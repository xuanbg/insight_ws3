using System.ServiceModel;
using System.ServiceModel.Web;

namespace Insight.WS.Log
{
    [ServiceContract]
    interface Interface
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="log">日志数据对象</param>
        [WebInvoke(Method = "PUT", UriTemplate = "logs", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void WriteToLog(SYS_Logs log);


    }
}
