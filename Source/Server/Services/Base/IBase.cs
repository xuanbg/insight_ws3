using System;
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

        /// <summary>
        /// 删除在线用户
        /// </summary>
        /// <param name="us">用户会话对象实体</param>
        /// <param name="sid">会话ID</param>
        /// <returns>bool 是否删除成功</returns>
        [OperationContract]
        bool DelOnlineUser(Session us, Guid sid);

    }
}
