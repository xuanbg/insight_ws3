using System.Linq;
using System.ServiceModel;
using static Insight.WS.Log.Util;

namespace Insight.WS.Log
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LogManage : Interface
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="log">日志数据对象</param>
        public void WriteToLog(SYS_Logs log)
        {
            SetResponseParam();
            var rule = Rules.SingleOrDefault(r => r.Code == log.Code);
            if (rule?.ToDataBase ?? false)
            {
                WriteToDB(log);
            }
            else
            {
                WriteToFile(log);
            }
        }

    }
}
