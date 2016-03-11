using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service.Business
{
    public class SCM : ISCM
    {

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 供应商列表</returns>
        public DataTable GetSuppliers(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select R.ID, case when R.IsMaster = 1 then 0 else 2 end as Type, C.* from Supplier C join MDR_MU R on R.MasterDataId = C.SupplierId and R.FailureDate is null and R.UserId = @UserId union all ";
            sql += "select R.ID, 1 as Type, C.* from Supplier C join MDR_MU R on R.MasterDataId = C.SupplierId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 获取供应商详细信息列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 供应商详细信息列表</returns>
        public DataTable GetSupplierInfo(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select C.* from SupplierInfo C join MDR_MU R on R.MasterDataId = C.SupplierId and R.FailureDate is null and R.UserId = @UserId union ";
            sql += "select C.* from SupplierInfo C join MDR_MU R on R.MasterDataId = C.SupplierId and R.FailureDate is null and R.IsMaster = 1 join MDG_Employee E on E.MID = R.UserId and E.DirectLeader = @UserId";
            var parm = new[] {new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}};
            return SqlQuery(MakeCommand(sql, parm));
        }

        /// <summary>
        /// 根据ID获取供应商对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">供应商ID</param>
        /// <returns>MDG_Supplier 供应商对象实体</returns>
        public MDG_Supplier GetSupplier(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDG_Supplier.SingleOrDefault(m => m.MID == id);
            }
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Supplier对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool AddMasterData(Session us, MasterData m, MDG_Supplier d)
        {
            if (!Verification(us, "C772729A-6876-4E29-8B90-A940D4630127")) return false;

            var cmds = new List<SqlCommand> {DataAccess.AddMasterData(m)};

            var sql = "insert MDG_Supplier (MID, EnterpriseType, IndustryType, RegisterNumber, TaxNumber, Corporation, RegisterDate, BusinessScope, Scale, Staffs, [State], Province, City, District, [Address], Phone, ZipCode, Website, [Description], CreatorDeptId, CreatorUserId) ";
            sql += "select @MID, @EnterpriseType, @IndustryType, @RegisterNumber, @TaxNumber, @Corporation, @RegisterDate, @BusinessScope, @Scale, @Staffs, ID, @Province, @City, @District, @Address, @Phone, @ZipCode, @Website, @Description, @CreatorDeptId, @CreatorUserId from MasterData where FullName = '中华人民共和国'";
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
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            sql = "insert MDR_MU (MasterDataId, UserId, IsMaster, EffectiveDate) select @MasterDataId, @UserId, 1, getdate()";
            parm = new[]
            {
                new SqlParameter("@MasterDataId", SqlDbType.UniqueIdentifier) {Value = d.MID},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            return SqlExecute(cmds);
        }

        /// <summary>
        /// 更新供应商数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="m">MasterData对象实体</param>
        /// <param name="d">MDG_Supplier对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateMasterData(Session us, MasterData m, MDG_Supplier d)
        {
            if (!Verification(us, "E4B9A144-FAB4-41EB-B930-3AE7E8559870")) return false;

            var cmds = new List<SqlCommand> {DataAccess.UpdateMasterData(m)};

            const string sql = "update MDG_Supplier set EnterpriseType = @EnterpriseType, IndustryType = @IndustryType, RegisterNumber = @RegisterNumber, TaxNumber = @TaxNumber, Corporation = @Corporation, RegisterDate = @RegisterDate, BusinessScope = @BusinessScope, Scale = @Scale, Staffs = @Staffs, Province = @Province, City = @City, District = @District, [Address] = @Address, Phone = @Phone, ZipCode = @ZipCode, Website = @Website, [Description] = @Description where MID = @MID";
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
                new SqlParameter("@Description", d.Description),
                new SqlParameter("@MID", SqlDbType.UniqueIdentifier) {Value = d.MID}
            };
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

    }
}
