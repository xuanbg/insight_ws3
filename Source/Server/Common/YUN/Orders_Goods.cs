//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Server.Common.YUN
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    
    public partial class Orders_Goods
    {
    	[DataMember]
        public int Orders_Goods_ID { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Type { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_ParentID { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_OrdersID { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_ID { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_SupplierID { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Code { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_CateID { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_BrandID { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Name { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Img { get; set; }
    	[DataMember]
        public Nullable<decimal> Orders_Goods_Product_Price { get; set; }
    	[DataMember]
        public Nullable<decimal> Orders_Goods_Product_MKTPrice { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Maker { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Spec { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_AuthorizeCode { get; set; }
    	[DataMember]
        public Nullable<decimal> Orders_Goods_Product_brokerage { get; set; }
    	[DataMember]
        public Nullable<decimal> Orders_Goods_Product_SalePrice { get; set; }
    	[DataMember]
        public Nullable<decimal> Orders_Goods_Product_PurchasingPrice { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_Coin { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_IsFavor { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_UseCoin { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Amount { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_DeliveryStatus { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_IsSettle { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_DeliveryID { get; set; }
    	[DataMember]
        public string Orders_Goods_Note { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_ReceivedReturn { get; set; }
    	[DataMember]
        public string Orders_Goods_RefundReason { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Specification { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Color { get; set; }
    	[DataMember]
        public Nullable<double> Orders_Goods_Product_Rate { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Cate { get; set; }
    	[DataMember]
        public Nullable<int> Orders_Goods_Product_Issubstitute { get; set; }
    	[DataMember]
        public string Orders_Goods_Product_Provider { get; set; }
    }
}
