using System;
using System.Collections.Generic;
using System.Configuration;

namespace Insight.WS.Server.Common
{
    public class OnlineManage
    {

        /// <summary>
        /// 用户会话列表
        /// </summary>
        public static List<Session> Sessions { get; set; }

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
            MaxAuthorized = Convert.ToInt32(ConfigurationManager.AppSettings["MaxAuthorized"]);
        }

        /// <summary>
        /// 会话合法性验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool Verification(Session obj)
        {
            if (obj == null) return false;

            var us = Sessions.Find(s => s.UserId == obj.UserId);
            if (us == null || us.Signature != obj.Signature) return false;

            us.LastConnect = DateTime.Now;
            return true;
        }

    }
}
