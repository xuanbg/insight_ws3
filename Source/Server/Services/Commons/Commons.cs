using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.OnlineManage;

namespace Insight.WS.Service
{

    public partial class Commons : ICommons
    {

        #region 报表接口

        /// <summary>
        /// 获取全部可用的报表模板
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="type">模板类型</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable 可用报表模板列表</returns>
        public DataTable GetReportTemplet(Session us, string type, bool withOutTree)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.ID, max(P.Permission) as Permission from ReportTemplet D ";
            sql += "join Get_PermData('AD0BD296-46F5-46B3-85B9-00B6941343E7', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId ";
            sql += $"where D.Alias = '{type}' {(withOutTree ? "and D.IsData = 1 " : "")}group by D.ID) ";
            sql += "select D.*, case when D.IsData = 0 then 0 else L.Permission end as Permission from ReportTemplet D join List L on L.ID = D.ID order by D.[Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取打印或预览内容
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="oid">数据对象ID</param>
        /// <param name="tid">模板ID</param>
        /// <param name="obj">电子影像对象实体</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public ImageData BuildImageData(Session us, Guid oid, Guid tid, ImageData obj)
        {
            if (!Verification(us)) return null;

            var img = ReportDAL.BuildImage(oid, tid, us.DeptName, us.UserName, us.DeptId, us.UserId, obj);
            if (obj != null)
            {
                var id = (Guid)ReportDAL.SaveImage(img);
                img.ID = id;

                if (obj.ImageType == 1 || obj.ImageType == 3)
                {
                    const string sql = "insert ABS_Clearing_Attachs (ClearingId, ImageId) select @ClearingId, @ImageId";
                    var parm = new[]
                    {
                        new SqlParameter("ClearingId", SqlDbType.UniqueIdentifier) {Value = oid},
                        new SqlParameter("ImageId", SqlDbType.UniqueIdentifier) {Value = id}
                    };
                    SqlQuery(MakeCommand(sql, parm));
                }
            }
            return img;
        }

        #endregion

        #region 电子影像公共方法

        /// <summary>
        /// 根据ID获取电子影像对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">电子影像ID</param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public ImageData GetImageData(Session us, Guid id)
        {
            if (!Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.ImageData.SingleOrDefault(i => i.ID == id);
            }
        }

