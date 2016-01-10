IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Supplier') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Supplier
GO


/*****��ͼ����ѯ���пͻ�*****/

CREATE VIEW Supplier
AS

select distinct M.ID as SupplierId,
case when C.Enable = 1 then '����' else 'ͣ��' end as ״̬, U.Name as �ɹ�����, M.Name as ����, M.Alias as ���, C.BusinessScope as ��Ӫ��Χ, C.Scale + '��' as �ʲ���ģ,
C.Staffs as Ա������, P.Name + case when T.Name = '��Ͻ��' or T.Name = '��' then '' else T.Name end + D.Name + C.Address as ��ַ, C.ZipCode as �ʱ�
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