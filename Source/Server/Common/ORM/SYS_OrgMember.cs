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
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    
    public partial class SYS_OrgMember
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid OrgId { get; set; }
    	[DataMember]
        public System.Guid UserId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User1 { get; set; }
    }
}
