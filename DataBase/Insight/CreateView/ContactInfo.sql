IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ContactInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW ContactInfo
GO


/*****��ͼ����ѯ������ϵ��*****/

CREATE VIEW ContactInfo
AS

select T.ID, T.MasterDataId, D.Alias, D.Name as ��ϵ��ʽ, T.Number as ����, T.IsMaster as ��Ҫ
from MDS_Contact_Info T
join MasterData D on D.ID = T.InfoTypeId

GO