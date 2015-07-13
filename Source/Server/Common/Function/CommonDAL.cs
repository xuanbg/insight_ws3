using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Server.Common
{
    public class CommonDAL
    {

        #region 公共数据接口

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public static Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            if (OnlineManage.Sessions.Count >= OnlineManage.MaxAuthorized)
            {
                obj.LoginStatus = LoginResult.Unauthorized;
                return obj;
            }

            var isSafe = true;
            var pw = obj.Signature;
            var us = OnlineManage.Sessions.Find(s => s.LoginName == obj.LoginName);
            if (us == null)
            {
                var user = GetUser(obj.LoginName);
                if (user == null)
                {
                    obj.LoginStatus = LoginResult.NotExist;
                    return obj;
                }

                obj.ID = OnlineManage.Sessions.Count;
                obj.UserId = user.ID;
                obj.UserName = user.Name;
                obj.Signature = user.Password;
                obj.FailureCount = 0;
                obj.Validity = user.Validity;

                OnlineManage.Sessions.Add(obj);
                OnlineManage.SafeMachine.Add(null);
                us = OnlineManage.Sessions[obj.ID];
            }
            else
            {
                if (us.FailureCount > 4)
                {
                    isSafe = us.MachineId != obj.MachineId && obj.MachineId == OnlineManage.SafeMachine[us.ID];
                }

                if (us.SessionId == Guid.Empty)
                {
                    us.SessionId = obj.SessionId;
                    us.MachineId = obj.MachineId;
                    us.LoginStatus = LoginResult.Success;
                }
                else
                {
                    us.LoginStatus = us.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
                }
            }

            // 10分钟后重置连续失败次数
            var time = DateTime.Now - us.LastConnect;
            if (us.FailureCount > 0 && time.TotalMinutes > 10)
            {
                us.FailureCount = 0;
            }

            if (!us.Validity)
            {
                us.LoginStatus = LoginResult.Banned;
            }
            else if (us.Signature != pw || !isSafe)
            {
                us.FailureCount += 1;
                us.LoginStatus = LoginResult.Failure;
                if (us.MachineId == obj.MachineId)
                {
                    us.SessionId = Guid.Empty;
                }
            }
            else
            {
                OnlineManage.SafeMachine[us.ID] = us.MachineId;
            }

            us.LastConnect = DateTime.Now;
            return us;
        }

        /// <summary>
        /// 修改指定用户的密码
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public static bool UpdataPassword(Session us, string pw)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = string.Format("update SYS_User set Password = '{0}' where ID = '{1}' ", pw, us.UserId);
            if (SqlHelper.SqlNonQuery(sql) > 0)
            {
                OnlineManage.Sessions[us.ID].Signature = pw;
                return true;
            }
            return false;
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

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="timeout">超时秒数</param>
        /// <returns>bool 是否正确</returns>
        public static bool CodeVerify(string number, string code, int timeout)
        {
            using (var context = new WSEntities())
            {
                var vr = context.SYS_Verify_Record.Where(v => v.Mobile == number && v.Code == code)
                         .OrderByDescending(v => v.SN)
                         .FirstOrDefault();
                if (vr == null) return false;

                var time = DateTime.Now - vr.CreateTime;
                if (time.Seconds > timeout) return false;

                vr.Verified = true;
                vr.VerifyTime = DateTime.Now;
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="sdst">手机号</param>
        /// <param name="type">验证码类型</param>
        /// <returns>string 验证码</returns>
        public static string GetVerifyCode(string sdst, int type)
        {
            var smsg = "";
            var r = new Random(Environment.TickCount);
            var code = r.Next(100000, 999999).ToString();
            switch (type)
            {
                case 1: // 注册新用户
                    smsg = string.Format("您的验证码是：{0}，该验证码3分钟内有效！欢迎使用信分宝，开启信用新生活。么么哒【信分宝】", code);
                    break;

                case 2: // 重置密码
                    smsg = string.Format("您的验证码是：{0}，该验证码3分钟内有效！亲爱的用户，您正在重置登录密码！如非本人操作，请告知客服【信分宝】", code);
                    break;
            }

            var address = new EndpointAddress("http://cf.lmobile.cn/submitdata/service.asmx");
            var binding = new BasicHttpBinding();
            using (var cli = new Service1SoapClient(binding, address))
            {
                var sname = "dlxinfb";
                var spwd = "50wTKJIW";
                var scorpid = "";
                var sprdid = "1012818";
                var state = cli.g_Submit(sname, spwd, scorpid, sprdid, sdst, smsg);
                var rs = state.MsgID + ":" + state.MsgState;
            }

            var sql = "insert SYS_Verify_Record (Type, Mobile, Code) select @Type, @Mobile, @Code";
            var parm = new[]
            {
                new SqlParameter("@Type", type),
                new SqlParameter("@Mobile", sdst),
                new SqlParameter("@Code", code)
            };
                return SqlHelper.SqlNonQuery(sql, parm) > 0 ? code : null;
        }

        #endregion

    }
}
