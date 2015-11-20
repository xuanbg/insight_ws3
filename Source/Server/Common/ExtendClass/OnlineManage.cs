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
        /// 合法机器码
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

            var us = Sessions[obj.ID];
            var sm = SafeMachine[obj.ID];
            var result = false;

            // 1天后重置连续失败次数
            var time = DateTime.Now - us.LastConnect;
            if (us.FailureCount > 0 && time.TotalDays > 1)
            {
                us.FailureCount = 0;
            }

            if ((us.FailureCount > 5 && obj.MachineId != sm) || us.Signature != obj.Signature || !us.Validity)
            {
                us.FailureCount += 1;
            }
            else
            {
                us.FailureCount = 0;
                result = true;
            }

            us.LastConnect = DateTime.Now;
            return result;
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj, string action)
        {
            if (!Verification(obj)) return false;

            const string sql = "select A.ActionId from Sys_RolePerm_Action A join Get_PermRole(@UserId, @DeptId) R on R.RoleId = A.RoleId and A.ActionId = @ActionId group by A.ActionId having min(A.Action) > 0";
            var parm = new[]
            {
                new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) {Value = obj.UserId},
                new SqlParameter("@DeptId", SqlDbType.UniqueIdentifier) {Value = obj.DeptId},
                new SqlParameter("@ActionId", SqlDbType.UniqueIdentifier) {Value = Guid.Parse(action)}
            };
            return SqlScalar(MakeCommand(sql, parm)) != null;
        }

    }
}
