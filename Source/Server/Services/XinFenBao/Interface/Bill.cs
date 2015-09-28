using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Function;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface
    {

        /// <summary>
        /// 确认分期，生成账单
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <param name="payCode">首付款支付业务号</param>
        /// <returns>bool 是否成功</returns>
        public bool AddBill(Session us, Guid oid, string payCode)
        {
            if (!OnlineManage.Verification(us)) return false;

            BIZ_Order order;
            BIZ_StagePlan stagplan;
            ABS_Contract_Subjects ps; // 商品
            ABS_Contract_Subjects bs; // 本金
            using (var context = new WSEntities())
            {
                ps = context.ABS_Contract_Subjects.Single(s => s.ContractId == oid && s.PlanType == 0);
                if (ps.Amount <= 0) return true;

                bs = context.ABS_Contract_Subjects.FirstOrDefault(s => s.ContractId == oid && s.PlanType == 1);
                order = context.BIZ_Order.Single(o => o.OID == oid);
                stagplan = context.BIZ_StagePlan.FirstOrDefault(p => p.ID == order.StagePlan);
            }

            // 确认可用额度（有分期）
            if (bs != null && (ps.Amount == null || GetAvailable(us) < bs.Amount)) return false;

            // 更新云商订单状态
            if (order.YunOrderId != null && !YSDAL.UpOrderStatus((int) order.YunOrderId, 1)) return false;

            // 更新订单状态
            var cmds = new List<SqlCommand>
            {
                SqlHelper.MakeCommand($"update ABS_Contract set Status = 2 where ID = '{oid}'"),
                SqlHelper.MakeCommand($"update BIZ_Order set PaymentStatus = 1 where OID = '{oid}'")
            };

            // 生成账单还款计划（有分期）
            if (stagplan != null) cmds.AddRange(CommonDAL.MakeRepaymentPlan(oid, bs, stagplan.StageNum));

            // 插入购物首付款结算记录
            if (order.FirstPay > 0) cmds.AddRange(CommonDAL.MakeFirstPayClearing(us, order.FirstPay, payCode));

            if (!SqlHelper.SqlExecute(cmds)) return false;


            if (order.XfbOrderId == null && !XFBDAL.AddOrder(us, order, ps, stagplan?.StageNum ?? 0))
            {
                CommonDAL.ResetFundPlan(oid, (int)order.YunOrderId);
                return false;
            }
        
            // 保存信分宝订单ID
            List<ABS_Contract_FundPlan> list = null;
            using (var context = new WSEntities())
            {
                var so = context.BIZ_Order.Single(o => o.OID == order.OID);
                so.XfbOrderId = order.XfbOrderId;
                context.SaveChanges();

                if (bs != null) list = context.ABS_Contract_FundPlan.Where(f => f.SubjectsId == bs.ID).ToList();
            }

            if (bs == null) return true;

            if (XFBDAL.AddBill((int) order.XfbOrderId, list, order.Interest)) return true;

            CommonDAL.ResetFundPlan(oid, (int) order.YunOrderId);
            return false;
        }

        /// <summary>
        /// 根据标的ID获取订单列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">订单ID</param>
        /// <returns>账单列表</returns>
        public List<BillList> GetBillList(Session us, Guid oid)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BillList.Where(b => b.ContractId == oid).ToList();
            }
        }

        /// <summary>
        /// 根据账单ID还款
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="objs">资金履约对象集合</param>
        /// <param name="payCode">支付业务号</param>
        /// <returns>是否成功</returns>
        public bool BillPerform(Session us, List<ABS_Contract_FundPerform> objs, string payCode)
        {
            if (!OnlineManage.Verification(us)) return false;

            decimal ba = 0;
            decimal sa = 0;
            decimal la = 0;
            using (var context = new XFBEntities())
            {
                foreach (var obj in objs)
                {
                    var bill = context.t_bill_stage.Single(b => b.bill_no == obj.PlanId.ToString());
                    // ReSharper disable once PossibleInvalidOperationException
                    ba += (decimal) bill.base_amount;
                    // ReSharper disable once PossibleInvalidOperationException
                    sa += (decimal) bill.charge_amount;
                    // ReSharper disable once PossibleInvalidOperationException
                    la += (obj.Amount - (decimal) bill.stage_amount);
                    obj.Amount = (decimal) bill.stage_amount;

                    bill.repay_amount = (float) obj.Amount;
                    bill.bill_status = 2;
                    bill.actual_repay = DateTime.Now;
                    bill.repay_channel = 2;
                }

                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var member = context.t_member_info.Single(m => m.user_id == user.id);
                member.use_sum += (float) ba;
                context.SaveChanges();
            }

            var cmds = new List<SqlCommand>();
            cmds.AddRange(ClearingDAL.BillClearing(us.UserId, us.UserName, ba, sa, la, "WeiXinPay", payCode));
            cmds.AddRange(ContractDAL.FundPerform(objs));

            return SqlHelper.SqlExecute(cmds);
        }
    }
}
