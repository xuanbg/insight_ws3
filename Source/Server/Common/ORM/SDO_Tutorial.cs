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
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SDO_TutorialComment))]
    [KnownType(typeof(SDO_TutorialPraise))]
    
    public partial class SDO_Tutorial
    {
        public SDO_Tutorial()
        {
            this.SDO_TutorialComment = new HashSet<SDO_TutorialComment>();
            this.SDO_TutorialPraise = new HashSet<SDO_TutorialPraise>();
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
        public string Picture { get; set; }
    	[DataMember]
        public string Url { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SDO_TutorialComment> SDO_TutorialComment { get; set; }
    	[DataMember]
        public virtual ICollection<SDO_TutorialPraise> SDO_TutorialPraise { get; set; }
    }
}
