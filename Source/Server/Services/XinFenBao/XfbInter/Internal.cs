using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.XFB;

namespace Insight.WS.Service.XinFenBao
{
    public class Internal : IInternal
    {

        private const string SecCode = "0A457C39B0A81CEFE3D9E30E99A00388";

        /// <summary>
        /// 信分宝会员注册
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="pw">密码Hash值</param>
        /// <param name="name">用户姓名</param>
        /// <param name="id">身份证号</param>
        /// <returns>boll 是否成功</returns>
        public bool Register(string code, string ln, string pw, string name, string id)
        {
            if (code != SecCode) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == ln);
                if (user != null) return false;
            }

            return CommonDAL.AddMember("iOS", name, ln, pw, id, null);
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="type">会员类型</param>
        /// <returns>boll 是否成功</returns>
        public bool SetMemberType(string code, string ln, int type)
        {
            if (code != SecCode) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.Single(u => u.LoginName == ln);
                user.Type = type;
                if (context.SaveChanges() == 0) return false;
            }

            var us = OnlineManage.Sessions.FirstOrDefault(s => s.LoginName == ln);
            if (us != null) us.Type = type;
            return true;
        }

        /// <summary>
        /// 设置用户登录密码
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>boll 是否成功</returns>
        public bool SetPassword(string code, string ln, string pw)
        {
            if (code != SecCode) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == ln);
                if (user == null || user.Password == pw) return true;

                user.Password = pw;
                if (context.SaveChanges() == 0) return false;
            }

            var us = OnlineManage.Sessions.FirstOrDefault(s => s.LoginName == ln);
            if (us != null) us.Signature = pw;
            return true;
        }

        /// <summary>
        /// 根据ID封禁/解封用户
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="validity">true:解封；false:封禁</param>
        /// <returns>bool 是否成功</returns>
        public bool SetUserStatus(string code, string ln, bool validity)
        {
            if (code != SecCode) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == ln);
                if (user == null || user.Validity == validity) return true;

                user.Validity = validity;
                if (context.SaveChanges() == 0) return false;
            }

            var us = OnlineManage.Sessions.FirstOrDefault(s => s.LoginName == ln);
            if (us != null) us.Validity = validity;
            return true;
        }

        /// <summary>
        /// 插入绑定银行卡
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="ln">用户登录名</param>
        /// <param name="name">持卡人姓名</param>
        /// <param name="type">卡类型</param>
        /// <param name="bank">发卡银行</param>
        /// <param name="number">卡号</param>
        /// <returns>bool 是否成功</returns>
        public bool AddBankCard(string code, string ln, string name, string type, string bank, string number)
        {
            if (code != SecCode) return false;

            SYS_User member;
            using (var context = new WSEntities())
            {
                member = context.SYS_User.Single(u => u.LoginName == ln);
            }

            var sql = "insert MDE_Member_Card (MemberId, Name, Type, BankName, Number) ";
            sql += "select @MemberId, @Name, @Type, @BankName, @Number";
            var parm = new[]
            {
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = member.ID},
                new SqlParameter("@Name", name),
                new SqlParameter("@Type", type),
                new SqlParameter("@BankName", bank),
                new SqlParameter("@Number", number),
            };

            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 设置账单状态
        /// </summary>
        /// <param name="code">安全码</param>
        /// <param name="id">账单ID</param>
        /// <param name="status">账单状态</param>
        /// <returns>bool 是否成功</returns>
        public bool SetBillStatus(string code, string id, int status)
        {
            if (code != SecCode) return false;

            Guid billId;
            Guid.TryParse(id, out billId);
            if (billId == Guid.Empty) return true;

            if (status != 2 && status != 5) return true;

            decimal ba;
            decimal sa;
            decimal la;
            string pay;
            string loginName;
            using (var context = new XFBEntities())
            {
                var bill = context.t_bill_stage.Single(b => b.bill_no == id);
                ba = (decimal) (bill.base_amount ?? 0);
                sa = (decimal) (bill.charge_amount ?? 0);
                la = (decimal) (bill.overdue_fine ?? 0);
                switch (bill.repay_channel)
                {
                    case 1:
                        pay ="AliPay";
                        break;
                    case 2:
                        pay = "WeiXinPay";
                        break;
                    case 3:
                        pay = "UnionPay";
                        break;
                    case 6:
                        pay = "Transfer";
                        break;
                    default:
                        pay = "OtherPay";
                        break;
                }

                var order = context.t_order_info.Single(o => o.id == bill.order_id);
                loginName = context.t_sys_user.Single(u => u.id == order.owner_userid).login_name;
            }

            SYS_User user;
            using (var context = new WSEntities())
            {
                user = context.SYS_User.Single(u => u.LoginName == loginName);
            }

            var cmds = new List<SqlCommand>();
            cmds.AddRange(ClearingDAL.BillClearing(user.ID, user.Name, ba, sa, la, pay, null, status == 2 ? 1 : -1));

            var obj = new ABS_Contract_FundPerform
            {
                PlanId = billId,
                Amount = ba + sa
            };
            cmds.AddRange(ContractDAL.FundPerform(new List<ABS_Contract_FundPerform> {obj}));

            return SqlHelper.SqlExecute(cmds);
        }

    }
}
