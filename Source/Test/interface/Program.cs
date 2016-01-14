using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Insight.WS.Test.Interface.Entity;
using static Insight.WS.Test.Interface.Util;

namespace Insight.WS.Test.Interface
{
    static class Program
    {
        private const string BaseAddress = "http://localhost:6280/AppService/";
        //private const string BaseAddress = "http://120.27.142.125:6280/AppService/";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var version = new Version(Application.ProductVersion);
            var build = $"{version.Major}{version.Minor}{version.Build.ToString("D4").Substring(0,2)}";
            Util.Version = Convert.ToInt32(build);
            UserSession = Login("Admin", "123456");
            //UserSession = UserLogin("18600740256", "111111");
            AddTopic();
            //GetOrgs();

            Signout();
            //Logout();
        }

        private static void GetOrgs()
        {
            var url = "http://localhost:6400/organization/orgs";
            var author = Base64(UserSession);
            var result = HttpRequest(url, "GET", author);
            PutResult(result);
        }

        private static void AddRule()
        {
            var url = "http://localhost:6514/rules";
            var rule = new SYS_Logs_Rules
            {
                ID = Guid.NewGuid(),
                ToDataBase = false,
                Code = "600102",
                Level = 6,
                Source = "日志管理",
                Action = "修改规则",
                Message = "成功！",
                CreatorUserId = UserSession.UserId,
                CreateTime = DateTime.Now
            };
            var dict = new Dictionary<string, SYS_Logs_Rules> { { "rule", rule } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "POST", author, data);
            PutResult(result);
        }

        private static void SendLog()
        {
            var url = "http://localhost:6514/logs";
            var code = "600102";
            for (var i = 0; i < 1000; i++)
            {
                var dict = new Dictionary<string, string>
                {
                    {"code", code},
                    {"message", $"这是第{i}条日志"},
                    {"userid", null}
                };
                var data = Serialize(dict);
                var author = Base64(Hash(code + Secret));
                var result = HttpRequest(url, "POST", author, data);
            }
            //PutResult(result);
        }

