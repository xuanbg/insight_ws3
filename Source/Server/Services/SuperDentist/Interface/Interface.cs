using System.Linq;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Interface : IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        public Session Login(Session obj)
        {
            return General.UserLogin(obj);
        }


        public JsonResult GetUsers()
        {
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.ToList();
                return Util.GetJson(user);
            }
        }
    }
}
