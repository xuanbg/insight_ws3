IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_DictType') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_DictType
GO


/*****标量值函数：根据分类ID获取字典类型*****/

CREATE FUNCTION Get_DictType (
@CategoryId           UNIQUEIDENTIFIER    --分类ID
)

RETURNS NVARCHAR(32) AS
BEGIN

DECLARE @Type         NVARCHAR(32),
        @Id           UNIQUEIDENTIFIER,
        @ParentId     UNIQUEIDENTIFIER
SET     @ParentId = @CategoryId

while @ParentId is not null
  begin

  select @Id = C.ID, @CategoryId = B.ID, @ParentId = B.ParentId
  from BASE_Category C
  join BASE_Category B on B.ID = C.ParentId
  where C.ID = @CategoryId

  end

select @Type = Alias
from BASE_Category
where Id = @Id

RETURN @Type

END
GO