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
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(SYS_Alert_Message))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SYS_Alert_Target))]
    
    public partial class SYS_Alert_Rules
    {
        public SYS_Alert_Rules()
        {
            this.SYS_Alert_Message = new HashSet<SYS_Alert_Message>();
            this.SYS_Alert_Target = new HashSet<SYS_Alert_Target>();
        }
    
    	[DataMember]
        public Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<Guid> CategoryId { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Script { get; set; }
    	[DataMember]
        public Nullable<int> UpperLimit { get; set; }
    	[DataMember]
        public Nullable<int> UpperType { get; set; }
    	[DataMember]
        public Nullable<int> LowerLimit { get; set; }
    	[DataMember]
        public Nullable<int> LowerType { get; set; }
    	[DataMember]
        public Nullable<int> LimitRules { get; set; }
    	[DataMember]
        public int CycleType { get; set; }
    	[DataMember]
        public int Cycle { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool Enable { get; set; }
    	[DataMember]
        public Nullable<Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public Guid CreatorUserId { get; set; }
    	[DataMember]
        public DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual BASE_Category BASE_Category { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Alert_Message> SYS_Alert_Message { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Alert_Target> SYS_Alert_Target { get; set; }
    }
}
