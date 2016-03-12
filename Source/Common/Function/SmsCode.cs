using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Server.Common
{
    public class SmsCode
    {
        /// <summary>
        /// 生成注册用的验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public static JsonResult GetRegisterCode(string mobile)
        {
            var result = GetCode(mobile, 1, 30);
            if (!result.Successful) return result;

            var code = result.Data;
            var message = $"您的验证码是：{code}，此验证码仅用于注册，请在30分钟内使用！";

            // 发送短信


            return result.Success(code);
        }

        /// <summary>
        /// 生成重置登录密码用的验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public static JsonResult GetResetPasswordCode(string mobile)
        {
            var result = GetCode(mobile, 1, 5);
            if (!result.Successful) return result;

            var code = result.Data;
            var message = $"您的验证码是：{code}，此验证码仅用于重置登录密码，请在5分钟内使用！";

            // 发送短信


            return result.Success(code);
        }

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="type">类型</param>
        /// <param name="time">失效时间</param>
        /// <returns>JsonResult</returns>
        private static JsonResult GetCode(string mobile, int type, int time)
        {
            var url = BaseServer + $"smscode?mobile={mobile}&type={type}&time={time}";
            var auth = Base64(Hash(mobile + Secret));
            return General.HttpRequest(url, "GET", auth);
        }

    }
}
