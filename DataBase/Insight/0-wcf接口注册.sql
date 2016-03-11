use Insight
go

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****ģ���*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --��������
[Port]             VARCHAR(8),                                                                                         --����˿ں�
[Path]             VARCHAR(16),                                                                                        --����·��
[NameSpace]        VARCHAR(128) NOT NULL,                                                                              --���������ռ�
[Interface]        VARCHAR(64) NOT NULL,                                                                               --�ӿ�����
[Service]          VARCHAR(64) NOT NULL,                                                                               --����������
[ServiceFile]      NVARCHAR(MAX)  NOT NULL,                                                                            --�ļ�·��
)
GO

insert SYS_Interface (Port, Path, NameSpace, Interface, Service, ServiceFile)
select NULL, NULL, 'Insight.WS.Service', 'ICommons', 'Commons', 'Commons.dll' union all
select NULL, 'masterdata', 'Insight.WS.Service', 'IMasterDatas', 'MasterDatas', 'MasterDatas.dll' union all
select NULL, 'crm', 'Insight.WS.Service.Business', 'ICRM', 'CRM', 'Business\CRM.dll' union all
select NULL, 'scm', 'Insight.WS.Service.Business', 'ISCM', 'SCM', 'Business\SCM.dll' union all
select NULL, 'settle', 'Insight.WS.Service.Business', 'ISettlement', 'Settlement', 'Business\Settlement.dll'
