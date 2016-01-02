using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using Qiniu.RS;
using static Insight.WS.Server.Common.General;
using static Insight.WS.Server.Common.SqlHelper;
using static Insight.WS.Server.Common.Util;
using static Insight.WS.Service.SuperDentist.DataAccess;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AppService : Interface
    {

        #region 静态字段

        private static readonly string AccessKey = GetAppSetting("AccessKey");
        private static readonly string SecretKey = GetAppSetting("SecretKey");
        private static readonly string BucketName = GetAppSetting("Bucket");

        #endregion

        #region user

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult Register(string smsCode, string password)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature) return result.InvalidAuth();

            using (var context = new WSEntities())
            {
                // 验证用户登录名是否已存在
                var user = context.SYS_User.FirstOrDefault(u => u.LoginName == obj.LoginName);
                if (user != null) return result.AccountExists();
            }

            if (!VerifyCode(obj.LoginName, smsCode, 1)) return result.SMSCodeError();

            var cmds = new List<SqlCommand>
            {
                Server.Common.DataAccess.AddMasterData(new MasterData { Name = obj.UserName, Alias = obj.LoginName }),
                InsertData(new MDG_Member()),
                Server.Common.DataAccess.AddUser(new SYS_User {Name = obj.UserName, LoginName = obj.LoginName, Password = password, Type = -1})
            };
            if (!SqlExecute(cmds)) return result.DataBaseError();

            obj.Signature = Hash(obj.LoginName.ToUpper() + password);
            return result.Success(Serialize(obj));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>JsonResult</returns>
        public JsonResult Login(Session session)
        {
            var us = UserLogin(session);
            return new JsonResult().Success(Serialize(us));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult Logout()
        {
            var result = Verify();
            if (!result.Successful) return result;

            var us = GetAuthorization<Session>();
            return SetUserOffline(us, us.LoginName) ? result : result.NotFound();
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="password">新登录密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ChangePassword(string password)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var us = GetAuthorization<Session>();
            return UpdateSignature(us, us.UserId, password) ? result : result.NotFound();
        }

        /// <summary>
        /// 重置登录密码
        /// </summary>
        /// <param name="smsCode">短信验证码</param>
        /// <param name="password">密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ResetPassword(string smsCode, string password)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<Session>();
            var signature = Hash(obj.LoginName.ToUpper() + smsCode + password);
            if (signature != obj.Signature) return result.InvalidAuth();

            // 验证用户是否存在
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.SingleOrDefault(u => u.LoginName == obj.LoginName);
                if (user == null) return result.NotFound();

                obj.UserId = user.ID;
                obj.Signature = Hash(user.LoginName.ToUpper() + user.Password);
            }

            if (!VerifyCode(obj.LoginName, smsCode, 2)) return result.SMSCodeError();

            if (!UpdateSignature(obj, obj.UserId, password)) return result.DataBaseError();

            obj.Signature = Hash(obj.LoginName.ToUpper() + password);
            return result.Success(Serialize(obj));
        }

        /// <summary>
        /// 获取会员列表
        /// </summary>
        /// <param name="name">昵称</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMembers(string name)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var members = context.MemberInfo.Where(m => m.Name.Contains(name)).ToList();
                return result.Success(Serialize(members));
            }
        }

        /// <summary>
        /// 编辑会员信息
        /// </summary>
        /// <param name="member">会员信息数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult SetMemberInfo(MDG_Member member)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.MDG_Member.SingleOrDefault(m => m.MID == member.MID);
                if (data == null) return result.NotFound();

                data.Portrait = member.Portrait;
                data.Signature = member.Signature;
                data.Country = member.Country;
                data.State = member.State;
                data.City = member.City;
                data.County = member.County;
                data.Street = member.Street;
                data.ZipCode = member.ZipCode;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMemberInfo(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid uid;
            if (!Guid.TryParse(id, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var member = context.MemberInfo.SingleOrDefault(m => m.ID == uid);
                return GetJson(member);
            }
        }

        #endregion

        #region Favorite

        /// <summary>
        /// 获取收藏列表
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <param name="type">收藏类型</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetFavorites(string id, int type)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid uid;
            if (!Guid.TryParse(id, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var favorites = context.MDE_Favorites.Where(f => f.CreatorUserId == uid && f.Type == type);
                return result.Success(Serialize(favorites));
            }
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="favorites">收藏数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult Favorite(MDE_Favorites favorites)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(favorites);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id">收藏记录ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveFavorite(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid fid;
            if (!Guid.TryParse(id, out fid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var favorite = context.MDE_Favorites.SingleOrDefault(f => f.ID == fid);
                if (favorite == null) return result.NotFound();

                context.MDE_Favorites.Remove(favorite);
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        #endregion

        #region Message

        /// <summary>
        /// 获取私信列表
        /// </summary>
        /// <param name="id">通信对象ID</param>
        /// <param name="mid">会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetMessages(string id, string mid)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid rid;
            if (!Guid.TryParse(id, out rid)) return result.InvalidGuid();

            Guid uid;
            if (!Guid.TryParse(mid, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var messages = context.MDE_Message.Where(m => m.CreatorUserId == uid && m.ReceiveUserId == rid);
                foreach (var message in messages)
                {
                    message.HaveRead = true;
                }

                return context.SaveChanges() > 0 ? result.Success(Serialize(messages)) : result.DataBaseError();
            }
        }

        /// <summary>
        /// 写私信
        /// </summary>
        /// <param name="message">私信数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddMessage(MDE_Message message)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(message);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveMessage(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid mid;
            if (!Guid.TryParse(id, out mid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var message = context.MDE_Message.SingleOrDefault(f => f.ID == mid);
                if (message == null) return result.NotFound();

                context.MDE_Message.Remove(message);
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="id">私信ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult SendMessage(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid mid;
            if (!Guid.TryParse(id, out mid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var message = context.MDE_Message.SingleOrDefault(t => t.ID == mid);
                if (message == null) return result.NotFound();

                message.SendTime = DateTime.Now;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        #endregion

        #region Topic

        /// <summary>
        /// 获取话题列表
        /// </summary>
        /// <param name="gid"></param>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopics(string gid)
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            var gp = new GuidParse(gid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topics = gp.Guid.HasValue
                    ? context.Topics.Where(m => m.GroupId == gp.Guid).ToList()
                    : context.Topics.Where(m => !m.Private).ToList();
                return result.Success(Serialize(topics));
            }
        }

        /// <summary>
        /// 获取相关话题列表
        /// </summary>
        /// <param name="tags">话题标签</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetRelateTopics(string tags)
        {
            var result = Verify(tags + Secret);
            if (!result.Successful) return result;

            var taglist = tags.Split(Convert.ToChar(","));
            var topics = new List<SDT_Topic>();
            using (var context = new WSEntities())
            {
                foreach (var tag in taglist)
                {
                    var list = context.SDT_Topic.Where(t => t.Tags.Contains(tag));
                    topics.AddRange(list);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(20);
                var simtopics = context.Topics.Join(order, t => t.TopicId, o => o, (t, o) => t).ToList();
                return result.Success(Serialize(simtopics));
            }
        }

        /// <summary>
        /// 获取相似话题列表
        /// </summary>
        /// <param name="title">话题标题</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSimilarTopics(string title)
        {
            var result = Verify(title + Secret);
            if (!result.Successful) return result;

            var topics = new List<SDT_Topic>();
            using (var context = new WSEntities())
            {
                var cate = context.BASE_Category.Single(c => c.Alias == "Tags");
                var tags = context.MasterData.Where(m => m.CategoryId == cate.ID).Select(m => m.Name);
                foreach (var tag in tags)
                {
                    if (!title.Contains(tag)) continue;

                    var list = context.SDT_Topic.Where(t => t.Tags.Contains(tag));
                    topics.AddRange(list);
                }
                var group = topics.GroupBy(t => t.ID).Select(l => new { ID = l.Key, Count = l.Count() });
                var order = group.OrderByDescending(l => l.Count).Select(id => id.ID).Take(20);
                var simtopics = context.Topics.Join(order, t => t.TopicId, o => o, (t, o) => t).ToList();
                return result.Success(Serialize(simtopics));
            }
        }

        /// <summary>
        /// 新增话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddTopic(SDT_Topic topic)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(topic);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除话题
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemovTopic(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.SDT_Topic.SingleOrDefault(t => t.ID == tid);
                if (topic == null) return result.NotFound();

                topic.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑话题
        /// </summary>
        /// <param name="topic">话题数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditTopic(SDT_Topic topic)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Topic.SingleOrDefault(t => t.ID == topic.ID);
                if (data == null) return result.NotFound();

                data.Title = topic.Title;
                data.Description = topic.Description;
                data.Tags = topic.Tags;
                data.CaseId = topic.CaseId;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取话题详情
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopic(string id, string mid)
        {
            var result = Verify(id.ToUpper() + Secret);
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.GetTopic(tid, gp.Guid).FirstOrDefault();
                return GetJson(topic);
            }
        }

        /// <summary>
        /// 转载话题
        /// </summary>
        /// <param name="forward">话题转载数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult ForwardTopic(SDT_Forward forward)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(forward);
            return SqlNonQuery(cmd) > 0 ? result : result.DataBaseError();
        }

        #endregion

        #region Speech

        /// <summary>
        /// 获取发言列表
        /// </summary>
        /// <param name="id">话题ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSpeechs(string id)
        {
            var result = Verify(id.ToUpper() + Secret);
            if (!result.Successful) return result;

            Guid tid;
            if (!Guid.TryParse(id, out tid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speechs = context.Speechs.Where(s=> s.TopicId == tid).ToList();
                return result.Success(Serialize(speechs));
            }
        }

        /// <summary>
        /// 新增发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddSpeech(SDT_Speech speech)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(speech);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除发言
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveSpeech(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.SDT_Speech.SingleOrDefault(s => s.ID == sid);
                if (speech == null) return result.NotFound();

                speech.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑发言
        /// </summary>
        /// <param name="speech">发言数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditSpeech(SDT_Speech speech)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Speech.SingleOrDefault(t => t.ID == speech.ID);
                if (data == null) return result.NotFound();

                data.Content = speech.Content;
                data.CaseId = speech.CaseId;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取发言详情
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSpeech(string id, string mid)
        {
            var result = Verify(id.ToUpper() + Secret);
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.GetSpeech(sid, gp.Guid).FirstOrDefault();
                return GetJson(speech);
            }
        }

        /// <summary>
        /// 新增发言态度
        /// </summary>
        /// <param name="attitude">发言态度数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddAttitude(SDT_Attitude attitude)
        {
            var result = Verify();
            if (!result.Successful) return result;

            if (attitude.Type < 3)
            {
                var t = 3 - attitude.Type;
                using (var context = new WSEntities())
                {
                    var att = context.SDT_Attitude.SingleOrDefault(a => a.Type == t && a.CreatorUserId == attitude.CreatorUserId);
                    if (att != null)
                    {
                        att.Type = attitude.Type;
                        return context.SaveChanges() > 0 ? result : result.DataBaseError();
                    }
                }
            }

            var cmd = InsertData(attitude);
            return SqlNonQuery(cmd) > 0 ? result : result.DataBaseError();
        }

        #endregion

        #region Comment

        /// <summary>
        /// 获取发言评论列表
        /// </summary>
        /// <param name="id">发言ID</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetComments(string id, string mid)
        {
            var result = Verify(id.ToUpper() + Secret);
            if (!result.Successful) return result;

            Guid sid;
            if (!Guid.TryParse(id, out sid)) return result.InvalidGuid();

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var comments = context.GetComments(sid, gp.Guid).ToList();
                return result.Success(Serialize(comments));
            }
        }

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddComment(SDT_Comment comment)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(comment);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveComment(string id)
        {
            var result = Verify();
            if (!result.Successful) return result;

            Guid cid;
            if (!Guid.TryParse(id, out cid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var comment = context.SDT_Comment.SingleOrDefault(s => s.ID == cid);
                if (comment == null) return result.NotFound();

                comment.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑评论
        /// </summary>
        /// <param name="comment">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditComment(SDT_Comment comment)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDT_Comment.SingleOrDefault(s => s.ID == comment.ID);
                if (data == null) return result.NotFound();

                data.Content = comment.Content;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 新增评论态度
        /// </summary>
        /// <param name="praise">评论数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddPraise(SDT_Praise praise)
        {
            var result = Verify();
            if (!result.Successful) return result;

            var cmd = InsertData(praise);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 获取话题可用标签
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetTopicTags()
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var cate = context.BASE_Category.Single(c => c.Alias == "Tags");
                var data = context.MasterData.Where(m => m.CategoryId == cate.ID).ToList();
                return result.Success(Serialize(data));
            }
        }

        #endregion

        #region setting

        /// <summary>
        /// 获取七牛云文件上传Token
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetQiniuUploadToken()
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            Qiniu.Conf.Config.ACCESS_KEY = AccessKey;
            Qiniu.Conf.Config.SECRET_KEY = SecretKey;
            var policy = new PutPolicy(BucketName);
            var token = policy.Token();
            return result.Success(Serialize(token));
        }

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="id">图形验证码ID</param>
        /// <param name="type">短信验证码类型</param>
        /// <param name="mobile">手机号</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetSmsVerifyCode(string id, int type, string mobile)
        {
            var result = Verify(Secret);
            if (!result.Successful) return result;

            switch (type)
            {
                case 1:
                    return SmsCode.GetRegisterCode(mobile);

                case 2:
                    return SmsCode.GetResetPasswordCode(mobile);

                default:
                    return result.UnknownSmsType();
            }
        }

        #endregion

    }
}
