USE Insight_Report
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_StartDate') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_StartDate
GO


/*****标量值函数：根据生成时间、周期和延时计算开始日期*****/

CREATE FUNCTION Get_StartDate(
@BuildTime             DateTime,       --生成时间
@Delay                 Int,            --延时
@Type                  Int,            --周期类型
@Cycle                 Int             --周期数量
)

RETURNS DateTime AS
BEGIN

DECLARE @StartDate     DateTime,
        @Real_Time     DateTime

set @Real_Time = dateadd(hour, -@Delay, @BuildTime)
set @Cycle = case when @Delay < 0 then 0 else -@Cycle end

if @Type = 1
  set @StartDate = dateadd(year, @Cycle, @Real_Time)
else if @Type = 2
  set @StartDate = dateadd(month, @Cycle, @Real_Time)
else if @Type = 3
  set @StartDate = dateadd(week, @Cycle, @Real_Time)
else if @Type = 4
  set @StartDate = dateadd(day, @Cycle, @Real_Time)

RETURN @StartDate
END

GO