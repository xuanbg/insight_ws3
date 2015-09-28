using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.XinFenBao
{
    public partial class Withdrawal : MdiBase
    {
        public Withdrawal()
        {
            InitializeComponent();
        }

        private void Withdrawal_Load(object sender, EventArgs e)
        {
            InitToolBar();

        }
    }
}
