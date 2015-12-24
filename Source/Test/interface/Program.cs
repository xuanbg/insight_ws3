using System;
using System.Collections.Generic;
using static Insight.WS.Test.Interface.Util;

namespace Insight.WS.Test.Interface
{
    static class Program
    {
        private const string BassAddress = "http://localhost:6280/Interface/";
        //private const string BassAddress = "http://120.27.142.125:6280/Interface/";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mobile = "18600740251";
            //Register(GetSmsVerifyCode("1", mobile), mobile);
            //GetToken();
            //ResetPassword(GetSmsVerifyCode("2", mobile), mobile, "123456");
            UserSession = Login(mobile, "111111");
            //ChangePassword("111111");
            GetMemberInfo();
            Logout();
        }

        private static void GetMemberInfo()
        {
            var url = BassAddress + "user/getmemberinfo";
            var id = UserSession.UserId;
            var data = $"id={id}";
            var author = Base64(UserSession);
            var result = HttpRequest(url, "GET", author, data);
            if (result.Successful)
            {
                Console.Write(result.Data);
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

        private static void ChangePassword(string password)
        {
            var url = BassAddress + "user/change";
            var author = Base64(UserSession);
            var data = Serialize(Hash(password));
            var result = HttpRequest(url, "POST", author, data);
            if (result.Successful)
            {
                UserSession.Signature = Hash(UserSession.LoginName.ToUpper() + Hash(password));
                Console.Write($"用户 {UserSession.LoginName} 密码已经修改为{password}");
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

        private static Session ResetPassword(string code, string mobile, string password)
        {
            var url = BassAddress + "user/reset";
            var session = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + code + Hash(password)),
                Version = 10000,
                ClientType = 2,
                MachineId = Hash("MachineId")
            };
            var author = Base64(session);
            var dict = new Dictionary<string, string> { { "smsCode", code }, { "password", Hash(password) } };
            var data = Serialize(dict);
            var result = HttpRequest(url, "POST", author, data);
            if (result.Successful)
            {
                session = Deserialize<Session>(result.Data);
                Console.Write($"用户 {mobile} 密码已经修改为{password}");
                Console.ReadLine();
                return session;
            }

            Console.Write(result.Message);
            Console.ReadLine();
            return null;
        }

        private static string GetSmsVerifyCode(string type, string mobile)
        {
            var url = BassAddress + "setting/getverifycode";
            var data = $"id=&type={type}&mobile={mobile}";
            var author = Base64(Secret);
            var result = HttpRequest(url, "GET", author, data);
            if (result.Successful)
            {
                Console.Write($"Code: {result.Data}");
                Console.ReadLine();
                return Deserialize<string>(result.Data);
            }

            Console.Write(result.Message);
            Console.ReadLine();
            return null;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mobile"></param>
        private static Session Register(string code, string mobile)
        {
            var url = BassAddress + "user";
            var session = new Session
            {
                LoginName = mobile,
                UserName = "李四",
                Signature = Hash(mobile.ToUpper() + code + Hash("111111")),
                Version = 10000,
                ClientType = 2,
                MachineId = Hash("MachineId")
            };
            var author = Base64(session);
            var dict = new Dictionary<string, string> {{"smsCode", code}, {"password", Hash("111111")}};
            var data = Serialize(dict);
            var result = HttpRequest(url, "PUT", author, data);
            if (result.Successful)
            {
                session = Deserialize<Session>(result.Data);
                Console.Write($"用户 {mobile} 注册成功");
                Console.ReadLine();
                return session;
            }

            Console.Write(result.Message);
            Console.ReadLine();
            return null;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        private static Session Login(string mobile, string password)
        {
            var url = BassAddress + "user/signin";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + Hash(password)),
                Version = 10000,
                ClientType = 2,
                MachineId = Hash("MachineId")
            };
            var data = Serialize(us);
            var result = HttpRequest(url, "POST", null, data);
            if (result.Successful)
            {
                var session = Deserialize<Session>(result.Data);
                Console.Write($"用户 {mobile} 登录结果：{session.LoginResult}");
                Console.ReadLine();
                return session;
            }

            Console.Write(result.Message);
            Console.ReadLine();
            return null;
        }

        /// <summary>
        /// 注销
        /// </summary>
        private static void Logout()
        {
            var url = BassAddress + "user/signout";
            var author = Base64(UserSession);
            var data = Serialize(UserSession.ID);
            var result = HttpRequest(url, "POST", author, data);
            if (result.Successful)
            {
                Console.Write($"用户 {UserSession.LoginName} 注销成功");
                Console.ReadLine();
            }
            else
            {
                Console.Write(result.Message);
                Console.ReadLine();
            }
        }

        private static void GetToken()
        {
            var url = BassAddress + "setting/getqiniutoken";
            var author = Base64(Secret);
            var result = HttpRequest(url, "GET", author);
            if (result.Successful)
            {
                Console.Write($"Token: {result.Data}");
                Console.ReadLine();
            }
            else
            {
                Console.Write(result.Message);
                Console.ReadLine();
            }
        }

    }

}
