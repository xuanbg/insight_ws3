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
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(ABS_Contract_Subjects))]
    [KnownType(typeof(ABS_Contract_Attachs))]
    [KnownType(typeof(ABS_Contract_FundPlan))]
    [KnownType(typeof(MDG_Employee))]
    
    public partial class ABS_Contract
    {
        public ABS_Contract()
        {
            this.ABS_Contract_Subjects = new HashSet<ABS_Contract_Subjects>();
            this.ABS_Contract_Attachs = new HashSet<ABS_Contract_Attachs>();
            this.ABS_Contract_FundPlan = new HashSet<ABS_Contract_FundPlan>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ParentId { get; set; }
    	[DataMember]
        public string ContractCode { get; set; }
    	[DataMember]
        public string Title { get; set; }
    	[DataMember]
        public System.Guid ObjectId { get; set; }
    	[DataMember]
        public string ObjectName { get; set; }
    	[DataMember]
        public Nullable<System.Guid> AgentId { get; set; }
    	[DataMember]
        public string AgentName { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ExecuteDeptId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ExecuteUserId { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> EffectiveDate { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> InvalidDate { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_Subjects> ABS_Contract_Subjects { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_Attachs> ABS_Contract_Attachs { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_FundPlan> ABS_Contract_FundPlan { get; set; }
    	[DataMember]
        public virtual MDG_Employee MDG_Employee { get; set; }
    	[DataMember]
        public virtual MasterData MasterData1 { get; set; }
    }
}