        private static void SearchTopics(string keys)
        {
            var url = BaseAddress + "topics/search";
            var data = $"keys={keys}&gid={null}";
            var author = Base64(Hash(keys + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetSimilarTopics(string title)
        {
            var url = BaseAddress + "topics/similar";
            var data = $"title={title}";
            var author = Base64(Hash(title + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetRelateTopics(string tags)
        {
            var url = BaseAddress + "topics/relate";
            var data = $"tags={tags}";
            var author = Base64(Hash(tags + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static string AddTopic()
        {
            var url = BaseAddress + "topic";
            var topic = new SDT_Topic
            {
                Title = "test",
                Description = "Test",
                Tags = "A",
                PublishTime = DateTime.Now,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Topic> { { "topic", topic }};
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data, false);
            PutResult(result);
            return result.Data;
        }

        private static void AddFavorites(string tid, int type)
        {
            var url = BaseAddress + "user/favorite";
            var favorite = new MDE_Favorites
            {
                Type = type,
                ObjectId = Guid.Parse(tid),
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, MDE_Favorites> { { "favorites", favorite } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
        }

        private static void ForwardTopic(string tid)
        {
            var url = BaseAddress + "topic/forward";
            var forward = new SDT_Forward
            {
                TopicId = Guid.Parse(tid),
                GroupId = Guid.Empty,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Forward> { { "forward", forward } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
        }

        private static string AddSpeech(string tid)
        {
            var url = BaseAddress + "topic/speech";
            var speech = new SDT_Speech
            {
                TopicId = Guid.Parse(tid),
                Content = "马上进入新的一年2016了，来点轻松点的内容吧。",
                PublishTime = DateTime.Now,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Speech> { { "speech", speech } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
            return result.Data;
        }

        private static void AddAttitude(string sid, int type)
        {
            var url = BaseAddress + "topic/speech/attitude";
            var attitude = new SDT_Attitude
            {
                SpeechId = Guid.Parse(sid),
                Type = type,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Attitude> { { "attitude", attitude } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
        }

        private static string AddComment(string sid)
        {
            var url = BaseAddress + "topic/speech/comment";
            var comment = new SDT_Comment
            {
                SpeechId = Guid.Parse(sid),
                Content = "AQS里面的CLH队列是CLH同步锁的一种变形",
                PublishTime = DateTime.Now,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Comment> { { "comment", comment } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
            return result.Data;
        }

        private static void AddPraise(string cid, int type)
        {
            var url = BaseAddress + "topic/speech/comment/praise";
            var praise = new SDT_Praise
            {
                CommentId = Guid.Parse(cid),
                Type = type,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Praise> { { "praise", praise } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
        }

        private static void GetTopics()
        {
            var url = BaseAddress + "topics";
            var data = $"gid={""}";
            var author = Base64(Hash(Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetTopic(string id)
        {
            var url = BaseAddress + "topic";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetSpeechs(string id)
        {
            var url = BaseAddress + "topic/speechs";
            var data = $"id={id}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetSpeech(string id)
        {
            var url = BaseAddress + "topic/speech";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetComments(string id)
        {
            var url = BaseAddress + "topic/speech/comments";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetMemberInfo()
        {
            var url = BaseAddress + "user/memberinfo";
            var id = UserSession.UserId;
            var data = $"id={id}";
            var author = Base64(UserSession);
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void ChangePassword(string password)
        {
            var url = BaseAddress + "user/change";
            var author = Base64(UserSession);
            var dict = new Dictionary<string, string> {{ "password", Hash(password) } };
            var data = Serialize(dict);
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
            var url = BaseAddress + "user/reset";
            var session = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + code + Hash(password)),
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
            var url = BaseAddress + "setting/verifycode";
            var data = $"id=&type={type}&mobile={mobile}";
            var author = Base64(Hash(Secret));
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
            var url = BaseAddress + "user";
            var session = new Session
            {
                LoginName = mobile,
                UserName = "xbg",
                Signature = Hash(mobile.ToUpper() + code + Hash("123456")),
                MachineId = Hash("MachineId")
            };
            var author = Base64(session);
            var dict = new Dictionary<string, string> {{"smsCode", code}, {"password", Hash("123456")}};
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
            var url = $"{BaseAddress}user/signin";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + Hash(password)),
                Version = 101,
                MachineId = Hash("MachineId")
            };
            var dict = new Dictionary<string, Session> { { "session", us } };
            var data = Serialize(dict);
            var result = HttpRequest(url, "POST", null, data, false);
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

        private static Session UserLogin(string mobile, string password)
        {
            var url = $"{BaseAddress}user/signin";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + Hash(password)),
                MachineId = Hash("MachineId")
            };
            var author = Base64(us);
            var result = HttpRequest(url, "PUT", author, "", false);
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
            var url = "http://localhost:6400/verify/user/signout";
            var author = Base64(UserSession);
            var dict = new Dictionary<string, string> {{ "account", UserSession.LoginName}};
            var data = Serialize(dict);
            var result = HttpRequest(url, "PUT", author, data, false);
            if (result.Successful)
            {
                Console.Write($"用户{UserSession.LoginName}注销成功！");
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

        /// <summary>
        /// 注销
        /// </summary>
        private static void Signout()
        {
            var url = $"{BaseAddress}user/signout";
            var author = Base64(UserSession);
            var dict = new Dictionary<string, string> {{ "account", UserSession.LoginName}};
            var data = Serialize(dict);
            var result = HttpRequest(url, "POST", author, data, false);
            if (result.Successful)
            {
                Console.Write($"用户{UserSession.LoginName}注销成功！");
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

        private static void GetToken()
        {
            var url = BaseAddress + "setting/qiniutoken";
            var author = Base64(Hash(Secret));
            var result = HttpRequest(url, "GET", author);
            PutResult(result);
        }

        private static void PutResult(JsonResult result)
        {
            if (result.Successful)
            {
                Console.Write($"Message: {result.Message}\r\n");
                Console.Write($"Result: {result.Data}");
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

    }

}
