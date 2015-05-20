﻿using System;
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

        private EndpointAddress _Address;
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

            InitParameter();
            _Restart = CheckUpdate();
            if (!_CanConnect && General.ShowConfirm("无法连接服务器！是否检查服务器地址和端口配置？\n\r如果您不知道如何配置，请联系管理员。", MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                var loginSet = new LoginSet();
                if (loginSet.ShowDialog() != DialogResult.OK) return;

                goto Start;
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
            if (!_CanConnect) return;
            
            if (!string.IsNullOrEmpty(txtUserName.Text)) InitDepartment();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化用户会话参数
        /// </summary>
        private void InitParameter()
        {
            Session = new Session
            {
                SessionId = Guid.NewGuid(),
                BaseAddress = string.Format("net.tcp://{0}:{1}/", Config.BaseAddress(), Config.Port()),
                MachineId = General.GetHash(General.GetCpuId() + General.GetMbId())
            };

            // 初始化EndpointAddress参数
            _Address = new EndpointAddress(Session.BaseAddress + "Login");
        }

        /// <summary>
        /// 客户端文件更新
        /// </summary>
        private bool CheckUpdate()
        {
            panel.Visible = false;
            ShowProgress("获取文件更新列表…");

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
                        ShowProgress(string.Format("正在更新 {0}…", file.Name));
                        Thread.Sleep(500);

                        restart = restart || update.UpdateFile(cli.GetFile(file));
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
        /// 
        /// </summary>
        private void EntryLogin()
        {
            if (_Restart)
            {
                General.ShowMessage("由于本次更新包含了关键文件，应用程序必须重启以完成更新！");
                DialogResult = DialogResult.Retry;
                Close();
            }
            else
            {
                pbcLogin.Visible = false;
                panel.Visible = true;
                txtUserName.Focus();

                // 自动输入配置文件中保存的用户名
                txtUserName.EditValue = Config.IsSaveUserInfo() ? Config.UserName() : null;
                if (!string.IsNullOrEmpty(txtUserName.Text)) txtPassWord.Focus();
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
            Session.LoginName = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(Session.LoginName))
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

            Session.Signature = General.GetHash(txtPassWord.Text.Trim());
            Session.DeptId = (Guid?)lokDepartment.EditValue;
            Session.DeptName = lokDepartment.EditValue == null ? null : lokDepartment.Text;
            using (var cli = new LoginClient(Binding, _Address))
            {
                Session = cli.UserLogin(Session);
            }

            switch (Session.LoginStatus)
            {
                case LoginResult.Success:
                    Config.SaveUserName(Session.LoginName);
                    DialogResult = DialogResult.OK;
                    break;

                case LoginResult.Failure:
                    General.ShowWarning("对不起，您输入的密码不正确！\r\n如果您不知道或遗忘自己的密码，请联系管理员。");
                    txtPassWord.EditValue = null;
                    txtPassWord.Focus();
                    break;

                case LoginResult.Online:
                    General.ShowWarning("对不起，当前用户已登录！\r\n如果您已经退出系统，请稍后再试。");
                    break;

                case LoginResult.NotExist:
                    General.ShowWarning("该账户不存在！请检查输入的用户名。\r\n如果您不知道自己的用户名，请联系管理员。");
                    txtUserName.EditValue = null;
                    txtUserName.Focus();
                    break;

                case LoginResult.Banned:
                    General.ShowWarning("该账户已封禁！在解封前您不能登录系统。\r\n如果您需要使用该账号登录系统，请联系管理员。");
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
            if (loginSet.ShowDialog() != DialogResult.OK) return;

            InitParameter();
            _Restart = CheckUpdate();
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
