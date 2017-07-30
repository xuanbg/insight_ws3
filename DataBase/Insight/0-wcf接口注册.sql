use Insight_WS
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
[Version]          VARCHAR(8),                                                                                         --����汾��
[NameSpace]        VARCHAR(128) NOT NULL,                                                                              --���������ռ�
[Interface]        VARCHAR(64) NOT NULL,                                                                               --�ӿ�����
[Service]          VARCHAR(64) NOT NULL,                                                                               --����������
[ServiceFile]      NVARCHAR(MAX)  NOT NULL,                                                                            --�ļ�·��
)
GO

insert SYS_Interface (Port, Path, Version, NameSpace, Interface, Service, ServiceFile)
select '6280', 'commonapi', 'v1.0', 'Insight.WS.Service', 'ICommons', 'Commons', 'Services\Commons.dll' union all
select '6280', 'dataapi', 'v1.0', 'Insight.WS.Service', 'IMasterDatas', 'MasterDatas', 'Services\MasterDatas.dll' union all
select '6280', 'crmapi', 'v1.0', 'Insight.WS.Service.Business', 'ICRM', 'CRM', 'Services\CRM.dll' union all
select '6280', 'scmapi', 'v1.0', 'Insight.WS.Service.Business', 'ISCM', 'SCM', 'Services\SCM.dll' union all
select '6280', 'settleapi', 'v1.0', 'Insight.WS.Service.Business', 'ISettlement', 'Settlement', 'Services\Settlement.dll'
