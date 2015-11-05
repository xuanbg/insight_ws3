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
    
    public partial class MasterData_Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MasterData_Property()
        {
            this.MDD_Binary = new HashSet<MDD_Binary>();
            this.MDD_Character = new HashSet<MDD_Character>();
            this.MDD_Date = new HashSet<MDD_Date>();
            this.MDD_Numeric = new HashSet<MDD_Numeric>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid ModuleId { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Parameter { get; set; }
        public bool BuiltIn { get; set; }
    
        public virtual BASE_Category BASE_Category { get; set; }
        public virtual SYS_Module SYS_Module { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDD_Binary> MDD_Binary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDD_Character> MDD_Character { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDD_Date> MDD_Date { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDD_Numeric> MDD_Numeric { get; set; }
    }
}
