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
    [KnownType(typeof(ABS_Contract_Subjects))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SYS_Module))]
    [KnownType(typeof(ImageData))]
    [KnownType(typeof(MasterData_Property))]
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(MDG_Customer))]
    [KnownType(typeof(MDG_Supplier))]
    [KnownType(typeof(SYS_Alert_Rules))]
    [KnownType(typeof(SYS_Report_Templates))]
    [KnownType(typeof(SYS_Report_Definition))]
    
    public partial class BASE_Category
    {
        public BASE_Category()
        {
            this.ABS_Contract_Subjects = new HashSet<ABS_Contract_Subjects>();
            this.ImageData = new HashSet<ImageData>();
            this.MasterData_Property = new HashSet<MasterData_Property>();
            this.MasterData = new HashSet<MasterData>();
            this.MDG_Customer = new HashSet<MDG_Customer>();
            this.MDG_Customer1 = new HashSet<MDG_Customer>();
            this.MDG_Supplier = new HashSet<MDG_Supplier>();
            this.MDG_Supplier1 = new HashSet<MDG_Supplier>();
            this.SYS_Alert_Rules = new HashSet<SYS_Alert_Rules>();
            this.SYS_Report_Templates = new HashSet<SYS_Report_Templates>();
            this.SYS_Report_Definition = new HashSet<SYS_Report_Definition>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ParentId { get; set; }
    	[DataMember]
        public System.Guid ModuleId { get; set; }
    	[DataMember]
        public int Index { get; set; }
    	[DataMember]
        public string Code { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Alias { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public bool BuiltIn { get; set; }
    	[DataMember]
        public bool Visible { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorDeptId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Contract_Subjects> ABS_Contract_Subjects { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual SYS_Module SYS_Module { get; set; }
    	[DataMember]
        public virtual ICollection<ImageData> ImageData { get; set; }
    	[DataMember]
        public virtual ICollection<MasterData_Property> MasterData_Property { get; set; }
    	[DataMember]
        public virtual ICollection<MasterData> MasterData { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Customer> MDG_Customer { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Customer> MDG_Customer1 { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Supplier> MDG_Supplier { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Supplier> MDG_Supplier1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Alert_Rules> SYS_Alert_Rules { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Templates> SYS_Report_Templates { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Definition> SYS_Report_Definition { get; set; }
    }
}
