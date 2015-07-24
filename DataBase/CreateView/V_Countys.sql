IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Countys') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Countys
GO


/*****视图：查询县市*****/

CREATE VIEW Countys
AS

select M.ID, M.CategoryId, M.Name
from MasterData M
join BASE_Category C on C.ID = M.CategoryId
join BASE_Category S on S.ID = C.ParentId
join BASE_Category T on T.ID = S.ParentId
where T.Alias = 'Region'

GO