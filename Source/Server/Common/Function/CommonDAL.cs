using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;
using Insight.WS.Server.Common.YUN;

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

            var isSafe = false;
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
                obj.OpenId = user.OpenId;
                obj.UserId = user.ID;
                obj.UserName = user.Name;
                obj.Signature = user.Password;
                obj.FailureCount = 0;
                obj.Validity = user.Validity;
                obj.Type = user.Type;

                OnlineManage.Sessions.Add(obj);
                OnlineManage.SafeMachine.Add(null);
                us = OnlineManage.Sessions[obj.ID];
            }
            else
            {
                isSafe = obj.MachineId == OnlineManage.SafeMachine[us.ID];
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
            else if (us.Signature != pw || (us.FailureCount > 4 && !isSafe))
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

            var sql = $"update SYS_User set Password = '{pw}' where ID = '{us.UserId}' ";
            if (SqlHelper.SqlNonQuery(sql) <= 0) return false;

            OnlineManage.Sessions[us.ID].Signature = pw;
            return true;
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
            var cmds = new List<SqlCommand> { MasterDataDAL.AddMasterData(md) };

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
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            return SqlHelper.SqlExecute(cmds);
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
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="timeout">超时分钟数（默认30分钟）</param>
        /// <returns>bool 是否正确</returns>
        public static bool CodeVerify(string number, string code, int timeout = 30)
        {
            using (var context = new WSEntities())
            {
                var vr = context.SYS_Verify_Record.Where(v => !v.Verified && v.Mobile == number && v.Code == code)
                         .OrderByDescending(v => v.SN)
                         .FirstOrDefault();
                if (vr == null) return false;

                var time = DateTime.Now - vr.CreateTime;
                if (time.TotalMinutes > timeout) return false;

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
        /// <param name="time">有效时间（分钟）</param>
        /// <returns>string 验证码</returns>
        public static string GetVerifyCode(string sdst, int type, int time = 30)
        {
            var random = new Random(Environment.TickCount);
            var code = random.Next(100000, 999999).ToString();
            var smsg = $"您的验证码是：{code}，该验证码{time}分钟内有效！";
            switch (type)
            {
                case 1: // 注册新用户
                    smsg += "欢迎使用信分宝，开启信用新生活。么么哒";
                    break;

                case 2: // 重置登录密码
                    smsg += "亲爱的用户，您正在重置登录密码！如非本人操作，请告知客服";
                    break;

                case 3: // 重置支付密码
                    smsg += "亲爱的用户，您正在重置支付密码！如非本人操作，请立即修改登录密码";
                    break;
            }

            // 发送短信
            Util.SendMessage(sdst, smsg);

            // 保存验证码
            const string sql = "insert SYS_Verify_Record (Type, Mobile, Code) select @Type, @Mobile, @Code";
            var parm = new[]
            {
                new SqlParameter("@Type", type),
                new SqlParameter("@Mobile", sdst),
                new SqlParameter("@Code", code)
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0 ? code : null;
        }

        /// <summary>
        /// 订单状态同步
        /// </summary>
        public static void OrderStatusSync()
        {
            List<OrderStatus> list;
            using (var context = new WSEntities())
            {
                // 同步云商订单状态
                list = context.OrderStatus.ToList();
                foreach (var s in list)
                {
                    var order = context.BIZ_Order.Single(o => o.OID == s.OID);
                    order.OrdersStatus = s.OrdersStatus;
                    order.DeliveryStatus = s.DeliveryStatus;
                    order.PaymentStatus = s.PaymentStatus;
                    order.RefundStatus = s.Orders_RefundStatus;

                    var contract = context.ABS_Contract.Single(c => c.ID == s.OID);
                    if (s.OrdersStatus == 1) contract.Status = 3;
                    if (s.DeliveryStatus == 1) contract.Status = 4;
                    if (s.DeliveryStatus == 5) contract.Status = 6;
                    if (s.PaymentStatus == 3) contract.Status = 7;
                    if (s.Orders_RefundStatus == 1) contract.Status = 8;
                    if (s.OrdersStatus == 8) contract.Status = 9;
                }
                context.SaveChanges();
            }

            // 同步云商订单状态到信分宝
            using (var context = new XFBEntities())
            {
                foreach (var s in list)
                {
                    var xfbOrder = context.t_order_info.FirstOrDefault(o => o.id == s.XfbOrderId);
                    if (xfbOrder == null) continue;

                    if (s.DeliveryStatus == 5) xfbOrder.order_status = 4;
                    if (s.PaymentStatus == 3) xfbOrder.order_status = 5;
                    if (s.Orders_RefundStatus == 1) xfbOrder.order_status = 6;
                    if (s.OrdersStatus == 8) xfbOrder.order_status = 0;
                    if (xfbOrder.return_time == null && (s.DeliveryStatus == 5 || s.OrdersStatus == 8))
                    {
                        var bills = context.t_bill_stage.Where(b => b.order_id == xfbOrder.id && b.bill_status != 2).ToList();
                        var member = context.t_member_info.Single(m => m.user_id == xfbOrder.owner_userid);
                        member.use_sum += bills.Sum(b => b.base_amount);
                        xfbOrder.return_time = DateTime.Now;
                    }
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 拼装还款计划
        /// </summary>
        /// <param name="oid">订单ID</param>
        /// <param name="bs">标的对象（本金）</param>
        /// <param name="stage">分期数</param>
        /// <returns>SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> MakeRepaymentPlan(Guid oid, ABS_Contract_Subjects bs, int stage)
        {
            var plans = new List<ABS_Contract_FundPlan>();
            for (var i = 0; i < stage; i++)
            {
                var ba = i == stage - 1 ? (bs.Amount - bs.Price * i) : bs.Price;
                var date = Util.FormatDate(DateTime.Now.AddDays(1), 5);
                var plan = new ABS_Contract_FundPlan
                {
                    ContractId = oid,
                    SubjectsId = bs.ID,
                    Amount = ba ?? 0,
                    StartDate = date.AddMonths(i - 1).AddDays(1),
                    EndDate = date.AddMonths(i),
                    Ex_StartDate = date.AddMonths(i).AddDays(-3),
                    Ex_EndDate = date.AddMonths(i).AddDays(7),
                    Description = $"【第{i + 1}期】"
                };
                plans.Add(plan);
            }
            return ContractDAL.AddFundPlan(plans);
        }

        /// <summary>
        /// 拼装购物首付款结算记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="amount">金额</param>
        /// <param name="payCode">结算号</param>
        /// <returns>SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> MakeFirstPayClearing(Session us, decimal amount, string payCode)
        {
            MasterData payType;
            MasterData firstPay;
            using (var context = new WSEntities())
            {
                firstPay = context.MasterData.Single(m => m.Alias == "FirstPay");
                payType = context.MasterData.Single(m => m.Alias == "WeiXinPay");
            }
            var clear = new ABS_Clearing
            {
                Direction = 1,
                ObjectId = us.UserId,
                ObjectName = us.UserName,
                Description = "分期购物首付款",
                CreatorUserId = Guid.Empty
            };
            var cmds = new List<SqlCommand> {ClearingDAL.InsertClearing(clear)};
            var item = new ABS_Clearing_Item
            {
                Summary = "购物首付款",
                ObjectId = firstPay.ID,
                ObjectName = firstPay.Name,
                Units = "元",
                Amount = amount
            };
            cmds.Add(ClearingDAL.InsertDetail(item));
            var pay = new ABS_Clearing_Pay
            {
                PayType = payType.ID,
                Code = payCode,
                Amount = amount
            };
            cmds.Add(ClearingDAL.InsertPays(pay));

            return cmds;
        }

        /// <summary>
        /// 获取用户可用额度
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>decimal 可用额度</returns>
        public static decimal GetAvailable(Session us)
        {
            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var member = context.t_member_info.Single(m => m.user_id == user.id);
                var bills = context.t_bill_stage.Where(b => b.bill_status == 3).Join(context.t_order_info.Where(o => o.owner_userid == user.id), b => b.order_id, o => o.id, (b, o) => b).ToList();

                return bills.Count > 0 ? 0 :(decimal) member.use_sum;
            }
        }

        /// <summary>
        /// 复原订单状态
        /// </summary>
        /// <param name="oid">订单ID</param>
        /// <param name="yoid">云商订单ID</param>
        public static void ResetFundPlan(Guid oid, int yoid)
        {
            using (var context = new WSEntities())
            {
                var list = context.ABS_Contract_FundPlan.Where(f => f.ContractId == oid).ToList();
                var order = context.ABS_Contract.Single(o => o.ID == oid);
                order.Status = 1;
                context.ABS_Contract_FundPlan.RemoveRange(list);
                context.SaveChanges();
            }
            using (var context = new YSEntities())
            {
                var yo = context.Orders.Single(o => o.Orders_ID == yoid);
                yo.Orders_PaymentStatus = 1;
                context.SaveChanges();
            }
        }

        #endregion

    }
}
