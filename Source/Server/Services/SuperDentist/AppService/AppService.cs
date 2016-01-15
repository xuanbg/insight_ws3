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
    public partial class AppService : Interface
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
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            return SetUserOffline(us, us.LoginName) ? result : result.NotFound();
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="password">新登录密码MD5值</param>
        /// <returns>JsonResult</returns>
        public JsonResult ChangePassword(string password)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

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

        #endregion

        #region Group

        /// <summary>
        /// 获取群组列表
        /// </summary>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetGroups(string mid)
        {
            var result = Verify(mid + Secret);
            if (!result.Successful) return result;

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var groups = new List<Group>();
                if (gp.Guid.HasValue)
                {
                    var top3 = context.GetGroups(gp.Guid).Where(g => (g.IsJoin == null || !(bool) g.IsJoin) && !g.IsCare)
                        .OrderByDescending(g => g.Heat).Take(3);
                    var care = context.GetGroups(gp.Guid).Where(g => g.IsCare);
                    var join = context.GetGroups(gp.Guid).Where(g => g.IsJoin != null && (bool) g.IsJoin && !g.IsCare);
                    groups.AddRange(top3);
                    groups.AddRange(care);
                    groups.AddRange(join);
                }
                else
                {
                    groups = context.GetGroups(gp.Guid).OrderByDescending(g => g.Heat).Take(20).ToList();
                }
                return result.Success(Serialize(groups));
            }
        }

        /// <summary>
        /// 搜索群组
        /// </summary>
        /// <param name="keys">关键词</param>
        /// <param name="mid">会员ID（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult SearchGroups(string keys, string mid)
        {
            var result = Verify(keys + Secret);
            if (!result.Successful) return result;

            var gp = new GuidParse(mid);
            if (!gp.Successful) return result.InvalidGuid();

            var keylist = keys.Split(Convert.ToChar(",")).ToList();
            var groups = Common.SearchGroup(keylist, gp.Guid);
            return result.Success(Serialize(groups));
        }

        /// <summary>
        /// 新建群组
        /// </summary>
        /// <param name="group">群组数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddGroup(SDG_Group group)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            group.CreatorUserId = us.UserId;
            group.OwnerUserId = us.UserId;
            var cmd = InsertData(group);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 删除群组
        /// </summary>
        /// <param name="id">群组ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveGroup(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid gid;
            if (!Guid.TryParse(id, out gid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var group = context.SDG_Group.SingleOrDefault(g => g.ID == gid);
                if (group == null) return result.NotFound();

                if (us.UserId != group.ManageUserId && us.UserId != group.OwnerUserId) result.Forbidden();

                group.Validity = false;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 编辑群组信息
        /// </summary>
        /// <param name="group">群组数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditGroup(SDG_Group group)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDG_Group.SingleOrDefault(t => t.ID == group.ID);
                if (data == null) return result.NotFound();

                if (us.UserId != data.ManageUserId && us.UserId != data.OwnerUserId) result.Forbidden();

                data.Name = group.Name;
                data.Description = group.Description;
                data.Icon = group.Icon;
                data.Picture = group.Picture;
                data.ManageUserId = group.ManageUserId;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 转让群主
        /// </summary>
        /// <param name="id">群组ID</param>
        /// <param name="mid">新的群主会员ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult Transfer(string id, string mid)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid gid;
            if (!Guid.TryParse(id, out gid)) return result.InvalidGuid();

            Guid uid;
            if (!Guid.TryParse(mid, out uid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var data = context.SDG_Group.SingleOrDefault(t => t.ID == gid);
                if (data == null) return result.NotFound();

                if (us.UserId != data.OwnerUserId) result.Forbidden();

                data.OwnerUserId = uid;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 加入群组
        /// </summary>
        /// <param name="member">群组成员数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult JoinGroup(SDG_GroupMember member)
        {
            var result = Verify();
            if (!result.Successful) return result;

            using (var context = new WSEntities())
            {
                var data = context.SDG_GroupMember.SingleOrDefault(r => r.MemberId == member.MemberId);
                if (data != null) return result.DataAlreadyExists();
            }

            var cmd = InsertData(member);
            var id = SqlScalar(cmd);
            return id == null ? result.DataBaseError() : result.Success(id.ToString());
        }

        /// <summary>
        /// 开除群组成员
        /// </summary>
        /// <param name="id">群组成员数据记录ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveMember(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid rid;
            if (!Guid.TryParse(id, out rid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var data = context.SDG_GroupMember.SingleOrDefault(r => r.ID == rid);
                if (data == null) return result.NotFound();

                var group = context.SDG_Group.Single(g => g.ID == data.GroupId);
                if (us.UserId != group.ManageUserId && us.UserId != group.OwnerUserId) result.Forbidden();

                context.SDG_GroupMember.Remove(data);
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 同意加入群组
        /// </summary>
        /// <param name="id">群组成员数据记录ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddMember(string id)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid rid;
            if (!Guid.TryParse(id, out rid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var data = context.SDG_GroupMember.SingleOrDefault(r => r.ID == rid);
                if (data == null) return result.NotFound();

                var group = context.SDG_Group.Single(g => g.ID == data.GroupId);
                if (us.UserId != group.ManageUserId && us.UserId != group.OwnerUserId) result.Forbidden();

                data.Validity = true;
                return context.SaveChanges() > 0 ? result : result.DataBaseError();
            }
        }

        /// <summary>
        /// 获取群组成员列表
        /// </summary>
        /// <param name="id">群组ID</param>
        /// <param name="member">是否群组成员</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetGroupMembers(string id, bool member)
        {
            Session us;
            var result = Verify(out us);
            if (!result.Successful) return result;

            Guid gid;
            if (!Guid.TryParse(id, out gid)) return result.InvalidGuid();

            using (var context = new WSEntities())
            {
                var group = context.SDG_Group.SingleOrDefault(g => g.ID == gid);
                if (group == null) return result.NotFound();

                if (us.UserId != group.ManageUserId && us.UserId != group.OwnerUserId) result.Forbidden();

                var list = context.SDG_GroupMember.Where(m => m.Validity == member && m.GroupId == gid && m.MemberId != group.OwnerUserId).ToList();
                return result.Success(Serialize(list));
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
