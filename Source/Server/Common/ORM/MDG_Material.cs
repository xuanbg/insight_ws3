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
    using System.Collections.Generic;
    
    public partial class MDG_Material
    {
        public System.Guid MID { get; set; }
        public long SN { get; set; }
        public int Index { get; set; }
        public string BarCode { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public Nullable<System.Guid> SizeType { get; set; }
        public Nullable<System.Guid> Unit { get; set; }
        public Nullable<System.Guid> StorageType { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public Nullable<System.Guid> CreatorDeptId { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual MasterData MasterData { get; set; }
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
        public virtual MDG_Dictionary MDG_Dictionary1 { get; set; }
        public virtual MDG_Dictionary MDG_Dictionary2 { get; set; }
        public virtual SYS_Organization SYS_Organization { get; set; }
        public virtual SYS_User SYS_User { get; set; }
    }
}
