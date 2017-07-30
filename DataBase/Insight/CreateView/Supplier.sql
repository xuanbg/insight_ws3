IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Supplier') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Supplier
GO


/*****视图：查询所有客户*****/

CREATE VIEW Supplier
AS

select distinct M.ID as SupplierId,
case when C.Enable = 1 then '正常' else '停用' end as 状态, U.Name as 采购经理, M.Name as 名称, M.Alias as 简称, C.BusinessScope as 经营范围, C.Scale + '万' as 资产规模,
C.Staffs as 员工人数, P.Name + case when T.Name = '市辖区' or T.Name = '县' then '' else T.Name end + D.Name + C.Address as 地址, C.ZipCode as 邮编
from MasterData M
join MDG_Supplier C on C.MID = M.ID
  and C.Visible = 1
join MDR_MU R on R.MasterDataId = M.ID
join SYS_User U on U.ID = R.UserId
  and R.FailureDate is null
  and R.IsMaster = 1
left join BASE_Category P on P.ID = C.Province
left join BASE_Category T on T.ID = C.City
left join MasterData D on D.ID = C.District

GO