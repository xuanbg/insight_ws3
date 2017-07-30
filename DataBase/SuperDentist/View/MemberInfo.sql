IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MemberInfo') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW MemberInfo
GO


/*****视图：查询会员信息*****/

CREATE VIEW MemberInfo
AS

select D.ID, D.Name, D.Alias, M.Signature, M.Portrait, M.Integral, M.Beans, S.Unread
from MasterData D
join MDG_Member M on M.MID = D.ID
left join (
  select ReceiveUserId, count(0) as Unread
  from MDE_Message
  where HaveRead = 0
    and SendTime is not null
  group by ReceiveUserId) S on S.ReceiveUserId = D.ID

GO