using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDC_FirstVisit
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid CaseHistoryId { get; set; }
    	
        public string Complained { get; set; }
    	
        public string MedicalHistory { get; set; }
    	
        public string Previous { get; set; }
    	
        public string Inspection { get; set; }
    	
        public string UpperJaw { get; set; }
    	
        public string LowerJaw { get; set; }
    	
        public string Diagnosis { get; set; }
    	
        public string TherapyPlan { get; set; }
    	
        public string Therapy { get; set; }
    	
        public string Notify { get; set; }
    	
        public string KeyWord { get; set; }
    	
        public string Description { get; set; }
    	
        public Guid? DoctorId { get; set; }
    	
        public Guid? NurseId { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
