using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using test.Service;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private DateTime FormatDate(DateTime date, int n)
        {
            var day = date.Day;
            var mod = day % 10;
            day = (day - mod + n + (mod > n ? 10 : 0)) % 30;

            var fd = DateTime.Parse(date.ToString("yyyy-MM-dd").Substring(0, 8) + day.ToString("00")).AddMonths(date.Day > 20 + n ? 1 : 0);
            return fd;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var encoder = new BinaryMessageEncodingBindingElement { ReaderQuotas = { MaxArrayLength = 67108864, MaxStringContentLength = 67108864 } };
            var transport = new TcpTransportBindingElement { MaxReceivedMessageSize = 1073741824, TransferMode = TransferMode.Streamed };
            var address = new EndpointAddress("net.tcp://localhost:7210/XfbInterface");
            var binding = new CustomBinding { SendTimeout = TimeSpan.FromSeconds(600), ReceiveTimeout = TimeSpan.FromSeconds(600) };
            binding.Elements.AddRange(encoder, transport);

            var machineId = General.GetHash(General.GetCpuId() + General.GetMbId());
            var session = new Session
            {
                SessionId = Guid.NewGuid(),
                MachineId = machineId,
                LoginName = "18723451111",
                Signature = General.GetHash("111111"),
                UserName = "宣炳刚"
            };
            var img = Image.FromFile(@"C:\Windows\WinSxS\amd64_microsoft-windows-tabletpc-journal_31bf3856ad364e35_10.0.10240.16384_none_1fb1fa003f458089\Monet.jpg");
            var buff = General.ImageToByteArray(img);

            var list = new List<ABS_Contract_FundPerform>();
            var obj = new ABS_Contract_FundPerform
            {
                PlanId = Guid.Parse("29C38CA1-4858-E511-80BD-069A45FAD4EF"),
                Amount = (decimal) 0.01
            };
            list.Add(obj);
            var oid = Guid.Parse("132bffe8-1061-e511-80be-069a45fad4ef");
            using (var cli = new InterfaceClient(binding, address))
            {
                session = cli.UserLogin(session);

                var r = cli.AddBill(session, oid, "111");
            }

        }
    }

}
