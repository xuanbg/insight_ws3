using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using FastReport;
using Insight.WS.Server.Common.ORM;
using static Insight.WS.Server.Common.DataAccess;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Server.Common
{
    public class General
    {

        #region 接口验证

        public static bool SimpleVerifty(Session session)
        {
            return true;
        }
        public static bool Verification(Session session, string code)
        {
            return true;
        }

        /// <summary>
        /// 通过Session校验是否有权限访问
        /// </summary>
        /// <returns>JsonResult</returns>
        public static JsonResult Verify()
        {
            Session obj;
            return Verify(out obj);
        }

        /// <summary>
        /// 通过Session校验是否有权限访问
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <returns></returns>
        public static JsonResult Verify(out Session session)
        {
            var url = VerifyServer + "verify";
            var dict = GetAuthorization();
            var auth = dict["Auth"];
            session = GetAuthor<Session>(auth);
            return HttpRequest(url, "GET", auth);
        }

        /// <summary>
        /// 通过指定的Rule校验是否有权限访问
        /// </summary>
        /// <returns>JsonResult</returns>
        public static JsonResult Verify(string rule)
        {
            var result = new JsonResult();
            var dict = GetAuthorization();
            var key = GetAuthor<string>(dict["Auth"]);
            return key == Hash(rule) ? result.Success() : result.InvalidAuth();
        }

        #endregion  

        #region Report

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

        #endregion

        #region 常用方法

        /// <summary>
        /// 获取Http请求头部承载的验证信息
        /// </summary>
        /// <returns>string Http请求头部承载的验证字符串</returns>
        public static Dictionary<string, string> GetAuthorization()
        {
            var context = WebOperationContext.Current;
            if (context == null) return null;

            var headers = context.IncomingRequest.Headers;
            var response = context.OutgoingResponse;
            if (!CompareVersion(headers))
            {
                response.StatusCode = HttpStatusCode.NotAcceptable;
                return null;
            }

            var auth = headers[HttpRequestHeader.Authorization];
            if (string.IsNullOrEmpty(auth))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }

            var accept = headers[HttpRequestHeader.Accept];
            var val = accept.Split(Convert.ToChar(";"));
            return new Dictionary<string, string>
            {
                {"Auth", auth},
                {"Version", val[1].Substring(9)},
                {"Client", val[2].Substring(8)}
            };
        }

        /// <summary>
        /// 获取Authorization承载的数据
        /// </summary>
        /// <param name="auth">验证信息</param>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>数据对象</returns>
        public static T GetAuthor<T>(string auth)
        {
            try
            {
                var buffer = Convert.FromBase64String(auth);
                var json = Encoding.UTF8.GetString(buffer);
                return Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                LogToLogServer("508001", ex.ToString());
                return default(T);
            }
        }

        /// <summary>
        /// HttpRequest方法
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="method">请求的方法：GET,PUT,POST,DELETE</param>
        /// <param name="author">接口认证数据</param>
        /// <param name="data">接口参数</param>
        /// <returns>JsonResult</returns>
        public static JsonResult HttpRequest(string url, string method, string author, string data = "")
        {
            var request = GetWebRequest(url, method, author);
            if (method == "GET") return GetResponse(request);

            var buffer = Encoding.UTF8.GetBytes(data);
            request.ContentLength = buffer.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(buffer, 0, buffer.Length);
            }

            return GetResponse(request);
        }

        /// <summary>
        /// 将事件消息写到日志服务器
        /// </summary>
        /// <param name="code">事件代码</param>
        /// <param name="message">事件消息</param>
        public static void LogToLogServer(string code, string message = null)
        {
            LogToLogServer(code, message, null, null);
        }

        /// <summary>
        /// 将事件消息写到日志服务器
        /// </summary>
        /// <param name="code">事件代码</param>
        /// <param name="message">事件消息</param>
        /// <param name="source">事件来源</param>
        /// <param name="action">操作名称</param>
        public static void LogToLogServer(string code, string message, string source, string action)
        {
            LogToLogServer(code, message, source, action, null, null);
        }

        /// <summary>
        /// 将事件消息写到日志服务器
        /// </summary>
        /// <param name="code">事件代码</param>
        /// <param name="message">事件消息</param>
        /// <param name="source">事件来源</param>
        /// <param name="action">操作名称</param>
        /// <param name="userid">源用户ID</param>
        /// <param name="key">查询关键字段</param>
        public static void LogToLogServer(string code, string message, string source, string action, string userid, string key)
        {
            var url = LogServer + "logs";
            var dict = new Dictionary<string, string>
            {
                {"code", code},
                {"message", message},
                {"source", source },
                {"action", action },
                {"userid", userid },
                {"key", key }
            };
            var data = Serialize(dict);
            var author = Base64(Hash(code + Secret));
            HttpRequest(url, "POST", author, data);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取WebRequest对象
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="method">请求的方法：GET,PUT,POST,DELETE</param>
        /// <param name="author">接口认证数据</param>
        /// <returns>HttpWebRequest</returns>
        private static HttpWebRequest GetWebRequest(string url, string method, string author)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = $"application/json; version={CurrentVersion}; client=MallServer";
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, author);

            return request;
        }

        /// <summary>
        /// 获取Request响应数据
        /// </summary>
        /// <param name="request">WebRequest</param>
        /// <returns>JsonResult</returns>
        private static JsonResult GetResponse(WebRequest request)
        {
            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return new JsonResult().BadRequest();

                using (var reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                {
                    var result = reader.ReadToEnd();
                    responseStream.Close();
                    return Deserialize<JsonResult>(result);
                }
            }
            catch (Exception ex)
            {
                LogToEvent(ex.ToString());
                return new JsonResult().BadRequest();
            }
        }

        /// <summary>
        /// 验证版本是否兼容
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        private static bool CompareVersion(WebHeaderCollection headers)
        {
            var accept = headers[HttpRequestHeader.Accept];
            if (accept == null) return false;

            var val = accept.Split(Convert.ToChar(";"));
            if (accept.Length < 3) return false;

            var ver = Convert.ToInt32(val[1].Substring(9));
            return ver >= Convert.ToInt32(CompatibleVersion) && ver <= Convert.ToInt32(UpdateVersion);
        }

        #endregion

    }
}
