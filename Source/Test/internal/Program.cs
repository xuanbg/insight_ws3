using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Service;

namespace Test.Internal
{
    static class Program
    {

        private static BasicHttpBinding _Binding;
        private static EndpointAddress _Address;
        private const string SecCode = "0A457C39B0A81CEFE3D9E30E99A00388";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _Binding = new BasicHttpBinding();
            _Address = new EndpointAddress("http://localhost:7280/XfbInternal");

            SetPw();
            //AddBankCard();
        }


        private static void AddBankCard()
        {
            using (var cli = new InternalClient(_Binding, _Address))
            {
                var r = cli.AddBankCard(SecCode, "13521906383", "肖楠", "信用卡", "中国建设银行", "6236683760004603947");
            }
        }


        private static void SetPw()
        {
            using (var cli = new InternalClient(_Binding, _Address))
            {
                var r = cli.SetPassword(SecCode, "13051165004", "96E79218965EB72C92A549DD5A330112");
            }
            
        }
    }
}
