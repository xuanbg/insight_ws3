IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****ģ���*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --��������
[Binding]          VARCHAR(32) NOT NULL,                                                                               --������
[Port]             VARCHAR(32) NOT NULL,                                                                               --����˿ں�
[Name]             VARCHAR(32) NOT NULL,                                                                               --ģ������
[Class]            VARCHAR(64) NOT NULL,                                                                               --ʵ���������ռ�
[Interface]        VARCHAR(64) NOT NULL,                                                                               --�ӿ��������ռ�
[Location]         NVARCHAR(MAX),                                                                                      --�ļ����·��
)
GO

insert SYS_Interface (Binding, Port, Name, Class, Interface, Location)
select 'TCP', '6210', 'Login', 'Insight.WS.Service.Login', 'Insight.WS.Service.ILogin', 'Services' union all
select 'TCP', '6210', 'Commons', 'Insight.WS.Service.Commons', 'Insight.WS.Service.ICommons', 'Services' union all
select 'TCP', '6210', 'Base', 'Insight.WS.Service.Base', 'Insight.WS.Service.IBase', 'Services' union all
select 'TCP', '6210', 'Report', 'Insight.WS.Service.Report', 'Insight.WS.Service.IReport', 'Services' union all
select 'TCP', '6210', 'MasterDatas', 'Insight.WS.Service.MasterDatas', 'Insight.WS.Service.IMasterDatas', 'Services' union all

select 'TCP', '6210', 'CRM', 'Insight.WS.Service.Business.CRM', 'Insight.WS.Service.Business.ICRM', 'Services\Business' union all
select 'TCP', '6210', 'SCM', 'Insight.WS.Service.Business.SCM', 'Insight.WS.Service.Business.ISCM', 'Services\Business' union all
select 'TCP', '6210', 'Settlement', 'Insight.WS.Service.Business.Settlement', 'Insight.WS.Service.Business.ISettlement', 'Services\Business' union all

select 'HTTP', '6280', 'Interface', 'Insight.WS.Service.SuperDentist.Interface', 'Insight.WS.Service.SuperDentist.IInterface', 'Services\SuperDentist'
