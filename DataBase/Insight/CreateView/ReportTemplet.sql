IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ReportTemplet') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW ReportTemplet
GO


/*****视图：查询所有报表模板及其分类*****/

CREATE VIEW ReportTemplet
AS

with Category as (
  select ID, ParentId, [Index], cast(0 as bit) as IsData, Visible, Name, dbo.Get_RootAlias(ID) as Alias, CreatorDeptId, CreatorUserId
  from BASE_Category
  where ModuleId = 'DD46BA9F-A345-4CEC-AE00-26561460E470'
)

select *
from Category
union all
select T.ID, C.ID as ParentId, T.SN as [Index], cast(1 as bit) as IsData, C.Visible, T.Name, C.Alias, T.CreatorDeptId, T.CreatorUserId
from SYS_Report_Templates T
join Category C on C.ID = T.CategoryId

GO