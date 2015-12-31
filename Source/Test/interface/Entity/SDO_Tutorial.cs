using System;

namespace Insight.WS.Test.Interface.Entity
{

    public class SDO_Tutorial
    {
    	
        public Guid ID { get; set; }
    	
        public long SN { get; set; }
    	
        public string Title { get; set; }
    	
        public string Description { get; set; }
    	
        public string Picture { get; set; }
    	
        public string Url { get; set; }
    	
        public bool Validity { get; set; }
    	
        public Guid CreatorUserId { get; set; }
    	
        public DateTime CreateTime { get; set; }
    
    }
}
