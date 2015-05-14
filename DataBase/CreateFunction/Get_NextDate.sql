IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_NextDate') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_NextDate
GO


/*****标量值函数：根据生成时间和周期计算下次生成时间*****/

CREATE FUNCTION Get_NextDate(
@BuildTime             DateTime,       --生成时间
@Type                  Int,            --周期类型
@Cycle                 Int             --周期数量
)

RETURNS DateTime AS
BEGIN

DECLARE @NextDate     DateTime

if @Type = 1
  set @NextDate = dateadd(year, @Cycle, @BuildTime)
else if @Type = 2
  set @NextDate = dateadd(month, @Cycle, @BuildTime)
else if @Type = 3
  set @NextDate = dateadd(week, @Cycle, @BuildTime)
else if @Type = 4
  set @NextDate = dateadd(day, @Cycle, @BuildTime)

RETURN @NextDate
END

GO