USE Insight_Base
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TitleMember') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW TitleMember
GO


/*****��ͼ����ѯ������֯�ڵ�ĳ�Ա�û�*****/

CREATE VIEW TitleMember
AS

--����ְλ���û���Ա
select PM.ID,
       U.Name as �û���,
       U.LoginName as ��¼��,
       case when U.Validity = 1 then '����' else '���' end as ״̬,
       PM.OrgId as TitleId
from Sys_User U
join Sys_OrgMember PM on PM.UserId = U.ID
join Sys_Organization O on O.ID = PM.OrgId
  and O.Validity = 1

union --���ϲ�ְλ���û���Ա
select PM.ID,
       U.Name as �û���,
       U.LoginName as ��¼��,
       case when U.Validity = 1 then '����' else '���' end as ״̬,
       OM.OrgId as TitleId
from Sys_User U
join Sys_OrgMember PM on PM.UserId = U.ID
join Sys_OrgMerger OM on OM.MergerOrgId = PM.OrgId

GO