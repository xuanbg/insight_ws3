USE Insight_Report
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ReportSchedular') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW ReportSchedular
GO


/*****视图：查询报表生成任务*****/

CREATE VIEW ReportSchedular
AS
with List as(
select distinct S.ID as SchedularId, S.ReportId, D.TemplateId, S.BuildTime, dbo.Get_NextDate(S.BuildTime, R.CycleType, R.Cycle) as NextDate,
       case when D.Mode > 1 and D.Delay > 0 then null else dbo.Get_StartDate(S.BuildTime, D.Delay, R.CycleType, R.Cycle) end as StartDate,
       case when D.Mode > 1 and D.Delay < 0 then null else dbo.Get_EndDate(S.BuildTime, D.Delay, R.CycleType, R.Cycle) end as EndDate,
       O.FullName as DeptName,
       O.ID as DeptId, case when D.Type = 1 then null else RU.UserId end as UserId
from SYS_Report_Schedular S
join SYS_Report_Definition D on D.ID = S.ReportId
join SYS_Report_Rules R on R.ID = S.RuleId
join SYS_Report_Entity E on E.ReportId = D.ID
join SYS_Organization O on O.ID = E.OrgId
join SYS_Report_Member M on M.EntityId = E.ID
join RoleUser RU on RU.RoleId = M.RoleId)

select newid() as ID, * from List

GO