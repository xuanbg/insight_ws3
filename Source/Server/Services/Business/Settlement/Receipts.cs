using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Service.Business
{
    public partial class Settlement
    {

        /// <summary>
        /// 获取结算记录日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        public DataTable GetClearingDate(Session us)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select convert(varchar(4),getdate(),120) as ID, null as ParentId, 0 as Type, cast(datepart(year , getdate()) as varchar) + '年' as Name union ";
            sql += "select convert(varchar(7),getdate(),120) as ID, convert(varchar(4),getdate(),120) as ParentId, 1 as Type, cast(datepart(month , getdate()) as varchar) + '月' as Name union ";
            sql += "select convert(varchar(10),getdate(),120) as ID, convert(varchar(7),getdate(),120) as ParentId, 2 as Type, cast(datepart(day , getdate()) as varchar) + '日' as Name union ";
            sql += "select distinct convert(varchar(4),CreateTime,120) as ID, null as ParentId, 0 as Type, cast(datepart(year , CreateTime) as varchar) + '年' as Name from ABS_Clearing union ";
            sql += "select distinct convert(varchar(7),CreateTime,120) as ID, convert(varchar(4),CreateTime,120) as ParentId, 1 as Type, cast(datepart(month , CreateTime) as varchar) + '月' as Name from ABS_Clearing union ";
            sql += "select distinct convert(varchar(10),CreateTime,120) as ID, convert(varchar(7),CreateTime,120) as ParentId, 2 as Type, cast(datepart(day , CreateTime) as varchar) + '日' as Name from ABS_Clearing order by ID desc";
            return SqlQuery(MakeCommand(sql));
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
            if (!SimpleVerifty(us)) return null;

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

            return SqlQuery(MakeCommand(sql, parm));
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
            if (!SimpleVerifty(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Clearing C ";
            sql += "join Get_PermData(@ModuleId, @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, case C.Direction when 1 then '收款' else '付款' end as 类型, case when C.Validity = 1 then '正常' else '作废' end as 状态, C.ReceiptCode as 单据号, C.ObjectName as 结算单位, C.Description as 备注, C.CreateTime as 结算时间, U.Name as 经办人, CA.Status as 结账, A.ImageId, L.Permission ";
            sql += "from ABS_Clearing C join List L on L.ID = C.ID join SYS_User U on U.ID = C.CreatorUserId left join ABS_Clearing_Check CA on CA.ID = C.CheckId ";
            sql += $"left join (select A.ClearingId, A.ImageId from ABS_Clearing_Attachs A join ImageData D on D.ID = A.ImageId and D.ImageType = 1 and D.Expand = 'fpx') A on A.ClearingId = C.ID where C.ObjectName like '%{str}%' order by C.CreateTime desc";
            var parm = new[]
            {
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = mid},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlQuery(MakeCommand(sql, parm));
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
            if (!SimpleVerifty(us)) return null;

            var sql = $"select * from dbo.Get_FundPlan('{id}', {dirt})";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据付款人ID获取可用预付款对象实体集合
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="id">付款人ID</param>
        /// <returns>Advance List 可用预付款对象实体集合</returns>
        public List<Advance> GetAdvance(Session us, Guid id)
        {
            if (!SimpleVerifty(us)) return null;

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
            if (!SimpleVerifty(us)) return null;

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
            if (!SimpleVerifty(us)) return null;

            var sql = $"select Summary as 摘要, ObjectName as 项目, Units as 单位, Price as 单价, Counts as 数量, Amount as 金额 from ABS_Clearing_Item where ClearingId = '{cid}'";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取结算方式列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 结算方式列表</returns>
        public DataTable GetReceiptPay(Session us, Guid cid)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select P.Code as 票号, M.Name as 结算方式, sum(P.Amount) as 金额 from ABS_Clearing_Item I join ABS_Clearing_Pay P on P.ClearingItemId = I.ID ";
            sql += $"join MasterData M on M.ID = P.PayType where ClearingId = '{cid}' group by P.Code, M.Name";
            return SqlQuery(MakeCommand(sql));
        }

        /// <summary>
        /// 根据ID获取附件列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 附件列表</returns>
        public DataTable GetReceiptAttach(Session us, Guid cid)
        {
            if (!SimpleVerifty(us)) return null;

            var sql = "select I.ID, case I.ImageType when 1 then '单据' else '附件' end as 类型, I.Code as 编码, I.Name as 名称, I.Expand as 扩展名, ";
            sql += $"M.Name as 密级, I.Pages as 页数, I.Size as 字节数 from ABS_Clearing_Attachs A join ImageData I on I.ID = A.ImageId left join MasterData M on M.ID = I.SecrecyDegree where ClearingId = '{cid}'";
            return SqlQuery(MakeCommand(sql));
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
            if (!SimpleVerifty(us)) return false;

            var code = DataAccess.GetSerialCode(sid, bid, mid, us.DeptId, us.UserId);
            const string sql = "update ABS_Clearing set ReceiptCode = @Code, PrintTimes = 1 where ID = @BusinessId";
            var parm = new[]
            {
                new SqlParameter("@BusinessId", SqlDbType.UniqueIdentifier) {Value = bid},
                new SqlParameter("@Code", code)
            };
            return SqlNonQuery(MakeCommand(sql, parm)) > 0 ? code : null;
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
            if (!Verification(us, "5A4547D1-3A24-4152-ADD7-BECB0A852F31")) return false;

            var cmds = new List<SqlCommand>();
            switch (type)
            {
                case 1:
                    cmds.Add(MakeCommand($"delete ABS_Clearing where ID = '{bid}'"));
                    break;
                case 2:
                    cmds.Add(MakeCommand($"update ABS_Clearing set Validity = 0 where ID = '{bid}'"));
                    break;
                case 3:
                    break;
            }
            return SqlExecute(cmds);
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
            var action = obj.Direction > 0 ? "0536EAF9-257F-41EF-8F96-901ABBA18095" : "1CB951F4-D404-4095-8914-268DF8F5A961";
            if (!Verification(us, action)) return null;

            var col = new DataColumn
            {
                ColumnName = "UseAdvance",
                DataType = typeof(decimal),
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
                    var filter = adv.ObjectId == null ? "项目 <> '预付款' and 金额 - UseAdvance > 0" : $"ProductId = '{adv.ObjectId}' and 金额 - UseAdvance > 0";
                    UseAdvance(idt.Select(filter), adv, irs[0]);
                }
            }

            var cmds = new List<SqlCommand> { InsertClearing(obj) };
            cmds.AddRange(InsertDetail(us, idt, pdt, advs.FindAll(a => a.Amount < 0)));
            return SqlExecute(cmds, 0);
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
            if (!Verification(us, "C6D59DAF-18C8-4A05-AA22-BA27CBC4595B")) return false;

            var cmds = new List<SqlCommand>();
            var obj = new ImageData
            {
                ImageType = 0,
                CreatorDeptId = us.DeptId,
                CreatorUserId = us.UserId
            };

            var img = BuildImage(Guid.Empty, tid, us.DeptName, us.UserName, us.DeptId, us.UserId, obj);
            var id = DataAccess.SaveImage(img);
            var sql = "insert ABS_Clearing_Check (CheckTime, ImageId, CreatorDeptId, CreatorUserId) select getdate(), @ImageId, @CreatorDeptId, @CreatorUserId ";
            sql += "select ID from ABS_Clearing_Check where SN = scope_identity()";
            var parm = new[]
            {
                new SqlParameter("@ImageId", SqlDbType.UniqueIdentifier) {Value = id},
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Write", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

            sql = "update C set CheckId = @CheckId from ABS_Clearing C where C.CreatorUserId = @UserID and C.CheckId is null";
            parm = new[]
            {
                new SqlParameter("@CheckId", SqlDbType.UniqueIdentifier) {Value = Guid.Empty},
                new SqlParameter("@UserID", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Read", SqlDbType.Int) {Value = 0}
            };
            cmds.Add(MakeCommand(sql, parm));

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
            cmds.Add(MakeCommand(sql, parm));
            return SqlExecute(cmds);
        }

    }
}
