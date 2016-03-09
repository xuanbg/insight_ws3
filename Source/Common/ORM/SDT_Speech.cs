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
    
    [KnownType(typeof(SDC_FirstVisit))]
    [KnownType(typeof(SDT_Attitude))]
    [KnownType(typeof(SDT_Comment))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SDT_Topic))]
    
    public partial class SDT_Speech
    {
        public SDT_Speech()
        {
            this.SDT_Attitude = new HashSet<SDT_Attitude>();
            this.SDT_Comment = new HashSet<SDT_Comment>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid TopicId { get; set; }
    	[DataMember]
        public string Content { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CaseId { get; set; }
    	[DataMember]
        public bool Recommend { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> PublishTime { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SDC_FirstVisit SDC_FirstVisit { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Attitude> SDT_Attitude { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Comment> SDT_Comment { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual SDT_Topic SDT_Topic { get; set; }
    }
}