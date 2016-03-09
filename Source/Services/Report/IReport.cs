using System;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    [ServiceContract]
    public partial interface IReport
    {

        /// <summary>
        /// 生成报表实例
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="rid">报表定义ID</param>
        /// <param name="sd">开始日期</param>
        /// <param name="ed">截止日期</param>
        /// <param name="on">统计实体全称</param>
        /// <param name="oid">统计实体ID</param>
        /// <returns>SYS_Report_Instances 报表实例</returns>
        [OperationContract]
        SYS_Report_Instances BulidReport(Session us, Guid rid, DateTime? sd, DateTime? ed, string on, Guid oid);

    }
}
