using System.Linq;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Interface : IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>Session 用户会话</returns>
        public JsonResult Login(Session us)
        {
            var session = UserLogin(us);
            return Util.GetJson(session);
        }


        public JsonResult GetUsers(Session us)
        {
            var result = Verify(us);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.ToList();
                return Util.GetJson(user);
            }
        }
    }
}
