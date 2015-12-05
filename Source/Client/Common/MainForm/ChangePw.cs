using System;
using System.Windows.Forms;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class ChangePw : DialogBase
    {

        #region 构造函数

        public ChangePw()
        {
            InitializeComponent();
        }

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPw.Text))
            {
                General.ShowError("请输入正确的原密码，否则无法为您更换密码！");
                txtOldPw.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNewPw.Text.Trim()))
            {
                General.ShowWarning("新密码不能为空，请输入您的新密码并牢记！");
                txtNewPw.Focus();
                return;
            }

            if (txtNewPw.Text.Trim() == "123456")
            {
                General.ShowWarning("新密码不能设为初始密码，请输入其它密码并牢记！");
                txtNewPw.EditValue = null;
                txtOldPw.EditValue = null;
                txtNewPw.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmPw.Text.Trim()))
            {
                General.ShowWarning("必须再输入一次新密码！\r\n并且只有两次输入的密码一致，才能为您更换密码。");
                txtConfirmPw.Focus();
                return;
            }

            if (txtNewPw.Text.Trim() != txtConfirmPw.Text.Trim())
            {
                General.ShowError("两次密码输入不一致！\r\n请重新确认密码，只有两次输入的密码一致，才能为您更换密码。");
                txtConfirmPw.EditValue = null;
                txtConfirmPw.Focus();
                return;
            }

            var signature = General.GetHash(MainForm.Session.LoginName.ToUpper() + General.GetHash(txtOldPw.Text.Trim()));
            if (signature != MainForm.Session.Signature)
            {
                General.ShowError("请输入正确的原密码，否则无法为您更换密码！");
                txtOldPw.EditValue = null;
                txtOldPw.Focus();
                return;
            }

            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                var pw = General.GetHash(txtNewPw.Text);
                if (cli.UpdataPassWord(MainForm.Session, pw))
                {
                    General.ShowMessage("更换密码成功！请牢记新密码并使用新密码登录系统。");
                    MainForm.Session.Signature = General.GetHash(MainForm.Session.LoginName.ToUpper() + pw);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("更换密码失败！请检查网络状况，并再次进行更换密码操作。");
                }
            }
        }

        #endregion

    }
}
