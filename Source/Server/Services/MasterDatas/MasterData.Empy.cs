using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service
{
    public partial class MasterDatas
    {
        /// <summary>
        /// 根据部门ID获取部门员工列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="oid">部门ID</param>
        /// <returns>DataTable 部门员工列表</returns>
        public DataTable GetEmployees(Session us, Guid oid)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("with List as (select E.MID, MAX(P.Permission) as Permission from [MDG_Employee] E ");
            sql.Append("join Get_PermData('9B2CB116-6E3B-4A9F-9279-E3F568514BEE', @UserId, @DeptId) P on P.OrgId = isnull(E.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = E.CreatorUserId group by E.MID) ");
            sql.Append("select E.*, L.Permission from Employee E join List L on L.MID = E.ID where E.DeptId = @ID");
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = oid},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        /// <summary>
        /// 根据员工姓名获取员工列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">员工姓名</param>
        /// <returns>DataTable 部门员工列表</returns>
        public DataTable GetEmployeesForName(Session us, string name)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("with List as (select E.MID, MAX(P.Permission) as Permission from [MDG_Employee] E ");
            sql.Append("join Get_PermData('9B2CB116-6E3B-4A9F-9279-E3F568514BEE', @UserId, @DeptId) P on P.OrgId = isnull(E.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = E.CreatorUserId group by E.MID) ");
            sql.AppendFormat("select E.*, L.Permission from Employee E join List L on L.MID = E.ID where E.姓名 like '%{0}%'", name);
            var parm = new[]
            {
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            return SqlHelper.SqlQuery(sql.ToString(), parm);
        }

        /// <summary>
        /// 根据ID获取员工对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <returns>MDG_Employee 员工对象实体</returns>
        public MDG_Employee GetEmployee(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Employee.SingleOrDefault(d => d.MID == id);
            }
        }

        /// <summary>
        /// 获取员工职位关系对象实体
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <returns>MDR_ET 职位关系对象实体</returns>
        public MDR_ET GetEmployeeTitle(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDR_ET.SingleOrDefault(d => d.EmployeeId == id);
            }
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Employee对象实体</param>
        /// <param name="r">MDR_ET对象实体</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public bool AddEmployee(Session us, MasterData m, MDG_Employee d, MDR_ET r, DataTable cdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.AddMasterData(m)};

            var sql = "insert MDG_Employee (MID, Gender, WorkType, IdCardNo, DirectLeader, OfficeAddress, HomeAddress, Photo, Thumbnail, EntryDate, DimissionDate, Description, Status, LoginUser, CreatorDeptId, CreatorUserId) select @MID, @Gender, @WorkType, @IdCardNo, @DirectLeader, @OfficeAddress, @HomeAddress, @Photo, @Thumbnail, @EntryDate, @DimissionDate, @Description, @Status, @LoginUser, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@Gender", d.Gender),
                new SqlParameter("@WorkType", SqlDbType.UniqueIdentifier) {Value = d.WorkType},
                new SqlParameter("@IdCardNo", d.IdCardNo),
                new SqlParameter("@DirectLeader", SqlDbType.UniqueIdentifier) {Value = d.DirectLeader},
                new SqlParameter("@OfficeAddress", d.OfficeAddress),
                new SqlParameter("@HomeAddress", d.HomeAddress),
                new SqlParameter("@Photo", SqlDbType.Image) {Value = d.Photo},
                new SqlParameter("@Thumbnail", SqlDbType.Image) {Value = d.Thumbnail},
                new SqlParameter("@EntryDate", d.EntryDate),
                new SqlParameter("@DimissionDate", d.DimissionDate),
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@Status", d.Status),
                new SqlParameter("@LoginUser", d.LoginUser),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            sql = "insert MDR_ET (EmployeeId, TitleId) select @EmployeeId, @TitleId";
            parm = new[]
            {
                new SqlParameter("@EmployeeId", SqlDbType.UniqueIdentifier) {Value = r.EmployeeId},
                new SqlParameter("@TitleId", SqlDbType.UniqueIdentifier) {Value = r.TitleId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            cmds.AddRange(MasterDataDAL.InsertContactInfo(Guid.Empty, cdt));
            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 更新员工和联系方式
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Employee对象实体</param>
        /// <param name="r">MDR_ET对象实体</param>
        /// <param name="cdl">联系方式删除列表</param>
        /// <param name="cdt">联系方式列表</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateEmployee(Session us, MasterData m, MDG_Employee d, MDR_ET r, List<object> cdl, DataTable cdt)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.UpdateMasterData(m)};

            const string sql = "update MDG_Employee set Gender = @Gender, WorkType = @WorkType, IdCardNo = @IdCardNo, DirectLeader = @DirectLeader, OfficeAddress = @OfficeAddress, HomeAddress = @HomeAddress, Photo = @Photo, Thumbnail = @Thumbnail, EntryDate = @EntryDate, DimissionDate = @DimissionDate, Description = @Description, Status = @Status, LoginUser = @LoginUser where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@Gender", d.Gender),
                new SqlParameter("@WorkType", SqlDbType.UniqueIdentifier) {Value = d.WorkType},
                new SqlParameter("@IdCardNo", d.IdCardNo),
                new SqlParameter("@DirectLeader", SqlDbType.UniqueIdentifier) {Value = d.DirectLeader},
                new SqlParameter("@OfficeAddress", d.OfficeAddress),
                new SqlParameter("@HomeAddress", d.HomeAddress),
                new SqlParameter("@Photo", SqlDbType.Image) {Value = d.Photo},
                new SqlParameter("@Thumbnail", SqlDbType.Image) {Value = d.Thumbnail},
                new SqlParameter("@EntryDate", d.EntryDate),
                new SqlParameter("@DimissionDate", d.DimissionDate),
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@Status", d.Status),
                new SqlParameter("@LoginUser", d.LoginUser),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));
            cmds.Add(SqlHelper.MakeCommand(string.Format("update MDR_ET set TitleId = '{0}' where ID = '{1}'", r.TitleId, r.ID)));

            cmds.AddRange(MasterDataDAL.DeleteContactInfo(cdl));
            cmds.AddRange(MasterDataDAL.InsertContactInfo(m.ID, cdt));
            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 更新员工状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">员工ID</param>
        /// <param name="stu">状态</param>
        /// <returns>bool 是否更新成功</returns>
        public bool UpdateStatus(Session us, Guid id, int stu)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = "update MDG_Employee set Status = @Status where MID = @ID ";
            var parm = new[]
            {
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier) {Value = id},
                new SqlParameter("@Status", 1)
            };

            switch (stu)
            {
                case 1:
                    parm[1].Value = 2;
                    break;

                case 3:
                    sql += "update MDG_Employee set DimissionDate = getdate() where MID = @ID ";
                    sql += "update SYS_User Set Validity = 0 where ID = @ID";
                    parm[1].Value = 3;
                    break;

                case 4:
                    sql += "update MDG_Employee set DimissionDate = null where MID = @ID ";
                    sql += "update SYS_User Set Validity = 1 where ID = @ID";
                    break;
            }
            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

    }
}
