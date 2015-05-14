using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Samples.GZipEncoder;

namespace Insight.WS.Server.Common
{
    public class Services
    {

        #region 成员属性

        /// <summary>
        /// 服务绑定
        /// </summary>
        public dynamic Binding { get; set; }

        /// <summary>
        /// 服务基地址
        /// </summary>
        public Uri BaseAddress { get; set; }

        /// <summary>
        /// 最大接收消息大小（字节）
        /// </summary>
        public int MaxReceivedMessageSize { get; set; }

        /// <summary>
        /// 最大数组长度
        /// </summary>
        public int MaxArrayLength { get; set; }

        /// <summary>
        /// 最大字符串长度
        /// </summary>
        public int MaxStringContentLength { get; set; }

        /// <summary>
        /// 发送超时（秒）
        /// </summary>
        public int SendTimeout { get; set; }

        /// <summary>
        /// 接收超时（秒）
        /// </summary>
        public int ReceiveTimeout { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造Services对象
        /// </summary>
        public Services()
        {

        }

        /// <summary>
        /// 构造Services对象（使用自定义服务绑定）
        /// </summary>
        /// <param name="IsCompres">是否压缩传输</param>
        /// <param name="MaxReceivedMessage">最大接收消息大小（默认2G字节）</param>
        /// <param name="MaxArray">最大数组长度（默认64K）</param>
        /// <param name="MaxStringContent">最大字符串长度（默认64M）</param>
        /// <param name="Send">发送超时（默认600秒）</param>
        /// <param name="Receive">接收超时（默认600秒）</param>
        public Services(bool IsCompres, int MaxReceivedMessage = 2147483647, int MaxArray = 65536, int MaxStringContent = 67108864, int Send = 600, int Receive = 600)
        {
            MaxReceivedMessageSize = MaxReceivedMessage;
            MaxArrayLength = MaxArray;
            MaxStringContentLength = MaxStringContent;
            SendTimeout = Send;
            ReceiveTimeout = Receive;

            InitBinding(IsCompres);
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 启动服务主机
        /// </summary>
        /// <param name="ServiceList">服务定义对象实体集合</param>
        /// <param name="DevelopMode">是否开发模式</param>
        /// <returns>ServiceHost List 已启动服务主机集合</returns>
        public List<ServiceHost> StartService(IEnumerable<SYS_Interface> ServiceList, bool DevelopMode)
        {
            var hosts = new List<ServiceHost>();
            foreach (var td in from serv in ServiceList 
                               let path = string.Format("{0}\\{1}\\{2}.dll", Application.StartupPath, serv.Location, serv.Name)
                               where File.Exists(path) 
                               select new Thread(() => hosts.Add(OpenHost(path, serv.Name, serv.Class, serv.Interface, DevelopMode))))
            {
                td.Start();
            }
            return hosts;
        }

        /// <summary>
        /// 启动服务主机
        /// </summary>
        /// <param name="Path">文件相对路径</param>
        /// <param name="Name">主机名</param>
        /// <param name="ClassName">类名</param>
        /// <param name="Interface">接口</param>
        /// <param name="DevelopMode">是否开发模式</param>
        /// <returns>ServiceHost 服务主机</returns>
        public ServiceHost StartService(string Path, string Name, string ClassName, string Interface, bool DevelopMode)
        {
            var path = Application.StartupPath + string.Format("\\{0}\\{1}.dll", Path, Name);
            return !File.Exists(path) ? null : OpenHost(path, Name, ClassName, Interface, DevelopMode);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化自定义服务绑定
        /// </summary>
        /// <param name="IsCompres">是否压缩传输</param>
        private void InitBinding(bool IsCompres)
        {
            // 初始化WCF参数
            Binding = new CustomBinding
            {
                SendTimeout = TimeSpan.FromSeconds(SendTimeout),
                ReceiveTimeout = TimeSpan.FromSeconds(ReceiveTimeout)
            };
            var encoder = new BinaryMessageEncodingBindingElement
            {
                ReaderQuotas =
                {
                    MaxArrayLength = MaxArrayLength,
                    MaxStringContentLength = MaxStringContentLength
                }
            };
            if (IsCompres)
            {
                var gZipEncode = new GZipMessageEncodingBindingElement(encoder);
                Binding.Elements.Add(gZipEncode);
            }
            else
            {
                Binding.Elements.Add(encoder);
            }
            var transport = new TcpTransportBindingElement
            {
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                TransferMode = TransferMode.Streamed
            };
            Binding.Elements.Add(transport);
        }
        
        /// <summary>
        /// 创建并打开服务主机
        /// </summary>
        /// <param name="Path">文件绝对路径</param>
        /// <param name="Name">主机名</param>
        /// <param name="ClassName">类名</param>
        /// <param name="Interface">接口</param>
        /// <param name="DevelopMode">是否开发模式</param>
        /// <returns>ServiceHost 服务主机</returns>
        private ServiceHost OpenHost(string Path, string Name, string ClassName, string Interface, bool DevelopMode)
        {
            var asm = Assembly.LoadFrom(Path);
            var host = new ServiceHost(asm.GetType(ClassName), BaseAddress);
            host.AddServiceEndpoint(asm.GetType(Interface), Binding, Name);
            if (DevelopMode)
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior());
                host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), Name + "/mex");
            }

            host.Open();
            return host;
        }

        #endregion

    }
}
