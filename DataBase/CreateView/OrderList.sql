IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'OrderList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW OrderList
GO


/*****视图：查询可用预付款*****/

CREATE VIEW OrderList
AS

select C.ID, C.ObjectId, PS.ProductName, PS.ProductSpeci, PS.ProductPrice, O.OrderAmount, O.FirstPay, O.StageAmount, PS.ProductImage, C.Status, O.StagePlan, C.CreateTime
from ABS_Contract C
join BIZ_Order O on O.OID = C.ID
join ABS_Contract_Subjects S on S.ContractId = C.ID
join BIZ_Product_Snapshot PS on PS.SID = S.ID

GO