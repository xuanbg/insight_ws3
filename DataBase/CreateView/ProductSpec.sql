IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Specification') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Specification
GO


/*****视图：查询可用预付款*****/

CREATE VIEW Specification
AS

select distinct Product_Extend_ProductID as ProductId ,stuff((
  select ','+ Product_Extend_Value 
  from Product_Library_Extend 
  where Product_Extend_ProductID = PE.Product_Extend_ProductID 
  for xml path('')),1,1,'') as Specific
from Product_Library_Extend PE

GO