//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ABS_Advance_Record
    {
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid DetailId { get; set; }
        public decimal Amount { get; set; }
        public System.Guid ClearingId { get; set; }
    
        public virtual ABS_Advance_Detail ABS_Advance_Detail { get; set; }
        public virtual ABS_Clearing ABS_Clearing { get; set; }
    }
}