using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Server.Common
{
    public partial class DataAccess
    {

        /// <summary>
        /// 拼装插入契约主记录的SqlCommand
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">契约主记录对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand AddContract(Session us, ABS_Contract obj)
        {
            var sql = "insert ABS_Contract (ParentId, ContractCode, Title, ObjectId, ObjectName, AgentId, AgentName, ExecuteDeptId, ExecuteUserId, EffectiveDate, InvalidDate, Description, Status, CreatorDeptId, CreatorUserId) ";
            sql += "select @ParentId, @ContractCode, @Title, @ObjectId, @ObjectName, @AgentId, @AgentName, @ExecuteDeptId, @ExecuteUserId, @EffectiveDate, @InvalidDate, @Description, @Status, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ABS_Contract where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@ContractCode", obj.ContractCode),
                new SqlParameter("@Title", obj.Title),
                new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = obj.ObjectId},
                new SqlParameter("@ObjectName", obj.ObjectName),
                new SqlParameter("@AgentId", SqlDbType.UniqueIdentifier) {Value = obj.AgentId},
                new SqlParameter("@AgentName", obj.AgentName),
                new SqlParameter("@ExecuteDeptId", SqlDbType.UniqueIdentifier) {Value = obj.ExecuteDeptId},
                new SqlParameter("@ExecuteUserId", SqlDbType.UniqueIdentifier) {Value = obj.ExecuteUserId},
                new SqlParameter("@EffectiveDate", obj.EffectiveDate),
                new SqlParameter("@InvalidDate", obj.InvalidDate),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Status", obj.Status),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装插入契约标的的SqlCommand
        /// </summary>
        /// <param name="obj">契约标的对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand AddSubject(ABS_Contract_Subjects obj)
        {
            var sql = "insert ABS_Contract_Subjects (ContractId, Direction, PlanType, CategoryId, ObjectId, ObjectName, EffectiveDate, InvalidDate, Units, Price, Counts, Amount, Description) ";
            sql += "select @ContractId, @Direction, @PlanType, @CategoryId, @ObjectId, @ObjectName, @EffectiveDate, @InvalidDate, @Units, @Price, @Counts, @Amount, @Description ";
            sql += "select ID from ABS_Contract_Subjects where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ContractId", SqlDbType.UniqueIdentifier) {Value = obj.ContractId},
                new SqlParameter("@Direction", obj.Direction),
                new SqlParameter("@PlanType", obj.PlanType),
                new SqlParameter("@CategoryId", SqlDbType.UniqueIdentifier) {Value = obj.CategoryId},
                new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = obj.ObjectId},
                new SqlParameter("@ObjectName", obj.ObjectName),
                new SqlParameter("@EffectiveDate", obj.EffectiveDate),
                new SqlParameter("@InvalidDate", obj.InvalidDate),
                new SqlParameter("@Units", obj.Units),
                new SqlParameter("@Price", obj.Price),
                new SqlParameter("@Counts", obj.Counts),
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装插入契约资金计划的SqlCommand
        /// </summary>
        /// <param name="list">契约资金计划对象集合</param>
        /// <returns>SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> AddFundPlan(IEnumerable<ABS_Contract_FundPlan> list)
        {
            var sql = "insert ABS_Contract_FundPlan (ContractId, SubjectsId, ParentId, CurrencyId, Amount, StartDate, EndDate, Ex_StartDate, Ex_EndDate, Description) ";
            sql += "select @ContractId, @SubjectsId, @ParentId, @CurrencyId, @Amount, @StartDate, @EndDate, @Ex_StartDate, @Ex_EndDate, @Description";
            return list.Select(obj => new[]
            {
                new SqlParameter("@ContractId", SqlDbType.UniqueIdentifier) {Value = obj.ContractId},
                new SqlParameter("@SubjectsId", SqlDbType.UniqueIdentifier) {Value = obj.SubjectsId},
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@CurrencyId", SqlDbType.UniqueIdentifier) {Value = obj.CurrencyId},
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@StartDate", obj.StartDate),
                new SqlParameter("@EndDate", obj.EndDate),
                new SqlParameter("@Ex_StartDate", obj.Ex_StartDate),
                new SqlParameter("@Ex_EndDate", obj.Ex_EndDate),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0},
                new SqlParameter("@Get", SqlDbType.Int) {Value = 1}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 拼装插入契约资金计划的SqlCommand
        /// </summary>
        /// <param name="obj">契约资金计划对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand AddFundPlan(ABS_Contract_FundPlan obj)
        {
            var sql = "insert ABS_Contract_FundPlan (ContractId, SubjectsId, ParentId, CurrencyId, Amount, StartDate, EndDate, Ex_StartDate, Ex_EndDate, Description) ";
            sql += "select @ContractId, @SubjectsId, @ParentId, @CurrencyId, @Amount, @StartDate, @EndDate, @Ex_StartDate, @Ex_EndDate, @Description ";
            sql += "select ID from ABS_Contract_FundPlan where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ContractId", SqlDbType.UniqueIdentifier) {Value = obj.ContractId},
                new SqlParameter("@SubjectsId", SqlDbType.UniqueIdentifier) {Value = obj.SubjectsId},
                new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier) {Value = obj.ParentId},
                new SqlParameter("@CurrencyId", SqlDbType.UniqueIdentifier) {Value = obj.CurrencyId},
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@StartDate", obj.StartDate),
                new SqlParameter("@EndDate", obj.EndDate),
                new SqlParameter("@Ex_StartDate", obj.Ex_StartDate),
                new SqlParameter("@Ex_EndDate", obj.Ex_EndDate),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
                
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 构造资金履约SqlCommand
        /// </summary>
        /// <param name="pid">计划ID</param>
        /// <param name="amount">履约金额</param>
        /// <returns>SqlCommand List</returns>
        public static IEnumerable<SqlCommand> FundPerform(object pid, object amount)
        {
            var pids = SqlQuery(MakeCommand($"select * from dbo.Get_FundPlanId('{pid}')"));
            const string sql = "insert ABS_Contract_FundPerform (PlanId, ClearingId, Amount) select @PlanId, @ClearingId, @Amount";
            return (from DataRow row in pids.Rows
                select new[]
                {
                    new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                    new SqlParameter("@PlanId", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                    new SqlParameter("@Amount", amount),
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
                }
                into parm
                select MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 构造资金履约SqlCommand
        /// </summary>
        /// <param name="objs"></param>
        /// <returns>SqlCommand List</returns>
        public static IEnumerable<SqlCommand> FundPerform(List<ABS_Contract_FundPerform> objs)
        {
            const string sql = "insert ABS_Contract_FundPerform (PlanId, ClearingId, Amount) select @PlanId, @ClearingId, @Amount";
            return objs.Select(obj => new[]
            {
                new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@PlanId", SqlDbType.UniqueIdentifier) {Value = obj.PlanId},
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 构造物资履约SqlCommand
        /// </summary>
        /// <param name="pid">计划ID</param>
        /// <param name="count">履约金额</param>
        /// <returns>SqlCommand</returns>
        public static List<SqlCommand> GoodsPerform(object pid, object count)
        {
            var pids = SqlQuery(MakeCommand($"select * from dbo.Get_GoodsPlanId('{pid}')"));
            const string sql = "insert ABS_Contract_GoodsPerform (PlanId, DeliveryId, Counts) select @PlanId, @DeliveryId, @Counts";
            return (from DataRow row in pids.Rows
                select new[]
                {
                    new SqlParameter("@DeliveryId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                    new SqlParameter("@PlanId", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                    new SqlParameter("@Counts", count),
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
                }
                into parm
                select MakeCommand(sql, parm)).ToList();
        }

    }
}
