using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Service.SuperDentist
{

    [ServiceContract]
    public interface IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="us">用户会话</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/login", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult Login(Session us);

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id">SessionID</param>
        /// <returns>JsonResult</returns>
        [WebInvoke(Method = "POST", UriTemplate = "user/logout", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult Logout(int id);


    }

}
