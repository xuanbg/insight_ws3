using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public class Report
    {

        /// <summary>
        /// 获取报表生成任务
        /// </summary>
        /// <returns></returns>
        public static List<ReportSchedular> GetTask()
        {
            using (var context = new Entities())
            {
                return context.ReportSchedular.Where(r => r.BuildTime < DateTime.Now).OrderBy(r => r.SchedularId).ToList();
            }
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
            return SqlHelper.SqlScalar(SqlHelper.MakeCommand(sql, parm));
        }
    
    }
}
