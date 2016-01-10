IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_RootAlias') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_RootAlias
GO


/*****标量值函数：获取根分类简称*****/

CREATE FUNCTION Get_RootAlias (
@CategoryId                UNIQUEIDENTIFIER     --分类ID
)

RETURNS NVARCHAR(16) AS
BEGIN

DECLARE @Alias        NVARCHAR(16)
DECLARE @ParentId     UNIQUEIDENTIFIER
SET @ParentId = @CategoryId

while @ParentId is not null
  begin
  select @Alias = Alias, @ParentId = ParentId from BASE_Category where ID = @CategoryId
  if @ParentId is not null
    set @CategoryId = @ParentId
  end

RETURN @Alias
END

GO