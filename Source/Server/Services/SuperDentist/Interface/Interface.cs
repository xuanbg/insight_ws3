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
            var result = new JsonResult {Code = "500", Name = "UnknownError", Message = "未知错误" };
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature)
            {
                result.Code = "401";
                result.Name = "InvalidAuthenticationInfo";
                result.Message = "提供的身份验证信息不正确";
                return result;
            }

            using (var context = new WSEntities())
            {
                // 验证用户登录名是否已存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user != null)
                {
                    result.Code = "409";
                    result.Name = "AccountAlreadyExists";
                    result.Message = "用户已存在";
                    return result;
                }
            }

            if (!VerifyCode(obj.LoginName, smsCode, 1))
            {
                result.Code = "410";
                result.Name = "SMSCodeError";
                result.Message = "短信验证码错误";
                return result;
            }

            var cmds = new List<SqlCommand>
            {
                DataAccess.AddMasterData(new MasterData { Name = obj.UserName, Alias = obj.LoginName }),
                DataAccess.AddMember(new MDG_Member()),
                DataAccess.AddUser(new SYS_User {Name = obj.UserName, LoginName = obj.LoginName, Password = password, Type = -1})
            };
            if (!SqlExecute(cmds))
            {
                result.Code = "501";
                result.Name = "DataBaseError";
                result.Message = "写入数据失败";
                return result;
            }

            obj.Signature = Hash(obj.LoginName.ToUpper() + password);
            return GetJson(UserLogin(obj));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>JsonResult</returns>
        public JsonResult Login(Session us)
        {
            var session = UserLogin(us);
            return GetJson(session);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id">SessionID</param>
        /// <returns>JsonResult</returns>
        public JsonResult Logout(int id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var us = GetAuthorization<Session>();
            us.OnlineStatus = false;
            SetOnlineStatus(us);
            return result;
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
            if (DataAccess.UpdataPassword(us, password)) return result;

            result.Code = "407";
            result.Name = "DataNotUpdate";
            result.Message = "未更新任何数据";
            return result;
        }

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ResetPassword(string smsCode, string password)
        {
            var result = new JsonResult { Code = "500", Name = "UnknownError", Message = "未知错误" };
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature)
            {
                result.Code = "401";
                result.Name = "InvalidAuthenticationInfo";
                result.Message = "提供的身份验证信息不正确";
                return result;
            }

            // 验证用户是否存在
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.SingleOrDefault(u => u.LoginName == obj.LoginName);
                if (user == null)
                {
                    result.Code = "404";
                    result.Name = "AccountNotExists";
                    result.Message = "指定的资源不存在";
                    return result;
                }
                obj.UserId = user.ID;
            }

            if (!VerifyCode(obj.LoginName, smsCode, 2))
            {
                result.Code = "410";
                result.Name = "SMSCodeError";
                result.Message = "短信验证码错误";
                return result;
            }

            if (DataAccess.UpdataPassword(obj, password))
            {
                obj.Signature = Hash(obj.LoginName.ToUpper() + password);
                return GetJson(UserLogin(obj));
            }

            result.Code = "407";
            result.Name = "DataNotUpdate";
            result.Message = "未更新任何数据";
            return result;
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
            if (!Guid.TryParse(id, out uid)) return InvalidGuid();

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
            return !result.Successful ? result : GetVerifyCode(type, mobile);
        }

        #endregion

    }
}
