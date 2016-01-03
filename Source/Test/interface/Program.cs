using System;
using System.Collections.Generic;
using System.Text;
using Insight.WS.Test.Interface.Entity;
using static Insight.WS.Test.Interface.Util;

namespace Insight.WS.Test.Interface
{
    static class Program
    {
        private const string BassAddress = "http://localhost:6280/AppService/";
        //private const string BassAddress = "http://120.27.142.125:6280/AppService/";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var buffer = Convert.FromBase64String("eyJNYWNoaW5lSWQiOiI4MjlGRTcwOTE5MzEwMTVFM0IxNTJFMkNGQ0MxMEQ5QyIsIlVzZXJUeXBlIjotMSwiRGVwdElkIjpudWxsLCJDbGllbnRUeXBlIjoyLCJJRCI6MCwiTG9naW5SZXN1bHQiOjEsIlVzZXJJZCI6IjU5NjdmMGMzLWMwYWEtZTUxMS05NDBkLWU4NGE0ZGNmYTY5MCIsIlVzZXJOYW1lIjoieW9uZyIsIkZhaWx1cmVDb3VudCI6MiwiTG9naW5OYW1lIjoiMTg2MjgwNzA3MzkiLCJFeHRlbnNpb25EYXRhIjp7fSwiT25saW5lU3RhdHVzIjp0cnVlLCJPcGVuSWQiOm51bGwsIlZlcnNpb24iOjEwMDAsIlZhbGlkaXR5Ijp0cnVlLCJCYXNlQWRkcmVzcyI6bnVsbCwiU2lnbmF0dXJlIjoiQkMxMENEMzIyNzhCRkYyRjU0MTkyRTY1NTY0OTZDRDMiLCJEZXB0TmFtZSI6bnVsbCwiTGFzdENvbm5lY3QiOiJcL0RhdGUoMTQ1MTAyMzU2OTc4NilcLyJ9");
            //var json = Encoding.UTF8.GetString(buffer);
            //var obj = Deserialize<Session>(json);
            //GetToken();
            GetSimilarTopics();
            GetRelateTopics();
            var mobile = "18600740252";
            //UserSession = Register(GetSmsVerifyCode("1", mobile), mobile);
            //UserSession = ResetPassword(GetSmsVerifyCode("2", mobile), mobile, "123456");
            //UserSession = Login(mobile, "123456");
            //var tid = "79A1F72C-CCAE-E511-9C5E-ACBC3278616E";
            //var sid = "7CA1F72C-CCAE-E511-9C5E-ACBC3278616E";
            //var cid = "7DA1F72C-CCAE-E511-9C5E-ACBC3278616E";
            //GetMemberInfo();
            //AddTopic();
            //AddFavorites(tid, 2);
            //ForwardTopic(tid);
            //AddSpeech(tid);
            //AddAttitude(sid, 1);
            //AddComment(sid);
            //AddPraise(cid, 1);
            //GetTopics();
            //GetTopic(tid);
            //GetSpeechs(tid);
            //GetSpeech(sid);
            //GetComments(sid);
            //ChangePassword("111111");
            //Logout();
        }

        private static void GetSimilarTopics()
        {
            var url = BassAddress + "simtopics";
            var title = "大王龋齿";
            var data = $"title={title}";
            var author = Base64(Hash(title + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetRelateTopics()
        {
            var url = BassAddress + "reltopics";
            var tags = "龋齿";
            var data = $"tags={tags}";
            var author = Base64(Hash(tags + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static string AddTopic()
        {
            var url = BassAddress + "topic";
            var topic = new SDT_Topic
            {
                Title = "我是测试话题",
                Description = "在把美美的自拍照晒到社交媒体之前，大部分人都有着不可缺少的一步，那就是利用修图软件对图片进行美化。",
                PublishTime = DateTime.Now,
                CreatorUserId = UserSession.UserId
            };
            var dict = new Dictionary<string, SDT_Topic> { { "topic", topic } };
            var data = Serialize(dict);
            var author = Base64(UserSession);
            var result = HttpRequest(url, "PUT", author, data);
            PutResult(result);
            return result.Data;
        }

        private static void AddFavorites(string tid, int type)
        {
            var url = BassAddress + "user/favorite";
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
            var url = BassAddress + "topic/forward";
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
            var url = BassAddress + "topic/speech";
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
            var url = BassAddress + "topic/speech/attitude";
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
            var url = BassAddress + "topic/speech/comment";
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
            var url = BassAddress + "topic/speech/comment/praise";
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
            var url = BassAddress + "topics";
            var data = $"gid={""}";
            var author = Base64(Hash(Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetTopic(string id)
        {
            var url = BassAddress + "topic";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetSpeechs(string id)
        {
            var url = BassAddress + "topic/speechs";
            var data = $"id={id}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetSpeech(string id)
        {
            var url = BassAddress + "topic/speech";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetComments(string id)
        {
            var url = BassAddress + "topic/speech/comments";
            var data = $"id={id}&mid={UserSession?.UserId}";
            var author = Base64(Hash(id + Secret));
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void GetMemberInfo()
        {
            var url = BassAddress + "user/memberinfo";
            var id = UserSession.UserId;
            var data = $"id={id}";
            var author = Base64(UserSession);
            var result = HttpRequest(url, "GET", author, data);
            PutResult(result);
        }

        private static void ChangePassword(string password)
        {
            var url = BassAddress + "user/change";
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
            var url = BassAddress + "setting/verifycode";
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
            var url = BassAddress + "user";
            var session = new Session
            {
                LoginName = mobile,
                UserName = "xbg",
                Signature = Hash(mobile.ToUpper() + code + Hash("123456")),
                Version = 10000,
                ClientType = 2,
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
            var url = BassAddress + "user/signin";
            var us = new Session
            {
                LoginName = mobile,
                Signature = Hash(mobile.ToUpper() + Hash(password)),
                Version = 10000,
                ClientType = 2,
                MachineId = Hash("MachineId")
            };
            var dict = new Dictionary<string, Session> { { "session", us } };
            var data = Serialize(dict);
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
            var dict = new Dictionary<string, int> {{"id", 0}};
            var data = Serialize(dict);
            var result = HttpRequest(url, "POST", author, data);
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
            var url = BassAddress + "setting/qiniutoken";
            var author = Base64(Hash(Secret));
            var result = HttpRequest(url, "GET", author);
            PutResult(result);
        }

        private static void PutResult(JsonResult result)
        {
            if (result.Successful)
            {
                Console.Write($"Result: {result.Data}");
                Console.ReadLine();
                return;
            }

            Console.Write(result.Message);
            Console.ReadLine();
        }

    }

}
