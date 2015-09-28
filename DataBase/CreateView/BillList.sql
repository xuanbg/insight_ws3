IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BillList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW BillList
GO


/*****视图：查询账单列表*****/

CREATE VIEW BillList
AS

select 
F.ID, --账单ID
F.ContractId, --订单ID
F.Description, --账单描述（第 x 期）
isnull(F.Amount - isnull(P.Perform, 0), 0) as Amount, --需还本金
O.Interest, --服务费
isnull(case when datediff(day, F.EndDate, getdate()) > 7 then (F.Amount - isnull(P.Perform, 0)) * 0.005 * datediff(day, F.EndDate, getdate()) else 0 end, 0) as Liquidated, --违约金
F.EndDate, --还款截止日期
isnull(P.Perform, 0) as Perform, --已还金额
P.PerformDate --还款日期
from ABS_Contract_FundPlan F
join ABS_Contract C on C.ID = F.ContractId
  and C.Status not in (6, 7, 8, 9)
join BIZ_Order O on O.OID = C.ID
left join (
  select PlanId, sum(Amount) as Perform, max(CreateTime) as PerformDate
  from ABS_Contract_FundPerform
  group by PlanId) P on P.PlanId = F.ID

GO