IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_FundPlanId') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_FundPlanId
GO


/*****表值函数：获取指定资金计划ID的全部父计划ID*****/

CREATE FUNCTION Get_FundPlanId(
@PlanId                 UNIQUEIDENTIFIER      --资金计划ID
)

RETURNS TABLE AS

RETURN

with
PlanList as (
  select ID, ParentId
  from ABS_Contract_FundPlan
  where ID = @PlanId
  union all
  select F.ID, F.ParentId from ABS_Contract_FundPlan F
  join PlanList L on L.ParentId = F.ID)

select ID from PlanList

GO