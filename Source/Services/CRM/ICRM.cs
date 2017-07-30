using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.Business
{
    [ServiceContract]
    public interface ICRM
    {

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 客户列表</returns>
        [OperationContract]
        DataTable GetCustomers(Session us);

        /// <summary>
        /// 获取客户详细信息列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 客户详细信息列表</returns>
        [OperationContract]
        DataTable GetCustomerInfo(Session us);

        /// <summary>
        /// 根据ID获取客户对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">客户ID</param>
        /// <returns>MDG_Customer 客户对象实体</returns>
        [OperationContract]
        MDG_Customer GetCustomer(Session us, Guid id);

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Customer对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddCustomer(Session us, MasterData m, MDG_Customer d);

        /// <summary>
        /// 更新客户数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Customer对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateCustomer(Session us, MasterData m, MDG_Customer d);

    }
}
