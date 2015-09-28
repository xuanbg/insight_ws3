IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Available') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Available
GO


/*****视图：查询可用额度*****/

CREATE VIEW Available
AS

with List as (
  select U.ID as MemberId, S.ID as SubjectId, E.Enable, E.Status
  from ABS_Contract_Subjects S
  join MasterData M on M.ID = S.ObjectId
    and M.Alias = 'Loans'
  join ABS_Contract C on C.ID = S.ContractId
    and C.Status > 0
  join SYS_User U on U.ID = C.ObjectId
    and U.Type != -1
  join MDG_EntMember E on E.MID = U.ID)

select L.MemberId, isnull(sum(F.Amount), 0) as LoanAmount, isnull(sum(F.Perform), 0) as Perform, L.Enable, L.Status
from List L
left join (
  select F.SubjectsId, sum(F.Amount) as Amount, sum(P.Perform) as Perform
  from ABS_Contract_FundPlan F
  left join (
    select PlanId, sum(Amount) as Perform 
    from ABS_Contract_FundPerform 
    group by PlanId) P on P.PlanId = F.ID
    group by SubjectsId) F on F.SubjectsId = L.SubjectId
group by L.MemberId, L.Enable, L.Status

GO