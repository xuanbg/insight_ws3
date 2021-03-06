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
    [KnownType(typeof(ABS_Storage_Location))]
    [KnownType(typeof(ABS_Storage_Summary))]
    
    public partial class ABS_Storage_Detail
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid SummaryId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> LocationId { get; set; }
    	[DataMember]
        public int BatchNumber { get; set; }
    	[DataMember]
        public Nullable<decimal> Price { get; set; }
    	[DataMember]
        public Nullable<decimal> Counts { get; set; }
    
    	[DataMember]
        public virtual ABS_Storage_Location ABS_Storage_Location { get; set; }
    	[DataMember]
        public virtual ABS_Storage_Summary ABS_Storage_Summary { get; set; }
    }
}
