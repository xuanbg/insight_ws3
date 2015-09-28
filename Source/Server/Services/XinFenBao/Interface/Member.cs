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
    public partial class Interface
    {

        /// <summary>
        /// 获取用户用户会话
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户用户会话</returns>
        public Session GetSession(Guid id, string pw)
        {
            return OnlineManage.Sessions.Find(s => s.UserId == id && s.Signature == pw);
        }

        /// <summary>
        /// 获取用户授信额度
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>decimal 授信额度</returns>
        public decimal GetLoans(Session us)
        {
            if (!OnlineManage.Verification(us)) return -1;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var member = context.t_member_info.Single(m => m.user_id == user.id);
                return (decimal) member.credit_sum;
            }
        }

        /// <summary>
        /// 获取用户可用额度
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>decimal 可用额度</returns>
        public decimal GetAvailable(Session us)
        {
            if (!OnlineManage.Verification(us)) return -1;

            return CommonDAL.GetAvailable(us);
        }

        /// <summary>
        /// 会员认证状态
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>string 会员认证状态</returns>
        public string GetMemberStatus(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                return context.t_sys_user.Single(u => u.login_name == us.LoginName).verify_state;
            }
        }

        /// <summary>
        /// 用户是否已设置支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否已设置支付密码</returns>
        public bool HasPayPassword(Session us)
        {
            if (!OnlineManage.Verification(us)) return false;

            using (var context = new WSEntities())
            {
                return context.SYS_User.Single(u => u.ID == us.UserId).PayPassword != null;
            }
        }

        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>bool 是否设置成功</returns>
        public string GetPortrait(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var member = context.t_member_info.Single(m => m.user_id == user.id);
                return member.head_portrait == null ? null : Util.GetAppSetting("ImageSite") + member.head_portrait;
            }
        }

        /// <summary>
        /// 获取用户绑定银行卡列表
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>绑定银行卡列表</returns>
        public List<MDE_Member_Card> GetCards(Session us)
        {
            if (!OnlineManage.Verification(us)) return null;

            using (var context = new WSEntities())
            {
                return context.MDE_Member_Card.Where(a => a.MemberId == us.UserId).ToList();
            }
        }

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="obj">银行卡对象实体</param>
        /// <returns>bool 是否成功</returns>
        public bool AddCard(Session us, MDE_Member_Card obj)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "insert MDE_Member_Card (MemberId, Name, Type, BankName, Number) select @MemberId, @Name, @Type, @BankName, @Number";
            var parm = new[]
            {
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Name", obj.Name),
                new SqlParameter("@Type", obj.Type),
                new SqlParameter("@BankName", obj.BankName),
                new SqlParameter("@Number", obj.Number)
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 提交意见反馈
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="msg">反馈意见</param>
        /// <returns>bool 是否成功</returns>
        public bool Feedback(Session us, string msg)
        {
            if (!OnlineManage.Verification(us)) return false;

            const string sql = "insert MDE_Member_Feedback (MemberId, Complaint) select @MemberId, @Complaint";
            var parm = new[]
            {
                new SqlParameter("@MemberId", SqlDbType.UniqueIdentifier) {Value = us.UserId},
                new SqlParameter("@Complaint", msg)
            };
            return SqlHelper.SqlNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>用户会话</returns>
        public Session UserLogin(Session obj)
        {
            return CommonDAL.UserLogin(obj);
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="recom">推荐码</param>
        /// <param name="id">身份证号</param>
        /// <returns>用户会话</returns>
        public Session Register(Session obj, string code, string recom, string id)
        {
            if (obj == null) return null;

            if (!CommonDAL.CodeVerify(obj.LoginName, code))
            {
                obj.LoginStatus = LoginResult.Failure;
                return obj;
            }

            using (var context = new XFBEntities())
            {
                // 验证登录名是否存在
                var user = context.t_sys_user.FirstOrDefault(u => u.login_name == obj.LoginName);
                if (user != null)
                {
                    obj.LoginStatus = LoginResult.Multiple;
                    return obj;
                }

                // 验证推荐人是否存在
                if (!string.IsNullOrEmpty(recom))
                {
                    var recomUser = context.t_sys_user.FirstOrDefault(u => u.login_name == recom);
                    if (recomUser == null)
                    {
                        obj.LoginStatus = LoginResult.NotExist;
                        return obj;
                    }
                }
            }

            using (var context = new WSEntities())
            {
                // 验证用户登录名是否已存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user != null)
                {
                    obj.LoginStatus = LoginResult.Multiple;
                    return obj;
                }

                // 验证身份证号是否被使用
                var member = context.MasterData.FirstOrDefault(m => m.Code == id);
                if (member != null)
                {
                    obj.LoginStatus = LoginResult.Online;
                    return obj;
                }
            }

            if (!CommonDAL.AddMember("WeiXin", obj.UserName, obj.LoginName, obj.Signature, id, obj.OpenId))
            {
                obj.LoginStatus = LoginResult.Failure;
                return obj;
            }

            // 插入信分宝用户
            using (var context = new XFBEntities())
            {
                var recomUser = context.t_sys_user.FirstOrDefault(u => u.login_name == recom);
                if (recomUser != null) recomUser.recom_num += 1;

                var seq = context.t_mysql_seq.Single(s => s.seq_name == "t_sys_user");
                seq.current_value += 1;
                context.SaveChanges();

                var user = new t_sys_user
                {
                    id = seq.current_value,
                    login_name = obj.LoginName,
                    real_name = obj.UserName,
                    pass_word = obj.Signature,
                    status = 0,
                    recom_code = recom,
                    recom_num = 0,
                    create_time = DateTime.Now,
                    type = obj.Type == -9 ? "A3" : (obj.Type == -5 ? "A1" : "A2"),
                    has_verify = "A1"
                };
                context.t_sys_user.Add(user);

                var member = new t_member_info
                {
                    user_id = seq.current_value,
                    credit_sum = 0,
                    use_sum = 0,
                    card_number = id
                };
                context.t_member_info.Add(member);

                if (context.SaveChanges() == 0)
                {
                    DeleteMember(obj.LoginName);
                    obj.LoginStatus = LoginResult.Failure;
                    return obj;
                }
            }

            return CommonDAL.UserLogin(obj);
        }

        /// <summary>
        /// 修改指定用户的登录密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="pw">新密码Hash值</param>
        /// <returns>bool 是否修改成功</returns>
        public bool UpdatePassword(Session us, string pw)
        {
            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                user.pass_word = pw;
                context.SaveChanges();
            }

            return CommonDAL.UpdataPassword(us, pw);
        }

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="id">身份证号</param>
        /// <returns>用户会话</returns>
        public Session ResetPassword(Session obj, string code, string id)
        {
            if (obj == null) return null;

            // 验证短信验证码是否正确
            if (!CommonDAL.CodeVerify(obj.LoginName, code))
            {
                obj.LoginStatus = LoginResult.Failure;
                return obj;
            }

            using (var context = new WSEntities())
            {
                // 验证用户是否存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user == null)
                {
                    obj.LoginStatus = LoginResult.NotExist;
                    return obj;
                }

                // 验证用户身份证号是否正确
                var member = context.MasterData.Single(m => m.ID == user.ID);
                if (member.Code != id)
                {
                    obj.LoginStatus = LoginResult.Online;
                    return obj;
                }
            }

            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == obj.LoginName);
                user.pass_word = obj.Signature;
                context.SaveChanges();
            }

            var sql = $"update SYS_User set Password = '{obj.Signature}' where LoginName = '{obj.LoginName}'";
            if (SqlHelper.SqlNonQuery(sql) <= 0) return null;

            var us = OnlineManage.Sessions.Find(s => s.LoginName == obj.LoginName);
            if (us != null)
            {
                us.SessionId = Guid.Empty;
                us.Signature = obj.Signature;
            }

            return CommonDAL.UserLogin(obj);
        }

        /// <summary>
        /// 重置支付密码
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="code">验证码</param>
        /// <param name="id">身份证号</param>
        /// <param name="pw">新支付密码</param>
        /// <returns>bool 是否重置成功</returns>
        public bool ResetPayPassword(Session us, string code, string id, string pw)
        {
            if (!OnlineManage.Verification(us)) return false;

            if (!CommonDAL.CodeVerify(us.LoginName, code)) return false;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.Single(u => u.ID == us.UserId);
                var member = context.MasterData.Single(m => m.ID == user.ID);
                if (member.Code != id) return false;

                user.PayPassword = pw;
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 设置用户头像
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <param name="pic">头像图片</param>
        /// <returns>bool 是否设置成功</returns>
        public string SetPortrait(Session us, byte[] pic)
        {
            if (!OnlineManage.Verification(us)) return null;

            var path = Util.SaveImage(pic, us.LoginName);
            using (var context = new XFBEntities())
            {
                var user = context.t_sys_user.Single(u => u.login_name == us.LoginName);
                var member = context.t_member_info.Single(m => m.user_id == user.id);
                member.head_portrait = path;
                context.SaveChanges();
                return path;
            }
        }

    }
}
