using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    [ServiceContract]
    public interface ICommons
    {

        #region ImageData

        /// <summary>
        /// 单独上传附件到数据库
        /// </summary>
        /// <param name="objs">ImageData对象集合</param>
        /// <param name="tab">业务附件表名称</param>
        /// <param name="col">>业务附件表主记录字段</param>
        /// <param name="bid">业务记录ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "images", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddImages(List<ImageData> objs, string tab, string col, Guid bid);

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "images/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveImage(string id);

        /// <summary>
        /// 根据ID获取单据快照
        /// </summary>
        /// <param name="id">单据快照ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "images/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetImageData(string id);

        #endregion

        #region Categorys

        /// <summary>
        /// 新增分类数据
        /// </summary>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "categorys", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult AddCategory(BASE_Category obj, int index);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "DELETE", UriTemplate = "categorys/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult RemoveCategory(string id);

        /// <summary>
        /// 编辑分类数据
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "categorys/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        JsonResult UpdateCategory(string id, BASE_Category obj, int index, Guid? oldParentId, int oldIndex);

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "categorys/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetCategory(string id);

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="getall">是否忽略Visible属性</param>
        /// <param name="hasalias">是否显示别名</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "categorys?mid={mid}&getall={getall}&hasalias={hasalias}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetCategorys(string mid, bool getall, bool hasalias);

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="id">分类或节点ID</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <param name="table">表名称（默认MasterData）</param>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "categorys/{id}/counts?type={type}&table={table}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetObjectCount(string id, string type, string table);

        #endregion

        #region 其它接口

        /// <summary>
        /// 为跨域请求设置响应头信息
        /// </summary>
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void ResponseOptions();

        /// <summary>
        /// 获取服务配置
        /// </summary>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "servers", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetServers();

        /// <summary>
        /// 获取服务端文件列表
        /// </summary>
        /// <returns>JsonResult</returns>
        [WebGet(UriTemplate = "files", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetFiles();

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="id">更新文件ID</param>
        /// <returns>JsonResult</returns>
        [OperationContract]
        [WebGet(UriTemplate = "files/{id}", ResponseFormat = WebMessageFormat.Json)]
        JsonResult GetFile(string id);

        #endregion

    }
}
