using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using Qiniu.RS;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Interface : IInterface
    {

        #region 静态字段

        private static readonly string AccessKey = GetAppSetting("AccessKey");
        private static readonly string SecretKey = GetAppSetting("SecretKey");
        private static readonly string BucketName = GetAppSetting("Bucket");

        #endregion

        #region user

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult Register(string smsCode, string password)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature) return result.InvalidAuth();

            using (var context = new WSEntities())
            {
                // 验证用户登录名是否已存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user != null) return result.AccountExists();
            }

            if (!VerifyCode(obj.LoginName, smsCode, 1)) return result.SMSCodeError();

            var cmds = new List<SqlCommand>
            {
                DataAccess.AddMasterData(new MasterData { Name = obj.UserName, Alias = obj.LoginName }),
                DataAccess.AddMember(new MDG_Member()),
                DataAccess.AddUser(new SYS_User {Name = obj.UserName, LoginName = obj.LoginName, Password = password, Type = -1})
            };
            if (!SqlExecute(cmds)) return result.DataBaseError();

            obj.Signature = Hash(obj.LoginName.ToUpper() + password);
            return GetJson(UserLogin(obj));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>JsonResult</returns>
        public JsonResult Login(Session session)
        {
            var us = UserLogin(session);
            return GetJson(us);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult Logout()
        {
            var result = Verify();
            if (!result.Successful) return result;

            var us = GetAuthorization<Session>();
            return SetUserOffline(us, us.LoginName) ? result : result.NotFound();
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="password">新登录密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ChangePassword(string password)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var us = GetAuthorization<Session>();
            return UpdateSignature(us, us.UserId, password) ? result : result.NotFound();
        }

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ResetPassword(string smsCode, string password)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature) return result.InvalidAuth();

            // 验证用户是否存在
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.SingleOrDefault(u => u.LoginName == obj.LoginName);
                if (user == null) return result.NotFound();

                obj.UserId = user.ID;
                obj.Signature = Hash(user.LoginName.ToUpper() + user.Password);
            }

            if (!VerifyCode(obj.LoginName, smsCode, 2)) return result.SMSCodeError();

            if (!UpdateSignature(obj, obj.UserId, password)) return result.DataBaseError();

            obj.Signature = Hash(obj.LoginName.ToUpper() + password);
            return GetJson(UserLogin(obj));
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMemberInfo(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid uid;
            if (!Guid.TryParse(id, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var member = context.MemberInfo.SingleOrDefault(m => m.ID == uid);
                return GetJson(member);
            }
        }

        #endregion

        #region setting

        /// <summary>
        /// 获取七牛云文件上传Token
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetQiniuUploadToken()
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            Qiniu.Conf.Config.ACCESS_KEY = AccessKey;
            Qiniu.Conf.Config.SECRET_KEY = SecretKey;
            var policy = new PutPolicy(BucketName);
            var token = policy.Token();
            result.Data = Serialize(token);
            return result;
        }

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="id">图形验证码ID</param>
        /// <param name="type">短信验证码类型</param>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSmsVerifyCode(string id, int type, string mobile)
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            switch (type)
            {
                case 1:
                    return SmsCode.GetRegisterCode(mobile);

                case 2:
                    return SmsCode.GetResetPasswordCode(mobile);

                default:
                    return result.UnknownSmsType();
            }
        }

        #endregion

    }
}
