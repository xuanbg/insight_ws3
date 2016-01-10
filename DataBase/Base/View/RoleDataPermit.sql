USE Insight_Base
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'RoleDataPermit') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW RoleDataPermit
GO


/*****��ͼ����ѯ���н�ɫ������Ȩ��*****/

CREATE VIEW RoleDataPermit
AS

with 
List as (
select distinct
       G.ID as DataId,
       null as ParentId,
       D.RoleId,
       G.[Index],
       0 as Action,
       G.Name as ģ��,
       null as ��дȨ��
from SYS_ModuleGroup G
join SYS_Module M on M.ModuleGroupId = G.ID
join SYS_RolePerm_Data D on D.ModuleId = M.ID
union
select distinct
       G.ID as DataId,
       null as ParentId,
       A.RoleId,
       G.[Index],
       0 as Action,
       G.Name as ģ��,
       null as ��дȨ��
from SYS_ModuleGroup G
join SYS_Module M on M.ModuleGroupId = G.ID
join SYS_RolePerm_DataAbs A on A.ModuleId = M.ID

union
select distinct
       M.ID as DataId,
       case when M.ModuleGroupId is null then M.ParentId else M.ModuleGroupId end as ParentId,
       D.RoleId,
       M.[Index] + 100 as [Index],
       1 as Action,
       M.Name + '����' as ģ��,
       null as ��дȨ��
from SYS_Module M
join SYS_RolePerm_Data D on D.ModuleId = M.ID
union
select distinct
       M.ID as DataId,
       case when M.ModuleGroupId is null then M.ParentId else M.ModuleGroupId end as ParentId,
       A.RoleId,
       M.[Index] + 100 as [Index],
       1 as Action,
       M.Name + '����' as ģ��,
       null as ��дȨ��
from SYS_Module M
join SYS_RolePerm_DataAbs A on A.ModuleId = M.ID

union
select D.ID as DataId,
       D.ModuleId as ParentId,
       D.RoleId,
       D.Mode + 201 as [Index],
       D.Mode + 2 as Action,
       case D.Mode when 0 then '�޹���' when 1 then '������' when 2 then '��������' when 3 then '����������' when 4 then '����������' when 5 then '����������' end as ģ��,
       case when D.Permission = 0 then 'ֻ��' when D.Permission = 1 then '��д' else null end as ��дȨ��
from SYS_RolePerm_Data D
union
select A.ID as DataId,
       A.ModuleId as ParentId,
       A.RoleId,
       300 as [Index],
       4 as Action,
       O.FullName as ģ��,
       case when A.Permission = 0 then 'ֻ��' when A.Permission = 1 then '��д' else null end as ��дȨ��
from SYS_RolePerm_DataAbs A
join SYS_Organization O on O.ID = A.OrgId
where A.OrgId is not null
union
select A.ID as DataId,
       A.ModuleId as ParentId,
       A.RoleId,
       301 as [Index],
       3 as Action,
       U.Name + '(' + U.LoginName + ')' as ģ��,
       case when A.Permission = 0 then 'ֻ��' when A.Permission = 1 then '��д' else null end as ��дȨ��
from SYS_RolePerm_DataAbs A
join SYS_User U on U.ID = A.UserId
where A.UserId is not null
)

select newid() as ID, * from List

GO