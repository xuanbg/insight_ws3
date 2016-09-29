using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public partial class DataAccess
    {

        /// <summary>
        /// 拼装插入结算主记录的SqlCommand
        /// </summary>
        /// <param name="obj">结算主记录对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertClearing(ABS_Clearing obj)
        {
            var sql = "insert ABS_Clearing (Direction, ObjectId, ObjectName, Description, CreatorDeptId, CreatorUserId) ";
            sql += "select @Direction, @ObjectId, @ObjectName, @Description, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ABS_Clearing where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@Direction", obj.Direction),
                new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = obj.ObjectId},
                new SqlParameter("@ObjectName", obj.ObjectName),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorDeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = obj.CreatorUserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装插入项目明细记录的SqlCommand
        /// </summary>
        /// <param name="obj">结算项目明细对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertDetail(ABS_Clearing_Item obj)
        {
            var sql = "insert ABS_Clearing_Item (ClearingId, Summary, ObjectId, ObjectName, Units, Price, Counts, Amount) ";
            sql += "select @ClearingId, @Summary, @ObjectId, @ObjectName, @Units, @Price, @Counts, @Amount ";
            sql += "select ID from ABS_Clearing_Item where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Summary", obj.Summary),
                new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = obj.ObjectId},
                new SqlParameter("@ObjectName", obj.ObjectName),
                new SqlParameter("@Units", obj.Units),
                new SqlParameter("@Price", obj.Price),
                new SqlParameter("@Counts", obj.Counts),
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 拼装插入项目支付明细记录的SqlCommand
        /// </summary>
        /// <param name="obj">结算支付明细对象</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand InsertPays(ABS_Clearing_Pay obj)
        {
            var sql = "insert ABS_Clearing_Pay (ClearingItemId, PayType, Code, Amount) ";
            sql += "select @ClearingItemId, @PayType, @Code, @Amount";
            var parm = new[]
            {
                new SqlParameter("@ClearingItemId", SqlDbType.UniqueIdentifier) {Value = obj.ClearingItemId},
                new SqlParameter("@PayType", SqlDbType.UniqueIdentifier) {Value = obj.PayType},
                new SqlParameter("@Code", obj.Code),
                new SqlParameter("@Amount", obj.Amount),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
            };
            return SqlHelper.MakeCommand(sql, parm);
        }

        /// <summary>
        /// 构造账单履约结算记录的SqlCommand
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="user">用户姓名</param>
        /// <param name="ba">本金金额</param>
        /// <param name="sa">服务费金额</param>
        /// <param name="la">违约金金额</param>
        /// <param name="payType">付款方式</param>
        /// <param name="payCode">结算号</param>
        /// <param name="direction">资金方向：1、流入；-1、流出（默认流入）</param>
        /// <returns>SqlCommand集合</returns>
        public static IEnumerable<SqlCommand> BillClearing(Guid uid, string user, decimal ba, decimal sa, decimal la, string payType, string payCode, int direction = 1)
        {
            Guid payId;
            MasterData product;
            MasterData service;
            MasterData liquidated;
            using (var context = new Entities())
            {
                payId = context.MasterData.Single(m => m.Alias == payType).ID;
                product = context.MasterData.Single(m => m.Alias == "Loans");
                service = context.MasterData.Single(m => m.Alias == "Service");
                liquidated = context.MasterData.Single(m => m.Alias == "Liquidated");
            }

            // 插入结算记录
            var clear = new ABS_Clearing
            {
                Direction = direction,
                ObjectId = uid,
                ObjectName = user,
                Description = "分期购物商城账单还款",
                CreatorUserId = Guid.Empty
            };
            var cmds = new List<SqlCommand> { InsertClearing(clear) };

            // 结算本金
            var item = new ABS_Clearing_Item
            {
                Summary = "分期购物账单还款（本金）",
                ObjectId = product.ID,
                ObjectName = product.Name,
                Units = "元",
                Amount = ba
            };
            cmds.Add(InsertDetail(item));
            var pay = new ABS_Clearing_Pay
            {
                PayType = payId,
                Code = payCode,
                Amount = ba
            };
            cmds.Add(InsertPays(pay));

            // 结算服务费
            if (sa > 0)
            {
                item = new ABS_Clearing_Item
                {
                    Summary = "支付分期服务费",
                    ObjectId = service.ID,
                    ObjectName = service.Name,
                    Units = "元",
                    Amount = sa
                };
                cmds.Add(InsertDetail(item));
                pay = new ABS_Clearing_Pay
                {
                    PayType = payId,
                    Code = payCode,
                    Amount = sa
                };
                cmds.Add(InsertPays(pay));
            }

            // 结算违约金
            if (la > 0)
            {
                item = new ABS_Clearing_Item
                {
                    Summary = "支付逾期违约金",
                    ObjectId = liquidated.ID,
                    ObjectName = liquidated.Name,
                    Units = "元",
                    Amount = la
                };
                cmds.Add(InsertDetail(item));
                pay = new ABS_Clearing_Pay
                {
                    PayType = payId,
                    Code = payCode,
                    Amount = la
                };
                cmds.Add(InsertPays(pay));
            }

            return cmds;
        }

    }
}
