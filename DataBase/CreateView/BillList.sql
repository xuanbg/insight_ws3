IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BillList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW BillList
GO


/*****��ͼ����ѯ�˵��б�*****/

CREATE VIEW BillList
AS

select 
F.ID, --�˵�ID
F.ContractId, --����ID
F.Description, --�˵��������� x �ڣ�
isnull(F.Amount - isnull(P.Perform, 0), 0) as Amount, --�軹����
O.Interest, --�����
isnull(case when datediff(day, F.EndDate, getdate()) > 7 then (F.Amount - isnull(P.Perform, 0)) * 0.005 * datediff(day, F.EndDate, getdate()) else 0 end, 0) as Liquidated, --ΥԼ��
F.EndDate, --�����ֹ����
isnull(P.Perform, 0) as Perform, --�ѻ����
P.PerformDate --��������
from ABS_Contract_FundPlan F
join ABS_Contract C on C.ID = F.ContractId
  and C.Status not in (6, 7, 8, 9)
join BIZ_Order O on O.OID = C.ID
left join (
  select PlanId, sum(Amount) as Perform, max(CreateTime) as PerformDate
  from ABS_Contract_FundPerform
  group by PlanId) P on P.PlanId = F.ID

GO