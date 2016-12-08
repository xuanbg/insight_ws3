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
    
    public partial class ABS_Clearing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ABS_Clearing()
        {
            this.ABS_Advance_Record = new HashSet<ABS_Advance_Record>();
            this.ABS_Clearing_Item = new HashSet<ABS_Clearing_Item>();
            this.ABS_Clearing_Attachs = new HashSet<ABS_Clearing_Attachs>();
            this.ABS_Contract_FundPerform = new HashSet<ABS_Contract_FundPerform>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public int Direction { get; set; }
        public string ReceiptCode { get; set; }
        public string HashCode { get; set; }
        public Nullable<System.Guid> ObjectId { get; set; }
        public string ObjectName { get; set; }
        public int PrintTimes { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> CheckId { get; set; }
        public Nullable<System.Guid> RelationId { get; set; }
        public bool Validity { get; set; }
        public Nullable<System.Guid> CreatorDeptId { get; set; }
        public System.Guid CreatorUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABS_Advance_Record> ABS_Advance_Record { get; set; }
        public virtual ABS_Clearing_Check ABS_Clearing_Check { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABS_Clearing_Item> ABS_Clearing_Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABS_Clearing_Attachs> ABS_Clearing_Attachs { get; set; }
        public virtual MasterData MasterData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABS_Contract_FundPerform> ABS_Contract_FundPerform { get; set; }
    }
}