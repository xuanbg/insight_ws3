using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Service;
using Timer = System.Timers.Timer;
using static Insight.WS.Server.Common.Util;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
    {

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        private static Services Services;

        #region 构造函数

        public InsightServer()
        {
            InitializeComponent();
            InitSeting();
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {
            // 启动WCF服务主机
            Services = new Services();
            var services = DataAccess.GetServiceList();
            foreach (var serv in services)
            {
                var info = BuildService(serv);
                Services.CreateHost(info);
            }
            Services.StartService();
        }

        protected override void OnStop()
        {
            Services.StopService();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化环境变量
        /// </summary>
        private static void InitSeting()
        {
            var version = new Version(Application.ProductVersion);
            var build = $"{version.Major}{version.Minor}{version.Build.ToString("D4").Substring(0, 2)}";
            CurrentVersion = Convert.ToInt32(build);
            CompatibleVersion = GetAppSetting("CompatibleVersion");
            UpdateVersion = GetAppSetting("UpdateVersion");

            LogServer = GetAppSetting("LogServer");
            VerifyServer = GetAppSetting("VerifyServer");
        }

        /// <summary>
        /// 初始化基础服务主机
        /// </summary>
        /// <returns></returns>
        private static ServiceInfo BuildService(SYS_Interface info)
        {
            var endpoints = new List<EndpointSet>
            {
                new EndpointSet {Interface = info.Interface},
            };
            return new ServiceInfo
            {
                BaseAddress = GetAppSetting("Address"),
                Port = info.Port,
                ServiceFile = info.ServiceFile,
                NameSpace = info.NameSpace,
                ComplyType = info.Class,
                Endpoints = endpoints
            };
        }

        #endregion

    }
}
