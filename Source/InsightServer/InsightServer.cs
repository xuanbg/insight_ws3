using System.ServiceProcess;
using Insight.WCF;
using Insight.WS.Server.Common.Utils;
using static Insight.Utils.Common.Util;

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
            foreach (var info in Parameters.Services)
            {
                var service = new Service.Info
                {
                    BaseAddress = GetAppSetting("Address"),
                    Port = info.Port,
                    Path = info.Path,
                    Version = info.Version,
                    NameSpace = info.NameSpace,
                    Interface = info.Interface,
                    ComplyType = info.Service,
                    ServiceFile = info.ServiceFile
                };
                _Services.CreateHost(service);
            }
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