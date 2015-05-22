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
    [KnownType(typeof(ABS_Clearing))]
    [KnownType(typeof(ABS_Contract))]
    [KnownType(typeof(ABS_Delivery))]
    [KnownType(typeof(ABS_StockCapital))]
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(ImageData))]
    [KnownType(typeof(MDG_Contact))]
    [KnownType(typeof(MDG_Customer))]
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(MDG_Employee))]
    [KnownType(typeof(MDG_Expense))]
    [KnownType(typeof(MDG_Material))]
    [KnownType(typeof(MDG_Supplier))]
    [KnownType(typeof(MDR_ET))]
    [KnownType(typeof(SYS_Alert_Rules))]
    [KnownType(typeof(SYS_Allot_Record))]
    [KnownType(typeof(SYS_Code_Allot))]
    [KnownType(typeof(SYS_Code_Scheme))]
    [KnownType(typeof(SYS_ModuleParam))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_OrgMerger))]
    [KnownType(typeof(SYS_OrgMember))]
    [KnownType(typeof(SYS_Report_Rules))]
    [KnownType(typeof(SYS_Report_Templates))]
    [KnownType(typeof(SYS_Report_Definition))]
    [KnownType(typeof(SYS_Report_Entity))]
    [KnownType(typeof(SYS_Role_Title))]
    [KnownType(typeof(SYS_RolePerm_DataAbs))]
    [KnownType(typeof(ABS_Advance))]
    [KnownType(typeof(ABS_Clearing_Check))]
    [KnownType(typeof(ABS_Storage_Location))]
    
    public partial class SYS_Organization
    {
        public SYS_Organization()
        {
            this.ABS_Clearing = new HashSet<ABS_Clearing>();
            this.ABS_Contract = new HashSet<ABS_Contract>();
            this.ABS_Contract1 = new HashSet<ABS_Contract>();
            this.ABS_Delivery = new HashSet<ABS_Delivery>();
            this.ABS_StockCapital = new HashSet<ABS_StockCapital>();
            this.BASE_Category = new HashSet<BASE_Category>();
            this.ImageData = new HashSet<ImageData>();
            this.MDG_Contact = new HashSet<MDG_Contact>();
            this.MDG_Customer = new HashSet<MDG_Customer>();
            this.MDG_Dictionary = new HashSet<MDG_Dictionary>();
            this.MDG_Employee = new HashSet<MDG_Employee>();
            this.MDG_Expense = new HashSet<MDG_Expense>();
            this.MDG_Material = new HashSet<MDG_Material>();
            this.MDG_Supplier = new HashSet<MDG_Supplier>();
            this.MDR_ET = new HashSet<MDR_ET>();
            this.SYS_Alert_Rules = new HashSet<SYS_Alert_Rules>();
            this.SYS_Allot_Record = new HashSet<SYS_Allot_Record>();
            this.SYS_Code_Allot = new HashSet<SYS_Code_Allot>();
            this.SYS_Code_Scheme = new HashSet<SYS_Code_Scheme>();
            this.SYS_ModuleParam = new HashSet<SYS_ModuleParam>();
            this.SYS_Organization1 = new HashSet<SYS_Organization>();
            this.SYS_OrgMerger = new HashSet<SYS_OrgMerger>();
            this.SYS_OrgMember = new HashSet<SYS_OrgMember>();
            this.SYS_OrgMerger1 = new HashSet<SYS_OrgMerger>();
            this.SYS_Report_Rules = new HashSet<SYS_Report_Rules>();
            this.SYS_Report_Templates = new HashSet<SYS_Report_Templates>();
            this.SYS_Report_Definition = new HashSet<SYS_Report_Definition>();
            this.SYS_Report_Entity = new HashSet<SYS_Report_Entity>();
            this.SYS_Role_Title = new HashSet<SYS_Role_Title>();
            this.SYS_RolePerm_DataAbs = new HashSet<SYS_RolePerm_DataAbs>();
            this.ABS_Advance = new HashSet<ABS_Advance>();
            this.ABS_Clearing_Check = new HashSet<ABS_Clearing_Check>();
            this.ABS_Storage_Location = new HashSet<ABS_Storage_Location>();
        }
    
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
        public string Code { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string Alias { get; set; }
    	[DataMember]
        public string FullName { get; set; }
    	[DataMember]
        public Nullable<System.Guid> PositionId { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Clearing> ABS_Clearing { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract> ABS_Contract { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract> ABS_Contract1 { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Delivery> ABS_Delivery { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_StockCapital> ABS_StockCapital { get; set; }
    	[DataMember]
        public virtual ICollection<BASE_Category> BASE_Category { get; set; }
    	[DataMember]
        public virtual ICollection<ImageData> ImageData { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Contact> MDG_Contact { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Customer> MDG_Customer { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Dictionary> MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual MDG_Dictionary MDG_Dictionary1 { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Employee> MDG_Employee { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Expense> MDG_Expense { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Material> MDG_Material { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Supplier> MDG_Supplier { get; set; }
    	[DataMember]
        public virtual ICollection<MDR_ET> MDR_ET { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Alert_Rules> SYS_Alert_Rules { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Allot_Record> SYS_Allot_Record { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Allot> SYS_Code_Allot { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Scheme> SYS_Code_Scheme { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_ModuleParam> SYS_ModuleParam { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Organization> SYS_Organization1 { get; set; }
    	[DataMember]
        public virtual SYS_Organization SYS_Organization2 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMerger> SYS_OrgMerger { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMember> SYS_OrgMember { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMerger> SYS_OrgMerger1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Rules> SYS_Report_Rules { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Templates> SYS_Report_Templates { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Definition> SYS_Report_Definition { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Entity> SYS_Report_Entity { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role_Title> SYS_Role_Title { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_DataAbs> SYS_RolePerm_DataAbs { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Advance> ABS_Advance { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing_Check> ABS_Clearing_Check { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Storage_Location> ABS_Storage_Location { get; set; }
    }
}