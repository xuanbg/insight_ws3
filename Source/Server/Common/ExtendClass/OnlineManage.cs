using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Insight.WS.Server.Common.SqlHelper;

namespace Insight.WS.Server.Common
{
    public class OnlineManage
    {

        /// <summary>
        /// 用户会话列表
        /// </summary>
        public static List<Session> Sessions { get; set; }

        /// <summary>
        /// 用户安全设备码列表
        /// </summary>
        public static List<string> SafeMachine { get; set; }

        /// <summary>
        /// 最大在线用户数
        /// </summary>
        public static int MaxAuthorized { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public OnlineManage()
        {
            Sessions = new List<Session>();
            SafeMachine = new List<string>();
            MaxAuthorized = Convert.ToInt32(Util.GetAppSetting("MaxAuthorized"));
        }

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj)
        {
            if (obj == null || obj.ID >= Sessions.Count) return false;

            // 用户被封禁，不能通过验证
            var us = Sessions[obj.ID];
            if (!us.Validity) return false;

            // 1天后重置连续失败次数
            if (us.FailureCount > 0 && (DateTime.Now - us.LastConnect).TotalDays > 1)
            {
                us.FailureCount = 0;
            }

            // 连续签名错误超过5次（冒用时），不能通过验证
            us.LastConnect = DateTime.Now;
            if (us.FailureCount >= 5 && obj.MachineId != SafeMachine[obj.ID]) return false;

            // 签名正确时，通过验证且错误计数清零；不正确则不能通过验证，且连续失败计数累加1次
            if (us.Signature == obj.Signature)
            {
                us.FailureCount = 0;
                return true;
            }

            us.FailureCount ++;
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
