IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TopicList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW TopicList
GO


/*****视图：查询话题列表*****/

CREATE VIEW TopicList
AS

select case when F.ID is null then newid() else F.ID end as ID, 
       F.GroupId, T.ID as TopicId, T.Private, 
	   T.Title, V.ID as VoiceId, V.Content, 
	   V.MID as MemberId, V.Portrait, V.Agrees, T.PublishTime
from SDT_Topic T
left join SDT_Forward F on F.TopicId = T.ID
left join (
  select V.ID, V.TopicId, V.Content, M.MID, M.Portrait, isnull(count(0), 0) as Agrees
  from SDT_Voice V
  join MDG_Member M on M.MID = V.CreatorUserId
  left join SDT_Attitude A on A.VoiceId = V.ID
    and A.Type = 1
  where V.Recommend = 1
  group by V.ID, V.TopicId, V.Content, M.MID, M.Portrait
) V on V.TopicId = T.ID
where T.PublishTime is not null

GO