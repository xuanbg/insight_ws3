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
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(MDG_Employee))]
    [KnownType(typeof(MDR_ET))]
    
    public partial class MDG_Employee
    {
        public MDG_Employee()
        {
            this.ABS_Contract = new HashSet<ABS_Contract>();
            this.MDG_Employee1 = new HashSet<MDG_Employee>();
            this.MDR_ET = new HashSet<MDR_ET>();
        }
    
    	[DataMember]
        public System.Guid MID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<int> Gender { get; set; }
    	[DataMember]
        public Nullable<System.Guid> WorkType { get; set; }
    	[DataMember]
        public string IdCardNo { get; set; }
    	[DataMember]
        public Nullable<System.Guid> DirectLeader { get; set; }
    	[DataMember]
        public string OfficeAddress { get; set; }
    	[DataMember]
        public string HomeAddress { get; set; }
    	[DataMember]
        public byte[] Photo { get; set; }
    	[DataMember]
        public byte[] Thumbnail { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> EntryDate { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> DimissionDate { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public int Status { get; set; }
    	[DataMember]
        public bool LoginUser { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Contract> ABS_Contract { get; set; }
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Employee> MDG_Employee1 { get; set; }
    	[DataMember]
        public virtual MDG_Employee MDG_Employee2 { get; set; }
    	[DataMember]
        public virtual ICollection<MDR_ET> MDR_ET { get; set; }
    }
}