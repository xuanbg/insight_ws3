﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    partial class Base
    {

        #region 获取

        /// <summary>
        /// 获取全部用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户组结果集</returns>
        public DataTable GetGroups(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select ID, BuiltIn as 内置, Name as 组名称, Description as 描述 From SYS_UserGroup where Visible = 1 order by SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取用户组对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>SYS_UserGroup 用户组对象</returns>
        public SYS_UserGroup GetGroup(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_UserGroup.SingleOrDefault(e => e.ID == id);
            }
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户结果集</returns>
        public DataTable GetUsers(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select ID, BuiltIn as 内置, Name as 名称, LoginName as 登录名, Description as 描述, Case Validity when 1 then '正常' else '封禁' end 状态 From SYS_User where Type > 0 order by SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取用户对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>SYS_User 用户对象</returns>
        public SYS_User GetUser(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_User.SingleOrDefault(e => e.ID == id);
            }
        }

        /// <summary>
        /// 获取全部用户组的所有成员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部用户组成员信息结果集</returns>
        public DataTable GetGroupMembers(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select M.ID, U.Name as 用户名, U.LoginName as 登录名, U.Description as 描述, M.GroupId, M.UserId from SYS_UserGroupMember M join SYS_User U on U.ID = M.UserId order by U.SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取组成员之外的全部用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>DataTable 组成员之外所有用户信息结果集</returns>
        public DataTable GetGroupMemberBeSides(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select U.ID, U.Name as 用户名, U.LoginName as 登录名, U.Description as 描述 from SYS_User U where U.Type > 0 ";
            sql += $"and not exists (select UserId from SYS_UserGroupMember where UserId = U.ID and GroupId = '{id}') order by U.LoginName";
            return SqlQuery(MakeCommand(sql));
        }

        #endregion

        #region 新增

        /// <summary>
        /// 根据对象实体数据新增一个用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户组对象</param>
        /// <returns>object 插入的用户组ID </returns>
        public object AddGroup(Session us, SYS_UserGroup obj)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "insert into SYS_UserGroup (Name, Description, CreatorUserId) select @Name, @Description, @CreatorUserId select ID From SYS_UserGroup where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlScalar(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据对象实体数据新增一个用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户对象</param>
        /// <returns>bool 是否插入成功</returns>
        public bool AddUser(Session us, SYS_User obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = "insert SYS_User (ID, Name, LoginName, Password, PayPassword, OpenId, Description, Type, CreatorUserId) ";
            sql += "select @ID, @Name, @LoginName, @Password, @PayPassword, @OpenId, @Description, @Type, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@LoginName", obj.LoginName),
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@PayPassword", obj.PayPassword),
                new SqlParameter("@OpenId", obj.OpenId),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Type", SqlDbType.Int) {Value = 1},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 根据参数组集合批量插入用户组成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="gid">用户组ID</param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 是否插入成功</returns>
        public bool AddGroupMember(Session us, Guid gid, List<Guid> uids)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "insert into SYS_UserGroupMember (GroupId, UserId, CreatorUserId) select @GroupId, @UserId, @CreatorUserId";
            var cmds = uids.Select(id => new[]
            {
                new SqlParameter("@GroupId", SqlDbType.UniqueIdentifier) {Value = gid}, 
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = id}, 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
            return SqlExecute(cmds);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 根据对象实体数据更新用户组信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户组对象</param>
        /// <returns>bool 是否更新成功</returns>
        public bool UpdateGroup(Session us, SYS_UserGroup obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "update SYS_UserGroup set Name = @Name, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Description", obj.Description)
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 根据对象实体数据更新用户信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户对象</param>
        /// <returns>bool 是否更新成功</returns>
        public bool UpdateUser(Session us, SYS_User obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "update SYS_User set Name = @Name, LoginName = @LoginName, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@LoginName", obj.LoginName),
                new SqlParameter("@Description", obj.Description)
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 根据ID封禁/解封用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <param name="validity">true:解封；false:封禁</param>
        /// <returns>bool 是否更新成功</returns>
        public bool UpdateUserStatus(Session us, Guid id, bool validity)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"update SYS_User set Validity = '{validity}' where ID = '{id}'";
            if (SqlNonQuery(MakeCommand(sql)) > 0)
            {
                OnlineManage.Sessions.Find(s => s.UserId == id).Validity = validity;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据ID重置用户密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否更新成功</returns>
        public bool ResetPassword(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string pw = "E10ADC3949BA59ABBE56E057F20F883E";
            var sql = $"update SYS_User set Password = '{pw}' where ID = '{id}'";
            if (SqlNonQuery(MakeCommand(sql)) > 0)
            {
                OnlineManage.Sessions.Find(s => s.UserId == id).Signature = pw;
                return true;
            }
            return false;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除用户组
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户组ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteGroup(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"Delete from SYS_UserGroup where ID = '{id}' and BuiltIn = 0";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 根据ID删除用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteUser(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"Delete from SYS_User where ID = '{id}' and BuiltIn = 0";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 根据ID集合删除用户组成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="ids">户组成员关系ID集合</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteMember(Session us, List<Guid> ids)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "Delete from SYS_UserGroupMember where ID = @ID";
            var cmds = ids.Select(id => new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
            return SqlExecute(cmds);
        }

        #endregion

    }
}
