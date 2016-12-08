using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;
using Insight.Utils.Entity;
using Insight.WCF;
using Insight.WS.Server.Common.Entity;
using Insight.WS.Server.Common.Utils;
using static Insight.Utils.Common.Util;

namespace Insight.WS.Server
{
    public partial class InsightServer : ServiceBase
    {

        /// <summary>
        /// 运行中的服务主机
        /// </summary>
        private static Service Services;

        /// <summary>
        /// 服务根路径
        /// </summary>
        private static readonly string RootPath = Application.StartupPath + "\\Client";

        #region 构造函数

        public InsightServer()
        {
            InitializeComponent();
            InitSeting();

            // 每小时更新一次服务器文件列表
            var updateinfo = new System.Timers.Timer(3600000);
            updateinfo.Elapsed += UpdateFileList;
            updateinfo.Enabled = true;
        }

        #endregion

        #region 服务行为

        protected override void OnStart(string[] args)
        {
            // 启动WCF服务主机
            Services = new Service();
            using (var context = new Entities())
            {
                var list = context.SYS_Interface.ToList();
                foreach (var info in list)
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
                    Services.CreateHost(service);
                }
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
        private void InitSeting()
        {
            UpdateFileList(null, null);
            Parameters.BaseServer = GetAppSetting("BaseServer");
            Parameters.VerifyUrl = $"{Parameters.BaseServer}/security/v1.0/tokens/verify";
        }

        /// <summary>
        /// 更新服务器文件列表
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void UpdateFileList(object source, ElapsedEventArgs e)
        {
            var list = new List<FileInfo>();
            GetLocalFiles(list, RootPath, ".dll|.exe|.frl");
            Parameters.FileList = list;
        }

        #endregion

    }
}
