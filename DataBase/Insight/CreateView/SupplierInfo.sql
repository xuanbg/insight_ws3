IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SupplierInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW SupplierInfo
GO


/*****视图：查询所有客户详细信息*****/

CREATE VIEW SupplierInfo
AS

select M.ID as SupplierId, M.Code as 供应商编号, S.Name as 所在国家, E.Name as 企业类型, I.Name as 行业类型, C.RegisterNumber as 执照注册号, C.TaxNumber as 税务登记号,
C.Corporation as 法人代表, C.RegisterDate as 开业日期, C.Phone as 联系电话, C.Website as 官方网站, C.Description as 备注信息
from MasterData M
join MDG_Supplier C on C.MID = M.ID
join MasterData S on S.ID = C.State
left join MasterData E on E.ID = C.EnterpriseType
left join MasterData I on I.ID = C.IndustryType

GO