IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'AllotRecord') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW AllotRecord
GO


/*****��ͼ����ѯ��������¼*****/

CREATE VIEW AllotRecord
AS

select R.ID, R.SN, R.SchemeId, case when isnull(A.Number, '') >= R.StartNumber then '����' else 'δ��' end as ״̬, M.Name + '����' as ��������, U.Name as �Ƶ���Ա, R.StartNumber + ' - ' + R.EndNumber as ��������, R.CreateTime as ��������
from SYS_Allot_Record R
join SYS_User U on U.ID = R.OwnerId 
join SYS_Module M on M.ID = R.ModuleId
left join (
  select ModuleId, OwnerId, max(AllotNumber) as Number 
  from SYS_Code_Allot
  where BusinessId is not null
  group by ModuleId, OwnerId) A on A.ModuleId = R.ModuleId
    and A.OwnerId = R.OwnerId

GO