using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{

    public partial class Commons
    {

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="getAll">是否忽略Visible属性</param>
        /// <param name="hasAlias">是否显示别名</param>
        /// <returns>DataTable 分类列表</returns>
        public DataTable GetCategorys(Session us, Guid mid, bool getAll, bool hasAlias)
        {
            if (!SimpleVerifty(us)) return null;

            var str = hasAlias ? "case when Alias is null then '' else '(' + Alias + ')' end" : "''";
            var sql = $"select ID, ParentId, [Index], Name + {str} as Name, Alias, Code, BuiltIn, Visible from BASE_Category where ModuleId = '{mid}'{(getAll ? "" : " and Visible = 1")} order by [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取BASE_Category对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">分类ID</param>
        /// <returns>BASE_Category对象实体</returns>
        public BASE_Category GetCategory(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BASE_Category.SingleOrDefault(c => c.ID == id);
            }
        }

        /// <summary>
        /// 新增分类数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <returns>object 插入成功返回新插入记录的ID；插入失败返回false</returns>
        public bool AddCategory(Session us, BASE_Category obj, int index)
        {
            if (!SimpleVerifty(us)) return false;

            var cmds = new List<SqlCommand>();
            var sql = new StringBuilder("insert BASE_Category (ParentId, ModuleId, [Index], Code, Name, Alias, Description, CreatorDeptId, CreatorUserId)");
            sql.Append("select @ParentId, @ModuleId, @Index, @Code, @Name, @Alias, @Description, @CreatorDeptId, @CreatorUserId;");
            sql.Append("select ID from BASE_Category where SN = scope_identity()");
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = obj.ModuleId},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", index, obj.Index, obj.ParentId, false, obj.ModuleId)));
            cmds.Add(MakeCommand(sql.ToString(), parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 编辑分类数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="obj">BASE_Category 对象实体</param>
        /// <param name="index">变更前的Index值</param>
        /// <param name="oldParentId">变更前的父分类ID</param>
        /// <param name="oldIndex">原Index值</param>
        /// <returns>object 更新成功返回true；更新失败返回false</returns>
        public bool UpdateCategory(Session us, BASE_Category obj, int index, Guid? oldParentId, int oldIndex)
        {
            if (!SimpleVerifty(us)) return false;

            var cmds = new List<SqlCommand>();
            var sql = new StringBuilder("update BASE_Category set ParentId = @ParentId, [Index] = @Index, Code = @Code, Name = @Name, Alias = @Alias, Description = @Description where ID = @ID");
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID}
            };
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", index, obj.Index, obj.ParentId, false, obj.ModuleId)));
            cmds.Add(MakeCommand(sql.ToString(), parm));
            if (obj.ParentId != oldParentId)
            {
                cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", oldIndex, 9999, oldParentId, false, obj.ModuleId)));
            }
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">分类ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DelCategory(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return false;

            var cmds = new List<SqlCommand>();
            var obj = GetCategory(us, id);
            var sql = $"delete BASE_Category where ID = '{id}'";

            cmds.Add(MakeCommand(sql));
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("BASE_Category", obj.Index, 99999, obj.ParentId, false, obj.ModuleId)));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 全部分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        public bool GlobalNameIsExisting(Session us, Guid mid, string col, string str)
        {
            return SimpleVerifty(us) && NameIsExisting(mid, col, str);
        }

        /// <summary>
        /// 父分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="col">数据列名称</param>
        /// <param name="str">要比对的名称</param>
        /// <param name="pid">父节点ID</param>
        /// <returns>bool:要比对的名称是否存在</returns>
        public bool LocalNameIsExisting(Session us, Guid mid, string col, string str, Guid? pid)
        {
            return SimpleVerifty(us) && NameIsExisting(mid, "Name", str, pid);
        }

        /// <summary>
        /// 分类中是否存在指定名称的对象
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="columnName"></param>
        /// <param name="name"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private bool NameIsExisting(Guid moduleId, string columnName, string name, params Guid?[] parentId)
        {
            var sql = $"select count(*) from BASE_Category where ModuleId = '{moduleId}' and {columnName} = '{name}' ";
            sql += parentId.Length == 0 ? "" : $"and ParentId {(parentId[0] == null ? "is null" : $"= '{parentId[0]}'")}";
            using (var context = new WSEntities())
            {
                return context.Database.SqlQuery<int>(sql).FirstOrDefault() > 0;
            }
        }

    }
}
