using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Insight.WS.Server.Common;
using Timer = System.Timers.Timer;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
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

        public InsightServer()
        {
            InitializeComponent();

            // 生成报表批处理（1小时）
            var reportBuild = new Timer(3600000);
            reportBuild.Elapsed += OnReportBuildTimedEvent;
            reportBuild.Enabled = true;
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {

            // 启动在线用户管理
            // ReSharper disable once UnusedVariable
            var om = new OnlineManage();

            // 启动WCF服务主机
            var comp = bool.Parse(Util.GetAppSetting("IsCompres"));
            var address = Util.GetAppSetting("Address");
            var tcpService = new Services
            {
                BaseAddress = $"net.tcp://{address}:"
            };
            tcpService.InitTcpBinding(comp);
            Hosts.AddRange(tcpService.StartService("TCP", !comp));

            var httpService = new Services
            {
                BaseAddress = $"http://{address}:"
            };
            httpService.InitHttpBinding();
            Hosts.AddRange(httpService.StartService("HTTP", !comp));

            // 生成自动报表
            var tdreportThread = new Thread(delegate () { Finish = ReportDAL.Build(); });
            tdreportThread.Start();
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

        #endregion

    }
}
