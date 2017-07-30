IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetComments') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetComments
GO


/*****表值函数：获取评论列表*****/

CREATE FUNCTION GetComments (
@SpeechId              UNIQUEIDENTIFIER,    --发言ID
@UserId                UNIQUEIDENTIFIER     --用户ID
)

RETURNS TABLE AS
RETURN

select C.ID, C.Content, D.ID as MemberId, D.Name, M.Portrait, isnull(P.Praise, 0) as Praise,
isnull(P.IsPraise, 0) as IsPraise, isnull(P.IsReport, 0) as IsReport, C.PublishTime
from SDT_Comment C
join MasterData D on D.ID = C.CreatorUserId
join MDG_Member M on M.MID = C.CreatorUserId
left join (
  select CommentId,
  sum(case Type when 1 then 1 else 0 end) as Praise,
  cast(sum(case when Type = 1 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsPraise,
  cast(sum(case when Type = 2 and CreatorUserId = @UserId then 1 else 0 end) as bit) as IsReport
  from SDT_Praise
  group by CommentId) P on P.CommentId = C.ID
where C.SpeechId = @SpeechId
  and C.Validity = 1
  and C.PublishTime is not null

GO