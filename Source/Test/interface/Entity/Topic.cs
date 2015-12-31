using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class Topic
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? CaseId { get; set; }
        public bool Private { get; set; }
        public DateTime? PublishTime { get; set; }
        public bool? IsCare { get; set; }
        public bool? IsSpeeched { get; set; }
    }
}
