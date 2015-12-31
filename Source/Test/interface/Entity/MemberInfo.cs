using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class MemberInfo
    {
    	
        public Guid ID { get; set; }
    	
        public string Name { get; set; }
    	
        public string Alias { get; set; }
    	
        public string Portrait { get; set; }
    	
        public int Integral { get; set; }
    	
        public int Beans { get; set; }
    	
        public int? Unread { get; set; }
    	
        public string Signature { get; set; }
    }
}
