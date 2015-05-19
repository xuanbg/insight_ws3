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

            // 初始化CustomBinding参数
            var encoder = new BinaryMessageEncodingBindingElement { ReaderQuotas = { MaxArrayLength = 67108864, MaxStringContentLength = 67108864 } };
            var transport = new TcpTransportBindingElement { MaxReceivedMessageSize = 1073741824, TransferMode = TransferMode.Streamed };
            _Binding = new CustomBinding { SendTimeout = TimeSpan.FromSeconds(600), ReceiveTimeout = TimeSpan.FromSeconds(600) };
            if (Config.IsCompres())
            {
                var gZipEncode = new GZipMessageEncodingBindingElement(encoder);
                _Binding.Elements.AddRange(gZipEncode, transport);
            }
            else
            {
                _Binding.Elements.AddRange(encoder, transport);
            }

            // 打开登录对话框
            var login = new Login { Binding = _Binding };
            var result = login.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    Application.Run(new MainForm(login.Session, _Binding));
                    break;

                case DialogResult.Cancel:
                    Application.Exit();
                    break;

                case DialogResult.Retry:
                    Application.Restart();
                    break;
            }

        }

        #endregion

    }
}
