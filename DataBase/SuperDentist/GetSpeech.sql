IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetSpeech') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetSpeech
GO


/*****表值函数：获取发言详情*****/

CREATE FUNCTION GetSpeech (
@SpeechId              UNIQUEIDENTIFIER,    --发言ID
@UserId                UNIQUEIDENTIFIER     --用户ID
)

RETURNS TABLE AS
RETURN

select S.ID, T.Title, S.Content, S.CaseId,
M.MID as MemberId, D.Name, M.Signature, M.Portrait,
isnull(A.Agrees, 0) as Agrees, isnull(A.Praise, 0) as Praise,
isnull(A.IsAgrees, 0) as IsAgrees, isnull(A.IsOppose, 0) as IsOppose,
isnull(A.IsPraise, 0) as IsPraise, isnull(A.IsReport, 0) as IsReport,
cast(case when F.ID is null then 0 else 1 end as bit) as IsCare, S.PublishTime
from SDT_Speech S
join SDT_Topic T on T.ID = S.TopicId
join MasterData D on D.ID = S.CreatorUserId
join MDG_Member M on M.MID = S.CreatorUserId
left join (
  select SpeechId,
  sum(case Type when 1 then 1 else 0 end) as Agrees,
  sum(case Type when 3 then 1 else 0 end) as Praise,
  cast(sum(case when Type = 1 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsAgrees,
  cast(sum(case when Type = 2 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsOppose,
  cast(sum(case when Type = 3 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsPraise,
  cast(sum(case when Type = 4 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsReport
  from SDT_Attitude
  group by SpeechId) A on A.SpeechId = S.ID
left join (
  select SpeechId, count(0) as Comments
  from SDT_Comment
  where Validity = 1
  group by SpeechId) C on C.SpeechId = S.ID
left join MDE_Favorites F on F.ObjectId = S.ID
  and F.CreatorUserId = @UserId
where S.ID = @SpeechId
  and S.Validity = 1
  and S.PublishTime is not null

GO