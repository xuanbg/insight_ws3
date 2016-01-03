﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public partial class WSEntities : DbContext
    {
    	public WSEntities()
            : this(false) { }
    
        public WSEntities(bool proxyCreationEnabled)
            : base("name=WSEntities")
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    	
        public WSEntities(string connectionString)
          : this(connectionString, false) { }
    	  
        public WSEntities(string connectionString, bool proxyCreationEnabled)
            : base(connectionString)
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }	
    	
        public ObjectContext ObjectContext
        {
          get { return ((IObjectContextAdapter)this).ObjectContext; }
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
        public virtual DbSet<ImageData> ImageData { get; set; }
        public virtual DbSet<MasterData> MasterData { get; set; }
        public virtual DbSet<MasterData_Merger> MasterData_Merger { get; set; }
        public virtual DbSet<MasterData_Property> MasterData_Property { get; set; }
        public virtual DbSet<MDD_Binary> MDD_Binary { get; set; }
        public virtual DbSet<MDD_Character> MDD_Character { get; set; }
        public virtual DbSet<MDD_Date> MDD_Date { get; set; }
        public virtual DbSet<MDD_Numeric> MDD_Numeric { get; set; }
        public virtual DbSet<MDG_Contact> MDG_Contact { get; set; }
        public virtual DbSet<MDG_Customer> MDG_Customer { get; set; }
        public virtual DbSet<MDG_Dictionary> MDG_Dictionary { get; set; }
        public virtual DbSet<MDG_Employee> MDG_Employee { get; set; }
        public virtual DbSet<MDG_Expense> MDG_Expense { get; set; }
        public virtual DbSet<MDG_Material> MDG_Material { get; set; }
        public virtual DbSet<MDG_Supplier> MDG_Supplier { get; set; }
        public virtual DbSet<MDR_ET> MDR_ET { get; set; }
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
        public virtual DbSet<Advance> Advance { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<ReportSchedular> ReportSchedular { get; set; }
        public virtual DbSet<ReportTemplet> ReportTemplet { get; set; }
        public virtual DbSet<MDE_Favorites> MDE_Favorites { get; set; }
        public virtual DbSet<MDE_Message> MDE_Message { get; set; }
        public virtual DbSet<MDG_Member> MDG_Member { get; set; }
        public virtual DbSet<SDC_CaseHistory> SDC_CaseHistory { get; set; }
        public virtual DbSet<SDC_FirstVisit> SDC_FirstVisit { get; set; }
        public virtual DbSet<SDC_Subsequent> SDC_Subsequent { get; set; }
        public virtual DbSet<SDC_Summary> SDC_Summary { get; set; }
        public virtual DbSet<SDG_Group> SDG_Group { get; set; }
        public virtual DbSet<SDG_GroupMember> SDG_GroupMember { get; set; }
        public virtual DbSet<SDO_Advertisement> SDO_Advertisement { get; set; }
        public virtual DbSet<SDO_Recommend> SDO_Recommend { get; set; }
        public virtual DbSet<SDT_Attitude> SDT_Attitude { get; set; }
        public virtual DbSet<SDT_Comment> SDT_Comment { get; set; }
        public virtual DbSet<SDT_Forward> SDT_Forward { get; set; }
        public virtual DbSet<SDT_Praise> SDT_Praise { get; set; }
        public virtual DbSet<SDT_Topic> SDT_Topic { get; set; }
        public virtual DbSet<SDO_Tutorial> SDO_Tutorial { get; set; }
        public virtual DbSet<SDO_TutorialComment> SDO_TutorialComment { get; set; }
        public virtual DbSet<SDO_TutorialPraise> SDO_TutorialPraise { get; set; }
        public virtual DbSet<MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<Speechs> Speechs { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<SDT_Speech> SDT_Speech { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
    
        [DbFunction("WSEntities", "GetTopic")]
        public virtual IQueryable<Topic> GetTopic(Nullable<System.Guid> topicId, Nullable<System.Guid> userId)
        {
            var topicIdParameter = topicId.HasValue ?
                new ObjectParameter("TopicId", topicId) :
                new ObjectParameter("TopicId", typeof(System.Guid));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Topic>("[WSEntities].[GetTopic](@TopicId, @UserId)", topicIdParameter, userIdParameter);
        }
    
        [DbFunction("WSEntities", "Authority")]
        public virtual IQueryable<Nullable<System.Guid>> Authority(Nullable<System.Guid> userId, Nullable<System.Guid> deptId, Nullable<System.Guid> actionId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            var deptIdParameter = deptId.HasValue ?
                new ObjectParameter("DeptId", deptId) :
                new ObjectParameter("DeptId", typeof(System.Guid));
    
            var actionIdParameter = actionId.HasValue ?
                new ObjectParameter("ActionId", actionId) :
                new ObjectParameter("ActionId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Nullable<System.Guid>>("[WSEntities].[Authority](@UserId, @DeptId, @ActionId)", userIdParameter, deptIdParameter, actionIdParameter);
        }
    
        [DbFunction("WSEntities", "GetComments")]
        public virtual IQueryable<Comments> GetComments(Nullable<System.Guid> speechId, Nullable<System.Guid> userId)
        {
            var speechIdParameter = speechId.HasValue ?
                new ObjectParameter("SpeechId", speechId) :
                new ObjectParameter("SpeechId", typeof(System.Guid));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Comments>("[WSEntities].[GetComments](@SpeechId, @UserId)", speechIdParameter, userIdParameter);
        }
    
        [DbFunction("WSEntities", "GetSpeech")]
        public virtual IQueryable<Speech> GetSpeech(Nullable<System.Guid> speechId, Nullable<System.Guid> userId)
        {
            var speechIdParameter = speechId.HasValue ?
                new ObjectParameter("SpeechId", speechId) :
                new ObjectParameter("SpeechId", typeof(System.Guid));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Speech>("[WSEntities].[GetSpeech](@SpeechId, @UserId)", speechIdParameter, userIdParameter);
        }
    
        [DbFunction("WSEntities", "GetGroups")]
        public virtual IQueryable<Group> GetGroups(Nullable<System.Guid> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Group>("[WSEntities].[GetGroups](@UserId)", userIdParameter);
        }
    }
}
