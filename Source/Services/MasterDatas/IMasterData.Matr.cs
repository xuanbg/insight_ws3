using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service
{
    public partial interface IMasterDatas
    {

        /// <summary>
        /// 获取全部物资材料列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部物资材料列表</returns>
        [OperationContract]
        DataTable GetMaterials(Session us);

        /// <summary>
        /// 根据ID获取物资材料对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">物资材料ID</param>
        /// <returns>MDG_Material 物资材料对象实体</returns>
        [OperationContract]
        MDG_Material GetMaterial(Session us, Guid id);

        /// <summary>
        /// 添加物资材料
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Material对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddMaterial(Session us, MasterData m, MDG_Material d, int i);

        /// <summary>
        /// 更新物资材料
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Material对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateMaterial(Session us, MasterData m, MDG_Material d, int i);

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">物资材料ID</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        [OperationContract]
        int DelMaterial(Session us, Guid id);

    }
}
