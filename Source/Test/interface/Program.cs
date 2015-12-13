using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;

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
            var obj = new JavaScriptSerializer().Deserialize<JsonResult>(result);
            if (!obj.Successful)
            {
                
            }
            else
            {
                var user = new JavaScriptSerializer().Deserialize<List<SYS_User>>(obj.Data);
            }
        }

    }
    public class JsonResult
    {
        public bool Successful { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string Data { get; set; }
    }
}
