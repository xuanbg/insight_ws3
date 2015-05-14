using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        /// 付款人数据
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// 款项数据
        /// </summary>
        public CustomBinding Binding { get; set; }

        #endregion

        #region 变量声明

        private EndpointAddress _Address;
        private List<UpdateFile> _ServerFiles;
        private List<UpdateFile> _LocalFiles;
        private List<UpdateFile> _UpdateFiles;
        private string _RootPath;
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
            // 初始化用户会话参数
            Session = new Session
            {
                SessionId = Guid.NewGuid(),
                BaseAddress = string.Format("net.tcp://{0}:{1}/", Config.BaseAddress(), Config.Port()),
                MachineId = General.GetHash(General.GetCpuId() + General.GetMbId())
            };

            // 初始化WCF参数
            _Address = new EndpointAddress(Session.BaseAddress + "Login");

            if (CheckUpdate())
            {
                // 删除上次更新产生的bak文件
                foreach (var file in Directory.GetFiles(_RootPath, "*.bak"))
                {
                    File.Delete(file);
                }

                DownloadFile();
            }

            if (_Restart)
            {
                General.ShowMessage("由于本次更新包含了关键文件，应用程序必须退出以完成更新！\r\n如需进入ERP系统，请您重新启动客户端程序。");
                DialogResult = DialogResult.Cancel;
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
        /// 焦点离开用户名输入框后显示该用户可登陆部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text)) InitDepartment();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 显示当前登录用户的可登陆部门
        /// </summary>
        private void InitDepartment()
        {
            lokDepartment.EditValue = null;
            try
            {
                using (var cli = new LoginClient(Binding, _Address))
                {
                    Format.InitLookUpEdit(lokDepartment, cli.GetDeptList(txtUserName.Text), "FullName");
                }

                lokDepartment.ItemIndex = 0;
            }
            catch
            {
                General.ShowError("无法连接服务器！请检查服务器地址和端口是否正确配置。\n\r如果您不知道如何配置，请联系管理员。");
            }
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

        #region 更新文件

        /// <summary>
        /// 客户端文件更新
        /// </summary>
        private bool CheckUpdate()
        {
            panel.Visible = false;
            ShowProgress("获取文件更新列表…");

            // 获取本地文件列表
            _LocalFiles = new List<UpdateFile>();
            _RootPath = Application.StartupPath;
            GetLocalFiles(_RootPath);

            // 获取服务器上的客户端文件列表
            try
            {
                using (var cli = new LoginClient(Binding, _Address))
                {
                    _ServerFiles = cli.GetServerList();
                }
            }
            catch
            {
                General.ShowError("无法连接服务器！请检查服务器地址和端口是否正确配置。\n\r如果您不知道如何配置，请联系管理员。");
                return false;
            }

            // 根据服务器文件列表比较文件版本，如本地文件不存在或版本比服务器上的低，则将该文件加入更新列表
            _UpdateFiles = new List<UpdateFile>();
            _UpdateFiles.AddRange(from sf in _ServerFiles 
                                  let cf = _LocalFiles.Find(file => file.Name == sf.Name && file.Path == sf.Path) 
                                  where cf == null || (cf.Version != null && string.Compare(cf.Version, sf.Version, StringComparison.Ordinal) < 0) 
                                  select sf);
            return _UpdateFiles.Count > 0;
        }

        /// <summary>
        /// 获取本地文件列表
        /// </summary>
        /// <param name="dir"></param>
        private void GetLocalFiles(string dir)
        {
            // 读取目录下文件信息
            var dirInfo = new DirectoryInfo(dir);
            _LocalFiles.AddRange(from file in dirInfo.GetFiles()
                                 where ".dll.exe.frl".IndexOf(file.Extension) >= 0
                                 select new UpdateFile
                                 {
                                     Name = file.Name,
                                     Path = file.DirectoryName.Replace(_RootPath, ""),
                                     FullPath = file.FullName,
                                     Version = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion
                                 });

            // 递归子目录
            var dirs = Directory.GetDirectories(dir);
            foreach (var path in dirs)
            {
                GetLocalFiles(path);
            }
        }

        /// <summary>
        /// 下载并更新客户端文件
        /// </summary>
        private void DownloadFile()
        {
            using (var cli = new LoginClient(Binding, _Address))
            {
                foreach (var file in _UpdateFiles)
                {
                    ShowProgress(string.Format("正在更新 {0}…", file.Name));
                    Thread.Sleep(500);

                    var path = _RootPath + file.Path + "\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    FileStream fs;
                    var buffer = cli.GetFile(file);
                    try
                    {
                        fs = new FileStream(path + file.Name, FileMode.Create, FileAccess.Write);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        _Restart = true;
                        File.Move(file.Name, file.Name + ".bak");
                        fs = new FileStream(path + file.Name, FileMode.Create, FileAccess.Write);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }
            }
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
                    panel.Visible = false;
                    ShowProgress("正在加载主窗体，请稍候…");

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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var loginSet = new LoginSet();
            if (loginSet.ShowDialog() != DialogResult.OK) return;

            panel.Visible = false;
            Refresh();
            Login_Shown(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
