IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Available') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Available
GO


/*****视图：查询可用额度*****/

CREATE VIEW Available
AS

select distinct E.MID as MemberId, isnull(sum(S.Amount), 0) as TotalAmount, isnull(sum(F.Amount), 0) as LoanAmount, isnull(sum(F.Perform), 0) as Perform, E.Enable, E.Status
from MDG_EntMember E
left join ABS_Contract C on C.ObjectId = E.MID
  and C.Status > 0
left join ABS_Contract_Subjects S on S.ContractId = C.ID
left join MasterData M on M.ID = S.ObjectId
  and M.Alias = 'Loans'
left join (
  select F.SubjectsId, sum(F.Amount) as Amount, sum(P.Perform) as Perform
  from ABS_Contract_FundPlan F
  left join (
    select PlanId, sum(Amount) as Perform 
    from ABS_Contract_FundPerform 
    group by PlanId) P on P.PlanId = F.ID
    group by SubjectsId) F on F.SubjectsId = S.ID
group by E.MID, E.Enable, E.Status

GO