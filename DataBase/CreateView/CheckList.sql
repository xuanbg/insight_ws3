IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'CheckList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW CheckList
GO


/*****��ͼ����ѯ���ö��*****/

CREATE VIEW CheckList
AS

select M.MID, D.ID as MemberId, '��ҵ�ͻ�' as �ͻ�����, D.Alias as �ֻ���, D.Name as ����, M.IdCardNo as ���֤��, M.CompanyName as [������λ/ѧУ], M.Loans as ���Ŷ��, '������Ϣ' as �������,
case M.Status when 0 then '���˻�' when 1 then 'δ�ύ' when 2 then '�����' when 3 then '�����' else '�Ѿܾ�' end as ״̬, M.CreateTime, M.Status, M.VerifyUserId
from MasterData D
join MDG_EntMember M on M.MID = D.ID

GO