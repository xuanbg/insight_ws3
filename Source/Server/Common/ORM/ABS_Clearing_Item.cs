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
    [KnownType(typeof(ABS_Clearing))]
    [KnownType(typeof(ABS_Clearing_Pay))]
    [KnownType(typeof(MasterData))]
    
    public partial class ABS_Clearing_Item
    {
        public ABS_Clearing_Item()
        {
            this.ABS_Clearing_Pay = new HashSet<ABS_Clearing_Pay>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid ClearingId { get; set; }
    	[DataMember]
        public string Summary { get; set; }
    	[DataMember]
        public System.Guid ObjectId { get; set; }
    	[DataMember]
        public string ObjectName { get; set; }
    	[DataMember]
        public string Units { get; set; }
    	[DataMember]
        public Nullable<decimal> Price { get; set; }
    	[DataMember]
        public Nullable<decimal> Counts { get; set; }
    	[DataMember]
        public decimal Amount { get; set; }
    
    	[DataMember]
        public virtual ABS_Clearing ABS_Clearing { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing_Pay> ABS_Clearing_Pay { get; set; }
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    }
}
