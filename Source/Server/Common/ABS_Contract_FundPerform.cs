//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace Insight.WS.Server.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ABS_Clearing_Item))]
    [KnownType(typeof(ABS_Contract_FundPlan))]
    
    public partial class ABS_Contract_FundPerform
    {
    	[DataMember]
        public Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Guid PlanId { get; set; }
    	[DataMember]
        public Guid ClearingId { get; set; }
    	[DataMember]
        public decimal Amount { get; set; }
    	[DataMember]
        public DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ABS_Clearing_Item ABS_Clearing_Item { get; set; }
    	[DataMember]
        public virtual ABS_Contract_FundPlan ABS_Contract_FundPlan { get; set; }
    }
}
