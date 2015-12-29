using System;

namespace Insight.WS.Server.Common
{
    public class GuidParse
    {

        /// <summary>
        /// 转换结果
        /// </summary>
        public bool Successful = true;

        /// <summary>
        /// 转换成功后的结果
        /// </summary>
        public Guid? Relust;

        /// <summary>
        /// 将一个字符串转换为可为空的GUID
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        public GuidParse(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            Guid guid;
            Successful = Guid.TryParse(str, out guid);
            if (Successful) Relust = guid;
        }

    }
}
