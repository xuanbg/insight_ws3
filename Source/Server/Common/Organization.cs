//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SERP.Server.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    [DataContract(IsReference = true)]
    public partial class Organization
    {
        [DataMember]
        public System.Guid ID { get; set; }
        [DataMember]
        public long SN { get; set; }
        [DataMember]
        public Nullable<System.Guid> ParentId { get; set; }
        [DataMember]
        public int NodeType { get; set; }
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public string 名称 { get; set; }
        [DataMember]
        public string 全称 { get; set; }
        [DataMember]
        public string 简称 { get; set; }
        [DataMember]
        public string 编码 { get; set; }
    }
}
