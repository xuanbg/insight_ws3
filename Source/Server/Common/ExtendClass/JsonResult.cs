using System.Runtime.Serialization;

namespace Insight.WS.Server.Common
{
    /// <summary>
    /// Json接口返回值
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        [DataMember]
        public bool Successful { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 错误名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [DataMember]
        public string Data { get; set; }

    }
}
