using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

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
            if (!SimpleVerifty(us)) return null;

            var sql = "select ID, [Index], Name, Icon from SYS_ModuleGroup where ID in ";
            sql += "(select ModuleGroupId from SYS_Module M join dbo.Get_PermModule(@UserId, @DeptId) P on P.ModuleId = M.ID) ";
            sql += "order by [Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取用户获得授权的所有模块信息
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 模块列表</returns>
        public DataTable GetUserModule(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select ModuleGroupId, ID, [Index], ProgramName, MainFrom, ApplicationName, Location, [Default], Icon from SYS_Module M ";
            sql += "join dbo.Get_PermModule(@UserId, @DeptId) P on P.ModuleId = M.ID where M.Validity = 1 order by M.[Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取模块对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">模块ID</param>
        /// <returns>SYS_Module 模块对象实体</returns>
        public SYS_Module GetModuleInfo(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

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
            if (!SimpleVerifty(us)) return null;

            var sql = "select A.*, cast(case when PA.ActionId is null then 0 else 1 end as bit) as [Enable] from SYS_ModuleAction A ";
            sql += "left join dbo.Get_PermAction(@ModuleId, @UserId, @DeptId) PA on PA.ActionId = A.ID ";
            sql += "where A.ModuleId = @ModuleId order by A.[Index]";
            var parm = new[]
            {
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = id},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 修改指定用户的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public bool UpdataPassWord(Session us, string pw)
        {
            return SimpleVerifty(us) && UpdateSignature(us, us.UserId, pw);
        }

        /// <summary>
        /// 设置指定用户的状态为离线
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否成功</returns>
        public bool Logout(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return false;

            SetUserOffline(us, id);
            return true;
        }

        #endregion

    }
}
