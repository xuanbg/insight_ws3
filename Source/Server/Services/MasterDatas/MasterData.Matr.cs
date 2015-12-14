using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{
    public partial class MasterDatas
    {

        /// <summary>
        /// 获取全部物资材料列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 全部物资材料列表</returns>
        public DataTable GetMaterials(Session us)
        {
            if (!Verification(us)) return null;

            var sql = "with List as(Select D.MID, max(P.Permission) as Permission from MDG_Material D ";
            sql += "join Get_PermData('AE251B20-4B82-4754-B404-77CE35F4F57E', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.MID) ";
            sql += "select M.ID, M.CategoryId, D.[Index], M.Name as 名称, M.Alias as 简称, M.Code as 编码, D.Model as 型号, D.Size + isnull(S.Name, '') as 规格, U.Name as 单位, D.[Description] as 备注, case D.Enable when 0 then '停用' else '正常' end as 状态, L.Permission from MDG_Material D ";
            sql += "join List L on L.MID = D.MID join MasterData M on M.ID = D.MID left join MasterData S on S.ID = D.SizeType left join MasterData U on U.ID = D.Unit order by D.[Index]";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取物资材料对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">物资材料ID</param>
        /// <returns>MDG_Material 物资材料对象实体</returns>
        public MDG_Material GetMaterial(Session us, Guid id)
        {
            if (!Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Material.SingleOrDefault(d => d.MID == id);
            }
        }

        /// <summary>
        /// 添加物资材料
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Material对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool AddMaterial(Session us, MasterData m, MDG_Material d, int i)
        {
            if (!Verification(us, "3B6CB884-FDBE-415C-AEA0-FBC52D990317")) return false;

            var cmds = new List<SqlCommand>();

            if (i != d.Index)
            {
                cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Material", i, d.Index, m.CategoryId)));
            }
            cmds.Add(DataAccess.AddMasterData(m));

            const string sql = "insert MDG_Material (MID, [Index], BarCode, Model, Size, SizeType, Unit, StorageType, [Description], CreatorDeptId, CreatorUserId) select @MID, @Index, @BarCode, @Model, @Size, @SizeType, @StorageType, @Unit, @Description, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@Index", d.Index),
                new SqlParameter("@BarCode", d.BarCode),
                new SqlParameter("@Model", d.Model),
                new SqlParameter("@Size", d.Size),
                new SqlParameter("@SizeType", SqlDbType.UniqueIdentifier) {Value = d.SizeType},
                new SqlParameter("@Unit", SqlDbType.UniqueIdentifier) {Value = d.Unit},
                new SqlParameter("@StorageType", SqlDbType.UniqueIdentifier) {Value = d.StorageType},
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新物资材料
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Material对象实体</param>
        /// <param name="i">初始索引</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateMaterial(Session us, MasterData m, MDG_Material d, int i)
        {
            if (!Verification(us, "E74CBB7B-CC79-4D11-912C-EEA3398A89E4")) return false;

            var cmds = new List<SqlCommand>
            {
                MakeCommand(DataAccess.ChangeIndex("MDG_Material", i, d.Index, m.CategoryId)),
                DataAccess.UpdateMasterData(m)
            };
            
            const string sql = "update MDG_Material set [Index] = @Index, BarCode = @BarCode, Model = @Model, Size = @Size, SizeType = @SizeType, Unit = @Unit, StorageType = @StorageType, Description = @Description where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@Index", d.Index),
                new SqlParameter("@BarCode", d.BarCode),
                new SqlParameter("@Model", d.Model),
                new SqlParameter("@Size", d.Size),
                new SqlParameter("@SizeType", SqlDbType.UniqueIdentifier) {Value = d.SizeType},
                new SqlParameter("@Unit", SqlDbType.UniqueIdentifier) {Value = d.Unit},
                new SqlParameter("@StorageType", SqlDbType.UniqueIdentifier) {Value = d.StorageType},
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
        /// <param name="id">物资材料ID</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        public int DelMaterial(Session us, Guid id)
        {
            if (!Verification(us, "ECD076C1-1A34-42E6-BBF7-0D15AA99B54E")) return 0;

            var cmds = new List<SqlCommand>();

            var obj = DataAccess.GetData(id);
            var data = GetMaterial(us, id);
            var sql = $"Delete From MasterData where ID = '{id}'";

            cmds.Add(MakeCommand(DataAccess.ChangeIndex("MDG_Material", data.Index, 99999, obj.CategoryId, false)));
            cmds.Add(MakeCommand(sql));
            if (SqlExecute(cmds))
            {
                return 1;
            }
            return SqlExecute(new[] {MakeCommand($"update MDG_Material set [Enable] = 0 where MID = '{id}'")}) ? 2 : 0;
        }

    }
}
