using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using Insight.WS.Server.Common;

namespace Insight.WS.Test.Interface
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            GetUsers();
        }

        private static void GetUsers()
        {
            var url = "http://localhost:6280/Interface/GetUsers";
            var result = Util.HttpGet(url, "");
        }

    }
}
