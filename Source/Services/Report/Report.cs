using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class Report : IReport
    {

        #region 业务逻辑

        /// <summary>
        /// 生成报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="rid">报表定义ID</param>
        /// <param name="sd">开始日期</param>
        /// <param name="ed">截止日期</param>
        /// <param name="on">统计实体全称</param>
        /// <param name="oid">统计实体ID</param>
        /// <returns>SYS_Report_Instances 报表实例</returns>
        public SYS_Report_Instances BulidReport(Session us, Guid rid, DateTime? sd, DateTime? ed, string on, Guid oid)
        {
            return !SimpleVerifty(us) ? null : General.BulidReport(rid, sd, ed, @on, us.UserName, oid, us.UserId);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 增加一个模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">SYS_Report_Templates对象实体</param>
        /// <returns>object 新模板ID</returns>
        private object AddTemplet(Session us, SYS_Report_Templates obj)
        {
            const string sql = "insert SYS_Report_Templates (CategoryId, Name, Content, Description, CreatorDeptId, CreatorUserId) select @CategoryId, @Name, @Content, @Description, @CreatorDeptId, @CreatorUserId; select ID from SYS_Report_Templates where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Content", obj.Content),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlScalar(MakeCommand(sql, parm));
        }

        private IEnumerable<SqlCommand> InsertRules(Guid id, DataTable tab)
        {
            var cmds = new List<SqlCommand>();
            foreach (DataRow row in tab.Rows)
            {
                const string sql = "insert SYS_Report_Period (ReportId, RuleId) select @ReportId, @RuleId";
                var parm = new[]
                {
                    new SqlParameter("@ReportId", SqlDbType.UniqueIdentifier) {Value = id},
                    new SqlParameter("@RuleId", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
                };
                cmds.Add(MakeCommand(sql, parm));
            }
            return cmds;
        }

        private IEnumerable<SqlCommand> InsertEntitys(Guid id, DataTable edt, DataTable mdt)
        {
            var cmds = new List<SqlCommand>();
            foreach (DataRow row in edt.Rows)
            {
                if ((bool)row["Selected"])
                {
                    var sql = "insert SYS_Report_Entity (ReportId, OrgId) select @ReportId, @OrgId;";
                    sql += "select ID from SYS_Report_Entity where SN = scope_identity()";
                    var parm = new[]
                    {
                        new SqlParameter("@ReportId", SqlDbType.UniqueIdentifier) {Value = id},
                        new SqlParameter("@OrgId", SqlDbType.UniqueIdentifier) {Value = row["OrgId"]},
                        new SqlParameter("@Read", SqlDbType.Int) {Value = 0},
                        new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
                    };
                    cmds.Add(MakeCommand(sql, parm));
                }
                else
                {
                    const string sql = "select @ID";
                    var parm = new[]
                    {
                        new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                        new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
                    };
                    cmds.Add(MakeCommand(sql, parm));
                }
                cmds.AddRange(InsertMembers(mdt.Select($"OrgId = '{row["OrgId"]}'")));
            }
            return cmds;
        }

        private IEnumerable<SqlCommand> InsertMembers(IEnumerable<DataRow> rows)
        {
            const string sql = "insert SYS_Report_Member (EntityId, RoleId) select @EntityId, @RoleId";
            return rows.Select(row => new[]
            {
                new SqlParameter("@EntityId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty}, 
                new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) {Value = row["RoleId"]}, 
                new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
