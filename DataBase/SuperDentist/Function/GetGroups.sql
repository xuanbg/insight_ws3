IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetGroups') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetGroups
GO


/*****表值函数：获取群组列表*****/

CREATE FUNCTION GetGroups (
@UserId                UNIQUEIDENTIFIER     --用户ID
)

RETURNS TABLE AS
RETURN

select G.*,
cast(case when M.ID is null then 0 else 1 end as bit) as IsJoin,
isnull(cast(case when F.ID is null then 0 else 1 end as bit), 0) as IsCare
from Groups G
left join SDG_GroupMember M on M.GroupId = G.ID
  and M.MemberId = @UserId
  and M.Validity = 1
left join MDE_Favorites F on F.ObjectId = G.ID

GO