        /// <summary>
        /// 单独上传附件到数据库
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务记录ID</param>
        /// <param name="objs">ImageData对象集合</param>
        /// <param name="tab">业务附件表名称</param>
        /// <param name="col">>业务附件表主记录字段</param>
        /// <returns>bool 是否成功</returns>
        public bool SaveImages(Session us, Guid bid, List<ImageData> objs, string tab, string col)
        {
            if (!Verification(us)) return false;

            var cmds = CommonDAL.AddImageDatas(objs, tab, col, bid);
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID删除电子影像数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">电子影像ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelImageData(Session us, Guid id)
        {
            if (!Verification(us)) return false;

            var sql = $"delete ImageData where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

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
        public bool NameIsExist(Session us, string tab, string col, string str)
        {
            if (!Verification(us)) return false;

            var sql = $"select count(*) from {tab} where {col} = '{str}'";
            return (int)SqlScalar(MakeCommand(sql)) > 0;
        }

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
        public bool NameIsExisting(Session us, Guid? pid, string tab, string col, string str, bool isParent)
        {
            if (!Verification(us)) return false;

            var p = isParent ? "ParentId" : "CategoryId";
            var pn = pid.HasValue ? $"= '{pid}'" : "is null";
            var sql = $"select count(*) from {tab} where {col} = '{str}' and {p} {pn}";
            return (int)SqlScalar(MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 获取节点或分类下对象数量
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">分类或节点ID</param>
        /// <param name="tab">表名称（默认MasterData）</param>
        /// <param name="type">类型（默认分类，可选节点）</param>
        /// <returns>int 对象数量</returns>
        public int GetObjectCount(Session us, Guid? id, string type, string tab)
        {
            if (!Verification(us)) return -1;

            var sql = $"select count(ID) from {tab} where {type} {(id.HasValue ? "= @ID" : "is null")}";
            var parm = new[] {new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id}};
            return (int)SqlScalar(MakeCommand(sql, parm));
        }

        #endregion

        #region 其它接口

        public UpdateFile a()
        {
            return new UpdateFile();
        }

        public Advance b()
        {
            return new Advance();
        }

        /// <summary>
        /// 删除在线用户会话
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="sid">要删除Session的ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DelOnlineUser(Session us, int? sid)
        {
            if (!Verification(us)) return false;

            Sessions[sid ?? us.ID].SessionId = Guid.Empty;
            return true;
        }

        /// <summary>
        /// 获取组织机构列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 组织机构列表</returns>
        public DataTable GetOrgTree(Session us)
        {
            if (!Verification(us)) return null;

            const string sql = "select ID, ParentId, NodeType, [Index], 名称 as Name from Organization";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取编码方案列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 编码方案列表</returns>
        public DataTable GetCodeSchemes(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.ID, max(P.Permission) as Permission from SYS_Code_Scheme D ";
            sql += "join Get_PermData('1E976784-E58C-47C7-AEC5-D92B7B32F122', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.ID) ";
            sql += "select D.ID, D.Name from SYS_Code_Scheme D join List L on L.ID = D.ID where D.Validity = 1";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据类型获取全部主数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="type">主数据类型码</param>
        /// <returns>DataTable 全部主数据</returns>
        public DataTable GetMasterDatas(Session us, int type)
        {
            if (!Verification(us)) return null;

            var sql = "";
            if ((type & 8) == 8) sql += "union select M.ID, M.Name, M.Alias from MasterData M join MDG_Customer C on C.MID = M.ID ";
            if ((type & 4) == 4) sql += "union select M.ID, M.Name, M.Alias from MasterData M join MDG_Supplier S on S.MID = M.ID ";
            if ((type & 2) == 2) sql += "union select M.ID, M.Name, M.Alias from MasterData M join MDG_Employee E on E.MID = M.ID ";
            if ((type & 1) == 1) sql += "union select M.ID, M.Name, M.Alias from MasterData M join MDG_Contact O on O.MID = M.ID ";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取全部可用收支项目
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 收支项目</returns>
        public DataTable GetExpense(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.MID, max(P.Permission) as Permission from MDG_Expense D ";
            sql += "join Get_PermData('993D148D-C062-4850-8D3E-FD4F12814F99', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.MID) ";
            sql += "select ID, ParentId, cast(0 as bit) as IsData, cast(0 as bit) as BuiltIn, [Index], Name, Alias, null as Unit, null as Price from BASE_Category where ModuleId = '993D148D-C062-4850-8D3E-FD4F12814F99' union all ";
            sql += "select M.ID, M.CategoryId, cast(1 as bit) as IsData, E.BuiltIn, E.[Index], M.Name, M.Alias, E.Unit, E.Price from MasterData M join MDG_Expense E on E.MID = M.ID join List L on L.MID = M.ID where E.Enable = 1";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取所有物资列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 物资列表</returns>
        public DataTable GetMaterials(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.MID, max(P.Permission) as Permission from MDG_Material D ";
            sql += "join Get_PermData('993D148D-C062-4850-8D3E-FD4F12814F99', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.MID) ";
            sql += "select M.ID, E.[Index], M.Name, E.BarCode, E.Unit from MasterData M join MDG_Material E on E.MID = M.ID join List L on L.MID = M.ID where E.Enable = 1";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取授权的仓库列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 仓库列表</returns>
        public DataTable GetStore(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Storage_Location C ";
            sql += "join Get_PermData('D83D9B83-AA49-4A1D-91E8-727B248AA6F1', @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, C.Name from ABS_Storage_Location C join List L on L.ID = C.ID where C.NodeType = 2";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        #endregion

    }
}

