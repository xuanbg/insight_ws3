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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
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
            return GetJson(UserLogin(obj));
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns>JsonResult</returns>
        public JsonResult Login(Session session)
        {
            var us = UserLogin(session);
            return GetJson(us);
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
            return GetJson(UserLogin(obj));
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

            var gp = new GuidParse(id);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var favorite = context.MDE_Favorites.SingleOrDefault(f => f.ID == gp.Relust);
                if (favorite == null) return result.NotFound();

                context.MDE_Favorites.Remove(favorite);
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
                var topics = gp.Relust.HasValue
                    ? context.Topics.Where(m => m.GroupId == gp.Relust).ToList()
                    : context.Topics.Where(m => !m.Private).ToList();
                return GetJson(topics);
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

            var gp = new GuidParse(id);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var topic = context.SDT_Topic.SingleOrDefault(t => t.ID == gp.Relust);
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
                var topic = context.GetTopic(tid, gp.Relust).FirstOrDefault();
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
                return GetJson(speechs);
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

            var gp = new GuidParse(id);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var speech = context.SDT_Speech.SingleOrDefault(s => s.ID == gp.Relust);
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
                var speech = context.GetSpeech(sid, gp.Relust).FirstOrDefault();
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
                var comments = context.GetComments(sid, gp.Relust).ToList();
                return GetJson(comments);
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
            result.Data = Serialize(token);
            return result;
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
