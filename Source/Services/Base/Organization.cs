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
    partial class Base
    {

        #region 获取

        /// <summary>
        /// 获取组织机构树
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 组织机构节点信息结果集</returns>
        public DataTable GetOrgs(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            const string sql = "select * from Organization order by NodeType desc, [Index]";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取机构对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">节点ID</param>
        /// <returns>SYS_Organization 节点对象</returns>
        public SYS_Organization GetOrg(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

            using (var context = new WSEntities())
            {
                return context.SYS_Organization.SingleOrDefault(e => e.ID == id);
            }
        }

        /// <summary>
        /// 获取所有职位成员用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 节点成员信息结果集</returns>
        public DataTable GetOrgMembers(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            const string sql = "select * from TitleMember";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 获取职位成员之外的所有用户
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">节点ID</param>
        /// <returns>DataTable 节点可添加成员信息结果集</returns>
        public DataTable GetOrgMemberBeSides(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select U.ID, U.Name as 用户名, U.LoginName as 登录名, U.[Description] as 描述 from SYS_User U left join MDG_Contact C on C.MID = U.ID ";
            sql += $"where not exists (select UserId from SYS_OrgMember where UserId = U.ID and OrgId = '{id}') and C.MID is null ";
            sql += "order by LoginName";
            return SqlQuery(MakeCommand(sql));
        }

        #endregion

        #region 新增

        /// <summary>
        /// 根据对象实体数据新增一个组织机构节点
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <param name="index">原序号</param>
        /// <returns>object 插入成功返回插入的节点ID；失败返回false</returns>
        public bool AddOrg(Session us, SYS_Organization obj, int index)
        {
            if (!Verification(us, "88AC97EF-52A3-4F7F-8121-4C311206535F")) return false;

            var cmds = new List<SqlCommand>();
            var sql = "insert SYS_Organization (ParentId, NodeType, [Index], Code, Name, Alias, FullName, PositionId, CreatorUserId)";
            sql += "select @ParentId, @NodeType, @Index, @Code, @Name, @Alias, @FullName, @PositionId, @CreatorUserId;";
            sql += "select ID from SYS_Organization where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@NodeType", obj.NodeType),
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@FullName", obj.FullName),
                new SqlParameter("@PositionId", SqlDbType.UniqueIdentifier) {Value = obj.PositionId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("SYS_Organization", index, obj.Index, obj.ParentId, false)));
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据对象实体数据新增一条组织机构节点合并记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点合并对象</param>
        /// <returns>bool 是否插入成功</returns>
        public bool AddOrgMerger(Session us, SYS_OrgMerger obj)
        {
            if (!Verification(us, "DAE7F2C5-E379-4F74-8043-EB616D4A5F8B")) return false;

            const string sql = "insert into SYS_OrgMerger ([OrgId], [MergerOrgId], [CreatorUserId]) select @OrgId, @MergerOrgId, @CreatorUserId select ID From SYS_OrgMerger where SN = SCOPE_IDENTITY()";
            var parm = new[]
            {
                new SqlParameter("@OrgId", SqlDbType.UniqueIdentifier) {Value = obj.OrgId},
                new SqlParameter("@MergerOrgId", SqlDbType.UniqueIdentifier) {Value = obj.MergerOrgId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0;
        }

        /// <summary>
        /// 根据参数组集合批量插入职位成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="tid">职位ID</param>
        /// <param name="uids">用户ID集合</param>
        /// <returns>bool 是否插入成功</returns>
        public bool AddOrgMember(Session us, Guid tid, List<Guid> uids)
        {
            if (!Verification(us, "1F29DDEA-A4D7-4EF9-8136-0D4AFE88CB08")) return false;

            const string sql = "insert into SYS_OrgMember ([OrgId], [UserId], [CreatorUserId]) select @OrgId, @UserId, @CreatorUserId";
            var cmds = uids.Select(id => new[]
            {
                new SqlParameter("@OrgId", SqlDbType.UniqueIdentifier) {Value = tid}, 
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = id}, 
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
            return SqlExecute(cmds);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 根据对象实体数据更新组织机构信息
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <param name="index">原序号</param>
        /// <returns>int 更新成功的记录数量</returns>
        public bool UpdateOrg(Session us, SYS_Organization obj, int index)
        {
            if (!Verification(us, "542D5E28-8102-40C6-9C01-190D13DBF6C6")) return false;

            var cmds = new List<SqlCommand>();

            const string sql = "update SYS_Organization set [Index] = @Index, Code = @Code, Name = @Name, Alias = @Alias, FullName = @FullName, PositionId = @PositionId where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Alias", obj.Alias),
                new SqlParameter("@FullName", obj.FullName),
                new SqlParameter("@PositionId", SqlDbType.UniqueIdentifier) {Value = obj.PositionId}
            };

            cmds.Add(MakeCommand(DataAccess.ChangeIndex("SYS_Organization", index, obj.Index, obj.ParentId, false)));
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据对象实体数据更新组织机构表ParentId字段
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">组织节点对象</param>
        /// <returns>int 更新成功的记录数量</returns>
        public bool UpdateOrgParentId(Session us, SYS_Organization obj)
        {
            if (!Verification(us, "DB1A4EA2-1B3E-41AD-91FA-A3945AB7D901")) return false;

            var org = GetOrg(us, obj.ID);
            var cmds = new List<SqlCommand>();

            const string sql = "update SYS_Organization set ParentId = @ParentId, [Index] = @Index where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = obj.ID},
                new SqlParameter("@Index", obj.Index),
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId}
            };

            cmds.Add(MakeCommand(DataAccess.ChangeIndex("SYS_Organization", 999, obj.Index, obj.ParentId, false)));
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("SYS_Organization", org.Index, 999, org.ParentId, false)));
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据ID删除组织机构节点
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">组织节点ID</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteOrg(Session us, Guid id)
        {
            if (!Verification(us, "71803766-97FE-4E6E-82DB-D5C90D2B7004")) return false;

            var cmds = new List<SqlCommand>();
            var obj = GetOrg(us, id);
            var sql = $"Delete from SYS_Organization where ID = '{id}'";
            cmds.Add(MakeCommand(sql));
            cmds.Add(MakeCommand(DataAccess.ChangeIndex("SYS_Organization", obj.Index, 99999, obj.ParentId, false)));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID集合删除职位成员关系
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="ids">职位成员关系ID集合</param>
        /// <returns>bool 是否删除成功</returns>
        public bool DeleteOrgMember(Session us, List<Guid> ids)
        {
            if (!Verification(us, "70AC8EEB-F920-468D-8C8F-2DBA049ADAE9")) return false;

            const string sql = "Delete from SYS_OrgMember where ID = @ID";
            var cmds = ids.Select(id => new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
            return SqlExecute(cmds);
        }

        #endregion

    }
}
