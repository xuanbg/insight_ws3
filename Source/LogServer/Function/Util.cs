using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.Samples.GZipEncoder;
using System.Threading;
using System.Web.Script.Serialization;
using Insight.WS.Log.Service;

namespace Insight.WS.Log
{
    public static class Util
    {

        #region 成员属性

        /// <summary>
        /// 安全码
        /// </summary>
        public const string Secret = "842A381C91CE43A98720825601C22A56";

        /// <summary>
        /// 访问验证服务用的Binding
        /// </summary>
        private static readonly Binding Binding = new NetTcpBinding();

        /// <summary>
        /// 访问验证服务用的Address
        /// </summary>
        private static readonly EndpointAddress Address = new EndpointAddress(GetAppSetting("IvsAddress"));

        /// <summary>
        /// 最大接收消息大小（字节）
        /// </summary>
        private const int MaxReceivedMessageSize = 1073741824;

        /// <summary>
        /// 最大数组长度
        /// </summary>
        private const int MaxArrayLength = 67108864;

        /// <summary>
        /// 最大字符串长度
        /// </summary>
        private const int MaxStringContentLength = 67108864;

        /// <summary>
        /// 发送超时（秒）
        /// </summary>
        private const int SendTimeout = 600;

        /// <summary>
        /// 接收超时（秒）
        /// </summary>
        private const int ReceiveTimeout = 600;

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        public static ServiceHost Host;

        /// <summary>
        /// 日志规则列表
        /// </summary>
        public static List<SYS_Logs_Rules> Rules;

        /// <summary>
        /// 进程同步基元
        /// </summary>
        public static readonly Mutex Mutex = new Mutex();

        #endregion

        #region 静态公共方法

        /// <summary>
        /// 创建服务主机
        /// </summary>
        public static void CreateHost()
        {
            var transport = new HttpTransportBindingElement
            {
                ManualAddressing = true,
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                TransferMode = TransferMode.Streamed
            };
            var encoder = new WebMessageEncodingBindingElement
            {
                ReaderQuotas = {MaxArrayLength = MaxArrayLength, MaxStringContentLength = MaxStringContentLength},
                ContentTypeMapper = new TypeMapper()
            };
            var gZipEncode = new GZipMessageEncodingBindingElement(encoder);
            var binding = new CustomBinding
            {
                SendTimeout = TimeSpan.FromSeconds(SendTimeout),
                ReceiveTimeout = TimeSpan.FromSeconds(ReceiveTimeout),
                Elements = {gZipEncode, transport}
            };

            var address = new Uri(GetAppSetting("Address"));
            Host = new ServiceHost(typeof (LogManage), address);
            var endpoint = Host.AddServiceEndpoint(typeof (Interface), binding, "LogServer");
            endpoint.Behaviors.Add(new WebHttpBehavior());
        }

        /// <summary>
        /// 读取配置项的值
        /// </summary>
        /// <param name="key">配置项</param>
        /// <returns>配置项的值</returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 计算字符串的Hash值
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>String Hash值</returns>
        public static string Hash(string str)
        {
            var md5 = MD5.Create();
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(str.Trim()));
            return s.Aggregate("", (current, c) => current + c.ToString("X2"));
        }

        /// <summary>
        /// 通过Session校验是否有权限访问
        /// </summary>
        /// <param name="session">用户会话</param>
        /// <param name="aid">操作ID</param>
        /// <returns></returns>
        public static JsonResult Verify(out Session session, string aid)
        {
            session = GetAuthorization<Session>();
            var result = new JsonResult();
            if (session == null) return result.InvalidAuth();

            return Verification(session, aid) ? result.Success() : result.InvalidAuth();
        }

        /// <summary>
        /// 通过指定的Rule校验是否有权限访问
        /// </summary>
        /// <returns>JsonResult</returns>
        public static JsonResult Verify(string rule)
        {
            var result = new JsonResult();
            var obj = GetAuthorization<string>();
            return obj != Hash(rule) ? result.InvalidAuth() : result.Success();
        }

        /// <summary>
        /// 将一个对象序列化为Json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns>string Json字符串</returns>
        public static string Serialize<T>(T obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        #endregion

        #region 静态私有方法

        /// <summary>
        /// 获取Authorization承载的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns>数据对象</returns>
        private static T GetAuthorization<T>()
        {
            var woc = WebOperationContext.Current;
            var auth = woc.IncomingRequest.Headers[HttpRequestHeader.Authorization];
            if (string.IsNullOrEmpty(auth))
            {
                woc.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return default(T);
            }

            SetResponseParam();
            try
            {
                var buffer = Convert.FromBase64String(auth);
                var json = Encoding.UTF8.GetString(buffer);
                return Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                var log = new SYS_Logs
                {
                    Code = "300001",
                    Level = 3,
                    Source = "日志服务",
                    Action = "身份验证",
                    Message = ex.ToString(),
                    CreateTime = DateTime.Now
                };
                DataAccess.WriteToFile(log);
                woc.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return default(T);
            }
        }

        /// <summary>
        /// 将一个Json字符串反序列化为指定类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns>T 反序列化的对象</returns>
        private static T Deserialize<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
        }

        /// <summary>
        /// 设置Response参数
        /// </summary>
        private static void SetResponseParam()
        {
            var response = WebOperationContext.Current.OutgoingResponse;
            response.Headers[HttpResponseHeader.ContentEncoding] = "gzip";
            response.ContentType = "application/x-gzip";
        }

        /// <summary>
        /// 会话合法性验证，用于持久化客户端
        /// </summary>
        /// <param name="obj">用户会话</param>
        /// <param name="aid">操作ID</param>
        /// <returns>bool 是否成功</returns>
        private static bool Verification(Session obj, string aid)
        {
            using (var client = new InterfaceClient(Binding, Address))
            {
                return client.Authorization(obj, aid);
            }
        }

        #endregion

    }


    /// <summary>
    /// WebContentTypeMapper
    /// </summary>
    public class TypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Json;
        }

    }

    /// <summary>
    /// 日志等级
    /// </summary>
    public enum Level
    {
        Emergency,
        Alert,
        Critical,
        Error,
        Warning,
        Notice,
        Informational,
        Debug
    }
}
