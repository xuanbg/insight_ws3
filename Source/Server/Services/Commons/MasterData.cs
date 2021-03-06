﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service
{

    public partial class Commons
    {

        /// <summary>
        /// 更新数据状态为可用
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>bool 是否成功</returns>
        public bool EnableMasterData(Session us, Guid id, string tab)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = $"update {tab} set [Enable] = 1 where MID = '{id}'";
            return SqlNonQuery(MakeCommand(sql)) > 0;
        }

        /// <summary>
        /// 删除、停用数据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">数据ID</param>
        /// <param name="tab">数据表名称</param>
        /// <returns>1：删除 2：停用 0：失败</returns>
        public int DelMasterData(Session us, Guid id, string tab)
        {
            if (!OnlineManage.Verification(us)) return 0;

            var cmds = new List<SqlCommand>();
            var rest = 0;

            var sql = $"Delete From MasterData where ID = '{id}'";
            cmds.Add(MakeCommand(sql));
            if (SqlExecute(cmds))
            {
                rest = 1;
            }
            else if (tab != null)
            {
                cmds.Clear();
                cmds.Add(MakeCommand($"update {tab} set [Enable] = 0 where MID = '{id}'"));
                rest = SqlExecute(cmds) ? 2 : 0;
            }
            return rest;
        }

        /// <summary>
        /// 根据ID获取主数据对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">主数据ID</param>
        /// <returns>MasterData 主数据对象实体</returns>
        public MasterData GetMasterData(Session us, Guid id)
        {
            return !OnlineManage.Verification(us) ? null : MasterDataDAL.GetData(id);
        }

        /// <summary>
        /// 插入主数据用户关系
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">关系ID</param>
        /// <param name="obj">MDR_MU对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool Transfer(Session us, Guid? id, MDR_MU obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            if (id.HasValue) cmds.Add(UpdateFailureDate((Guid)id, obj.EffectiveDate));

            var sql = $"select count(*) from MDR_MU where FailureDate is null and MasterDataId = '{obj.MasterDataId}' and UserId = '{obj.UserId}'";
            if ((int)SqlScalar(MakeCommand(sql)) == 0)
            {
                sql = "insert MDR_MU (MasterDataId, UserId, IsMaster, EffectiveDate) select @MasterDataId, @UserId, @IsMaster, @EffectiveDate";
                var parm = new[]
                {
                    new SqlParameter("@MasterDataId", SqlDbType.UniqueIdentifier) {Value = obj.MasterDataId},
                    new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = obj.UserId},
                    new SqlParameter("@IsMaster", obj.IsMaster),
                    new SqlParameter("@EffectiveDate", obj.EffectiveDate)
                };
                cmds.Add(MakeCommand(sql, parm));
            }
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 取消共享
        /// </summary>
        /// <param name="us"></param>
        /// <param name="ids">关系ID集合</param>
        /// <returns>bool 是否成功</returns>
        public bool UnShare(Session us, List<Guid> ids)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = ids.Select(id => UpdateFailureDate(id, DateTime.Now)).ToList();
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 拼装更新失效时间SqlCommand
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private SqlCommand UpdateFailureDate(Guid id, DateTime time)
        {
            const string sql = "update MDR_MU set FailureDate = @FailureDate where ID = @ID";
            var parm = new[]
            {
                new SqlParameter("@FailureDate", time),
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id}
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 插入主数据合并记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="obj">MasterData_Merger对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool AddMerge(Session us, MasterData_Merger obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>
            {
                MakeCommand($"update MDG_Customer set [Enable] = 0, Visible = 0 where MID = '{obj.MasterId}'")
            };

            const string sql = "insert MasterData_Merger (MasterId, MergerId, CreatorUserId) select @MasterId, @MergerId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MasterId", SqlDbType.UniqueIdentifier) {Value = obj.MasterId},
                new SqlParameter("@MergerId", SqlDbType.UniqueIdentifier) {Value = obj.MergerId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="type">字典类型，参看主数据初始化脚本说明</param>
        /// <param name="withOutTree">是否不带分类</param>
        /// <returns>DataTable</returns>
        public DataTable GetDictionary(Session us, string type, bool withOutTree)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(Select D.ID, max(P.Permission) as Permission from Dictionary D ";
            sql += "join Get_PermData('5C801552-1905-452B-AE7F-E57227BE70B8', @UserId, @DeptId) P on P.OrgId = isnull(D.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = D.CreatorUserId group by D.ID) ";
            sql += "select D.*, case when D.IsData = 0 then 0 else L.Permission end as Permission from Dictionary D ";
            sql += $"join List L on L.ID = D.ID where D.type = @Type {(withOutTree ? "and D.IsData = 1" : "")} order by [Index]";
            var parm = new[]
            {
                new SqlParameter("@Type", type),
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 联系人列表</returns>
        public DataTable GetContacts(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select C.* from Contact C join MDR_MU R on R.MasterDataId = C.ParentId and R.FailureDate is null and R.UserId = @UserId union ";
            sql += "select C.* from Contact C join MDR_MU R on R.MasterDataId = C.ParentId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取所有联系方式列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 联系方式列表</returns>
        public DataTable GetContactInfos(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select I.* from ContactInfo I join MasterData C on C.ID = I.MasterDataId join MDR_MU R on R.MasterDataId = C.ParentId and R.FailureDate is null and R.UserId = @UserId union ";
            sql += "select I.* from ContactInfo I join MasterData C on C.ID = I.MasterDataId join MDR_MU R on R.MasterDataId = C.ParentId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取联系人对象实体
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">联系人ID</param>
        /// <returns>MDG_Customer 联系人对象实体</returns>
        public MDG_Contact GetContact(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Contact.SingleOrDefault(m => m.MID == id);
            }
        }

        /// <summary>
        /// 根据ID获取联系人联系方式
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="id">员工ID</param>
        /// <returns>DataTable 联系方式列表</returns>
        public DataTable GetContactInfo(Session us, Guid id)
        {
            return !OnlineManage.Verification(us) ? null : MasterDataDAL.GetContactInfo(id);
        }

        /// <summary>
        /// 获取所有在职员工列表
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <returns>DataTable 在职员工列表</returns>
        public DataTable GetAllEmployees(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            const string sql = "select M.ID, M.Name as 姓名, M.Alias as 登录名 from MasterData M join MDG_Employee E on E.MID = M.ID and E.Status < 3";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据客户/供应商ID获取共享用户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">客户/供应商ID</param>
        /// <returns>DataTable 共享用户列表</returns>
        public DataTable GetSharing(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select R.ID, U.Name as 姓名, U.LoginName as 登录账号 from MDR_MU R join SYS_User U on U.ID = R.UserId where R.IsMaster = 0 and R.FailureDate is null and R.MasterDataId = '{id}'";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public bool AddContact(Session us, MasterData m, MDG_Contact d, DataTable cdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.AddMasterData(m)};

            if (d.IsMaster) cmds.Add(MasterDataDAL.ClearMaster(m.ParentId));
            if (!d.IsMaster && !MasterDataDAL.HasContact(m.ParentId)) d.IsMaster = true;
            var sql = "insert MDG_Contact (MID, LastName, FirstName, MiddleName, Gender, Department, Title, OfficeAddress, HomeAddress, Birthday, [Description], IsMaster, LoginUser, CreatorDeptId, CreatorUserId) ";
            sql += "select @MID, @LastName, @FirstName, @MiddleName, @Gender, @Department, @Title, @OfficeAddress, @HomeAddress, @Birthday, @Description, @IsMaster, @LoginUser, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@LastName", d.LastName),
                new SqlParameter("@FirstName", d.FirstName),
                new SqlParameter("@MiddleName", d.MiddleName),
                new SqlParameter("@Gender", d.Gender),
                new SqlParameter("@Department", d.Department),
                new SqlParameter("@Title", d.Title),
                new SqlParameter("@OfficeAddress", d.OfficeAddress),
                new SqlParameter("@HomeAddress", d.HomeAddress),
                new SqlParameter("@Birthday", d.Birthday),
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@IsMaster", d.IsMaster),
                new SqlParameter("@LoginUser", d.LoginUser),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            cmds.AddRange(MasterDataDAL.InsertContactInfo(Guid.Empty, cdt));
            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新联系人和联系方式
        /// </summary>
        /// <param name="us">Session对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Contact对象实体</param>
        /// <param name="cdl">联系方式删除列表</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateContact(Session us, MasterData m, MDG_Contact d, List<object> cdl, DataTable cdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.UpdateMasterData(m)};

            if (d.IsMaster) cmds.Add(MasterDataDAL.ClearMaster(m.ParentId));
            const string sql = "update MDG_Contact set LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Gender = @Gender, Department = @Department, Title = @Title, OfficeAddress = @OfficeAddress, HomeAddress = @HomeAddress, Birthday = @Birthday, [Description] = @Description, IsMaster = @IsMaster, LoginUser = @LoginUser where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@LastName", d.LastName),
                new SqlParameter("@FirstName", d.FirstName),
                new SqlParameter("@MiddleName", d.MiddleName),
                new SqlParameter("@Gender", d.Gender),
                new SqlParameter("@Department", d.Department),
                new SqlParameter("@Title", d.Title),
                new SqlParameter("@OfficeAddress", d.OfficeAddress),
                new SqlParameter("@HomeAddress", d.HomeAddress),
                new SqlParameter("@Birthday", d.Birthday),
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@IsMaster", d.IsMaster),
                new SqlParameter("@LoginUser", d.LoginUser),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID}
            };
            cmds.Add(MakeCommand(sql, parm));

            cmds.AddRange(MasterDataDAL.DeleteContactInfo(cdl));
            cmds.AddRange(MasterDataDAL.InsertContactInfo(m.ID, cdt));
            return SqlExecute(cmds);
        }

    }
}
