using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class MDE_Message
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid ReceiveUserId { get; set; }
    	
        public string Content { get; set; }
    	
        public DateTime? SendTime { get; set; }
    	
        public bool HaveRead { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
