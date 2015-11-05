using System;
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
        /// 获取所有角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色信息结果集</returns>
        public DataTable GetAllRole(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select ID, BuiltIn as 内置, Name as 名称, Description as 描述 from SYS_Role order by SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取角色对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>SYS_Role 角色对象实体</returns>
        public SYS_Role GetRole(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Role.SingleOrDefault(r => r.ID == id);
            }
        }

        /// <summary>
        /// 获取角色成员信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色成员信息结果集</returns>
        public DataTable GetRoleMember(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select * from RoleMember order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取角色成员用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色成员用户信息结果集</returns>
        public DataTable GetRoleUser(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select * from RoleUser";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取角色模块权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色模块权限授权信息结果集</returns>
        public DataTable GetRoleModulePermit(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select * from RoleModulePermit order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取角色操作权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色操作权限授权信息结果集</returns>
        public DataTable GetRoleActionPermit(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select * from RoleActionPermit order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取角色数据权限授权信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 角色数据权限授权信息结果集</returns>
        public DataTable GetRoleDataPermit(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select * from RoleDataPermit order by RoleId, Action, [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据角色ID获取可用的组织机构列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的组织机构列表</returns>
        public DataTable GetMemberOfTitle(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select O.ID, O.ParentId, O.NodeType, O.[Index], O.名称 from Organization O left join SYS_Role_Title T on T.OrgId = O.ID and T.RoleId = '{id}' where T.ID is null";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据角色ID获取可用的用户组列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的用户组列表</returns>
        public DataTable GetMemberOfGroup(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select G.ID, G.Name as 名称, G.Description as 描述 from SYS_UserGroup G left join SYS_Role_UserGroup R on R.GroupId = G.ID and R.RoleId = '{id}' where R.ID is null order by G.SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据角色ID获取可用的用户列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 可用的用户列表</returns>
        public DataTable GetMemberOfUser(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select U.ID, U.Name as 名称, U.LoginName as 登录名, U.Description as 描述 from SYS_User U left join SYS_Role_User R on R.UserId = U.ID and R.RoleId = '{id}' where U.Type > 0 and R.ID is null order by U.SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取指定角色的所有功能操作和授权
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 所有功能操作和授权</returns>
        public DataTable GetRoleActions(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select * from dbo.Get_RoleAction('{id}') order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取指定角色的所有相对数据权限
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>DataTable 所有相对数据权限</returns>
        public DataTable GetRoleRelData(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"exec Get_RoleData '{id}'";
            return SqlQuery(MakeCommand(sql));
        }

        #endregion

        #region 新增

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">角色对象实体</param>
        /// <param name="action">功能授权表</param>
        /// <param name="data">数据授权表</param>
        /// <param name="custom">自定义数据授权表</param>
        /// <returns>bool 数据插入是否成功</returns>
        public bool AddRole(Session us, SYS_Role obj, DataTable action, DataTable data, DataTable custom)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            const string sql = "insert SYS_Role (Name, Description, CreatorUserId) select @Name, @Description, @CreatorUserId; select ID from SYS_Role where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));
            cmds.AddRange(InsertRoleAction(obj.ID, action, us.UserId));
            cmds.AddRange(InsertRoleRelData(obj.ID, data, us.UserId));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据参数组集合插入角色成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="rid">角色ID</param>
        /// <param name="tids">职位ID集合</param>
        /// <param name="gids">用户组ID集合</param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 插入是否成功</returns>
        public bool AddRoleMember(Session us, Guid rid, List<Guid> tids, List<Guid> gids, List<Guid> uids)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            cmds.AddRange(InsertRoleTitle(rid, tids, us.UserId));
            cmds.AddRange(InsertRoleGroup(rid, gids, us.UserId));
            cmds.AddRange(InsertRoleUser(rid, uids, us.UserId));
            return SqlExecute(cmds);
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">角色对象实体</param>
        /// <param name="adl">功能删除列表</param>
        /// <param name="ddl">相对数据授权删除列表</param>
        /// <param name="cdl">绝对数据授权删除列表</param>
        /// <param name="adt">功能授权表</param>
        /// <param name="ddt">相对数据授权表</param>
        /// <param name="cdt">绝对数据授权表</param>
        /// <returns>bool 数据更新是否成功</returns>
        public bool EditRole(Session us, SYS_Role obj, List<object> adl, List<object> ddl, List<object> cdl, DataTable adt, DataTable ddt, DataTable cdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            const string sql = "update SYS_Role set Name = @Name, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            cmds.Add(MakeCommand(sql, parm));

            adl.ForEach(id => cmds.Add(MakeCommand($"delete SYS_RolePerm_Action where ID = '{id}'")));
            cmds.AddRange(InsertRoleAction(obj.ID, adt, us.UserId));

            ddl.ForEach(id => cmds.Add(MakeCommand($"delete SYS_RolePerm_Data where ID = '{id}'")));
            cmds.AddRange(InsertRoleRelData(obj.ID, ddt, us.UserId));

            //cdl.ForEach(id => cmds.Add(SqlHelper.MakeCommand(String.Format("delete SYS_RolePerm_DataAbs where ID = '{0}'", id))));

            return SqlExecute(cmds);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除角色
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">角色ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteRole(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"Delete from SYS_Role where ID = '{id}' and BuiltIn = 0";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 根据成员类型和ID删除角色成员
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="type">成员类型</param>
        /// <param name="id">角色成员ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteRoleMember(Session us, int type, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"Delete from {(type == 3 ? "SYS_Role_Title" : (type == 2 ? "SYS_Role_UserGroup" : "SYS_Role_User"))} where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        #endregion

    }
}
