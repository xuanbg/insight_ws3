using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Service;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var encoder = new BinaryMessageEncodingBindingElement { ReaderQuotas = { MaxArrayLength = 67108864, MaxStringContentLength = 67108864 } };
            var transport = new TcpTransportBindingElement { MaxReceivedMessageSize = 1073741824, TransferMode = TransferMode.Streamed };
            var Address = new EndpointAddress("net.tcp://localhost:7210/Interface");
            var _Binding = new CustomBinding { SendTimeout = TimeSpan.FromSeconds(600), ReceiveTimeout = TimeSpan.FromSeconds(600) };
            _Binding.Elements.AddRange(encoder, transport);

            using (var cli = new XfbInterfaceClient(_Binding, Address))
            {
                cli.GetVerifyCode("18310795790", 1);
            }
        }

    }
}
