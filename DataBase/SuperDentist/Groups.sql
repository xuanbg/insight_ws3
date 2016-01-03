IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Groups') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Groups
GO


/*****视图：查询群组列表*****/

CREATE VIEW Groups
AS

select G.ID, G.Name, G.Description, G.Icon, G.Picture, G.Heat, 
isnull(T.Topics, 0) as Topics, isnull(M.Members, 0) as Members,
isnull(F.Favorites, 0) as Favorites, G.OwnerUserId, G.ManageUserId
from SDG_Group G
left join (
  select GroupId, count(0) as Topics
  from SDT_Forward
  group by GroupId) T on T.GroupId = G.ID
left join (
  select GroupId, count(0) as Members
  from SDG_GroupMember
  where Validity = 1
  group by GroupId) M on M.GroupId = G.ID
left join (
  select ObjectId, count(0) as Favorites
  from MDE_Favorites
  where Type = 1
  group by ObjectId) F on F.ObjectId = G.ID
where G.Validity = 1

GO