﻿using System;
using Insight.Utils.Common;

namespace Insight.WS.Server.Common.Entity
{
    public class Logistics
    {
        [PropertyAlias("订单号")]
        public string OrderCode { get; set; }

        [PropertyAlias("物流公司")]
        public string Service { get; set; }

        [PropertyAlias("物流单号")]
        public string Number { get; set; }

        [PropertyAlias("发货时间")]
        public DateTime DeliveryTime { get; set; }
    }
}
