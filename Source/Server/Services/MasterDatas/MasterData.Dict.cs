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
    public partial class MasterDatas
    {

        /// <summary>
        /// 根据权限获取字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 所有字典数据</returns>
        public DataTable GetDictionarys(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.MID, max(P.Permission) as Permission from MDG_Dictionary D ";
            sql += "join Get_PermData('5C801552-1905-452B-AE7F-E57227BE70B8', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.MID) ";
            sql += "select M.ID, M.CategoryId, D.[Index], D.BuiltIn as 预置, M.Name as 名称, M.Alias as 简称, M.Code as 编码, D.[Description] as 备注, case D.Enable when 0 then '停用' else '正常' end as 状态, L.Permission from MDG_Dictionary D ";
            sql += "join List L on L.MID = D.MID join MasterData M on M.ID = D.MID";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取MDG_Dictionary对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">字典数据ID</param>
        /// <returns>MDG_Dictionary对象实体</returns>
        public MDG_Dictionary GetDictionary(Session us, Guid id)
        {
            if (!Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Dictionary.SingleOrDefault(d => d.MID == id);
            }
        }

        /// <summary>
        /// 添加字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Dictionary对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool AddDictionary(Session us, MasterData m, MDG_Dictionary d, int i)
        {
            if (!Verification(us, "7B06DCC7-E47C-409F-9542-850013815112")) return false;

            var cmds = new List<SqlCommand>();

            if (i != d.Index)
            {
                cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Dictionary", i, d.Index, m.CategoryId)));
            }
            cmds.Add(DataAccess.AddMasterData(m));

            const string sql = "insert MDG_Dictionary (MID, [Index], [Type], [Description], CreatorDeptId, CreatorUserId) select @MID, @Index, dbo.Get_DictType(@CategoryId), @Description, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@Index", SqlDbType.Int) {Value = d.Index},
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = m.CategoryId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新字典数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Dictionary对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateDictionary(Session us, MasterData m, MDG_Dictionary d, int i)
        {
            if (!Verification(us, "3AF9B968-F812-4FD7-BDF1-5FF47D09D77B")) return false;

            var cmds = new List<SqlCommand>
            {
                MakeCommand(DataAccess.ChangeIndex("MDG_Dictionary", i, d.Index, m.CategoryId)),
                DataAccess.UpdateMasterData(m)
            };

            const string sql = "update MDG_Dictionary set [Index] = @Index, Description = @Description where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@Index", SqlDbType.Int) {Value = d.Index},
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = m.ID}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
        }

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">数据ID</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        public int DelDictionary(Session us, Guid id)
        {
            if (!Verification(us, "33744044-4DBF-4DB8-8DD0-0990E6F6B36B")) return 0;

            var cmds = new List<SqlCommand>();

            var obj = DataAccess.GetData(id);
            var dict = GetDictionary(us, id);
            var sql = $"Delete From MasterData where ID = '{id}'";

            cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Dictionary", dict.Index, 99999, obj.CategoryId, false)));
            cmds.Add(MakeCommand(sql));
            if (SqlExecute(cmds))
            {
                return 1;
            }
            return SqlExecute(new[] {MakeCommand($"update MDG_Dictionary set [Enable] = 0 where MID = '{id}'")}) ? 2 : 0;
        }

    }
}
