//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.XFB
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    [KnownType(typeof(t_category_info))]
    [KnownType(typeof(t_sys_user))]
    
    public partial class t_model_info
    {
    	[DataMember]
        public int id { get; set; }
    	[DataMember]
        public Nullable<int> category_id { get; set; }
    	[DataMember]
        public string code { get; set; }
    	[DataMember]
        public string name { get; set; }
    	[DataMember]
        public Nullable<int> score { get; set; }
    	[DataMember]
        public string flag { get; set; }
    	[DataMember]
        public Nullable<int> create_userid { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> create_time { get; set; }
    	[DataMember]
        public string remarks { get; set; }
    	[DataMember]
        public Nullable<int> min_limit { get; set; }
    	[DataMember]
        public Nullable<int> max_limit { get; set; }
    
    	[DataMember]
        public virtual t_category_info t_category_info { get; set; }
    	[DataMember]
        public virtual t_sys_user t_sys_user { get; set; }
    }
}
