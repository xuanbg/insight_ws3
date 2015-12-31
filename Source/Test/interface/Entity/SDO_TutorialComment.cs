using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDO_TutorialComment
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid TutorialId { get; set; }
    	
        public string Content { get; set; }
    	
        public DateTime? PublishTime { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    	
        public bool Validity { get; set; }
    
    }
}
