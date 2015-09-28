using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Insight.WS.Server.Common;
using Timer = System.Timers.Timer;

namespace Insight.WS.Server
{
    public partial class ServicesHost : ServiceBase
    {

        #region 成员属性

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        private List<ServiceHost> Hosts { get; } = new List<ServiceHost>();

        /// <summary>
        /// 报表任务状态
        /// </summary>
        private bool Finish { get; set; }

        #endregion

        #region 构造函数

        public ServicesHost()
        {
            InitializeComponent();

            // 生成报表批处理（1小时）
            var reportBuild = new Timer(3600000);
            reportBuild.Elapsed += OnReportBuildTimedEvent;
            reportBuild.Enabled = true;

            // 订单状态同步批处理（5分钟）
            var orderSync = new Timer(300000);
            orderSync.Elapsed += OnOrderSyncTimedEvent;
            orderSync.Enabled = true;

            // 接口同步批处理（10分钟）
            var interfaceSync = new Timer(600000);
            interfaceSync.Elapsed += OnInterfaceSyncTimedEvent;
            interfaceSync.Enabled = true;
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {
            // 启动在线用户管理
            // ReSharper disable once UnusedVariable
            var om = new OnlineManage();

            // 生成自动报表
            var tdreportThread = new Thread(delegate() { Finish = ReportDAL.Build(); });
            tdreportThread.Start();

            // 同步订单状态
            var orderThread = new Thread(CommonDAL.OrderStatusSync);
            orderThread.Start();

            // 同步接口
            var interfaceThread = new Thread(Atom.IntrefaceSync);
            interfaceThread.Start();

            // 启动WCF服务主机
            var comp = bool.Parse(Util.GetAppSetting("IsCompres"));
            var address = Util.GetAppSetting("Address");
            var tcpService = new Services()
            {
                BaseAddress = new Uri($"net.tcp://{address}:{Util.GetAppSetting("TcpPort")}")
            };
            tcpService.InitTcpBinding(comp);
            Hosts.AddRange(tcpService.StartService("TCP", !comp));

            var httpService = new Services()
            {
                BaseAddress = new Uri($"http://{address}:{Util.GetAppSetting("HttpPort")}")
            };
            httpService.InitHttpBinding();
            Hosts.AddRange(httpService.StartService("HTTP", !comp));
        }

        protected override void OnStop()
        {
            foreach (var host in Hosts)
            {
                host.Abort();
                host.Close();
            }
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
            Finish = ReportDAL.Build();
        }

        /// <summary>
        /// 订单状态同步任务
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnOrderSyncTimedEvent(object source, ElapsedEventArgs e)
        {
            CommonDAL.OrderStatusSync();
        }

        /// <summary>
        /// 接口同步任务
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnInterfaceSyncTimedEvent(object source, ElapsedEventArgs e)
        {
            Atom.IntrefaceSync();
        }

        #endregion

    }
}
