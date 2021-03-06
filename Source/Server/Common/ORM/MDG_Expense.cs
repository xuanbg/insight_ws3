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
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    
    public partial class MDG_Expense
    {
    	[DataMember]
        public System.Guid MID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public int Index { get; set; }
    	[DataMember]
        public Nullable<System.Guid> Unit { get; set; }
    	[DataMember]
        public Nullable<decimal> Price { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool BuiltIn { get; set; }
    	[DataMember]
        public bool Enable { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    }
}
