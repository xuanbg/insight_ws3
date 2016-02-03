using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Timers;
using Insight.WS.Base;
using Insight.WS.Server.Common;
using static Insight.WS.Server.Common.Util;
using Timer = System.Timers.Timer;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
    {

        #region 成员属性

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        private static ServiceHost Host;

        /// <summary>
        /// 报表任务状态
        /// </summary>
        private bool Finish { get; set; }

        #endregion

        #region 构造函数

        public InsightServer()
        {
            InitializeComponent();
            InitSeting();

            // 生成报表批处理（1小时）
            var reportBuild = new Timer(3600000);
            reportBuild.Elapsed += OnReportBuildTimedEvent;
            reportBuild.Enabled = true;
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {
            var path = $"{Application.StartupPath}\\Services\\SuperDentist\\AppService.dll";
            if (!File.Exists(path)) return;

            var endpoints = new List<EndpointSet> { new EndpointSet { Name = "Interface", Path = "AppService" } };
            var serv = new Services
            {
                BaseAddress = GetAppSetting("Address"),
                Port = GetAppSetting("Port"),
                NameSpace = "Insight.WS.Service.SuperDentist",
                ServiceType = "AppService",
                Endpoints = endpoints
            };
            Host = serv.CreateHost(path);
            Host.Open();
        }

        protected override void OnStop()
        {
            Host.Abort();
            Host.Close();
        }

        #endregion

        #region 定时触发事件

        /// <summary>
        /// 自动报表生成任务
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnReportBuildTimedEvent(object source, ElapsedEventArgs e)
        {
            if (!Finish) return;

            Finish = false;
            Finish = General.BuildReport();
        }

        #endregion

        /// <summary>
        /// 初始化环境变量
        /// </summary>
        public static void InitSeting()
        {
            var version = new Version(Application.ProductVersion);
            var build = $"{version.Major}{version.Minor}{version.Build.ToString("D4").Substring(0, 2)}";
            CurrentVersion = Convert.ToInt32(build);
            CompatibleVersion = GetAppSetting("CompatibleVersion");
            UpdateVersion = GetAppSetting("UpdateVersion");

            BaseServer = GetAppSetting("BaseServer");
            VerifyServer = GetAppSetting("VerifyServer");
            LogServer = GetAppSetting("LogServer");
        }
    }
}
