using System.Xml.Serialization;

namespace Insight.WS.Server.Common
{

    [XmlRoot(Namespace = "http://tempuri.org/")]
    public class CSubmitState
    {

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgID { get; set; }

        /// <summary>
        /// 发送状态
        /// </summary>
        public string MsgState { get; set; }

        /// <summary>
        /// 保留字段
        /// </summary>
        public string Reserve { get; set; }

    }
}
