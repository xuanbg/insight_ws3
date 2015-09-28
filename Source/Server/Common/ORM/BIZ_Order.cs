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
    [KnownType(typeof(ABS_Contract))]
    [KnownType(typeof(MDE_Member_Address))]
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(BIZ_StagePlan))]
    
    public partial class BIZ_Order
    {
    	[DataMember]
        public System.Guid OID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<int> MallId { get; set; }
    	[DataMember]
        public string MallCode { get; set; }
    	[DataMember]
        public string MallName { get; set; }
    	[DataMember]
        public Nullable<System.Guid> StagePlan { get; set; }
    	[DataMember]
        public decimal FirstPay { get; set; }
    	[DataMember]
        public Nullable<System.Guid> FirstPayChannel { get; set; }
    	[DataMember]
        public decimal OrderAmount { get; set; }
    	[DataMember]
        public Nullable<System.Guid> AddressId { get; set; }
    	[DataMember]
        public int InvoiceType { get; set; }
    	[DataMember]
        public string InvoiceInfo { get; set; }
    	[DataMember]
        public Nullable<int> YunOrderId { get; set; }
    	[DataMember]
        public Nullable<int> XfbOrderId { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> OutDate { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> CancelTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> RefundTime { get; set; }
    	[DataMember]
        public Nullable<int> OrdersStatus { get; set; }
    	[DataMember]
        public Nullable<int> DeliveryStatus { get; set; }
    	[DataMember]
        public Nullable<int> PaymentStatus { get; set; }
    	[DataMember]
        public decimal Interest { get; set; }
    	[DataMember]
        public Nullable<int> RefundStatus { get; set; }
    
    	[DataMember]
        public virtual ABS_Contract ABS_Contract { get; set; }
    	[DataMember]
        public virtual MDE_Member_Address MDE_Member_Address { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual BIZ_StagePlan BIZ_StagePlan { get; set; }
    }
}
