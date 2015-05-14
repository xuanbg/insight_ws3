using System;
using System.Windows.Forms;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.MainApp
{
    public partial class LoginSet : DialogBase
    {

        #region 构造函数

        public LoginSet()
        {
            InitializeComponent();

            // 读取配置文件中的服务器地址和端口信息
            txtAddress.Text = Config.BaseAddress();
            txtPort.Text = Config.Port();

            // 读取用户信息保存选项
            chkIsSaveUser.Checked = Config.IsSaveUserInfo();
        }

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!chkIsSaveUser.Checked)
            {
                Config.SaveUserName(string.Empty);
            }

            Config.SaveIsSaveUserInfo(chkIsSaveUser.Checked);
            Config.SaveAddress(txtAddress.Text, txtPort.Text);

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
