using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service
{
    [ServiceContract]
    public partial interface ICommons
    {

        #region 报表接口

        /// <summary>
        /// 获取全部可用的报表模板
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="type">模板类型</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable 可用报表模板列表</returns>
        [OperationContract]
        DataTable GetReportTemplet(Session us, string type, bool withOutTree);

        /// <summary>
        /// 获取打印或预览内容
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="oid">数据对象ID</param>
        /// <param name="tid">模板ID</param>
        /// <param name="obj">电子影像对象实体</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        [OperationContract]
        ImageData BuildImageData(Session us, Guid oid, Guid tid, ImageData obj);

        #endregion

        #region 电子影像公共方法

        /// <summary>
        /// 根据ID获取单据快照
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">单据快照ID</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        [OperationContract]
        ImageData GetImageData(Session us, Guid id);

        /// <summary>
        /// 单独上传附件到数据库
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务记录ID</param>
        /// <param name="objs">ImageData对象集合</param>
        /// <param name="tab">业务附件表名称</param>
        /// <param name="col">>业务附件表主记录字段</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool SaveImages(Session us, Guid bid, List<ImageData> objs, string tab, string col);

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">电子影像ID</param>
        /// <returns>bool 是否成功</returns>
        [OperationContract]
        bool DelImageData(Session us, Guid id);

        #endregion

        #region 验证接口

        /// <summary>
        /// 验证内容是否已存在
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="tab">数据表名称</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">验证内容</param>
        /// <returns>bool 内容是否存在</returns>
        [OperationContract]
        bool NameIsExist(Session us, string tab, string col, string str);

        /// <summary>
        /// 验证指定分类下内容是否已存在
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="pid">分类ID</param>
        /// <param name="tab">数据表名称</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">验证内容</param>
        /// <param name="isParent"></param>
        /// <returns>bool 内容是否存在</returns>
        [OperationContract]
        bool NameIsExisting(Session us, Guid? pid, string tab, string col, string str, bool isParent);

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">分类或节点ID</param>
        /// <param name="tab">表名称（默认MasterData）</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <returns>int 对象数量</returns>
        [OperationContract]
        int GetObjectCount(Session us, Guid? id, string type, string tab);

        #endregion

        #region 其它接口

        [OperationContract]
        UpdateFile a();

        [OperationContract]
        Advance b();

        /// <summary>
        /// 删除在线用户会话
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="sid">要删除Session的ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DelOnlineUser(Session us, int? sid);

        /// <summary>
        /// 获取组织机构列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 组织机构列表</returns>
        [OperationContract]
        DataTable GetOrgTree(Session us);

        /// <summary>
        /// 获取编码方案列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 编码方案列表</returns>
        [OperationContract]
        DataTable GetCodeSchemes(Session us);

        /// <summary>
        /// 根据类型获取全部主数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="type">主数据类型码</param>
        /// <returns>DataTable 全部主数据</returns>
        [OperationContract]
        DataTable GetMasterDatas(Session us, int type);

        /// <summary>
        /// 获取全部可用收支项目
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 收支项目</returns>
        [OperationContract]
        DataTable GetExpense(Session us);

        /// <summary>
        /// 获取所有物资列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 物资列表</returns>
        [OperationContract]
        DataTable GetMaterials(Session us);

        /// <summary>
        /// 获取授权的仓库列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 仓库列表</returns>
        [OperationContract]
        DataTable GetStore(Session us);

        #endregion

    }
}
