using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{

    public partial interface IReport
    {

        /// <summary>
        /// 获取当前用户所有可选报表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 可阅读报表</returns>
        [OperationContract]
        DataTable GetMyReports(Session us);

        /// <summary>
        /// 获取当前用户所有可阅读报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 报表实例</returns>
        [OperationContract]
        DataTable GetInstances(Session us);

        /// <summary>
        /// 获得用户可选组织机构列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="reportId">所选报表ID</param>
        /// <returns>DataTable 可选组织机构列表</returns>
        [OperationContract]
        DataTable GetMyReportEntitys(Session us, Guid reportId);

        /// <summary>
        /// 根据ID获取报表定义对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表ID</param>
        /// <returns>SYS_Report_Definition 报表定义对象实体</returns>
        [OperationContract]
        SYS_Report_Definition GetDefinition(Session us, Guid id);

        /// <summary>
        /// 根据ID获取报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表实例ID</param>
        /// <returns>SYS_Report_Instances 报表实例</returns>
        [OperationContract]
        SYS_Report_Instances GetReportInstance(Session us, Guid id);

        /// <summary>
        /// 添加即时报表数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">报表实例对象实体</param>
        /// <returns>object 返回插入成功记录的ID</returns>
        [OperationContract]
        SYS_Report_IU AddInstance(Session us, SYS_Report_Instances obj);

        /// <summary>
        /// 删除报表实例和用户关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">报表实例和用户关系ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DeleteReportIU(Session us, Guid id);

    }
}
