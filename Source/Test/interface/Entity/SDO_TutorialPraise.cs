using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDO_TutorialPraise
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid TutorialId { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
