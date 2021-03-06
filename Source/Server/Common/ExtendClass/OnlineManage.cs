﻿using System;
using System.Collections.Generic;

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
        /// <param name="obj"></param>
        /// <returns></returns>
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

    }
}
