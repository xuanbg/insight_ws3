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
    
    public partial class t_sys_user
    {
    	[DataMember]
        public int id { get; set; }
    	[DataMember]
        public string login_name { get; set; }
    	[DataMember]
        public string real_name { get; set; }
    	[DataMember]
        public string pass_word { get; set; }
    	[DataMember]
        public Nullable<int> status { get; set; }
    	[DataMember]
        public string my_code { get; set; }
    	[DataMember]
        public string recom_code { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> create_time { get; set; }
    	[DataMember]
        public Nullable<int> create_userid { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> update_time { get; set; }
    	[DataMember]
        public Nullable<int> update_userid { get; set; }
    	[DataMember]
        public string description { get; set; }
    	[DataMember]
        public int recom_num { get; set; }
    	[DataMember]
        public System.Guid uid { get; set; }
    }
}
