using System;
using System.Data;
using System.Data.SqlClient;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class Report
    {

        #region 获取

        /// <summary>
        /// 获取所有模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 模板列表</returns>
        public DataTable GetTemplates(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(Select D.ID, max(P.Permission) as Permission from SYS_Report_Templates D ";
            sql += "join Get_PermData('AD0BD296-46F5-46B3-85B9-00B6941343E7', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.ID) ";
            sql += "select T.ID, T.CategoryId, T.Name 名称, T.Description 描述, U.Name as 创建人, T.CreateTime as 创建日期, L.Permission from SYS_Report_Templates T join List L on L.ID = T.ID join SYS_User U on U.ID = T.CreatorUserId order by T.SN";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取模板对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">模板ID</param>
        /// <returns>SYS_Report_Templates 模板对象实体</returns>
        public SYS_Report_Templates GetTemplate(Session us, Guid id)
        {
            return !OnlineManage.Verification(us) ? null : ReportDAL.GetTemplate(id);
        }

        #endregion

        #region 新增

        /// <summary>
        /// 复制模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="tid">源模板ID</param>
        /// <param name="obj">SYS_Report_Templates对象实体</param>
        /// <returns>object 新模板ID</returns>
        public object CopyTemplet(Session us, Guid tid, SYS_Report_Templates obj)
        {
            if (!OnlineManage.Verification(us)) return null;

            obj.Content = GetTemplate(us, tid).Content;
            return AddTemplet(us, obj);
        }

        /// <summary>
        /// 增加一个模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">SYS_Report_Templates对象实体</param>
        /// <returns>object 新模板ID</returns>
        public object AddTemplet(Session us, SYS_Report_Templates obj)
        {
            if (!OnlineManage.Verification(us)) return null;

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

        #endregion

        #region 更新

        /// <summary>
        /// 根据传入的模板对象实体更新模板信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool EditTemplets(Session us, SYS_Report_Templates obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "update SYS_Report_Templates set CategoryId = @CategoryId, Name = @Name, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 用传入的参数Content更新指定ID的模板Content字段
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="content">模板内容</param>
        /// <param name="id">模板ID</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateContent(Session us, string content, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "update SYS_Report_Templates set Content = @Content where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@Content", content),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除指定ID的模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">模板ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelTemplets(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"delete from SYS_Report_Templates where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        #endregion

    }
}
