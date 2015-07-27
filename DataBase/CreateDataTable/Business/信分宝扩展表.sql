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

/*****�ŷֱ���չ��*****/

/*****�ֲ���Ʒ��*****/

CREATE TABLE BIZ_Advertiser(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Advertiser PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[Index]            INT NOT NULL,                                                                                                           --���
[Name]             NVARCHAR(64) NOT NULL,                                                                                                  --��Ʒ����
[TargetURL]        NVARCHAR(128) NOT NULL,                                                                                                 --Ŀ���ַ
[ImageURL]         NVARCHAR(128) NOT NULL,                                                                                                 --ͼƬ·��
[ProductId]        INT NOT NULL,                                                                                                           --��ƷID
[ProductCode]      VARCHAR(32) NOT NULL,                                                                                                   --��Ʒ���
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****���ڷ�����*****/

CREATE TABLE BIZ_StagePlan(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_StagePlan PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[StageNum]         INT NOT NULL,                                                                                                           --������
[Rate]           ��DECIMAL(20,4) NOT NULL,                                                                                                 --����
[EffectiveDate]    DATETIME NOT NULL,                                                                                                      --��Ч����
[InvalidDate]      DATETIME,                                                                                                               --ʧЧ����
[Description]      NVARCHAR(MAX),                                                                                                          --����
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --�Ƿ���Ч��0����Ч��1����Ч
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ�Ĭ�ϵ�ַ��0����1����
[CreatorDeptId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --��������ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID) NOT NULL,                                                          --������ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****ͨ�������ݣ���ҵ��Ա��*****/

CREATE TABLE MDG_EntMember(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_EntMember PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[Portrait]         VARCHAR(64),                                                                                                            --�û�ͷ����·��
[IdCardNo]         VARCHAR(18),                                                                                                            --���֤��
[EducateId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --ѧ��ID
[Marital]          NVARCHAR(8),                                                                                                            --����״���������ѻ飻�ѻ�����������
[CompanyName]      NVARCHAR(32),                                                                                                           --��λ����
[IndustryType]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --��ҵ����ID���ֵ�
[AnnualIncome]     NVARCHAR(8),                                                                                                            --�����룺6�����£�6��-10��10��-15��15-20��20������
[Office]           NVARCHAR(8),                                                                                                            --ְλ���߹ܣ��в㣻ְԱ
[Phone]            VARCHAR(16),                                                       ���������������������������������������������������� --�̶��绰
[Description]      NVARCHAR(MAX),                                                                                                          --����
[Loans]            DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --���Ŷ��
[Available]        DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --���ö��
[Enable]           BIT DEFAULT 1 NOT NULL,                                                                                                 --����Ƿ���ã�0�������ã�1������
[Status]           INT DEFAULT 0 NOT NULL,                                                                                                 --״̬��0��δ�ύ��1������ʵ��2���Ѻ�ʵ��3���Ѿܾ�
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --��ʵ����ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --��ʵ��ID
[VerifyTime]       DATETIME,                                                                                                               --��ʵʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա�������ϱ�*****/

CREATE TABLE MDE_Member_CreditInfo(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_CreditInfo PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[Type]             INT NOT NULL,                                                                                                           --���ͣ�1�����֤�����棩��2�����֤�����棩��3�����֤���ֳ֣�
[Name]             NVARCHAR(16) NOT NULL,                                                                                                  --������������
[Image]            VARCHAR(64) NOT NULL,                                                                                                   --�������ϴ��·��
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --״̬��1������ʵ��2���Ѻ�ʵ��3���Ѿܾ�
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --��ʵ����ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --��ʵ��ID
[VerifyTime]       DATETIME,                                                                                                               --��ʵʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա��ϵ�˱�*****/

CREATE TABLE MDE_Member_Contact(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Contact PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[Type]             INT NOT NULL,                                                                                                           --���ͣ�1��ֱϵ������2��ͬ��
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --��ϵ������
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --��ϵ���ֻ���
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --״̬��1������ʵ��2���Ѻ�ʵ��3���Ѿܾ�
[VerifyDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --��ʵ����ID
[VerifyUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --��ʵ��ID
[VerifyTime]       DATETIME,                                                                                                               --��ʵʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա���п���*****/

CREATE TABLE MDE_Member_Card(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Card PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --�ֿ�������
[Type]             NVARCHAR(4) NOT NULL,                                                                                                   --������
[BankName]         NVARCHAR(8) NOT NULL,                                                                                                   --��������
[Number]           VARCHAR(32) NOT NULL,                                                                                                   --����
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ�Ĭ�Ͽ���0����1����
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --�Ƿ���Ч��0����Ч��1����Ч
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա�ջ���ַ��*****/

CREATE TABLE MDE_Member_Address(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Address PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[Name]             NVARCHAR(8) NOT NULL,                                                                                                   --��ϵ��
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --�ֻ���
[StateId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --����ʡID
[CityId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BASE_Category(ID),                                                              --���ڵ���ID
[CountyId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --��������ID
[Street]           NVARCHAR(32) NOT NULL,                                                                                                  --�ֵ������ƺ�
[ZipCode]          VARCHAR(6),                                                                                                             --�ʱ�
[Description]      NVARCHAR(64),                                                                                                           --������������ַ��
[Default]          BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ�Ĭ�ϵ�ַ��0����1����
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --�Ƿ���Ч��0����Ч��1����Ч
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա���ּ�¼��*****/

CREATE TABLE MDE_Member_Withdrawal(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Withdrawal PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[CardId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDE_Member_Card(ID) NOT NULL,                                                   --�����п�ID
[StagePlanId]      UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BIZ_StagePlan(ID) NOT NULL,                                                     --���ڷ���ID
[LoanAmount]       DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --���ֽ��
[Description]      NVARCHAR(MAX),                                                                                                          --����
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --״̬��1��������2���ѷſ
[LoanDeptId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --�ſ��ID
[LoanUserId]       UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --�ſ���ID
[LoanTime]         DATETIME,                                                                                                               --�ſ�ʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��������չ����Ա���������*****/

CREATE TABLE MDE_Member_Feedback(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Member_Feedback PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --��ԱID
[Complaint]        NVARCHAR(MAX),                                                                                                          --���
[Reply]            NVARCHAR(MAX),                                                                                                          --������
[Description]      NVARCHAR(MAX),                                                                                                          --����
[Status]           INT DEFAULT 1 NOT NULL,                                                                                                 --״̬��1��������2��������3���ѽ����4���ѻظ�
[AcceptDeptId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_Organization(ID),                                                           --������ID
[AcceptUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Sys_User(ID),                                                                   --������ID
[AcceptTime]       DATETIME,                                                                                                               --����ʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO


/*****������չ��*****/

CREATE TABLE BIZ_Order(
[OID]              UNIQUEIDENTIFIER  CONSTRAINT IX_BIZ_Order PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[ShopId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --����ID
[StagePlan]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES BIZ_StagePlan(ID),                                                              --���ڷ���ID
[StageAmount]      DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --�����
[FirstPay]         DECIMAL(20,2) DEFAULT 0 NOT NULL,                                                                                       --�׸���
[FirstPayChannel]  UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDG_Dictionary(MID),                                                            --�շ�֧������ID
[AddressId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MDE_Member_Address(ID),                                                         --�ջ���ַID
[InvoiceType]      INT DEFAULT 1 NOT NULL,                                                                                                 --��Ʊ���ͣ�1�����ˣ�2����λ��3����ֵ˰Ʊ
[InvoiceInfo]      NVARCHAR(128),                                                                                                          --��Ʊ��Ϣ
[PayStatus]        BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ񸶿0��δ���1���Ѹ���
[CancelTime]       DATETIME DEFAULT GETDATE() NOT NULL,                                                                                    --ȡ��ʱ��
[RefundTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --�˿�ʱ��
)
GO

/*****��Ʒ���ձ�*****/

CREATE TABLE BIZ_Product_Snapshot(
[SID]              UNIQUEIDENTIFIER CONSTRAINT IX_BIZ_Product_Snapshot PRIMARY KEY FOREIGN KEY REFERENCES ABS_Contract_Subjects(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[ProductName]      NVARCHAR(64) NOT NULL,                                                                                                  --��Ʒ����
[ProductPrice]     DECIMAL(20,4),                                                                                                          --��Ʒ����
[ProductImage]     NVARCHAR(128) NOT NULL,                                                                                                 --ͼƬ·��
[Parameter]        NVARCHAR(MAX),                                                                                                          --��Ʒ����
[PackingList]      NVARCHAR(MAX),                                                                                                          --��װ�嵥
[Description]      NVARCHAR(MAX),                                                                                                          --��Ʒ����
[ProductPic1]      NVARCHAR(128) NOT NULL,                                                                                                 --�ֲ�ͼƬ1·��
[ProductPic2]      NVARCHAR(128) NOT NULL,                                                                                                 --�ֲ�ͼƬ2·��
[ProductPic3]      NVARCHAR(128) NOT NULL,                                                                                                 --�ֲ�ͼƬ3·��
[ProductPic4]      NVARCHAR(128) NOT NULL,                                                                                                 --�ֲ�ͼƬ4·��
[ProductPic5]      NVARCHAR(128) NOT NULL,                                                                                                 --�ֲ�ͼƬ5·��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO


/*****��֤��¼��*****/

CREATE TABLE SYS_Verify_Record(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Verify_Record PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[Type]             INT NOT NULL,                                                                                                           --���ͣ�1��ע�᣻2����������
[Mobile]           VARCHAR(11) NOT NULL,                                                                                                   --�ֻ���
[Code]             VARCHAR(6) NOT NULL,                                                                                                    --��֤��
[Verified]         BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ���֤��0����1����
[VerifyTime]       DATETIME,                                                                                                               --��֤ʱ��
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO