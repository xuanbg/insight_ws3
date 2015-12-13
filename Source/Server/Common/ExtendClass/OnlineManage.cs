using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Server.Common
{
    public static class OnlineManage
    {

        private static readonly List<Session> Sessions = new List<Session>();

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <returns></returns>
        public static List<Session> GetSessions()
        {
            return Sessions.Where(s => s.Type > 0 && s.SessionId != Guid.Empty).ToList();
        } 

        /// <summary>
        /// 获取用户Session
        /// </summary>
        /// <param name="obj">传入的用户Session</param>
        /// <returns>Session</returns>
        public static Session GetSession(Session obj)
        {
            var session = Sessions.SingleOrDefault(s => string.Equals(s.LoginName, obj.LoginName, StringComparison.CurrentCultureIgnoreCase));
            if (session != null) return session;

            if (Sessions.Count >= Convert.ToInt32(Util.GetAppSetting("MaxAuthorized")))
            {
                obj.LoginStatus = LoginResult.Unauthorized;
                return obj;
            }

            var user = DataAccess.GetUser(obj.LoginName);
            if (user == null)
            {
                obj.LoginStatus = LoginResult.NotExist;
                return obj;
            }

            // 初始化Session数据并加入缓存
            session = new Session
            {
                ID = Sessions.Count,
                OpenId = user.OpenId,
                UserId = user.ID,
                LoginName = user.LoginName,
                UserName = user.Name,
                Type = user.Type,
                Validity = user.Validity,
                MachineId = obj.MachineId,
                BaseAddress = obj.BaseAddress,
                Signature = Util.GetHash(user.LoginName.ToUpper() + user.Password),
                FailureCount = 0,
                LastConnect = DateTime.Now
            };
            Sessions.Add(session);

            return session;
        }

        /// <summary>
        /// 更新用户Session数据
        /// </summary>
        /// <param name="obj">传入的用户Session</param>
        public static void UpdateSession(Session obj)
        {
            var session = Sessions[obj.ID];
            session.SessionId = obj.SessionId;
            session.MachineId = obj.MachineId;
            session.DeptId = obj.DeptId;
            session.DeptName = obj.DeptName;
        }

        /// <summary>
        /// 更新指定用户Session的签名
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="pw">密码MD5值</param>
        public static bool UpdateSignature(int index, string pw)
        {
            if (index >= Sessions.Count) return false;

            var session = Sessions[index];
            session.Signature = Util.GetHash(session.LoginName.ToUpper() + pw);
            return true;
        }

        /// <summary>
        /// 重置指定用户Session的登录状态
        /// </summary>
        /// <param name="index">索引</param>
        public static bool ResetLoginStatus(int index)
        {
            if (index >= Sessions.Count) return false;

            Sessions[index].SessionId = Guid.Empty;
            return true;
        }

        /// <summary>
        /// 根据用户ID设置用户状态
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="validity">用户状态</param>
        public static bool SetUserStatus(Guid uid, bool validity)
        {
            var session = Sessions.SingleOrDefault(s => s.UserId == uid);
            if (session == null) return false;

            session.Validity = validity;
            return true;
        }

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj)
        {
            if (obj == null || obj.ID >= Sessions.Count) return false;

            var session = Sessions[obj.ID];

            // 用户被封禁，不能通过验证
            if (!session.Validity) return false;

            // 验证签名失败计数清零（距上次用户签名验证时间超过1小时）
            if (session.FailureCount > 0 && (DateTime.Now - session.LastConnect).TotalHours > 1)
            {
                session.FailureCount = 0;
            }
            session.LastConnect = DateTime.Now;

            // 验证签名失败超过5次（冒用时），不再验证
            if (session.FailureCount >= 5 && session.MachineId != obj.MachineId) return false;

            // 签名正确时，通过验证且错误计数清零；不正确则不能通过验证，且连续失败计数累加1次
            if (session.Signature == obj.Signature)
            {
                session.FailureCount = 0;
                return true;
            }

            session.FailureCount ++;
            return false;
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj, string action)
        {
            Guid actionId;
            if (!Guid.TryParse(action, out actionId)) return false;

            // 验证会话合法性
            if (!Verification(obj)) return false;

            // 根据传入的操作代码进行鉴权
            const string sql = "select A.ActionId from Sys_RolePerm_Action A join Get_PermRole(@UserId, @DeptId) R on R.RoleId = A.RoleId and A.ActionId = @ActionId group by A.ActionId having min(A.Action) > 0";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = obj.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = obj.DeptId},
                new SqlParameter("@ActionId", SqlDbType.UniqueIdentifier) {Value = actionId}
            };
            return SqlScalar(MakeCommand(sql, parm)) != null;
        }

    }
}
