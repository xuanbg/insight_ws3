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
    [KnownType(typeof(ABS_Advance_Record))]
    [KnownType(typeof(ABS_Clearing_Check))]
    [KnownType(typeof(ABS_Clearing_Item))]
    [KnownType(typeof(ABS_Clearing_Attachs))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(ABS_Contract_FundPerform))]
    
    public partial class ABS_Clearing
    {
        public ABS_Clearing()
        {
            this.ABS_Advance_Record = new HashSet<ABS_Advance_Record>();
            this.ABS_Clearing_Item = new HashSet<ABS_Clearing_Item>();
            this.ABS_Clearing_Attachs = new HashSet<ABS_Clearing_Attachs>();
            this.ABS_Contract_FundPerform = new HashSet<ABS_Contract_FundPerform>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public int Direction { get; set; }
    	[DataMember]
        public string ReceiptCode { get; set; }
    	[DataMember]
        public string HashCode { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ObjectId { get; set; }
    	[DataMember]
        public string ObjectName { get; set; }
    	[DataMember]
        public int PrintTimes { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CheckId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> RelationId { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Advance_Record> ABS_Advance_Record { get; set; }
    	[DataMember]
        public virtual ABS_Clearing_Check ABS_Clearing_Check { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing_Item> ABS_Clearing_Item { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing_Attachs> ABS_Clearing_Attachs { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract_FundPerform> ABS_Contract_FundPerform { get; set; }
    }
}