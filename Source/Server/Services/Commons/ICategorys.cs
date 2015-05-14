using System;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    public partial interface ICommons
    {

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="getAll">是否忽略Visible属性</param>
        /// <param name="hasAlias">是否显示别名</param>
        /// <returns>DataTable 分类列表</returns>
        [OperationContract]
        DataTable GetCategorys(Session us, Guid mid, bool getAll, bool hasAlias);

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">分类ID</param>
        /// <returns>BASE_Category对象实体</returns>
        [OperationContract]
        BASE_Category GetCategory(Session us, Guid id);

        /// <summary>
        /// 新增分类数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <returns>object 插入成功返回新插入记录的ID；插入失败返回false</returns>
        [OperationContract]
        bool AddCategory(Session us, BASE_Category obj, int index);

        /// <summary>
        /// 编辑分类数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>object 更新成功返回true；更新失败返回false</returns>
        [OperationContract]
        bool UpdateCategory(Session us, BASE_Category obj, int index, Guid? oldParentId, int oldIndex);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">分类ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DelCategory(Session us, Guid id);

        /// <summary>
        /// 全部分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        [OperationContract]
        bool GlobalNameIsExisting(Session us, Guid mid, string col, string str);

        /// <summary>
        /// 父分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <param name="pid">父节点ID</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        [OperationContract]
        bool LocalNameIsExisting(Session us, Guid mid, string col, string str, Guid? pid);

    }
}
