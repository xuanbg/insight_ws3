using System.ServiceProcess;
using Insight.Utils.Common;
using Insight.WCF;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
    {
        private static Service _Services;

        public InsightServer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动WCF服务主机
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            _Services = new Service();
            _Services.CreateHosts(Util.GetAppSetting("Address"), "*");
            _Services.StartService();
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        protected override void OnStop()
        {
            _Services.StopService();
        }
    }
}