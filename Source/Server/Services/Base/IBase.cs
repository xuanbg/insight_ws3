using System.Collections.Generic;
using System.ServiceModel;
using Insight.WS.Server.Common;

namespace Insight.WS.Service
{
    [ServiceContract]
    public partial interface IBase
    {

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <returns>Session List 在线用户列表</returns>
        [OperationContract]
        List<Session> GetOnlineUser(Session us);

    }
}
