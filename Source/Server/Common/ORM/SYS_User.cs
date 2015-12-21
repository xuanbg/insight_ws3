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
    [KnownType(typeof(ABS_Advance))]
    [KnownType(typeof(ABS_Clearing))]
    [KnownType(typeof(ABS_Clearing_Check))]
    [KnownType(typeof(ABS_Contract))]
    [KnownType(typeof(ABS_Delivery))]
    [KnownType(typeof(ABS_Storage_Location))]
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(ImageData))]
    [KnownType(typeof(MasterData_Merger))]
    [KnownType(typeof(MDG_Contact))]
    [KnownType(typeof(MDG_Customer))]
    [KnownType(typeof(MDG_Dictionary))]
    [KnownType(typeof(MDG_Employee))]
    [KnownType(typeof(MDG_Expense))]
    [KnownType(typeof(MDG_Material))]
    [KnownType(typeof(MDG_Supplier))]
    [KnownType(typeof(MDR_MU))]
    [KnownType(typeof(SYS_Alert_Rules))]
    [KnownType(typeof(SYS_Allot_Record))]
    [KnownType(typeof(SYS_Code_Allot))]
    [KnownType(typeof(SYS_Code_Scheme))]
    [KnownType(typeof(SYS_ModuleParam))]
    [KnownType(typeof(SYS_Organization))]
    [KnownType(typeof(SYS_OrgMember))]
    [KnownType(typeof(SYS_OrgMerger))]
    [KnownType(typeof(SYS_Report_Definition))]
    [KnownType(typeof(SYS_Report_Instances))]
    [KnownType(typeof(SYS_Report_IU))]
    [KnownType(typeof(SYS_Report_Rules))]
    [KnownType(typeof(SYS_Report_Templates))]
    [KnownType(typeof(SYS_Role))]
    [KnownType(typeof(SYS_Role_Title))]
    [KnownType(typeof(SYS_Role_User))]
    [KnownType(typeof(SYS_Role_UserGroup))]
    [KnownType(typeof(SYS_RolePerm_Action))]
    [KnownType(typeof(SYS_RolePerm_Data))]
    [KnownType(typeof(SYS_RolePerm_DataAbs))]
    [KnownType(typeof(SYS_UserGroup))]
    [KnownType(typeof(SYS_UserGroupMember))]
    [KnownType(typeof(MDE_Favorites))]
    [KnownType(typeof(MDE_Message))]
    [KnownType(typeof(SDC_CaseHistory))]
    [KnownType(typeof(SDC_FirstVisit))]
    [KnownType(typeof(SDC_Subsequent))]
    [KnownType(typeof(SDC_Summary))]
    [KnownType(typeof(SDG_Group))]
    [KnownType(typeof(SDO_Advertisement))]
    [KnownType(typeof(SDO_Recommend))]
    [KnownType(typeof(SDT_Attitude))]
    [KnownType(typeof(SDT_Comment))]
    [KnownType(typeof(SDT_Forward))]
    [KnownType(typeof(SDT_Praise))]
    [KnownType(typeof(SDT_Topic))]
    [KnownType(typeof(SDT_Voice))]
    
    public partial class SYS_User
    {
        public SYS_User()
        {
            this.ABS_Advance = new HashSet<ABS_Advance>();
            this.ABS_Clearing = new HashSet<ABS_Clearing>();
            this.ABS_Clearing_Check = new HashSet<ABS_Clearing_Check>();
            this.ABS_Contract = new HashSet<ABS_Contract>();
            this.ABS_Delivery = new HashSet<ABS_Delivery>();
            this.ABS_Storage_Location = new HashSet<ABS_Storage_Location>();
            this.BASE_Category = new HashSet<BASE_Category>();
            this.ImageData = new HashSet<ImageData>();
            this.MasterData_Merger = new HashSet<MasterData_Merger>();
            this.MDG_Contact = new HashSet<MDG_Contact>();
            this.MDG_Customer = new HashSet<MDG_Customer>();
            this.MDG_Dictionary = new HashSet<MDG_Dictionary>();
            this.MDG_Employee = new HashSet<MDG_Employee>();
            this.MDG_Expense = new HashSet<MDG_Expense>();
            this.MDG_Material = new HashSet<MDG_Material>();
            this.MDG_Supplier = new HashSet<MDG_Supplier>();
            this.MDR_MU = new HashSet<MDR_MU>();
            this.SYS_Alert_Rules = new HashSet<SYS_Alert_Rules>();
            this.SYS_Allot_Record = new HashSet<SYS_Allot_Record>();
            this.SYS_Allot_Record1 = new HashSet<SYS_Allot_Record>();
            this.SYS_Code_Allot = new HashSet<SYS_Code_Allot>();
            this.SYS_Code_Allot1 = new HashSet<SYS_Code_Allot>();
            this.SYS_Code_Scheme = new HashSet<SYS_Code_Scheme>();
            this.SYS_ModuleParam = new HashSet<SYS_ModuleParam>();
            this.SYS_Organization = new HashSet<SYS_Organization>();
            this.SYS_OrgMember = new HashSet<SYS_OrgMember>();
            this.SYS_OrgMember1 = new HashSet<SYS_OrgMember>();
            this.SYS_OrgMerger = new HashSet<SYS_OrgMerger>();
            this.SYS_Report_Definition = new HashSet<SYS_Report_Definition>();
            this.SYS_Report_Instances = new HashSet<SYS_Report_Instances>();
            this.SYS_Report_IU = new HashSet<SYS_Report_IU>();
            this.SYS_Report_Rules = new HashSet<SYS_Report_Rules>();
            this.SYS_Report_Templates = new HashSet<SYS_Report_Templates>();
            this.SYS_Role = new HashSet<SYS_Role>();
            this.SYS_Role_Title = new HashSet<SYS_Role_Title>();
            this.SYS_Role_User = new HashSet<SYS_Role_User>();
            this.SYS_Role_User1 = new HashSet<SYS_Role_User>();
            this.SYS_Role_UserGroup = new HashSet<SYS_Role_UserGroup>();
            this.SYS_RolePerm_Action = new HashSet<SYS_RolePerm_Action>();
            this.SYS_RolePerm_Data = new HashSet<SYS_RolePerm_Data>();
            this.SYS_RolePerm_DataAbs = new HashSet<SYS_RolePerm_DataAbs>();
            this.SYS_UserGroup = new HashSet<SYS_UserGroup>();
            this.SYS_UserGroupMember = new HashSet<SYS_UserGroupMember>();
            this.SYS_UserGroupMember1 = new HashSet<SYS_UserGroupMember>();
            this.MDE_Favorites = new HashSet<MDE_Favorites>();
            this.MDE_Message = new HashSet<MDE_Message>();
            this.SDC_CaseHistory = new HashSet<SDC_CaseHistory>();
            this.SDC_FirstVisit = new HashSet<SDC_FirstVisit>();
            this.SDC_Subsequent = new HashSet<SDC_Subsequent>();
            this.SDC_Summary = new HashSet<SDC_Summary>();
            this.SDG_Group = new HashSet<SDG_Group>();
            this.SDG_Group1 = new HashSet<SDG_Group>();
            this.SDG_Group2 = new HashSet<SDG_Group>();
            this.SDO_Advertisement = new HashSet<SDO_Advertisement>();
            this.SDO_Recommend = new HashSet<SDO_Recommend>();
            this.SDT_Attitude = new HashSet<SDT_Attitude>();
            this.SDT_Comment = new HashSet<SDT_Comment>();
            this.SDT_Forward = new HashSet<SDT_Forward>();
            this.SDT_Praise = new HashSet<SDT_Praise>();
            this.SDT_Topic = new HashSet<SDT_Topic>();
            this.SDT_Voice = new HashSet<SDT_Voice>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string LoginName { get; set; }
    	[DataMember]
        public string Password { get; set; }
    	[DataMember]
        public string PayPassword { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public int Type { get; set; }
    	[DataMember]
        public bool BuiltIn { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public Nullable<System.Guid> CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    	[DataMember]
        public string OpenId { get; set; }
    
    	[DataMember]
        public virtual ICollection<ABS_Advance> ABS_Advance { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing> ABS_Clearing { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Clearing_Check> ABS_Clearing_Check { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Contract> ABS_Contract { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Delivery> ABS_Delivery { get; set; }
    	[DataMember]
        public virtual ICollection<ABS_Storage_Location> ABS_Storage_Location { get; set; }
    	[DataMember]
        public virtual ICollection<BASE_Category> BASE_Category { get; set; }
    	[DataMember]
        public virtual ICollection<ImageData> ImageData { get; set; }
    	[DataMember]
        public virtual ICollection<MasterData_Merger> MasterData_Merger { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Contact> MDG_Contact { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Customer> MDG_Customer { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Dictionary> MDG_Dictionary { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Employee> MDG_Employee { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Expense> MDG_Expense { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Material> MDG_Material { get; set; }
    	[DataMember]
        public virtual ICollection<MDG_Supplier> MDG_Supplier { get; set; }
    	[DataMember]
        public virtual ICollection<MDR_MU> MDR_MU { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Alert_Rules> SYS_Alert_Rules { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Allot_Record> SYS_Allot_Record { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Allot_Record> SYS_Allot_Record1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Allot> SYS_Code_Allot { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Allot> SYS_Code_Allot1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Scheme> SYS_Code_Scheme { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_ModuleParam> SYS_ModuleParam { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Organization> SYS_Organization { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMember> SYS_OrgMember { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMember> SYS_OrgMember1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_OrgMerger> SYS_OrgMerger { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Definition> SYS_Report_Definition { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Instances> SYS_Report_Instances { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_IU> SYS_Report_IU { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Rules> SYS_Report_Rules { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Report_Templates> SYS_Report_Templates { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role> SYS_Role { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role_Title> SYS_Role_Title { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role_User> SYS_Role_User { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role_User> SYS_Role_User1 { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Role_UserGroup> SYS_Role_UserGroup { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_Action> SYS_RolePerm_Action { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_Data> SYS_RolePerm_Data { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_DataAbs> SYS_RolePerm_DataAbs { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_UserGroup> SYS_UserGroup { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_UserGroupMember> SYS_UserGroupMember { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_UserGroupMember> SYS_UserGroupMember1 { get; set; }
    	[DataMember]
        public virtual ICollection<MDE_Favorites> MDE_Favorites { get; set; }
    	[DataMember]
        public virtual ICollection<MDE_Message> MDE_Message { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_CaseHistory> SDC_CaseHistory { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_FirstVisit> SDC_FirstVisit { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_Subsequent> SDC_Subsequent { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_Summary> SDC_Summary { get; set; }
    	[DataMember]
        public virtual ICollection<SDG_Group> SDG_Group { get; set; }
    	[DataMember]
        public virtual ICollection<SDG_Group> SDG_Group1 { get; set; }
    	[DataMember]
        public virtual ICollection<SDG_Group> SDG_Group2 { get; set; }
    	[DataMember]
        public virtual ICollection<SDO_Advertisement> SDO_Advertisement { get; set; }
    	[DataMember]
        public virtual ICollection<SDO_Recommend> SDO_Recommend { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Attitude> SDT_Attitude { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Comment> SDT_Comment { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Forward> SDT_Forward { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Praise> SDT_Praise { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Topic> SDT_Topic { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Voice> SDT_Voice { get; set; }
    }
}
