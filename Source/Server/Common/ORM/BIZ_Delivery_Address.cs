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
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(MDG_Member))]
    
    public partial class BIZ_Delivery_Address
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid MemberId { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Mobile { get; set; }
    	[DataMember]
        public Nullable<System.Guid> StateId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CityId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CountyId { get; set; }
    	[DataMember]
        public string Street { get; set; }
    	[DataMember]
        public string ZipCode { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool Default { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual BASE_Category BASE_Category { get; set; }
    	[DataMember]
        public virtual BASE_Category BASE_Category1 { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual MDG_Member MDG_Member { get; set; }
    }
}
