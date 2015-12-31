using System;

namespace Insight.WS.Test.Interface.Entity
{
    
    public class Comments
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Portrait { get; set; }
        public int Praise { get; set; }
        public bool IsPraise { get; set; }
        public bool IsReport { get; set; }
        public DateTime? PublishTime { get; set; }
    }
}
