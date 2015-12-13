using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.SuperDentist
{

    [ServiceContract]
    public interface IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        [WebInvoke(UriTemplate = "/Login", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Session Login(Session obj);

        [WebGet(UriTemplate = "getusers", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        JsonResult GetUsers();

    }

}
