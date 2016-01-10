IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK__SYS_Organ__Position')
ALTER TABLE SYS_Organization DROP CONSTRAINT FK__SYS_Organ__Position
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'ImageData') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE ImageData
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDR_MU') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDR_MU
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDR_ET') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDR_ET
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDS_Contact_Info') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDS_Contact_Info
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Employee') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Employee
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Contact') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Contact
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Supplier') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Supplier
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Customer') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Customer
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Expense') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Expense
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Material') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Material
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Dictionary') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Dictionary
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDD_Binary') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDD_Binary
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDD_Date') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDD_Date
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDD_Numeric') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDD_Numeric
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDD_Character') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDD_Character
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MasterData_Property') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MasterData_Property
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MasterData_Merger') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MasterData_Merger
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MasterData') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MasterData
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BASE_Category') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BASE_Category
GO


/*****基础分类表*****/

CREATE TABLE BASE_Category(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BASE_Category PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父分类ID
[ModuleId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Module(ID) ON DELETE CASCADE NOT NULL,                                      --模块注册ID
[Index]            INT DEFAULT 0 NOT NULL,                                                                                                 --序号
[Code]             VARCHAR(32),                                                                                                            --编码
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[Alias]            NVARCHAR(16),                                                                                                           --别名/简称
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[BuiltIn]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否预置：0、自定；1、预置
[Visible]          BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可见：0、不可见；1、可见
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****主数据基础表*****/

/*****主数据索引表*****/

CREATE TABLE MasterData(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MasterData PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ParentId]         UNIQUEIDENTIFIER,                                                                                                       --父数据ID
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE,                                            --分类ID
[Code]             VARCHAR(32),                                                                                                            --编码，可索引
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[Alias]            NVARCHAR(32),                                                                                                           --别名/简称，可索引
[FullName]         NVARCHAR(64)                                                                                                            --全称
)
CREATE NONCLUSTERED INDEX IX_MD_Code ON MasterData(Code)
CREATE NONCLUSTERED INDEX IX_MD_Alias ON MasterData(Alias)
GO

/*****主数据合并表*****/

CREATE TABLE MasterData_Merger(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MasterData_Merger PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MasterId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[MergerId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --被并主数据ID（只允许同类型合并）
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --合并时间
)
GO


/*****主数据动态属性表（动态属性可继承,不预读，在选定特定主数据后再动态加载）*****/

CREATE TABLE MasterData_Property(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MasterData_Property PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ModuleId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Module(ID) NOT NULL,                                                        --模块注册ID
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE,                                            --分类ID
[Index]            INT DEFAULT 0 NOT NULL,                                                                                                 --序号
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[Label]            VARCHAR(32),                                                                                                            --属性标签
[Parameter]        TEXT,                                                                                                                   --属性参数
[BuiltIn]          BIT DEFAULT 0 NOT NULL                                                                                                  --是否预置：0、自定；1、预置
)
GO

/*****主数据动态属性值（字符型）表*****/

CREATE TABLE MDD_Character(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDD_Character PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[PropertyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData_Property(ID) NOT NULL,                                               --主数据动态属性ID
[Value]            NVARCHAR(MAX)                                                                                                           --主数据动态属性值（字符型）
)
GO

/*****主数据动态属性值（数值型）表*****/

CREATE TABLE MDD_Numeric(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDD_Numeric PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[PropertyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData_Property(ID) NOT NULL,                                               --主数据动态属性ID
[Value]            DECIMAL(20,6)                                                                                                           --主数据动态属性值（数值型）
)
GO

/*****主数据动态属性值（日期型）表*****/

CREATE TABLE MDD_Date(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDD_Date PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[PropertyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData_Property(ID) NOT NULL,                                               --主数据动态属性ID
[Value]            DATETIME                                                                                                                --主数据动态属性值（日期型）
)
GO

/*****主数据动态属性值（流数据型）表*****/

CREATE TABLE MDD_Binary(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDD_Binary PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[PropertyId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData_Property(ID) NOT NULL,                                               --主数据动态属性ID
[Value]            IMAGE                                                                                                                   --主数据动态属性值（流数据型）
)
GO


/*****主数据扩展表*****/

/*****通用主数据：字典表*****/

CREATE TABLE MDG_Dictionary(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Dictionary PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Index]            INT DEFAULT 0 NOT NULL,                                                                                                 --序号
[Type]             NVARCHAR(32),                                                                                                           --字典类型：详见Init_Category.sql《初始化字典根分类》部分
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[BuiltIn]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否预置：0、自定；1、预置
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO
ALTER TABLE SYS_Organization  WITH CHECK ADD CONSTRAINT FK__SYS_Organ__Position FOREIGN KEY(PositionId) REFERENCES MDG_Dictionary (MID)
GO


/*****通用主数据：物资（SPU）表*****/

CREATE TABLE MDG_Material(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Material PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Index]            INT DEFAULT 0 NOT NULL,                                                                                                 --序号
[BarCode]          VARCHAR(16),                                                                                                            --条形码
[Model]            NVARCHAR(32),                                                                                                           --型号
[Size]             NVARCHAR(32),                                                                                                           --规格
[SizeType]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --规格单位ID，字典
[Unit]             UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --单位ID，字典
[StorageType]      UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --存储方式ID，字典
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****通用主数据：费用项目表*****/

CREATE TABLE MDG_Expense(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Expense PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Index]            INT DEFAULT 0 NOT NULL,                                                                                                 --序号
[Unit]             UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --单位ID，字典
[Price]            DECIMAL(20,4),                                                                                                          --单价
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[BuiltIn]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否预置：0、自定；1、预置
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****通用主数据：客户表*****/

CREATE TABLE MDG_Customer(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Customer PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[EnterpriseType]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --企业类型ID，字典
[IndustryType]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --行业类型ID，字典
[RegisterNumber]   VARCHAR(24),                                                                                                            --营业执照注册号
[TaxNumber]        VARCHAR(24),                                                                                                            --税务登记号
[Corporation]      NVARCHAR(24),                                                                                                           --法人
[RegisterDate]     DATETIME,                                                                                                               --开业日期
[BusinessScope]    NVARCHAR(128),                                                                                                          --经营范围
[Scale]            NVARCHAR(24),                                                                                                           --资产规模
[Staffs]           INT,                                                                                                                    --员工人数
[State]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --所在国家/地区，字典
[Province]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在省/直辖市，字典
[City]             UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在市，字典
[District]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --所在区/县，字典
[Address]          NVARCHAR(64),                                                                                                           --注册地址
[Phone]            VARCHAR(24),                                                                                                            --电话号码
[ZipCode]          VARCHAR(6),                                                                                                             --邮编
[Website]          VARCHAR(64),                                                                                                            --网站
[Class]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --客户类型，字典
[Statu]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --客户状态，字典
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[Visible]          BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可见：0、不可见；1、可见
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****通用主数据：供应商表*****/

CREATE TABLE MDG_Supplier(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Supplier PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[EnterpriseType]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --企业类型ID，字典
[IndustryType]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --行业类型ID，字典
[RegisterNumber]   VARCHAR(24),                                                                                                            --营业执照注册号
[TaxNumber]        VARCHAR(24),                                                                                                            --税务登记号
[Corporation]      NVARCHAR(24),                                                                                                           --法人
[RegisterDate]     DATETIME,                                                                                                               --开业日期
[BusinessScope]    NVARCHAR(128),                                                                                                          --经营范围
[Scale]            NVARCHAR(24),                                                                                                           --资产规模
[Staffs]           INT,                                                                                                                    --员工人数
[State]            UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --所在国家/地区，字典
[Province]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在省/直辖市，字典
[City]             UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在市，字典
[District]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --所在区/县，字典
[Address]          NVARCHAR(32),                                                                                                           --注册地址
[Phone]            VARCHAR(24),                                                                                                            --电话号码
[ZipCode]          VARCHAR(6),                                                                                                             --邮编
[Website]          VARCHAR(32),                                                                                                            --网站
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[Visible]          BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可见：0、不可见；1、可见
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****通用主数据：联系人表*****/

CREATE TABLE MDG_Contact(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Contact PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[LastName]         NVARCHAR(16),                                                                                                           --姓
[FirstName]        NVARCHAR(16),                                                                                                           --名
[MiddleName]       NVARCHAR(16),                                                                                                           --字
[Gender]           INT,                                                                                                                    --性别：0、女；1、男
[Department]       NVARCHAR(32),                                                                                                           --部门
[Title]            NVARCHAR(32),                                                                                                           --职务
[OfficeAddress]    NVARCHAR(128),                                                                                                          --工作地点
[HomeAddress]      NVARCHAR(128),                                                                                                          --家庭住址
[Birthday]         DATETIME,                                                                                                               --出生日期
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[IsMaster]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否主要联系人：0、否；1、是
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --是否可用：0、不可用；1、可用
[LoginUser]        BIT DEFAULT 0 NOT NULL,                                                                                                 --是否登录用户：0、否；1、是
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****通用主数据：员工表*****/

CREATE TABLE MDG_Employee(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Employee PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Gender]           INT,                                                                                                                    --性别：0、女；1、男
[WorkType]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --工种ID，字典
[IdCardNo]         VARCHAR(18),                                                                                                            --身份证号
[DirectLeader]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Employee(MID),                                                              --直接领导ID
[OfficeAddress]    VARCHAR(64),                                                                                                            --工作地点
[HomeAddress]      VARCHAR(64),                                                                                                            --家庭住址
[Photo]            IMAGE,                                                                                                                  --照片
[Thumbnail]        IMAGE,                                                                                                                  --缩略图
[EntryDate]        DATETIME,                                                                                                               --入职日期
[DimissionDate]    DATETIME,                                                                                                               --离职日期
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --状态：1、正常；2、休假；3、离职
[LoginUser]        BIT DEFAULT 0 NOT NULL,                                                                                                 --是否登录用户：0、否；1、是
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****通用主数据附属数据：联系方式表*****/

CREATE TABLE MDS_Contact_Info(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDS_Contact_Info PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[IsMaster]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否主要负责人：0、否；1、是
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[InfoTypeId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID) NOT NULL,                                                   --联系方式ID，字典
[Number]           NVARCHAR(128) NOT NULL                                                                                                  --联系号码
)
GO


/*****通用主数据关系：员工职位表*****/

CREATE TABLE MDR_ET(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDR_ET PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[EmployeeId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Employee(MID) ON DELETE CASCADE NOT NULL,                                   --员工ID
[TitleId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_Organization(ID) ON DELETE CASCADE NOT NULL                                 --职位ID
)
GO

/*****通用主数据关系：用户关系表*****/

CREATE TABLE MDR_MU(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDR_CU PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[IsMaster]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否主要负责人：0、否；1、是
[MasterDataId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --主数据ID
[UserId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) ON DELETE CASCADE NOT NULL,                                        --用户ID
[EffectiveDate]    DATETIME NOT NULL,                                                                                                      --生效日期
[FailureDate]      DATETIME                                                                                                                --失效日期
)
GO


/*****电子影像数据表*****/

/*****电子影像表*****/

CREATE TABLE ImageData(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_ImageData PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CategoryId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID) ON DELETE CASCADE,                                            --分类ID
[ImageType]        INT DEFAULT 0 NOT NULL,                                                                                                 --类型：0、附件；1、收据；2、发票；3、付款单；4、报销单；5、入库单；6、出库单
[Code]             VARCHAR(32),                                                                                                            --编码，可索引
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --名称
[Expand]           VARCHAR(8),                                                                                                             --扩展名
[SecrecyDegree]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --涉密等级，字典
[Pages]            INT,                                                                                                                    --页数
[Size]             BIGINT,                                                                                                                 --文件字节数
[Path]             NVARCHAR(MAX),                                                                                                          --存放路径
[Image]            IMAGE NOT NULL,                                                                                                         --电子影像内容
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Validity]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorDeptId]    UNIQUEIDENTIFIER,                                                                                                       --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL,                                                                                    --创建时间
)
CREATE NONCLUSTERED INDEX IX_ID_Code ON ImageData(Code)
GO


/*****触发器：插入联系人后自动添加用户*****/

CREATE TRIGGER MDG_Contact_Insert ON MDG_Contact AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_User (ID, Name, LoginName, Description, Type, CreatorUserId)
  select MD.ID, MD.Name, MD.Alias, MD.FullName, 2, TI.CreatorUserId
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1

END
GO

/*****触发器：更新联系人后自动添加用户*****/

CREATE TRIGGER MDG_Contact_Update ON MDG_Contact AFTER UPDATE AS

BEGIN
SET NOCOUNT ON

INSERT SYS_User (ID, Name, LoginName, Description, Type, CreatorUserId)
  select MD.ID, MD.Name, MD.Alias, MD.FullName, 2, TI.CreatorUserId
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1
  left join SYS_User U on U.ID = TI.MID
  where U.ID is null

UPDATE U set U.Name = MD.Name, U.LoginName = MD.Alias, U.Description = MD.FullName
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1
  left join SYS_User U on U.ID = TI.MID
  where U.ID is not null

END
GO

/*****触发器：插入员工后自动添加用户*****/

CREATE TRIGGER MDG_Employee_Insert ON MDG_Employee AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_User (ID, Name, LoginName, Description, Type, CreatorUserId)
  select MID, MD.Name, MD.Alias, md.FullName, 1, TI.CreatorUserId
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1

END

GO

/*****触发器：更新员工后自动添加用户*****/

CREATE TRIGGER MDG_Employee_Update ON MDG_Employee AFTER UPDATE AS

BEGIN
SET NOCOUNT ON

UPDATE U set U.Name = MD.Name, U.LoginName = MD.Alias, U.Description = MD.FullName
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1
  left join SYS_User U on U.ID = TI.MID
  where U.ID is not null

INSERT SYS_User (ID, Name, LoginName, Description, Type, CreatorUserId)
  select MID, MD.Name, MD.Alias, md.FullName, 1, TI.CreatorUserId
  from Inserted TI
  join MasterData MD on MD.ID = TI.MID
    and TI.LoginUser = 1
  left join SYS_User U on U.ID = TI.MID
  where U.ID is null

INSERT SYS_OrgMember(OrgId, UserId, CreatorUserId)
  select R.TitleId, R.EmployeeId, TI.CreatorUserId
  from MDR_ET R
  join Inserted TI on TI.MID = R.EmployeeId
    and TI.LoginUser = 1
  left join SYS_OrgMember M on M.OrgId = R.TitleId
    and M.UserId = R.EmployeeId
  where M.ID is null

END

GO

/*****触发器：插入员工职位关系后自动添加用户职位关系*****/

CREATE TRIGGER MDR_ET_Insert ON MDR_ET AFTER INSERT AS

BEGIN
SET NOCOUNT ON

INSERT SYS_OrgMember(OrgId, UserId, CreatorUserId)
  select TI.TitleId, U.ID, U.CreatorUserId
  from Inserted TI
  join SYS_User U on U.ID = TI.EmployeeId

END
GO

/*****触发器：更新员工职位关系后自动添加用户职位关系*****/

CREATE TRIGGER MDR_ET_Update ON MDR_ET AFTER UPDATE AS

BEGIN
SET NOCOUNT ON

UPDATE M set OrgId = TI.TitleId
  from Inserted TI
  left join SYS_OrgMember M on M.UserID = TI.EmployeeId
    and M.OrgId = TI.TitleId
  where M.ID is not null

END
GO

/*****触发器：删除员工职位关系后自动删除用户职位关系*****/

CREATE TRIGGER MDR_ET_Delete ON MDR_ET AFTER DELETE AS

BEGIN
SET NOCOUNT ON

DELETE M
  from Inserted TI
  join SYS_OrgMember M on M.UserId = TI.EmployeeId
    and M.OrgId = TI.TitleId

END
GO
