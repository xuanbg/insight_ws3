using System.ServiceProcess;
using System.Threading;
using System.Timers;
using Insight.WS.Server.Common;
using Timer = System.Timers.Timer;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
    {

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
            // 启动WCF服务主机


            // 生成自动报表
            var tdreportThread = new Thread(delegate () { General.BuildReport(); });
            tdreportThread.Start();
        }

        protected override void OnStop()
        {

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
            General.BuildReport();
        }

        #endregion

    }
}
