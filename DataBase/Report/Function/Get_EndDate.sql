USE Insight_Report
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_EndDate') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_EndDate
GO


/*****����ֵ��������������ʱ�䡢���ں���ʱ�����ֹ����*****/

CREATE FUNCTION Get_EndDate(
@BuildTime             DateTime,       --����ʱ��
@Delay                 Int,            --��ʱ
@Type                  Int,            --��������
@Cycle                 Int             --��������
)

RETURNS DateTime AS
BEGIN

DECLARE @EndDate     DateTime,
        @Real_Time     DateTime

set @Real_Time = dateadd(day, -1, dateadd(hour, -@Delay, @BuildTime))
set @Cycle = case when @Delay < 0 then @Cycle else 0 end

if @Type = 1
  set @EndDate = dateadd(year, @Cycle, @Real_Time)
else if @Type = 2
  set @EndDate = dateadd(month, @Cycle, @Real_Time)
else if @Type = 3
  set @EndDate = dateadd(week, @Cycle, @Real_Time)
else if @Type = 4
  set @EndDate = dateadd(day, @Cycle, @Real_Time)

RETURN @EndDate
END

GO