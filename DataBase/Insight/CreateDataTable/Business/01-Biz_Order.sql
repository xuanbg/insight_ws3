
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Order_Subjects') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Order_Subjects
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Order') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Order
GO


/*****订单扩展表*****/

/*****订单扩展表*****/

CREATE TABLE BIZ_Order(
[OID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Order PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Channel]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --销售渠道ID，字典
[Contact]          NVARCHAR(8),                                                                                                            --联系电话
[Phone]            NVARCHAR(64),                                                                                                           --联系电话
[Address]          NVARCHAR(64),                                                                                                           --送货地址
)
GO

/*****订单标的扩展表*****/

CREATE TABLE BIZ_Order_Subjects(
[SID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Order_Subjects PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SubjectType]      INT DEFAULT 0 NOT NULL,                                                                                                 --标的类型：1、产品；2、配件；3、服务
[Model]            NVARCHAR(32),                                                                                                           --型号
[Size]             NVARCHAR(32),                                                                                                           --规格
[Color]            NVARCHAR(64),                                                                                                           --颜色
[Caliber]          NVARCHAR(64),                                                                                                           --口径
[FeedMode]         NVARCHAR(64),                                                                                                           --进水方式
)
GO

