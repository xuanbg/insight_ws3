IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'CheckList') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW CheckList
GO


/*****视图：查询可用额度*****/

CREATE VIEW CheckList
AS

select M.MID, D.ID as MemberId, '行业客户' as 客户类型, D.Alias as 手机号, D.Name as 姓名, M.IdCardNo as 身份证号, M.CompanyName as [工作单位/学校], M.Loans as 授信额度, '基本信息' as 审核内容,
case M.Status when 0 then '已退回' when 1 then '未提交' when 2 then '待审核' when 3 then '已审核' else '已拒绝' end as 状态, M.CreateTime, M.Status, M.VerifyUserId
from MasterData D
join MDG_EntMember M on M.MID = D.ID

GO