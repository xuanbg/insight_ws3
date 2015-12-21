IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDO_Recommend') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDO_Recommend
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDO_Advertisement') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDO_Advertisement
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Praise') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Praise
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Comment') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Comment
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Attitude') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Attitude
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Voice') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Voice
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Forward') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Forward
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDT_Topic') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDT_Topic
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDG_GroupMember') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDG_GroupMember
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDG_Group') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDG_Group
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDC_Summary') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDC_Summary
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDC_Subsequent') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDC_Subsequent
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDC_FirstVisit') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDC_FirstVisit
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SDC_CaseHistory') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SDC_CaseHistory
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Favorites') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Favorites
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDE_Message') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDE_Message
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'MDG_Member') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE MDG_Member
GO


/*****会员*****/

/*****会员扩展表*****/

CREATE TABLE MDG_Member(
[MID]              UNIQUEIDENTIFIER CONSTRAINT IX_MDG_Member PRIMARY KEY FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE,
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Portrait]         VARCHAR(64),                                                                                                            --用户头像存放路径
[Integral]         INT DEFAULT 0 NOT NULL,                                                                                                 --积分
[Beans]            INT DEFAULT 0 NOT NULL,                                                                                                 --魔豆
[Country]          NVARCHAR(32),                                                                                                           --所在国家
[State]            NVARCHAR(32),                                                                                                           --所在省
[City]             NVARCHAR(32),                                                                                                           --所在地市
[County]           NVARCHAR(32),                                                                                                           --所在区县
[Street]           NVARCHAR(32),                                                                                                           --街道及门牌号
[ZipCode]          VARCHAR(6),                                                                                                             --邮编
)
GO

/*****私信表*****/

