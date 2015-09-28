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
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(ABS_StockDetail))]
    [KnownType(typeof(ABS_Clearing_Item))]
    
    public partial class ABS_Clearing_Pay
    {
        public ABS_Clearing_Pay()
        {
            this.ABS_StockDetail = new HashSet<ABS_StockDetail>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid ClearingItemId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> PayType { get; set; }
    	[DataMember]
        public string Code { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CurrencyId { get; set; }
    	[DataMember]
        public decimal Amount { get; set; }
    	[DataMember]
        public decimal ExchangeRate { get; set; }
    
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary1 { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_StockDetail> ABS_StockDetail { get; set; }
    	[DataMember]
        public virtual ABS_Clearing_Item ABS_Clearing_Item { get; set; }
    }
}
