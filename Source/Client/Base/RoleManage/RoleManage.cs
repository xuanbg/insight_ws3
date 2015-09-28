using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class RoleManage : MdiBase
    {

        #region 变量声明

        private DataTable _Roles;
        private DataTable _Members;
        private DataTable _RoleUsers;
        private DataTable _RoleModulePermit;
        private DataTable _RoleActionPermit;
        private DataTable _RoleDataPermit;
        private string _FilterStr;
        private Guid _ObjectId;

        #endregion

        #region 构造函数

        public RoleManage()
        {
            InitializeComponent();

            // 注册事件
            gdvRole.FocusedRowObjectChanged += gdvRole_FocusedRowObjectChanged;
            treMember.CustomDrawNodeImages += CustomDrawNodeImages;
            treModule.CustomDrawNodeImages += DrawNodeImages;
            treAction.CustomDrawNodeImages += DrawNodeImages;
            treData.CustomDrawNodeImages += DrawNodeImages;
        }

        #endregion

        #region 界面事件处理

        private void RoleManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitRoleList();
        }

        /// <summary>
        /// 角色列表选中行变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvRole_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var builtIn = (bool)gdvRole.GetFocusedDataRow()["内置"];
            SwitchItemStatus(new Context("DeleteRole", !builtIn), new Context("AddMember", !builtIn));
            _ObjectId = (Guid)gdvRole.GetFocusedDataRow()["ID"];
            _FilterStr = "RoleId = '" + _ObjectId + "'";

            InitRoleMember();
            InitPermission(tabPermission.SelectedTabPageIndex);
        }

        /// <summary>
        /// 切换角色成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treMember_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (treMember.FocusedNode == null) return;

            var builtIn = (bool)_Roles.Rows.Find(treMember.FocusedNode.GetValue("RoleId"))["内置"];
            var canRemove = !builtIn && (int)treMember.FocusedNode.GetValue("NodeType") != 0;
            SwitchItemStatus(new Context("Remove", canRemove));
        }

        /// <summary>
        /// 双击角色列表编辑当前所选角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvRole_DoubleClick(object sender, EventArgs e)
        {
            if (gdvRole.FocusedRowHandle < 0) return;

            RoleEdit(true);
        }

        /// <summary>
        /// 显示角色成员的类型图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            if (e.Node.Level != 0) return;

            e.SelectImageIndex = Convert.ToInt32(e.Node.GetValue("MemberId").ToString().Substring(0, 1));
        }

        /// <summary>
        /// 重绘模块功能树节点图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = (int)e.Node.GetValue("Action");
        }

        /// <summary>
        /// 初始化页内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPermission_Selected(object sender, TabPageEventArgs e)
        {
            InitPermission(e.PageIndex);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载角色列表数据
        /// </summary>
        private void InitRoleList()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Roles = cli.GetAllRole(UserSession);
                _RoleModulePermit = cli.GetRoleModulePermit(UserSession);
                _RoleActionPermit = cli.GetRoleActionPermit(UserSession);
                _RoleDataPermit = cli.GetRoleDataPermit(UserSession);
            }

            grdRole.DataSource = _Roles;
            Format.GridFormat(gdvRole);
            gdvRole.Columns["名称"].Width = 200;
            gdvRole.Columns["描述"].Width = 450;
            gdvRole.MoveFirst();
        }

        /// <summary>
        /// 加载所选角色成员数据
        /// </summary>
        private void InitRoleMember()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Members = cli.GetRoleMember(UserSession);
                _RoleUsers = cli.GetRoleUser(UserSession);
            }

            ShowMember();
            InitRoleUser();
        }

        /// <summary>
        /// 显示角色成员及用户
        /// </summary>
        private void ShowMember()
        {
            var dv = _Members.Copy().DefaultView;
            dv.RowFilter = _FilterStr;
            treMember.DataSource = dv;
            Format.TreeFormat(treMember);
            treMember.SelectImageList = imgMember;
            treMember.KeyFieldName = "MemberId";
            treMember.ExpandAll();
        }

        /// <summary>
        /// 加载所选角色成员用户数据
        /// </summary>
        private void InitRoleUser()
        {
            var dv = _RoleUsers.Copy().DefaultView;
            dv.RowFilter = _FilterStr;
            grdUser.DataSource = dv;
            Format.GridFormat(gdvUser);
            gdvUser.Columns["用户名"].Width = 120;
            gdvUser.Columns["登录名"].Width = 100;
            gdvUser.Columns["描述"].Width = 223;
        }

        /// <summary>
        /// 根据所选标签页索引号加载内容
        /// </summary>
        /// <param name="pageIndex"></param>
        private void InitPermission(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    InitRoleModulePermit();
                    break;

                case 1:
                    InitRoleActionPermit();
                    break;

                case 2:
                    InitRoleDataPermit();
                    break;
            }
        }

        /// <summary>
        /// 加载所选角色的模块授权数据
        /// </summary>
        private void InitRoleModulePermit()
        {
            var dv = _RoleModulePermit.Copy().DefaultView;
            dv.RowFilter = _FilterStr;
            treModule.DataSource = dv;
            Format.TreeFormat(treModule);
            treModule.SelectImageList = imgPermission;
            treModule.KeyFieldName = "ModuleId";
            treModule.ExpandAll();
        }

        /// <summary>
        /// 加载所选角色的功能授权数据
        /// </summary>
        private void InitRoleActionPermit()
        {
            var dv = _RoleActionPermit.Copy().DefaultView;
            dv.RowFilter = _FilterStr;
            treAction.DataSource = dv;
            Format.TreeFormat(treAction);
            treAction.SelectImageList = imgPermission;
            treAction.KeyFieldName = "ActionId";
            treAction.ExpandToLevel(0);
        }

        /// <summary>
        /// 加载所选角色的数据授权数据
        /// </summary>
        private void InitRoleDataPermit()
        {
            var dv = _RoleDataPermit.Copy().DefaultView;
            dv.RowFilter = _FilterStr;
            treData.DataSource = dv;
            Format.TreeFormat(treData);
            treData.SelectImageList = imgData;
            treData.KeyFieldName = "DataId";
            treData.Columns["模块"].Width = 227;
            treData.Columns["读写权限"].Width = 60;
            treData.Columns["读写权限"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            treData.ExpandToLevel(1);
        }

        #endregion

        #region 按钮事件处理

        /// <summary>
        /// 重载菜单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitRoleList();
                    break;

                case "NewRole":
                    RoleEdit(false);
                    break;

                case "EditRole":
                    RoleEdit(true);
                    break;

                case "DeleteRole":
                    RoleDelete();
                    break;

                case "AddMember":
                    MemberAdd();
                    break;

                case "Remove":
                    MemberRemove();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑当前所选角色
        /// </summary>
        /// <param name="isEdit"></param>
        private void RoleEdit(bool isEdit)
        {
            var handle = gdvRole.FocusedRowHandle;
            var dig = new RoleWizard
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId = isEdit ? (Guid) gdvRole.GetFocusedDataRow()["ID"] : Guid.Empty
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitRoleList();
                gdvRole.FocusedRowHandle = isEdit ? handle : gdvRole.GetRowHandle(_Roles.Rows.Count - 1);
            }
            dig.Close();
        }

        /// <summary>
        /// 删除当前所选角色
        /// </summary>
        private void RoleDelete()
        {
            var row = gdvRole.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除角色【{row["名称"]}】吗？\r\n角色删除后将无法恢复！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.DeleteRole(UserSession, (Guid) row["ID"]))
                {
                    General.ShowError($"对不起，角色【{row["名称"]}】删除失败！如多次删除失败，请联系管理员。");
                    return;
                }
                
                row.Delete();
            }
        }

        /// <summary>
        /// 为当前所选角色添加成员
        /// </summary>
        private void MemberAdd()
        {
            var handle = gdvRole.FocusedRowHandle;
            var row = gdvRole.GetFocusedDataRow();
            var dig = new AddMember
            {
                Owner = this,
                ObjectId = (Guid) row["ID"]
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitRoleMember();
                gdvRole.FocusedRowHandle = handle;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除当前所选角色成员
        /// </summary>
        private void MemberRemove()
        {
            var handle = gdvRole.FocusedRowHandle;
            var node = treMember.FocusedNode;
            if (General.ShowConfirm($"您确定要移除角色成员【{node.GetValue("成员")}】吗？\r\n角色成员被移除后相应用户将失去该角色赋予的权限！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.DeleteRoleMember(UserSession, (int) node.GetValue("NodeType"), (Guid) node.GetValue("ID")))
                {
                    General.ShowError($"对不起，角色成员【{node.GetValue("成员")}】移除失败！如多次移除失败，请联系管理员。");
                    return;
                }
                
                InitRoleMember();
                gdvRole.FocusedRowHandle = handle;
            }
        }

        #endregion

    }
}
