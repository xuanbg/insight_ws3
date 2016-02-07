using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{

    public partial interface IReport
    {

        /// <summary>
        /// 获取全部分期规则
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分期规则列表</returns>
        [OperationContract]
        DataTable GetRules(Session us);

        /// <summary>
        /// 根据ID获取分期规则对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期规则ID</param>
        /// <returns>SYS_Report_Rules 分期规则对象实体</returns>
        [OperationContract]
        SYS_Report_Rules GetRule(Session us, Guid id);

        /// <summary>
        /// 插入一条分期规则记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期规则对象实体</param>
        /// <returns>object 返回插入成功记录的ID</returns>
        [OperationContract]
        object AddRule(Session us, SYS_Report_Rules obj);

        /// <summary>
        /// 根据对象实体更新分期规则
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期规则对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool EditRule(Session us, SYS_Report_Rules obj);

        /// <summary>
        /// 根据ID删除分期规则记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期规则ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelRule(Session us, Guid id);

    }
}
