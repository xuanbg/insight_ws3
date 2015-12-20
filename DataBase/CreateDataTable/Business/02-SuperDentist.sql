
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Praise') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Praise
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Comment') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Comment
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Attitude') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Attitude
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Voice') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Voice
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Forward') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Forward
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'TOP_Topic') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE TOP_Topic
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SOC_Group') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SOC_Group
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'DCH_FirstVisit') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE DCH_FirstVisit
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'DCH_CaseHistory') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE DCH_CaseHistory
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
[ReceiveUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES MasterData(ID) NOT NULL,                                                        --接收人ID
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

CREATE TABLE DCH_CaseHistory(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_DCH_CaseHistory PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****初诊表*****/

CREATE TABLE DCH_FirstVisit(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_DCH_FirstVisit PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CaseHistoryId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES DCH_CaseHistory(ID) ON DELETE CASCADE NOT NULL,                                 --病历ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****群组*****/

/*****群组表*****/

CREATE TABLE SOC_Group(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SOC_Group PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO


/*****话题*****/

/*****话题表*****/

CREATE TABLE TOP_Topic(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Topic PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[Title]            NVARCHAR(64),                                                                                                           --标题
[Description]      NVARCHAR(MAX),                                                                                                          --描述
[Tags]             NVARCHAR(64),                                                                                                           --话题标签
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES DCH_FirstVisit(ID),                                                             --病历ID
[Private]          BIT DEFAULT 0 NOT NULL,                                                                                                 --是否私有：0、公开；1、私有
[PublishGroupId]   UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SOC_Group(ID),                                                                  --发布群组ID
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****话题转发记录表*****/

CREATE TABLE TOP_Forward(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Forward PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TopicId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TOP_Topic(ID) ON DELETE CASCADE NOT NULL,                                       --话题ID
[GroupId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SOC_Group(ID) ON DELETE CASCADE NOT NULL,                                       --群组ID
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****讨论表*****/

CREATE TABLE TOP_Voice(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Voice PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[TopicId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TOP_Topic(ID) ON DELETE CASCADE NOT NULL,                                       --话题ID
[Content]          NVARCHAR(MAX) NOT NULL,                                                                                                 --发言内容
[CaseId]           UNIQUEIDENTIFIER FOREIGN KEY REFERENCES DCH_FirstVisit(ID),                                                             --病历ID
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****讨论态度表*****/

CREATE TABLE TOP_Attitude(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Attitude PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[VoiceId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TOP_Voice(ID) ON DELETE CASCADE NOT NULL,                                       --发言ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、赞同；2、反对；3、赞；4、没有帮助
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****评论表*****/

CREATE TABLE TOP_Comment(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Comment PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[VoiceId]          UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TOP_Voice(ID) ON DELETE CASCADE NOT NULL,                                       --发言ID
[Content]          NVARCHAR(512) NOT NULL,                                                                                                 --评论内容
[PublishTime]      DATETIME,                                                                                                               --发布时间
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO

/*****评论态度表*****/

CREATE TABLE TOP_Praise(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_TOP_Praise PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --自增序列
[CommentId]        UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TOP_Comment(ID) ON DELETE CASCADE NOT NULL,                                     --评论ID
[Type]             INT NOT NULL,                                                                                                           --类型：1、赞；2、举报
[CreatorUserId]    UNIQUEIDENTIFIER FOREIGN KEY REFERENCES SYS_User(ID) NOT NULL,                                                          --创建人ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --创建时间
)
GO



