using Insight.WCF;
using Insight.WS.Server.Common.Utils;
using Insight.WCF.Entity;
using static Insight.Utils.Common.Util;

namespace Test
{
    class Program
    {
        private static Services Services;

        static void Main(string[] args)
        {
            Services = new Services();
            var services = DataAccess.GetServiceList();
            foreach (var info in services)
            {
                var service = new ServiceInfo
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
        }
    }
}
