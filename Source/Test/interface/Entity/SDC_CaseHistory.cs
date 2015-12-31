using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDC_CaseHistory
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public string PatientName { get; set; }
    	
        public int Gender { get; set; }
    	
        public DateTime? Birthday { get; set; }
    	
        public string Phone { get; set; }
    	
        public string WeChat { get; set; }
    	
        public string OpenId { get; set; }
    	
        public int Secret { get; set; }
    	
        public string Description { get; set; }
    	
        public DateTime UpdateTime { get; set; }
    	
        public bool Validity { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
