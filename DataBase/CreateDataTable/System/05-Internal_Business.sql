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