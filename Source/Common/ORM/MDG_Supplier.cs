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
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(MDG_Dictionary))]
    
    public partial class MDG_Supplier
    {
    	[DataMember]
        public System.Guid MID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<System.Guid> EnterpriseType { get; set; }
    	[DataMember]
        public Nullable<System.Guid> IndustryType { get; set; }
    	[DataMember]
        public string RegisterNumber { get; set; }
    	[DataMember]
        public string TaxNumber { get; set; }
    	[DataMember]
        public string Corporation { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> RegisterDate { get; set; }
    	[DataMember]
        public string BusinessScope { get; set; }
    	[DataMember]
        public string Scale { get; set; }
    	[DataMember]
        public Nullable<int> Staffs { get; set; }
    	[DataMember]
        public Nullable<System.Guid> State { get; set; }
    	[DataMember]
        public Nullable<System.Guid> Province { get; set; }
    	[DataMember]
        public Nullable<System.Guid> City { get; set; }
    	[DataMember]
        public Nullable<System.Guid> District { get; set; }
    	[DataMember]
        public string Address { get; set; }
    	[DataMember]
        public string Phone { get; set; }
    	[DataMember]
        public string ZipCode { get; set; }
    	[DataMember]
        public string Website { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool Enable { get; set; }
    	[DataMember]
        public bool Visible { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual BASE_Category BASE_Category { get; set; }
    	[DataMember]
        public virtual BASE_Category BASE_Category1 { get; set; }
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary1 { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary2 { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary3 { get; set; }
    }
}
