using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;

namespace Insight.WS.Service.Business
{
    public class Settlement : ISettlement
    {
        /// <summary>
        /// 获取结算记录日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        public DataTable GetClearingDate(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select convert(varchar(4),getdate(),120) as ID, null as ParentId, 0 as Type, cast(datepart(year , getdate()) as varchar) + '年' as Name union ";
            sql += "select convert(varchar(7),getdate(),120) as ID, convert(varchar(4),getdate(),120) as ParentId, 1 as Type, cast(datepart(month , getdate()) as varchar) + '月' as Name union ";
            sql += "select convert(varchar(10),getdate(),120) as ID, convert(varchar(7),getdate(),120) as ParentId, 2 as Type, cast(datepart(day , getdate()) as varchar) + '日' as Name union ";
            sql += "select distinct convert(varchar(4),CreateTime,120) as ID, null as ParentId, 0 as Type, cast(datepart(year , CreateTime) as varchar) + '年' as Name from ABS_Clearing union ";
            sql += "select distinct convert(varchar(7),CreateTime,120) as ID, convert(varchar(4),CreateTime,120) as ParentId, 1 as Type, cast(datepart(month , CreateTime) as varchar) + '月' as Name from ABS_Clearing union ";
            sql += "select distinct convert(varchar(10),CreateTime,120) as ID, convert(varchar(7),CreateTime,120) as ParentId, 2 as Type, cast(datepart(day , CreateTime) as varchar) + '日' as Name from ABS_Clearing order by ID desc";
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据日期查询收款记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="date">收款日期</param>
        /// <returns>DataTable 收款记录</returns>
        public DataTable GetReceiptsForDate(Session us, Guid mid, string date)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Clearing C ";
            sql += "join Get_PermData(@ModuleId, @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, case C.Direction when 1 then '收款' else '付款' end as 类型, case when C.Validity = 1 then '正常' else '作废' end as 状态, C.ReceiptCode as 单据号, C.ObjectName as 结算单位, C.Description as 备注, C.CreateTime as 结算时间, U.Name as 经办人, CA.Status as 结账, A.ImageId, L.Permission ";
            sql += "from ABS_Clearing C join List L on L.ID = C.ID join SYS_User U on U.ID = C.CreatorUserId left join ABS_Clearing_Check CA on CA.ID = C.CheckId ";
            sql += "left join (select A.ClearingId, A.ImageId from ABS_Clearing_Attachs A join ImageData D on D.ID = A.ImageId and D.ImageType = 1 and D.Expand = 'fpx') A on A.ClearingId = C.ID where C.CreateTime >= @Date and C.CreateTime < dateadd(day, 1, @Date) order by C.CreateTime desc";
            var parm = new[]
            {
                new SqlParameter("@Date", date), 
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = mid}, 
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}, 
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 根据付款人查询收款记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataTable 收款记录</returns>
        public DataTable GetReceiptsForName(Session us, Guid mid, string str)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Clearing C ";
            sql += "join Get_PermData(@ModuleId, @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, case C.Direction when 1 then '收款' else '付款' end as 类型, case when C.Validity = 1 then '正常' else '作废' end as 状态, C.ReceiptCode as 单据号, C.ObjectName as 结算单位, C.Description as 备注, C.CreateTime as 结算时间, U.Name as 经办人, CA.Status as 结账, A.ImageId, L.Permission ";
            sql += "from ABS_Clearing C join List L on L.ID = C.ID join SYS_User U on U.ID = C.CreatorUserId left join ABS_Clearing_Check CA on CA.ID = C.CheckId ";
            sql += string.Format("left join (select A.ClearingId, A.ImageId from ABS_Clearing_Attachs A join ImageData D on D.ID = A.ImageId and D.ImageType = 1 and D.Expand = 'fpx') A on A.ClearingId = C.ID where C.ObjectName like '%{0}%' order by C.CreateTime desc", str);
            var parm = new[]
            {
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = mid},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 根据付款人ID获取未履约数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">付款人ID</param>
        /// <param name="dirt">资金方向</param>
        /// <returns>DataTable 未履约数据</returns>
        public DataTable GetFundPlans(Session us, Guid id, int dirt)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = string.Format("select * from dbo.Get_FundPlan('{0}', {1})", id, dirt);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据付款人ID获取可用预付款对象实体集合
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">付款人ID</param>
        /// <returns>Advance List 可用预付款对象实体集合</returns>
        public List<Advance> GetAdvance(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.Advance.Where(a => a.OwnerId == id).ToList();
            }
        }

        /// <summary>
        /// 根据ID获取结算记录对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>ABS_Clearing 结算记录对象实体</returns>
        public ABS_Clearing GetReceipt(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.ABS_Clearing.SingleOrDefault(c => c.ID == cid);
            }
        }

        /// <summary>
        /// 根据ID获取收费项目列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 收费项目列表</returns>
        public DataTable GetReceiptItem(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = string.Format("select Summary as 摘要, ObjectName as 项目, Units as 单位, Price as 单价, Counts as 数量, Amount as 金额 from ABS_Clearing_Item where ClearingId = '{0}'", cid);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取结算方式列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 结算方式列表</returns>
        public DataTable GetReceiptPay(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select P.Code as 票号, M.Name as 结算方式, sum(P.Amount) as 金额 from ABS_Clearing_Item I join ABS_Clearing_Pay P on P.ClearingItemId = I.ID ";
            sql += string.Format("join MasterData M on M.ID = P.PayType where ClearingId = '{0}' group by P.Code, M.Name", cid);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取附件列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 附件列表</returns>
        public DataTable GetReceiptAttach(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select I.ID, case I.ImageType when 1 then '单据' else '附件' end as 类型, I.Code as 编码, I.Name as 名称, I.Expand as 扩展名, ";
            sql += string.Format("M.Name as 密级, I.Pages as 页数, I.Size as 字节数 from ABS_Clearing_Attachs A join ImageData I on I.ID = A.ImageId left join MasterData M on M.ID = I.SecrecyDegree where ClearingId = '{0}'", cid);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 更新收据号
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="mid">业务模块ID</param>
        /// <returns>bool 是否更新成功</returns>
        public object GetReceiptCode(Session us, Guid sid, Guid bid, Guid mid)
        {
            if (!OnlineManage.Verification(us)) return false;

            var code = CommonDAL.GetSerialCode(sid, bid, mid, us.DeptId, us.UserId);
            const string sql = "update ABS_Clearing set ReceiptCode = @Code, PrintTimes = 1 where ID = @BusinessId";
            var parm = new[]
            {
                new SqlParameter("@BusinessId", SqlDbType.UniqueIdentifier) {Value = bid},
                new SqlParameter("@Code", code)
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0 ? code : null;
        }

        /// <summary>
        /// 删除/作废收据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="type">操作类型</param>
        /// <returns>bool 是否更新成功</returns>
        public bool DelReceipt(Session us, Guid bid, int type)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            switch (type)
            {
                case 1:
                    cmds.Add(SqlHelper.MakeCommand(string.Format("delete ABS_Clearing where ID = '{0}'", bid)));
                    break;
                case 2:
                    cmds.Add(SqlHelper.MakeCommand(string.Format("update ABS_Clearing set Validity = 0 where ID = '{0}'", bid)));
                    break;
                case 3:
                    break;
            }
            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 保存结算记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">ABS_Clearing对象实体</param>
        /// <param name="idt">结算项目列表</param>
        /// <param name="pdt">结算方式列表</param>
        /// <returns>object 结算记录ID</returns>
        public object AddClearing(Session us, ABS_Clearing obj, DataTable idt, DataTable pdt)
        {
            if (!OnlineManage.Verification(us)) return null;

            var col = new DataColumn
            {
                ColumnName = "UseAdvance",
                DataType = typeof (decimal),
                DefaultValue = 0
            };
            idt.Columns.Add(col);

            var advs = new List<Advance>();
            var irs = idt.Select("项目 = '预付款' and 金额 < 0");
            if (irs.Length > 0)
            {
                using (var context = new WSEntities())
                {
                    advs = context.Advance.Where(a => a.OwnerId == obj.ObjectId).ToList();
                }

                foreach (var adv in advs)
                {
                    var filter = adv.ObjectId == null ? "项目 <> '预付款' and 金额 - UseAdvance > 0" : string.Format("ProductId = '{0}' and 金额 - UseAdvance > 0", adv.ObjectId);
                    UseAdvance(idt.Select(filter), adv, irs[0]);
                }
            }

            var cmds = new List<SqlCommand> {InsertClearing(obj)};
            cmds.AddRange(InsertDetail(us, idt, pdt, advs.FindAll(a => a.Amount < 0)));
            return SqlHelper.SqlExecute(cmds, 0);
        }

        /// <summary>
        /// 插入结账记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="tid">模板ID</param>
        /// <param name="sid">编码方案ID</param>
        /// <returns>bool 是否成功</returns>
        public bool AddCheck(Session us, Guid tid, Guid sid)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();
            var obj = new ImageData
            {
                ImageType = 0,
                CreatorDeptId = us.DeptId,
                CreatorUserId = us.UserId
            };

            var img = ReportDAL.BuildImage(Guid.Empty, tid, us.DeptName, us.UserName, us.DeptId, us.UserId, obj);
            var id = ReportDAL.SaveImage(img);
            var sql = "insert ABS_Clearing_Check (CheckTime, ImageId, CreatorDeptId, CreatorUserId) select getdate(), @ImageId, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ABS_Clearing_Check where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ImageId", SqlDbType.UniqueIdentifier) {Value = id},
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            sql = "update C set CheckId = @CheckId from ABS_Clearing C where C.CreatorUserId = @UserID and C.CheckId is null";
            parm = new[]
            {
                new SqlParameter("@CheckId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@UserID", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            sql = "exec Get_Code @SchemeId, @DeptId, @UserId, @BusinessId, @ModuleId, @Char, @Code output ";
            sql += "update ABS_Clearing_Check set ReceiptCode = @Code where ID = @BusinessId";
            parm = new[]
            {
                new SqlParameter("@BusinessId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@SchemeId", SqlDbType.UniqueIdentifier) {Value = sid},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = Guid.Parse("B2C41F35-9D5E-42DC-8DEC-08BF9E57CE2A")},
                new SqlParameter("@Char", null),
                new SqlParameter("@Code", SqlDbType.VarChar),
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));
            return SqlHelper.SqlExecute(cmds);
        }

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
            return SqlHelper.MakeCommand(sql, parm);
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
                cmds.Add(SqlHelper.MakeCommand(sql, parm));

                var amoumt = (decimal)row["金额"] - (decimal)row["UseAdvance"];
                if (amoumt > 0) cmds.AddRange(InsertPays(amoumt, pdt));
                if ((bool)row["IsPlan"]) cmds.AddRange(ContractDAL.FundPerform(row["ID"], row["金额"]));
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
                cmds.Add(SqlHelper.MakeCommand(sql, parm));

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
                cmds.Add(SqlHelper.MakeCommand(sql, parm));
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
            cmds.Add(SqlHelper.MakeCommand(sql, parm));
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
                cmds.Add(SqlHelper.MakeCommand(sql, parm));
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
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

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
            }).Select(parm => SqlHelper.MakeCommand(sql, parm)).ToList();
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
            return SqlHelper.MakeCommand(sql, parm);
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

    }
}
