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
    
    public partial class ABS_Contract_FundPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ABS_Contract_FundPlan()
        {
            this.ABS_Contract_FundPerform = new HashSet<ABS_Contract_FundPerform>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid ContractId { get; set; }
        public Nullable<System.Guid> SubjectsId { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<System.Guid> CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<System.DateTime> Ex_StartDate { get; set; }
        public Nullable<System.DateTime> Ex_EndDate { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual ABS_Contract ABS_Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABS_Contract_FundPerform> ABS_Contract_FundPerform { get; set; }
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
        public virtual ABS_Contract_Subjects ABS_Contract_Subjects { get; set; }
    }
}
