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
        /// 获取所有模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 模板列表</returns>
        [OperationContract]
        DataTable GetTemplates(Session us);

        /// <summary>
        /// 根据ID获取模板对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">模板ID</param>
        /// <returns>SYS_Report_Templates 模板对象实体</returns>
        [OperationContract]
        SYS_Report_Templates GetTemplate(Session us, Guid id);

        /// <summary>
        /// 复制模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="tid">源模板ID</param>
        /// <param name="obj">SYS_Report_Templates对象实体</param>
        /// <returns>object 新模板ID</returns>
        [OperationContract]
        object CopyTemplet(Session us, Guid tid, SYS_Report_Templates obj);

        /// <summary>
        /// 增加一个模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">SYS_Report_Templates对象实体</param>
        /// <returns>object 新模板ID</returns>
        [OperationContract]
        object AddTemplet(Session us, SYS_Report_Templates obj);

        /// <summary>
        /// 根据传入的模板对象实体更新模板信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool EditTemplets(Session us, SYS_Report_Templates obj);

        /// <summary>
        /// 用传入的参数Content更新指定ID的模板Content字段
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="content">模板内容</param>
        /// <param name="id">模板ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateContent(Session us, string content, Guid id);

        /// <summary>
        /// 删除指定ID的模板
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">模板ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelTemplets(Session us, Guid id);

    }
}
