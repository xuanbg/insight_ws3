﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ABS_Advance> ABS_Advance { get; set; }
        public virtual DbSet<ABS_Advance_Detail> ABS_Advance_Detail { get; set; }
        public virtual DbSet<ABS_Advance_Record> ABS_Advance_Record { get; set; }
        public virtual DbSet<ABS_Clearing> ABS_Clearing { get; set; }
        public virtual DbSet<ABS_Clearing_Attachs> ABS_Clearing_Attachs { get; set; }
        public virtual DbSet<ABS_Clearing_Check> ABS_Clearing_Check { get; set; }
        public virtual DbSet<ABS_Clearing_Item> ABS_Clearing_Item { get; set; }
        public virtual DbSet<ABS_Clearing_Pay> ABS_Clearing_Pay { get; set; }
        public virtual DbSet<ABS_Contract> ABS_Contract { get; set; }
        public virtual DbSet<ABS_Contract_Attachs> ABS_Contract_Attachs { get; set; }
        public virtual DbSet<ABS_Contract_FundPerform> ABS_Contract_FundPerform { get; set; }
        public virtual DbSet<ABS_Contract_FundPlan> ABS_Contract_FundPlan { get; set; }
        public virtual DbSet<ABS_Contract_GoodsPerform> ABS_Contract_GoodsPerform { get; set; }
        public virtual DbSet<ABS_Contract_GoodsPlan> ABS_Contract_GoodsPlan { get; set; }
        public virtual DbSet<ABS_Contract_Subjects> ABS_Contract_Subjects { get; set; }
        public virtual DbSet<ABS_Delivery> ABS_Delivery { get; set; }
        public virtual DbSet<ABS_Delivery_Attachs> ABS_Delivery_Attachs { get; set; }
        public virtual DbSet<ABS_Delivery_Item> ABS_Delivery_Item { get; set; }
        public virtual DbSet<ABS_StockCapital> ABS_StockCapital { get; set; }
        public virtual DbSet<ABS_StockDetail> ABS_StockDetail { get; set; }
        public virtual DbSet<ABS_Storage_Detail> ABS_Storage_Detail { get; set; }
        public virtual DbSet<ABS_Storage_Location> ABS_Storage_Location { get; set; }
        public virtual DbSet<ABS_Storage_Summary> ABS_Storage_Summary { get; set; }
        public virtual DbSet<BASE_Category> BASE_Category { get; set; }
        public virtual DbSet<BIZ_CodeContrast> BIZ_CodeContrast { get; set; }
        public virtual DbSet<BIZ_Order> BIZ_Order { get; set; }
        public virtual DbSet<BIZ_Pay_Record> BIZ_Pay_Record { get; set; }
        public virtual DbSet<BIZ_Snapshot> BIZ_Snapshot { get; set; }
        public virtual DbSet<BIZ_StagePlan> BIZ_StagePlan { get; set; }
        public virtual DbSet<BIZ_TitleImage> BIZ_TitleImage { get; set; }
        public virtual DbSet<ImageData> ImageData { get; set; }
        public virtual DbSet<MasterData> MasterData { get; set; }
        public virtual DbSet<MDE_Member_Address> MDE_Member_Address { get; set; }
        public virtual DbSet<MDE_Member_Card> MDE_Member_Card { get; set; }
        public virtual DbSet<MDE_Member_Feedback> MDE_Member_Feedback { get; set; }
        public virtual DbSet<MDE_Member_OrderApply> MDE_Member_OrderApply { get; set; }
        public virtual DbSet<MDE_Member_Withdrawal> MDE_Member_Withdrawal { get; set; }
        public virtual DbSet<MDG_Contact> MDG_Contact { get; set; }
        public virtual DbSet<MDG_Customer> MDG_Customer { get; set; }
        public virtual DbSet<MDG_Dictionary> MDG_Dictionary { get; set; }
        public virtual DbSet<MDG_Employee> MDG_Employee { get; set; }
        public virtual DbSet<MDG_Expense> MDG_Expense { get; set; }
        public virtual DbSet<MDG_Material> MDG_Material { get; set; }
        public virtual DbSet<MDG_Supplier> MDG_Supplier { get; set; }
        public virtual DbSet<MDR_MU> MDR_MU { get; set; }
        public virtual DbSet<MDS_Contact_Info> MDS_Contact_Info { get; set; }
        public virtual DbSet<SYS_Alert_Message> SYS_Alert_Message { get; set; }
        public virtual DbSet<SYS_Alert_Rules> SYS_Alert_Rules { get; set; }
        public virtual DbSet<SYS_Alert_Send> SYS_Alert_Send { get; set; }
        public virtual DbSet<SYS_Alert_Target> SYS_Alert_Target { get; set; }
        public virtual DbSet<SYS_Allot_Record> SYS_Allot_Record { get; set; }
        public virtual DbSet<SYS_Code_Allot> SYS_Code_Allot { get; set; }
        public virtual DbSet<SYS_Code_Record> SYS_Code_Record { get; set; }
        public virtual DbSet<SYS_Code_Scheme> SYS_Code_Scheme { get; set; }
        public virtual DbSet<SYS_Interface> SYS_Interface { get; set; }
        public virtual DbSet<SYS_Module> SYS_Module { get; set; }
        public virtual DbSet<SYS_ModuleAction> SYS_ModuleAction { get; set; }
        public virtual DbSet<SYS_ModuleGroup> SYS_ModuleGroup { get; set; }
        public virtual DbSet<SYS_ModuleParam> SYS_ModuleParam { get; set; }
        public virtual DbSet<SYS_Organization> SYS_Organization { get; set; }
        public virtual DbSet<SYS_OrgMember> SYS_OrgMember { get; set; }
        public virtual DbSet<SYS_OrgMerger> SYS_OrgMerger { get; set; }
        public virtual DbSet<SYS_Report_Definition> SYS_Report_Definition { get; set; }
        public virtual DbSet<SYS_Report_Entity> SYS_Report_Entity { get; set; }
        public virtual DbSet<SYS_Report_Instances> SYS_Report_Instances { get; set; }
        public virtual DbSet<SYS_Report_IU> SYS_Report_IU { get; set; }
        public virtual DbSet<SYS_Report_Member> SYS_Report_Member { get; set; }
        public virtual DbSet<SYS_Report_Period> SYS_Report_Period { get; set; }
        public virtual DbSet<SYS_Report_Rules> SYS_Report_Rules { get; set; }
        public virtual DbSet<SYS_Report_Schedular> SYS_Report_Schedular { get; set; }
        public virtual DbSet<SYS_Report_Templates> SYS_Report_Templates { get; set; }
        public virtual DbSet<SYS_Role> SYS_Role { get; set; }
        public virtual DbSet<SYS_Role_Title> SYS_Role_Title { get; set; }
        public virtual DbSet<SYS_Role_User> SYS_Role_User { get; set; }
        public virtual DbSet<SYS_Role_UserGroup> SYS_Role_UserGroup { get; set; }
        public virtual DbSet<SYS_RolePerm_Action> SYS_RolePerm_Action { get; set; }
        public virtual DbSet<SYS_RolePerm_Data> SYS_RolePerm_Data { get; set; }
        public virtual DbSet<SYS_RolePerm_DataAbs> SYS_RolePerm_DataAbs { get; set; }
        public virtual DbSet<SYS_User> SYS_User { get; set; }
        public virtual DbSet<SYS_UserGroup> SYS_UserGroup { get; set; }
        public virtual DbSet<SYS_UserGroupMember> SYS_UserGroupMember { get; set; }
        public virtual DbSet<SYS_WeiXin_Config> SYS_WeiXin_Config { get; set; }
        public virtual DbSet<Advance> Advance { get; set; }
        public virtual DbSet<AllotRecord> AllotRecord { get; set; }
        public virtual DbSet<ApplyInfo> ApplyInfo { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<Citys> Citys { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactInfo> ContactInfo { get; set; }
        public virtual DbSet<Countys> Countys { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<FundForPerform> FundForPerform { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<OrdersList> OrdersList { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Product_Img> Product_Img { get; set; }
        public virtual DbSet<Product_Library_Img> Product_Library_Img { get; set; }
        public virtual DbSet<ProductExtend> ProductExtend { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductType_Extend> ProductType_Extend { get; set; }
        public virtual DbSet<ReportSchedular> ReportSchedular { get; set; }
        public virtual DbSet<ReportTemplet> ReportTemplet { get; set; }
        public virtual DbSet<RoleActionPermit> RoleActionPermit { get; set; }
        public virtual DbSet<RoleDataPermit> RoleDataPermit { get; set; }
        public virtual DbSet<RoleMember> RoleMember { get; set; }
        public virtual DbSet<RoleModulePermit> RoleModulePermit { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<SerialRecord> SerialRecord { get; set; }
        public virtual DbSet<StageInfo> StageInfo { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<SubjectInfo> SubjectInfo { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierInfo> SupplierInfo { get; set; }
        public virtual DbSet<T_ORDERAPPLYS> T_ORDERAPPLYS { get; set; }
        public virtual DbSet<T_ORDERS> T_ORDERS { get; set; }
        public virtual DbSet<T_PREPARE_DOC> T_PREPARE_DOC { get; set; }
        public virtual DbSet<T_REFUNDMENTS> T_REFUNDMENTS { get; set; }
        public virtual DbSet<TitleMember> TitleMember { get; set; }
        public virtual DbSet<WithdrawalList> WithdrawalList { get; set; }
        public virtual DbSet<WitOrderList> WitOrderList { get; set; }
    }
}
