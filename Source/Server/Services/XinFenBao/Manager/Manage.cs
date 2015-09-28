using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Service.XinFenBao
{

    public class Manager : IManager
    {

        #region 授信

        /// <summary>
        /// 获取审核日期列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 审核日期列表</returns>
        public DataTable GetCheckListDate(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select distinct convert(varchar(4),CreateTime,120) as ID, null as ParentId, 0 as Type, cast(datepart(year , CreateTime) as varchar) + '年' as Name from CheckList where VerifyUserId = '{us.UserId}' union ";
            sql += $"select distinct convert(varchar(7),CreateTime,120) as ID, convert(varchar(4),CreateTime,120) as ParentId, 1 as Type, cast(datepart(month , CreateTime) as varchar) + '月' as Name from CheckList where VerifyUserId = '{us.UserId}' union ";
            sql += $"select distinct convert(varchar(10),CreateTime,120) as ID, convert(varchar(7),CreateTime,120) as ParentId, 2 as Type, cast(datepart(day , CreateTime) as varchar) + '日' as Name from CheckList where VerifyUserId = '{us.UserId}' order by ID desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 按日期查询审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="date">日期</param>
        /// <returns>DataTable 审核列表</returns>
        public DataTable GetCheckListForDate(Session us, string date)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select * from CheckList where VerifyUserId = '{us.UserId}' and CreateTime >= '{date}' and CreateTime < dateadd(day, 1, '{date}') order by CreateTime desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 按手机号查询审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">手机号</param>
        /// <returns>DataTable 审核列表</returns>
        public DataTable GetCheckListForName(Session us, string name)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select * from CheckList where VerifyUserId = '{us.UserId}' and 手机号 like '{name}%' order by CreateTime desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 待审核列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 审核列表</returns>
        public DataTable GetAuditList(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = $"select * from CheckList where VerifyUserId = '{us.UserId}' and Status = 2 order by CreateTime desc";

            return SqlHelper.SqlQuery(sql);
        }

        #endregion

        #region 提现

        #endregion

        #region 订单

        #endregion

        #region 意见反馈

        /// <summary>
        /// 获取意见反馈日期列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>DataTable 意见反馈日期列表</returns>
        public DataTable GetFeedbackDate(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql = "select distinct convert(varchar(4),CreateTime,120) as ID, null as ParentId, 0 as Type, cast(datepart(year , CreateTime) as varchar) + '年' as Name from MDE_Member_Feedback union ";
            sql += "select distinct convert(varchar(7),CreateTime,120) as ID, convert(varchar(4),CreateTime,120) as ParentId, 1 as Type, cast(datepart(month , CreateTime) as varchar) + '月' as Name from MDE_Member_Feedback union ";
            sql += "select distinct convert(varchar(10),CreateTime,120) as ID, convert(varchar(7),CreateTime,120) as ParentId, 2 as Type, cast(datepart(day , CreateTime) as varchar) + '日' as Name from MDE_Member_Feedback order by ID desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 按日期查询意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="date">日期</param>
        /// <returns>DataTable 意见反馈列表</returns>
        public DataTable GetFeedBacksForDate(Session us, string date)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql ="select F.ID, M.Name as 客户姓名, M.Alias as 手机号, F.Complaint as 意见, case F.Status when 1 then '待回复' when 2 then '已回复' else '已归档' end as 状态 ";
            sql += $"from MDE_Member_Feedback F join MasterData M on M.ID = F.MemberId where F.CreateTime >= '{date}' and F.CreateTime < dateadd(day, 1, '{date}') order by F.CreateTime desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 按手机号查询意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="name">手机号</param>
        /// <returns>DataTable 意见反馈列表</returns>
        public DataTable GetFeedBacksForName(Session us, string name)
        {
            if (!OnlineManage.Verification(us)) return null;

            var sql ="select M.Name as 客户姓名, M.Alias as 手机号, F.Complaint as 意见, case F.Status when 1 then '待回复' when 2 then '已回复' else '已归档' end as 状态 ";
            sql += $"from MDE_Member_Feedback F join MasterData M on M.ID = F.MemberId where M.Alias like '{name}%' order by F.CreateTime desc";

            return SqlHelper.SqlQuery(sql);
        }

        /// <summary>
        /// 根据ID获取用户意见对象
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">用户意见ID</param>
        /// <returns>MDE_Member_Feedback 用户意见对象</returns>
        public MDE_Member_Feedback GetFeedback(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDE_Member_Feedback.Single(f => f.ID == id);
            }
        }

        /// <summary>
        /// 保存用户意见
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户意见对象</param>
        /// <returns>bool 是否成功</returns>
        public bool SaveReply(Session us, MDE_Member_Feedback obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var feed = context.MDE_Member_Feedback.Single(f => f.ID == obj.ID);
                feed.Reply = obj.Reply;
                feed.Status = 2;
                feed.AcceptDeptId = us.DeptId;
                feed.AcceptUserId = us.UserId;
                feed.AcceptTime = DateTime.Now;
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 用户意见归档
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">用户意见对象</param>
        /// <returns>bool 是否成功</returns>
        public bool Pigeonhole(Session us, MDE_Member_Feedback obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var feed = context.MDE_Member_Feedback.Single(f => f.ID == obj.ID);
                feed.Description = obj.Description;
                feed.Status = 4;
                return context.SaveChanges() > 0;
            }
        }

        #endregion

        #region 分期方案

        /// <summary>
        /// 获取分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>分期方案列表</returns>
        public List<BIZ_StagePlan> GetStagePlans(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_StagePlan.Where(p => p.Validity).ToList();
            }
        }

        /// <summary>
        /// 增加分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">分期方案对象</param>
        /// <returns>bool 是否成功</returns>
        public bool AddStagePlan(Session us, BIZ_StagePlan obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            var cmds = new List<SqlCommand>();

            var sql = $"update BIZ_StagePlan set InvalidDate = '{obj.EffectiveDate.AddDays(-1)}' where UserType = {obj.UserType} and StageNum = {obj.StageNum} and InvalidDate is null";
            cmds.Add(SqlHelper.MakeCommand(sql));

            sql = "insert BIZ_StagePlan (UserType, StageNum, Rate, EffectiveDate, InvalidDate, Description, CreatorDeptId, CreatorUserId) ";
            sql += "select @UserType, @StageNum, @Rate, @EffectiveDate, @InvalidDate, @Description, @CreatorDeptId, @CreatorUserId";
            var parm = new[]
            {
                new SqlParameter("@UserType", obj.UserType),
                new SqlParameter("@StageNum", obj.StageNum),
                new SqlParameter("@Rate", obj.Rate),
                new SqlParameter("@EffectiveDate", obj.EffectiveDate),
                new SqlParameter("@InvalidDate", obj.InvalidDate),
                new SqlParameter("@Description", obj.Description),
                new SqlParameter("@CreatorDeptId", SqlDbType.UniqueIdentifier) {Value = us.DeptId},
                new SqlParameter("@CreatorUserId", SqlDbType.UniqueIdentifier) {Value = us.UserId}
            };
            cmds.Add(SqlHelper.MakeCommand(sql, parm));

            return SqlHelper.SqlExecute(cmds);
        }

        /// <summary>
        /// 根据ID设置为默认分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期方案ID</param>
        /// <returns>bool 是否成功</returns>
        public bool SetDefault(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            var date = DateTime.Now;
            using (var context = new WSEntities())
            {
                var plan = context.BIZ_StagePlan.Single(p => p.ID == id);
                if (plan.EffectiveDate > date)
                {
                    context.BIZ_StagePlan.Where(p => p.EffectiveDate > date && p.UserType == plan.UserType).ToList().ForEach(p => p.Default = p.ID == id);
                }
                else
                {
                    context.BIZ_StagePlan.Where(p => p.EffectiveDate <= date && p.UserType == plan.UserType).ToList().ForEach(p => p.Default = p.ID == id);
                }

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除分期方案
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">分期方案ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DeletePlan(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var plan = context.BIZ_StagePlan.Single(p => p.ID == id);
                var edate = plan.EffectiveDate.AddDays(-1);
                var previous = context.BIZ_StagePlan.FirstOrDefault(p => p.UserType == plan.UserType && p.StageNum == plan.StageNum && p.InvalidDate == edate);

                DateTime idate;
                BIZ_StagePlan next = null;
                if (plan.InvalidDate.HasValue)
                {
                    idate = plan.InvalidDate.Value.AddDays(1);
                    next = context.BIZ_StagePlan.FirstOrDefault(p => p.UserType == plan.UserType && p.StageNum == plan.StageNum && p.EffectiveDate == idate);
                }

                if (next != null)
                {
                    next.EffectiveDate = plan.EffectiveDate;
                }
                else if (previous != null)
                {
                    previous.InvalidDate = plan.InvalidDate;
                }

                context.SaveChanges();

                var sql = $"delete BIZ_StagePlan where ID = '{plan.ID}'";
                if (SqlHelper.SqlNonQuery(sql) > 0) return true;

                sql = $"update BIZ_StagePlan set Validity = 0 where ID = '{plan.ID}'";
                return SqlHelper.SqlNonQuery(sql) > 0;
            }
        }

        #endregion

        #region 轮播

        /// <summary>
        /// 获取广告商品列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>广告商品列表</returns>
        public List<BIZ_Advertiser> GetAdvertisers(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.BIZ_Advertiser.ToList();
            }
        }

        /// <summary>
        /// 增加轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">轮播广告对象</param>
        /// <param name="img">轮播图</param>
        /// <returns>bool 是否成功</returns>
        public bool AddAdvertiser(Session us, BIZ_Advertiser obj, byte[] img)
        {
            if (!OnlineManage.Verification(us)) return false;

            int? pid = null;
            if (obj.TargetURL == null && obj.ProductCode != null)
            {
                using (var context = new YSEntities())
                {
                    var product = context.Products.FirstOrDefault(p => p.Code == obj.ProductCode);
                    if (product == null) return false;

                    pid = product.ID;
                }
            }

            var path = Util.SaveImage(img, "Advertiser", obj.ImageURL);
            var sql = "insert BIZ_Advertiser (Sort, Name, TargetURL, ImageURL, ProductId, ProductCode) ";
            sql += "select @Sort, @Name, @TargetURL, @ImageURL, @ProductId, @ProductCode";
            var parm = new[]
            {
                new SqlParameter("@Sort", obj.Sort),
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@TargetURL", obj.TargetURL),
                new SqlParameter("@ImageURL", path),
                new SqlParameter("@ProductId", pid),
                new SqlParameter("@ProductCode", obj.ProductCode),
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 编辑轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">轮播广告对象</param>
        /// <param name="img">轮播图</param>
        /// <returns>bool 是否成功</returns>
        public bool EditAdvertiser(Session us, BIZ_Advertiser obj, byte[] img)
        {
            if (!OnlineManage.Verification(us)) return false;

            int? pid = null;
            if (obj.TargetURL == null && obj.ProductId != null)
            {
                using (var context = new YSEntities())
                {
                    var product = context.Products.FirstOrDefault(p => p.Code == obj.ProductCode);
                    if (product == null) return false;

                    pid = product.ID;
                }
            }

            string path = null;
            if (img != null)
            {
                path = Util.SaveImage(img, "Advertiser", obj.ImageURL);
            }
            using (var context = new WSEntities())
            {
                var adv = context.BIZ_Advertiser.Single(a => a.ID == obj.ID);
                adv.Sort = obj.Sort;
                adv.Name = obj.Name;
                adv.TargetURL = obj.TargetURL;
                adv.ImageURL = path ?? obj.ImageURL;
                adv.ProductId = pid;
                adv.ProductCode = obj.ProductCode;

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据ID删除轮播图
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="id">轮播图ID</param>
        /// <returns>bool 是否成功</returns>
        public bool DelAdvertiser(Session us, Guid id)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                var adv = context.BIZ_Advertiser.Single(a => a.ID == id);
                context.BIZ_Advertiser.Remove(adv);

                return context.SaveChanges() > 0;
            }
        }

        #endregion

    }
}
