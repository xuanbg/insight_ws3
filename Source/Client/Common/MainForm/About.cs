using System.Diagnostics;
using System.Windows.Forms;

namespace Insight.WS.Client.Common
{
    public partial class About : DialogBase
    {
        public About()
        {
            InitializeComponent();

            // 显示文件版本信息
            var fileVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            labProduct.Text = fileVersion.ProductName;
            labVer.Text = fileVersion.FileVersion;
            labDev.Text = fileVersion.CompanyName;
        }

        protected override void Confirm_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
