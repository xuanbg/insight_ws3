using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Microsoft.Samples.GZipEncoder;

namespace Insight.WS.Client.MainApp
{
    static class Program
    {

        #region 变量声明

        private static CustomBinding _Binding;

        #endregion

        #region 构造函数

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 初始化WCF参数
            _Binding = new CustomBinding
            {
                SendTimeout = TimeSpan.FromSeconds(600),
                ReceiveTimeout = TimeSpan.FromSeconds(600)
            };
            var encoder = new BinaryMessageEncodingBindingElement
            {
                ReaderQuotas =
                {
                    MaxArrayLength = 65536,
                    MaxStringContentLength = 67108864
                }
            };
            if (Config.IsCompres())
            {
                var gZipEncode = new GZipMessageEncodingBindingElement(encoder);
                _Binding.Elements.Add(gZipEncode);
            }
            else
            {
                _Binding.Elements.Add(encoder);
            }
            var transport = new TcpTransportBindingElement
            {
                MaxReceivedMessageSize = 2147483647,
                TransferMode = TransferMode.Streamed
            };
            _Binding.Elements.Add(transport);

            var login = new Login { Binding = _Binding };
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(login.Session, _Binding));
            }
            else
            {
                Application.Exit();
            }

        }

        #endregion

    }
}
