using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Server.Common.Function
{
    public class YSDAL
    {

        /// <summary>
        /// 更新云商订单付款状态
        /// </summary>
        /// <param name="orderId">云商订单ID</param>
        /// <param name="status">状态码</param>
        /// <returns>bool 是否成功</returns>
        public static bool UpOrderStatus(int orderId, int status)
        {
            using (var context = new YSEntities())
            {
                var yo = context.Orders.Single(o => o.Orders_ID == orderId);
                yo.Orders_PaymentStatus = status;
                return context.SaveChanges() > 0;
            }
        }

    }
}
