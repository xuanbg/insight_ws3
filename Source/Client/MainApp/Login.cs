using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.MainApp.Service;

namespace Insight.WS.Client.MainApp
{
    public partial class Login : XtraForm
    {

        #region 属性

        /// <summary>
        /// 用户会话
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// WCF Binding
        /// </summary>
        public CustomBinding Binding { get; set; }

        #endregion

        #region 变量声明

        private readonly string _MachineId = General.GetHash(General.GetCpuId() + General.GetMbId());
        private EndpointAddress _Address;
        private string _BaseAddress;
        private bool _CanConnect;
        private bool _Restart;

        #endregion

        #region 构造函数

        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 第一次显示窗体时检查更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Shown(object sender, EventArgs e)
        {
            Start:

            _Restart = CheckUpdate();
            if (!_CanConnect && General.ShowConfirm("无法连接服务器！是否检查服务器地址和端口配置？\n\r如果您不知道如何配置，请联系管理员。", MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                var loginSet = new LoginSet();
                if (loginSet.ShowDialog() == DialogResult.OK) goto Start;
            }

            EntryLogin();
        }

        /// <summary>
        /// 焦点离开用户名输入框后显示该用户可登陆部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (!_CanConnect || string.IsNullOrEmpty(txtUserName.Text.Trim())) return;
            
            InitDepartment();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 客户端文件更新
        /// </summary>
        private bool CheckUpdate()
        {
            panel.Visible = false;
            ShowProgress("获取文件更新列表…");

            // 初始化EndpointAddress参数
            _BaseAddress = $"net.tcp://{Config.BaseAddress()}:{Config.Port()}/";
            _Address = new EndpointAddress(_BaseAddress + "Login");

            // 获取服务器上的客户端文件列表
            try
            {
                var restart = false;
                using (var cli = new LoginClient(Binding, _Address))
                {
                    var sf = cli.GetServerList();
                    var update = new Update(sf);
                    foreach (var file in update.UpdateFiles)
                    {
                        ShowProgress($"正在更新 {file.Name}…");
                        Thread.Sleep(500);

                        restart = update.UpdateFile(cli.GetFile(file)) || restart;
                    }
                }

                _CanConnect = true;
                return restart;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 显示登录控件
        /// </summary>
        private void EntryLogin()
        {
            if (_Restart)
            {
                General.ShowMessage("由于本次更新包含了关键文件，应用程序必须重启以完成更新！");
                DialogResult = DialogResult.Retry;
                Close();
                return;
            }

            if (!_CanConnect)
            {
                General.ShowError("仍然无法连接服务器！请重新检查服务器地址和端口配置。");
            }

            // 显示登录控件
            pbcLogin.Visible = false;
            panel.Visible = true;
            txtUserName.Focus();
            txtUserName.EditValue = Config.IsSaveUserInfo() ? Config.UserName() : null;

            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                txtPassWord.Focus();
            }
        }

        /// <summary>
        /// 显示当前登录用户的可登陆部门
        /// </summary>
        private void InitDepartment()
        {
            lokDepartment.EditValue = null;
            using (var cli = new LoginClient(Binding, _Address))
            {
                Format.InitLookUpEdit(lokDepartment, cli.GetDeptList(txtUserName.Text), "FullName");
            }

            lokDepartment.ItemIndex = 0;
        }

        /// <summary>
        /// 显示进度条
        /// </summary>
        /// <param name="text"></param>
        private void ShowProgress(string text)
        {
            pbcLogin.Visible = true;
            pbcLogin.Text = text;
            pbcLogin.Refresh();
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 点击确定按钮处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                General.ShowMessage("请输入用户名！");
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                General.ShowWarning("密码不能为空！");
                txtPassWord.Focus();
                return;
            }

            // 初始化Session并登录系统
            Session = new Session
            {
                LoginName = txtUserName.Text.Trim(),
                Signature = General.GetHash(txtUserName.Text.Trim().ToUpper() + General.GetHash(txtPassWord.Text.Trim())),
                ClientType = 0,
                MachineId = _MachineId,
                DeptId = (Guid?) lokDepartment.EditValue,
                DeptName = lokDepartment.EditValue == null ? null : lokDepartment.Text,
                BaseAddress = _BaseAddress
            };

            using (var cli = new LoginClient(Binding, _Address))
            {
                Session = cli.UserLogin(Session);
            }

            switch (Session.LoginResult)
            {
                case LoginResult.Success:
                    Config.SaveUserName(Session.LoginName);
                    DialogResult = DialogResult.OK;
                    break;

                case LoginResult.Multiple:
                    var proc = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                    if (proc.Length > 1)
                    {
                        General.ShowWarning("您已经在本机登录系统！请勿重复登录。");
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case LoginResult.Failure:
                    var msg = Session.FailureCount < 5 ? "对不起，您输入的密码不正确！\r\n如果您不知道或遗忘自己的密码，请联系管理员。" : "您的帐户已锁定！请在10分钟后再尝试登录。";
                    General.ShowWarning(msg);
                    txtPassWord.EditValue = null;
                    txtPassWord.Focus();
                    break;

                case LoginResult.Online:
                    General.ShowWarning("对不起，该用户已在其他设备登录！\r\n在该用户退出系统前，您不能登录系统。");
                    break;

                case LoginResult.NotExist:
                    General.ShowWarning("该账户不存在！请检查输入的用户名。\r\n如果您不知道自己的用户名，请联系管理员。");
                    txtUserName.EditValue = null;
                    txtUserName.Focus();
                    break;

                case LoginResult.Banned:
                    General.ShowWarning("该账户已封禁！在解封前您不能登录系统。\r\n如果您需要使用该账号登录系统，请联系管理员。");
                    txtUserName.EditValue = null;
                    txtUserName.Focus();
                    break;

                case LoginResult.Unauthorized:
                    General.ShowWarning("在线用户数已达上限！您缺少足够的授权数量。\r\n请联系开发商购买足够的用户授权数量。");
                    break;
            }
        }

        /// <summary>
        /// 打开登录设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Click(object sender, EventArgs e)
        {
            var loginSet = new LoginSet();
            if (loginSet.ShowDialog() == DialogResult.OK) _Restart = CheckUpdate();

            EntryLogin();
        }

        /// <summary>
        /// 关闭登录窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
