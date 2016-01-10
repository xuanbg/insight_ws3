IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_FundPlan') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_FundPlan
GO


/*****表值函数：获取指定主数据ID相关的未履约资金计划数据*****/

CREATE FUNCTION Get_FundPlan(
@MasterDataId  UNIQUEIDENTIFIER,       --主数据ID
@Direction     INT                     --资金方向
)

RETURNS TABLE AS

RETURN
select top 200 P.ID, C.ObjectId, cast(1 as bit) as IsPlan, case when P.StartDate > getdate() then cast(0 as bit) else cast(1 as bit) end as Selected, S.ObjectId as ProductId,
P.Description as 摘要, S.ObjectName as 项目, S.Units as 单位, S.Price as 单价, S.Counts, S.Counts as 数量, P.Amount - isnull(F.Amount, 0) as MaxAmount, P.Amount - isnull(F.Amount, 0) as 金额
from ABS_Contract C
join ABS_Contract_Subjects S on S.ContractId = C.ID
  and S.Direction = @Direction
join ABS_Contract_FundPlan P on P.SubjectsId = S.ID
left join (select PlanId, sum(Amount) as Amount
  from ABS_Contract_FundPerform
  group by PlanId) F on F.PlanId = P.ID
where C.ObjectId = @MasterDataId
  and C.Status = 2
  and isnull(F.Amount, 0) != P.Amount
order by P.StartDate

GO