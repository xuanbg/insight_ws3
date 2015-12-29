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
    [KnownType(typeof(MasterData))]
    [KnownType(typeof(SDC_CaseHistory))]
    [KnownType(typeof(SYS_User))]
    [KnownType(typeof(SDC_Subsequent))]
    [KnownType(typeof(SDC_Summary))]
    [KnownType(typeof(SDT_Topic))]
    
    public partial class SDC_FirstVisit
    {
        public SDC_FirstVisit()
        {
            this.SDC_Subsequent = new HashSet<SDC_Subsequent>();
            this.SDC_Summary = new HashSet<SDC_Summary>();
            this.SDT_Topic = new HashSet<SDT_Topic>();
        }
    
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public long SN { get; set; }
    	[DataMember]
        public System.Guid CaseHistoryId { get; set; }
    	[DataMember]
        public string Complained { get; set; }
    	[DataMember]
        public string MedicalHistory { get; set; }
    	[DataMember]
        public string Previous { get; set; }
    	[DataMember]
        public string Inspection { get; set; }
    	[DataMember]
        public string UpperJaw { get; set; }
    	[DataMember]
        public string LowerJaw { get; set; }
    	[DataMember]
        public string Diagnosis { get; set; }
    	[DataMember]
        public string TherapyPlan { get; set; }
    	[DataMember]
        public string Therapy { get; set; }
    	[DataMember]
        public string Notify { get; set; }
    	[DataMember]
        public string KeyWord { get; set; }
    	[DataMember]
        public string Description { get; set; }
    	[DataMember]
        public Nullable<System.Guid> DoctorId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> NurseId { get; set; }
    	[DataMember]
        public System.Guid CreatorUserId { get; set; }
    	[DataMember]
        public System.DateTime CreateTime { get; set; }
    
    	[DataMember]
        public virtual MasterData MasterData { get; set; }
    	[DataMember]
        public virtual MasterData MasterData1 { get; set; }
    	[DataMember]
        public virtual SDC_CaseHistory SDC_CaseHistory { get; set; }
    	[DataMember]
        public virtual SYS_User SYS_User { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_Subsequent> SDC_Subsequent { get; set; }
    	[DataMember]
        public virtual ICollection<SDC_Summary> SDC_Summary { get; set; }
    	[DataMember]
        public virtual ICollection<SDT_Topic> SDT_Topic { get; set; }
    }
}
