using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class SDG_Group
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public string Name { get; set; }
    	
        public string Description { get; set; }
    	
        public string Icon { get; set; }
    	
        public string Picture { get; set; }
    	
        public int Heat { get; set; }
    	
        public int Topics { get; set; }
    	
        public int Members { get; set; }
    	
        public Guid OwnerUserId { get; set; }
    	
        public Guid? ManageUserId { get; set; }
    	
        public bool Validity { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
