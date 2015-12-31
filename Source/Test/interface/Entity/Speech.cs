using System;

namespace Insight.WS.Test.Interface.Entity
{
    public class Speech
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? CaseId { get; set; }
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public string Portrait { get; set; }
        public int Agrees { get; set; }
        public int Comments { get; set; }
        public bool IsAgrees { get; set; }
        public bool IsOppose { get; set; }
        public bool IsPraise { get; set; }
        public bool IsReport { get; set; }
        public bool? IsCare { get; set; }
        public DateTime? PublishTime { get; set; }
        public int Opposes { get; set; }
        public int Praises { get; set; }
    }
}
