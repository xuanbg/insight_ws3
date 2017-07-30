IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_Inventory') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_Inventory
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_MA') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_MA
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_Mission') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_Mission
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_InApplyItem') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_InApplyItem
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_InApply') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_InApply
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Biz_Storage_ApplyIndex') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE Biz_Storage_ApplyIndex
GO


/*****库存数据表*****/

/*****申请单索引表*****/

CREATE TABLE Biz_Storage_ApplyIndex(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_Storage_ApplyIndex UNIQUE CLUSTERED IDENTITY(1,1),                        --自增序列
)
GO


/*****入库申请表*****/

CREATE TABLE Biz_Storage_InApply(
[AiId]             VARCHAR(36) PRIMARY KEY NONCLUSTERED,                                                               --申请单索引Id
[Sn]               BIGINT CONSTRAINT IX_Biz_Storage_InApply UNIQUE CLUSTERED IDENTITY(1,1),                            --自增序列
[GoodsType]        VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --入库物资类型，字典
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[SupplierId]       VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --供应商Id
[ContractId]       VARCHAR(36) FOREIGN KEY REFERENCES Abs_Contract(Id),                                                --合同Id
[ApplicantId]      VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --申请人Id，员工
[LogisticsType]    VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --物流方式（公司），字典
[WaybillNumber]    VARCHAR(64),                                                                                        --运单号
[Description]      NVARCHAR(MAX),                                                                                      --描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --创建部门Id
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --创建人Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --创建时间
)
GO

/*****入库申请物资明细表*****/

CREATE TABLE Biz_Storage_InApplyItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_Storage_InApplyItem UNIQUE CLUSTERED IDENTITY(1,1),                        --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_Storage_InApply(AiId) ON DELETE CASCADE NOT NULL,            --出入库申请单Id
[SKUId]            VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --物资Id
[HaveCheck]        INT NOT NULL,                                                                                       --验货方式：0、免检；1、抽检；2、全检
[Counts]           DECIMAL(20,6),                                                                                      --物资数量
[Summary]          NVARCHAR(64),                                                                                       --摘要
)
GO


/*****发货申请表*****/

CREATE TABLE Biz_Storage_OutApply(
[AiId]             VARCHAR(36) PRIMARY KEY NONCLUSTERED,                                                               --申请单索引Id
[Sn]               BIGINT CONSTRAINT IX_Biz_Biz_Storage_OutApply UNIQUE CLUSTERED IDENTITY(1,1),                       --自增序列
[Number]           VARCHAR(36),                                                                                        --申请单编码
[Title]            NVARCHAR(64) NOT NULL,                                                                              --标题
[CustomerId]       VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --供应商Id
[ContractId]       VARCHAR(36) FOREIGN KEY REFERENCES Abs_Contract(Id),                                                --合同Id
[ApplicantId]      VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --申请人Id，员工
[ExpectedDate]     DATETIME,                                                                                           --预约发货时间
[LogisticsType]    VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id),                                                  --物流方式（公司），字典
[Description]      NVARCHAR(MAX),                                                                                      --描述
[CreatorDeptId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_Organization(Id) NOT NULL,                                   --创建部门Id
[CreatorUserId]    VARCHAR(36) FOREIGN KEY REFERENCES Sys_User(Id) NOT NULL,                                           --创建人Id
[CreateTime]       DATETIME DEFAULT GETDATE()                                                                          --创建时间
)
GO

/*****发货申请物资明细表*****/

CREATE TABLE Biz_Storage_OutApplyItem(
[Id]               VARCHAR(36) PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
[Sn]               BIGINT CONSTRAINT IX_Biz_Storage_OutApplyItem UNIQUE CLUSTERED IDENTITY(1,1),                       --自增序列
[ApplyId]          VARCHAR(36) FOREIGN KEY REFERENCES Biz_Storage_OutApply(AiId) ON DELETE CASCADE NOT NULL,           --出入库申请单Id
[SKUId]            VARCHAR(36) FOREIGN KEY REFERENCES MasterData(Id) NOT NULL,                                         --物资Id
[Counts]           DECIMAL(20,6),                                                                                      --物资数量
[Summary]          NVARCHAR(64),                                                                                       --摘要
)
GO
