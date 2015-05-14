IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_RoleAction') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_RoleAction
GO


/*****��ֵ��������ȡ����ģ��͹��ܲ����б�*****/

CREATE FUNCTION Get_RoleAction (@RoleId UNIQUEIDENTIFIER)

RETURNS TABLE AS

RETURN

with
Groups as (
  select ID, null as ParentId, null as ActionId, [Index], 0 as Action, Name, null as CheckState, null as Info
  from SYS_ModuleGroup),
Modules as (
  select M.ID, case when M.ModuleGroupId is null then M.ParentId else M.ModuleGroupId end as ParentId, null as ActionId, isnull(G.[Index], 10) * 10 + M.[Index] as [Index],
  1 as Action, M.ApplicationName as Name, case when A.ModuleId is not null then 'Checked' end as CheckState, null as Info
  from SYS_Module M
  left join Groups G on G.ID = M.ModuleGroupId
  left join(
  select distinct A.ModuleId
  from SYS_ModuleAction A
  join SYS_RolePerm_Action P on P.ActionId = A.ID
    and P.RoleId = @RoleId
  ) A on A.ModuleId = M.ID),
Actions as (
  select case when P.ID is null then A.ID else P.ID end as ID, ModuleId as ParentId, A.ID as ActionId, M.[Index] * 20 + A.[Index] as [Index], 2 as Action, A.Alias as Name,
  case when P.Action = 0 then 'Indeterminate' when P.Action = 1 then 'Checked' end as CheckState,
  case when P.Action = 0 then '�ܾ�' when P.Action = 1 then '����' end as Info
  from SYS_ModuleAction A
  join Modules M on M.ID = A.ModuleId
  left join SYS_RolePerm_Action P on P.ActionId = A.ID
    and P.RoleId = @RoleId)


select *, CheckState as Original from Actions
union all
select distinct M.*, M.CheckState as Original
from Modules M
join Actions A on A.ParentId = M.ID
union all
select distinct G.*, G.CheckState as Original
from Groups G
join Modules M on M.ParentId = G.ID
join Actions A on A.ParentId = M.ID

GO