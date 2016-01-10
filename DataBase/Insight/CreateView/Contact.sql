IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Contact') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Contact
GO


/*****��ͼ����ѯ������ϵ��*****/

CREATE VIEW Contact
AS

select M.ID, M.ParentId, M.Name + case when E.Gender = 0 then '(Ůʿ)' when E.Gender = 1 then '(����)' else '' end as ����, E.Department as ��ְ����,
E.Title as ְ��, stuff(convert(varchar(5), E.Birthday, 100), 3, 1, '��') + '��' as ����, case when E.LoginUser = 1 then '��' else '��' end as ��¼,
M.Alias as ��¼�ʺ�, case when E.IsMaster = 1 then '��' else '��' end as ��Ҫ��ϵ��, T.Number as �绰����, P.Number as �ƶ��绰, A.Number as �����ʼ�,
E.OfficeAddress as �칫�ص�, E.HomeAddress as ��ͥסַ, E.Description as ��ע
from MasterData M
join MDG_Contact E on E.MID = M.ID
left join MDS_Contact_Info T on T.MasterDataId = M.ID
  and T.IsMaster = 1
  and T.InfoTypeId = (select ID from MasterData where Alias = 'Tel')
left join MDS_Contact_Info P on P.MasterDataId = M.ID
  and P.IsMaster = 1
  and P.InfoTypeId = (select ID from MasterData where Alias = 'Mobile')
left join MDS_Contact_Info A on A.MasterDataId = M.ID
  and A.IsMaster = 1
  and A.InfoTypeId = (select ID from MasterData where Alias = 'Email')

GO