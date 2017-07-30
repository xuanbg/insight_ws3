IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Customer') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Customer
GO


/*****��ͼ����ѯ���пͻ�*****/

CREATE VIEW Customer
AS

select distinct M.ID as CustomerId, S.Name as ״̬, L.Name as Class,
C.Enable, U.Name as �ͻ�����, M.Name as ����, M.Alias as ���, C.BusinessScope as ��Ӫ��Χ, C.Scale + '��' as �ʲ���ģ,
C.Staffs as Ա������, P.Name + case when T.Name = '��Ͻ��' or T.Name = '��' then '' else T.Name end + D.Name + C.Address as ��ַ, C.ZipCode as �ʱ�
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