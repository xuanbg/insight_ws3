using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDT_Forward
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid TopicId { get; set; }
    	
        public Guid GroupId { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
