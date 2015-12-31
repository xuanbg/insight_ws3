using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class Topics
    {
    	
        public Guid ID { get; set; }
    	
        public Guid? GroupId { get; set; }
    	
        public Guid TopicId { get; set; }
    	
        public bool Private { get; set; }
    	
        public string Title { get; set; }
    	
        public Guid? SpeechId { get; set; }
    	
        public string Content { get; set; }
    	
        public Guid? MemberId { get; set; }
    	
        public string Portrait { get; set; }
    	
        public int? Agrees { get; set; }
    	
        public DateTime? PublishTime { get; set; }
    }
}
