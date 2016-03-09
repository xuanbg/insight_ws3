using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service.Business
{
    [ServiceContract]
    public interface ISCM
    {

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 供应商列表</returns>
        [OperationContract]
        DataTable GetSuppliers(Session us);

        /// <summary>
        /// 获取供应商详细信息列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 供应商详细信息列表</returns>
        [OperationContract]
        DataTable GetSupplierInfo(Session us);

        /// <summary>
        /// 根据ID获取供应商对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">供应商ID</param>
        /// <returns>MDG_Supplier 供应商对象实体</returns>
        [OperationContract]
        MDG_Supplier GetSupplier(Session us, Guid id);

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Supplier对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddMasterData(Session us, MasterData m, MDG_Supplier d);

        /// <summary>
        /// 更新供应商数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Supplier对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateMasterData(Session us, MasterData m, MDG_Supplier d);

    }
}
