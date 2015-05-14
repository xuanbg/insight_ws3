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
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_Report_Definition))]
    [KnownType(typeof(SYS_User))]
    
    public partial class SYS_Report_Templates
    {
        public SYS_Report_Templates()
        {
            this.SYS_Report_Definition = new HashSet<SYS_Report_Definition>();
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
        public string Content { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public Guid CreatorUserId { get; set; }
    	[DataMember]
        public DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual BASE_Category BASE_Category { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Definition> SYS_Report_Definition { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    }
}
