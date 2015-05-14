IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_GoodsPlanId') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_GoodsPlanId
GO


/*****��ֵ��������ȡָ�����ʼƻ�ID��ȫ�����ƻ�ID*****/

CREATE FUNCTION Get_GoodsPlanId(
@PlanId                 UNIQUEIDENTIFIER      --�ʽ�ƻ�ID
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