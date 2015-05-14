IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'FundForPerform') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW FundForPerform
GO


/*****��ͼ����ѯ����Ӧ��*****/

CREATE VIEW FundForPerform
AS

select top 200 newid() as ID, P.ID as PlanId, C.ObjectId, case when P.StartDate > getdate() then cast(0 as bit) else cast(1 as bit) end as Selected, S.ObjectId as ProductId,
P.Description as ժҪ, S.ObjectName as ��Ŀ, S.Units as ��λ, S.Price as ����, S.Counts, S.Counts as ����, P.Amount - isnull(F.Amount, 0) as MaxAmount, P.Amount - isnull(F.Amount, 0) as ���
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