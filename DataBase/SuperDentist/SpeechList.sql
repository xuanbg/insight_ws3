IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SpeechList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW SpeechList
GO


/*****视图：查询发言列表*****/

CREATE VIEW SpeechList
AS

select S.ID, S.TopicId, S.Content, S.Recommend,
M.MID as MemberId, D.Name, M.Signature, M.Portrait,
isnull(A.Agrees, 0) as Agrees, S.PublishTime
from SDT_Speech S
join MasterData D on D.ID = S.CreatorUserId
join MDG_Member M on M.MID = S.CreatorUserId
left join (
  select SpeechId, count(0) as Agrees
  from SDT_Attitude
  where Type = 1
  group by SpeechId) A on A.SpeechId = S.ID
where S.Validity = 1
  and S.PublishTime is not null

GO