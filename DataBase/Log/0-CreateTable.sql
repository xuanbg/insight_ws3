USE Insight_Log
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Logs') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Logs
GO
IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Logs_Rules') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Logs_Rules
GO


/*****��־���ݱ�*****/

/*****��־�����*****/

CREATE TABLE SYS_Logs_Rules(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Logs_Rules PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[Code]             VARCHAR(6) NOT NULL,                                                                                                    --��������
[ToDataBase]       BIT DEFAULT 0 NOT NULL,                                                                                                 --�Ƿ�д�����ݿ⣺0����1����
[Level]            INT DEFAULT 0 NOT NULL,                                                                                                 --��־�ȼ���0��Emergency��1��Alert��2��Critical��3��Error��4��Warning��5��Notice��6��Informational��7��Debug
[Source]           NVARCHAR(16),                                                                                                           --�¼���Դ
[Action]           NVARCHAR(16),                                                                                                           --��������
[Message]          NVARCHAR(128),                                                                                                          --��־Ĭ������
[CreatorUserId]    UNIQUEIDENTIFIER NOT NULL,                                                                                              --������ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO

/*****��־��*****/

CREATE TABLE SYS_Logs(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Logs PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                                                   --��������
[Level]            INT NOT NULL,                                                                                                           --��־�ȼ���0��Emergency��1��Alert��2��Critical��3��Error��4��Warning��5��Notice��6��Informational��7��Debug
[Code]             VARCHAR(6),                                                                                                             --��������
[Source]           NVARCHAR(16) NOT NULL,                                                                                                  --�¼���Դ
[Action]           NVARCHAR(16) NOT NULL,                                                                                                  --��������
[Message]          NVARCHAR(MAX),                                                                                                          --��־����
[SourceUserId]     UNIQUEIDENTIFIER,                                                                                                       --��Դ�û�ID
[CreateTime]       DATETIME DEFAULT GETDATE() NOT NULL                                                                                     --����ʱ��
)
GO


