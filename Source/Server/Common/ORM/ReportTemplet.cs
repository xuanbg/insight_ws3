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
    
    public partial class ReportTemplet
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ParentId { get; set; }
    	[DataMember]
        public long Index { get; set; }
    	[DataMember]
        public Nullable<bool> IsData { get; set; }
    	[DataMember]
        public bool Visible { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Alias { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    }
}
