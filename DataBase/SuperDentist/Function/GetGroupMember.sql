IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'GetGroupMember') AND OBJECTPROPERTY(id, N'ISTABLEFUNCTION') = 1)
DROP FUNCTION GetGroupMember
GO


/*****表值函数：获取群组列表*****/

CREATE FUNCTION GetGroupMember (
@UserId                UNIQUEIDENTIFIER,     --用户ID
@Type                  BIT                   --是否成员
)

RETURNS TABLE AS
RETURN

select G.ID, D.Name, M.Signature, M.Portrait
from SDG_GroupMember G
join MasterData D on D.ID = G.MemberId
join MDG_Member M on M.MID = D.ID
where G.MemberId = @UserId
  and G.Validity = @Type

GO