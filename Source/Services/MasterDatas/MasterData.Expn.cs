using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class MasterDatas
    {
        /// <summary>
        /// 获取全部费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部费用项目列表</returns>
        public DataTable GetExpenses(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "with List as(Select D.MID, max(P.Permission) as Permission from MDG_Expense D ";
            sql += "join Get_PermData('993D148D-C062-4850-8D3E-FD4F12814F99', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.MID) ";
            sql += "select M.ID, M.CategoryId, D.[Index], D.BuiltIn as 预置, M.Name as 名称, M.Alias as 简称, M.Code as 编码, U.Name as 单位, D.Price as 单价, D.[Description] as 备注, case D.Enable when 0 then '停用' else '正常' end as 状态, L.Permission from MDG_Expense D ";
            sql += "join List L on L.MID = D.MID join MasterData M on M.ID = D.MID left join MasterData U on U.ID = D.Unit order by D.[Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取收支项目对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">收支项目ID</param>
        /// <returns>MDG_Expense 收支项目对象实体</returns>
        public MDG_Expense GetExpense(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Expense.SingleOrDefault(d => d.MID == id);
            }
        }

        /// <summary>
        /// 添加费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Expense对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool AddExpense(Session us, MasterData m, MDG_Expense d, int i)
        {
            if (!Verification(us, "FB98FF3F-73B4-4B2D-B669-9B123FFB5556")) return false;

            var cmds = new List<SqlCommand>();

            if (i != d.Index)
            {
                cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Expense", i, d.Index, m.CategoryId)));
            }
            cmds.Add(DataAccess.AddMasterData(m));

            const string sql = "insert MDG_Expense (MID, [Index], Unit, Price, [Description], CreatorDeptId, CreatorUserId) select @MID, @Index, @Unit, @Price, @Description, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@Index", d.Index),
                new SqlParameter("@Unit", SqlDbType.UniqueIdentifier) {Value = d.Unit},
                new SqlParameter("@Price", d.Price),
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新费用项目
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Expense对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateExpense(Session us, MasterData m, MDG_Expense d, int i)
        {
            if (!Verification(us, "C31B8B4E-229F-473E-82A5-FF6A145C75FF")) return false;

            var cmds = new List<SqlCommand>
            {
                MakeCommand(DataAccess.ChangeIndex("MDG_Expense", i, d.Index, m.CategoryId)),
                DataAccess.UpdateMasterData(m)
            };

            const string sql = "update MDG_Expense set [Index] = @Index, Unit = @Unit, Price = @Price, Description = @Description where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@Index", d.Index),
                new SqlParameter("@Unit", SqlDbType.UniqueIdentifier) {Value = d.Unit},
                new SqlParameter("@Price", d.Price),
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
        public int DelExpense(Session us, Guid id)
        {
            if (!Verification(us, "2BB1BCB1-CE9C-4AD5-9FF9-80757173289D")) return 0;

            var cmds = new List<SqlCommand>();

            var obj = DataAccess.GetData(id);
            var data = GetExpense(us, id);
            var sql = $"Delete From MasterData where ID = '{id}'";

            cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Expense", data.Index, 99999, obj.CategoryId, false)));
            cmds.Add(MakeCommand(sql));
            if (SqlExecute(cmds))
            {
                return 1;
            }
            return SqlExecute(new[] {MakeCommand($"update MDG_Expense set [Enable] = 0 where MID = '{id}'")}) ? 2 : 0;
        }

    }
}
