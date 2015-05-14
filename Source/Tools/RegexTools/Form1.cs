using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexTools
{
    public partial class FormRex : Form
    {
        public FormRex()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labOutput.Text = Regex.IsMatch(txtInput.Text.Trim(), txtRex.Text.Trim()).ToString();
        }

    }
}
