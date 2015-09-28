using System;
using System.Data;
using System.Data.SqlClient;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Server.Common
{
    public class ClearingDAL
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

    }
}
