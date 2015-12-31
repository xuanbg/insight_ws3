using System;

namespace Insight.WS.Test.Interface.Entity
{    
    public class SDT_Praise
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid CommentId { get; set; }
    	
        public int Type { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    	
        public string Description { get; set; }
    
    }
}
