IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****模块表*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --自增序列
[Name]             VARCHAR(32) NOT NULL,                                                                               --模块名称
[Class]            VARCHAR(64) NOT NULL,                                                                               --实现类命名空间
[Interface]        VARCHAR(64) NOT NULL,                                                                               --接口类命名空间
[Location]         NVARCHAR(MAX),                                                                                      --文件相对路径
)
GO

insert SYS_Interface (Name, Class, Interface, Location)
select 'Login', 'Insight.WS.Service.Login', 'Insight.WS.Service.ILogin', 'Services' union all
select 'Commons', 'Insight.WS.Service.Commons', 'Insight.WS.Service.ICommons', 'Services' union all
select 'Base', 'Insight.WS.Service.Base', 'Insight.WS.Service.IBase', 'Services' union all
select 'Report', 'Insight.WS.Service.Report', 'Insight.WS.Service.IReport', 'Services' union all
select 'MasterDatas', 'Insight.WS.Service.MasterDatas', 'Insight.WS.Service.IMasterDatas', 'Services' union all

select 'XfbInterface', 'Insight.WS.Service.XinFenBao.Interface', 'Insight.WS.Service.XinFenBao.IInterface', 'Services' union all
select 'XfbManager', 'Insight.WS.Service.XinFenBao.Manager', 'Insight.WS.Service.XinFenBao.IManager', 'Services' union all

select 'CRM', 'Insight.WS.Service.Business.CRM', 'Insight.WS.Service.Business.ICRM', 'Services\\Business' union all
select 'SCM', 'Insight.WS.Service.Business.SCM', 'Insight.WS.Service.Business.ISCM', 'Services\\Business' union all
select 'Settlement', 'Insight.WS.Service.Business.Settlement', 'Insight.WS.Service.Business.ISettlement', 'Services\\Business'
