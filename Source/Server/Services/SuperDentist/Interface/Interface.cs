using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web.Script.Serialization;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

namespace Insight.WS.Service.SuperDentist
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Interface : IInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        public Session Login(Session obj)
        {
            return General.UserLogin(obj);
        }


        public JsonResult GetUsers()
        {
            var result = new JsonResult {Successful = true, Code = "000"};
            using (var context = new WSEntities())
            {
                var user = context.SYS_User.FirstOrDefault();
                if (user == null)
                {
                    result.Successful = false;
                    result.Code = "400";
                    result.Message = "没有读取到任何SYS_User对象";
                }
                else
                {
                    result.Data = new JavaScriptSerializer().Serialize(user);
                }
            }
            return result;
        }

    }

    public class JsonResult
    {
        [DataMember]
        public bool Successful { get ; set;}

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public string Data { get; set; } 
    }
}
