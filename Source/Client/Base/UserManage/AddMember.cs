using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class AddMember : DialogBase
    {

        #region 变量声明

        private BaseClient _Client;
        private DataTable _OrgList;
        private DataTable _Groups;
        private DataTable _Users;

        #endregion

        #region 构造方法

        public AddMember()
        {
            InitializeComponent();

            treOrg.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }

        #endregion

        #region 界面事件


        private void AddMember_Load(object sender, EventArgs e)
        {
            InitMemberList();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化添加角色成员用户界面
        /// </summary>
        private void InitMemberList()
        {
            _Client = new BaseClient(OpenForm.Binding, OpenForm.Address);
            _OrgList = _Client.GetMemberOfTitle(OpenForm.UserSession, ObjectId);
            _Groups = _Client.GetMemberOfGroup(OpenForm.UserSession, ObjectId);
            _Users = _Client.GetMemberOfUser(OpenForm.UserSession, ObjectId);
            _Client.Close();

            InitOrgList();
            InitGroupList();
            InitUserList();
        }

        /// <summary>
        /// 初始化职位选择列表
        /// </summary>
        private void InitOrgList()
        {

            treOrg.DataSource = _OrgList;

            Format.TreeFormat(treOrg);
            treOrg.SelectImageList = imgOrgTreeNode;
            treOrg.ExpandToLevel(0);
        }

        /// <summary>
        /// 初始化用户组选择列表
        /// </summary>
        private void InitGroupList()
        {
            grdGroup.DataSource = _Groups;

            Format.GridFormat(gdvGroup, 0);
            gdvGroup.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            gdvGroup.Columns["名称"].Width = 120;
            gdvGroup.Columns["描述"].Width = 219;
        }

        /// <summary>
        /// 初始化用户选择列表
        /// </summary>
        private void InitUserList()
        {
            grdUser.DataSource = _Users;

            Format.GridFormat(gdvUser, 0);
            gdvUser.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            gdvUser.Columns["名称"].Width = 100;
            gdvUser.Columns["登录名"].Width = 100;
            gdvUser.Columns["描述"].Width = 139;
        }

        #endregion

        #region 确定按钮方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            var ts = (from node in treOrg.GetNodeList() 
                      where node.Checked && (int) node.GetValue("NodeType") == 3 
                      select (Guid) node.GetValue("ID")).ToList();
            var gs = gdvGroup.GetSelectedRows().Select(i => (Guid) gdvGroup.GetDataRow(i)["ID"]).ToList();
            var us = gdvUser.GetSelectedRows().Select(i => (Guid) gdvUser.GetDataRow(i)["ID"]).ToList();
            if (ts.Count + gs.Count + us.Count == 0 && General.ShowConfirm("当前未选择任何角色成员！您确定要离开此界面吗？") != DialogResult.OK)
            {
                return;
            }

            _Client = new BaseClient(OpenForm.Binding, OpenForm.Address);
            if (_Client.AddRoleMember(OpenForm.UserSession, ObjectId, ts, gs, us))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                General.ShowError("添加角色成员失败！如多次失败，请联系管理员。");
            }
        }

        #endregion

    }
}
