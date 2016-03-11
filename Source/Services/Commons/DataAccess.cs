using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class Commons
    {

        #region ImageData

        /// <summary>
        /// 保存ImageData
        /// </summary>
        /// <param name="imgs">ImageData对象集合</param>
        /// <param name="tab">附件表名称</param>
        /// <param name="col">附件表业务主记录ID字段名称</param>
        /// <param name="bid">业务主记录ID</param>
        /// <returns>是否保存成功</returns>
        public static bool InsertData(IEnumerable<ImageData> imgs, string tab, string col, Guid bid)
        {
            var sql = "insert ImageData (CategoryId, ImageType, Code, Name, Expand, SecrecyDegree, Pages, Size, Path, Image, Description, CreatorDeptId, CreatorUserId) ";
            sql += "select @CategoryId, @ImageType, @Code, @Name, @Expand, @SecrecyDegree, @Pages, @Size, @Path, @Image, @Description, @CreatorDeptId, @CreatorUserId select @ID = ID from ImageData where SN = SCOPE_IDENTITY() ";
            sql += $"insert {tab} ({col}, ImageId) select '{bid}', @ID";
            var cmds = imgs.Select(img => new[]
            {
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = img.CategoryId},
                new SqlParameter("@ImageType", img.ImageType),
                new SqlParameter("@Code", img.Code),
                new SqlParameter("@Name", img.Name),
                new SqlParameter("@Expand", img.Expand),
                new SqlParameter("@SecrecyDegree", SqlDbType.UniqueIdentifier) {Value = img.SecrecyDegree},
                new SqlParameter("@Pages", img.Pages),
                new SqlParameter("@Size", img.Size),
                new SqlParameter("@Path", img.Path),
                new SqlParameter("@Image", SqlDbType.Image) {Value = img.Image},
                new SqlParameter("@Description", img.Description),
                new SqlParameter("@Validity", img.Validity),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = img.CreatorDeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = img.CreatorUserId},
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier) {Value = bid}
            }).Select(parm => MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID在数据库中删除电子影像记录
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>bool 是否成功</returns>
        private bool? DeleteImage(Guid id)
        {
            using (var context = new WSEntities())
            {
                var image = context.ImageData.SingleOrDefault(i => i.ID == id);
                if (image == null) return null;

                context.ImageData.Remove(image);
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据ID读取电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>ImageData</returns>
        private ImageData ReadImage(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.ImageData.SingleOrDefault(i => i.ID == id);
            }
        }

        #endregion

        #region Categorys

        /// <summary>
        /// 保存BASE_Category到数据库
        /// </summary>
        /// <param name="obj">BASE_Category</param>
        /// <param name="index">索引位置</param>
        /// <returns>bool 是否成功</returns>
        private bool InsertData(BASE_Category obj, int index)
        {
            var cmds = new List<SqlCommand>();
            var sql = "insert BASE_Category (ParentId, ModuleId, [Index], Code, Name, Alias, Description, CreatorDeptId, CreatorUserId) ";
            sql += "select @ParentId, @ModuleId, @Index, @Code, @Name, @Alias, @Description, @CreatorDeptId, @CreatorUserId;";
            sql += "select ID from BASE_Category where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = obj.ModuleId},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorDeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId}
            };
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", index, obj.Index, obj.ParentId, false, obj.ModuleId)));
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID删除分类数据
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>bool 是否成功</returns>
        private bool? DeleteCategory(Guid id)
        {
            var cmds = new List<SqlCommand>();
            var obj = ReadCategory(id);
            cmds.Add(MakeCommand($"delete BASE_Category where ID = '{id}'"));
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", obj.Index, 99999, obj.ParentId, false, obj.ModuleId)));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新分类数据
        /// </summary>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>bool 是否成功</returns>
        private bool UpdateData(BASE_Category obj, int index, Guid? oldParentId, int oldIndex)
        {
            var cmds = new List<SqlCommand>();
            var sql = "update BASE_Category set ParentId = @ParentId, [Index] = @Index, Code = @Code, Name = @Name, Alias = @Alias, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", index, obj.Index, obj.ParentId, false, obj.ModuleId)));
            cmds.Add(MakeCommand(sql, parm));
            if (obj.ParentId != oldParentId)
            {
                cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", oldIndex, 9999, oldParentId, false, obj.ModuleId)));
            }
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID读取分类数据
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>BASE_Category</returns>
        private BASE_Category ReadCategory(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.BASE_Category.SingleOrDefault(c => c.ID == id);
            }
        }

        /// <summary>
        /// 读取分类数据
        /// </summary>
        /// <returns></returns>
        private DataTable ReadCategorys(string mid, bool getAll, bool hasAlias)
        {
            var str = hasAlias ? "case when Alias is null then '' else '(' + Alias + ')' end" : "''";
            var sql = $"select ID, ParentId, [Index], Name + {str} as Name, Alias, Code, BuiltIn, Visible from BASE_Category where ModuleId = '{mid}'{(getAll ? "" : " and Visible = 1")} order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取分类下元素数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private int GetCounts(Guid? id, string type, string table)
        {
            var sql = $"select count(ID) from {table} where {type} {(id.HasValue ? "= @ID" : "is null")}";
            var parm = new[] { new SqlParameter("@ID", SqlDbType.UniqueIdentifier) { Value = id } };
            return (int)SqlScalar(MakeCommand(sql, parm));
        }

        #endregion

    }
}
