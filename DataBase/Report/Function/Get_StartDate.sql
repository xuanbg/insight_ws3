USE Insight_Report
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_StartDate') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_StartDate
GO


/*****����ֵ��������������ʱ�䡢���ں���ʱ���㿪ʼ����*****/

CREATE FUNCTION Get_StartDate(
@BuildTime             DateTime,       --����ʱ��
@Delay                 Int,            --��ʱ
@Type                  Int,            --��������
@Cycle                 Int             --��������
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