CREATE TABLE MDE_Message(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Message PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[ReceiveUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --接收人ID
[Content]          NVARCHAR(MAX) NOT NULL,                                                                                                 --私信内容
[SendTime]         DATETIME,                                                                                                               --发送时间
[HaveRead]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否已读：0、未读；1、已读
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) DEFAULT '00000000-0000-0000-0000-000000000000' NOT NULL,           --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****收藏表*****/

CREATE TABLE MDE_Favorites(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_MDE_Favorites PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Type]             INT NOT NULL,                                                                                                           --类型：1、群组；2、话题；3、讨论；4、视频
[ObjectId]         UNIQUEIDENTIFIER NOT NULL,                                                                                              --收藏对象ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****病历*****/

/*****病历表*****/

CREATE TABLE SDC_CaseHistory(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDC_CaseHistory PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[PatientName]      NVARCHAR(16) NOT NULL,                                                                                                  --患者姓名
[Gender]           INT NOT NULL,                                                                                                           --性别：0、女；1、男
[Birthday]         DATETIME,                                                                                                               --出生日期
[Phone]            NVARCHAR(32),                                                                                                           --联系电话
[WeChat]           NVARCHAR(32),                                                                                                           --微信号
[OpenId]           NVARCHAR(32),                                                                                                           --微信OpenId
[Secret]           INT DEFAULT 1 NOT NULL,                                                                                                 --密级：0、完全公开；1、可搜索，可分享；2、可搜索，不可分享；3、仅可二维码检索，不可分享
[Description]      NVARCHAR(128),                                                                                                          --描述
[UpdateTime]       DATETIME DEFAULT GETDATE() NOT NULL,                                                                                    --最后更新时间
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****初诊表*****/

CREATE TABLE SDC_FirstVisit(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDC_FirstVisit PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CaseHistoryId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDC_CaseHistory(ID) ON DELETE CASCADE NOT NULL,                                 --病历ID
[Complained]       NVARCHAR(64),                                                                                                           --主诉
[MedicalHistory]   NVARCHAR(512),                                                                                                          --现病史
[Previous]         NVARCHAR(128),                                                                                                          --既往史
[Inspection]       NVARCHAR(MAX),                                                                                                          --检查
[Diagnosis]        NVARCHAR(32),                                                                                                           --诊断
[TherapyPlan]      NVARCHAR(128),                                                                                                          --治疗计划
[Therapy]          NVARCHAR(MAX),                                                                                                          --治疗过程记录
[Notify]           NVARCHAR(128),                                                                                                          --医嘱
[KeyWord]          NVARCHAR(64),                                                                                                           --关键词
[Description]      NVARCHAR(128),                                                                                                          --描述
[DoctorId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --主诊医生ID
[NurseId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --护理人ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****复诊表*****/

CREATE TABLE SDC_Subsequent(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDC_Subsequent PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDC_FirstVisit(ID),                                                             --病例ID
[MedicalHistory]   NVARCHAR(512),                                                                                                          --现病史
[Inspection]       NVARCHAR(MAX),                                                                                                          --检查
[TherapyPlan]      NVARCHAR(256),                                                                                                          --治疗计划
[Therapy]          NVARCHAR(MAX),                                                                                                          --治疗过程记录
[Notify]           NVARCHAR(128),                                                                                                          --医嘱
[KeyWord]          NVARCHAR(64),                                                                                                           --关键词
[Description]      NVARCHAR(128),                                                                                                          --描述
[DoctorId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --主诊医生ID
[NurseId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID),                                                                 --护理人ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****总结表*****/

CREATE TABLE SDC_Summary(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDC_Summary PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDC_FirstVisit(ID),                                                             --病例ID
[Content]          NVARCHAR(MAX) NOT NULL,                                                                                                 --总结内容
[KeyWord]          NVARCHAR(64),                                                                                                           --关键词
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****群组*****/

/*****群组表*****/

CREATE TABLE SDG_Group(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDG_Group PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Name]             NVARCHAR(32) NOT NULL,                                                                                                  --群名称
[Description]      NVARCHAR(128),                                                                                                          --群描述
[Icon]             VARCHAR(64),                                                                                                            --群图标
[Picture]          VARCHAR(64),                                                                                                            --群图片
[Heat]             INT DEFAULT 0 NOT NULL,                                                                                                 --热度
[Topics]           INT DEFAULT 0 NOT NULL,                                                                                                 --话题数
[Members]          INT DEFAULT 0 NOT NULL,                                                                                                 --成员数
[OwnerUserId]      UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --群主ID
[ManageUserId]     UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID),                                                                   --群管理员ID
[Validity]         BIT DEFAULT 1 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****群成员表*****/

CREATE TABLE SDG_GroupMember(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDG_GroupMember PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[GroupId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDG_Group(ID) ON DELETE CASCADE NOT NULL,                                       --群组ID
[MemberId]         UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) ON DELETE CASCADE NOT NULL,                                      --成员ID
[Validity]         BIT DEFAULT 0 NOT NULL,                                                                                                 --是否有效：0、无效；1、有效
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****话题*****/

/*****话题表*****/

CREATE TABLE SDT_Topic(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Topic PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Title]            NVARCHAR(64) NOT NULL,                                                                                                  --标题
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Tags]             NVARCHAR(64),                                                                                                           --话题标签
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDC_FirstVisit(ID),                                                             --病例ID
[Private]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否私有：0、公开，访客可读，可转发；1、私有，访客不可读，不可转发
[PublishGroupId]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDG_Group(ID),                                                                  --发布群组ID
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****话题转发记录表*****/

CREATE TABLE SDT_Forward(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Forward PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TopicId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDT_Topic(ID) ON DELETE CASCADE NOT NULL,                                       --话题ID
[GroupId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDG_Group(ID) ON DELETE CASCADE NOT NULL,                                       --群组ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****讨论表*****/

CREATE TABLE SDT_Voice(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Voice PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TopicId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDT_Topic(ID) ON DELETE CASCADE NOT NULL,                                       --话题ID
[Content]          NVARCHAR(MAX) NOT NULL,                                                                                                 --发言内容
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDC_FirstVisit(ID),                                                             --病例ID
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****讨论态度表*****/

CREATE TABLE SDT_Attitude(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Attitude PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[VoiceId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDT_Voice(ID) ON DELETE CASCADE NOT NULL,                                       --发言ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、赞同；2、反对；3、赞；4、没有帮助
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****评论表*****/

CREATE TABLE SDT_Comment(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Comment PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[VoiceId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDT_Voice(ID) ON DELETE CASCADE NOT NULL,                                       --发言ID
[Content]          NVARCHAR(512) NOT NULL,                                                                                                 --评论内容
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****评论态度表*****/

CREATE TABLE SDT_Praise(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDT_Praise PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CommentId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SDT_Comment(ID) ON DELETE CASCADE NOT NULL,                                     --评论ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、赞；2、举报
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO



/*****轮播图表*****/

CREATE TABLE SDO_Advertisement(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDO_Advertisement PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Type]             INT NOT NULL,                                                                                                           --类型：1、首页轮播；2、群组轮播
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****首页推荐表*****/

CREATE TABLE SDO_Recommend(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SDO_Recommend PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO
