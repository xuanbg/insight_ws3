using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Server.Common
{
    public partial class DataAccess
    {

        /// <summary>
        /// 获取报表生成任务
        /// </summary>
        /// <returns></returns>
        public static List<ReportSchedular> GetTask()
        {
            using (var context = new WSEntities())
            {
                return context.ReportSchedular.Where(r => r.BuildTime < DateTime.Now).OrderBy(r => r.SchedularId).ToList();
            }
        }

        /// <summary>
        /// 根据ID获取报表定义对象实体
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <returns>SYS_Report_Definition 报表定义对象实体</returns>
        public static SYS_Report_Definition GetDefinition(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_Report_Definition.SingleOrDefault(e => e.ID == id);
            }
        }

        /// <summary>
        /// 根据ID获取模板对象实体
        /// </summary>
        /// <param name="id">模板ID</param>
        /// <returns>SYS_Report_Templates 模板对象实体</returns>
        public static SYS_Report_Templates GetTemplate(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_Report_Templates.SingleOrDefault(t => t.ID == id);
            }
        }

        /// <summary>
        /// 保存报表实例
        /// </summary>
        /// <param name="objs">报表实例对象实体</param>
        /// <param name="time"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void SaveInstances(IEnumerable<SYS_Report_Instances> objs, DateTime? time, Guid id)
        {
            const string sql = "insert SYS_Report_Instances(ReportId, Name, Content, CreatorUserId) select @ReportId, @Name, @Content, @CreatorUserId";
            var cmds = objs.Select(obj => new[]
            {
                new SqlParameter("@ReportId", SqlDbType.UniqueIdentifier) {Value = obj.ReportId}, 
                new SqlParameter("@Name", obj.Name), 
                new SqlParameter("@Content", obj.Content), 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
            cmds.Add(MakeCommand(string.Format("update SYS_Report_Schedular set BuildTime = '{0}' where ID = '{1}' and BuildTime < '{0}'", time, id)));
            SqlExecute(cmds);
        }

        /// <summary>
        /// 保存电子影像
        /// </summary>
        /// <param name="obj">电子影像对象实体</param>
        /// <returns>object 电子影像ID</returns>
        public static object SaveImage(ImageData obj)
        {
            var sql = "insert ImageData (CategoryId, ImageType, Code, Name, [Expand], SecrecyDegree, Pages, Size, [Path], [Image], [Description], CreatorDeptId, CreatorUserId) ";
            sql += "select @CategoryId, @ImageType, @Code, @Name, @Expand, @SecrecyDegree, @Pages, @Size, @Path, @Image, @Description, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ImageData where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@ImageType", obj.ImageType),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Expand", obj.Expand),
                new SqlParameter("@SecrecyDegree", SqlDbType.UniqueIdentifier) {Value = obj.SecrecyDegree},
                new SqlParameter("@Pages", obj.Pages),
                new SqlParameter("@Size", obj.Size),
                new SqlParameter("@Path", obj.Path),
                new SqlParameter("@Image", SqlDbType.Image) {Value = obj.Image},
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorDeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId}
            };
            return SqlScalar(MakeCommand(sql, parm));
        }
    
    }
}
