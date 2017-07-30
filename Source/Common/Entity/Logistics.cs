using System;
using Insight.Utils.Common;

namespace Insight.WS.Server.Common.Entity
{
    public class Logistics
    {
        [Alias("订单号")]
        public string OrderCode { get; set; }

        [Alias("物流公司")]
        public string Service { get; set; }

        [Alias("物流单号")]
        public string Number { get; set; }

        [Alias("发货时间")]
        public DateTime DeliveryTime { get; set; }

        [Alias("数量")]
        public decimal Count { get; set; }
    }
}
