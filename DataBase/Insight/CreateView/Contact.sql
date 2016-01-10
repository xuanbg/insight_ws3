IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Contact') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Contact
GO


/*****视图：查询所有联系人*****/

CREATE VIEW Contact
AS

select M.ID, M.ParentId, M.Name + case when E.Gender = 0 then '(女士)' when E.Gender = 1 then '(先生)' else '' end as 姓名, E.Department as 任职部门,
E.Title as 职务, stuff(convert(varchar(5), E.Birthday, 100), 3, 1, '月') + '日' as 生日, case when E.LoginUser = 1 then '是' else '否' end as 登录,
M.Alias as 登录帐号, case when E.IsMaster = 1 then '是' else '否' end as 主要联系人, T.Number as 电话号码, P.Number as 移动电话, A.Number as 电子邮件,
E.OfficeAddress as 办公地点, E.HomeAddress as 家庭住址, E.Description as 备注
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