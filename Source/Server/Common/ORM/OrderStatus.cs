//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.ORM
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    
    public partial class OrderStatus
    {
    	[DataMember]
        public System.Guid OID { get; set; }
    	[DataMember]
        public Nullable<int> YunOrderId { get; set; }
    	[DataMember]
        public Nullable<int> XfbOrderId { get; set; }
    	[DataMember]
        public Nullable<int> DeliveryStatus { get; set; }
    	[DataMember]
        public Nullable<int> PaymentStatus { get; set; }
    	[DataMember]
        public Nullable<int> OrdersStatus { get; set; }
    	[DataMember]
        public Nullable<int> Orders_RefundStatus { get; set; }
    }
}
