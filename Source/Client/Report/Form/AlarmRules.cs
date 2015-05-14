using System;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.Platform.Report
{
    public partial class AlarmRules : MdiBase
    {
        public AlarmRules()
        {
            InitializeComponent();
        }

        private void AlarmRules_Load(object sender, EventArgs e)
        {
            InitToolBar();
        }

    }
}
