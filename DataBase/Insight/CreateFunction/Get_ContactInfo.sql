IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Get_ContactInfo') AND OBJECTPROPERTY(id, N'ISSCALARFUNCTION') = 1)
DROP FUNCTION Get_ContactInfo
GO


/*****����ֵ��������ȡĿ�������ʼ���ַ���ֻ���*****/

CREATE FUNCTION Get_ContactInfo(
@ObjectId              UNIQUEIDENTIFIER,    --Ŀ�����ID������������ID)
@Type                  INT             --��ϵ��ʽ��0�������ʼ���1������
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