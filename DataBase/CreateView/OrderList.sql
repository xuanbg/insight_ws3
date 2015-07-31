IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'OrderList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW OrderList
GO


/*****视图：查询订单列表*****/

CREATE VIEW OrderList
AS

select C.ID, C.ObjectId as MemberId, S.ID as SubjectId, PS.ProductName, PS.ProductSpeci, isnull(PS.ProductPrice, 0) as ProductPrice, isnull(O.OrderAmount, 0) as OrderAmount, isnull(O.FirstPay, 0) as FirstPay, isnull(O.StageAmount, 0) as StageAmount, PS.ProductImage, O.StagePlan, C.CreateTime, 
case C.Status when 1 then '未付款' when 2 then '已付款' when 3 then '已归档' when 4 then '已作废' when 5 then '已确认' when 6 then '已发货' when 7 then '已退货' when 8 then '已退款' else '草稿' end as Status
from ABS_Contract C
join BIZ_Order O on O.OID = C.ID
join ABS_Contract_Subjects S on S.ContractId = C.ID
join BIZ_Product_Snapshot PS on PS.SID = S.ID

GO