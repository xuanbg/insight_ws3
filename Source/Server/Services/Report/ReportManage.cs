using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial class Report
    {

        #region 获取

        /// <summary>
        /// 获取全部报表信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报表信息列表</returns>
        public DataTable GetReports(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("with List as(Select D.ID, max(P.Permission) as Permission from SYS_Report_Definition D ");
            sql.Append("join Get_PermData('DD46BA9F-A345-4CEC-AE00-26561460E470', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.ID) ");
            sql.Append("select D.ID, D.CategoryId, case when D.Type = 1 then '组织' else '个人' end as 类型, case D.Mode when 1 then '时段' when 2 then '时点' else '即时' end as 模式, D.Name as 名称, T.Name as 模板, case when D.DataSource = 1 then '系统' else '模板' end as 数据源, D.[Description] as 备注, L.Permission from SYS_Report_Definition D join List L on L.ID = D.ID join SYS_Report_Templates T on T.ID = D.TemplateId order by D.SN");
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        /// <summary>
        /// 获取全部报表的分期信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分期信息列表</returns>
        public DataTable GetReportRules(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select P.ID, P.ReportId, R.Name from SYS_Report_Period P join SYS_Report_Rules R on R.ID = P.RuleId";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 获取全部报表的统计实体信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 统计实体信息列表</returns>
        public DataTable GetReportEntitys(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select E.ID, E.ReportId, O.FullName from SYS_Report_Entity E join SYS_Organization O on O.ID = E.OrgId";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 获取全部统计实体的报送对象信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报送对象信息列表</returns>
        public DataTable GetReportMembers(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select M.ID, M.EntityId, R.Name from SYS_Report_Member M join SYS_Role R on R.ID = M.RoleId";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 获取全部分期规则，当前报表所用规则对应Selected为1
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 分期规则列表</returns>
        public DataTable GetReportRule(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select R.ID, case when P.ID is null then cast(0 as bit) else cast(1 as bit) end as Selected, Name as 名称, ");
            sql.Append("cast(Cycle as varchar) + case CycleType when 1 then '年' when 2 then '月' when 3 then '周' when 4 then '日' else '-' end as 周期 ");
            sql.AppendFormat("from SYS_Report_Rules R left join SYS_Report_Period P on P.RuleId = R.ID and P.ReportId = '{0}'", id);
            return SqlHelper.SqlQuery(sql.ToString());
        }

        /// <summary>
        /// 获取全部可选的机构/部门
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 组织机构列表</returns>
        public DataTable GetReportEntity(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select case when E.ID is null then newid() else E.ID end as ID, O.ID as OrgId, O.ParentId, case when E.ID is null then cast(0 as bit) else cast(1 as bit) end as Selected, O.NodeType, O.[Index], O.名称 ");
            sql.AppendFormat("from Organization O left join SYS_Report_Entity E on E.OrgId = O.ID and E.ReportId = '{0}' where NodeType < 3", id);
            return SqlHelper.SqlQuery(sql.ToString());
        }

        /// <summary>
        /// 获取全部成员列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>DataTable 成员列表</returns>
        public DataTable GetReportMember(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select newid() as ID, O.ID as OrgId, R.ID as RoleId, case when M.ID is null then cast(0 as bit) else cast(1 as bit) end as Selected, R.Name as 名称, R.Description as 描述 ");
            sql.AppendFormat("from SYS_Role R join Organization O on O.NodeType < 3 left join SYS_Report_Entity E on E.OrgId = O.ID and E.ReportId = '{0}' left join SYS_Report_Member M on M.EntityId = E.ID and M.RoleId = R.ID order by R.SN", id);
            return SqlHelper.SqlQuery(sql.ToString());
        }

        #endregion

        #region 新增

        /// <summary>
        /// 新增报表定义
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="def">报表定义对象实体</param>
        /// <param name="rdt">分期子表</param>
        /// <param name="edt">实体子表</param>
        /// <param name="mdt">报送子表</param>
        /// <returns>bool 数据是否插入成功</returns>
        public bool AddDefinition(Session us, SYS_Report_Definition def, DataTable rdt, DataTable edt, DataTable mdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();

            var sql = new StringBuilder("insert SYS_Report_Definition (CategoryId, Name, TemplateId, Mode, Delay, [Type], DataSource, Description, CreatorDeptId, CreatorUserId) ");
            sql.Append("select @CategoryId, @Name, @TemplateId, @Mode, @Delay, @Type, @DataSource, @Description, @CreatorDeptId, @CreatorUserId;");
            sql.Append("select ID from SYS_Report_Definition where SN = scope_identity()");
            var parm = new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = def.CategoryId},
                new SqlParameter("@Name", def.Name),
                new SqlParameter("@TemplateId", SqlDbType.UniqueIdentifier) {Value = def.TemplateId},
                new SqlParameter("@Mode", def.Mode),
                new SqlParameter("@Delay", def.Delay),
                new SqlParameter("@Type", def.Type),
                new SqlParameter("@DataSource", def.DataSource),
                new SqlParameter("@Description", def.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql.ToString(), parm));
            cmds.AddRange(InsertRules(def.ID, rdt));
            cmds.AddRange(InsertEntitys(def.ID, edt, mdt));

            return SqlHelper.SqlExecute(cmds);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新报表定义
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="def">报表定义对象实体</param>
        /// <param name="rdl">分期规则删除列表</param>
        /// <param name="edl">会计主体删除列表</param>
        /// <param name="mdl">报送成员删除列表</param>
        /// <param name="rdt">分期子表</param>
        /// <param name="edt">实体子表</param>
        /// <param name="mdt">报送子表</param>
        /// <returns>bool 数据是否更新成功</returns>
        public bool EditDefinition(Session us, SYS_Report_Definition def, List<object> rdl, List<object> edl, List<object> mdl, DataTable rdt, DataTable edt, DataTable mdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            const string sql = "update SYS_Report_Definition set CategoryId = @CategoryId, Name = @Name, TemplateId = @TemplateId, Mode = @Mode, Delay = @Delay, [Type] = @Type, DataSource = @DataSource, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = def.CategoryId},
                new SqlParameter("@Name", def.Name),
                new SqlParameter("@TemplateId", SqlDbType.UniqueIdentifier) {Value = def.TemplateId},
                new SqlParameter("@Mode", def.Mode),
                new SqlParameter("@Delay", def.Delay),
                new SqlParameter("@Type", def.Type),
                new SqlParameter("@DataSource", def.DataSource),
                new SqlParameter("@Description", def.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = def.ID},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            cmds.AddRange(rdl.Select(id => SqlHelper.MakeCommand($"delete SYS_Report_Period where ReportId = '{def.ID}' and RuleId = '{id}'")));
            cmds.AddRange(edl.Select(id => SqlHelper.MakeCommand($"delete SYS_Report_Entity where ReportId = '{def.ID}' and OrgId = '{id}'")));
            cmds.AddRange(mdl.Select(id => SqlHelper.MakeCommand($"delete M from SYS_Report_Member M join SYS_Report_Entity E on E.ID = M.EntityId and E.ReportId = '{def.ID}' where RoleId = '{id}'")));

            cmds.AddRange(InsertRules(def.ID, rdt));
            cmds.AddRange(InsertEntitys(def.ID, edt, mdt));

            //cmds.AddRange(InsertMembers(def.ID, mdt));

            return SqlHelper.SqlExecute(cmds);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除报表定义记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表定义ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelReport(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"delete SYS_Report_Definition where ID = '{id}'";
            return SqlHelper.SqlNonQuery(sql) > 0;
        }

        #endregion

    }
}
