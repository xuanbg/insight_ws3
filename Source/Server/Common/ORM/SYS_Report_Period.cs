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
    using System.Collections.Generic;
    
    public partial class SYS_Report_Period
    {
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid ReportId { get; set; }
        public System.Guid RuleId { get; set; }
    
        public virtual SYS_Report_Definition SYS_Report_Definition { get; set; }
        public virtual SYS_Report_Rules SYS_Report_Rules { get; set; }
    }
}
