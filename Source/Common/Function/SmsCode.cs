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
            var result = new JsonResult();
            var code = General.GetCode(1, mobile);
            if (code == null) return result.TimeTooShort();

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
            var result = new JsonResult();
            var code = General.GetCode(2, mobile);
            if (code == null) return result.TimeTooShort();

            var message = $"您的验证码是：{code}，此验证码仅用于重置登录密码，请在5分钟内使用！";

            // 发送短信


            return result.Success(code);
        }

    }
}
