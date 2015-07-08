//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Service.XinFenBao
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    
    public partial class t_bill_stage
    {
    	[DataMember]
        public int id { get; set; }
    	[DataMember]
        public string bill_no { get; set; }
    	[DataMember]
        public Nullable<int> order_id { get; set; }
    	[DataMember]
        public Nullable<float> stage_amount { get; set; }
    	[DataMember]
        public Nullable<float> base_amount { get; set; }
    	[DataMember]
        public Nullable<float> charge_amount { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> latest_repay { get; set; }
    	[DataMember]
        public Nullable<int> overdue_day { get; set; }
    	[DataMember]
        public Nullable<float> repay_amount { get; set; }
    	[DataMember]
        public Nullable<int> bill_status { get; set; }
    	[DataMember]
        public string description { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> create_time { get; set; }
    	[DataMember]
        public Nullable<float> overdue_fine { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> actual_repay { get; set; }
    	[DataMember]
        public Nullable<int> repay_channel { get; set; }
    	[DataMember]
        public Nullable<int> delete_flag { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> return_time { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> refund_time { get; set; }
    	[DataMember]
        public Nullable<int> update_userid { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> update_time { get; set; }
    }
}
