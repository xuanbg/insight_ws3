using System;

namespace Insight.WS.Test.Interface.Entity
{
    public class SDT_Topic
    {
        
        public Guid ID { get; set; }
        
        public long SN { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Tags { get; set; }
        
        public Guid? CaseId { get; set; }
        
        public bool Private { get; set; }
        
        public bool Validity { get; set; }

        public DateTime? PublishTime { get; set; }
        
        public Guid CreatorUserId { get; set; }
        
        public DateTime CreateTime { get; set; }

    }
}
