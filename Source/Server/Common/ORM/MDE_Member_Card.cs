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
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(MDE_Member_Withdrawal))]
    
    public partial class MDE_Member_Card
    {
        public MDE_Member_Card()
        {
            this.MDE_Member_Withdrawal = new HashSet<MDE_Member_Withdrawal>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid MemberId { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Type { get; set; }
    	[DataMember]
        public string BankName { get; set; }
    	[DataMember]
        public string Number { get; set; }
    	[DataMember]
        public bool Default { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual ICollection<MDE_Member_Withdrawal> MDE_Member_Withdrawal { get; set; }
    }
}
