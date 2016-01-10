IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetTopics') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetTopics
GO


/*****表值函数：获取话题列表*****/

CREATE FUNCTION GetTopics (
@GroupId	UNIQUEIDENTIFIER,	--群组ID
@All		bit					--是否全部话题
)

RETURNS @Table TABLE (
ID			uniqueidentifier,
Private		bit,
Title		nvarchar(64),
SpeechId	uniqueidentifier,
Content		nvarchar(max),
MemberId	uniqueidentifier,
Portrait	nvarchar(64),
Agrees		int,
PublishTime	datetime
) AS

begin

declare @List table (
ID			uniqueidentifier,
Private		bit,
Title		nvarchar(64),
SpeechId	uniqueidentifier,
Content		nvarchar(max),
MemberId	uniqueidentifier,
Portrait	nvarchar(64),
Agrees		int,
PublishTime	datetime)

insert @List
select T.ID, T.Private, T.Title, S.ID as SpeechId, S.Content, S.MID as MemberId, S.Portrait, S.Agrees, T.PublishTime
from SDT_Topic T
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

if (@All = 0)
  begin
  if (@GroupId is null)
    insert @Table select T.* from @List T where T.Private = 0
  else
    insert @Table select T.* from @List T join SDT_Forward F on F.TopicId = T.ID and F.GroupId = @GroupId
  end
else
  insert @Table select * from @List

RETURN

end
GO