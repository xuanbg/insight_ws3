using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using FastReport.Utils;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class MainForm : XtraForm
    {

        #region 变量声明

        public static CustomBinding Binding;
        public static EndpointAddress Address;
        public static Session Session;

        private DataTable _NavGroup;
        private DataTable _NavItem;
        private Waiting _Waiting = new Waiting();
        private List<object> _OpenModules = new List<object>();
        private string _ShotTime = DateTime.Now.ToLongTimeString();
        private string _LongTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        private bool _Expand;
        private int _ItemCount;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化状态栏信息
        /// </summary>
        /// <param name="session"></param>
        /// <param name="binding"></param>
        public MainForm(Session session, CustomBinding binding)
        {
            _Waiting.Show();
            _Waiting.Refresh();
            Thread.Sleep(500);

            InitializeComponent();

            Session = session;
            Binding = binding;
            Address = new EndpointAddress(Session.BaseAddress + "Commons");

            // 初始化界面
            Res.LoadLocale("Components\\Chinese (Simplified).frl");
            defaultLookAndFeel.LookAndFeel.SkinName = Config.LookAndFeel();
            btnTime.Caption = _ShotTime;
            btnDept.Caption = Session.DeptName;
            btnDept.Visibility = Session.DeptName == null ? BarItemVisibility.Never : BarItemVisibility.Always;
            btnUser.Caption = Session.UserName;
            btnServer.Caption = string.Format("{0} : {1}", Config.BaseAddress(), Config.Port());
            if (SystemInformation.WorkingArea.Height < 760)
            {
                WindowState = FormWindowState.Maximized;
            }

            // 加载导航栏
            using (var cli = new CommonsClient(Binding, Address))
            {
                _NavGroup = cli.GetModuleGroup(Session);
                _NavItem = cli.GetUserModule(Session);
            }

            InitNavBar();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 启动后加载默认加载模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            _OpenModules.ForEach(AddPageMdi);
            _Waiting.Close();

            if (Session.Signature == General.GetHash("123456"))
                ChangPassWord(null, null);
        }

        /// <summary>
        /// 点击导航栏项目打开相应MDI窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void navItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            AddPageMdi(e.Link.Item.Tag);
        }

        /// <summary>
        /// 如注销用户失败，弹出询问对话框。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string str = "注销用户账号失败！是否强制退出系统？\r\n如强制退出，可能会导致在一小时内无法登录系统！";
            if (!Commons.DelOnlineUser() && General.ShowConfirm(str) != DialogResult.OK) e.Cancel = true;
        }

        /// <summary>
        /// 退出系统前保存当前应用的皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            Config.SaveLookAndFeel(defaultLookAndFeel.LookAndFeel.SkinName);
            Application.Exit();
        }

        /// <summary>
        /// 点击登录时间图标切换时间格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTime_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnTime.Caption = btnTime.Caption == _ShotTime ? _LongTime : _ShotTime;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化导航栏
        /// </summary>
        private void InitNavBar()
        {
            foreach (DataRow row in _NavGroup.Rows)
            {
                _Expand = false;
                var groupId = row["ID"].ToString();
                var navGroup = new NavBarGroup
                {
                    Caption = row["Name"].ToString(),
                    Name = groupId,
                    SmallImage = Image.FromStream(new MemoryStream((byte[]) row["Icon"]))
                };

                CreateNavItem(groupId, navGroup);
                navGroup.Expanded = ((_NavGroup.Rows.Count * 55 + _ItemCount * 32) < navMain.Height || _Expand);
                navMain.Groups.Add(navGroup);
            }
        }

        /// <summary>
        /// 创建导航菜单项目并注册事件
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="nbg"></param>
        private void CreateNavItem(string gid, NavBarGroup nbg)
        {
            var filter = string.Format(" ModuleGroupId = '{0}'", gid);
            foreach (var row in _NavItem.Select(filter))
            {
                var navItem = new NavBarItem(row["ApplicationName"].ToString())
                {
                    Tag = row["ID"],
                    SmallImage = Image.FromStream(new MemoryStream((byte[]) row["Icon"]))
                };
                navItem.LinkClicked += navItem_LinkClicked;
                nbg.ItemLinks.Add(navItem);
                _ItemCount++;

                if (!(bool) row["Default"]) continue;

                _OpenModules.Add(navItem.Tag);
                _Expand = true;
            }
        }

        /// <summary>
        /// 打开MDI子窗体
        /// </summary>
        /// <param name="mid"></param>
        private void AddPageMdi(object mid)
        {
            if (Application.OpenForms[mid.ToString()] != null)
            {
                Application.OpenForms[mid.ToString()].Activate();
                return;
            }

            Refresh();
            bprMain.Visibility = BarItemVisibility.Always;
            bprMain.Refresh();

            using (var cli = new CommonsClient(Binding, Address))
            {
                var mod = cli.GetModuleInfo(Session, (Guid)mid);
                var path = string.Format("{0}\\{1}\\{2}.dll", Application.StartupPath, mod.Location ?? "", mod.ProgramName).Replace("\\\\", "\\");
                if (File.Exists(path))
                {
                    var asm = Assembly.LoadFrom(path);
                    var mdi = (MdiBase)asm.CreateInstance(mod.MainFrom);
                    mdi.Icon = Icon.FromHandle(new Bitmap(new MemoryStream(mod.Icon)).GetHicon());
                    mdi.MdiParent = this;
                    mdi.Name = mid.ToString();
                    mdi.Text = mod.ApplicationName;
                    mdi.ModuleId = mod.ID;
                    mdi.UserSession = Session;
                    mdi.Binding = Binding;
                    mdi.Address = new EndpointAddress(Session.BaseAddress + mod.ProgramName);
                    mdi.Show();
                }
                else
                {
                    var str = string.Format("对不起，{0}模块无法加载！\r\n在您的安装文件夹中缺少{1}.dll文件。", mod.ApplicationName, mod.ProgramName);
                    General.ShowError(str);
                }
                bprMain.Visibility = BarItemVisibility.Never;
            }
        }

        #endregion

        #region 主菜单点击事件

        /// <summary>
        /// 点击菜单项：修改密码，弹出修改密码对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangPassWord(object sender, ItemClickEventArgs e)
        {
            var dig = new ChangePw();
            dig.ShowDialog();
        }

        /// <summary>
        /// 点击菜单项：锁定，弹出解锁对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lock(object sender, ItemClickEventArgs e)
        {
            var dig = new Unlock();
            dig.ShowDialog();
        }

        /// <summary>
        /// 点击菜单项：注销，弹出询问对话框，确认注销后重启应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout(object sender, ItemClickEventArgs e)
        {
            if (General.ShowConfirm("注销用户将导致当前未完成的输入内容丢失！\r\n您确定要注销吗？") == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        /// <summary>
        /// 点击菜单项：退出，关闭应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 点击菜单项：打印机设置，打开打印机设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintSet(object sender, ItemClickEventArgs e)
        {
            var dig = new PrintSet();
            dig.ShowDialog();
        }

        /// <summary>
        /// 点击菜单项：帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 点击菜单项：关于，打开关于对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About(object sender, ItemClickEventArgs e)
        {
            var dig = new About();
            dig.ShowDialog();
        }

        #endregion

    }
}
