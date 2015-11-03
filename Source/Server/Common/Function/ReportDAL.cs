using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FastReport;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Server.Common
{
    public class ReportDAL
    {

        /// <summary>
        /// 获取任务、生成报表并保存
        /// </summary>
        /// <returns>bool 是否完成当前任务</returns>
        public static bool Build()
        {
            var time = DateTime.Now;
            Util.LogToEvent($"报表生成任务已经于{time}启动…", EventLogEntryType.Information);
            var task = GetTask();
            var obj = new List<SYS_Report_Instances>();
            string temp = null;
            var i = 0;

            foreach (var s in task)
            {
                temp = temp ?? GetTemplate(s.TemplateId).Content;
                obj.Add(BulidReport(s.ReportId, s.StartDate, s.EndDate, s.DeptName, "Insight WS", s.DeptId, s.UserId, temp));
                i++;
                if (i < task.Count && s.SchedularId == task[i].SchedularId) continue;

                SaveInstances(obj, s.NextDate, s.SchedularId);
                obj.Clear();
                temp = null;
            }
            Util.LogToEvent($"本次报表生成任务已经于{DateTime.Now}完成！共耗时：{(DateTime.Now - time).Seconds}秒。", EventLogEntryType.Information);
            return true;
        }

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
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
            cmds.Add(SqlHelper.MakeCommand(string.Format("update SYS_Report_Schedular set BuildTime = '{0}' where ID = '{1}' and BuildTime < '{0}'", time, id)));
            SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 生成报表实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sd">开始日期</param>
        /// <param name="ed">截止日期</param>
        /// <param name="dn">会计主体名称</param>
        /// <param name="un">制表人名称</param>
        /// <param name="did">会计主体ID</param>
        /// <param name="uid">用户ID</param>
        /// <param name="templat"></param>
        /// <returns>SYS_Report_Instances 报表实例对象实体</returns>
        public static SYS_Report_Instances BulidReport(Guid id, DateTime? sd, DateTime? ed, string dn, string un, Guid did, Guid? uid, string templat = null)
        {
            var report = GetDefinition(id);
            var conStr = SqlHelper.ConStr[report.DataSource];
            var name = $"{dn}【{report.Name}】{sd?.ToShortDateString() ?? ""}—{ed?.ToShortDateString() ?? ""}";
            var fr = new Report();

            fr.LoadFromString(templat ?? GetTemplate(report.TemplateId).Content);

            if (conStr != null) fr.Dictionary.Connections[0].ConnectionString = conStr;

            fr.SetParameterValue("StartDate", sd);
            fr.SetParameterValue("EndDate", ed);
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did.ToString());
            fr.SetParameterValue("UserId", uid?.ToString());

            if (!fr.Prepare()) return null;

            var stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            var instance = new SYS_Report_Instances
            {
                ReportId = id,
                Name = name.Replace("-", "/").Replace("/", "."),
                Content = bytes,
                CreatorUserId = uid
            };
            return instance;
        }

        /// <summary>
        /// 根据指定报表模板生成业务电子影像
        /// </summary>
        /// <param name="id">业务ID</param>
        /// <param name="templetId">报表模板ID</param>
        /// <param name="dn"></param>
        /// <param name="un"></param>
        /// <param name="did"></param>
        /// <param name="uid"></param>
        /// <param name="obj"></param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public static ImageData BuildImage(Guid id, Guid templetId, string dn, string un, Guid? did, Guid uid, ImageData obj)
        {
            var img = obj ?? new ImageData();
            var fr = new Report();

            fr.LoadFromString(GetTemplate(templetId).Content);
            fr.Dictionary.Connections[0].ConnectionString = SqlHelper.ConStr["WSEntities"];
            fr.SetParameterValue("BusinessId", id.ToString());
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did?.ToString());
            fr.SetParameterValue("UserId", uid.ToString());
            if (!fr.Prepare()) return img;

            Stream stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            img.Name = id.ToString();
            img.Expand = "fpx";
            img.Pages = fr.PreparedPages.Count;
            img.Size = stream.Length;
            img.Image = bytes;
            return img;
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
            return SqlHelper.SqlScalar(sql, parm);
        }
    
    }
}
