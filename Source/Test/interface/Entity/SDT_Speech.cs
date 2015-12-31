using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDT_Speech
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid TopicId { get; set; }
    	
        public string Content { get; set; }
    	
        public Guid? CaseId { get; set; }
    	
        public bool Recommend { get; set; }
    	
        public bool Validity { get; set; }
    	
        public DateTime? PublishTime { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
