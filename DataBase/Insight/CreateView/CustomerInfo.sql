IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'CustomerInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW CustomerInfo
GO


/*****��ͼ����ѯ���пͻ���ϸ��Ϣ*****/

CREATE VIEW CustomerInfo
AS

select M.ID as CustomerId, M.Code as �ͻ����, S.Name as ���ڹ���, E.Name as ��ҵ����, I.Name as ��ҵ����, C.RegisterNumber as ִ��ע���, C.TaxNumber as ˰��ǼǺ�,
C.Corporation as ���˴���, C.RegisterDate as ��ҵ����, C.Phone as ��ϵ�绰, C.Website as �ٷ���վ, C.Description as ��ע��Ϣ
from MasterData M
join MDG_Customer C on C.MID = M.ID
join MasterData S on S.ID = C.State
left join MasterData E on E.ID = C.EnterpriseType
left join MasterData I on I.ID = C.IndustryType

GO