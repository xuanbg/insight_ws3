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
    
    public partial class SYS_Report_Templates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Report_Templates()
        {
            this.SYS_Report_Definition = new HashSet<SYS_Report_Definition>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> CreatorDeptId { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual BASE_Category BASE_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Report_Definition> SYS_Report_Definition { get; set; }
    }
}
