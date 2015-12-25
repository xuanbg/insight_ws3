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
            if (session == null) return null;

            // 用户被封禁
            if (!session.Validity)
            {
                obj.LoginResult = LoginResult.Banned;
                return obj;
            }

            // 未通过签名验证
            obj.ID = session.ID;
            if (!SimpleVerifty(obj))
            {
                obj.LoginResult = LoginResult.Failure;
                return obj;
            }

            // 当前是否已登录或未正常退出
            if (session.OnlineStatus)
            {
                session.LoginResult = session.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
            }
            else
            {
                session.LoginResult = LoginResult.Success;
                session.OnlineStatus = true;
                SetOnlineStatus(session);
                UpdateSession(obj);
            }

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
        /// <param name="signature">新的签名</param>
        public void UpdateSignature(Session obj, string signature)
        {
            if (!SimpleVerifty(obj)) return;

            Sessions[obj.ID].Signature = signature;
        }

        /// <summary>
        /// 设置指定用户Session的登录状态
        /// </summary>
        /// <param name="obj">用户会话</param>
        public void SetOnlineStatus(Session obj)
        {
            if (!SimpleVerifty(obj)) return;

            Sessions[obj.ID].OnlineStatus = obj.OnlineStatus;
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
            if (!SimpleVerifty(obj)) return false;

            var session = Sessions.SingleOrDefault(s => s.UserId == uid);
            if (session == null) return false;

            session.Validity = validity;
            return true;
        }

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话信息</returns>
        public Session Verification(Session obj)
        {
            if (obj == null) return null;

            // 不在在线用户列表中（下标溢出）
            if (obj.ID >= Sessions.Count) return Verify(obj);

            var session = Sessions[obj.ID];

            // 不在在线用户列表中（ID不匹配）
            if (session.UserId != obj.UserId) return Verify(obj);

            // 用户被封禁
            if (!session.Validity)
            {
                obj.LoginResult = LoginResult.Banned;
                return obj;
            }

            // 验证签名失败计数清零（距上次用户签名验证时间超过1小时）
            if (session.FailureCount > 0 && (DateTime.Now - session.LastConnect).TotalHours > 1)
            {
                session.FailureCount = 0;
            }
            session.LastConnect = DateTime.Now;

            // 签名正确时，通过验证且错误计数清零；不正确或验证签名失败超过5次（冒用时）则不能通过验证，且连续失败计数累加1次
            if (session.Signature == obj.Signature && (session.FailureCount < 5 || session.MachineId == obj.MachineId))
            {
                session.FailureCount = 0;
                obj.LoginResult = LoginResult.Success;
                return obj;
            }

            session.FailureCount ++;
            obj.LoginResult = LoginResult.Failure;
            return obj;
        }

        /// <summary>
        /// 简单会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public bool SimpleVerifty(Session obj)
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

            // 签名正确时，通过验证且错误计数清零；不正确则不能通过验证，且连续失败计数累加1次
            if (session.Signature == obj.Signature && (session.FailureCount < 5 || session.MachineId == obj.MachineId))
            {
                session.FailureCount = 0;
                return true;
            }

            session.FailureCount++;
            return false;
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
            if (!SimpleVerifty(obj)) return false;

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
        /// 更新用户Session数据
        /// </summary>
        /// <param name="obj">用户会话</param>
        private void UpdateSession(Session obj)
        {
            var session = Sessions[obj.ID];
            session.DeptId = obj.DeptId;
            session.DeptName = obj.DeptName;
            session.Version = obj.Version;
            session.ClientType = obj.ClientType;
            session.MachineId = obj.MachineId;
        }

        /// <summary>
        /// 在线用户列表未找到数据时的验证方法
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        private Session Verify(Session obj)
        {
            var us = GetSession(obj);

            // 用户不存在或签名不一致，登录状态标记为失败，返回传入对象
            if (us == null || us.Signature != obj.Signature)
            {
                obj.LoginResult = LoginResult.Failure;
                return obj;
            }

            // 登录状态标记为离线，返回在线列表中对象
            us.LoginResult = LoginResult.NotExist;
            return us;
        }

        /// <summary>
        /// 获取用户Session
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
