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
    
    public partial class MDE_Member_Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MDE_Member_Address()
        {
            this.BIZ_Order = new HashSet<BIZ_Order>();
        }
    
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.Guid> StateId { get; set; }
        public Nullable<System.Guid> CityId { get; set; }
        public Nullable<System.Guid> CountyId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
        public bool Validity { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual BASE_Category BASE_Category { get; set; }
        public virtual BASE_Category BASE_Category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIZ_Order> BIZ_Order { get; set; }
        public virtual MasterData MasterData { get; set; }
        public virtual MDG_Dictionary MDG_Dictionary { get; set; }
    }
}