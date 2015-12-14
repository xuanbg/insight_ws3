using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    partial class Base
    {

        #region 获取

        /// <summary>
        /// 获取全部编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 编码方案列表</returns>
        public DataTable GetSchemes(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(select S.ID, max(P.Permission) as Permission from SYS_Code_Scheme S ";
            sql += "join Get_PermData('1E976784-E58C-47C7-AEC5-D92B7B32F122', @UserId, @DeptId) P on P.OrgId = isnull(S.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = S.CreatorUserId group by S.ID) ";
            sql += "select S.ID, Case when Validity = 1 then '正常' else '停用' end 状态, S.Name as 名称, S.CodeFormat as 编码格式, S.SerialFormat as 分组规则, S.Description as 描述, S.CreateTime as 创建日期, L.Permission from SYS_Code_Scheme S join List L on L.ID = S.ID order by S.SN";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取全部流水码使用记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 使用记录</returns>
        public DataTable GetSerialRecord(Session us)
        {
            if (!Verification(us)) return null;

            const string sql = "select * from SerialRecord";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取全部流水码分配记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 分配记录</returns>
        public DataTable GetAllotRecord(Session us)
        {
            if (!Verification(us)) return null;

            const string sql = "select * from AllotRecord order by SN";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取编码方案对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>SYS_Code_Scheme 编码方案对象实体</returns>
        public SYS_Code_Scheme GetScheme(Session us, Guid id)
        {
            if (!Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Code_Scheme.SingleOrDefault(s => s.ID == id);
            }
        }

        /// <summary>
        /// 根据传入参数获取编码方案预览
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="code">编码格式</param>
        /// <param name="mark">分组规则</param>
        /// <returns>string 业务编码</returns>
        public string GetCodePreview(Session us, Guid sid, string code, string mark)
        {
            if (!Verification(us)) return null;

            const string sql = "select dbo.Get_CodePreview(@SchemeId, @DeptId, @UserId, @CodeFormat, @SerialFormat)";
            var parm = new[]
            {
                new SqlParameter("@SchemeId", SqlDbType.UniqueIdentifier) {Value = sid},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@CodeFormat", code),
                new SqlParameter("@SerialFormat", mark)
            };
            return SqlScalar(MakeCommand(sql, parm)).ToString();
        }

        #endregion

        #region 新增

        /// <summary>
        /// 新增编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">编码方案对象实体</param>
        /// <returns>bool 数据是否插入成功</returns>
        public bool AddScheme(Session us, SYS_Code_Scheme obj)
        {
            if (!Verification(us, "073A086E-03A2-4612-89A3-89B6757C61EB")) return false;

            const string sql = "insert SYS_Code_Scheme (Name, CodeFormat, SerialFormat, Description, CreatorDeptId, CreatorUserId) select @Name, @CodeFormat, @SerialFormat, @Description, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@CodeFormat", obj.CodeFormat),
                new SqlParameter("@SerialFormat", obj.SerialFormat),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新编码方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj"></param>
        /// <returns>bool 是否更新成功</returns>
        public bool UpdateScheme(Session us, SYS_Code_Scheme obj)
        {
            if (!Verification(us, "2FD5E15B-5463-49F4-9706-517AD22654DE")) return false;

            const string sql = "update SYS_Code_Scheme set Name = @Name, CodeFormat = @CodeFormat, SerialFormat = @SerialFormat, Description = @Description where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@CodeFormat", obj.CodeFormat),
                new SqlParameter("@SerialFormat", obj.SerialFormat),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 根据ID更新编码方案状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>bool 是否更新成功</returns>
        public bool EnableScheme(Session us, Guid id)
        {
            if (!Verification(us, "8EEDDF19-79B0-4454-B2D7-722DEAF7ECDF")) return false;

            var sql = $"update SYS_Code_Scheme set Validity = 1 where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除编码方案或设为不可用
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">编码方案ID</param>
        /// <returns>int 0：失败；1、删除成功；2：设置为不可用</returns>
        public int DeleteScheme(Session us, Guid id)
        {
            if (!Verification(us, "083CBEFA-EEC1-42C9-9C9F-4D5754919789")) return 0;

            var sql = $"select count(*) from SYS_ModuleParam where Value = '{id}'";
            var count = (int)SqlScalar(MakeCommand(sql));
            if (count == 0)
            {
                sql = $"Delete from SYS_Code_Scheme where ID = '{id}'";
                return SqlNonQuery(MakeCommand(sql)) > 0 ? 1 : 0;
            }
            sql = $"update SYS_Code_Scheme set Validity = 0 where ID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0 ? 2 : 0;
        }

        #endregion

    }
}
