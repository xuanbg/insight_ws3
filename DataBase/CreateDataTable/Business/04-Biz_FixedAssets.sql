
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_DisposalItem') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_DisposalItem
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Disposal') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Disposal
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_ScrapItem') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_ScrapItem
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Scrap') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Scrap
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_RenewalItem') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_RenewalItem
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Renewal') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Renewal
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_ReturnItem') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_ReturnItem
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Return') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Return
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Transfer') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Transfer
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Apply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Apply
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Inventory') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Inventory
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Depreciation') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Depreciation
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets_Maintain') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets_Maintain
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_FixedAssets') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_FixedAssets
GO


/*****固定资产台帐表*****/

CREATE TABLE Biz_FixedAssets(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets UNIQUE CLUSTERED IDENTITY(1,1),                                --自增序列
[CategoryId]       VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --资产分类Id，字典
[BatchNumber]      INT,                                                                                                --登帐批次，自增
[Code]             VARCHAR(36),                                                                                        --资产编码
[GoodsId]          VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --物资Id
[ManfDate]         DATETIME,                                                                                           --生产日期
[WarrantyDeadline] DATETIME,                                                                                           --保修截止日期
[InUseDate]        DATETIME,                                                                                           --投入使用日期
[Direction]        BIT,                                                                                                --使用方向：0、自用；1、出租
[Situations]       INT DEFAULT 0,                                                                                      --资产状况：0、正常；1、稍有影响；2、影响使用；3、无法使用；4、局部损坏；5、大部损坏；6、彻底损坏
[DepMethod]        INT,                                                                                                --折旧方法：1、平均年限法；2、工作量法；3、双倍余额递减法；4、年度总和法
[BuyDate]          DATETIME,                                                                                           --购入日期
[ServiceLife]      INT,                                                                                                --使用年限
[OriginalCoat]     DECIMAL(20,2),                                                                                      --资产原值
[ResidualsRate]    INT,                                                                                                --残值率
[AccumulatedDep]   DECIMAL(20,2),                                                                                      --累计折旧
[Status]           INT DEFAULT 0,                                                                                      --状态：0、未审核；1、封存；2、启用；3、已报废；4、已出售；5、已赠送；6、已投资；7、已拆解；8、已销毁；9、已灭失；
[Description]      NVARCHAR(MAX),                                                                                      --规格描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产登帐操作员登录部门Id（资产管理部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产登帐操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产登帐时间
)
GO


/*****固定资产转移申请表*****/

CREATE TABLE Biz_FixedAssets_Apply(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_TA UNIQUE CLUSTERED IDENTITY(1,1),                             --自增序列
[ManageDept]       VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产主管部门Id
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[GoodName]         NVARCHAR(128) NOT NULL,                                                                             --申领物资名称
[User]             VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --资产使用申请人Id（员工）
[StorageLocation]  NVARCHAR(128) NOT NULL,                                                                             --资产存放地点
[TransferDate]     DATETIME,                                                                                           --资产领用日期
[Status]           INT DEFAULT 0,                                                                                      --申请状态：0、未批准；1、已批准；2、已完成
[Description]      NVARCHAR(MAX),                                                                                      --申请物资理由和规格要求描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产领用申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产领用申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产领用申请时间
)
GO


/*****固定资产转移记录表*****/

CREATE TABLE Biz_FixedAssets_Transfer(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Transfer UNIQUE CLUSTERED IDENTITY(1,1),                       --自增序列
[Index]            INT NOT NULL,                                                                                       --资产转移序号，每次增1
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Apply(Id),                                       --资产领用申请Id
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                    --固定资产Id
[UserDept]         VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产使用部门Id
[User]             VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --资产使用人/责任人Id
[StorageLocation]  NVARCHAR(128) NOT NULL,                                                                             --资产存放地点
[TransferDate]     DATETIME,                                                                                           --资产转移日期
[Validity]         BIT,                                                                                                --转移状态：0、失效；1、生效
[Description]      NVARCHAR(MAX),                                                                                      --规格描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产转移操作员登录部门Id（资产管理部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产转移操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产转移时间
)
GO


/*****固定资产更新申请表*****/

CREATE TABLE Biz_FixedAssets_Renewal(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Renewal UNIQUE CLUSTERED IDENTITY(1,1),                        --自增序列
[ManageDept]       VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产主管部门Id
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[User]             VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --资产更新申请人Id（员工）
[TransferDate]     DATETIME,                                                                                           --资产更新日期
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未批准；1、已批准
[Description]      NVARCHAR(MAX),                                                                                      --申请设备更新理由和规格要求描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产更新申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产更新申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产更新申请时间
)
GO


/*****固定资产更新申请明细表*****/

CREATE TABLE Biz_FixedAssets_RenewalItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_RI UNIQUE CLUSTERED IDENTITY(1,1),                             --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Renewal(Id) ON DELETE CASCADE NOT NULL,          --更新申请单Id
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                    --固定资产Id
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未处理；1、已处理
)
GO


/*****固定资产归还申请表*****/

