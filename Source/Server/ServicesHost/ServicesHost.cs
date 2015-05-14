using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.ServiceProcess;
using System.Timers;
using Insight.WS.Server.Common;

namespace Insight.WS.Server
{
    public partial class ServicesHost : ServiceBase
    {

        #region 变量声明

        private List<ServiceHost> _Hosts;
        private bool _Finish;

        #endregion

        #region 构造函数

        public ServicesHost()
        {
            InitializeComponent();

            var timer = new Timer(3600000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {
            // 启动在线用户管理
            // ReSharper disable once UnusedVariable
            var om = new OnlineManage();

            // 生成自动报表
            var td = new System.Threading.Thread(delegate() { _Finish = BuildReport.Build(); });
            td.Start();

            // 启动WCF服务主机
            var comp = bool.Parse(ConfigurationManager.AppSettings["IsCompres"]);
            var serv = new Services(comp)
            {
                BaseAddress = new Uri(string.Format("net.tcp://localhost:{0}", ConfigurationManager.AppSettings["Port"]))
            };
            _Hosts = serv.StartService(CommonDAL.GetServiceList(), !comp);
        }

        protected override void OnStop()
        {
            foreach (var host in _Hosts)
            {
                host.Abort();
                host.Close();
            }
        }

        #endregion

        #region 定时触发事件

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (!_Finish) return;

            _Finish = false;
            _Finish = BuildReport.Build();
        }

        #endregion

    }
}
