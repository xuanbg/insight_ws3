using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;

namespace Insight.WS.Service.Business
{
    public class CRM : ICRM
    {

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 客户列表</returns>
        public DataTable GetCustomers(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select R.ID, case when R.IsMaster = 1 then 2 else 1 end as Type, C.* from Customer C join MDR_MU R on R.MasterDataId = C.CustomerId and R.EffectiveDate < getdate() and R.FailureDate is null and R.UserId = @UserId union all ";
            sql += "select R.ID, 0 as Type, C.* from Customer C join MDR_MU R on R.MasterDataId = C.CustomerId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 获取客户详细信息列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 客户详细信息列表</returns>
        public DataTable GetCustomerInfo(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select C.* from CustomerInfo C join MDR_MU R on R.MasterDataId = C.CustomerId and R.FailureDate is null and R.UserId = @UserId union ";
            sql += "select C.* from CustomerInfo C join MDR_MU R on R.MasterDataId = C.CustomerId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 根据ID获取客户对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">客户ID</param>
        /// <returns>MDG_Customer 客户对象实体</returns>
        public MDG_Customer GetCustomer(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Customer.SingleOrDefault(m => m.MID == id);
            }
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Customer对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool AddCustomer(Session us, MasterData m, MDG_Customer d)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.AddMasterData(m)};

            var sql = "insert MDG_Customer (MID, EnterpriseType, IndustryType, RegisterNumber, TaxNumber, Corporation, RegisterDate, BusinessScope, Scale, Staffs, [State], Province, City, District, [Address], Phone, ZipCode, Website, Class, Statu, [Description], CreatorDeptId, CreatorUserId) ";
            sql += "select @MID, @EnterpriseType, @IndustryType, @RegisterNumber, @TaxNumber, @Corporation, @RegisterDate, @BusinessScope, @Scale, @Staffs, ID, @Province, @City, @District, @Address, @Phone, @ZipCode, @Website, @Class, @Statu, @Description, @CreatorDeptId, @CreatorUserId from MasterData where FullName = '中华人民共和国'";
            var parm = new[]
            {
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@EnterpriseType", SqlDbType.UniqueIdentifier) {Value = d.EnterpriseType},
                new SqlParameter("@IndustryType", SqlDbType.UniqueIdentifier) {Value = d.IndustryType},
                new SqlParameter("@RegisterNumber", d.RegisterNumber),
                new SqlParameter("@TaxNumber", d.TaxNumber),
                new SqlParameter("@Corporation", d.Corporation),
                new SqlParameter("@RegisterDate", d.RegisterDate),
                new SqlParameter("@BusinessScope", d.BusinessScope),
                new SqlParameter("@Scale", d.Scale),
                new SqlParameter("@Staffs", d.Staffs),
                new SqlParameter("@Province", SqlDbType.UniqueIdentifier) {Value = d.Province},
                new SqlParameter("@City", SqlDbType.UniqueIdentifier) {Value = d.City},
                new SqlParameter("@District", SqlDbType.UniqueIdentifier) {Value = d.District},
                new SqlParameter("@Address", d.Address),
                new SqlParameter("@Phone", d.Phone),
                new SqlParameter("@ZipCode", d.ZipCode),
                new SqlParameter("@Website", d.Website),
                new SqlParameter("@Class", SqlDbType.UniqueIdentifier) {Value = d.Class},
                new SqlParameter("@Statu", SqlDbType.UniqueIdentifier) {Value = d.Statu},
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            sql = "insert MDR_MU (MasterDataId, UserId, IsMaster, EffectiveDate) select @MasterDataId, @UserId, 1, getdate()";
            parm = new[]
            {
                new SqlParameter("@MasterDataId", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 更新客户数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Customer对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateCustomer(Session us, MasterData m, MDG_Customer d)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand> {MasterDataDAL.UpdateMasterData(m)};

            const string sql = "update MDG_Customer set EnterpriseType = @EnterpriseType, IndustryType = @IndustryType, RegisterNumber = @RegisterNumber, TaxNumber = @TaxNumber, Corporation = @Corporation, RegisterDate = @RegisterDate, BusinessScope = @BusinessScope, Scale = @Scale, Staffs = @Staffs, Province = @Province, City = @City, District = @District, [Address] = @Address, Phone = @Phone, ZipCode = @ZipCode, Website = @Website, Class = @Class, Statu = @Statu, [Description] = @Description where MID = @MID";
            var parm = new[]
            {
                new SqlParameter("@EnterpriseType", SqlDbType.UniqueIdentifier) {Value = d.EnterpriseType},
                new SqlParameter("@IndustryType", SqlDbType.UniqueIdentifier) {Value = d.IndustryType},
                new SqlParameter("@RegisterNumber", d.RegisterNumber),
                new SqlParameter("@TaxNumber", d.TaxNumber),
                new SqlParameter("@Corporation", d.Corporation),
                new SqlParameter("@RegisterDate", d.RegisterDate),
                new SqlParameter("@BusinessScope", d.BusinessScope),
                new SqlParameter("@Scale", d.Scale),
                new SqlParameter("@Staffs", d.Staffs),
                new SqlParameter("@Province", SqlDbType.UniqueIdentifier) {Value = d.Province},
                new SqlParameter("@City", SqlDbType.UniqueIdentifier) {Value = d.City},
                new SqlParameter("@District", SqlDbType.UniqueIdentifier) {Value = d.District},
                new SqlParameter("@Address", d.Address),
                new SqlParameter("@Phone", d.Phone),
                new SqlParameter("@ZipCode", d.ZipCode),
                new SqlParameter("@Website", d.Website),
                new SqlParameter("@Class", SqlDbType.UniqueIdentifier) {Value = d.Class},
                new SqlParameter("@Statu", SqlDbType.UniqueIdentifier) {Value = d.Statu},
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));
            return SqlHelper.SqlExecute(cmds);
        }

    }
}
