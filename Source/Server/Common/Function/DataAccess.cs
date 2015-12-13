using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.OnlineManage;

namespace Insight.WS.Server.Common
{
    public partial class DataAccess
    {

        #region 公共数据接口

        /// <summary>
        /// 修改指定用户的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public static bool UpdataPassword(Session us, string pw)
        {
            const string sql = "update SYS_User set Password = @Password where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Password", pw)
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0 && UpdateSignature(us.ID, pw);
        }

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
        /// 写入会员数据
        /// </summary>
        /// <param name="sourec">来源</param>
        /// <param name="name">姓名</param>
        /// <param name="ln">登录名</param>
        /// <param name="pw">登陆密码</param>
        /// <param name="id">身份证号</param>
        /// <param name="openid">OpenId</param>
        /// <returns>bool 是否成功</returns>
        public static bool AddMember(string sourec, string name, string ln, string pw, string id, string openid)
        {
            Guid? catId;
            using (var context = new WSEntities())
            {
                catId = context.BASE_Category.FirstOrDefault(c => c.Alias == sourec)?.ID;
            }
            
            // 插入主数据索引
            var md = new MasterData { CategoryId = catId, Code = id, Name = name, Alias = ln };
            var cmds = new List<SqlCommand> { AddMasterData(md) };

            // 插入外部用户
            const string sql = "insert SYS_User (ID, Name, LoginName, Password, OpenId, Type, CreatorUserId) select @ID, @Name, @LoginName, @Password, @OpenId, @Type, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Name", name),
                new SqlParameter("@LoginName", ln),
                new SqlParameter("@Password", pw),
                new SqlParameter("@OpenId", openid),
                new SqlParameter("@Type", SqlDbType.Int) {Value = 0},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
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
            return SqlScalar(MakeCommand(sql, parm)).ToString();
        }

        /// <summary>
        /// 获取可用服务列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SYS_Interface> GetServiceList(string type)
        {
            using (var context = new WSEntities())
            {
                return context.SYS_Interface.Where(i => i.Binding == type).ToList();
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
            sql.Append(dataTable == "BASE_Category" ? $"and ModuleId = '{moduleId}' " : "");
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
            sql += $"insert {tab} ({col}, ImageId) select '{bid}', @ID";
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
            }).Select(parm => MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="type">验证码类型</param>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="time">有效时间（分钟）</param>
        /// <returns>string 验证码</returns>
        public static bool GetVerifyCode(int type, string phone, string code, int time)
        {
            const string sql = "insert SYS_Verify_Record (Type, Mobile, Code, FailureTime) select @Type, @Mobile, @Code, @FailureTime";
            var parm = new[]
            {
                new SqlParameter("@Type", type),
                new SqlParameter("@Mobile", phone),
                new SqlParameter("@Code", code),
                new SqlParameter("@FailureTime", DateTime.Now.AddMinutes(time))
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        #endregion
    }
}
