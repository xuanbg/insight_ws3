using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
namespace Insight.WS.Log
{
    public static class Util
    {

        #region 成员属性

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
        private static readonly Mutex Mutex = new Mutex();

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
        /// 在启用Gzip压缩时设置Response参数
        /// </summary>
        public static void SetResponseParam()
        {
            var response = WebOperationContext.Current.OutgoingResponse;
            response.Headers[HttpResponseHeader.ContentEncoding] = "gzip";
            response.ContentType = "application/x-gzip";
        }

        /// <summary>
        /// 从数据库加载日志规则到缓存
        /// </summary>
        public static void ReadRule()
        {
            using (var context = new WSEntities())
            {
                Rules = context.SYS_Logs_Rules.ToList();
            }
        }

        /// <summary>
        /// 将日志写入数据库
        /// </summary>
        /// <param name="log"></param>
        public static void WriteToDB(SYS_Logs log)
        {
            using (var context = new WSEntities())
            {
                context.SYS_Logs.Add(log);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 将日志写入文件
        /// </summary>
        /// <param name="log"></param>
        public static void WriteToFile(SYS_Logs log)
        {
            Mutex.WaitOne();
            var path = $"{GetAppSetting("LogLocal")}\\{GetLevelName(log.Level)}\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += $"{DateTime.Today.ToString("yyyy-MM-dd")}.log";
            var time = log.CreateTime.ToString("O");
            var text = $"[{log.CreateTime.Kind} {time}] [{log.Code}] [{log.Source}] [{log.Action}] Message:{log.Message}\r\n";
            var buffer = Encoding.UTF8.GetBytes(text);
            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(buffer, 0, buffer.Length);
            }
            Mutex.ReleaseMutex();
        }

        /// <summary>
        /// 获取事件等级名称
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private static string GetLevelName(int level)
        {
            var name = (Level) level;
            return name.ToString();
        }

    }

    #endregion

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
