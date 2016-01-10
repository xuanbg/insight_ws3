USE Insight_Base
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_SubOrg') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION Get_SubOrg
GO


/*****��ֵ��������ȡָ����֯�����������¼�����/����*****/

CREATE FUNCTION Get_SubOrg(
@OrgId                 UNIQUEIDENTIFIER      --��֯����ID
)

RETURNS TABLE AS

RETURN
with
OrgList as (
  select @OrgId as ID
  union all
  select O.ID from Sys_Organization O
  join OrgList L on L.ID = O.ParentId
  where Validity = 1
    and NodeType < 3),
MergerOrg as(
  select OM.MergerOrgId as ID from OrgList OL
  join Sys_OrgMerger OM on OM.OrgId = OL.ID
  union all
  select O.ID from Sys_Organization O
  join MergerOrg M on M.ID = O.ParentId
  where Validity = 1
    and NodeType < 3)

select ID from OrgList
union all
select ID from MergerOrg

GO