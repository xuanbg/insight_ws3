using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service.Business
{
    public partial class Settlement : ISettlement
    {

        #region 资金结算

        /// <summary>
        /// 计算预付款使用金额
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="adv"></param>
        /// <param name="arow"></param>
        private void UseAdvance(ICollection<DataRow> rows, Advance adv, DataRow arow)
        {
            if (rows.Count > 0)
            {
                var ca = (decimal)arow["UseAdvance"] - (decimal)arow["金额"];
                var aa = adv.Amount > ca ? ca : adv.Amount;
                if (aa == 0) return;

                foreach (var row in rows)
                {
                    var pa = (decimal)row["金额"] - (decimal)row["UseAdvance"];
                    if (aa > pa)
                    {
                        aa -= pa;
                        row["UseAdvance"] = (decimal)row["UseAdvance"] + pa;
                        arow["UseAdvance"] = (decimal)arow["UseAdvance"] - pa;
                    }
                    else
                    {
                        row["UseAdvance"] = aa;
                        arow["UseAdvance"] = (decimal)arow["UseAdvance"] - aa;
                        aa = 0;
                        break;
                    }
                }
                adv.Amount = aa - (adv.Amount > ca ? ca : adv.Amount);
            }
            else
            {
                adv.Amount = 0;
            }
        }

        /// <summary>
        /// 插入结算主记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private SqlCommand InsertClearing(ABS_Clearing obj)
        {
            var sql = "insert ABS_Clearing (Direction, ObjectId, ObjectName, Description, CreatorDeptId, CreatorUserId) select @Direction, @ObjectId, @ObjectName, @Description, @CreatorDeptId, @CreatorUserId ";
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
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 插入项目明细记录
        /// </summary>
        /// <param name="us"></param>
        /// <param name="idt"></param>
        /// <param name="pdt"></param>
        /// <param name="advs"></param>
        /// <param name="saveAdvance"></param>
        /// <returns></returns>
        private IEnumerable<SqlCommand> InsertDetail(Session us, DataTable idt, DataTable pdt, List<Advance> advs, bool saveAdvance = true)
        {
            var cmds = new List<SqlCommand>();
            var sql = "insert ABS_Clearing_Item (ClearingId, Summary, ObjectId, ObjectName, Units, Price, Counts, Amount) select @ClearingId, @Summary, @ObjectId, @ObjectName, @Units, @Price, @Counts, @Amount ";
            sql += "select ID from ABS_Clearing_Item where SN = scope_identity()";
            foreach (DataRow row in idt.Rows)
            {
                var parm = new[]
                {
                    new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                    new SqlParameter("@Summary", row["摘要"]),
                    new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = row["ProductId"]},
                    new SqlParameter("@ObjectName", row["项目"]),
                    new SqlParameter("@Units", row["单位"]),
                    new SqlParameter("@Price", row["单价"]),
                    new SqlParameter("@Counts", row["数量"]),
                    new SqlParameter("@Amount", row["金额"]),
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 0},
                    new SqlParameter("@Write", SqlDbType.Int) {Value = 1}
                };
                cmds.Add(MakeCommand(sql, parm));

                var amoumt = (decimal)row["金额"] - (decimal)row["UseAdvance"];
                if (amoumt > 0) cmds.AddRange(InsertPays(amoumt, pdt));
                if ((bool)row["IsPlan"]) cmds.AddRange(DataAccess.FundPerform(row["ID"], row["金额"]));
                if (row["项目"].ToString() == "预付款" && (decimal)row["金额"] > 0 && saveAdvance) cmds.AddRange(InsertAdvance(us, row));
                if (row["项目"].ToString() == "预付款" && (decimal)row["金额"] < 0) cmds.AddRange(InsertAdvanceRecord(advs));
            }
            return cmds;
        }

        private IEnumerable<SqlCommand> InsertPays(decimal amount, DataTable pdt)
        {
            var cmds = new List<SqlCommand>();
            const string sql = "insert ABS_Clearing_Pay (ClearingItemId, PayType, Code, Amount) select @ClearingItemId, @PayType, @Code, @Amount";
            foreach (DataRow row in pdt.Rows)
            {
                var rpa = (decimal)row["金额"];
                if (rpa <= 0) continue;

                var parm = new[]
                {
                    new SqlParameter("@ClearingItemId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                    new SqlParameter("@PayType", SqlDbType.UniqueIdentifier) {Value = row["结算方式"]},
                    new SqlParameter("@Code", row["票号"]),
                    new SqlParameter("@Amount", amount > rpa ? rpa : amount),
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 1}
                };
                cmds.Add(MakeCommand(sql, parm));

                if (rpa > amount)
                {
                    row["金额"] = rpa - amount;
                    break;
                }

                amount -= rpa;
                row["金额"] = 0;
                if (amount == 0) break;
            }
            return cmds;
        }

        /// <summary>
        /// 获取或建立预付款账户信息
        /// </summary>
        /// <param name="us"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private IEnumerable<SqlCommand> InsertAdvance(Session us, DataRow row)
        {
            var cid = (Guid)row["ObjectId"];
            var gao = GetAdvance(cid);
            var cmds = new List<SqlCommand>();
            string sql;
            SqlParameter[] parm;
            if (gao != null)
            {
                sql = "select @DetailId";
                parm = new[]
                {
                    new SqlParameter("@DetailId", SqlDbType.UniqueIdentifier) {Value = gao.ID},
                    new SqlParameter("@Write", SqlDbType.Int) {Value = 3}
                };
                cmds.Add(QueryAdvanceId(cid));
                cmds.Add(MakeCommand(sql, parm));
            }
            else
            {
                cmds.AddRange(InsertAdvanceDetail(us, cid));
            }

            sql = "insert ABS_Advance_Record (DetailId, Amount, ClearingId) select @DetailId, @Amount, @ClearingId";
            parm = new[]
            {
                new SqlParameter("@DetailId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Amount", (decimal) row["金额"]),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 3},
                new SqlParameter("@Get", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));
            return cmds;
        }

        /// <summary>
        /// 插入预存款资金明细记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">客户ID</param>
        /// <returns>SqlCommand List SqlCommand对象集合</returns>
        private IEnumerable<SqlCommand> InsertAdvanceDetail(Session us, Guid cid)
        {
            var cmds = new List<SqlCommand>();
            string sql;
            ABS_Advance obj;
            SqlParameter[] parm;
            using (var context = new WSEntities())
            {
                obj = context.ABS_Advance.SingleOrDefault(a => a.OwnerId == cid);
            }

            if (obj == null)
            {
                sql = "insert ABS_Advance (OwnerId, CreatorDeptId, CreatorUserId) select @OwnerId, @CreatorDeptId, @CreatorUserId ";
                sql += "select ID from ABS_Advance where SN = scope_identity()";
                parm = new[]
                {
                    new SqlParameter("@OwnerId", SqlDbType.UniqueIdentifier) {Value = cid},
                    new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                    new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                    new SqlParameter("@Write", SqlDbType.Int) {Value = 2}
                };
                cmds.Add(MakeCommand(sql, parm));
            }
            else
            {
                cmds.Add(QueryAdvanceId(cid));
            }

            sql = "insert ABS_Advance_Detail (AccountId, Amount) select @AccountId, 0 ";
            sql += "select ID from ABS_Advance_Detail where SN = scope_identity()";
            parm = new[]
            {
                new SqlParameter("@AccountId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 2}, 
                new SqlParameter("@Write", SqlDbType.Int) {Value = 3}
            };
            cmds.Add(MakeCommand(sql, parm));

            return cmds;
        }

        /// <summary>
        /// 插入预付款使用记录
        /// </summary>
        /// <param name="advs"></param>
        /// <returns></returns>
        private IEnumerable<SqlCommand> InsertAdvanceRecord(IEnumerable<Advance> advs)
        {
            const string sql = "insert ABS_Advance_Record (DetailId, Amount, ClearingId) select @DetailId, @Amount, @ClearingId";
            return advs.Select(adv => new[]
            {
                new SqlParameter("@ClearingId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@DetailId", SqlDbType.UniqueIdentifier) {Value = adv.ID}, 
                new SqlParameter("@Amount", adv.Amount), 
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            }).Select(parm => MakeCommand(sql, parm)).ToList();
        }

        /// <summary>
        /// 根据客户ID查询预付款主记录ID
        /// </summary>
        /// <param name="cid">客户ID</param>
        /// <returns>SqlCommand SqlCommand对象实体</returns>
        private SqlCommand QueryAdvanceId(Guid cid)
        {
            const string sql = "select ID from ABS_Advance where OwnerId = @OwnerId";
            var parm = new[]
            {
                new SqlParameter("@OwnerId", SqlDbType.UniqueIdentifier) {Value = cid},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 2}
            };
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 根据付款人ID获取通用预付款明细记录
        /// </summary>
        /// <param name="id">付款人ID</param>
        /// <returns>Advance 通用预付款明细记录</returns>
        private Advance GetAdvance(Guid id)
        {
            using (var context = new WSEntities())
            {
                return context.Advance.SingleOrDefault(a => a.OwnerId == id && a.Type == 0 && a.ObjectId == null && a.ValidDate == null);
            }
        }

        #endregion

        #region 物资结算

        /// <summary>
        /// 插入结算主记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private SqlCommand InsertDelivery(ABS_Delivery obj)
        {
            var sql = "insert ABS_Delivery (Direction, ObjectId, ObjectName, Description, CreatorDeptId, CreatorUserId) select @Direction, @ObjectId, @ObjectName, @Description, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ABS_Delivery where SN = scope_identity()";
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
            return MakeCommand(sql, parm);
        }

        /// <summary>
        /// 插入项目明细记录
        /// </summary>
        /// <param name="idt"></param>
        /// <returns></returns>
        private IEnumerable<SqlCommand> InsertDeliveryDetail(DataTable idt)
        {
            const string sql = "insert ABS_Delivery_Item (DeliveryId, Summary, ObjectId, ObjectName, Units, Price, Counts, Amount) select @DeliveryId, @Summary, @ObjectId, @ObjectName, @Units, @Price, @Counts, @Amount ";
            return (from DataRow row in idt.Rows
                    select new[]
                {
                    new SqlParameter("@DeliveryId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty}, 
                    new SqlParameter("@Summary", row["摘要"]), 
                    new SqlParameter("@ObjectId", SqlDbType.UniqueIdentifier) {Value = row["ProductId"]}, 
                    new SqlParameter("@ObjectName", row["项目"]), 
                    new SqlParameter("@Units", row["单位"]), 
                    new SqlParameter("@Price", row["单价"]), 
                    new SqlParameter("@Counts", row["数量"]), 
                    new SqlParameter("@Amount", row["金额"]), 
                    new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
                } into parm select MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
