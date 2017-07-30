IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SupplierInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW SupplierInfo
GO


/*****��ͼ����ѯ���пͻ���ϸ��Ϣ*****/

CREATE VIEW SupplierInfo
AS

select M.ID as SupplierId, M.Code as ��Ӧ�̱��, S.Name as ���ڹ���, E.Name as ��ҵ����, I.Name as ��ҵ����, C.RegisterNumber as ִ��ע���, C.TaxNumber as ˰��ǼǺ�,
C.Corporation as ���˴���, C.RegisterDate as ��ҵ����, C.Phone as ��ϵ�绰, C.Website as �ٷ���վ, C.Description as ��ע��Ϣ
from MasterData M
join MDG_Supplier C on C.MID = M.ID
join MasterData S on S.ID = C.State
left join MasterData E on E.ID = C.EnterpriseType
left join MasterData I on I.ID = C.IndustryType

GO