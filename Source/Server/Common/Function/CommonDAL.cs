using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Insight.WS.Server.Common
{
    public class CommonDAL
    {

        #region 公共数据接口

        /// <summary>
        /// 根据用户登录名获取用户对象实体
        /// </summary>
        /// <param name="str">用户登录名</param>
        /// <returns>SYS_User 用户对象实体</returns>
        public static SYS_User GetUser(string str)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_User.SingleOrDefault(s => s.LoginName == str);
            }
        }

        /// <summary>
        /// 根据传入参数获取业务编码
        /// </summary>
        /// <param name="sid">编码方案ID</param>
        /// <param name="did">登录部门ID</param>
        /// <param name="uid">登录用户ID</param>
        /// <param name="bid">业务记录ID</param>
        /// <param name="mid">业务模块ID</param>
        /// <param name="str">自定义字符编码字段</param>
        /// <returns>string 业务编码</returns>
        public static string GetSerialCode(Guid sid, Guid bid, Guid? mid, Guid? did, Guid uid, string str = null)
        {
            const string sql = "exec Get_Code @SchemeId, @DeptId, @UserId, @BusinessId, @ModuleId, @Char, @Code";
            var parm = new[]
            {
                new SqlParameter("@SchemeId", SqlDbType.UniqueIdentifier) {Value = sid},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = did},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = uid},
                new SqlParameter("@BusinessId", SqlDbType.UniqueIdentifier) {Value = bid},
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = mid},
                new SqlParameter("@Char", str),
                new SqlParameter("@Code", SqlDbType.VarChar)
            };
            return SqlHelper.SqlScalar(sql, parm).ToString();
        }

        /// <summary>
        /// 获取可用服务列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SYS_Interface> GetServiceList()
        {
            using (var context = new WSEntities())
            {
                return context.SYS_Interface.ToList();
            }
        }

        #endregion

        #region 公共业务逻辑

        /// <summary>
        /// 根据输入的参数生成调整Index值的SQL命令
        /// </summary>
        /// <param name="dataTable">数据表名称</param>
        /// <param name="oldIndex">原Index值</param>   
        /// <param name="newIndex">现Index值</param>   
        /// <param name="parentId">父节点或分类ID</param>   
        /// <param name="isCategoryId">true:根据CategoryId（分类下）；false:根据ParentId（父节点下）；</param>
        /// <param name="moduleId">主数据类型（如果数据表名为BASE_Category则必须输入该参数</param>
        /// <returns>string SQL命令</returns>
        public static string ChangeIndex(string dataTable, int oldIndex, int newIndex, Guid? parentId, bool isCategoryId = true, Guid? moduleId = null)
        {
            var sql = new StringBuilder();
            sql.AppendFormat("update D set [Index] = D.[Index] {0} 1 from {1} D ", (oldIndex < newIndex ? "-" : "+"), dataTable);
            sql.Append(dataTable.Substring(0, 3) == "MDG" ? "join MasterData M on M.ID = D.MID " : "");
            sql.AppendFormat("where {0} {1} ", (isCategoryId ? "CategoryId" : "ParentId"), (parentId == null ? "is null" : "= '" + parentId + "'"));
            sql.Append(dataTable == "BASE_Category" ? string.Format("and ModuleId = '{0}' ", moduleId) : "");
            sql.AppendFormat("and [Index] {0} {1} ", (oldIndex < newIndex ? ">" : "<"), oldIndex);
            sql.AppendFormat("and [Index] {0} {1}", (oldIndex < newIndex ? "<=" : ">="), newIndex);
            return sql.ToString();
        }

        /// <summary>
        /// 构造保存ImageData的SqlCommand集合
        /// </summary>
        /// <param name="imgs">ImageData对象集合</param>
        /// <param name="tab">附件表名称</param>
        /// <param name="col">附件表业务主记录ID字段名称</param>
        /// <param name="bid">业务主记录ID</param>
        /// <returns>SqlCommand List SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> AddImageDatas(IEnumerable<ImageData> imgs, string tab, string col, Guid bid)
        {
            var sql = "insert ImageData (CategoryId, ImageType, Code, Name, Expand, SecrecyDegree, Pages, Size, Path, Image, Description, CreatorDeptId, CreatorUserId) ";
            sql += "select @CategoryId, @ImageType, @Code, @Name, @Expand, @SecrecyDegree, @Pages, @Size, @Path, @Image, @Description, @CreatorDeptId, @CreatorUserId select @ID = ID from ImageData where SN = SCOPE_IDENTITY() ";
            sql += string.Format("insert {0} ({1}, ImageId) select '{2}', @ID", tab, col, bid);
            return imgs.Select(img => new[]
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
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
