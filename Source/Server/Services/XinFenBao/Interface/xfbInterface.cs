using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.XinFenBao
{
    public class XfbInterface:IXfbInterface
    {

        /// <summary>
        /// 获取省数据
        /// </summary>
        /// <returns>省数据集合</returns>
        public List<States> GetStates()
        {
            using (var context = new WSEntities())
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
            using (var context = new WSEntities())
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
            using (var context = new WSEntities())
            {
                return context.Countys.Where(c => c.CategoryId == cityId).ToList();
            }
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

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public Session UserLogin(Session obj)
        {
            return CommonDAL.UserLogin(obj);
        }

    }
}
