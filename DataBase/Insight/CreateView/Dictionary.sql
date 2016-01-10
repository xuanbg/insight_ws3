IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Dictionary') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Dictionary
GO


/*****视图：查询所有字典数据（带分类）*****/

CREATE VIEW Dictionary
AS

select C.ID, C.ParentId, C.[Index], cast(0 as bit) as [IsData], dbo.Get_DictType(C.ID) as [Type], C.Code, C.Name, C.Alias, null as BuiltIn, null as CreatorDeptId, C.CreatorUserId 
from BASE_Category C
join BASE_Category B on B.ID = C.ParentId
where C.ModuleId = '5C801552-1905-452B-AE7F-E57227BE70B8'
  and B.ParentId is not null
union all

select M.ID,
       case when M.ParentId is null then CategoryId else ParentId end as ParentId,
       D.[Index],
	   cast(1 as bit) as [IsData],
       D.[Type],
       M.Code,
       M.Name,
       M.Alias,
	   D.BuiltIn,
       D.CreatorDeptId,
       D.CreatorUserId
from MasterData M
join MDG_Dictionary D on D.MID = M.ID
  and D.Enable = 1

GO