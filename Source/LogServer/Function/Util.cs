using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using Microsoft.Samples.GZipEncoder;

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

    }

    #endregion


    public class TypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Json;
        }

    }

}
