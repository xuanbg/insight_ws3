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
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    
    public partial class ReportSchedular
    {
    	[DataMember]
        public System.Guid ID { get; set; }
    	[DataMember]
        public System.Guid SchedularId { get; set; }
    	[DataMember]
        public System.Guid ReportId { get; set; }
    	[DataMember]
        public System.Guid TemplateId { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> BuildTime { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> NextDate { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> StartDate { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> EndDate { get; set; }
    	[DataMember]
        public string DeptName { get; set; }
    	[DataMember]
        public System.Guid DeptId { get; set; }
    	[DataMember]
        public Nullable<System.Guid> UserId { get; set; }
    }
}