using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;

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
            return !OnlineManage.Verification(us) ? null : ReportDAL.BulidReport(rid, sd, ed, @on, us.UserName, oid, us.UserId);
        }

        #endregion

        #region 私有方法

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
                cmds.Add(SqlHelper.MakeCommand(sql, parm));
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
                    cmds.Add(SqlHelper.MakeCommand(sql, parm));
                }
                else
                {
                    const string sql = "select @ID";
                    var parm = new[]
                    {
                        new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                        new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
                    };
                    cmds.Add(SqlHelper.MakeCommand(sql, parm));
                }
                cmds.AddRange(InsertMembers(mdt.Select(string.Format("OrgId = '{0}'", row["OrgId"]))));
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
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
