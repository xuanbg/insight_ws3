using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial interface IMasterDatas
    {

        /// <summary>
        /// 根据权限获取字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 所有字典数据</returns>
        [OperationContract]
        DataTable GetDictionarys(Session us);

        /// <summary>
        /// 根据ID获取MDG_Dictionary对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">字典数据ID</param>
        /// <returns>MDG_Dictionary对象实体</returns>
        [OperationContract]
        MDG_Dictionary GetDictionary(Session us, Guid id);

        /// <summary>
        /// 添加字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Dictionary对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddDictionary(Session us, MasterData m, MDG_Dictionary d, int i);

        /// <summary>
        /// 更新字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Dictionary对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateDictionary(Session us, MasterData m, MDG_Dictionary d, int i);

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id"></param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        [OperationContract]
        int DelDictionary(Session us, Guid id);

    }
}
