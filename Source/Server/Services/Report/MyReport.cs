using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial class Report
    {

        #region 获取

        /// <summary>
        /// 获取当前用户所有可选报表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 可阅读报表</returns>
        public DataTable GetMyReports(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as (select distinct R.ID, R.SN, R.CategoryId, R.Name from SYS_Report_Definition R join SYS_Report_Entity E on E.ReportId = R.ID join SYS_Report_Member M on M.EntityId = E.ID join Get_PermRole(@UserId, @DeptId) P on P.RoleId = M.RoleId) ";
            sql += "select distinct C.ID, C.[Index], C.ParentId, C.Name, cast(0 as bit) as IsData from BASE_Category C join List L on L.CategoryId = C.ID union all select L.ID, L.SN as [Index], L.CategoryId as ParentId, L.Name, cast(1 as bit) as IsData from List L order by [Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 获取当前用户所有可阅读报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报表实例</returns>
        public DataTable GetInstances(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select distinct I.ID, I.Name, I.ReportId, I.CreateTime, R.ID as RID from SYS_Report_Instances I join SYS_Report_IU R on R.InstanceId = I.ID and R.UserId = '{us.UserId}' order by I.CreateTime desc";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 获得用户可选组织机构列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="reportId">所选报表ID</param>
        /// <returns>DataTable 可选组织机构列表</returns>
        public DataTable GetMyReportEntitys(Session us, Guid reportId)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select distinct O.ID, O.FullName from SYS_Report_Entity R join SYS_Report_Member M on M.EntityId = R.ID join Get_PermRole(@UserId, @DeptId) P on P.RoleId = M.RoleId join SYS_Organization O on O.ID = R.OrgId where R.ReportId = @ReportId";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@ReportId", SqlDbType.UniqueIdentifier) {Value = reportId}
            };
            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 根据ID获取报表定义对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>SYS_Report_Definition 报表定义对象实体</returns>
        public SYS_Report_Definition GetDefinition(Session us, Guid id)
        {
            return !OnlineManage.Verification(us) ? null : ReportDAL.GetDefinition(id);
        }

        /// <summary>
        /// 根据ID获取报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表实例ID</param>
        /// <returns>SYS_Report_Instances 报表实例</returns>
        public SYS_Report_Instances GetReportInstance(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Report_Instances.SingleOrDefault(e => e.ID == id);
            }
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加即时报表数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">报表实例对象实体</param>
        /// <returns>object 返回插入成功记录的ID</returns>
        public SYS_Report_IU AddInstance(Session us, SYS_Report_Instances obj)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "insert SYS_Report_Instances(ReportId, Name, Content, CreatorUserId) select @ReportId, @Name, @Content, @CreatorUserId; select ID from SYS_Report_Instances where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ReportId", SqlDbType.UniqueIdentifier) {Value = obj.ReportId},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Content", obj.Content),
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            var id = SqlHelper.SqlScalar(sql, parm);

            if (id == null)
            {
                return null;
            }
            var iu = new SYS_Report_IU
            {
                InstanceId = (Guid) id,
                ID = (Guid)SqlHelper.SqlScalar($"select ID from SYS_Report_IU where InstanceId = '{id}' and UserId = '{us.UserId}'")
            };
            return iu;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID查询该关系对应实例的用户关系数
        /// 如关系数大于1，删除报表实例和用户关系
        /// 否则删除该关系对应报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表实例和用户关系ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DeleteReportIU(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"select count(1) from SYS_Report_IU A join SYS_Report_IU B on B.InstanceId = A.InstanceId where B.ID = '{id}'";
            sql = string.Format((int)SqlHelper.SqlScalar(sql) > 1 ? "delete from SYS_Report_IU where ID = '{0}'" : "delete I from SYS_Report_Instances I join SYS_Report_IU R on R.InstanceId = I.ID and R.ID = '{0}'", id);
            return SqlHelper.SqlNonQuery(sql) > 0;
        }

        #endregion

    }
}
