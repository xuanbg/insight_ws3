IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'OrderList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW OrderList
GO


/*****��ͼ����ѯ�����б�*****/

CREATE VIEW OrderList
AS

select C.ID, C.ObjectId as MemberId, S.ID as SubjectId, PS.ProductName, PS.ProductSpeci, isnull(PS.ProductPrice, 0) as ProductPrice, isnull(O.OrderAmount, 0) as OrderAmount, isnull(O.FirstPay, 0) as FirstPay, isnull(O.StageAmount, 0) as StageAmount, PS.ProductImage, O.StagePlan, C.CreateTime, 
case C.Status when 1 then 'δ����' when 2 then '�Ѹ���' when 3 then '�ѹ鵵' when 4 then '������' when 5 then '��ȷ��' when 6 then '�ѷ���' when 7 then '���˻�' when 8 then '���˿�' else '�ݸ�' end as Status
from ABS_Contract C
join BIZ_Order O on O.OID = C.ID
join ABS_Contract_Subjects S on S.ContractId = C.ID
join BIZ_Product_Snapshot PS on PS.SID = S.ID

GO