//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.ORM
{
    using System;
    
    public partial class GetSpeech_Result
    {
        public System.Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<System.Guid> CaseId { get; set; }
        public System.Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public string Portrait { get; set; }
        public int Agrees { get; set; }
        public int Opposes { get; set; }
        public int Praises { get; set; }
        public int Comments { get; set; }
        public bool IsAgrees { get; set; }
        public bool IsOppose { get; set; }
        public bool IsPraise { get; set; }
        public bool IsReport { get; set; }
        public Nullable<bool> IsCare { get; set; }
        public Nullable<System.DateTime> PublishTime { get; set; }
    }
}