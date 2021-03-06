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
    [KnownType(typeof(SYS_Alert_Message))]
    
    public partial class SYS_Alert_Send
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid MessageId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> TargetId { get; set; }
    	[DataMember]
        public Nullable<int> SendType { get; set; }
    	[DataMember]
        public string Target { get; set; }
    	[DataMember]
        public Nullable<int> Times { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> SendTime { get; set; }
    	[DataMember]
        public int Status { get; set; }
    
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual SYS_Alert_Message SYS_Alert_Message { get; set; }
    }
}
