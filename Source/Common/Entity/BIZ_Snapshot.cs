//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BIZ_Snapshot
    {
        public System.Guid SID { get; set; }
        public long SN { get; set; }
        public string ProductName { get; set; }
        public string ProductSpeci { get; set; }
        public Nullable<decimal> ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string Parameter { get; set; }
        public string PackingList { get; set; }
        public string Description { get; set; }
        public string ProductPic1 { get; set; }
        public string ProductPic2 { get; set; }
        public string ProductPic3 { get; set; }
        public string ProductPic4 { get; set; }
        public string ProductPic5 { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual ABS_Contract_Subjects ABS_Contract_Subjects { get; set; }
    }
}