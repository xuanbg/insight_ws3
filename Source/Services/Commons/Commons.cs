using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;

namespace Insight.WS.Service
{

    public partial class Commons : ICommons
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
        public JsonResult AddImages(List<ImageData> objs, string tab, string col, Guid bid)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            return InsertData(objs, tab, col, bid) ? verify.Success() : verify.DataBaseError();
        }

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveImage(string id)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            Guid iid;
            if (!Guid.TryParse(id, out iid)) return verify.InvalidGuid();

            var result = DeleteImage(iid);
            if (result == null) return verify.NotFound();

            return result.Value ? verify : verify.DataBaseError();
        }

        /// <summary>
        /// 根据ID获取电子影像对象实体
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetImageData(string id)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            Guid iid;
            if (!Guid.TryParse(id, out iid)) return verify.InvalidGuid();

            var result = ReadImage(iid);
            return result == null ? verify.NotFound() : verify.Success(result);
        }

        #endregion

        #region Categorys

        /// <summary>
        /// 新增分类数据
        /// </summary>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddCategory(BASE_Category obj, int index)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            var result = InsertData(obj, index);
            return result ? verify : verify.DataBaseError();
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveCategory(string id)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            Guid cid;
            if (!Guid.TryParse(id, out cid)) return verify.InvalidGuid();

            var result = DeleteCategory(cid);
            if (result == null) return verify.NotFound();

            return result.Value ? verify : verify.DataBaseError();
        }

        /// <summary>
        /// 编辑分类数据
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>JsonResult</returns>
        public JsonResult UpdateCategory(string id, BASE_Category obj, int index, Guid? oldParentId, int oldIndex)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            var result = UpdateData(obj, index, oldParentId, oldIndex);
            return result ? verify : verify.NotUpdate();
        }

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetCategory(string id)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            Guid cid;
            if (!Guid.TryParse(id, out cid)) return verify.InvalidGuid();

            var result = ReadCategory(cid);
            return result == null ? verify.NotFound() : verify.Success(result);
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="getall">是否忽略Visible属性</param>
        /// <param name="hasalias">是否显示别名</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetCategorys(string mid, bool getall, bool hasalias)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            var result = ReadCategorys(mid, getall, getall);
            return result.Rows.Count > 0 ? verify.Success(result) : verify.NoContent();
        }

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="id">分类或节点ID</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <param name="table">表名称（默认MasterData）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetObjectCount(string id, string type, string table)
        {
            var verify = Verify();
            if (!verify.Successful) return verify;

            var parse = new GuidParse(id);
            if (!parse.Successful) return verify.InvalidGuid();

            var result = GetCounts(parse.Guid, type, table);
            return verify.Success(result);
        }

        #endregion

        #region 其它接口

        /// <summary>
        /// 为跨域请求设置响应头信息
        /// </summary>
        public void ResponseOptions()
        {
            var context = WebOperationContext.Current;
            if (context == null) return;

            var response = context.OutgoingResponse;
            response.Headers.Add("Access-Control-Allow-Credentials", "true");
            response.Headers.Add("Access-Control-Allow-Headers", "Accept, Content-Type, Authorization");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        /// <summary>
        /// 获取服务配置
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetServers()
        {
            var verify = Verify(Util.Secret);
            if (!verify.Successful) return verify;

            var servers = new Dictionary<string, string>
            {
                {"BaseServer", Util.BaseServer},
                {"LogServer", Util.LogServer}
            };
            return verify.Success(servers);
        }

        /// <summary>
        /// 获取服务端文件列表
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetFiles()
        {
            var verify = Verify(Util.Secret);
            return verify.Successful ? verify.Success(Util.FileList) : verify;
        }

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="id">更新文件ID</param>
        /// <returns>JsonResult</returns>
        public byte[] GetFile(string id)
        {
            var verify = Verify(id + Util.Secret);
            if (!verify.Successful) return null;

            var file = Util.FileList.SingleOrDefault(f => f.ID == id);
            if (file == null) return null;

            var webRes = WebRequest.Create(file.FullPath).GetResponse();
            using (var stream = webRes.GetResponseStream())
            {
                var buff = new byte[webRes.ContentLength];
                stream.Read(buff, 0, buff.Length);
                return buff;
            }
        }

        #endregion

    }
}

