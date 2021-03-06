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
    [KnownType(typeof(SYS_Report_Definition))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SYS_Report_IU))]
    
    public partial class SYS_Report_Instances
    {
        public SYS_Report_Instances()
        {
            this.SYS_Report_IU = new HashSet<SYS_Report_IU>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid ReportId { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public byte[] Content { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SYS_Report_Definition SYS_Report_Definition { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_IU> SYS_Report_IU { get; set; }
    }
}
