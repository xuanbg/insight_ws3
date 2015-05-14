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
    [KnownType(typeof(ABS_Delivery))]
    [KnownType(typeof(ABS_Storage_Detail))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(MDG_Dictionary))]
    
    public partial class ABS_Storage_Location
    {
        public ABS_Storage_Location()
        {
            this.ABS_Delivery = new HashSet<ABS_Delivery>();
            this.ABS_Storage_Detail = new HashSet<ABS_Storage_Detail>();
        }
    
    	[DataMember]
        public Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<Guid> ParentId { get; set; }
    	[DataMember]
        public int Index { get; set; }
    	[DataMember]
        public int NodeType { get; set; }
    	[DataMember]
        public Nullable<Guid> StorageType { get; set; }
    	[DataMember]
        public string Code { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Alias { get; set; }
    	[DataMember]
        public Nullable<Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public Guid CreatorUserId { get; set; }
    	[DataMember]
        public DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Delivery> ABS_Delivery { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Storage_Detail> ABS_Storage_Detail { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    }
}
