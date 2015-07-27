IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Verify_Record') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Verify_Record
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Order') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Order
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Product_Snapshot') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Product_Snapshot
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_Feedback') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_Feedback
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_Withdrawal') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_Withdrawal
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_Address') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_Address
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_Card') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_Card
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_Contact') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_Contact
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Member_CreditInfo') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Member_CreditInfo
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_EntMember') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_EntMember
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_StagePlan') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_StagePlan
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'BIZ_Advertiser') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE BIZ_Advertiser
GO

/*****信分宝扩展表*****/

/*****轮播商品表*****/

CREATE TABLE BIZ_Advertiser(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Advertiser PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Index]            INT NOT NULL,                                                                                                           --序号
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --商品名称
[TargetURL]        NVARCHAR(128) NOT NULL,                                                                                                 --目标地址
[ImageURL]         NVARCHAR(128) NOT NULL,                                                                                                 --图片路径
[ProductId]        INT NOT NULL,                                                                                                           --商品ID
[ProductCode]      VARCHAR(32) NOT NULL,                                                                                                   --商品编号
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****分期方案表*****/

CREATE TABLE BIZ_StagePlan(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_StagePlan PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[StageNum]         INT NOT NULL,                                                                                                           --分期数
[Rate]           　DECIMAL(20,4) NOT NULL,                                                                                                 --费率
[EffectiveDate]    DATETIME NOT NULL,                                                                                                      --生效日期
[InvalidDate]      DATETIME,                                                                                                               --失效日期
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否默认地址：0、否；1、是
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --创建部门ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****通用主数据：企业会员表*****/

CREATE TABLE MDG_EntMember(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_EntMember PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Portrait]         VARCHAR(64),                                                                                                            --用户头像存放路径
[IdCardNo]         VARCHAR(18),                                                                                                            --身份证号
[EducateId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --学历ID
[Marital]          NVARCHAR(8),                                                                                                            --婚姻状况：单身；已婚；已婚已育；其他
[CompanyName]      NVARCHAR(32),                                                                                                           --单位名称
[IndustryType]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --行业类型ID，字典
[AnnualIncome]     NVARCHAR(8),                                                                                                            --年收入：6万以下；6万-10万；10万-15万；15-20万；20万以上
[Office]           NVARCHAR(8),                                                                                                            --职位：高管；中层；职员
[Phone]            VARCHAR(16),                                                       　　　　　　　　　　　　　　　　　　　　　　　　　　 --固定电话
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Loans]            DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --授信额度
[Available]        DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --可用额度
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --额度是否可用：0、不可用；1、可用
[Status]           INT DEFAULT 0 NOT NULL,                                                                                                 --状态：0、未提交；1、待核实；2、已核实；3、已拒绝
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --核实部门ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --核实人ID
[VerifyTime]       DATETIME,                                                                                                               --核实时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员授信资料表*****/

CREATE TABLE MDE_Member_CreditInfo(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_CreditInfo PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、身份证（正面）；2、身份证（反面）；3、身份证（手持）
[Name]             NVARCHAR(16) NOT NULL,                                                                                                  --授信资料名称
[Image]            VARCHAR(64) NOT NULL,                                                                                                   --授信资料存放路径
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --状态：1、待核实；2、已核实；3、已拒绝
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --核实部门ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --核实人ID
[VerifyTime]       DATETIME,                                                                                                               --核实时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员联系人表*****/

CREATE TABLE MDE_Member_Contact(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Contact PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、直系亲属；2、同事
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --联系人姓名
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --联系人手机号
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --状态：1、待核实；2、已核实；3、已拒绝
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --核实部门ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --核实人ID
[VerifyTime]       DATETIME,                                                                                                               --核实时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员银行卡表*****/

CREATE TABLE MDE_Member_Card(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Card PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --持卡人姓名
[Type]             NVARCHAR(4) NOT NULL,                                                                                                   --卡类型
[BankName]         NVARCHAR(8) NOT NULL,                                                                                                   --发卡银行
[Number]           VARCHAR(32) NOT NULL,                                                                                                   --卡号
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否默认卡：0、否；1、是
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员收货地址表*****/

CREATE TABLE MDE_Member_Address(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Address PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --联系人
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --手机号
[StateId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在省ID
[CityId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --所在地市ID
[CountyId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --所在区县ID
[Street]           NVARCHAR(32) NOT NULL,                                                                                                  --街道及门牌号
[ZipCode]          VARCHAR(6),                                                                                                             --邮编
[Description]      NVARCHAR(64),                                                                                                           --描述（完整地址）
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否默认地址：0、否；1、是
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员提现记录表*****/

CREATE TABLE MDE_Member_Withdrawal(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Withdrawal PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[CardId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDE_Member_Card(ID) NOT NULL,                                                   --绑定银行卡ID
[StagePlanId]      UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BIZ_StagePlan(ID) NOT NULL,                                                     --分期方案ID
[LoanAmount]       DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --提现金额
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --状态：1、待处理；2、已放款；
[LoanDeptId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --放款部门ID
[LoanUserId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --放款人ID
[LoanTime]         DATETIME,                                                                                                               --放款时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****主数据扩展：会员意见反馈表*****/

CREATE TABLE MDE_Member_Feedback(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Feedback PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --会员ID
[Complaint]        NVARCHAR(MAX),                                                                                                          --意见
[Reply]            NVARCHAR(MAX),                                                                                                          --处理结果
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --状态：1、待处理；2、已受理；3、已解决；4、已回复
[AcceptDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --处理部门ID
[AcceptUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --处理人ID
[AcceptTime]       DATETIME,                                                                                                               --处理时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****订单扩展表*****/

CREATE TABLE BIZ_Order(
[OID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Order PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ShopId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --店铺ID
[StagePlan]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BIZ_StagePlan(ID),                                                              --分期方案ID
[StageAmount]      DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --服务费
[FirstPay]         DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --首付款
[FirstPayChannel]  UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --收费支付渠道ID
[AddressId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDE_Member_Address(ID),                                                         --收货地址ID
[InvoiceType]      INT DEFAULT 1 NOT NULL,                                                                                                 --发票类型：1、个人；2、单位；3、增值税票
[InvoiceInfo]      NVARCHAR(128),                                                                                                          --发票信息
[PayStatus]        BIT DEFAULT 0 NOT NULL,                                                                                                 --是否付款：0、未付款；1、已付款
[CancelTime]       DATETIME DEFAULT GETDATE() NOT NULL,                                                                                    --取消时间
[RefundTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --退款时间
)
GO

/*****商品快照表*****/

CREATE TABLE BIZ_Product_Snapshot(
[SID]              UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Product_Snapshot PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ProductName]      NVARCHAR(64) NOT NULL,                                                                                                  --商品名称
[ProductPrice]     DECIMAL(20,4),                                                                                                          --商品单价
[ProductImage]     NVARCHAR(128) NOT NULL,                                                                                                 --图片路径
[Parameter]        NVARCHAR(MAX),                                                                                                          --商品参数
[PackingList]      NVARCHAR(MAX),                                                                                                          --包装清单
[Description]      NVARCHAR(MAX),                                                                                                          --商品描述
[ProductPic1]      NVARCHAR(128) NOT NULL,                                                                                                 --轮播图片1路径
[ProductPic2]      NVARCHAR(128) NOT NULL,                                                                                                 --轮播图片2路径
[ProductPic3]      NVARCHAR(128) NOT NULL,                                                                                                 --轮播图片3路径
[ProductPic4]      NVARCHAR(128) NOT NULL,                                                                                                 --轮播图片4路径
[ProductPic5]      NVARCHAR(128) NOT NULL,                                                                                                 --轮播图片5路径
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****验证记录表*****/

CREATE TABLE SYS_Verify_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Verify_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Type]             INT NOT NULL,                                                                                                           --类型：1、注册；2、重置密码
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --手机号
[Code]             VARCHAR(6) NOT NULL,                                                                                                    --验证码
[Verified]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否验证：0、否；1、是
[VerifyTime]       DATETIME,                                                                                                               --验证时间
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO