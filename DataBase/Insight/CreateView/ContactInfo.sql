IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ContactInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW ContactInfo
GO


/*****视图：查询所有联系人*****/

CREATE VIEW ContactInfo
AS

select T.ID, T.MasterDataId, D.Alias, D.Name as 联系方式, T.Number as 号码, T.IsMaster as 主要
from MDS_Contact_Info T
join MasterData D on D.ID = T.InfoTypeId

GO