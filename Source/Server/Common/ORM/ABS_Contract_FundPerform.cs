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
    
    public partial class ABS_Contract_FundPerform
    {
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid PlanId { get; set; }
        public Nullable<System.Guid> ClearingId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime CreateTime { get; set; }
    
        public virtual ABS_Clearing ABS_Clearing { get; set; }
        public virtual ABS_Contract_FundPlan ABS_Contract_FundPlan { get; set; }
    }
}
