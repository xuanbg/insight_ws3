using System;

namespace Insight.WS.Test.Interface.Entity
{
    public class MDE_Favorites
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public int Type { get; set; }
    	
        public Guid ObjectId { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
