USE Insight_Base
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'RoleUser') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW RoleUser
GO


/*****��ͼ����ѯ���н�ɫ�ĳ�Ա�û�*****/

CREATE VIEW RoleUser
AS

with List as (
select RU.RoleId,
       U.ID as UserId,
       U.Name as �û���,
       U.LoginName as ��¼��,
       U.Description as ����,
       case when U.Validity = 1 then '����' else '���' end as ״̬
from Sys_Role_User RU
join Sys_User U on U.ID = RU.UserId
union
select RG.RoleId,
       U.ID as UserId,
       U.Name as �û���,
       U.LoginName as ��¼��,
       U.Description as ����,
       case when U.Validity = 1 then '����' else '���' end as ״̬
from Sys_Role_UserGroup RG
join Sys_UserGroupMember GM on GM.GroupId = RG.GroupId
join Sys_User U on U.ID = GM.UserId
union
select RP.RoleId,
       U.ID as UserId,
       U.Name as �û���,
       U.LoginName as ��¼��,
       U.Description as ����,
       case when U.Validity = 1 then '����' else '���' end as ״̬
from Sys_Role_Title RP
join Sys_OrgMember OM on OM.OrgId = RP.OrgId
join Sys_User U on U.ID = OM.UserId)

select newid() as ID, * from List

GO