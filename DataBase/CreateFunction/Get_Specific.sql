IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_Specific') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_Specific
GO


/*****��ֵ��������ȡָ��������ID��ص�δ��Լ�ʽ�ƻ�����*****/

CREATE FUNCTION Get_Specific(@ID INT) --��ƷID

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