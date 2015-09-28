using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;

namespace Insight.WS.Server.Common
{
    public class XFBDAL
    {

        /// <summary>
        /// 保存信分宝订单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="order">订单对象</param>
        /// <param name="subject">标的对象（商品）</param>
        /// <param name="stage">分期数</param>
        /// <returns>bool 是否成功</returns>
        public static bool AddOrder(Session us, BIZ_Order order, ABS_Contract_Subjects subject, int stage)
        {
            using (var context = new XFBEntities())
            {
                // 更新信分宝可用额度
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var xfbmember = context.t_member_info.Single(m => m.user_id == user.id);
                xfbmember.use_sum -= (float) (subject.Amount - order.FirstPay);
                var xo = new t_order_info
                {
                    owner_userid = user.id,
                    order_name = order.OID.ToString(),
                    product_name = subject.ObjectName,
                    product_price = (float) (subject.Price ?? 0),
                    shop_name = order.MallName,
                    use_limit = (float) (subject.Amount - order.FirstPay),
                    order_status = stage > 0 ? 2 : 9,
                    create_userid = order.MallId,
                    create_time = DateTime.Now,
                    description = order.MallName,
                    stage_plan = stage,
                    first_pay = (float) order.FirstPay,
                    delete_flag = 0,
                    deal_time = DateTime.Now,
                    isPay = 1,
                    all_stage_amout = (float) order.Interest
                };
                context.t_order_info.Add(xo);
                if (context.SaveChanges() <= 0) return false;

                order.XfbOrderId = xo.id;
                return true;
            }
        }

        /// <summary>
        /// 生成信分宝账单
        /// </summary>
        /// <param name="orderId">信分宝订单ID</param>
        /// <param name="list">还款计划集合（本金）</param>
        /// <param name="sa">月服务费</param>
        /// <returns>bool 是否成功</returns>
        public static bool AddBill(int orderId, List<ABS_Contract_FundPlan> list, decimal sa)
        {
            using (var context = new XFBEntities())
            {
                foreach (var bill in list.Select(obj => new t_bill_stage
                {
                    bill_no = obj.ID.ToString(),
                    order_id = orderId,
                    stage_amount = (float) (obj.Amount + sa),
                    base_amount = (float) obj.Amount,
                    charge_amount = (float) sa,
                    latest_repay = obj.EndDate,
                    description = obj.Description.Substring(2, obj.Description.Length - 4),
                    bill_status = 1,
                    create_time = DateTime.Now,
                    repay_channel = 0,
                    delete_flag = 0
                }))
                {
                    context.t_bill_stage.Add(bill);
                }

                return context.SaveChanges() > 0;
            }
        }

    }
}
