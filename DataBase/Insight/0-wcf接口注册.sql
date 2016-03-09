IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****ģ���*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --��������
[Port]             VARCHAR(8) NOT NULL,                                                                                --����˿ں�
[NameSpace]        VARCHAR(128) NOT NULL,                                                                              --ģ������
[Class]            VARCHAR(64) NOT NULL,                                                                               --ʵ���������ռ�
[Interface]        VARCHAR(64) NOT NULL,                                                                               --�ӿ��������ռ�
[ServiceFile]      NVARCHAR(MAX),                                                                                      --�ļ�·��
)
GO

insert SYS_Interface (Port, NameSpace, Class, Interface, ServiceFile)
select '6210', 'Insight.WS.Service', 'Commons', 'ICommons', 'Commons.dll' union all
select '6210', 'Insight.WS.Service', 'Report', 'IReport', 'Report.dll' union all
select '6210', 'Insight.WS.Service', 'MasterDatas', 'IMasterDatas', 'MasterDatas.dll' union all

select '6210', 'Insight.WS.Service.Business', 'CRM', 'ICRM', 'Business\CRM.dll' union all
select '6210', 'Insight.WS.Service.Business', 'SCM', 'ISCM', 'Business\SCM.dll' union all
select '6210', 'Insight.WS.Service.Business', 'Settlement', 'ISettlement', 'Business\Settlement.dll'
