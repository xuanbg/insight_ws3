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
    [KnownType(typeof(ABS_Contract))]
    
    public partial class BIZ_Reimburse_Apply
    {
    	[DataMember]
        public System.Guid CID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<int> Days { get; set; }
    	[DataMember]
        public Nullable<decimal> Arrearage { get; set; }
    
    	[DataMember]
        public virtual ABS_Contract ABS_Contract { get; set; }
    }
}
