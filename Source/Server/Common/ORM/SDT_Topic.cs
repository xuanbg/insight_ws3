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
    [KnownType(typeof(SDC_FirstVisit))]
    [KnownType(typeof(SDT_Forward))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SDT_Voice))]
    
    public partial class SDT_Topic
    {
        public SDT_Topic()
        {
            this.SDT_Forward = new HashSet<SDT_Forward>();
            this.SDT_Voice = new HashSet<SDT_Voice>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public string Title { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public string Tags { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CaseId { get; set; }
    	[DataMember]
        public bool Private { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> PublishTime { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SDC_FirstVisit SDC_FirstVisit { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Forward> SDT_Forward { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Voice> SDT_Voice { get; set; }
    }
}
