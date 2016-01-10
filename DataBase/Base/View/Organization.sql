USE Insight_Base
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Organization') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Organization
GO


/*****��ͼ��ȫ����֯����*****/

CREATE VIEW Organization
AS

select ID,
       SN,
       ParentId,
	   NodeType,
	   [Index],
	   Name as ����,
	   FullName as ȫ��,
	   Alias as ���,
	   Code as ����
from Sys_Organization O
where Validity = 1
  and not exists (select MergerOrgId from Sys_OrgMerger M where M.MergerOrgId = O.ParentId)
union 
select O.ID,
       O.SN,
       OM.OrgId,
	   O.NodeType,
	   O.[Index],
	   O.Name as ����,
	   O.FullName as ȫ��,
	   O.Alias as ���,
	   O.Code as ����
from Sys_Organization O
  join Sys_OrgMerger OM on OM.MergerOrgId = O.ParentId

GO