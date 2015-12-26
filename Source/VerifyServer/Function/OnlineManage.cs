using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Insight.WS.Verify.Util;

namespace Insight.WS.Verify
{
    public class OnlineManage : Interface
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="type">验证类型</param>
        /// <param name="mobile">手机号</param>
        /// <param name="time">过期时间（分钟）</param>
        /// <returns>string 验证码</returns>
        public string GetCode(int type, string mobile, int time)
        {
            var record = SmsCodes.OrderByDescending(r => r.CreateTime).FirstOrDefault(r => r.Mobile == mobile && r.Type == type);
            if (record != null && (DateTime.Now - record.CreateTime).TotalSeconds < 60) return null;

            var code = Util.Random.Next(100000, 999999).ToString();
            record = new VerifyRecord
            {
                Type = type,
                Mobile = mobile,
                Code = code,
                FailureTime = DateTime.Now.AddMinutes(time),
                CreateTime = DateTime.Now
            };
            SmsCodes.Add(record);
            return code;
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="remove">是否验证成功后删除记录</param>
        /// <returns>bool 是否正确</returns>
        public bool VerifyCode(string mobile, string code, int type, bool remove)
        {
            SmsCodes.RemoveAll(c => c.FailureTime < DateTime.Now);
            var record = SmsCodes.FirstOrDefault(c => c.Mobile == mobile && c.Code == code && c.Type == type);
            if (record == null) return false;

            if (!remove) return true;

            return SmsCodes.RemoveAll(c => c.Mobile == mobile && c.Type == type) > 0;
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            var session = GetSession(obj);
            if (session.OnlineStatus && session.MachineId == obj.MachineId)
            {
                // 当前已登录或未正常退出，标记为在线
                obj.LoginResult = LoginResult.Online;
                return obj;
            }

            Verify(session, obj);
            if (obj.LoginResult.GetHashCode() > 1) return obj;

            session.DeptId = obj.DeptId;
            session.DeptName = obj.DeptName;
            session.Version = obj.Version;
            session.ClientType = obj.ClientType;
            session.MachineId = obj.MachineId;
            return session;
        }

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>全部内部用户的Session</returns>
        public List<Session> GetSessions(Session obj)
        {
            return Sessions.Where(s => s.UserType > 0 && s.OnlineStatus).ToList();
        }

        /// <summary>
        /// 更新指定用户Session的签名
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <param name="pw">用户新密码</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateSignature(Session obj, Guid id, string pw)
        {
            if (!SimpleVerification(obj)) return false;

            using (var context = new WSEntities())
            {
                // 更新数据库
                var user = context.SYS_User.SingleOrDefault(u => u.ID == id);
                if (user == null) return false;

                if (user.Password == pw) return true;

                user.Password = pw;
                if (context.SaveChanges() <= 0) return false;

                // 更新缓存
                var session = Sessions.SingleOrDefault(s => s.UserId == id);
                if (session != null) session.Signature = Hash(user.LoginName.ToUpper() + pw);

                return true;
            }
        }

        /// <summary>
        /// 根据用户ID更新用户信息
        /// </summary>
        /// <param name="obj">操作员的Session</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否成功</returns>
        public bool UpdateUserInfo(Session obj, Guid id)
        {
            if (!SimpleVerification(obj)) return false;

            var session = Sessions.SingleOrDefault(s => s.UserId == id);
            if (session == null) return true;

            var user = GetUser(id);
            if (user == null) return false;

            session.UserName = user.Name;
            session.UserType = user.Type;
            session.OpenId = user.OpenId;
            return true;
        }

        /// <summary>
        /// 设置指定用户的登录状态为离线
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="id">用户ID</param>
        /// <returns>bool 是否成功</returns>
        public bool SetUserOffline(Session obj, Guid id)
        {
            if (!SimpleVerification(obj)) return false;

            var session = Sessions.SingleOrDefault(s => s.UserId == id);
            if (session != null) session.OnlineStatus = false;

            return true;
        }

        /// <summary>
        /// 根据用户ID设置用户状态
        /// </summary>
        /// <param name="obj">操作员的Session</param>
        /// <param name="uid">用户ID</param>
        /// <param name="validity">可用状态</param>
        /// <returns>bool 是否成功</returns>
        public bool SetUserStatus(Session obj, Guid uid, bool validity)
        {
            if (!SimpleVerification(obj)) return false;

            var session = Sessions.SingleOrDefault(s => s.UserId == uid);
            if (session != null) session.Validity = validity;

            return true;
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        public bool Authorization(Session obj, string action)
        {
            Guid actionId;
            if (!Guid.TryParse(action, out actionId)) return false;

            // 验证会话合法性
            if (!SimpleVerification(obj)) return false;

            // 根据传入的操作代码进行鉴权
            var sql = "select A.ActionId from Sys_RolePerm_Action A join Get_PermRole(@UserId, @DeptId) R ";
            sql += "on R.RoleId = A.RoleId and A.ActionId = @ActionId ";
            sql += "group by A.ActionId having min(A.Action) > 0";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = obj.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = obj.DeptId},
                new SqlParameter("@ActionId", SqlDbType.UniqueIdentifier) {Value = actionId}
            };
            return SqlScalar(MakeCommand(sql, parm)) != null;
        }

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话信息</returns>
        public Session Verification(Session obj)
        {
            if (obj == null) return null;

            // 不在在线用户列表中（下标溢出），重新获取Session再比较
            if (obj.ID >= Sessions.Count) return Verify(GetSession(obj), obj);

            // 如用户ID匹配，直接比较。否则重新获取Session。
            var session = Sessions[obj.ID];
            return Verify(session.UserId == obj.UserId ? session : GetSession(obj), obj);
        }

