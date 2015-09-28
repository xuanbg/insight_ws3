using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface
    {

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>订单列表</returns>
        public List<OrderList> GetOrderList(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.OrderList.Where(o => o.MemberId == us.UserId).ToList();
            }
        }

        /// <summary>
        /// 根据订单ID获取订单信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <returns>BIZ_Order 订单对象</returns>
        public BIZ_Order GetOrder(Session us, Guid oid)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_Order.Single(o => o.OID == oid);
            }
        }

        /// <summary>
        /// 根据订单号获取商品快照
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">标的ID</param>
        /// <returns>商品快照对象</returns>
        public BIZ_Product_Snapshot GetSnapshot(Session us, Guid sid)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_Product_Snapshot.FirstOrDefault(s => s.SID == sid);
            }
        }

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="order">订单扩展</param>
        /// <param name="pid">商品ID</param>
        /// <returns>object 订单号</returns>
        public object AddOrder(Session us, BIZ_Order order, int pid)
        {
            if (!OnlineManage.Verification(us)) return null;

            // 准备数据
            MasterData baseSub;
            MDE_Member_Address address;
            BIZ_StagePlan stagePlan;
            Products product;
            using (var context = new YSEntities())
            {
                product = context.Products.Single(p => p.ID == pid);
            }
            var baseAmount = product.SalePrice - order.FirstPay;
            using (var context = new WSEntities())
            {
                baseSub = context.MasterData.Single(m => m.Alias == "Loans");
                address = context.MDE_Member_Address.Single(a => a.ID == order.AddressId);
                stagePlan = context.BIZ_StagePlan.FirstOrDefault(s => s.ID == order.StagePlan);
            }

            // 保存云商订单
            order.OrderAmount = product.SalePrice;
            order.Interest = Math.Round(baseAmount*(stagePlan?.Rate ?? 0), 2);
            order.InvoiceType = 1;
            order.InvoiceInfo = "个人-明细";
            order.OutDate = DateTime.Now.Date.AddDays(product.OutDay);
            order.OrdersStatus = 7;
            order.DeliveryStatus = 0;
            order.PaymentStatus = 0;
            order.RefundStatus = 0;
            if (!AddYunOrder(order, product, address, stagePlan?.StageNum ?? 0)) return null;

            // 保存订单及相关数据
            var contract = new ABS_Contract {ObjectId = us.UserId, ObjectName = us.UserName, Status = 1};
            var cmds = new List<SqlCommand>
            {
                ContractDAL.AddContract(us, contract),
                AddOrder(order)
            };
            if (stagePlan != null) cmds.Add(AddSubjects(baseSub, stagePlan, baseAmount));
            cmds.AddRange(AddSnapshot(product));
            var oid = SqlHelper.SqlExecute(cmds, 0);
            try
            {
                order.OID = (Guid) oid;
                UpdateOrderNo(order);
                return oid;
            }
            catch (Exception ex)
            {
                Util.LogToEvent(ex.ToString());
                ResetOrder(order);
                return null;
            }
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="order">BIZ_Order对象实体</param>
        /// <param name="obj"></param>
        /// <returns>bool 是否成功</returns>
        public bool Withdrawal(Session us, BIZ_Order order, MDE_Member_Withdrawal obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            MasterData baseSub;
            BIZ_StagePlan stagePlan;
            using (var context = new WSEntities())
            {
                var memble = context.MDG_EntMember.FirstOrDefault(m => m.MID == us.UserId);
                if (memble == null) return false;

                baseSub = context.MasterData.Single(m => m.Alias == "Loans");
                stagePlan = context.BIZ_StagePlan.Single(s => s.ID == order.StagePlan);
            }

            // 保存订单及相关数据
            order.Interest = Math.Round(order.OrderAmount*stagePlan.Rate, 2);
            var contract = new ABS_Contract {ObjectId = us.UserId, ObjectName = us.UserName, Status = 1};
            var cmds = new List<SqlCommand>
            {
                ContractDAL.AddContract(us, contract),
                AddOrder(order),
                AddSubjects(baseSub, stagePlan, order.OrderAmount),
                AddWithdrawal(us, obj)
            };

            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DeleteOrder(Session us, Guid oid)
        {
            if (!OnlineManage.Verification(us)) return false;
            using (var context = new WSEntities())
            {
                var contract = context.ABS_Contract.FirstOrDefault(o => o.ID == oid && o.Status < 2);
                if (contract == null) return false;

                var order = context.BIZ_Order.Single(o => o.OID == oid);
                if (!ResetOrder(order)) return false;

                context.ABS_Contract.Remove(contract);
                return (context.SaveChanges() == 0);
            }
        }

    }
}
