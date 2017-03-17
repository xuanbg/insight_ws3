using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using Insight.Utils.Common;
using Insight.Utils.Entity;
using Insight.WS.Server.Common.Entity;
using Insight.Utils.Server;
using Insight.WS.Server.Common.Utils;

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
        /// <returns>Result</returns>
        public Result AddImages(List<ImageData> objs, string tab, string col, Guid bid)
        {
            if (!Verify()) return _Result;

            return InsertData(objs, tab, col, bid) ? _Result : _Result.DataBaseError();
        }

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>Result</returns>
        public Result RemoveImage(string id)
        {
            if (!Verify()) return _Result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = DeleteImage(parse.Value);
            if (!obj.HasValue)return _Result.NotFound();

            return obj.Value ? _Result : _Result.DataBaseError();
        }

        /// <summary>
        /// 根据ID获取电子影像对象实体
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>Result</returns>
        public Result GetImageData(string id)
        {
            if (!Verify()) return _Result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = ReadImage(parse.Value);
            return obj == null ? _Result.NotFound() : _Result.Success(obj);

        }

        #endregion

        #region Categorys

        /// <summary>
        /// 新增分类数据
        /// </summary>
        /// <param name="category">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <returns>Result</returns>
        public Result AddCategory(BASE_Category category, int index)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            if (!InsertData(category, index)) result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>Result</returns>
        public Result RemoveCategory(string id)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            Guid cid;
            if (!Guid.TryParse(id, out cid))
            {
                result.InvalidGuid();
                return result;
            }

            var obj = DeleteCategory(cid);
            if (!obj.HasValue) result.NotFound();

            if (!obj.Value) result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 编辑分类数据
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>Result</returns>
        public Result UpdateCategory(string id, BASE_Category obj, int index, Guid? oldParentId, int oldIndex)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            if (!UpdateData(obj, index, oldParentId, oldIndex)) result.NotUpdate();

            return result;
        }

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>Result</returns>
        public Result GetCategory(string id)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            Guid cid;
            if (!Guid.TryParse(id, out cid))
            {
                result.InvalidGuid();
                return result;
            }

            var obj = ReadCategory(cid);
            if (obj == null) result.NotFound();
            else result.Success(obj);

            return result;
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="mid">模块ID</param>
        /// <param name="getall">是否忽略Visible属性</param>
        /// <param name="hasalias">是否显示别名</param>
        /// <returns>Result</returns>
        public Result GetCategorys(string mid, bool getall, bool hasalias)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            var obj = ReadCategorys(mid, getall, getall);
            if (obj.Rows.Count > 0) result.Success(result);
            else result.NoContent();

            return result;
        }

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="id">分类或节点ID</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <param name="table">表名称（默认MasterData）</param>
        /// <returns>Result</returns>
        public Result GetObjectCount(string id, string type, string table)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            var result = verify.Result;
            if (!result.successful) return result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = GetCounts(parse.Value, type, table);
            result.Success(obj);
            return result;
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
        /// 测试连通性
        /// </summary>
        /// <returns>Result</returns>
        public Result Test()
        {
            return _Result.Success();
        }

        /// <summary>
        /// 获取服务端文件列表
        /// </summary>
        /// <returns>Result</returns>
        public Result GetFiles()
        {
            return Verify() ? _Result.Success(Parameters.FileList) : _Result;
        }

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="id">更新文件ID</param>
        /// <returns>Result</returns>
        public Result GetFile(string id)
        {
            if (!Verify()) return _Result;

            var file = Parameters.FileList.SingleOrDefault(f => f.ID == id);
            if (file == null) return _Result.NotFound();

            var bytes = File.ReadAllBytes(file.FullPath);
            var str = Convert.ToBase64String(Util.Compress(bytes));
            return _Result.Success(str);
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="type">数据类型</param>
        /// <returns>Result</returns>
        public Result ImportExcel(string path, string type)
        {
            if (!Verify()) return _Result;

            var dir = System.Windows.Forms.Application.StartupPath;
            switch (type)
            {
                case "Logistics":
                    return new NpoiHelper<Logistics>().Import(dir + path);

                default:
                    return _Result;
            }
        }

        #endregion

        private Result _Result = new Result();
        private string _UserName;
        private Guid _UserId;
        private Guid? _DeptId;

        /// <summary>
        /// 身份验证方法
        /// </summary>
        /// <param name="action">操作权限代码，默认为空，即不进行鉴权</param>
        /// <returns>bool 身份是否通过验证</returns>
        private bool Verify(string action = null)
        {
            var verify = new Verify(Parameters.VerifyUrl, action);
            _UserName = verify.Token.userName;
            _UserId = verify.Token.userId;
            _DeptId = verify.Token.deptId;
            _Result = verify.Result;

            return _Result.successful;
        }
    }
}

