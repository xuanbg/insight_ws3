using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Interface : IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>JsonResult</returns>
        public JsonResult Login(Session us)
        {
            var session = UserLogin(us);
            return Util.GetJson(session);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id">SessionID</param>
        /// <returns>JsonResult</returns>
        public JsonResult Logout(int id)
        {
            var result = Verify();
            if (result == null || !result.Successful) return result;

            SetOnlineStatus(id, false);
            return result;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="smsCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult Register(string smsCode, string password)
        {
            var result = new JsonResult {Code = "500", Name = "UnknownError", Message = "未知错误" };
            var obj = GetAuthorization<Session>();
            if (!CodeVerify(obj.LoginName, smsCode, 1))
            {
                result.Code = "300";
                result.Name = "";
                result.Message = "短信验证码错误";
                return result;
            }

            using (var context = new WSEntities())
            {
                // 验证用户登录名是否已存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user != null)
                {
                    result.Code = "300";
                    result.Name = "";
                    result.Message = "用户已存在";
                    return result;
                }
            }

            if (DataAccess.AddMember("WeiXin", obj.UserName, obj.LoginName, password, null, obj.OpenId))
            {
                result.Successful = true;
                result.Code = "300";
                result.Name = "";
                result.Message = "短信验证码错误";
                return result;
            }
            return result;
        }
    }
}
