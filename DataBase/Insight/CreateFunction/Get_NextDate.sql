IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_NextDate') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_NextDate
GO


/*****����ֵ��������������ʱ������ڼ����´�����ʱ��*****/

CREATE FUNCTION Get_NextDate(
@BuildTime             DateTime,       --����ʱ��
@Type                  Int,            --��������
@Cycle                 Int             --��������
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