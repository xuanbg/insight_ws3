IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_GoodsPlanId') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_GoodsPlanId
GO


/*****表值函数：获取指定物资计划ID的全部父计划ID*****/

CREATE FUNCTION Get_GoodsPlanId(
@PlanId                 UNIQUEIDENTIFIER      --资金计划ID
)

RETURNS TABLE AS

RETURN

with
PlanList as (
  select ID, ParentId
  from ABS_Contract_GoodsPlan
  where ID = @PlanId
  union all
  select G.ID, G.ParentId from ABS_Contract_GoodsPlan G
  join PlanList L on L.ParentId = G.ID)

select ID from PlanList

GO