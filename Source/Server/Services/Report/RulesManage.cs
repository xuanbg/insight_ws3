using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class Report
    {

        #region 获取

        /// <summary>
        /// 获取全部分期规则
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分期规则列表</returns>
        public DataTable GetRules(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(Select D.ID, max(P.Permission) as Permission from SYS_Report_Rules D ";
            sql += "join Get_PermData('6C0C486F-E039-4C53-9F36-9FE262FB0D3C', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.ID) ";
            sql += "select D.ID, D.BuiltIn as 预置, D.Name as 名称, cast(D.Cycle as varchar(4)) + case D.CycleType when 1 then '年' when 2 then '月' when 3 then '周' when 4 then '日' else '-' end as 周期, ";
            sql += "D.StartTime as 分期起始, D.[Description] as 备注, D.CreateTime as 创建日期, L.Permission from SYS_Report_Rules D join List L on L.ID = D.ID order by D.SN";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取分期规则对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期规则ID</param>
        /// <returns>SYS_Report_Rules 分期规则对象实体</returns>
        public SYS_Report_Rules GetRule(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Report_Rules.SingleOrDefault(r => r.ID == id);
            }
        }

        #endregion

        #region 新增

        /// <summary>
        /// 插入一条分期规则记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期规则对象实体</param>
        /// <returns>object 返回插入成功记录的ID</returns>
        public object AddRule(Session us, SYS_Report_Rules obj)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "insert SYS_Report_Rules (Name, CycleType, Cycle, StartTime, [Description], CreatorDeptId, CreatorUserId) select @Name, @CycleType, @Cycle, @StartTime, @Description, @CreatorDeptId, @CreatorUserId; select ID from SYS_Report_Rules where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@CycleType", obj.CycleType),
                new SqlParameter("@Cycle", obj.Cycle),
                new SqlParameter("@StartTime", obj.StartTime),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlScalar(MakeCommand(sql, parm));
        }

        #endregion

        #region 更新

        /// <summary>
        /// 根据对象实体更新分期规则
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期规则对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool EditRule(Session us, SYS_Report_Rules obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "update SYS_Report_Rules set Name = @Name, CycleType = @CycleType, Cycle = @Cycle, StartTime = @StartTime, [Description] = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@CycleType", obj.CycleType),
                new SqlParameter("@Cycle", obj.Cycle),
                new SqlParameter("@StartTime", obj.StartTime),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除分期规则记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期规则ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelRule(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"delete SYS_Report_Rules where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        #endregion

    }
}
