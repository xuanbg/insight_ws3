using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Test.Interface
{
    static class Program
    {

        private static CustomBinding _Binding;
        private static EndpointAddress _Address;
        private static Session _Session;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitBinding();

        }



        private static void InitBinding()
        {
            var encoder = new BinaryMessageEncodingBindingElement { ReaderQuotas = { MaxArrayLength = 67108864, MaxStringContentLength = 67108864 } };
            var transport = new TcpTransportBindingElement { MaxReceivedMessageSize = 1073741824, TransferMode = TransferMode.Streamed };
            _Address = new EndpointAddress("net.tcp://localhost:7220/XfbInterface");
            _Binding = new CustomBinding { SendTimeout = TimeSpan.FromSeconds(600), ReceiveTimeout = TimeSpan.FromSeconds(600) };
            _Binding.Elements.AddRange(encoder, transport);
        }
    }
}
