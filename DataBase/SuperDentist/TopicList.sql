IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TopicList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW TopicList
GO


/*****视图：查询话题列表*****/

CREATE VIEW TopicList
AS

select case when F.ID is null then newid() else F.ID end as ID, 
       F.GroupId, T.ID as TopicId, T.Private, 
	   T.Title, S.ID as VoiceId, S.Content, 
	   S.MID as MemberId, S.Portrait, S.Agrees, T.PublishTime
from SDT_Topic T
left join SDT_Forward F on F.TopicId = T.ID
left join (
  select S.ID, S.TopicId, S.Content, M.MID, M.Portrait, isnull(A.Agrees, 0) as Agrees
  from SDT_Speech S
  join MDG_Member M on M.MID = S.CreatorUserId
  left join (
    select SpeechId, count(0) as Agrees
    from SDT_Attitude
    where Type = 1
    group by SpeechId) A on A.SpeechId = S.ID
  where S.Validity = 1
    and S.Recommend = 1) S on S.TopicId = T.ID
where T.Validity = 1
  and T.PublishTime is not null

GO