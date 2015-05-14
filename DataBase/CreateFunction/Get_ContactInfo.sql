IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_ContactInfo') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_ContactInfo
GO


/*****标量值函数：获取目标对象的邮件地址或手机号*****/

CREATE FUNCTION Get_ContactInfo(
@ObjectId              UNIQUEIDENTIFIER,    --目标对象ID（主数据索引ID)
@Type                  INT             --联系方式：0、电子邮件；1、短信
)

RETURNS NVARCHAR(32) AS
BEGIN

DECLARE @ObjectType    UNIQUEIDENTIFIER
DECLARE @ContactInfo   VARCHAR(32)

select @ContactInfo = I.Number
from MDS_Contact_Info I
join MasterData M on M.ID = I.InfoTypeId
  and M.Alias = case when @Type = 0 then 'Email' else 'Mobile' end
where I.MasterDataId = @ObjectId

RETURN @ContactInfo
END
GO