CREATE TABLE Biz_FixedAssets_Return(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Return UNIQUE CLUSTERED IDENTITY(1,1),                         --自增序列
[ManageDept]       VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产主管部门Id
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[User]             VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --资产归还申请人Id（员工）
[TransferDate]     DATETIME,                                                                                           --资产归还日期
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未批准；1、已批准
[Description]      NVARCHAR(MAX),                                                                                      --申请设备归还理由和规格要求描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产归还申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产归还申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产归还申请时间
)
GO


/*****固定资产归还申请明细表*****/

CREATE TABLE Biz_FixedAssets_ReturnItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_ReturnItem UNIQUE CLUSTERED IDENTITY(1,1),                     --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Return(Id) ON DELETE CASCADE NOT NULL,           --归还申请单Id
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                    --固定资产Id
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未处理；1、已处理
)
GO


/*****固定资产报废申请表*****/

CREATE TABLE Biz_FixedAssets_Scrap(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Scrap UNIQUE CLUSTERED IDENTITY(1,1),                          --自增序列
[ManageDept]       VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产主管部门Id
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未通过；1、已通过
[Description]      NVARCHAR(MAX),                                                                                      --申请报废理由描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产报废申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产报废申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产报废申请时间
)
GO


/*****固定资产报废申请明细表*****/

CREATE TABLE Biz_FixedAssets_ScrapItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_ScrapItem UNIQUE CLUSTERED IDENTITY(1,1),                        --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Scrap(Id) ON DELETE CASCADE NOT NULL,              --报废申请单Id
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                      --固定资产Id
)
GO


/*****固定资产处置申请表*****/

CREATE TABLE Biz_FixedAssets_Disposal(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Disposal UNIQUE CLUSTERED IDENTITY(1,1),                       --自增序列
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未通过；1、已通过
[Description]      NVARCHAR(MAX),                                                                                      --申请处置理由描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产处置申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产处置申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产处置申请时间
)
GO


/*****固定资产处置申请明细表*****/

CREATE TABLE Biz_FixedAssets_DisposalItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_DisposalItem UNIQUE CLUSTERED IDENTITY(1,1),                   --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Disposal(Id) ON DELETE CASCADE NOT NULL,         --报废申请单Id
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                    --固定资产Id
[Method]           BIT                                                                                                 --处置方法：1、出售；2、赠送；3、投资；4、拆解；5、销毁；6、灭失
)
GO


/*****固定资产维修申请表*****/

CREATE TABLE Biz_FixedAssets_Maintain(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Maintain UNIQUE CLUSTERED IDENTITY(1,1),                       --自增序列
[ManageDept]       VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产主管部门Id
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[User]             VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --资产维修申请人Id（员工）
[Status]           BIT DEFAULT 0,                                                                                      --申请状态：0、未通过；1、已通过
[Description]      NVARCHAR(MAX),                                                                                      --故障情况描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产维修申请操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产维修申请操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产维修申请时间
)
GO


/*****固定资产维修申请及结果明细表*****/

CREATE TABLE Biz_FixedAssets_MaintainItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_MaintainItem UNIQUE CLUSTERED IDENTITY(1,1),                   --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets_Maintain(Id) ON DELETE CASCADE NOT NULL,         --报废申请单Id
[Index]            INT NOT NULL,                                                                                       --资产维修序号，每次增1
[FixedAssetsId]    VARCHAR(36) FOREIGN KEY REFERENCES Biz_FixedAssets(Id) NOT NULL,                                    --固定资产Id
[Level]            INT NOT NULL,                                                                                       --故障等级：1、稍有影响；2、影响使用；3、无法使用
[FaultTime]        DATETIME,                                                                                           --故障发生时间
[Status]           BIT DEFAULT 0,                                                                                      --状态：0、待维修；1、完成维修；2、无法维修
[RepairTime]       DATETIME,                                                                                           --维修结束时间
[Expenses]         DECIMAL(20,2) NOT NULL,                                                                             --维修费用
[Repairman]        VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --维修人Id（员工）
[Accepter]         VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --验收人Id（员工）
[Description]      NVARCHAR(MAX),                                                                                      --维修说明描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --资产维修登记操作员登录部门Id（资产使用部门）
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --资产维修登记操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --资产维修登记时间
)
GO


/*****固定资产盘点明细表*****/

CREATE TABLE Biz_FixedAssets_Inventory(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Inventory UNIQUE CLUSTERED IDENTITY(1,1),                      --自增序列
[Index]            INT NOT NULL,                                                                                       --资产盘点序号，每次增1
[StartTime]        DATETIME,                                                                                           --盘点开始时间
[EndTime]          DATETIME,                                                                                           --盘点结束时间
[Briefing]         TEXT,                                                                                               --盘点简报内容
[Content]          TEXT                                                                                                --盘点报告内容（报表形式）
)
GO


/*****固定资产折旧明细表*****/

CREATE TABLE Biz_FixedAssets_Depreciation(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_FixedAssets_Depreciation UNIQUE CLUSTERED IDENTITY(1,1),                   --自增序列
[Index]            INT NOT NULL,                                                                                       --资产折旧序号，每次增1
[CycleNumber]      INT NOT NULL,                                                                                       --计提期数
[DepAmount]        DECIMAL(20,2) NOT NULL,                                                                             --计提折旧金额
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --计提折旧操作员登录部门Id
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --计提折旧操作员Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --计提折旧日期
)
GO