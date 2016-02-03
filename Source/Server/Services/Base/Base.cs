using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using static Insight.WS.Server.Common.General;

namespace Insight.WS.Service
{
    public partial class Base : IBase
    {

        #region 公共方法

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>Session List 在线用户列表</returns>
        public List<Session> GetOnlineUser(Session us)
        {
            return null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 拼装插入角色职位成员关系SqlCommand集合
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="ids">职位ID集合</param>
        /// <param name="uid">当前登录用户ID</param>
        /// <returns>SqlCommand List 角色职位成员关系SqlCommand集合</returns>
        private IEnumerable<SqlCommand> InsertRoleTitle(Guid rid, IEnumerable<Guid> ids, Guid uid)
        {
            const string sql = "insert SYS_Role_Title(RoleId, OrgId, CreatorUserId) select @RoleId, @OrgId, @CreatorUserId";
            return ids.Select(id => new[]
            {
                new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = rid}, 
                new SqlParameter("@OrgId", SqlDbType.UniqueIdentifier) {Value = id}, 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = uid}
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 拼装插入角色用户组成员关系SqlCommand集合
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="ids">用户组ID集合</param>
        /// <param name="uid">当前登录用户ID</param>
        /// <returns>SqlCommand List 角色用户组成员关系SqlCommand集合</returns>
        private IEnumerable<SqlCommand> InsertRoleGroup(Guid roleId, IEnumerable<Guid> ids, Guid uid)
        {
            const string sql = "insert SYS_Role_UserGroup(RoleId, GroupId, CreatorUserId) select @RoleId, @GroupId, @CreatorUserId";
            return ids.Select(id => new[]
            {
                new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = roleId},
                new SqlParameter("@GroupId", SqlDbType.UniqueIdentifier) {Value = id}, 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = uid}
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 拼装插入角色用户成员关系SqlCommand集合
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="ids">用户ID集合</param>
        /// <param name="uid">当前登录用户ID</param>
        /// <returns>SqlCommand List 角色用户成员关系SqlCommand集合</returns>
        private IEnumerable<SqlCommand> InsertRoleUser(Guid roleId, IEnumerable<Guid> ids, Guid uid)
        {
            const string sql = "insert SYS_Role_User(RoleId, UserId, CreatorUserId) select @RoleId, @UserId, @CreatorUserId";
            return ids.Select(id => new[]
            {
                new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = roleId}, 
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = id}, 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = uid}
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 拼装角色操作权限SqlCommand集合
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="uid">当前登录用户ID</param>
        /// <param name="id"></param>
        /// <returns>SqlCommand List 角色操作权限SqlCommand集合</returns>
        private IEnumerable<SqlCommand> InsertRoleAction(Guid id, DataTable dt, Guid uid)
        {
            const string sql = "insert SYS_RolePerm_Action(RoleId, ActionId, Action, CreatorUserId) select @RoleId, @ActionId, @Action, @CreatorUserId";
            return (from DataRow row in dt.Rows
                select new[]
                {
                    new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = id}, 
                    new SqlParameter("@ActionId", SqlDbType.UniqueIdentifier) {Value = (Guid) row["ActionId"]}, 
                    new SqlParameter("@Action", row["Info"].ToString() == "允许" ? 1 : 0), 
                    new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = uid}, 
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
                } into parm
                select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 拼装角色数据权限SqlCommand集合
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="uid">当前登录用户ID</param>
        /// <param name="id"></param>
        /// <returns>SqlCommand List 角色数据权限SqlCommand集合</returns>
        private IEnumerable<SqlCommand> InsertRoleRelData(Guid id, DataTable dt, Guid uid)
        {
            const string sql = "insert SYS_RolePerm_Data(RoleId, ModuleId, Mode, Permission, CreatorUserId) select @RoleId, @ModuleId, @Mode, @Permission, @CreatorUserId";
            return (from DataRow row in dt.Rows
                select new[]
                {
                    new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = id}, 
                    new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = (Guid) row["ParentId"]}, 
                    new SqlParameter("@Mode", (int) row["Action"] - 4), 
                    new SqlParameter("@Permission", row["Info"].ToString() == "读写" ? 1 : 0),
                    new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = uid},
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
                } into parm
                select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
