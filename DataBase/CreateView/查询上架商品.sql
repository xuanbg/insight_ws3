IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Products') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Products
GO


/*****视图：查询上架商品*****/

CREATE VIEW Products
AS

select L.Product_ID as ID,
       L.Product_GroupCode as GroupCode, 
	   L.Product_Code as Code,
	   C.Cate_Name as Category, 
	   L.Product_TypeID as TypeId, 
	   L.Product_Name as Name, 
	   L.Product_ERPSKU1 as Color, 
	   L.Product_MKTPrice as MarketPrice, 
	   isnull(L.Product_Price, 0) as SalePrice, 
	   C.Cate_Sort as OutDay,
	   L.Product_Img as ImageUrl, 
	   L.Product_Intro as Description, 
	   L.Product_Parameter as Parameter, 
	   L.Product_Intro_Extend1 as Warranty, 
	   isnull(cast(case T.Product_RelateTag_TagID when 17 then 1 else 0 end as bit), 0) as Recommend
  from Product_Library L
  join Product_Basic B on B.Product_Code = L.Product_Code
  join BasicCategory C on C.Cate_ID = L.Product_CateID
  left join Product_RelateTag T on T.Product_RelateTag_ProductID = B.Product_ID
  where B.Product_Publisher = 'jtyh' and B.Product_IsInsale = 1

GO