        /// <summary>
        /// 简单会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public bool SimpleVerification(Session obj)
        {
            if (obj == null) return false;

            // 不在在线用户列表中（下标溢出），重新获取Session再比较
            if (obj.ID >= Sessions.Count) return SimpleVerifty(GetSession(obj), obj);

            // 如用户ID匹配，直接比较。否则重新获取Session
            var session = Sessions[obj.ID];
            return SimpleVerifty(session.UserId == obj.UserId ? session : GetSession(obj), obj);
        }

        /// <summary>
        /// 比较Session
        /// </summary>
        /// <param name="basis">服务端的Session</param>
        /// <param name="obj">传入的Session</param>
        /// <returns>Session 用户会话</returns>
        private Session Verify(Session basis, Session obj)
        {
            // 用户被封禁
            if (!basis.Validity)
            {
                obj.LoginResult = LoginResult.Banned;
                return obj;
            }

            // 验证签名失败计数清零（距上次用户签名验证时间超过1小时）
            if (basis.FailureCount > 0 && (DateTime.Now - basis.LastConnect).TotalHours > 1)
            {
                basis.FailureCount = 0;
            }
            basis.LastConnect = DateTime.Now;

            // 签名不正确或验证签名失败超过5次（冒用时）则不能通过验证，且连续失败计数累加1次
            if (basis.Signature != obj.Signature || (basis.FailureCount >= 5 && basis.MachineId != obj.MachineId))
            {
                basis.FailureCount++;
                obj.LoginResult = LoginResult.Failure;
                return obj;
            }

            basis.OnlineStatus = true;
            basis.FailureCount = 0;
            obj.LoginResult = basis.MachineId != obj.MachineId ? LoginResult.Multiple : LoginResult.Success;
            return obj;
        }

        /// <summary>
        /// 比较Session，返回布尔值
        /// </summary>
        /// <param name="basis">服务端的Session</param>
        /// <param name="obj">传入的Session</param>
        /// <returns>bool 比较结果</returns>
        private bool SimpleVerifty(Session basis, Session obj)
        {
            // 用户被封禁，不能通过验证
            if (!basis.Validity) return false;

            // 验证签名失败计数清零（距上次用户签名验证时间超过1小时）
            if (basis.FailureCount > 0 && (DateTime.Now - basis.LastConnect).TotalHours > 1)
            {
                basis.FailureCount = 0;
            }
            basis.LastConnect = DateTime.Now;

            // 签名正确时，通过验证且错误计数清零；不正确则不能通过验证，且连续失败计数累加1次
            if (basis.Signature == obj.Signature && (basis.FailureCount < 5 || basis.MachineId == obj.MachineId))
            {
                basis.FailureCount = 0;
                return true;
            }

            basis.FailureCount++;
            return false;
        }

        /// <summary>
        /// 根据用户登录名获取用户Session
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session</returns>
        private Session GetSession(Session obj)
        {
            var session = Sessions.SingleOrDefault(s => string.Equals(s.LoginName, obj.LoginName, StringComparison.CurrentCultureIgnoreCase));
            if (session != null) return session;

            var user = GetUser(obj.LoginName);
            if (user == null) return null;


            // 初始化Session数据并加入缓存
            var signature = Hash(user.LoginName.ToUpper() + user.Password);
            session = new Session
            {
                ID = Sessions.Count,
                UserId = user.ID,
                UserName = user.Name,
                OpenId = user.OpenId,
                LoginName = user.LoginName,
                Signature = signature,
                UserType = user.Type,
                Validity = user.Validity,
                Version = obj.Version,
                ClientType = obj.ClientType,
                MachineId = obj.MachineId,
                BaseAddress = obj.BaseAddress
            };
            Sessions.Add(session);

            return session;
        }

    }
}
