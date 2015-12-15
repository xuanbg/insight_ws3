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
        /// <returns>Session 用户会话</returns>
        [WebInvoke(UriTemplate = "Login", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult Login(Session us);

        [WebInvoke(UriTemplate = "GetUsers", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetUsers(Session us);

    }

}
