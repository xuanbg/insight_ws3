using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class OnlineUser : DialogBase
    {

        #region 变量声明

        private List<Session> _Sessions;

        #endregion

        #region 构造方法

        public OnlineUser()
        {
            InitializeComponent();
        }
        #endregion

        #region 界面事件处理

        /// <summary>
        /// 在窗体加载时初始化组织机构树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlineUser_Load(object sender, EventArgs e)
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Sessions = cli.GetOnlineUser(OpenForm.UserSession);
            }

            InitOnlineList();
        }

        /// <summary>
        /// 按DEL键删除在线用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvOnline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            var cs = gdvOnline.GetFocusedRow() as Session;
            if (General.ShowConfirm($"您确定要使用户【{cs.UserName}】离线吗？用户离线后将必须重新登录系统才能继续操作。") != DialogResult.OK) return;

            if (!Commons.DelOnlineUser(cs))
            {
                General.ShowError("删除用户状态失败！如多次失败，请联系管理员。");
                return;
            }

            gdvOnline.DeleteRow(gdvOnline.FocusedRowHandle);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化在线用户列表
        /// </summary>
        private void InitOnlineList()
        {
            grdOnline.DataSource = _Sessions;
            Format.GridFormat(gdvOnline);
            gdvOnline.Columns["UserName"].Width = 80;
            gdvOnline.Columns["LoginName"].Width = 120;
            gdvOnline.Columns["DeptName"].Width = 160;
            gdvOnline.Columns["MachineId"].Visible = true;
            gdvOnline.Columns["MachineId"].Width = 240;
            gdvOnline.Columns["LastConnect"].Width = 110;
        }

        #endregion

        #region 重写虚方法实现

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        protected override void DialogClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
