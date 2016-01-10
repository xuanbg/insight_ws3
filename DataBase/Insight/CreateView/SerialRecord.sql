IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SerialRecord') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW SerialRecord
GO


/*****视图：查询编码使用情况*****/

CREATE VIEW SerialRecord
AS

with List as(
select SchemeId, RelationChar as 分组标识, max(SerialNumber) + 1 as 当前流水, count(1) as 记录数, max(CreateTime) as 上次发生时间
from SYS_Code_Record
group by SchemeId, RelationChar
union all
select A.SchemeId, M.Name + '【' + U.Name + '】' as [分组/业务], max(A.AllotNumber) + 1 as 当前流水, count(1) as 记录数, max(A.UpdateTime) as 上次发生时间
from SYS_Code_Allot A
join SYS_Module M on M.ID = A.ModuleId
join SYS_User U on U.ID = A.OwnerId
where A.BusinessId is not null
group by A.SchemeId, M.Name, U.Name)

select newid() as ID, * from List

GO