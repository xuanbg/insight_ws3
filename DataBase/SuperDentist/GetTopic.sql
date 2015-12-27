IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetTopic') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetTopic
GO


/*****表值函数：获取话题详情*****/

CREATE FUNCTION GetTopic (
@UserId                UNIQUEIDENTIFIER,    --用户ID
@TopicId               UNIQUEIDENTIFIER     --话题ID
)

RETURNS TABLE AS
RETURN

select T.ID, T.Title, T.Description, T.CaseId, T.Private, T.PublishTime,
cast(case when F.ID is null then 0 else 1 end as bit) as IsCare
from SDT_Topic T
left join MDE_Favorites F on F.ObjectId = T.ID
  and F.CreatorUserId = @UserId
where T.ID = @TopicId

GO