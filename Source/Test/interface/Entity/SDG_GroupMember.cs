using System;

namespace Insight.WS.Test.Interface.Entity
{
    public class SDG_GroupMember
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public Guid GroupId { get; set; }
    	
        public Guid MemberId { get; set; }
    	
        public bool Validity { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
