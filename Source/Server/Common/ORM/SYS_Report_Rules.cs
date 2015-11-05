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
    
    public partial class SYS_Report_Rules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Report_Rules()
        {
            this.SYS_Report_Period = new HashSet<SYS_Report_Period>();
            this.SYS_Report_Schedular = new HashSet<SYS_Report_Schedular>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public string Name { get; set; }
        public Nullable<int> CycleType { get; set; }
        public Nullable<int> Cycle { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public string Description { get; set; }
        public bool BuiltIn { get; set; }
        public Nullable<System.Guid> CreatorDeptId { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual SYS_Organization SYS_Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Report_Period> SYS_Report_Period { get; set; }
        public virtual SYS_User SYS_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Report_Schedular> SYS_Report_Schedular { get; set; }
    }
}
