﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class xfbEntities : DbContext
    {
    	public xfbEntities()
            : this(false) { }
    
        public xfbEntities(bool proxyCreationEnabled)
            : base("name=xfbEntities")
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    	
        public xfbEntities(string connectionString)
          : this(connectionString, false) { }
    	  
        public xfbEntities(string connectionString, bool proxyCreationEnabled)
            : base(connectionString)
        {
    		        this.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }	
    	
        public ObjectContext ObjectContext
        {
          get { return ((IObjectContextAdapter)this).ObjectContext; }
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_bill_stage> t_bill_stage { get; set; }
        public virtual DbSet<t_order_info> t_order_info { get; set; }
        public virtual DbSet<t_sys_user> t_sys_user { get; set; }
    }
}
