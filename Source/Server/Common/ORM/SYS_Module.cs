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
    [KnownType(typeof(BASE_Category))]
    [KnownType(typeof(MasterData_Property))]
    [KnownType(typeof(SYS_Allot_Record))]
    [KnownType(typeof(SYS_Code_Allot))]
    [KnownType(typeof(SYS_ModuleGroup))]
    [KnownType(typeof(SYS_ModuleAction))]
    [KnownType(typeof(SYS_ModuleParam))]
    [KnownType(typeof(SYS_RolePerm_Data))]
    [KnownType(typeof(SYS_RolePerm_DataAbs))]
    
    public partial class SYS_Module
    {
        public SYS_Module()
        {
            this.BASE_Category = new HashSet<BASE_Category>();
            this.MasterData_Property = new HashSet<MasterData_Property>();
            this.SYS_Allot_Record = new HashSet<SYS_Allot_Record>();
            this.SYS_Code_Allot = new HashSet<SYS_Code_Allot>();
            this.SYS_ModuleAction = new HashSet<SYS_ModuleAction>();
            this.SYS_ModuleParam = new HashSet<SYS_ModuleParam>();
            this.SYS_RolePerm_Data = new HashSet<SYS_RolePerm_Data>();
            this.SYS_RolePerm_DataAbs = new HashSet<SYS_RolePerm_DataAbs>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ModuleGroupId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> ParentId { get; set; }
    	[DataMember]
        public int Level { get; set; }
    	[DataMember]
        public int Type { get; set; }
    	[DataMember]
        public Nullable<int> Index { get; set; }
    	[DataMember]
        public string Name { get; set; }
    	[DataMember]
        public string ProgramName { get; set; }
    	[DataMember]
        public string MainFrom { get; set; }
    	[DataMember]
        public string ApplicationName { get; set; }
    	[DataMember]
        public string Location { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> RegisterTime { get; set; }
    	[DataMember]
        public bool Default { get; set; }
    	[DataMember]
        public bool Validity { get; set; }
    	[DataMember]
        public byte[] Icon { get; set; }
    
    	[DataMember]
        public virtual ICollection<BASE_Category> BASE_Category { get; set; }
    	[DataMember]
        public virtual ICollection<MasterData_Property> MasterData_Property { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Allot_Record> SYS_Allot_Record { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_Code_Allot> SYS_Code_Allot { get; set; }
    	[DataMember]
        public virtual SYS_ModuleGroup SYS_ModuleGroup { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_ModuleAction> SYS_ModuleAction { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_ModuleParam> SYS_ModuleParam { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_Data> SYS_RolePerm_Data { get; set; }
    	[DataMember]
        public virtual ICollection<SYS_RolePerm_DataAbs> SYS_RolePerm_DataAbs { get; set; }
    }
}
