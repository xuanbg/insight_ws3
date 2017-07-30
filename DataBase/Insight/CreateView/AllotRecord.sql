IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'AllotRecord') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW AllotRecord
GO


/*****视图：查询编码分配记录*****/

CREATE VIEW AllotRecord
AS

select R.ID, R.SN, R.SchemeId, case when isnull(A.Number, '') >= R.StartNumber then '已用' else '未用' end as 状态, M.Name + '单据' as 单据类型, U.Name as 制单人员, R.StartNumber + ' - ' + R.EndNumber as 编码区段, R.CreateTime as 分配日期
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