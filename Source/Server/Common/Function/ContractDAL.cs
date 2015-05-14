using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Insight.WS.Server.Common
{
    public class ContractDAL
    {
        /// <summary>
        /// 构造资金履约SqlCommand
        /// </summary>
        /// <param name="pid">计划ID</param>
        /// <param name="amount">履约金额</param>
        /// <returns>SqlCommand</returns>
        public static List<SqlCommand> FundPerform(object pid, object amount)
        {
            var pids = SqlHelper.SqlQuery(string.Format("select * from dbo.Get_FundPlanId('{0}')", pid));
            const string sql = "insert ABS_Contract_FundPerform (PlanId, ClearingId, Amount) select @PlanId, @ClearingId, @Amount";
            return (from DataRow row in pids.Rows
                select new[]
                {
                    new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty}, 
                    new SqlParameter("@PlanId", SqlDbType.UniqueIdentifier) {Value = row["ID"]},
                    new SqlParameter("@Amount", amount), 
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
                } into parm
                select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 构造物资履约SqlCommand
        /// </summary>
        /// <param name="pid">计划ID</param>
        /// <param name="count">履约金额</param>
        /// <returns>SqlCommand</returns>
        public static List<SqlCommand> GoodsPerform(object pid, object count)
        {
            var pids = SqlHelper.SqlQuery(String.Format("select * from dbo.Get_GoodsPlanId('{0}')", pid));
            const string sql = "insert ABS_Contract_GoodsPerform (PlanId, DeliveryId, Counts) select @PlanId, @DeliveryId, @Counts";
            return (from DataRow row in pids.Rows
                select new[]
                {
                    new SqlParameter("@DeliveryId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty}, 
                    new SqlParameter("@PlanId", SqlDbType.UniqueIdentifier) {Value = row["ID"]}, 
                    new SqlParameter("@Counts", count), 
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
                } into parm
                select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

    }
}
