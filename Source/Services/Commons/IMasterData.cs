using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial interface ICommons
    {

        /// <summary>
        /// 更新数据状态为可用
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool EnableMasterData(Session us, Guid id, string tab);

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        [OperationContract]
        int DelMasterData(Session us, Guid id, string tab);
        
        /// <summary>
        /// 根据ID获取主数据对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">主数据ID</param>
        /// <returns>MasterData 主数据对象实体</returns>
        [OperationContract]
        MasterData GetMasterData(Session us, Guid id);

        /// <summary>
        /// 插入主数据用户关系
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">关系ID</param>
        /// <param name="obj">MDR_MU对象实体</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool Transfer(Session us, Guid? id, MDR_MU obj);

        /// <summary>
        /// 取消共享
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="ids">关系ID集合</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UnShare(Session us, List<Guid> ids);

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="type">字典类型，参看主数据初始化脚本说明</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable</returns>
        [OperationContract]
        DataTable GetDictionary(Session us, string type, bool withOutTree);

        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 联系人列表</returns>
        [OperationContract]
        DataTable GetContacts(Session us);

        /// <summary>
        /// 获取所有联系方式列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 联系方式列表</returns>
        [OperationContract]
        DataTable GetContactInfos(Session us);

        /// <summary>
        /// 根据ID获取联系人对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">联系人ID</param>
        /// <returns>MDG_Customer 联系人对象实体</returns>
        [OperationContract]
        MDG_Contact GetContact(Session us, Guid id);

        /// <summary>
        /// 根据ID获取联系人联系方式
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">员工ID</param>
        /// <returns>DataTable 联系方式列表</returns>
        [OperationContract]
        DataTable GetContactInfo(Session us, Guid id);

        /// <summary>
        /// 获取所有在职员工列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 在职员工列表</returns>
        [OperationContract]
        DataTable GetAllEmployees(Session us);

        /// <summary>
        /// 根据客户/供应商ID获取共享用户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">客户/供应商ID</param>
        /// <returns>DataTable 共享用户列表</returns>
        [OperationContract]
        DataTable GetSharing(Session us, Guid id);

        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool AddContact(Session us, MasterData m, MDG_Contact d, DataTable cdt);

        /// <summary>
        /// 更新联系人和联系方式
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdl">联系方式删除列表</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool UpdateContact(Session us, MasterData m, MDG_Contact d, List<object> cdl, DataTable cdt);

    }
}
