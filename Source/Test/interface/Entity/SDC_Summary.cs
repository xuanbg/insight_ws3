using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDC_Summary
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid? CaseId { get; set; }
    	
        public string Content { get; set; }
    	
        public string KeyWord { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
