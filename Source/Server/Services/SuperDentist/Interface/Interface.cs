using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.General;

namespace Insight.WS.Service.SuperDentist
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
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

        public JsonResult Logout(int id)
        {
            var result = Verify();
            if (result == null || !result.Successful) return result;

            SetOnlineStatus(id, false);
            return result;
        }

        public JsonResult GetUsers()
        {
            var result = Verify();
            if (result == null || !result.Successful) return result;

            using (var context = new WSEntities())
            {
                var user = context.SYS_User.ToList();
                return Util.GetJson(user);
            }
        }

    }
}
