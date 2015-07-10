using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common;

namespace Insight.WS.Service.XinFenBao
{
    class XfbInterface:IXfbInterface
    {

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据集合</returns>
        public List<States> GetStates()
        {
            using (var context = new ws_Entities())
            {
                return context.States.ToList();
            }
        }

        /// <summary>
        /// 根据省ID获取地市数据
        /// </summary>
        /// <param name="stateId">省ID</param>
        /// <returns>地市数据集合</returns>
        public List<Citys> GetCitys(Guid stateId)
        {
            using (var context = new ws_Entities())
            {
                return context.Citys.Where(c => c.ParentId == stateId).ToList();
            }
        }

        /// <summary>
        /// 根据地市ID获取县市数据
        /// </summary>
        /// <param name="cityId">地市ID</param>
        /// <returns>县市数据集合</returns>
        public List<Countys> GetCountys(Guid cityId)
        {
            using (var context = new ws_Entities())
            {
                return context.Countys.Where(c => c.CategoryId == cityId).ToList();
            }
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            if (OnlineManage.Sessions.Count >= OnlineManage.MaxAuthorized)
            {
                obj.LoginStatus = LoginResult.Unauthorized;
                return obj;
            }

            var isSafe = true;
            var pw = obj.Signature;
            var us = OnlineManage.Sessions.Find(s => s.LoginName == obj.LoginName);
            if (us == null)
            {
                var user = CommonDAL.GetUser(obj.LoginName);
                if (user == null)
                {
                    obj.LoginStatus = LoginResult.NotExist;
                    return obj;
                }

                obj.ID = OnlineManage.Sessions.Count;
                obj.UserId = user.ID;
                obj.UserName = user.Name;
                obj.Signature = user.Password;
                obj.FailureCount = 0;
                obj.Validity = user.Validity;

                OnlineManage.Sessions.Add(obj);
                OnlineManage.SafeMachine.Add(null);
                us = OnlineManage.Sessions[obj.ID];
            }
            else
            {
                if (us.FailureCount > 4)
                {
                    isSafe = us.MachineId != obj.MachineId && obj.MachineId == OnlineManage.SafeMachine[us.ID];
                }

                if (us.SessionId == Guid.Empty)
                {
                    us.SessionId = obj.SessionId;
                    us.MachineId = obj.MachineId;
                    us.LoginStatus = LoginResult.Success;
                }
                else
                {
                    us.LoginStatus = us.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
                }
            }

            // 10分钟后重置连续失败次数
            var time = DateTime.Now - us.LastConnect;
            if (us.FailureCount > 0 && time.TotalMinutes > 10)
            {
                us.FailureCount = 0;
            }

            if (!us.Validity)
            {
                us.LoginStatus = LoginResult.Banned;
            }
            else if (us.Signature != pw || !isSafe)
            {
                us.FailureCount += 1;
                us.LoginStatus = LoginResult.Failure;
                if (us.MachineId == obj.MachineId)
                {
                    us.SessionId = Guid.Empty;
                }
            }
            else
            {
                OnlineManage.SafeMachine[us.ID] = us.MachineId;
            }

            us.LastConnect = DateTime.Now;
            return us;
        }

        /// <summary>
        /// 获取用户Session对象实体
        /// </summary>
        /// <param name="ln">登录账号</param>
        /// <param name="pw">登录密码</param>
        /// <returns>Session 用户Session对象实体</returns>
        public Session GetSession(string ln, string pw)
        {
            return OnlineManage.Sessions.Find(s => s.LoginName == ln && s.Signature == pw);
        }

    }
}
