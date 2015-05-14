IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_Eff_Time') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_Eff_Time
GO


/*****标量值函数：根据周期类型和开始日期计算最近有效日期*****/

CREATE FUNCTION Get_Eff_Time(
@StartTime             DateTime,       --开始日期
@Type                  Int,            --周期类型
@Cycle                 Int             --周期数量
)

RETURNS DateTime AS
BEGIN

DECLARE @Get_Eff_Time  DateTime,
        @Real_Time     DateTime,
        @Start_Minute  Int,
        @Start_Hour    Int,
        @Start_Day     Int,
        @Start_Week    Int,
        @Start_Month   Int,
        @Cur_Minute    Int,
        @Cur_Hour      Int,
        @Cur_Day       Int,
        @Cur_Week      Int,
        @Cur_Month     Int

SET     @Start_Minute   = datepart(minute, @StartTime)
SET     @Start_Hour     = datepart(hour, @StartTime)
SET     @Start_Day      = datepart(day, @StartTime)
SET     @Start_Week     = datepart(weekday, @StartTime)
SET     @Start_Month    = datepart(month, @StartTime)
SET     @Cur_Minute     = datepart(minute, getdate())
SET     @Cur_Hour       = datepart(hour, getdate())
SET     @Cur_Day        = datepart(day, getdate())
SET     @Cur_Week       = datepart(weekday, getdate())
SET     @Cur_Month      = datepart(month, getdate())
SET     @Real_Time      = case when @Type = 1 then dateadd(year, case when @Start_Month > @Cur_Month then 1 when @Start_Month = @Cur_Month then case when @Start_Day > @Cur_Day then 1 else 0 end else 0 end, @StartTime)
                               when @Type = 2 then dateadd(month, case when @Start_Day > @Cur_Day then 1 else 0 end, @StartTime)
                               when @Type = 3 then dateadd(week, case when @Start_Week > @Cur_Week then 1 else 0 end, @StartTime)
                               else dateadd(day, case when @Start_Hour > @Cur_Hour then 1 when @Start_Hour = @Cur_Hour then case when @Start_Minute > @Cur_Minute then 1 else 0 end else 0 end, @StartTime)
                               end

if @Type = 1
  set @Get_Eff_Time = dateadd(year, ceiling(datediff(year,@Real_Time, getdate())/@Cycle) * @Cycle + @Cycle, @StartTime)
else if @Type = 2
  set @Get_Eff_Time = dateadd(month, ceiling(datediff(month,@Real_Time, getdate())/@Cycle) * @Cycle + @Cycle, @StartTime)
else if @Type = 3
  set @Get_Eff_Time = dateadd(week, ceiling(datediff(week,@Real_Time, getdate())/@Cycle) * @Cycle + @Cycle, @StartTime)
else if @Type = 4
  set @Get_Eff_Time = dateadd(day, ceiling(datediff(day,@Real_Time, getdate())/@Cycle) * @Cycle + @Cycle, @StartTime)

RETURN @Get_Eff_Time
END

GO