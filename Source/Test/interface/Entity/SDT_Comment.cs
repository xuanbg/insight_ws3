using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDT_Comment
    {
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public string Content { get; set; }
    	
        public DateTime? PublishTime { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    	
        public Guid SpeechId { get; set; }
    	
        public bool Validity { get; set; }
    
    }
}
