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
    [KnownType(typeof(SYS_Role_UserGroup))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SYS_UserGroupMember))]
    
    public partial class SYS_UserGroup
    {
        public SYS_UserGroup()
        {
            this.SYS_Role_UserGroup = new HashSet<SYS_Role_UserGroup>();
            this.SYS_UserGroupMember = new HashSet<SYS_UserGroupMember>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool BuiltIn { get; set; }
    	[DataMember]
        public bool Visible { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<SYS_Role_UserGroup> SYS_Role_UserGroup { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_UserGroupMember> SYS_UserGroupMember { get; set; }
    }
}
