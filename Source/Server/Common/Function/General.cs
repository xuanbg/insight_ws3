using System;
using System.Linq;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Server.Common
{
    public class General
    {

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="action">是否验证即失效</param>
        /// <returns>bool 是否正确</returns>
        public static bool CodeVerify(string number, string code, int type, bool action = true)
        {
            using (var context = new WSEntities())
            {
                var list = context.SYS_Verify_Record.Where(c => c.Mobile == number && c.Type == type && !c.Verified).ToList();
                if (list.Count == 0 || !(list.Exists(c => c.Code == code && c.FailureTime > DateTime.Now))) return false;

                if (!action) return true;

                foreach (var record in list)
                {
                    record.Verified = true;
                    record.VerifyTime = DateTime.Now;
                }
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public static Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            var us = OnlineManage.GetSession(obj);
            obj.ID = us.ID;
            if (us.LoginStatus == LoginResult.Unauthorized || us.LoginStatus == LoginResult.NotExist) return us;

            // 用户被封禁
            if (!us.Validity)
            {
                us.LoginStatus = LoginResult.Banned;
                return us;
            }

            // 未通过签名验证
            if (!OnlineManage.Verification(obj))
            {
                us.LoginStatus = LoginResult.Failure;
                return us;
            }

            // 当前是否已登录或未正常退出
            if (us.SessionId == Guid.Empty)
            {
                OnlineManage.UpdateSession(obj);
                us.LoginStatus = LoginResult.Success;
            }
            else
            {
                us.LoginStatus = us.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
            }

            return us;
        }

    }
}
