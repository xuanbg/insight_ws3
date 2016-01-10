IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SerialRecord') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW SerialRecord
GO


/*****��ͼ����ѯ����ʹ�����*****/

CREATE VIEW SerialRecord
AS

with List as(
select SchemeId, RelationChar as �����ʶ, max(SerialNumber) + 1 as ��ǰ��ˮ, count(1) as ��¼��, max(CreateTime) as �ϴη���ʱ��
from SYS_Code_Record
group by SchemeId, RelationChar
union all
select A.SchemeId, M.Name + '��' + U.Name + '��' as [����/ҵ��], max(A.AllotNumber) + 1 as ��ǰ��ˮ, count(1) as ��¼��, max(A.UpdateTime) as �ϴη���ʱ��
from SYS_Code_Allot A
join SYS_Module M on M.ID = A.ModuleId
join SYS_User U on U.ID = A.OwnerId
where A.BusinessId is not null
group by A.SchemeId, M.Name, U.Name)

select newid() as ID, * from List

GO