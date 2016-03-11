﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using Insight.WS.Server.Common.Entity;
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
        /// <returns></returns>
        public static JsonResult Verify()
        {
            Session session;
            return Verify(out session);
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

        #region 常用方法

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
        /// 获取Http请求头部承载的验证信息
        /// </summary>
        /// <returns>string Http请求头部承载的验证字符串</returns>
        private static Dictionary<string, string> GetAuthorization()
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
        private static T GetAuthor<T>(string auth)
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
