using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

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

            Util.Session = Login();
            Logout();
        }


        private static void Logout()
        {
            var url = BassAddress + "user/logout";
            var data = Util.Serialize(Util.Session.ID);
            var result = Util.HttpPost(url, data);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>Session</returns>
        private static Session Login()
        {
            var mobile = "admin";
            var password = "1";
            var url = BassAddress + "user/login";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Util.GetHash(mobile.ToUpper() + Util.GetHash(password)),
                Version = 10000,
                MachineId = Util.GetHash("MachineId")
            };
            var data = Util.Serialize(us);
            var result = Util.HttpPost(url, data, null);
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
