using System.Collections.Generic;
using Insight.Utils.Entity;
using Insight.WCF;
using Insight.WS.Server.Common.Utils;
using static Insight.Utils.Common.Util;
using System.Windows.Forms;

namespace Test
{
    class Program
    {
        private static Service Services;
        private static readonly string RootPath = Application.StartupPath + "\\Client";

        static void Main(string[] args)
        {
            Services = new Service();
            var services = DataAccess.GetServiceList();
            foreach (var info in services)
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
            Services.StartService();

            var list = new List<FileInfo>();
            GetLocalFiles(list, RootPath, ".dll|.exe|.frl");
        }
    }
}
