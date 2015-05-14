//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Insight.WS.Server.Common
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ABS_Contract))]
    [KnownType(typeof(ABS_Contract_GoodsPlan))]
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(BIZ_Reimburse_Detail))]
    [KnownType(typeof(ABS_Contract_FundPlan))]
    
    public partial class ABS_Contract_Subjects
    {
        public ABS_Contract_Subjects()
        {
            this.ABS_Contract_GoodsPlan = new HashSet<ABS_Contract_GoodsPlan>();
            this.ABS_Contract_FundPlan = new HashSet<ABS_Contract_FundPlan>();
        }
    
    	[DataMember]
        public Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Guid ContractId { get; set; }
    	[DataMember]
        public int Direction { get; set; }
    	[DataMember]
        public int PlanType { get; set; }
    	[DataMember]
        public Nullable<Guid> CategoryId { get; set; }
    	[DataMember]
        public Nullable<Guid> ObjectId { get; set; }
    	[DataMember]
        public string ObjectName { get; set; }
    	[DataMember]
        public Nullable<DateTime> EffectiveDate { get; set; }
    	[DataMember]
        public Nullable<DateTime> InvalidDate { get; set; }
    	[DataMember]
        public string Units { get; set; }
    	[DataMember]
        public Nullable<decimal> Price { get; set; }
    	[DataMember]
        public Nullable<decimal> Counts { get; set; }
    	[DataMember]
        public Nullable<decimal> Amount { get; set; }
    	[DataMember]
        public string Description { get; set; }
    
    	[DataMember]
        public virtual ABS_Contract ABS_Contract { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_GoodsPlan> ABS_Contract_GoodsPlan { get; set; }
    	[DataMember]
        public virtual BASE_Category BASE_Category { get; set; }
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual BIZ_Reimburse_Detail BIZ_Reimburse_Detail { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_FundPlan> ABS_Contract_FundPlan { get; set; }
    }
}
