IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_FundPerform') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_GoodsPerform
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_FundPlan') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_GoodsPlan
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_FundPerform') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_FundPerform
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_FundPlan') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_FundPlan
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_Attachs') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_Attachs
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract_Subjects') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract_Subjects
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Contract') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Contract
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Delivery_Attachs') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Delivery_Attachs
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Delivery_Item') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Delivery_Item
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Delivery') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Delivery
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Storage_Detail') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Storage_Detail
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Storage_Summary') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Storage_Summary
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Storage_Location') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Storage_Location
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Advance_Record') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Advance_Record
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Advance_Detail') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Advance_Detail
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Advance') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Advance
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_StockDetail') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_StockDetail
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_StockCapital') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_StockCapital
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Clearing_Attachs') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Clearing_Attachs
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Clearing_Pay') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Clearing_Pay
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Clearing_Item') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Clearing_Item
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Clearing') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Clearing
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ABS_Clearing_Check') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ABS_Clearing_Check
GO


/*****资金结算数据表*****/

/*****资金结算结账表*****/

CREATE TABLE ABS_Clearing_Check(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Clearing_Check PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReceiptCode]      VARCHAR(32),                                                                                                            --票据编号
[CheckTime]        DATETIME,                                                                                                               --结账时间
[ImageId]          UNIQUEIDENTIFIER,                                                                                                       --电子影像ID
[Status]           BIT DEFAULT 0 NOT NULL,                                                                                                 --状态：0、未结账；1、已结账
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****资金结算记录表*****/

CREATE TABLE ABS_Clearing(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Clearing PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Direction]        INT NOT NULL,                                                                                                           --资金流向：-1、流出；1、流入
[ReceiptCode]      NVARCHAR(64),                                                                                                           --票据编号
[HashCode]         VARCHAR(32),                                                                                                            --防伪码,六要素（资金流向、总金额、结算人ID、创建部门ID、创建人ID、创建时间）的MD5值
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --结算人ID，客户、供应商、员工
[ObjectName]       NVARCHAR(64),                                                                                                           --结算人名称
[PrintTimes]       INT DEFAULT 0 NOT NULL,                                                                                                 --打印次数
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CheckId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing_Check(ID),                                                         --结账ID
[RelationId]       UNIQUEIDENTIFIER,                                                                                                       --关联结算记录ID
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****资金结算项目明细表*****/

CREATE TABLE ABS_Clearing_Item(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Clearing_Item PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing(ID) ON DELETE CASCADE NOT NULL,                                    --结算记录ID
[Summary]          NVARCHAR(64),                                                                                                           --摘要
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --结算项目ID
[ObjectName]       NVARCHAR(64),                                                                                                           --结算项目名称
[Units]            NVARCHAR(8),                                                                                                            --单位
[Price]            DECIMAL(20,4),                                                                                                          --单价
[Counts]           DECIMAL(20,6),                                                                                                          --数量
[Amount]           DECIMAL(20,2) NOT NULL                                                                                                  --金额
)
GO

/*****资金结算支付明细表*****/

CREATE TABLE ABS_Clearing_Pay(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Clearing_Pay PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ClearingItemId]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing_Item(ID) ON DELETE CASCADE NOT NULL,                               --结算项目明细ID
[PayType]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --结算方式ID，字典
[Code]             VARCHAR(32),                                                                                                            --结算号
[CurrencyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --币种ID，字典
[Amount]           DECIMAL(20,2) NOT NULL,                                                                                                 --金额
[ExchangeRate]     DECIMAL(20,6) DEFAULT 1 NOT NULL                                                                                        --汇率
)
GO

/*****资金结算附件表*****/

CREATE TABLE ABS_Clearing_Attachs(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Clearing_Attachs PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing(ID) ON DELETE CASCADE NOT NULL,                                    --结算记录ID
[ImageId]          UNIQUEIDENTIFIER NOT NULL                                                                                               --电子影像ID
)
GO


/*****库存资金数据*****/

/*****库存资金汇总表*****/

