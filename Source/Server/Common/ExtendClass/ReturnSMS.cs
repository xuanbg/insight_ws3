namespace Insight.WS.Server.Common
{
    public class returnsms
    {

        /// <summary>
        /// 状态
        /// </summary>
        public string returnstatus { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 剩余条数
        /// </summary>
        public string remainpoint { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public string taskID { get; set; }

        /// <summary>
        /// 发送成功条数
        /// </summary>
        public string successCounts { get; set; }

    }

}
