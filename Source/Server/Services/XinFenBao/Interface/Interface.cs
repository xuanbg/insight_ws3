using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface : IInterface
    {

        private const string SecCode = "0A457C39B0A81CEFE3D9E30E99A00388";

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="number">手机号</param>
        /// <param name="type">验证码类型</param>
        /// <returns>string 验证码</returns>
        public string GetVerifyCode(string secCode, string number, int type)
        {
            if (secCode != SecCode) return null;

            using (var context = new WSEntities())
            {
                var record = context.SYS_Verify_Record.OrderByDescending(r => r.CreateTime).FirstOrDefault(r => r.Mobile == number);
                if (record != null && (DateTime.Now - record.CreateTime).TotalSeconds < 60) return null;
            }

            return CommonDAL.GetVerifyCode(number, type);
        }

        /// <summary>
        /// 获取当前有效分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>分期方案列表</returns>
        public List<BIZ_StagePlan> GetStagePlans(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_StagePlan.Where(p => p.Validity && p.UserType == us.Type && p.EffectiveDate <= DateTime.Now && (p.InvalidDate == null || p.InvalidDate > DateTime.Now)).ToList();
            }
        }

        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="paypw">支付密码</param>
        /// <returns>bool 是否成功</returns>
        public bool ValidityPayPW(Session us, string paypw)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.Single(u => u.ID == us.UserId);
                return user.PayPassword == paypw;
            }
        }

        /// <summary>
        /// 保存支付记录
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="obj">支付记录对象</param>
        /// <returns>是否成功</returns>
        public bool SavePayRecord(string secCode, BIZ_Pay_Record obj)
        {
            if (secCode != SecCode) return false;

            var sql = "insert BIZ_Pay_Record (MemberId, Password, PayType, Business, TradeNo, Amount, Description) ";
            sql += "select @MemberId, @Password, @PayType, @Business, @TradeNo, @Amount, @Description";
            var parm = new[]
            {
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = obj.MemberId},
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@PayType", obj.PayType),
                new SqlParameter("@Business", obj.Business),
                new SqlParameter("@TradeNo", obj.TradeNo),
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@Description", obj.Description)
            };

            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 根据商户订单号获取支付记录
        /// </summary>
        /// <param name="secCode">安全码</param>
        /// <param name="tradeNo">商户订单号</param>
        /// <returns>BIZ_Pay_Record 支付记录对象</returns>
        public BIZ_Pay_Record GetPayRecord(string secCode, string tradeNo)
        {
            if (secCode != SecCode) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_Pay_Record.Single(r => r.TradeNo == tradeNo);
            }
        }

        /// <summary>
        /// 拼装插入订单的SqlCommand
        /// </summary>
        /// <param name="order">BIZ_Order对象</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand AddOrder(BIZ_Order order)
        {
            var sql = "insert BIZ_Order (OID, MallId, MallCode, MallName, StagePlan, FirstPay, FirstPayChannel, OrderAmount, Interest, AddressId, InvoiceType, InvoiceInfo, YunOrderId, XfbOrderId, OutDate, Description, OrdersStatus, PaymentStatus, DeliveryStatus, RefundStatus) ";
            sql += "select @OID, @MallId, @MallCode, @MallName, @StagePlan, @FirstPay, @FirstPayChannel, @OrderAmount, @Interest, @AddressId, @InvoiceType, @InvoiceInfo, @YunOrderId, @XfbOrderId, @OutDate, @Description, @OrdersStatus, @PaymentStatus, @DeliveryStatus, @RefundStatus";
            var parm = new[]
            {
                new SqlParameter("@OID", SqlDbType.UniqueIdentifier) {Value = order.OID},
                new SqlParameter("@MallId", order.MallId),
                new SqlParameter("@MallCode", order.MallCode),
                new SqlParameter("@MallName", order.MallName),
                new SqlParameter("@StagePlan", SqlDbType.UniqueIdentifier) {Value = order.StagePlan},
                new SqlParameter("@FirstPay", order.FirstPay),
                new SqlParameter("@FirstPayChannel", SqlDbType.UniqueIdentifier) {Value = order.FirstPayChannel},
                new SqlParameter("@OrderAmount", order.OrderAmount),
                new SqlParameter("@Interest", order.Interest),
                new SqlParameter("@AddressId", SqlDbType.UniqueIdentifier) {Value = order.AddressId},
                new SqlParameter("@InvoiceType", order.InvoiceType),
                new SqlParameter("@InvoiceInfo", order.InvoiceInfo),
                new SqlParameter("@YunOrderId", order.YunOrderId),
                new SqlParameter("@XfbOrderId", order.XfbOrderId),
                new SqlParameter("@OutDate", order.OutDate),
                new SqlParameter("@Description", order.Description),
                new SqlParameter("@OrdersStatus", order.OrdersStatus),
                new SqlParameter("@PaymentStatus", order.PaymentStatus),
                new SqlParameter("@DeliveryStatus", order.DeliveryStatus),
                new SqlParameter("@RefundStatus", order.RefundStatus),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };

            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 保存云商订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <param name="product">商品对象</param>
        /// <param name="address">地址对象</param>
        /// <param name="stageNum">分期数</param>
        /// <returns>bool 是否成功</returns>
        private bool AddYunOrder(BIZ_Order order, Products product, MDE_Member_Address address, int stageNum)
        {
            using (var context = new YSEntities())
            {
                var defaultDate = DateTime.Parse("1900-1-1");
                var yunOrder = new Orders
                {
                    Orders_Status = 7,
                    Orders_ERPSyncStatus = 0,
                    Orders_PaymentStatus = 0,
                    Orders_PaymentStatus_Time = DateTime.Now,
                    Orders_DeliveryStatus = 0,
                    Orders_DeliveryStatus_Time = DateTime.Now,
                    Orders_InvoiceStatus = 0,
                    Orders_Total_Price = product.SalePrice,
                    Orders_Total_AllPrice = product.SalePrice,
                    Orders_Address_StreetAddress = address.Description,
                    Orders_Address_Zip = address.ZipCode,
                    Orders_Address_Name = address.Name,
                    Orders_Address_Phone_Number = address.Mobile,
                    Orders_Address_Mobile = address.Mobile,
                    Orders_SourceType = 1,
                    Orders_Site = order.MallCode,
                    Orders_Source = order.MallName,
                    Orders_Addtime = DateTime.Now,
                    Orders_SupplierID = 1,
                    Orders_BankAuditPass = 1,
                    Orders_ShipmentsType = 0,
                    Orders_PriorityCoefficient = 1,
                    Orders_Installment = stageNum.ToString(),
                    Orders_Point = 0,
                    Orders_OldGoods = $"{product.Code};{product.Name};{product.Color};1",

                    Order_Confirm_Time = defaultDate,
                    Orders_Cancel_Time = defaultDate,
                    Orders_Delivery_Time = defaultDate,
                    Orders_Fail_Addtime = defaultDate,
                    Orders_PriorityLevelTime = defaultDate,
                    Orders_Return_Time = defaultDate,
                    Orders_Settle_Date = defaultDate,
                };
                context.Orders.Add(yunOrder);
                context.SaveChanges();
                order.YunOrderId = yunOrder.Orders_ID;

                var goods = new Orders_Goods
                {
                    Orders_Goods_OrdersID = yunOrder.Orders_ID,
                    Orders_Goods_Product_SupplierID = 1,
                    Orders_Goods_Product_Code = product.Code,
                    Orders_Goods_Product_Name = product.Name,
                    Orders_Goods_Product_Price = product.SalePrice,
                    Orders_Goods_Product_brokerage = 0,
                    Orders_Goods_Product_PurchasingPrice = product.SalePrice,
                    Orders_Goods_Amount = 1,
                    Orders_Goods_Product_Specification = "标准",
                    Orders_Goods_Product_Color = product.Color,
                    Orders_Goods_Product_Rate = 0
                };
                var invoice = new Orders_Invoice
                {
                    Invoice_OrdersID = yunOrder.Orders_ID,
                    Invoice_Type = 0,
                    Invoice_Title = order.InvoiceInfo
                };
                context.Orders_Goods.Add(goods);
                context.Orders_Invoice.Add(invoice);
                return (context.SaveChanges() > 0);
            }
        }

        /// <summary>
        /// 生成插入标的的SqlCommand集合
        /// </summary>
        /// <param name="baseSub">本金对象</param>
        /// <param name="stagePlan">分期方案对象</param>
        /// <param name="Amount">借款金额</param>
        /// <returns>标的SqlCommand集合</returns>
        private SqlCommand AddSubjects(MasterData baseSub, BIZ_StagePlan stagePlan, decimal Amount)
        {
            var subject = new ABS_Contract_Subjects
            {
                Direction = 1,
                PlanType = 1,
                ObjectId = baseSub.ID,
                ObjectName = baseSub.Name,
                EffectiveDate = DateTime.Now.Date,
                InvalidDate = DateTime.Now.Date.AddMonths(stagePlan.StageNum).AddDays(-1),
                Price = Math.Round(Amount/stagePlan.StageNum, 2),
                Counts = stagePlan.StageNum,
                Amount = Amount
            };
            return (ContractDAL.AddSubject(subject));
        }

        /// <summary>
        /// 拼装插入提现记录的SqlCommand
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">提现记录对象</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand AddWithdrawal(Session us, MDE_Member_Withdrawal obj)
        {
            const string sql = "insert MDE_Member_Withdrawal (MemberId, OrderId, CardId, Description) select @MemberId, @OrderId, @CardId, @Description";
            var parm = new[]
            {
                new SqlParameter("@OrderId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@CardId", SqlDbType.UniqueIdentifier) {Value = obj.CardId},
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装插入商品快照的SqlCommand集合
        /// </summary>
        /// <param name="product">商品对象</param>
        /// <returns>商品快照的SqlCommand集合</returns>
        private IEnumerable<SqlCommand> AddSnapshot(Products product)
        {
            var subject = new ABS_Contract_Subjects
            {
                Direction = 1,
                PlanType = 0,
                ObjectName = product.Name,
                Price = product.SalePrice,
                Counts = 1,
                Amount = product.SalePrice
            };
            var cmds = new List<SqlCommand> {ContractDAL.AddSubject(subject)};

            List<Product_Library_Img> imgs;
            using (var context = new YSEntities())
            {
                imgs = context.Product_Library_Img.Where(i => i.Product_Img_ProductID == product.ID).ToList();
            }
            var speci = SqlHelper.SqlScalar($"select Specific from dbo.Get_Specific({product.ID})", "YS");
            var sql = "insert BIZ_Product_Snapshot (SID, ProductName, ProductSpeci, ProductPrice, ProductImage, Parameter, PackingList, Description, ProductPic1, ProductPic2, ProductPic3, ProductPic4, ProductPic5) ";
            sql += "select @SID, @ProductName, @ProductSpeci, @ProductPrice, @ProductImage, @Parameter, @PackingList, @Description, @ProductPic1, @ProductPic2, @ProductPic3, @ProductPic4, @ProductPic5";
            var parm = new[]
            {
                new SqlParameter("@SID", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@ProductName", product.Name),
                new SqlParameter("@ProductSpeci", speci),
                new SqlParameter("@ProductPrice", product.SalePrice),
                new SqlParameter("@ProductImage", product.ImageUrl),
                new SqlParameter("@Parameter", product.Parameter),
                new SqlParameter("@PackingList", product.Warranty),
                new SqlParameter("@Description", product.Description),
                new SqlParameter("@ProductPic1", product.ImageUrl),
                new SqlParameter("@ProductPic2", product.ImageUrl),
                new SqlParameter("@ProductPic3", product.ImageUrl),
                new SqlParameter("@ProductPic4", product.ImageUrl),
                new SqlParameter("@ProductPic5", product.ImageUrl),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
            };
            for (var i = 0; i < imgs.Count; i++)
            {
                parm[i + 8].Value = imgs[i].Product_Img_Path;
            }
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            return cmds;
        }

        /// <summary>
        /// 更新订单号
        /// </summary>
        /// <param name="order"></param>
        private void UpdateOrderNo(BIZ_Order order)
        {
            using (var context = new YSEntities())
            {
                var yo = context.Orders.Single(o => o.Orders_ID == order.YunOrderId);
                yo.Orders_BankOrderSN = order.OID.ToString();
                context.SaveChanges();
            }
            if (order.XfbOrderId == null) return;

            using (var context = new XFBEntities())
            {
                var yo = context.t_order_info.Single(o => o.id == order.XfbOrderId);
                yo.order_name = order.OID.ToString();
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 复原订单
        /// </summary>
        /// <param name="order">订单对象</param>
        private bool ResetOrder(BIZ_Order order)
        {
            if (order.YunOrderId != null)
            {
                using (var context = new YSEntities())
                {
                    var yo = context.Orders.Single(o => o.Orders_ID == order.YunOrderId);
                    var og = context.Orders_Goods.Single(g => g.Orders_Goods_OrdersID == yo.Orders_ID);
                    var oi = context.Orders_Invoice.Single(i => i.Invoice_OrdersID == yo.Orders_ID);
                    context.Orders.Remove(yo);
                    context.Orders_Goods.Remove(og);
                    context.Orders_Invoice.Remove(oi);
                    if (context.SaveChanges() == 0) return false;
                }
            }

            if (order.XfbOrderId != null)
            {
                using (var context = new XFBEntities())
                {
                    var xo = context.t_order_info.Single(o => o.id == order.XfbOrderId);
                    context.t_order_info.Remove(xo);
                    if (context.SaveChanges() == 0) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="ln"></param>
        private void DeleteMember(string ln)
        {
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.Single(u => u.LoginName == ln);
                var member = context.MasterData.Single(m => m.ID == user.ID);
                context.MasterData.Remove(member);
                context.SYS_User.Remove(user);
                context.SaveChanges();
            }
        }

    }
}
