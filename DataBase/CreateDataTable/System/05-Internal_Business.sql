IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Travel_Plan') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Travel_Plan
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Travel_Apply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Travel_Apply
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Reimburse_Detail') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Reimburse_Detail
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Reimburse_Apply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Reimburse_Apply
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Borrowing_Apply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Borrowing_Apply
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Refund_Detail') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Refund_Detail
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Refund_Apply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Refund_Apply
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Code_Allot') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Code_Allot
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Code_Record') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Code_Record
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Allot_Record') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Allot_Record
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Code_Scheme') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Code_Scheme
GO


/*****编码方案*****/

/*****编码方案表*****/

CREATE TABLE SYS_Code_Scheme(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Code_Scheme PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[CodeFormat]       NVARCHAR(64) NOT NULL,                                                                                                  --编码格式
[SerialFormat]     NVARCHAR(16),                                                                                                           --流水码关联字符串格式
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****编码分配记录表*****/

CREATE TABLE SYS_Allot_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Allot_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SchemeId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Code_Scheme(ID) ON DELETE CASCADE NOT NULL,                                 --编码方案ID
[ModuleId]         UNIQUEIDENTIFIER NOT NULL,                                                                                              --模块注册ID
[OwnerId]          UNIQUEIDENTIFIER NOT NULL,                                                                                              --用户ID
[StartNumber]      VARCHAR(8),                                                                                                             --编码区段起始值
[EndNumber]        VARCHAR(8),                                                                                                             --编码区段结束值
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)

/*****编码流水记录表*****/

CREATE TABLE SYS_Code_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Code_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SchemeId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Code_Scheme(ID) ON DELETE CASCADE NOT NULL,                                 --编码方案ID
[RelationChar]     NVARCHAR(16),                                                                                                           --关联字符串
[SerialNumber]     INT NOT NULL,                                                                                                           --流水号
[BusinessId]       UNIQUEIDENTIFIER,                                                                                                       --业务记录ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Record_Serial ON SYS_Code_Record(SchemeId, RelationChar) INCLUDE (SerialNumber)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Record_BusinessId ON SYS_Code_Record(BusinessId)
GO

/*****编码分配记录表*****/

CREATE TABLE SYS_Code_Allot(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Code_Allot PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SchemeId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Code_Scheme(ID) ON DELETE CASCADE NOT NULL,                                 --编码方案ID
[ModuleId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Module(ID) ON DELETE CASCADE NOT NULL,                                      --模块注册ID
[OwnerId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --用户ID
[AllotNumber]      VARCHAR(8) NOT NULL,                                                                                                    --分配流水号
[BusinessId]       UNIQUEIDENTIFIER,                                                                                                       --业务记录ID
[UpdateTime]       DATETIME,                                                                                                               --使用时间
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Allot_Serial ON SYS_Code_Allot(SchemeId, ModuleId, OwnerId) INCLUDE (AllotNumber)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Allot_BusinessId ON SYS_Code_Allot(BusinessId)
GO


/*****内置业务：退款业务数据表*****/

/*****退款申请（契约扩展）表*****/

CREATE TABLE BIZ_Refund_Apply(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Refund_Apply PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Abs_Clearing(ID) ON DELETE CASCADE NOT NULL,                                    --结算记录ID
[Reason]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID) NOT NULL,                                                   --退款原因ID，字典
[PayType]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID) NOT NULL                                                    --结算方式ID，字典
)
GO

/*****退款明细（标的扩展）表*****/

CREATE TABLE BIZ_Refund_Detail(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Refund_Detail PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ClearingItemId]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Abs_Clearing_Item(ID) ON DELETE CASCADE NOT NULL,                               --结算记录ID
)
GO


/*****内置业务：报销业务数据表*****/

/*****借款申请（契约扩展）表*****/

CREATE TABLE BIZ_Borrowing_Apply(
[CID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Borrowing_Apply PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Type]             INT NOT NULL,                                                                                                           --借款类型：1、业务费；2、周转金
[PayType]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID)                                                             --结算方式ID，字典
)
GO


/*****报销申请（契约扩展）表*****/

CREATE TABLE BIZ_Reimburse_Apply(
[CID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Reimburse_Apply PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Days]             INT,                                                                                                                    --出差天数
[Arrearage]        DECIMAL(20,2)                                                                                                           --欠款金额
)
GO


/*****报销内容明细（标的扩展）表*****/

CREATE TABLE BIZ_Reimburse_Detail(
[SID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Reimburse_Detail PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ExpensesType]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID)                                                             --费用类型ID，字典
)
GO


/*****出差申请（契约扩展）表*****/

CREATE TABLE BIZ_Travel_Apply(
[CID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Travel_Apply PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TravelType]       INT NOT NULL,                                                                                                           --出差类型
[Destination]      NVARCHAR(64) NOT NULL,                                                                                                  --目的地
[Budget]           DECIMAL(20,2),                                                                                                          --费用预算
[PayType]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --结算方式ID，字典
[TicketTime]       DATETIME,                                                                                                               --订票时间
[TicketUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --订票人
[TakeTime]         DATETIME,                                                                                                               --取票时间
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Status]           INT DEFAULT 0                                                                                                           --订票状态：1、未订票；2、已订票；3、已取票；4、无需取票
)
GO


/*****行程计划安排表*****/

CREATE TABLE BIZ_Travel_Plan(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Travel_Plan PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TravelId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BIZ_Travel_Apply(CID) ON DELETE CASCADE NOT NULL,                               --出差申请ID
[Starting]         NVARCHAR(64),                                                                                                           --出发地
[Destination]      NVARCHAR(64),                                                                                                           --目的地
[StartingTime]     DATETIME,                                                                                                               --出发时间
[Vehicle]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --交通工具ID，字典
[NeedTicket]       BIT DEFAULT 0,                                                                                                          --是否订票：0、不需订票；1、需要订票
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Trains]           NVARCHAR(16),                                                                                                           --车次/航班
[Fare]             DECIMAL(20,2),                                                                                                          --票价
[GetTicket]        INT DEFAULT 1                                                                                                           --取票方式：1、自助；2、前台
)
GO