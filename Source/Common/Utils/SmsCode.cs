using Insight.Utils.Common;
using Insight.Utils.Entity;

namespace Insight.WS.Server.Common.Utils
{
    public class SmsCode
    {
        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="mobile">手机号</param>
        /// <param name="type">类型</param>
        /// <param name="time">失效时间</param>
        /// <returns>JsonResult</returns>
        private static Result<object> GetCode(string auth, string mobile, int type, int time)
        {
            var url = $"{Params.BaseServer}/smscode?mobile={mobile}&type={type}&time={time}";
            var request = new HttpRequest(auth);
            return request.Send(url) ? Util.Deserialize<Result<object>>(request.Data) : new Result<object>().BadRequest(request.Message);
        }
    }
}
