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
    
    [KnownType(typeof(SDG_Group))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SDT_Topic))]
    
    public partial class SDT_Forward
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid TopicId { get; set; }
    	[DataMember]
        public System.Guid GroupId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SDG_Group SDG_Group { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual SDT_Topic SDT_Topic { get; set; }
    }
}
