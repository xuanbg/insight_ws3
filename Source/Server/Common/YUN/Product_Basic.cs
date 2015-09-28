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
    
    public partial class Product_Basic
    {
    	[DataMember]
        public int Product_ID { get; set; }
    	[DataMember]
        public string Product_Code { get; set; }
    	[DataMember]
        public Nullable<int> Product_CateID { get; set; }
    	[DataMember]
        public Nullable<int> Product_BrandID { get; set; }
    	[DataMember]
        public Nullable<int> Product_TypeID { get; set; }
    	[DataMember]
        public Nullable<int> Product_SupplierID { get; set; }
    	[DataMember]
        public Nullable<int> Product_Supplier_CommissionCateID { get; set; }
    	[DataMember]
        public string Product_Name { get; set; }
    	[DataMember]
        public string Product_NameInitials { get; set; }
    	[DataMember]
        public string Product_SubName { get; set; }
    	[DataMember]
        public string Product_SubNameInitials { get; set; }
    	[DataMember]
        public Nullable<decimal> Product_MKTPrice { get; set; }
    	[DataMember]
        public Nullable<decimal> Product_GroupPrice { get; set; }
    	[DataMember]
        public Nullable<decimal> Product_PurchasingPrice { get; set; }
    	[DataMember]
        public Nullable<decimal> Product_Price { get; set; }
    	[DataMember]
        public string Product_PriceUnit { get; set; }
    	[DataMember]
        public string Product_Unit { get; set; }
    	[DataMember]
        public Nullable<int> Product_GroupNum { get; set; }
    	[DataMember]
        public string Product_Note { get; set; }
    	[DataMember]
        public string Product_NoteColor { get; set; }
    	[DataMember]
        public string Product_Audit_Note { get; set; }
    	[DataMember]
        public Nullable<double> Product_Weight { get; set; }
    	[DataMember]
        public string Product_Img { get; set; }
    	[DataMember]
        public string Product_Publisher { get; set; }
    	[DataMember]
        public Nullable<int> Product_StockAmount { get; set; }
    	[DataMember]
        public Nullable<int> Product_SaleAmount { get; set; }
    	[DataMember]
        public Nullable<int> Product_Review_Count { get; set; }
    	[DataMember]
        public Nullable<int> Product_Review_ValidCount { get; set; }
    	[DataMember]
        public Nullable<double> Product_Review_Average { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsInsale { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsGroupBuy { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsCoinBuy { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsFavor { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsGift { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsGiftCoin { get; set; }
    	[DataMember]
        public Nullable<double> Product_Gift_Coin { get; set; }
    	[DataMember]
        public Nullable<int> Product_CoinBuy_Coin { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsAudit { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> Product_Addtime { get; set; }
    	[DataMember]
        public string Product_Intro { get; set; }
    	[DataMember]
        public string Product_Parameter { get; set; }
    	[DataMember]
        public string Product_Intro_Extend1 { get; set; }
    	[DataMember]
        public string Product_Intro_Extend2 { get; set; }
    	[DataMember]
        public string Product_DetailTag_1 { get; set; }
    	[DataMember]
        public string Product_DetailTag_2 { get; set; }
    	[DataMember]
        public string Product_DetailTag_3 { get; set; }
    	[DataMember]
        public string Product_DetailTag_4 { get; set; }
    	[DataMember]
        public string Product_Trace_Intro { get; set; }
    	[DataMember]
        public Nullable<int> Product_AlertAmount { get; set; }
    	[DataMember]
        public Nullable<int> Product_UsableAmount { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsNoStock { get; set; }
    	[DataMember]
        public string Product_Spec { get; set; }
    	[DataMember]
        public string Product_Maker { get; set; }
    	[DataMember]
        public Nullable<int> Product_Sort { get; set; }
    	[DataMember]
        public Nullable<int> Product_QuotaAmount { get; set; }
    	[DataMember]
        public Nullable<int> Product_IsListShow { get; set; }
    	[DataMember]
        public string Product_GroupCode { get; set; }
    	[DataMember]
        public Nullable<int> Product_Hits { get; set; }
    	[DataMember]
        public string Product_Site { get; set; }
    	[DataMember]
        public string Product_SEO_Title { get; set; }
    	[DataMember]
        public string Product_SEO_Keyword { get; set; }
    	[DataMember]
        public string Product_SEO_Description { get; set; }
    	[DataMember]
        public string Product_Trace_Code { get; set; }
    	[DataMember]
        public Nullable<int> Product_PromotionTagID { get; set; }
    	[DataMember]
        public Nullable<System.DateTime> Product_LastEditTime { get; set; }
    	[DataMember]
        public Nullable<double> Product_CommissionRate { get; set; }
    	[DataMember]
        public Nullable<int> Product_SyncBasic { get; set; }
    	[DataMember]
        public Nullable<int> Product_Type { get; set; }
    	[DataMember]
        public Nullable<int> Product_AllowBuy { get; set; }
    	[DataMember]
        public string Product_Address_State { get; set; }
    	[DataMember]
        public string Product_Address_City { get; set; }
    	[DataMember]
        public string Product_Address_County { get; set; }
    	[DataMember]
        public string Product_Commodity_Code { get; set; }
    	[DataMember]
        public Nullable<int> Product_BelongsBank { get; set; }
    	[DataMember]
        public string Product_ERPCode { get; set; }
    	[DataMember]
        public string Product_ERPSKU1 { get; set; }
    	[DataMember]
        public string Product_ERPSKU2 { get; set; }
    }
}
