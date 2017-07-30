IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Customer') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Customer
GO


/*****视图：查询所有客户*****/

CREATE VIEW Customer
AS

select distinct M.ID as CustomerId, S.Name as 状态, L.Name as Class,
C.Enable, U.Name as 客户经理, M.Name as 名称, M.Alias as 简称, C.BusinessScope as 经营范围, C.Scale + '万' as 资产规模,
C.Staffs as 员工人数, P.Name + case when T.Name = '市辖区' or T.Name = '县' then '' else T.Name end + D.Name + C.Address as 地址, C.ZipCode as 邮编
from MasterData M
join MDG_Customer C on C.MID = M.ID
  and C.Visible = 1
join MDR_MU R on R.MasterDataId = M.ID
join SYS_User U on U.ID = R.UserId
  and R.FailureDate is null
  and R.IsMaster = 1
left join BASE_Category P on P.ID = C.Province
left join BASE_Category T on T.ID = C.City
left join MasterData D on D.ID = C.District
left join MasterData S on S.ID = C.Statu
left join MasterData L on L.ID = C.Class

GO