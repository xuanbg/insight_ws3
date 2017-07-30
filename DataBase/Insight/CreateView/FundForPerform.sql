IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'FundForPerform') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW FundForPerform
GO


/*****视图：查询所有应收*****/

CREATE VIEW FundForPerform
AS

select top 200 newid() as ID, P.ID as PlanId, C.ObjectId, case when P.StartDate > getdate() then cast(0 as bit) else cast(1 as bit) end as Selected, S.ObjectId as ProductId,
P.Description as 摘要, S.ObjectName as 项目, S.Units as 单位, S.Price as 单价, S.Counts, S.Counts as 数量, P.Amount - isnull(F.Amount, 0) as MaxAmount, P.Amount - isnull(F.Amount, 0) as 金额
from ABS_Contract C
join ABS_Contract_Subjects S on S.ContractId = C.ID
  and S.Direction = 1
join ABS_Contract_FundPlan P on P.SubjectsId = S.ID
left join (select PlanId, sum(Amount) as Amount
  from ABS_Contract_FundPerform
  group by PlanId) F on F.PlanId = P.ID
where C.Status = 2
  and isnull(F.Amount, 0) != P.Amount
order by P.StartDate

GO