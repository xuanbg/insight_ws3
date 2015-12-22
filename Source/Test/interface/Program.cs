using System;
using System.Collections.Generic;
using System.Text;
using static Insight.WS.Test.Interface.Util;

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
            Register();
            Util.Session = Login();
            Logout();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        private static void Register()
        {
            var url = BassAddress + "user/signup";
            var session = new Session
            {
                LoginName = "18600740257",
                UserName = "宣炳刚",
                Signature = Hash("18600740257" + "123456" + Hash("111111")),
                Version = 10000,
                MachineId = Hash("MachineId")
            };
            var json = Serialize(session);
            var buff = Encoding.UTF8.GetBytes(json);
            var author = Convert.ToBase64String(buff);
            var dict = new Dictionary<string, string> {{"smsCode", "123456"}, {"password", Hash("111111")}};
            var data = Serialize(dict);
            var result = HttpRequest(url, "PUT", author, data);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        private static Session Login()
        {
            var mobile = "admin";
            var password = "1";
            var url = BassAddress + "user/signin";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + Hash(password)),
                Version = 10000,
                MachineId = Hash("MachineId")
            };
            var data = Serialize(us);
            var result = HttpRequest(url, "POST", null, data);
            return !result.Successful ? null : Deserialize<Session>(result.Data);
        }

        /// <summary>
        /// 注销
        /// </summary>
        private static void Logout()
        {
            var url = BassAddress + "user/signout";
            var data = Serialize(Util.Session.ID);
            var result = HttpRequest(url, "POST", data);
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
