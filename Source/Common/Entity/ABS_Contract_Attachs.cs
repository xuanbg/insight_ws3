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
    
    public partial class ABS_Contract_Attachs
    {
        public System.Guid ID { get; set; }
        public long SN { get; set; }
        public System.Guid ContractId { get; set; }
        public System.Guid ImageId { get; set; }
    
        public virtual ABS_Contract ABS_Contract { get; set; }
        public virtual ImageData ImageData { get; set; }
    }
}