CREATE TABLE ABS_StockCapital(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_StockCapital PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[OrgId]            UNIQUEIDENTIFIER,                                                                                                       --组织机构ID
[Amount]           DECIMAL(20,2) NOT NULL                                                                                                  --金额
)
GO

/*****库存资金明细表*****/

CREATE TABLE ABS_StockDetail(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_StockDetail PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CapitalId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_StockCapital(ID) NOT NULL,                                                  --库存资金汇总ID
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing_Pay(ID) ON DELETE CASCADE,                                         --结算记录ID
[AccountId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --银行帐户ID，字典
[Amount]           DECIMAL(20,2) NOT NULL                                                                                                  --金额
)
GO


/*****预存款数据表*****/

/*****预存款帐户表*****/

CREATE TABLE ABS_Advance(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Advance PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[AccountNo]        VARCHAR(32),                                                                                                            --账号
[CardType]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --帐户类型：字典
[OwnerId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --所属客户ID
[Status]           INT DEFAULT 0 NOT NULL,                                                                                                 --状态：0、正常；1、挂失；2、注销
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****预存款资金明细表*****/

CREATE TABLE ABS_Advance_Detail(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Advance_Detail PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[AccountId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Advance(ID) ON DELETE CASCADE NOT NULL,                                     --账号ID
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --专用项目ID
[Type]             INT DEFAULT 0 NOT NULL,                                                                                                 --资金类型：0、现金；1、赠金
[Amount]           DECIMAL(20,2) NOT NULL,                                                                                                 --金额
[ValidDate]        DATETIME                                                                                                                --失效日期
)
GO

/*****预存款储值/消费记录表*****/

CREATE TABLE ABS_Advance_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Advance_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[DetailId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Advance_Detail(ID) ON DELETE CASCADE NOT NULL,                              --资金明细ID
[Amount]           DECIMAL(20,2) NOT NULL,                                                                                                 --金额
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing(ID) ON DELETE CASCADE NOT NULL                                     --结算项目明细ID
)
GO


/*****库存物资数据*****/

/*****仓库储位表*****/

CREATE TABLE ABS_Storage_Location(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Storage_Location PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父储位ID
[Index]            INT NOT NULL,                                                                                                           --序号
[NodeType]         INT NOT NULL,                                                                                                           --储位类型ID,字典（0、车辆；1、区域；2、仓库/堆场；3、库房；4、分区；5、货架；6、储位；7、层；8、篮框）
[StorageType]      UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --存储方式ID，字典
[Code]             VARCHAR(32),                                                                                                            --编码
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[Alias]            NVARCHAR(16),                                                                                                           --别名/简称
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****库存物资汇总表*****/

CREATE TABLE ABS_Storage_Summary(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Storage_Summary PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[GoodsType]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --入库物资类型，字典
[SKUId]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --物资ID
[Total]            DECIMAL(20,6)                                                                                                           --当前总数
)
GO

/*****库存物资明细表*****/

CREATE TABLE ABS_Storage_Detail(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Storage_Detail PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SummaryId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Storage_Summary(ID) NOT NULL,                                               --库存物资汇总ID
[LocationId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Storage_Location(ID) ON DELETE CASCADE,                                     --储位ID
[BatchNumber]      INT NOT NULL,                                                                                                           --入库批次号
[Price]            DECIMAL(20,4),                                                                                                          --入库单价
[Counts]           DECIMAL(20,6)                                                                                                           --出入库数量，入库正值、出库负值
)
GO


/*****物资结算数据表*****/

/*****物资结算表*****/

CREATE TABLE ABS_Delivery(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Delivery PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Direction]        INT NOT NULL,                                                                                                           --物资流向：-1、流出；1、流入
[ReceiptCode]      NVARCHAR(64),                                                                                                           --票据编号
[HashCode]         VARCHAR(32),                                                                                                            --防伪码,六要素（资金流向、总金额、结算人ID、创建部门ID、创建人ID、创建时间）的MD5值
[LocationId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Storage_Location(ID),                                                       --仓库ID
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --结算人ID，客户、供应商、员工
[ObjectName]       NVARCHAR(64),                                                                                                           --结算人名称
[PrintTimes]       INT DEFAULT 0 NOT NULL,                                                                                                 --打印次数
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****物资结算项目明细表*****/

CREATE TABLE ABS_Delivery_Item(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Delivery_Item PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[DeliveryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Delivery(ID) ON DELETE CASCADE NOT NULL,                                    --结算记录ID
[Summary]          NVARCHAR(64),                                                                                                           --摘要
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --结算项目ID
[ObjectName]       NVARCHAR(64),                                                                                                           --结算项目名称
[Units]            NVARCHAR(8),                                                                                                            --单位
[Price]            DECIMAL(20,4),                                                                                                          --单价
[Counts]           DECIMAL(20,6),                                                                                                          --数量
[Amount]           DECIMAL(20,2) NOT NULL                                                                                                  --金额
)
GO

/*****物资结算附件表*****/

CREATE TABLE ABS_Delivery_Attachs(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Delivery_Attachs PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[DeliveryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Delivery(ID) ON DELETE CASCADE NOT NULL,                                    --结算记录ID
[ImageId]          UNIQUEIDENTIFIER NOT NULL                                                                                               --电子影像ID
)
GO


/*****契约抽象数据表*****/

/*****契约抽象表*****/

CREATE TABLE ABS_Contract(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父契约ID
[ContractCode]     NVARCHAR(32),                                                                                                           --契约编号
[Title]            NVARCHAR(64),                                                                                                           --标题
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --对方签约人ID，客户、供应商、员工
[ObjectName]       NVARCHAR(64) NOT NULL,                                                                                                  --对方签约人名称
[AgentId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --对方代理人ID，客户、供应商、员工
[AgentName]        NVARCHAR(64),                                                                                                           --对方代理人名称
[ExecuteDeptId]    UNIQUEIDENTIFIER,                                                                                                       --己方责任部门ID
[ExecuteUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Employee(MID),                                                              --己方责任人ID，员工
[EffectiveDate]    DATETIME,                                                                                                               --生效日期
[InvalidDate]      DATETIME,                                                                                                               --失效日期
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Status]           INT DEFAULT 0 NOT NULL,                                                                                                 --状态：0、起草；1、审批中；2、执行中；3、已归档；4、作废
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****契约抽象标的表*****/

CREATE TABLE ABS_Contract_Subjects(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_Subjects PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ContractId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE NOT NULL,                                    --契约ID
[Direction]        INT NOT NULL,                                                                                                           --标的流向：-1、资金流出物资流入；1、资金流入物资流出
[PlanType]         INT NOT NULL,                                                                                                           --计划类型：0、无计划；1、仅有资金计划；2、仅有物资计划；3、两者皆有
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --标的物品类ID
[ObjectId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --标的物ID
[ObjectName]       NVARCHAR(64),                                                                                                           --标的物名称
[EffectiveDate]    DATETIME,                                                                                                               --生效日期
[InvalidDate]      DATETIME,                                                                                                               --失效日期
[Units]            NVARCHAR(8),                                                                                                            --单位
[Price]            DECIMAL(20,4),                                                                                                          --单价
[Counts]           DECIMAL(20,6),                                                                                                          --数量
[Amount]           DECIMAL(20,2),                                                                                                          --金额
[Description]      NVARCHAR(MAX)                                                                                                           --描述
)
GO

/*****契约附件表*****/

CREATE TABLE ABS_Contract_Attachs(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_Attachs PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ContractId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE NOT NULL,                                    --契约ID
[ImageId]          UNIQUEIDENTIFIER NOT NULL                                                                                               --电子影像ID
)
GO

/*****契约资金计划表*****/

CREATE TABLE ABS_Contract_FundPlan(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_FundPlan PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ContractId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE NOT NULL,                                    --契约ID
[SubjectsId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID),                                                      --标的ID
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父计划ID
[CurrencyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --币种ID，字典
[Amount]           DECIMAL(20,2) NOT NULL,                                                                                                 --计划金额
[StartDate]        DATETIME NOT NULL,                                                                                                      --计划开始时间
[EndDate]          DATETIME NOT NULL,                                                                                                      --计划截止时间
[Ex_StartDate]     DATETIME,                                                                                                               --开始执行时间
[Ex_EndDate]       DATETIME,                                                                                                               --停止执行时间
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****契约资金履约表*****/

CREATE TABLE ABS_Contract_FundPerform(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_FundPerform PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[PlanId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract_FundPlan(ID) ON DELETE CASCADE NOT NULL,                           --资金计划ID
[ClearingId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Clearing(ID) ON DELETE CASCADE,                                             --结算记录ID
[Amount]           DECIMAL(20,2) NOT NULL,                                                                                                 --履约金额
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****契约物资计划表*****/

CREATE TABLE ABS_Contract_GoodsPlan(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_GoodsPlan PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SubjectsId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID) ON DELETE CASCADE NOT NULL,                           --标的ID
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父计划ID
[Counts]           DECIMAL(20,6),                                                                                                          --计划数量
[StartDate]        DATETIME NOT NULL,                                                                                                      --计划开始时间
[EndDate]          DATETIME NOT NULL,                                                                                                      --计划截止时间
[Ex_StartDate]     DATETIME,                                                                                                               --开始执行时间
[Ex_EndDate]       DATETIME,                                                                                                               --停止执行时间
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****契约物资履约表*****/

CREATE TABLE ABS_Contract_GoodsPerform(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ABS_Contract_GoodsPerform PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[PlanId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Contract_GoodsPlan(ID) ON DELETE CASCADE NOT NULL,                          --物资计划ID
[DeliveryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES ABS_Delivery(ID) ON DELETE CASCADE,                                             --结算记录ID
[Counts]           DECIMAL(20,6),                                                                                                          --履约数量
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****触发器：删除仓库数据后自动删除子数据*****/

CREATE TRIGGER ABS_Storage_Location_Delete ON ABS_Storage_Location AFTER DELETE AS

BEGIN
SET NOCOUNT ON

DELETE L from ABS_Storage_Location L
  join Deleted D on D.ID = L.ParentId

END
GO

/*****触发器：插入资金结算明细记录后自动插入库存资金明细并更新库存资金汇总*****/

CREATE TRIGGER ABS_Clearing_Pay_Insert ON ABS_Clearing_Pay AFTER INSERT AS

BEGIN
SET NOCOUNT ON

DECLARE @ABS_StockCapital TABLE(
ID                 UNIQUEIDENTIFIER,
OrgId              UNIQUEIDENTIFIER,
Amount             DECIMAL(20,2))

DECLARE @ABS_StockDetail TABLE(
ID                 UNIQUEIDENTIFIER,
CapitalId          UNIQUEIDENTIFIER,
ClearingId         UNIQUEIDENTIFIER,
AccountId          UNIQUEIDENTIFIER,
Amount             DECIMAL(20,2))

insert @ABS_StockDetail                                        --准备要插入的库存资金明细记录
  select
  newid() as ID,                                               --新建一个ID
  isnull(S.ID, newid()) as CapitalId,                          --如果汇总记录不存在，则新建一个汇总记录ID
  TI.ID as ClearingId,                                         --取插入记录的ID作为结算记录ID
  null as AccountId,                                           --银行账户暂时为空
  TI.Amount * C.Direction as Amount                           --取插入记录的金额并根据流动方向取正负作为金额
  from Inserted TI
  join ABS_Clearing_Item I on I.ID = TI.ClearingItemId
  join ABS_Clearing C on C.ID = I.ClearingId
  left join ABS_StockCapital S on S.OrgId = dbo.Get_SupOrg(C.CreatorDeptId, 1)

insert @ABS_StockCapital                                       --准备要更新/插入的库存资金汇总记录
  select TD.CapitalId, dbo.Get_SupOrg(C.CreatorDeptId, 1), sum(TD.Amount) as Amount
  from Inserted TI
  join ABS_Clearing_Item I on I.ID = TI.ClearingItemId
  join ABS_Clearing C on C.ID = I.ClearingId
  join @ABS_StockDetail TD on TD.ClearingId = TI.ID
  group by TD.CapitalId, dbo.Get_SupOrg(C.CreatorDeptId, 1)

update S set Amount = S.Amount + TS.Amount                     --如果汇总记录存在,则更新总金额
  from ABS_StockCapital S
  join @ABS_StockCapital TS on TS.ID = S.ID
insert ABS_StockCapital                                        --如果汇总记录不存在,则插入记录
  select * from @ABS_StockCapital TS
  where not exists(select * from ABS_StockCapital where ID = TS.ID)

insert ABS_StockDetail select * from @ABS_StockDetail          --插入库存资金明细记录

END
GO

/*****触发器：删除资金明细后更新库存资金汇总*****/

CREATE TRIGGER ABS_StockDetail_Delete ON ABS_StockDetail AFTER DELETE AS

BEGIN
SET NOCOUNT ON

update S set S.Amount = S.Amount - TD.Amount
  from ABS_StockCapital S
  join(
    select CapitalId, sum(Amount) as Amount from Deleted
    group by CapitalId) TD on TD.CapitalId = S.ID

END
GO


/*****触发器：作废资金结算记录后
1、自动删除结算方式明细和履约记录
2、更新票号后后自动生成防伪码*****/

CREATE TRIGGER ABS_Clearing_Update ON ABS_Clearing AFTER UPDATE AS

BEGIN
SET NOCOUNT ON

delete P from ABS_Clearing_Pay P
  join ABS_Clearing_Item I on I.ID = P.ClearingItemId
  join Inserted TI on TI.ID = I.ClearingId
    and TI.Validity = 0

delete F from ABS_Contract_FundPerform F
  join ABS_Clearing_Item I on I.ID = F.ClearingId
  join Inserted TI on TI.ID = I.ClearingId
    and TI.Validity = 0

delete R from ABS_Advance_Record R
  join Inserted TI on TI.ID = R.ClearingId
    and TI.Validity = 0

update C set RelationId = null from ABS_Clearing C
  join Inserted TI on TI.RelationId = C.ID
    and TI.Validity = 0

update ABS_Clearing set HashCode = right(sys.fn_VarBinToHexStr(hashbytes('MD5', TI.ReceiptCode + cast(TI.ObjectId as varchar(36)) + cast(I.Amount as varchar(32)) + cast(TI.CreatorUserId as varchar(36)) + convert(varchar(19), TI.CreateTime, 120))), 32)
  from Inserted TI
  join Deleted TD on TD.ID = TI.ID
  join (
    select ClearingId, sum(Amount) as Amount
    from ABS_Clearing_Item
    group by ClearingId) I on I.ClearingId = TI.ID
  where TI.ReceiptCode is not null
    and TD.ReceiptCode is null

END
GO

/*****触发器：删除结算记录后自动更新关联记录*****/

CREATE TRIGGER ABS_Clearing_Delete ON ABS_Clearing AFTER DELETE AS

BEGIN
SET NOCOUNT ON

update C set RelationId = null from ABS_Clearing C
  join Deleted TD on TD.RelationId = C.ID

END
GO


/*****触发器：
1、作废物资结算记录后自动删除履约记录
2、更新票号后后自动生成防伪码*****/

CREATE TRIGGER ABS_Delivery_Update ON ABS_Delivery AFTER UPDATE AS

BEGIN
SET NOCOUNT ON

delete F from ABS_Contract_GoodsPerform F
join ABS_Delivery_Item I on I.ID = F.DeliveryId
join Inserted TI on TI.ID = I.DeliveryId
and TI.Validity = 0

update ABS_Delivery set HashCode = right(sys.fn_VarBinToHexStr(hashbytes('MD5', TI.ReceiptCode + cast(TI.ObjectId as varchar(36)) + cast(I.Amount as varchar(32)) + cast(TI.CreatorUserId as varchar(36)) + convert(varchar(19), TI.CreateTime, 120))), 32)
from Inserted TI
join Deleted TD on TD.ID = TI.ID
join (
select DeliveryId, sum(Amount) as Amount
from ABS_Delivery_Item
group by DeliveryId) I on I.DeliveryId = TI.ID
where TI.ReceiptCode is not null
and TD.ReceiptCode is null

END
GO
