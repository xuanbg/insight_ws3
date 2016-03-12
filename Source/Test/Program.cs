using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.WS.Server.Common;
using Insight.WS.Service;
using static Insight.WS.Server.Common.Util;

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
                    Port = info.Port ?? GetAppSetting("Port"),
                    Path = info.Path,
                    NameSpace = info.NameSpace,
                    Interface = info.Interface,
                    ComplyType = info.Service,
                    ServiceFile = info.ServiceFile,
                };
                Services.CreateHost(service);
            }
            Services.StartService();
        }
    }
}
