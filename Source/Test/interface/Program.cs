using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;

namespace Insight.WS.Test.Interface
{
    static class Program
    {
        private const string BassAddress = "http://localhost:6280/Interface/";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var us = Login();
            GetUsers(us);
        }

        private static void GetUsers(Session us)
        {
            var url = BassAddress + "GetUsers";
            var data = Util.Serialize(us);
            var result = Util.HttpPost(url, data);
            var obj = Util.Deserialize<JsonResult>(result);
            if (!obj.Successful)
            {
                
            }
            else
            {
                var user = Util.Deserialize<List<SYS_User>>(obj.Data);
            }
        }


        private static Session Login()
        {
            var url = BassAddress + "Login";
            var us = new Session
            {
                LoginName = "admin",
                Signature = Util.GetHash("ADMIN" + Util.GetHash("1")),
                Version = 10000
            };
            var data = Util.Serialize(us);
            var result = Util.HttpPost(url, data);
            var obj = Util.Deserialize<JsonResult>(result);

            return !obj.Successful ? null : Util.Deserialize<Session>(obj.Data);
        }

    }

    /// <summary>
    /// Json接口返回值
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }

    }
}
