using System.ServiceProcess;
using static Insight.WS.Log.Util;

namespace Insight.WS.Log
{
    public partial class LogServer : ServiceBase
    {
        public LogServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CreateHost();
            Host.Open();
            DataAccess.ReadRule();
        }

        protected override void OnStop()
        {
            Host.Abort();
            Host.Close();
        }
    }
}
