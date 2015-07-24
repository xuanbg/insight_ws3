IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Citys') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Citys
GO


/*****视图：查询地市*****/

CREATE VIEW Citys
AS

select C.ID, C.ParentId, C.[Index], C.Name
from BASE_Category C
join BASE_Category S on S.ID = C.ParentId
join BASE_Category T on T.ID = S.ParentId
where T.Alias = 'Region'

GO