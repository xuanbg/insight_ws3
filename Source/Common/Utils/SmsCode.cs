using Insight.Utils.Client;
using Insight.Utils.Entity;
using Insight.Utils.Server;

namespace Insight.WS.Server.Common.Utils
{
    public class SmsCode
    {
        /// <summary>
        /// 生成注册用的验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public static Result GetRegisterCode(string mobile)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            if (!verify.Result.Successful) return verify.Result;

            var result = GetCode(verify.AccessToken, mobile, 1, 30);
            if (!result.Successful) return result;

            var code = result.Data;
            var message = $"您的验证码是：{code}，此验证码仅用于注册，请在30分钟内使用！";

            // 发送短信


            result.Success(code);
            return result;
        }

        /// <summary>
        /// 生成重置登录密码用的验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public static Result GetResetPasswordCode(string mobile)
        {
            var verify = new Verify(Parameters.VerifyUrl);
            if (!verify.Result.Successful) return verify.Result;

            var result = GetCode(verify.AccessToken, mobile, 1, 5);
            if (!result.Successful) return result;

            var code = result.Data;
            var message = $"您的验证码是：{code}，此验证码仅用于重置登录密码，请在5分钟内使用！";

            // 发送短信

            result.Success(code);
            return result;
        }

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="mobile">手机号</param>
        /// <param name="type">类型</param>
        /// <param name="time">失效时间</param>
        /// <returns>JsonResult</returns>
        private static Result GetCode(string auth, string mobile, int type, int time)
        {
            var url = $"{Parameters.BaseServer}/smscode?mobile={mobile}&type={type}&time={time}";
            return new HttpClient(url).Request(auth);
        }

    }
}
