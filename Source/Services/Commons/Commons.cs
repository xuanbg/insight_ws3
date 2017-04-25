using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Insight.Utils.Common;
using Insight.Utils.Entity;
using Insight.Utils.Npoi;
using Insight.WS.Server.Common.Entity;
using Insight.Utils.Server;
using Insight.WS.Server.Common.Utils;

namespace Insight.WS.Service
{

    public partial class Commons : ServiceBase, ICommons
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Commons()
        {
            CallManage = Params.CallManage;
            VerifyUrl = Params.VerifyUrl;
        }

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
            if (!Verify()) return Result;

            return InsertData(objs, tab, col, bid) ? Result : Result.DataBaseError();
        }

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>Result</returns>
        public Result RemoveImage(string id)
        {
            if (!Verify()) return Result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = DeleteImage(parse.Value);
            if (!obj.HasValue)return Result.NotFound();

            return obj.Value ? Result : Result.DataBaseError();
        }

        /// <summary>
        /// 根据ID获取电子影像对象实体
        /// </summary>
        /// <param name="id">电子影像ID</param>
        /// <returns>Result</returns>
        public Result GetImageData(string id)
        {
            if (!Verify()) return Result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = ReadImage(parse.Value);
            return obj == null ? Result.NotFound() : Result.Success(obj);

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
            if (!Verify()) return Result;

            if (!InsertData(category, index)) Result.DataBaseError();

            return Result;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>Result</returns>
        public Result RemoveCategory(string id)
        {
            if (!Verify()) return Result;

            Guid cid;
            if (!Guid.TryParse(id, out cid))
            {
                Result.InvalidGuid();
                return Result;
            }

            var obj = DeleteCategory(cid);
            if (!obj.HasValue) Result.NotFound();

            if (!obj.Value) Result.DataBaseError();

            return Result;
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
            if (!Verify()) return Result;

            if (!UpdateData(obj, index, oldParentId, oldIndex)) Result.NotUpdate();

            return Result;
        }

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>Result</returns>
        public Result GetCategory(string id)
        {
            if (!Verify()) return Result;

            Guid cid;
            if (!Guid.TryParse(id, out cid))
            {
                Result.InvalidGuid();
                return Result;
            }

            var obj = ReadCategory(cid);
            if (obj == null) Result.NotFound();
            else Result.Success(obj);

            return Result;
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
            if (!Verify()) return Result;

            var obj = ReadCategorys(mid, getall, getall);
            if (obj.Rows.Count > 0) Result.Success(Result);
            else Result.NoContent();

            return Result;
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
            if (!Verify()) return Result;

            var parse = new GuidParse(id);
            if (!parse.Result.successful) return parse.Result;

            var obj = GetCounts(parse.Value, type, table);
            Result.Success(obj);
            return Result;
        }

        #endregion

        #region 其它接口

        /// <summary>
        /// 为跨域请求设置响应头信息
        /// </summary>
        public void ResponseOptions()
        {
        }

        /// <summary>
        /// 测试连通性
        /// </summary>
        /// <returns>Result</returns>
        public Result Test()
        {
            return Result.Success();
        }

        /// <summary>
        /// 获取服务端文件列表
        /// </summary>
        /// <returns>Result</returns>
        public Result GetFiles()
        {
            return Verify() ? Result.Success(Params.FileList) : Result;
        }

        /// <summary>
        /// 根据更新信息获取更新文件
        /// </summary>
        /// <param name="id">更新文件ID</param>
        /// <returns>Result</returns>
        public Result GetFile(string id)
        {
            if (!Verify()) return Result;

            var file = Params.FileList.SingleOrDefault(f => f.ID == id);
            if (file == null) return Result.NotFound();

            var bytes = File.ReadAllBytes(file.FullPath);
            var str = Convert.ToBase64String(Util.Compress(bytes));
            return Result.Success(str);
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="type">数据类型</param>
        /// <returns>Result</returns>
        public Result ImportExcel(string path, string type)
        {
            if (!Verify()) return Result;

            var dir = System.Windows.Forms.Application.StartupPath;
            switch (type)
            {
                case "Logistics":
                    return new NpoiHelper<Logistics>().Import(dir + path);

                default:
                    return Result;
            }
        }

        #endregion

    }
}

