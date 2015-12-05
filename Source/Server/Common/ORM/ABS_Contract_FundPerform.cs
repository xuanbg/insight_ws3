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
    [KnownType(typeof(ABS_Contract_FundPlan))]
    [KnownType(typeof(ABS_Clearing))]
    
    public partial class ABS_Contract_FundPerform
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid PlanId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ClearingId { get; set; }
    	[DataMember]
        public decimal Amount { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ABS_Contract_FundPlan ABS_Contract_FundPlan { get; set; }
    	[DataMember]
        public virtual ABS_Clearing ABS_Clearing { get; set; }
    }
}
