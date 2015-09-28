IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_Specific') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_Specific
GO


/*****表值函数：获取指定主数据ID相关的未履约资金计划数据*****/

CREATE FUNCTION Get_Specific(@ID INT) --商品ID

RETURNS TABLE AS

RETURN
select distinct stuff((
  select ','+ Product_Extend_Value 
  from Product_Library_Extend 
  where Product_Extend_ProductID = PE.Product_Extend_ProductID 
  for xml path('')),1,1,'') as Specific
from Product_Library_Extend PE
where Product_Extend_ProductID = @ID

GO