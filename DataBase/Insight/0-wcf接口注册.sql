IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'SYS_Interface') AND OBJECTPROPERTY(id, N'ISUSERTABLE') = 1)
DROP TABLE SYS_Interface
GO
/*****模块表*****/

CREATE TABLE SYS_Interface(
[ID]               UNIQUEIDENTIFIER CONSTRAINT IX_SYS_Interface PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[SN]               BIGINT IDENTITY(1,1),                                                                               --自增序列
[Port]             VARCHAR(8) NOT NULL,                                                                                --服务端口号
[NameSpace]        VARCHAR(128) NOT NULL,                                                                              --模块名称
[Class]            VARCHAR(64) NOT NULL,                                                                               --实现类命名空间
[Interface]        VARCHAR(64) NOT NULL,                                                                               --接口类命名空间
[ServiceFile]      NVARCHAR(MAX),                                                                                      --文件路径
)
GO

insert SYS_Interface (Port, NameSpace, Class, Interface, ServiceFile)
select '6210', 'Insight.WS.Service', 'Commons', 'ICommons', 'Commons.dll' union all
select '6210', 'Insight.WS.Service', 'Report', 'IReport', 'Report.dll' union all
select '6210', 'Insight.WS.Service', 'MasterDatas', 'IMasterDatas', 'MasterDatas.dll' union all

select '6210', 'Insight.WS.Service.Business', 'CRM', 'ICRM', 'Business\CRM.dll' union all
select '6210', 'Insight.WS.Service.Business', 'SCM', 'ISCM', 'Business\SCM.dll' union all
select '6210', 'Insight.WS.Service.Business', 'Settlement', 'ISettlement', 'Business\Settlement.dll'
