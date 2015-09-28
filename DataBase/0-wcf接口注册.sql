IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****模块表*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --自增序列
[Binding]          VARCHAR(32) NOT NULL,                                                                               --绑定类型
[Name]             VARCHAR(32) NOT NULL,                                                                               --模块名称
[Class]            VARCHAR(64) NOT NULL,                                                                               --实现类命名空间
[Interface]        VARCHAR(64) NOT NULL,                                                                               --接口类命名空间
[Location]         NVARCHAR(MAX),                                                                                      --文件相对路径
)
GO

insert SYS_Interface (Binding, Name, Class, Interface, Location)
select 'TCP', 'Login', 'Insight.WS.Service.Login', 'Insight.WS.Service.ILogin', 'Services' union all
select 'TCP', 'Commons', 'Insight.WS.Service.Commons', 'Insight.WS.Service.ICommons', 'Services' union all
select 'TCP', 'Base', 'Insight.WS.Service.Base', 'Insight.WS.Service.IBase', 'Services' union all
select 'TCP', 'Report', 'Insight.WS.Service.Report', 'Insight.WS.Service.IReport', 'Services' union all
select 'TCP', 'MasterDatas', 'Insight.WS.Service.MasterDatas', 'Insight.WS.Service.IMasterDatas', 'Services' union all

select 'TCP', 'CRM', 'Insight.WS.Service.Business.CRM', 'Insight.WS.Service.Business.ICRM', 'Services\\Business' union all
select 'TCP', 'SCM', 'Insight.WS.Service.Business.SCM', 'Insight.WS.Service.Business.ISCM', 'Services\\Business' union all
select 'TCP', 'Settlement', 'Insight.WS.Service.Business.Settlement', 'Insight.WS.Service.Business.ISettlement', 'Services\\Business'
