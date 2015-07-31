IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BillList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW BillList
GO


/*****视图：查询账单列表*****/

CREATE VIEW BillList
AS

select F.ID, F.SubjectsId, F.Description, isnull(F.Amount - isnull(P.Perform, 0), 0) as Amount, F.EndDate, isnull(P.Perform, 0) as Perform, P.PerformDate
from ABS_Contract_FundPlan F
left join (
  select PlanId, sum(Amount) as Perform, max(CreateTime) as PerformDate
  from ABS_Contract_FundPerform
  group by PlanId) P on P.PlanId = F.ID

GO