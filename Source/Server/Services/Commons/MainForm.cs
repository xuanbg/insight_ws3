using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{

    public partial class Commons
    {

        #region 获取数据

        /// <summary>
        /// 获取用户获得授权的所有模块的组信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 模块组列表</returns>
        public DataTable GetModuleGroup(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select ID, [Index], Name, Icon from SYS_ModuleGroup where ID in ");
            sql.Append("(select ModuleGroupId from SYS_Module M join dbo.Get_PermModule(@UserId, @DeptId) P on P.ModuleId = M.ID) ");
            sql.Append("order by [Index]");
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        /// <summary>
        /// 获取用户获得授权的所有模块信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 模块列表</returns>
        public DataTable GetUserModule(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select ModuleGroupId, ID, [Index], ProgramName, MainFrom, ApplicationName, Location, [Default], Icon from SYS_Module M ");
            sql.Append("join dbo.Get_PermModule(@UserId, @DeptId) P on P.ModuleId = M.ID where M.Validity = 1 order by M.[Index]");
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        /// <summary>
        /// 根据ID获取模块对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">模块ID</param>
        /// <returns>SYS_Module 模块对象实体</returns>
        public SYS_Module GetModuleInfo(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Module.SingleOrDefault(m => m.ID == id);
            }
        }

        /// <summary>
        /// 获取用户启动模块的工具栏操作信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">模块ID</param>
        /// <returns>DataTable 工具栏功能列表</returns>
        public DataTable GetAction(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select A.*, cast(case when PA.ActionId is null then 0 else 1 end as bit) as [Enable] from SYS_ModuleAction A ");
            sql.Append("left join dbo.Get_PermAction(@ModuleId, @UserId, @DeptId) PA on PA.ActionId = A.ID ");
            sql.Append("where A.ModuleId = @ModuleId order by A.[Index]");
            var parm = new[]
            {
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = id},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 修改指定登录名的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public bool UpdataPassWord(Session us, string pw)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = string.Format("update SYS_User set Password = '{0}' where ID = '{1}' ", pw, us.UserId);
            return SqlHelper.SqlNonQuery(sql) > 0;
        }

        #endregion

        #region 业务逻辑

        /// <summary>
        /// 删除在线用户会话
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>bool 是否删除成功</returns>
        public bool Exit(Session us)
        {
            if (us == null) return false;
            if (!OnlineManage.Verification(us)) return false;

            var ls = OnlineManage.Sessions.Find(s => s.SessionId == us.SessionId);
            return OnlineManage.Sessions.Remove(ls);
        }

        #endregion

    }
}
