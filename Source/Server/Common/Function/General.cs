using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using FastReport;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.Service;
using static Insight.WS.Server.Common.DataAccess;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Server.Common
{
    public class General
    {
        private static readonly int CompatibleVersion = Convert.ToInt32(GetAppSetting("CompatibleVersion"));
        private static readonly int UpdateVersion = Convert.ToInt32(GetAppSetting("UpdateVersion"));
        private static readonly Binding Binding = new NetTcpBinding();
        private static readonly EndpointAddress Address = new EndpointAddress(GetAppSetting("IvsAddress"));
        private static readonly List<VerifyRecord> SmsCodes = new List<VerifyRecord>();

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="type">验证码类型</param>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="time">有效时间（分钟）</param>
        /// <returns>string 验证码</returns>
        public static void GetVerifyCode(int type, string phone, string code, int time)
        {
            var record = new VerifyRecord
            {
                Type = type,
                Mobile = phone,
                Code = code,
                FailureTime = DateTime.Now.AddMinutes(time)
            };
            SmsCodes.Add(record);
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="number">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="type">验证码类型</param>
        /// <param name="action">是否验证即失效</param>
        /// <returns>bool 是否正确</returns>
        public static bool VerifyCode(string number, string code, int type, bool action = true)
        {
            var list = SmsCodes.Where(c => c.Mobile == number && c.Type == type && c.FailureTime > DateTime.Now).ToList();
            if (list.Count <= 0) return false;

            if (!action) return true;

            return SmsCodes.RemoveAll(c => c.Mobile == number && c.Type == type) > 0;
        }

        /// <summary>
        /// 获取用户登录结果
        /// </summary>
        /// <param name="obj">Session对象实体</param>
        /// <returns>Session对象实体</returns>
        public static Session UserLogin(Session obj)
        {
            if (obj == null) return null;

            var us = GetSession(obj);
            if (us == null) return null;

            // 用户被封禁
            if (!us.Validity)
            {
                us.LoginResult = LoginResult.Banned;
                return us;
            }

            // 未通过签名验证
            obj.ID = us.ID;
            if (!SimpleVerifty(obj))
            {
                us.LoginResult = LoginResult.Failure;
                return us;
            }

            // 当前是否已登录或未正常退出
            if (us.OnlineStatus)
            {
                us.LoginResult = us.MachineId != obj.MachineId ? LoginResult.Online : LoginResult.Multiple;
            }
            else
            {
                SetOnlineStatus(us.ID, true);
                UpdateSession(obj);
                us.LoginResult = LoginResult.Success;
            }

            return us;
        }

        /// <summary>
        /// 校验是否有权限访问
        /// </summary>
        /// <returns></returns>
        public static JsonResult Verify()
        {
            var obj = GetAuthorization<Session>();
            if (obj == null) return null;

            var result = new JsonResult();
            if (obj.Version < CompatibleVersion || obj.Version > UpdateVersion)
            {
                result.Code = "400";
                result.Name = "IncompatibleVersions";
                result.Message = "客户端版本不兼容";
                return result;
            }

            var us = Verification(obj);
            switch (us.LoginResult)
            {
                case LoginResult.Success:
                    result.Successful = true;
                    result.Code = "200";
                    result.Name = "OK";
                    result.Message = "接口调用成功";
                    break;

                case LoginResult.NotExist:
                    result.Successful = true;
                    result.Code = "300";
                    result.Name = "SessionExpired";
                    result.Message = "Session过期，请更新Session";
                    break;

                case LoginResult.Failure:
                    result.Code = "401";
                    result.Name = "InvalidAuthenticationInfo";
                    result.Message = "提供的身份验证信息不正确";
                    break;

                case LoginResult.Banned:
                    result.Code = "403";
                    result.Name = "AccountIsDisabled";
                    result.Message = "当前用户被禁止登录";
                    break;

                default:
                    result.Code = "500";
                    result.Name = "UnknownError";
                    result.Message = "未知错误";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取Authorization承载的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>数据对象</returns>
        public static T GetAuthorization<T>()
        {
            var woc = WebOperationContext.Current;
            var auth = woc.IncomingRequest.Headers[HttpRequestHeader.Authorization];
            if (string.IsNullOrEmpty(auth))
            {
                woc.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return default(T);
            }

            SetResponseParam();
            var buffer = Convert.FromBase64String(auth);
            var json = Encoding.UTF8.GetString(buffer);
            return Deserialize<T>(json);
        }

        /// <summary>
        /// 获取当前在线状态的全部内部用户的Session
        /// </summary>
        /// <returns>全部内部用户的Session</returns>
        public static List<Session> GetSessions()
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.GetSessions();
            }
        }

        /// <summary>
        /// 获取验证服务器上的用户会话
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>Session 用户会话</returns>
        public static Session GetSession(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.GetSession(obj);
            }
        }

        /// <summary>
        /// 更新用户Session数据
        /// </summary>
        /// <param name="obj">传入的用户Session</param>
        public static void UpdateSession(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                client.UpdateSession(obj);
            }
        }

        /// <summary>
        /// 更新指定用户Session的签名
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="pw">密码MD5值</param>
        public static bool UpdateSignature(int index, string pw)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.UpdateSignature(index, pw);
            }
        }

        /// <summary>
        /// 设置指定用户Session的登录状态
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="status">在线状态</param>
        public static bool SetOnlineStatus(int index, bool status)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.SetOnlineStatus(index, status);
            }
        }

        /// <summary>
        /// 根据用户ID设置用户状态
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="validity">用户状态</param>
        public static bool SetUserStatus(Guid uid, bool validity)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.SetUserStatus(uid, validity);
            }
        }

        /// <summary>
        /// 会话合法性验证，用于持久化客户端
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static Session Verification(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.Verification(obj);
            }
        }

        /// <summary>
        /// 简单会话合法性验证，用于非持久化客户端
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <returns>bool 是否成功</returns>
        public static bool SimpleVerifty(Session obj)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.SimpleVerifty(obj);
            }
        }

        /// <summary>
        /// 带鉴权的会话合法性验证
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="action">需要鉴权的操作ID</param>
        /// <returns>bool 是否成功</returns>
        public static bool Verification(Session obj, string action)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.Authorization(obj, action);
            }
        }

        /// <summary>
        /// 获取任务、生成报表并保存
        /// </summary>
        /// <returns>bool 是否完成当前任务</returns>
        public static bool BuildReport()
        {
            var time = DateTime.Now;
            LogToEvent($"报表生成任务已经于{time}启动…", EventLogEntryType.Information);
            var task = GetTask();
            var obj = new List<SYS_Report_Instances>();
            string temp = null;
            var i = 0;

            foreach (var s in task)
            {
                temp = temp ?? GetTemplate(s.TemplateId).Content;
                obj.Add(BulidReport(s.ReportId, s.StartDate, s.EndDate, s.DeptName, "Insight WS", s.DeptId, s.UserId, temp));
                i++;
                if (i < task.Count && s.SchedularId == task[i].SchedularId) continue;

                SaveInstances(obj, s.NextDate, s.SchedularId);
                obj.Clear();
                temp = null;
            }
            LogToEvent($"本次报表生成任务已经于{DateTime.Now}完成！共耗时：{(DateTime.Now - time).Seconds}秒。", EventLogEntryType.Information);
            return true;
        }

        /// <summary>
        /// 生成报表实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sd">开始日期</param>
        /// <param name="ed">截止日期</param>
        /// <param name="dn">会计主体名称</param>
        /// <param name="un">制表人名称</param>
        /// <param name="did">会计主体ID</param>
        /// <param name="uid">用户ID</param>
        /// <param name="templat"></param>
        /// <returns>SYS_Report_Instances 报表实例对象实体</returns>
        public static SYS_Report_Instances BulidReport(Guid id, DateTime? sd, DateTime? ed, string dn, string un, Guid did, Guid? uid, string templat = null)
        {
            var report = GetDefinition(id);
            var conStr = SqlHelper.ConStr[report.DataSource];
            var name = $"{dn}【{report.Name}】{sd?.ToShortDateString() ?? ""}—{ed?.ToShortDateString() ?? ""}";
            var fr = new Report();

            fr.LoadFromString(templat ?? GetTemplate(report.TemplateId).Content);

            if (conStr != null) fr.Dictionary.Connections[0].ConnectionString = conStr;

            fr.SetParameterValue("StartDate", sd);
            fr.SetParameterValue("EndDate", ed);
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did.ToString());
            fr.SetParameterValue("UserId", uid?.ToString());

            if (!fr.Prepare()) return null;

            var stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            var instance = new SYS_Report_Instances
            {
                ReportId = id,
                Name = name.Replace("-", "/").Replace("/", "."),
                Content = bytes,
                CreatorUserId = uid
            };
            return instance;
        }

        /// <summary>
        /// 根据指定报表模板生成业务电子影像
        /// </summary>
        /// <param name="id">业务ID</param>
        /// <param name="templetId">报表模板ID</param>
        /// <param name="dn"></param>
        /// <param name="un"></param>
        /// <param name="did"></param>
        /// <param name="uid"></param>
        /// <param name="obj"></param>
        /// <returns>ImageData 电子影像对象实体</returns>
        public static ImageData BuildImage(Guid id, Guid templetId, string dn, string un, Guid? did, Guid uid, ImageData obj)
        {
            var img = obj ?? new ImageData();
            var fr = new Report();

            fr.LoadFromString(GetTemplate(templetId).Content);
            fr.Dictionary.Connections[0].ConnectionString = SqlHelper.ConStr["WSEntities"];
            fr.SetParameterValue("BusinessId", id.ToString());
            fr.SetParameterValue("DeptName", dn);
            fr.SetParameterValue("UserName", un);
            fr.SetParameterValue("DeptId", did?.ToString());
            fr.SetParameterValue("UserId", uid.ToString());
            if (!fr.Prepare()) return img;

            Stream stream = new MemoryStream();
            fr.SavePrepared(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            img.Name = id.ToString();
            img.Expand = "fpx";
            img.Pages = fr.PreparedPages.Count;
            img.Size = stream.Length;
            img.Image = bytes;
            return img;
        }

    }
}
