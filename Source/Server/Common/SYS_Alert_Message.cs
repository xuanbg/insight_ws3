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
    [KnownType(typeof(SYS_Alert_Send))]
    [KnownType(typeof(SYS_Alert_Rules))]
    
    public partial class SYS_Alert_Message
    {
        public SYS_Alert_Message()
        {
            this.SYS_Alert_Send = new HashSet<SYS_Alert_Send>();
        }
    
    	[DataMember]
        public Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Guid RuleId { get; set; }
    	[DataMember]
        public string Content { get; set; }
    	[DataMember]
        public DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<SYS_Alert_Send> SYS_Alert_Send { get; set; }
    	[DataMember]
        public virtual SYS_Alert_Rules SYS_Alert_Rules { get; set; }
    }
}
