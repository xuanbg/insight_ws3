

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Library', @level2type=N'COLUMN',@level2name=N'Product_AllowBuy'

GO

ALTER TABLE [dbo].[Orders_BackApply] DROP CONSTRAINT [DF_Orders_BackApply_Orders_BackApply_SupplierID]
GO

/****** Object:  Table [dbo].[BankProductMap]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[BankProductMap]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders]
GO

/****** Object:  Table [dbo].[Orders_BackApply]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_BackApply]
GO

/****** Object:  Table [dbo].[Orders_Coupon]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Coupon]
GO

/****** Object:  Table [dbo].[Orders_Delivery]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Delivery]
GO

/****** Object:  Table [dbo].[Orders_FavorPolicy]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_FavorPolicy]
GO

/****** Object:  Table [dbo].[Orders_Goods]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Goods]
GO

/****** Object:  Table [dbo].[Orders_Goods_tmp]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Goods_tmp]
GO

/****** Object:  Table [dbo].[Orders_Invoice]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Invoice]
GO

/****** Object:  Table [dbo].[Orders_Log]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Log]
GO

/****** Object:  Table [dbo].[Orders_Payment]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Payment]
GO

/****** Object:  Table [dbo].[Orders_Settle]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Orders_Settle]
GO

/****** Object:  Table [dbo].[Original_Orders]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Original_Orders]
GO

/****** Object:  Table [dbo].[Original_Orders_Goods]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Original_Orders_Goods]
GO

/****** Object:  Table [dbo].[Original_Orders_Invoice]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Original_Orders_Invoice]
GO

/****** Object:  Table [dbo].[Product_Library_Img]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Product_Library_Img]
GO

/****** Object:  Table [dbo].[Product_Library_Extend]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Product_Library_Extend]
GO

/****** Object:  Table [dbo].[Product_Library]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Product_Library]
GO

/****** Object:  Table [dbo].[Warehouse_Record]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Warehouse_Record]
GO

/****** Object:  Table [dbo].[WareHouse_Product]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[WareHouse_Product]
GO

/****** Object:  Table [dbo].[Transaction_Bill]    Script Date: 2015/3/20 15:35:23 ******/
DROP TABLE [dbo].[Transaction_Bill]
GO

--delete AD
--dbcc checkident(AD, reseed, 0) 

delete Bank
dbcc checkident(Bank, reseed, 0) 

delete BasicCategory
dbcc checkident(BasicCategory, reseed, 0) 

delete Category
dbcc checkident(Category, reseed, 0) 

delete Feedback
dbcc checkident(Feedback, reseed, 0) 


delete Member
dbcc checkident(Member, reseed, 0) 

delete Member_Account_Log
dbcc checkident(Member_Account_Log, reseed, 0) 

delete Member_Account_Orders
dbcc checkident(Member_Account_Orders, reseed, 0) 

delete Member_Address
dbcc checkident(Member_Address, reseed, 0) 

delete Member_Consumption
dbcc checkident(Member_Consumption, reseed, 0) 

delete Member_Favorites
dbcc checkident(Member_Favorites, reseed, 0) 

delete Member_Grade
dbcc checkident(Member_Grade, reseed, 0) 

delete Member_Log
dbcc checkident(Member_Log, reseed, 0) 

delete Member_Pay_Log
dbcc checkident(Member_Pay_Log, reseed, 0) 

delete Member_Profile
dbcc checkident(Member_Profile, reseed, 0) 

delete MobileNumber
dbcc checkident(MobileNumber, reseed, 0) 

delete MobileNumberGrade
dbcc checkident(MobileNumberGrade, reseed, 0) 


delete Product_Basic
dbcc checkident(Product_Basic, reseed, 0) 

delete Product_Booking
dbcc checkident(Product_Booking, reseed, 0) 

delete Product_Category
dbcc checkident(Product_Category, reseed, 0) 

delete Product_Extend
dbcc checkident(Product_Extend, reseed, 0) 

delete Product_Img
dbcc checkident(Product_Img, reseed, 0) 

delete Product_RelateTag
dbcc checkident(Product_RelateTag, reseed, 0) 

delete Product_Tag
dbcc checkident(Product_Tag, reseed, 0) 

delete Product_Tag_Category
dbcc checkident(Product_Tag_Category, reseed, 0) 

delete ProductType
dbcc checkident(ProductType, reseed, 0) 

delete ProductType_Brand
dbcc checkident(ProductType_Brand, reseed, 0) 

delete ProductType_Extend
dbcc checkident(ProductType_Extend, reseed, 0) 

delete Promotion
dbcc checkident(Promotion, reseed, 0) 

delete RBAC_User
dbcc checkident(RBAC_User, reseed, 0) 
INSERT [dbo].[RBAC_User] ([RBAC_User_GroupID], [RBAC_User_Name], [RBAC_User_Password], [RBAC_User_LastLogin], [RBAC_User_LastLoginIP], [RBAC_User_Addtime], [RBAC_User_Site], [RBAC_User_Type], [RBAC_User_Subjection]) VALUES (0, N'admin', N'0ab44bd43d6b18fcd5cd928d6faab1b8', CAST(N'2015-08-10 16:44:29.773' AS DateTime), N'192.168.30.56', CAST(N'2015-04-02 14:33:31.693' AS DateTime), N'CN', 0, 0)

delete RBAC_UserRole
dbcc checkident(RBAC_UserRole, reseed, 0) 
INSERT INTO [dbo].[RBAC_UserRole] ([RBAC_UserRole_UserID], [RBAC_UserRole_RoleID]) VALUES (1, 1)

delete RBAC_User_Log
dbcc checkident(RBAC_User_Log, reseed, 0) 

