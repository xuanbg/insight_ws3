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

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Alert_Send') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Alert_Send
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Alert_Message') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Alert_Message
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Alert_Target') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Alert_Target
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Alert_Rules') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Alert_Rules
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_IU') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_IU
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Instances') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Instances
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Schedular') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Schedular
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Member') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Member
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Entity') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Entity
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Period') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Period
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Definition') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Definition
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Templates') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Templates
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Report_Rules') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Report_Rules
GO


/*****报表数据表*****/

/*****分期规则表*****/

CREATE TABLE SYS_Report_Rules(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Rules PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --规则名称
[CycleType]        INT,                                                                                                                    --报表周期类型：1、年；2、月；3、周；4、日
[Cycle]            INT,                                                                                                                    --周期数
[StartTime]        DATETIME,                                                                                                               --会计分期起始时间
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[BuiltIn]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否预置：0、自定；1、预置
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****模板表*****/

CREATE TABLE SYS_Report_Templates(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Templates PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE,                                            --报表分类ID,
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --模板名称
[Content]          TEXT NOT NULL,                                                                                                          --模板内容
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****报表定义表*****/

CREATE TABLE SYS_Report_Definition(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Definition PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE NOT NULL,                                   --报表分类ID,
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --报表名称
[TemplateId]       UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES SYS_Report_Templates(ID) NOT NULL,                                             --报表模板ID
[Mode]             INT DEFAULT 1 NOT NULL,                                                                                                 --统计模式：1、时段；2、时点；3、当前
[Delay]            INT DEFAULT 2 NOT NULL,                                                                                                 --延时小时数（正数延后，负数提前）
[Type]             INT DEFAULT 1 NOT NULL,                                                                                                 --报表类型：1、组织机构；2、个人私有
[DataSource]       VARCHAR(16),                                                                                                            --数据源
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****报表分期表*****/

CREATE TABLE SYS_Report_Period(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Period PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReportId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Definition(ID) ON DELETE CASCADE NOT NULL,                           --报表定义ID
[RuleId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Rules(ID) NOT NULL                                                   --分期规则ID
)
GO

/*****会计主体表*****/

CREATE TABLE SYS_Report_Entity(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Entity PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReportId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Definition(ID) ON DELETE CASCADE NOT NULL,                           --报表定义ID
[OrgId]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID) NOT NULL                                                   --组织机构（会计主体）ID
)
GO

/*****报送人员表*****/

CREATE TABLE SYS_Report_Member(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Member PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[EntityId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Entity(ID) ON DELETE CASCADE NOT NULL,                               --会计主体ID 
[RoleId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Role(ID) ON DELETE CASCADE NOT NULL                                         --角色ID
)
GO

/*****计划任务表*****/

CREATE TABLE SYS_Report_Schedular(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Schedular PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReportId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Definition(ID) ON DELETE CASCADE NOT NULL,                           --报表定义ID
[RuleId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Rules(ID) NOT NULL,                                                  --分期规则ID
[BuildTime]        DATETIME,                                                                                                               --报表计划生成时间
)
GO


/*****报表实例表*****/

CREATE TABLE SYS_Report_Instances(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_Instances PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReportId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Definition(ID) ON DELETE CASCADE NOT NULL,                           --报表定义ID
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --报表名称
[Content]          IMAGE NOT NULL,                                                                                                         --实例内容
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID),                                                                   --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****实例报送人员表*****/

CREATE TABLE SYS_Report_IU(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Report_IU PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[InstanceId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Report_Instances(ID) ON DELETE CASCADE NOT NULL,                            --实例表ID
[UserId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) ON DELETE CASCADE NOT NULL                                         --用户ID
)
GO


/*****预警数据表*****/

/*****预警规则表*****/

CREATE TABLE SYS_Alert_Rules(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Alert_Rules PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE,                                            --规则分类ID,
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --规则名称
[Script]           VARCHAR(64) NOT NULL,                                                                                                   --脚本名称(存储过程名称)
[UpperLimit]       INT,                                                                                                                    --阀值上限
[UpperType]        INT,                                                                                                                    --上限类型：0、大于；1、小于
[LowerLimit]       INT,                                                                                                                    --阀值下限
[LowerType]        INT,                                                                                                                    --下限类型：0、大于；1、小于
[LimitRules]       INT,                                                                                                                    --关系类型：0、与；1、或
[CycleType]        INT DEFAULT 1 NOT NULL,                                                                                                 --预警周期类型：1、天；2、小时；3、分
[Cycle]            INT DEFAULT 1 NOT NULL,                                                                                                 --周期数
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、停用；1、启用
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****预警目标表*****/

CREATE TABLE SYS_Alert_Target(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Alert_Targe PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[RuleId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Alert_Rules(ID) ON DELETE CASCADE NOT NULL,                                 --预警规则ID
[TargetId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --预警目标ID
[SendType]         INT DEFAULT 0 NOT NULL                                                                                                  --消息发送类型：0、系统消息；1、邮件；2、短信
)
GO

/*****预警消息表*****/

CREATE TABLE SYS_Alert_Message(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Alert_Message PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[RuleId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Alert_Rules(ID) ON DELETE CASCADE NOT NULL,                                 --预警规则ID
[Content]          TEXT,                                                                                                                   --消息内容
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL,                                                                                    --创建时间
)
GO

/*****预警消息发送状态表*****/

CREATE TABLE SYS_Alert_Send(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Alert_Send PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MessageId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Alert_Message(ID) ON DELETE CASCADE NOT NULL,                               --预警消息ID
[TargetId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --发送目标用户ID
[SendType]         INT,                                                                                                                    --消息发送类型：1、邮件；2、短信
[Target]           VARCHAR(32),                                                                                                            --发送目标：邮件地址或手机号码
[Times]            INT,                                                                                                                    --消息发送次数
[SendTime]         DATETIME,                                                                                                               --消息发送时间
[Status]           INT DEFAULT 0 NOT NULL                                                                                                  --消息发送状态：0、未发送；1、发送成功；2、发送失败
)
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
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****编码分配记录表*****/

CREATE TABLE SYS_Allot_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Allot_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[SchemeId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Code_Scheme(ID) ON DELETE CASCADE NOT NULL,                                 --编码方案ID
[ModuleId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Module(ID) ON DELETE CASCADE NOT NULL,                                      --模块注册ID
[OwnerId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --用户ID
[StartNumber]      VARCHAR(8),                                                                                                             --编码区段起始值
[EndNumber]        VARCHAR(8),                                                                                                             --编码区段结束值
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
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
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Allot_Serial ON SYS_Code_Allot(SchemeId, ModuleId, OwnerId) INCLUDE (AllotNumber)
CREATE NONCLUSTERED INDEX IX_SYS_Code_Allot_BusinessId ON SYS_Code_Allot(BusinessId)
GO


/*****初始化报表分期规则*****/

INSERT SYS_Report_Rules (Name, CycleType, Cycle, StartTime, Description, BuiltIn)
select '不定期', NULL, NULL, NULL, N'适用于不自动生成报表的情况', 1 union all
select '自然年度', 1, 1, CAST(0x00008EAC00000000 AS DateTime), N'按自然年度（1月1日-12月31日）分期', 1 union all
select '自然季度', 2, 3, CAST(0x00008EAC00000000 AS DateTime), N'按自然季度分期，首期1月1日-3月31日，每3月1期', 1 union all
select '自然月度', 2, 1, CAST(0x00008EAC00000000 AS DateTime), N'按自然月度（1日-月末）分期', 1 union all
select '自然周', 3, 1, CAST(0x00008EAE00000000 AS DateTime), N'按自然周（周一-周日）分期，以周一为起始', 1 union all
select '自然日', 4, 1, CAST(0x00008EAC00000000 AS DateTime), N'按自然日分期，以每日零点为起始', 1 union all
select '会计月度', 2, 1, CAST(0x00008EA600000000 AS DateTime), N'自定义月度（上月26日-本月25日）分期，可编辑', 0
GO


/*****触发器：插入报表分期后自动添加计划任务*****/

CREATE TRIGGER SYS_Report_Period_Insert ON SYS_Report_Period AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_Report_Schedular (ReportId, RuleId, BuildTime)
  select TI.ReportId, TI.RuleId,
  dateadd(hour, Delay, dbo.Get_Eff_Time(StartTime, CycleType, Cycle))as BuildTime
  from Inserted TI
  join SYS_Report_Definition RD on RD.ID = TI.ReportId
  join SYS_Report_Rules RR on RR.ID = TI.RuleId
    and RR.StartTime is not null

END
GO

/*****触发器：删除报表分期后自动删除计划任务*****/

CREATE TRIGGER SYS_Report_Period_Delete ON SYS_Report_Period AFTER DELETE AS

BEGIN
SET NOCOUNT ON

DELETE S
  from Deleted TD
  join SYS_Report_Schedular S on S.ReportId = TD.ReportId
    and S.RuleId = TD.RuleId

END
GO

/*****触发器：插入报表实例后自动添加报表实例用户关系*****/

CREATE TRIGGER SYS_Report_Instances_Insert ON SYS_Report_Instances AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_Report_IU (InstanceId, UserId)
  select distinct TI.ID, RU.UserId
  from Inserted TI
  join SYS_Report_Definition RD on RD.ID = TI.ReportId
    and RD.Type = 1
  join SYS_Report_Entity RE on RE.ReportId = TI.ReportId
  join SYS_Report_Member RM on RM.EntityId = RE.ID
  join RoleUser RU on RU.RoleId = RM.RoleId
    and RU.状态 = '正常'

INSERT SYS_Report_IU (InstanceId, UserId)
  select TI.ID, TI.CreatorUserId
  from Inserted TI
  join SYS_Report_Definition RD on RD.ID = TI.ReportId
    and RD.Type = 2

END
GO

/*****触发器：插入预警消息后自动添加发送任务*****/

CREATE TRIGGER SYS_Alert_Message_Insert ON SYS_Alert_Message AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_Alert_Send(MessageId, TargetId, SendType, Target)
  select TI.ID, T.TargetId, T.SendType, dbo.Get_ContactInfo(T.TargetId, T.SendType)
  from Inserted TI
  join SYS_Alert_Target T on T.RuleId = TI.RuleId
  where dbo.Get_ContactInfo(T.TargetId, T.SendType) is not null

END
GO