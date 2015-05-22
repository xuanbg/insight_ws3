using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.Business
{
    public class Storage : IStorage
    {

        #region 查询

        /// <summary>
        /// 获取结算记录日期列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>DataTable 结算记录日期列表</returns>
        public DataTable GetDeliveryDate(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = new StringBuilder("select convert(varchar(4),getdate(),120) as ID, null as ParentId, 0 as Type, cast(datepart(year , getdate()) as varchar) + '年' as Name union ");
            sql.Append("select convert(varchar(7),getdate(),120) as ID, convert(varchar(4),getdate(),120) as ParentId, 1 as Type, cast(datepart(month , getdate()) as varchar) + '月' as Name union ");
            sql.Append("select convert(varchar(10),getdate(),120) as ID, convert(varchar(7),getdate(),120) as ParentId, 2 as Type, cast(datepart(day , getdate()) as varchar) + '日' as Name union ");
            sql.Append("select distinct convert(varchar(4),CreateTime,120) as ID, null as ParentId, 0 as Type, cast(datepart(year , CreateTime) as varchar) + '年' as Name from ABS_Delivery union ");
            sql.Append("select distinct convert(varchar(7),CreateTime,120) as ID, convert(varchar(4),CreateTime,120) as ParentId, 1 as Type, cast(datepart(month , CreateTime) as varchar) + '月' as Name from ABS_Delivery union ");
            sql.Append("select distinct convert(varchar(10),CreateTime,120) as ID, convert(varchar(7),CreateTime,120) as ParentId, 2 as Type, cast(datepart(day , CreateTime) as varchar) + '日' as Name from ABS_Delivery order by ID desc");
            return SqlHelper.SqlQuery(sql.ToString());
        }

        /// <summary>
        /// 根据日期查询出入库记录
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="mid">模块ID</param>
        /// <param name="date">收款日期</param>
        /// <returns>DataTable 收款记录</returns>
        public DataTable GetDeliveryForDate(Session us, Guid mid, string date)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Delivery C ";
            sql += "join Get_PermData(@ModuleId, @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, case when C.Validity = 1 then '正常' else '作废' end as 状态, case C.Direction when 1 then '入库' when 0 then '退库' else '出库' end as 类型, C.ReceiptCode as 单据号, ";
            sql += "C.ObjectName as [客户/供应商], C.Description as 备注, C.CreateTime as 出入库时间, U.Name as 经办人, A.ImageId, L.Permission from ABS_Delivery C join List L on L.ID = C.ID join SYS_User U on U.ID = C.CreatorUserId ";
            sql += "left join (select A.DeliveryId, A.ImageId from ABS_Delivery_Attachs A join ImageData D on D.ID = A.ImageId and D.ImageType = 1 and D.Expand = 'fpx') A on A.DeliveryId = C.ID where C.CreateTime >= @Date and C.CreateTime < dateadd(day, 1, @Date) order by C.CreateTime desc";
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
        /// 根据关键字查询出入库记录
        /// </summary>
        /// <param name="us"></param>
        /// <param name="mid">模块ID</param>
        /// <param name="str">查询关键字</param>
        /// <returns>DataTable 收款记录</returns>
        public DataTable GetDeliveryForName(Session us, Guid mid, string str)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "with List as(select C.ID, max(P.Permission) as Permission from ABS_Delivery C ";
            sql += "join Get_PermData(@ModuleId, @UserId, @DeptId) P on P.OrgId = isnull(C.CreatorDeptId, '00000000-0000-0000-0000-000000000000') or P.UserId = C.CreatorUserId group by C.ID) ";
            sql += "select C.ID, case when C.Validity = 1 then '正常' else '作废' end as 状态, case C.Direction when 1 then '入库' when 0 then '退库' else '出库' end as 类型, C.ReceiptCode as 单据号, ";
            sql += "C.ObjectName as [客户/供应商], C.Description as 备注, C.CreateTime as 出入库时间, U.Name as 经办人, A.ImageId, L.Permission from ABS_Delivery C join List L on L.ID = C.ID join SYS_User U on U.ID = C.CreatorUserId ";
            sql += string.Format("left join (select A.DeliveryId, A.ImageId from ABS_Delivery_Attachs A join ImageData D on D.ID = A.ImageId and D.ImageType = 1 and D.Expand = 'fpx') A on A.DeliveryId = C.ID where C.ObjectName like '%{0}%' order by C.CreateTime desc", str);
            var parm = new[]
            {
                new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier) {Value = mid},
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId}
            };

            return SqlHelper.SqlQuery(sql, parm);
        }

        /// <summary>
        /// 根据申请单号获取未履约数据
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="code">申请单号</param>
        /// <returns>DataTable 未履约数据</returns>
        public DataTable Get_GoodsPlan(Session us, object code)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = string.Format("select * from dbo.Get_GoodsPlan('{0}')", code);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取出入库物资列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>DataTable 收费项目列表</returns>
        public DataTable GetDeliveryItem(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = string.Format("select Summary as 摘要, ObjectName as 项目, Units as 单位, Price as 单价, Counts as 数量, Amount as 金额 from ABS_Delivery_Item where DeliveryId = '{0}'", cid);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取附件列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="did">结算记录ID</param>
        /// <returns>DataTable 附件列表</returns>
        public DataTable GetDeliveryAttach(Session us, Guid did)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select I.ID, case I.ImageType when 1 then '收据' when  2 then '发票' when 3 then '付款单' when 4 then '报销单' when 5 then '入库单' when 6 then '出库单' else '附件' end as 类型, I.Code as 编码, I.Name as 名称, I.Expand as 扩展名, ";
            sql += string.Format("M.Name as 密级, I.Pages as 页数, I.Size as 字节数 from ABS_Delivery_Attachs A join ImageData I on I.ID = A.ImageId left join MasterData M on M.ID = I.SecrecyDegree where DeliveryId = '{0}'", did);
            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取结算记录对象实体
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="cid">结算记录ID</param>
        /// <returns>ABS_Clearing 结算记录对象实体</returns>
        public ABS_Delivery GetDelivery(Session us, Guid cid)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.ABS_Delivery.SingleOrDefault(c => c.ID == cid);
            }
        }

        #endregion

        #region 新增

        /// <summary>
        /// 保存收款记录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">ABS_Clearing对象实体</param>
        /// <param name="idt">收款项目列表</param>
        /// <returns>object 收款记录ID</returns>
        public object AddDelivery(Session us, ABS_Delivery obj, DataTable idt)
        {
            if (!OnlineManage.Verification(us)) return null;

            var cmds = new List<SqlCommand> {InsertDelivery(obj)};
            cmds.AddRange(InsertDeliveryDetail(idt));
            return SqlHelper.SqlExecute(cmds, 0);
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 更新出入库单据号
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="sid">编码方案ID</param>
        /// <param name="bid">业务数据ID</param>
        /// <param name="mid">业务模块ID</param>
        /// <param name="str">附加字符串</param>
        /// <returns>bool 是否更新成功</returns>
        public object GetDeliveryCode(Session us, Guid sid, Guid bid, Guid mid, string str)
        {
            if (!OnlineManage.Verification(us)) return false;

            var sql = "exec Get_Code @SchemeId, @DeptId, @UserId, @BusinessId, @ModuleId, @Char, @Code output ";
            sql += "update ABS_Delivery set ReceiptCode = @Code, PrintTimes = 1 where ID = @BusinessId";
            SqlParameter[] parm = { new SqlParameter("@SchemeId", SqlDbType.UniqueIdentifier){ Value = sid },
                                    new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier){ Value = us.DeptId },
                                    new SqlParameter("@UserId", SqlDbType.UniqueIdentifier){ Value = us.UserId },
                                    new SqlParameter("@BusinessId", SqlDbType.UniqueIdentifier){ Value = bid },
                                    new SqlParameter("@ModuleId", SqlDbType.UniqueIdentifier){ Value = mid },
                                    new SqlParameter("@Char", str),
                                    new SqlParameter("@Code", SqlDbType.VarChar) };
            return SqlHelper.SqlScalar(sql, parm);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除/作废出入库单据
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="bid">业务数据ID</param>
        /// <returns>bool 是否更新成功</returns>
        public bool DelDelivery(Session us, Guid bid)
        {
            if (!OnlineManage.Verification(us)) return false;

            if (GetDelivery(us, bid).PrintTimes == 0)
            {
                var sql = string.Format("delete ABS_Delivery where ID = '{0}'", bid);
                return SqlHelper.SqlNonQuery(sql) > 0;
            }
            else
            {
                var sql = string.Format("update ABS_Delivery set Validity = 0 where ID = '{0}'", bid);
                return SqlHelper.SqlNonQuery(sql) > 0;
            }
        }

        #endregion

        #region 其它

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
            return SqlHelper.MakeCommand(sql, parm);
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
                } into parm
                select SqlHelper.MakeCommand(sql, parm)).ToList();
        }

        #endregion

    }
}