delete Sys_Error
dbcc checkident(Sys_Error, reseed, 0) 

delete Supplier
dbcc checkident(Supplier, reseed, 0) 

delete Supplier_Address
dbcc checkident(Supplier_Address, reseed, 0) 

delete SupplierSignin
dbcc checkident(SupplierSignin, reseed, 0) 

delete SupplierSigninApply
dbcc checkident(SupplierSigninApply, reseed, 0) 

/****** Object:  Table [dbo].[Transaction_Bill]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction_Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionNo] [nvarchar](20) NULL,
	[OrdersNo] [nvarchar](20) NULL,
	[TransactionStatus] [int] NULL,
	[TransactionTime] [datetime] NULL,
	[Site] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transaction_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[WareHouse_Product]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WareHouse_Product](
	[WareHouse_Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[WareHouse_Product_ProductCode] [nvarchar](50) NULL,
	[WareHouse_Product_ProductID] [int] NULL,
	[WareHouse_Product_WarehouseCode] [nvarchar](50) NULL,
	[WareHouse_Product_Stock] [int] NULL,
 CONSTRAINT [PK_WareHouse_Product] PRIMARY KEY CLUSTERED 
(
	[WareHouse_Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Warehouse_Record]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Warehouse_Record](
	[Warehouse_Record_ID] [int] IDENTITY(1,1) NOT NULL,
	[Warehouse_Record_WarehousCode] [nvarchar](50) NULL,
	[Warehouse_Record_ProductCode] [nvarchar](50) NULL,
	[Warehouse_Record_Amount] [int] NULL,
	[Warehouse_Record_OrderID] [int] NULL,
	[Warehouse_Record_SupplierID] [int] NULL,
	[Warehouse_Record_IsDiscard] [int] NULL,
 CONSTRAINT [PK_Warehouse_Record] PRIMARY KEY CLUSTERED 
(
	[Warehouse_Record_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Product_Library]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Library](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Code] [nvarchar](50) NULL,
	[Product_CateID] [int] NULL,
	[Product_BrandID] [int] NULL,
	[Product_TypeID] [int] NULL CONSTRAINT [DF_BasicProduct_Product_TypeID]  DEFAULT ((0)),
	[Product_SupplierID] [int] NULL,
	[Product_Name] [nvarchar](100) NULL,
	[Product_NameInitials] [nvarchar](100) NULL,
	[Product_SubName] [nvarchar](100) NULL,
	[Product_SubNameInitials] [nvarchar](100) NULL,
	[Product_MKTPrice] [money] NULL,
	[Product_GroupPrice] [money] NULL,
	[Product_PurchasingPrice] [money] NULL,
	[Product_Price] [money] NULL,
	[Product_PriceUnit] [nvarchar](10) NULL,
	[Product_Unit] [nvarchar](50) NULL,
	[Product_GroupNum] [int] NULL,
	[Product_Note] [nvarchar](100) NULL,
	[Product_NoteColor] [nvarchar](8) NULL,
	[Product_Audit_Note] [nvarchar](200) NULL,
	[Product_Weight] [float] NULL CONSTRAINT [DF_BasicProduct_Product_Weight]  DEFAULT ((0)),
	[Product_Img] [nvarchar](100) NULL,
	[Product_Publisher] [nvarchar](50) NULL,
	[Product_UsableAmount] [int] NULL CONSTRAINT [DF_BasicProduct_Product_UsableAmount]  DEFAULT ((0)),
	[Product_StockAmount] [int] NULL CONSTRAINT [DF_BasicProduct_Product_StockAmount]  DEFAULT ((0)),
	[Product_BorrowAmount] [int] NULL,
	[Product_SaleAmount] [int] NULL CONSTRAINT [DF_BasicProduct_Product_SaleAmount]  DEFAULT ((0)),
	[Product_AlertAmount] [int] NULL CONSTRAINT [DF_BasicProduct_Product_AlertAmount]  DEFAULT ((0)),
	[Product_IsNoStock] [int] NULL CONSTRAINT [DF_BasicProduct_Product_IsNoStock]  DEFAULT ((0)),
	[Product_IsInsale] [int] NULL CONSTRAINT [DF_BasicProduct_Product_IsInsale]  DEFAULT ((1)),
	[Product_IsAudit] [int] NULL CONSTRAINT [DF_BasicProduct_Product_IsAudit]  DEFAULT ((0)),
	[Product_Addtime] [datetime] NULL CONSTRAINT [DF_BasicProduct_Product_Addtime]  DEFAULT (getdate()),
	[Product_Intro] [nvarchar](max) NULL,
	[Product_Parameter] [nvarchar](max) NULL,
	[Product_Intro_Extend1] [nvarchar](max) NULL,
	[Product_Intro_Extend2] [nvarchar](max) NULL,
	[Product_DetailTag_1] [nvarchar](50) NULL,
	[Product_DetailTag_2] [nvarchar](50) NULL,
	[Product_DetailTag_3] [nvarchar](50) NULL,
	[Product_DetailTag_4] [nvarchar](50) NULL,
	[Product_Spec] [nvarchar](100) NULL,
	[Product_Maker] [nvarchar](200) NULL,
	[Product_IsListShow] [int] NULL,
	[Product_GroupCode] [nvarchar](50) NULL,
	[Product_Site] [nvarchar](50) NULL CONSTRAINT [DF_BasicProduct_Product_Site]  DEFAULT (N'CN'),
	[Product_SEO_Title] [nvarchar](200) NULL,
	[Product_SEO_Keyword] [nvarchar](200) NULL,
	[Product_SEO_Description] [nvarchar](500) NULL,
	[Product_LastEditTime] [datetime] NULL,
	[Product_Type] [int] NULL,
	[Product_AllowBuy] [int] NULL CONSTRAINT [DF_Product_Library_Product_AllowBuy]  DEFAULT ((0)),
	[Product_Address_State] [nvarchar](10) NULL,
	[Product_Address_City] [nvarchar](10) NULL,
	[Product_Address_County] [nvarchar](10) NULL,
	[Product_IsCoinBuy] [int] NULL CONSTRAINT [DF_Product_Library_Product_IsCoinBuy]  DEFAULT ((0)),
	[Product_CoinBuy_Coin] [int] NULL CONSTRAINT [DF_Product_Library_Product_CoinBuy_Coin]  DEFAULT ((0)),
	[Product_ERPCode] [nvarchar](50) NULL,
	[Product_ERPSKU1] [nvarchar](50) NULL,
	[Product_ERPSKU2] [nvarchar](50) NULL,
	[Product_Clerk] [nvarchar](50) NULL,
	[Product_TypeOption] [int] NULL,
	[Product_StoreroomNo] [nvarchar](50) NULL CONSTRAINT [DF_Product_Library_Product_StoreroomNo]  DEFAULT (N''),
	[Product_Issubstitute] [int] NULL CONSTRAINT [DF_Product_Library_Product_Issubstitute]  DEFAULT ((0)),
	[Product_Provider] [nvarchar](50) NULL,
	[Product_Tax_Rate] [float] NULL CONSTRAINT [DF_Product_Library_Product_Tax_Rate]  DEFAULT ((0)),
	[Product_Business_Cate] [nvarchar](150) NULL CONSTRAINT [DF_Product_Library_Product_Business_Cate]  DEFAULT (N''),
 CONSTRAINT [PK_Product_Library] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Product_Library_Extend]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Library_Extend](
	[Product_Extend_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Extend_ProductID] [int] NULL,
	[Product_Extend_ExtendID] [int] NULL,
	[Product_Extend_Value] [nvarchar](1000) NULL,
	[Product_Extend_Img] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product_Library_Extend] PRIMARY KEY CLUSTERED 
(
	[Product_Extend_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Product_Library_Img]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Library_Img](
	[Product_Img_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Img_ProductID] [int] NULL,
	[Product_Img_Path] [nvarchar](100) NULL,
 CONSTRAINT [PK_Product_Library_Img] PRIMARY KEY CLUSTERED 
(
	[Product_Img_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Original_Orders_Invoice]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Original_Orders_Invoice](
	[Invoice_ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_OrdersID] [int] NULL CONSTRAINT [DF_Original_Order_invoice_invoice_order_id]  DEFAULT ((0)),
	[Invoice_Type] [int] NULL CONSTRAINT [DF_Original_Order_invoice_invoice_type]  DEFAULT ((0)),
	[Invoice_Title] [nvarchar](100) NULL CONSTRAINT [DF_Original_Order_invoice_invoice_title]  DEFAULT ((0)),
	[Invoice_Content] [int] NULL CONSTRAINT [DF_Original_Order_invoice_invoice_content]  DEFAULT ((0)),
	[Invoice_FirmName] [nvarchar](100) NULL,
	[Invoice_VAT_FirmName] [nvarchar](100) NULL,
	[Invoice_VAT_Code] [nvarchar](50) NULL,
	[Invoice_VAT_RegAddr] [nvarchar](100) NULL,
	[Invoice_VAT_RegTel] [nvarchar](50) NULL,
	[Invoice_VAT_Bank] [nvarchar](50) NULL,
	[Invoice_VAT_BankAcount] [nvarchar](50) NULL,
	[Invoice_VAT_Content] [nvarchar](50) NULL,
 CONSTRAINT [PK_Original_Orders_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Original_Orders_Goods]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Original_Orders_Goods](
	[Orders_Goods_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Goods_Type] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Type]  DEFAULT ((0)),
	[Orders_Goods_ParentID] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_ParentID]  DEFAULT ((0)),
	[Orders_Goods_OrdersID] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Orders_ID]  DEFAULT ((0)),
	[Orders_Goods_Product_ID] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_ID]  DEFAULT ((0)),
	[Orders_Goods_Product_SupplierID] [int] NULL,
	[Orders_Goods_Product_Code] [nvarchar](50) NULL,
	[Orders_Goods_Product_CateID] [int] NULL,
	[Orders_Goods_Product_BrandID] [int] NULL,
	[Orders_Goods_Product_Name] [nvarchar](100) NULL,
	[Orders_Goods_Product_Img] [nvarchar](100) NULL,
	[Orders_Goods_Product_Price] [money] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_Price]  DEFAULT ((0)),
	[Orders_Goods_Product_MKTPrice] [money] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_MKTPrice]  DEFAULT ((0)),
	[Orders_Goods_Product_Maker] [nvarchar](100) NULL,
	[Orders_Goods_Product_Spec] [nvarchar](50) NULL,
	[Orders_Goods_Product_AuthorizeCode] [nvarchar](50) NULL,
	[Orders_Goods_Product_brokerage] [money] NULL,
	[Orders_Goods_Product_SalePrice] [money] NULL,
	[Orders_Goods_Product_PurchasingPrice] [money] NULL,
	[Orders_Goods_Product_Coin] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_Coin]  DEFAULT ((0)),
	[Orders_Goods_Product_IsFavor] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_IsFavor]  DEFAULT ((0)),
	[Orders_Goods_Product_UseCoin] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Product_UseCoin]  DEFAULT ((0)),
	[Orders_Goods_Amount] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_Amount]  DEFAULT ((0)),
	[Orders_Goods_DeliveryStatus] [int] NULL,
	[Orders_Goods_IsSettle] [int] NULL,
	[Orders_Goods_DeliveryID] [int] NULL CONSTRAINT [DF_Original_Orders_Goods_Orders_Goods_DeliveryID]  DEFAULT ((0)),
	[Orders_Goods_Note] [nvarchar](100) NULL,
	[Orders_Goods_ReceivedReturn] [int] NULL,
	[Orders_Goods_RefundReason] [nvarchar](100) NULL,
	[Orders_Goods_Product_Specification] [nvarchar](100) NULL,
	[Orders_Goods_Product_Color] [nvarchar](100) NULL,
 CONSTRAINT [PK_Original_Orders_Goods] PRIMARY KEY CLUSTERED 
(
	[Orders_Goods_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Original_Orders]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Original_Orders](
	[Orders_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_SN] [nvarchar](20) NULL,
	[Orders_BuyerID] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_BuyerID]  DEFAULT ((0)),
	[Orders_SysUserID] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_SysUserID]  DEFAULT ((0)),
	[Orders_Status] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Status]  DEFAULT ((0)),
	[Orders_ERPSyncStatus] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_ERPSyncStatus]  DEFAULT ((0)),
	[Orders_PaymentStatus] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_PaymentStatus]  DEFAULT ((0)),
	[Orders_PaymentStatus_Time] [datetime] NULL CONSTRAINT [DF_Original_Orders_Orders_PaymentStatus_Time]  DEFAULT (getdate()),
	[Orders_DeliveryStatus] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_DeliveryStatus]  DEFAULT ((0)),
	[Orders_DeliveryStatus_Time] [datetime] NULL CONSTRAINT [DF_Original_Orders_Orders_DeliveryStatus_Time]  DEFAULT (getdate()),
	[Orders_InvoiceStatus] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_InvoiceStatus]  DEFAULT ((0)),
	[Orders_Fail_SysUserID] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Fail_SysUserID]  DEFAULT ((0)),
	[Orders_Fail_Note] [nvarchar](200) NULL,
	[Orders_Fail_Addtime] [datetime] NULL CONSTRAINT [DF_Original_Orders_Orders_Fail_Addtime]  DEFAULT (getdate()),
	[Orders_IsReturnCoin] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_isreturncoin]  DEFAULT ((0)),
	[Orders_Total_MKTPrice] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_MKTPrice]  DEFAULT ((0)),
	[Orders_Total_Price] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_Price]  DEFAULT ((0)),
	[Orders_Total_Freight] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_Freight]  DEFAULT ((0)),
	[Orders_Total_Coin] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_Coin]  DEFAULT ((0)),
	[Orders_Total_UseCoin] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_UseCoin]  DEFAULT ((0)),
	[Orders_Total_PriceDiscount] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_PriceDiscount]  DEFAULT ((0)),
	[Orders_Total_FreightDiscount] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_FreightDiscount]  DEFAULT ((0)),
	[Orders_Total_PriceDiscount_Note] [nvarchar](300) NULL,
	[Orders_Total_FreightDiscount_Note] [nvarchar](300) NULL,
	[Orders_Total_AllPrice] [money] NULL CONSTRAINT [DF_Original_Orders_Orders_Total_AllPrice]  DEFAULT ((0)),
	[Orders_Address_ID] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Address_id]  DEFAULT ((0)),
	[Orders_Address_Country] [nvarchar](8) NULL,
	[Orders_Address_State] [nvarchar](8) NULL CONSTRAINT [DF_Original_Orders_Orders_Address_Province]  DEFAULT ((0)),
	[Orders_Address_City] [nvarchar](8) NULL CONSTRAINT [DF_Original_Orders_Orders_Address_City]  DEFAULT ((0)),
	[Orders_Address_County] [nvarchar](8) NULL CONSTRAINT [DF_Original_Orders_Orders_Address_District]  DEFAULT ((0)),
	[Orders_Address_StreetAddress] [nvarchar](100) NULL,
	[Orders_Address_Zip] [nvarchar](20) NULL,
	[Orders_Address_Name] [nvarchar](100) NULL,
	[Orders_Address_Phone_Countrycode] [nvarchar](20) NULL CONSTRAINT [DF_Original_Orders_Orders_Address_Phone_Countrycode]  DEFAULT ((86)),
	[Orders_Address_Phone_Areacode] [nvarchar](20) NULL,
	[Orders_Address_Phone_Number] [nvarchar](100) NULL,
	[Orders_Address_Mobile] [nvarchar](100) NULL CONSTRAINT [DF_Original_Orders_Orders_Address_Mobile]  DEFAULT ((86)),
	[Orders_Delivery_Time_ID] [int] NULL,
	[Orders_Delivery] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Delivery]  DEFAULT ((0)),
	[Orders_Delivery_Name] [nvarchar](50) NULL,
	[Orders_Payway] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Payway]  DEFAULT ((0)),
	[Orders_Payway_Name] [nvarchar](50) NULL,
	[Orders_Note] [nvarchar](100) NULL,
	[Orders_Admin_Note] [nvarchar](200) NULL,
	[Orders_Admin_Sign] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_Admin_Sign]  DEFAULT ((0)),
	[Orders_Site] [nvarchar](50) NULL CONSTRAINT [DF_Original_Orders_Orders_Site]  DEFAULT (N'CN'),
	[Orders_SourceType] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_SourceType]  DEFAULT ((0)),
	[Orders_Source] [nvarchar](100) NULL,
	[Orders_VerifyCode] [nvarchar](128) NULL,
	[U_Orders_IsMonitor] [int] NULL,
	[Orders_Addtime] [datetime] NULL CONSTRAINT [DF_Original_Orders_Orders_Addtime]  DEFAULT (getdate()),
	[Orders_From] [nvarchar](100) NULL,
	[Orders_Account_Pay] [money] NULL,
	[Orders_Card_Pay] [money] NULL,
	[Orders_Total_RemainPrice] [money] NULL,
	[Orders_IsEvaluate] [int] NULL,
	[U_Orders_SMS_Status] [int] NULL,
	[U_Orders_IsPush] [int] NULL,
	[Orders_SupplierID] [int] NULL,
	[Orders_BankOrderSN] [nvarchar](50) NULL,
	[Orders_TieIn_Status] [int] NULL CONSTRAINT [DF_Original_Orders_Orders_TieIn_Status]  DEFAULT ((0)),
	[Orders_Settle_Account] [money] NULL,
	[Orders_Settle_Date] [datetime] NULL,
	[Orders_Settle_Note] [nvarchar](500) NULL,
	[Orders_Settle_IsSettle] [int] NULL,
	[Orders_BankAuditPass] [int] NULL,
	[Orders_IsUrgency] [int] NULL,
	[Orders_Credit_Card_No] [nvarchar](50) NULL,
	[Orders_ID_No] [nvarchar](50) NULL,
	[Orders_Installment] [float] NULL,
	[Orders_Point] [float] NULL,
 CONSTRAINT [PK_Original_Orders] PRIMARY KEY CLUSTERED 
(
	[Orders_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Settle]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Settle](
	[Settle_ID] [int] IDENTITY(1,1) NOT NULL,
	[Settle_Source] [nvarchar](50) NULL,
	[Settle_OrdersSN] [nvarchar](50) NULL,
	[Settle_OrdersID] [int] NULL,
	[Settle_Price] [money] NULL,
	[Settile_ReturnData] [nvarchar](50) NULL,
	[Settile_Note] [nvarchar](200) NULL,
	[Settile_AddTime] [datetime] NULL,
 CONSTRAINT [PK_Orders_Settle] PRIMARY KEY CLUSTERED 
(
	[Settle_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Payment]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Payment](
	[Orders_Payment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Payment_OrdersID] [int] NULL,
	[Orders_Payment_PaymentStatus] [int] NULL,
	[Orders_Payment_SysUserID] [int] NULL,
	[Orders_Payment_DocNo] [nvarchar](50) NULL,
	[Orders_Payment_Name] [nvarchar](100) NULL,
	[Orders_Payment_Amount] [money] NULL,
	[Orders_Payment_Note] [nvarchar](100) NULL,
	[Orders_Payment_Addtime] [datetime] NULL,
	[Orders_Payment_Site] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders_Payment] PRIMARY KEY CLUSTERED 
(
	[Orders_Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Log]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Log](
	[Orders_Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Log_OrdersID] [int] NULL,
	[Orders_Log_Addtime] [datetime] NULL,
	[Orders_Log_Operator] [nvarchar](50) NULL,
	[Orders_Log_Remark] [nvarchar](1000) NULL,
	[Orders_Log_Action] [nvarchar](50) NULL,
	[Orders_Log_Result] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order_Log] PRIMARY KEY CLUSTERED 
(
	[Orders_Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Invoice]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Invoice](
	[Invoice_ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_OrdersID] [int] NULL CONSTRAINT [DF_Order_invoice_invoice_order_id]  DEFAULT ((0)),
	[Invoice_Type] [int] NULL CONSTRAINT [DF_Order_invoice_invoice_type]  DEFAULT ((0)),
	[Invoice_Title] [nvarchar](100) NULL CONSTRAINT [DF_Order_invoice_invoice_title]  DEFAULT ((0)),
	[Invoice_Content] [int] NULL CONSTRAINT [DF_Order_invoice_invoice_content]  DEFAULT ((0)),
	[Invoice_FirmName] [nvarchar](100) NULL,
	[Invoice_VAT_FirmName] [nvarchar](100) NULL,
	[Invoice_VAT_Code] [nvarchar](50) NULL,
	[Invoice_VAT_RegAddr] [nvarchar](100) NULL,
	[Invoice_VAT_RegTel] [nvarchar](50) NULL,
	[Invoice_VAT_Bank] [nvarchar](50) NULL,
	[Invoice_VAT_BankAcount] [nvarchar](50) NULL,
	[Invoice_VAT_Content] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Goods_tmp]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Goods_tmp](
	[Orders_Goods_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Goods_Type] [int] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Type]  DEFAULT ((0)),
	[Orders_Goods_BuyerID] [int] NOT NULL CONSTRAINT [DF_Orders_Goods_tmp_orders_goods_buyerid]  DEFAULT ((0)),
	[Orders_Goods_SessionID] [nvarchar](50) NULL,
	[Orders_Goods_ParentID] [int] NULL,
	[Orders_Goods_Product_ID] [int] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Product_ID]  DEFAULT ((0)),
	[Orders_Goods_Product_SupplierID] [int] NULL,
	[Orders_Goods_Product_Code] [nvarchar](20) NULL,
	[Orders_Goods_Product_CateID] [int] NULL,
	[Orders_Goods_Product_BrandID] [int] NULL,
	[Orders_Goods_Product_Name] [nvarchar](100) NULL,
	[Orders_Goods_Product_Img] [nvarchar](100) NULL,
	[Orders_Goods_Product_Price] [money] NULL,
	[Orders_Goods_Product_MKTPrice] [money] NULL,
	[Orders_Goods_Product_Maker] [nvarchar](100) NULL,
	[Orders_Goods_Product_Spec] [nvarchar](50) NULL,
	[Orders_Goods_Product_AuthorizeCode] [nvarchar](50) NULL,
	[Orders_Goods_Product_brokerage] [money] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Product_brokerage]  DEFAULT ((0)),
	[Orders_Goods_Product_SalePrice] [money] NULL,
	[Orders_Goods_Product_PurchasingPrice] [money] NULL,
	[Orders_Goods_Product_Coin] [int] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Product_Coin]  DEFAULT ((0)),
	[Orders_Goods_Product_IsFavor] [int] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Product_IsFavor]  DEFAULT ((0)),
	[Orders_Goods_Product_UseCoin] [int] NULL,
	[Orders_Goods_Amount] [int] NULL CONSTRAINT [DF_Orders_Goods_tmp_Orders_Goods_Amount]  DEFAULT ((0)),
	[Orders_Goods_Addtime] [datetime] NULL,
	[Orders_Goods_OrdersID] [int] NULL,
	[Orders_Goods_Product_Specification] [nvarchar](100) NULL,
	[Orders_Goods_Product_Color] [nvarchar](100) NULL,
	[Orders_Goods_Product_Rate] [float] NULL,
	[Orders_Goods_Product_Cate] [nvarchar](100) NULL,
 CONSTRAINT [PK_Orders_Goods_tmp_1] PRIMARY KEY CLUSTERED 
(
	[Orders_Goods_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Goods]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Goods](
	[Orders_Goods_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Goods_Type] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Type]  DEFAULT ((0)),
	[Orders_Goods_ParentID] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_ParentID]  DEFAULT ((0)),
	[Orders_Goods_OrdersID] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Orders_ID]  DEFAULT ((0)),
	[Orders_Goods_Product_ID] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_ID]  DEFAULT ((0)),
	[Orders_Goods_Product_SupplierID] [int] NULL,
	[Orders_Goods_Product_Code] [nvarchar](50) NULL,
	[Orders_Goods_Product_CateID] [int] NULL,
	[Orders_Goods_Product_BrandID] [int] NULL,
	[Orders_Goods_Product_Name] [nvarchar](100) NULL,
	[Orders_Goods_Product_Img] [nvarchar](100) NULL,
	[Orders_Goods_Product_Price] [money] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_Price]  DEFAULT ((0)),
	[Orders_Goods_Product_MKTPrice] [money] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_MKTPrice]  DEFAULT ((0)),
	[Orders_Goods_Product_Maker] [nvarchar](100) NULL,
	[Orders_Goods_Product_Spec] [nvarchar](50) NULL,
	[Orders_Goods_Product_AuthorizeCode] [nvarchar](50) NULL,
	[Orders_Goods_Product_brokerage] [money] NULL,
	[Orders_Goods_Product_SalePrice] [money] NULL,
	[Orders_Goods_Product_PurchasingPrice] [money] NULL,
	[Orders_Goods_Product_Coin] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_Coin]  DEFAULT ((0)),
	[Orders_Goods_Product_IsFavor] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_IsFavor]  DEFAULT ((0)),
	[Orders_Goods_Product_UseCoin] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Product_UseCoin]  DEFAULT ((0)),
	[Orders_Goods_Amount] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_Amount]  DEFAULT ((0)),
	[Orders_Goods_DeliveryStatus] [int] NULL,
	[Orders_Goods_IsSettle] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_IsSettle]  DEFAULT ((0)),
	[Orders_Goods_DeliveryID] [int] NULL CONSTRAINT [DF_Orders_Goods_Orders_Goods_DeliveryID]  DEFAULT ((0)),
	[Orders_Goods_Note] [nvarchar](100) NULL,
	[Orders_Goods_ReceivedReturn] [int] NULL,
	[Orders_Goods_RefundReason] [nvarchar](100) NULL,
	[Orders_Goods_Product_Specification] [nvarchar](100) NULL,
	[Orders_Goods_Product_Color] [nvarchar](100) NULL,
	[Orders_Goods_Product_Rate] [float] NULL,
	[Orders_Goods_Product_Cate] [nvarchar](100) NULL,
	[Orders_Goods_Product_Issubstitute] [int] NULL,
	[Orders_Goods_Product_Provider] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders_Goods] PRIMARY KEY CLUSTERED 
(
	[Orders_Goods_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_FavorPolicy]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_FavorPolicy](
	[Orders_FavorPolicy_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_FavorPolicy_PolicyID] [int] NULL,
	[Orders_FavorPolicy_OrdersID] [int] NULL,
 CONSTRAINT [PK_Orders_FavorPolicy] PRIMARY KEY CLUSTERED 
(
	[Orders_FavorPolicy_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Delivery]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Delivery](
	[Orders_Delivery_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Delivery_OrdersID] [int] NULL,
	[Orders_Delivery_DeliveryStatus] [int] NULL,
	[Orders_Delivery_SysUserID] [int] NULL,
	[Orders_Delivery_DocNo] [nvarchar](50) NULL,
	[Orders_Delivery_Name] [nvarchar](100) NULL,
	[Orders_Delivery_companyName] [nvarchar](100) NULL,
	[Orders_Delivery_Code] [nvarchar](100) NULL,
	[Orders_Delivery_Amount] [money] NULL,
	[Orders_Delivery_Note] [nvarchar](200) NULL,
	[Orders_Delivery_Addtime] [datetime] NULL,
	[Orders_Delivery_Site] [nvarchar](50) NULL,
	[Orders_Delivery_SupplierID] [int] NULL,
	[Orders_Delivery_BankSN] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders_Delivery] PRIMARY KEY CLUSTERED 
(
	[Orders_Delivery_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_Coupon]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_Coupon](
	[Orders_Coupon_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_Coupon_OrdersID] [int] NULL,
	[Orders_Coupon_CouponID] [int] NULL,
 CONSTRAINT [PK_Orders_Coupon] PRIMARY KEY CLUSTERED 
(
	[Orders_Coupon_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders_BackApply]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders_BackApply](
	[Orders_BackApply_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_BackApply_OrdersCode] [nvarchar](50) NULL,
	[Orders_BackApply_MemberID] [int] NULL,
	[Orders_BackApply_Name] [nvarchar](50) NULL,
	[Orders_BackApply_Type] [int] NULL,
	[Orders_BackApply_Amount] [money] NULL,
	[Orders_BackApply_Note] [nvarchar](4000) NULL,
	[Orders_BackApply_Status] [int] NULL,
	[Orders_BackApply_SupplierID] [int] NULL,
	[Orders_BackApply_Addtime] [datetime] NULL,
	[Orders_BackApply_Site] [nvarchar](50) NULL,
 CONSTRAINT [PK_Orders_BackApply] PRIMARY KEY CLUSTERED 
(
	[Orders_BackApply_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Orders_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orders_SN] [nvarchar](20) NULL,
	[Orders_BuyerID] [int] NULL CONSTRAINT [DF_Orders_Orders_BuyerID]  DEFAULT ((0)),
	[Orders_SysUserID] [int] NULL CONSTRAINT [DF_Orders_Orders_SysUserID]  DEFAULT ((0)),
	[Orders_Status] [int] NULL CONSTRAINT [DF_Orders_Orders_Status]  DEFAULT ((0)),
	[Orders_ERPSyncStatus] [int] NULL CONSTRAINT [DF_Orders_Orders_ERPSyncStatus]  DEFAULT ((0)),
	[Orders_PaymentStatus] [int] NULL CONSTRAINT [DF_Orders_Orders_PaymentStatus]  DEFAULT ((0)),
	[Orders_PaymentStatus_Time] [datetime] NULL CONSTRAINT [DF_Orders_Orders_PaymentStatus_Time]  DEFAULT (getdate()),
	[Orders_DeliveryStatus] [int] NULL CONSTRAINT [DF_Orders_Orders_DeliveryStatus]  DEFAULT ((0)),
	[Orders_DeliveryStatus_Time] [datetime] NULL CONSTRAINT [DF_Orders_Orders_DeliveryStatus_Time]  DEFAULT (getdate()),
	[Orders_InvoiceStatus] [int] NULL CONSTRAINT [DF_Orders_Orders_InvoiceStatus]  DEFAULT ((0)),
	[Orders_Fail_SysUserID] [int] NULL CONSTRAINT [DF_Orders_Orders_Fail_SysUserID]  DEFAULT ((0)),
	[Orders_Fail_Note] [nvarchar](200) NULL,
	[Orders_Fail_Addtime] [datetime] NULL CONSTRAINT [DF_Orders_Orders_Fail_Addtime]  DEFAULT (getdate()),
	[Orders_IsReturnCoin] [int] NULL CONSTRAINT [DF_Orders_Orders_isreturncoin]  DEFAULT ((0)),
	[Orders_Total_MKTPrice] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_MKTPrice]  DEFAULT ((0)),
	[Orders_Total_Price] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_Price]  DEFAULT ((0)),
	[Orders_Total_Freight] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_Freight]  DEFAULT ((0)),
	[Orders_Total_Coin] [int] NULL CONSTRAINT [DF_Orders_Orders_Total_Coin]  DEFAULT ((0)),
	[Orders_Total_UseCoin] [int] NULL CONSTRAINT [DF_Orders_Orders_Total_UseCoin]  DEFAULT ((0)),
	[Orders_Total_PriceDiscount] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_PriceDiscount]  DEFAULT ((0)),
	[Orders_Total_FreightDiscount] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_FreightDiscount]  DEFAULT ((0)),
	[Orders_Total_PriceDiscount_Note] [nvarchar](300) NULL,
	[Orders_Total_FreightDiscount_Note] [nvarchar](300) NULL,
	[Orders_Total_AllPrice] [money] NULL CONSTRAINT [DF_Orders_Orders_Total_AllPrice]  DEFAULT ((0)),
	[Orders_Address_ID] [int] NULL CONSTRAINT [DF_Orders_Orders_Address_id]  DEFAULT ((0)),
	[Orders_Address_Country] [nvarchar](8) NULL,
	[Orders_Address_State] [nvarchar](8) NULL CONSTRAINT [DF_Orders_Orders_Address_Province]  DEFAULT ((0)),
	[Orders_Address_City] [nvarchar](8) NULL CONSTRAINT [DF_Orders_Orders_Address_City]  DEFAULT ((0)),
	[Orders_Address_County] [nvarchar](8) NULL CONSTRAINT [DF_Orders_Orders_Address_District]  DEFAULT ((0)),
	[Orders_Address_StreetAddress] [nvarchar](100) NULL,
	[Orders_Address_Zip] [nvarchar](20) NULL,
	[Orders_Address_Name] [nvarchar](100) NULL,
	[Orders_Address_Phone_Countrycode] [nvarchar](20) NULL CONSTRAINT [DF_Orders_Orders_Address_Phone_Countrycode]  DEFAULT ((86)),
	[Orders_Address_Phone_Areacode] [nvarchar](20) NULL,
	[Orders_Address_Phone_Number] [nvarchar](100) NULL,
	[Orders_Address_Mobile] [nvarchar](100) NULL CONSTRAINT [DF_Orders_Orders_Address_Mobile]  DEFAULT ((86)),
	[Orders_Delivery_Time_ID] [int] NULL,
	[Orders_Delivery] [int] NULL CONSTRAINT [DF_Orders_Orders_Delivery]  DEFAULT ((0)),
	[Orders_Delivery_Name] [nvarchar](50) NULL,
	[Orders_Payway] [int] NULL CONSTRAINT [DF_Orders_Orders_Payway]  DEFAULT ((0)),
	[Orders_Payway_Name] [nvarchar](50) NULL,
	[Orders_Note] [nvarchar](100) NULL,
	[Orders_Admin_Note] [nvarchar](200) NULL,
	[Orders_Admin_Sign] [int] NULL CONSTRAINT [DF_Orders_Orders_Admin_Sign]  DEFAULT ((0)),
	[Orders_Site] [nvarchar](50) NULL CONSTRAINT [DF_Orders_Orders_Site]  DEFAULT (N'CN'),
	[Orders_SourceType] [int] NULL CONSTRAINT [DF_Orders_Orders_SourceType]  DEFAULT ((0)),
	[Orders_Source] [nvarchar](100) NULL,
	[Orders_VerifyCode] [nvarchar](128) NULL,
	[U_Orders_IsMonitor] [int] NULL,
	[Orders_Addtime] [datetime] NULL CONSTRAINT [DF_Orders_Orders_Addtime]  DEFAULT (getdate()),
	[Orders_From] [nvarchar](100) NULL,
	[Orders_Account_Pay] [money] NULL,
	[Orders_Card_Pay] [money] NULL,
	[Orders_Total_RemainPrice] [money] NULL,
	[Orders_Settle_Price] [money] NULL CONSTRAINT [DF_Orders_Orders_Settle_Price]  DEFAULT ((0)),
	[Orders_IsEvaluate] [int] NULL,
	[U_Orders_SMS_Status] [int] NULL,
	[U_Orders_IsPush] [int] NULL,
	[Orders_SupplierID] [int] NULL,
	[Orders_BankOrderSN] [nvarchar](50) NULL,
	[Orders_TieIn_Status] [int] NULL CONSTRAINT [DF_Orders_Orders_TieIn_Status]  DEFAULT ((0)),
	[Orders_Settle_Account] [money] NULL,
	[Orders_Settle_Date] [datetime] NULL,
	[Orders_Settle_Note] [nvarchar](500) NULL,
	[Orders_Settle_IsSettle] [int] NULL CONSTRAINT [DF_Orders_Orders_Settle_IsSettle]  DEFAULT ((0)),
	[Orders_BankAuditPass] [int] NULL,
	[Orders_IsUrgency] [int] NULL,
	[Orders_ShipmentsType] [int] NULL,
	[Orders_ApplyStatus] [int] NULL,
	[Orders_Delivery_Requirements] [nvarchar](500) NULL,
	[Orders_PriorityLevel] [int] NULL CONSTRAINT [DF_Orders_Orders_PriorityLevel]  DEFAULT ((0)),
	[Orders_PriorityCoefficient] [int] NULL CONSTRAINT [DF_Orders_Orders_PriorityCoefficient]  DEFAULT ((0)),
	[Orders_PriorityLevelTime] [datetime] NULL CONSTRAINT [DF_Orders_Orders_PriorityLevelTime]  DEFAULT ('1900-01-01'),
	[Orders_Credit_Card_No] [nvarchar](50) NULL,
	[Orders_ID_No] [nvarchar](50) NULL,
	[Orders_Installment] [nvarchar](20) NULL,
	[Orders_Point] [float] NULL,
	[Orders_Delivery_Time] [datetime] NULL,
	[Orders_Cancel_Time] [datetime] NULL,
	[Orders_Return_Time] [datetime] NULL,
	[Order_Confirm_Time] [datetime] NULL,
	[Orders_RefundStatus] [int] NULL CONSTRAINT [DF_Orders_Orders_RefundStatus]  DEFAULT ((0)),
	[Orders_TieIn_SN] [nvarchar](20) NULL,
	[Orders_KFConfirmSMS] [int] NULL CONSTRAINT [DF_Orders_Orders_KFConfirmSMS]  DEFAULT ((0)),
	[Orders_Import_Type] [nvarchar](50) NULL,
	[Orders_Import_Cardholder] [nvarchar](50) NULL,
	[Orders_Import_cardholder_Tel] [nvarchar](50) NULL,
	[Orders_Import_MainOrdersID] [nvarchar](50) NULL,
	[Orders_OldGoods] [nvarchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Orders_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BankProductMap]    Script Date: 2015/3/20 15:35:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BankProductMap](
	[BankProductMap_ID] [int] IDENTITY(1,1) NOT NULL,
	[BankProductMap_BankName] [nvarchar](255) NULL,
	[BankProductMap_BankProductCode] [nvarchar](500) NULL,
	[BankProductMap_BankProductName] [nvarchar](255) NULL,
	[BankProductMap_ProductCode] [nvarchar](255) NULL,
	[BankProductMap_ProductName] [nvarchar](500) NULL,
	[BankProductMap_Amount] [int] NULL,
	[BankProductMap_Specification] [nvarchar](500) NULL,
	[BankProductMap_Color] [nvarchar](50) NULL,
	[BankProductMap_SupplierID] [int] NULL,
	[BankProductMap_Price] [money] NULL,
	[BankProductMap_Cate] [nvarchar](50) NULL,
	[BankProductMap_CommissionRate] [float] NULL,
	[BankProductMap_ERPCode] [nvarchar](255) NULL,
 CONSTRAINT [PK_BankProductMap] PRIMARY KEY CLUSTERED 
(
	[BankProductMap_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Orders_BackApply] ADD  CONSTRAINT [DF_Orders_BackApply_Orders_BackApply_SupplierID]  DEFAULT ((0)) FOR [Orders_BackApply_SupplierID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'虚拟商品是否允许购买' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Library', @level2type=N'COLUMN',@level2name=N'Product_AllowBuy'
GO


