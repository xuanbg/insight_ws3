IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'States') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW States
GO


/*****视图：查询省份*****/

CREATE VIEW States
AS

select S.ID, S.[Index], S.Name
from BASE_Category S
join BASE_Category T on T.ID = S.ParentId
where T.Alias = 'Region'

GO