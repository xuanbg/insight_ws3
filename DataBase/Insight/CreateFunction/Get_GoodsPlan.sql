IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_GoodsPlan') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_GoodsPlan
GO


/*****表值函数：获取指定合同号的相关未履约物资计划*****/

CREATE FUNCTION Get_GoodsPlan(
@Code          varchar(32)     --合同号
)

RETURNS TABLE AS

RETURN
with List as (
  select P.ID, C.ObjectId, cast(1 as bit) as IsPlan, case when P.StartDate > getdate() then cast(0 as bit) else cast(1 as bit) end as Selected, S.ObjectId as ProductId,
  P.Description, S.ObjectName, S.Units, S.Price, P.Counts - isnull(G.Counts, 0) as Counts, P.StartDate
  from ABS_Contract C
  join ABS_Contract_Subjects S on S.ContractId = C.ID
  join ABS_Contract_GoodsPlan P on P.SubjectsId = S.ID
  left join (select PlanId, sum(Counts) as Counts
    from ABS_Contract_GoodsPerform
    group by PlanId) G on G.PlanId = P.ID
  where C.ContractCode = @Code
    and C.Status = 2
    and isnull(G.Counts, 0) != P.Counts)

select top 200 ID, ObjectId, IsPlan, Selected, ProductId, Description as 摘要, ObjectName as 项目, Units as 单位, Price as 单价, Counts as 数量, Counts as MaxCount, Price * Counts as 金额, Price * Counts as MaxAmount from List
order by StartDate


GO