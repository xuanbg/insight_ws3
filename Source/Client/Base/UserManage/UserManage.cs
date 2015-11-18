using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class UserManage : MdiBase
    {

        #region 变量声明

        private DataTable _Users;
        private DataTable _Groups;
        private DataTable _Members;
        private DataView _Member;

        #endregion

        #region 构造函数

        public UserManage()
        {
            InitializeComponent();
            gdvGroup.FocusedRowObjectChanged += gdvGroup_FocusedRowObjectChanged;
        }

        #endregion

        #region 界面事件处理

        private void UserManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitUserList();
            InitGroupList();
        }

        /// <summary>
        /// 所选用户组发生变化刷新用户组成员列表和设置工具栏用户组相关按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvGroup_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            InitMemberList();
            var builtIn = (bool)gdvGroup.GetFocusedDataRow()["内置"];
            SwitchItemStatus(new Context("EditGroup", !builtIn), new Context("DeleteGroup", !builtIn), new Context("AddMember", _Users.Rows.Count > _Member.Count), new Context("Remove", _Member.Count > 0));
        }

        /// <summary>
        /// 所选用户发生变化时设置工具栏用户相关按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvUser_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var builtIn = (bool)gdvUser.GetFocusedDataRow()["内置"];
            var status = gdvUser.GetFocusedDataRow()["状态"].ToString();
            SwitchItemStatus(new Context("EditUser", !builtIn), new Context("DeleteUser", !builtIn), new Context("Banned", (!builtIn && status == "正常")), new Context("Release", status != "正常"));
        }

        /// <summary>
        /// 用户列表刷新时设置工具栏用户相关按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdUser_Paint(object sender, PaintEventArgs e)
        {
            var builtIn = (bool)gdvUser.GetFocusedDataRow()["内置"];
            var status = gdvUser.GetFocusedDataRow()["状态"].ToString();
            SwitchItemStatus(new Context("Banned", (!builtIn && status == "正常")), new Context("Release", status != "正常"));
            SwitchItemStatus(new Context("AddMember", _Users.Rows.Count > _Member.Count), new Context("Remove", _Member.Count > 0));
        }

        /// <summary>
        /// 双击用户组列表编辑当前选中用户组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvGroup_DoubleClick(object sender, EventArgs e)
        {
            var edit = barManager.Items["EditGroup"];
            if (gdvGroup.GetFocusedRow() == null || !edit.Enabled) return;

            GroupEdit(true);
        }

        /// <summary>
        /// 双击用户列表编辑当前选中用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvUser_DoubleClick(object sender, EventArgs e)
        {
            var edit = barManager.Items["EditUser"];
            if (gdvUser.GetFocusedRow() == null || !edit.Enabled) return;

            UserEdit(true);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化用户组列表
        /// </summary>
        private void InitGroupList()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Groups = cli.GetGroups(UserSession);
                _Members = cli.GetGroupMembers(UserSession);
            }

            grdGroup.DataSource = _Groups;
            Format.GridFormat(gdvGroup);
            gdvGroup.Columns["组名称"].Width = 120;
            gdvGroup.Columns["描述"].Width = 286;
            gdvGroup.MoveFirst();
        }

        /// <summary>
        /// 初始化用户列表
        /// </summary>
        private void InitUserList()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Users = cli.GetUsers(UserSession);
            }

            grdUser.DataSource = _Users;
            Format.GridFormat(gdvUser);
            gdvUser.Columns["名称"].Width = 120;
            gdvUser.Columns["登录名"].Width = 100;
            gdvUser.Columns["描述"].Width = 211;
        }

        /// <summary>
        /// 初始化用户组成员列表
        /// </summary>
        private void InitMemberList()
        {
            // 绑定数据源
            var filter = "GroupId = '" + gdvGroup.GetFocusedDataRow()[0] + "'";
            _Member = _Members.Copy().DefaultView;
            _Member.RowFilter = filter;
            grdMember.DataSource = _Member;
            Format.GridFormat(gdvMember);
            gdvMember.Columns["用户名"].Width = 120;
            gdvMember.Columns["登录名"].Width = 100;
            gdvMember.Columns["描述"].Width = 226;
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
                    InitUserList();
                    InitGroupList();
                    break;

                case "NewGroup":
                    GroupEdit(false);
                    break;

                case "EditGroup":
                    GroupEdit(true);
                    break;

                case "DeleteGroup":
                    GroupDelete();
                    break;

                case "AddMember":
                    MemberAdd();
                    break;

                case "Remove":
                    MemberRemove();
                    break;

                case "NewUser":
                    UserEdit(false);
                    break;

                case "EditUser":
                    UserEdit(true);
                    break;

                case "DeleteUser":
                    UserDelete();
                    break;

                case "Banned":
                    Banned();
                    break;

                case "Release":
                    Release();
                    break;

                case "Reset":
                    Reset();
                    break;

                case "Online":
                    Online();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑当前选中用户组
        /// </summary>
        /// <param name="isEdit"></param>
        private void GroupEdit(bool isEdit)
        {
            var dig = new Group
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectData = isEdit ? gdvGroup.GetFocusedDataRow() : _Groups.NewRow(),
                ObjectId = (Guid) gdvGroup.GetFocusedDataRow()["ID"]
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                if (isEdit)
                {
                    gdvGroup.GetFocusedDataRow().ItemArray = dig.ObjectData.ItemArray;
                    _Groups.AcceptChanges();
                }
                else
                {
                    _Groups.Rows.Add(dig.ObjectData);
                    gdvGroup.FocusedRowHandle = gdvGroup.GetRowHandle(_Groups.Rows.Count - 1);
                }
                grdUser.Refresh();
            }
            dig.Close();
        }

        /// <summary>
        /// 删除当前选中用户组
        /// </summary>
        private void GroupDelete()
        {
            var row = gdvGroup.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除用户组【{row["组名称"]}】吗？\r\n用户组删除后将无法恢复！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.DeleteGroup(UserSession, (Guid) row["ID"]))
                {
                    General.ShowError($"对不起，用户组【{row["组名称"]}】已经被使用，无法删除！");
                    return;
                }
                
                row.Delete();
                _Groups.AcceptChanges();
                grdGroup.Refresh();
            }
        }

        /// <summary>
        /// 为当前选中用户组添加成员
        /// </summary>
        private void MemberAdd()
        {
            var focused = gdvGroup.FocusedRowHandle;
            var id = (Guid)gdvGroup.GetFocusedDataRow()["ID"];
            DataTable list;
            using (var cli = new BaseClient(Binding, Address))
            {
                list = cli.GetGroupMemberBeSides(UserSession, id);
            }
            var dig = new Member
            {
                IsAdd = true,
                List = list
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                using (var cli = new BaseClient(Binding, Address))
                {
                    if (!cli.AddGroupMember(UserSession, id, dig.IdList))
                    {
                        General.ShowError("未能增加任何成员！");
                        return;
                    }
                    
                    InitGroupList();
                    gdvGroup.FocusedRowHandle = focused;
                }
            }
            dig.Close();
        }

        /// <summary>
        /// 为当前选中用户组删除成员
        /// </summary>
        private void MemberRemove()
        {
            var focused = gdvGroup.FocusedRowHandle;
            var id = (Guid)gdvGroup.GetFocusedDataRow()["ID"];
            var list = _Members.Select($"GroupId = '{id}'").CopyToDataTable();

            var dig = new Member
            {
                IsAdd = false,
                List = list
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                using (var cli = new BaseClient(Binding, Address))
                {
                    if (!cli.DeleteMember(UserSession, dig.IdList))
                    {
                        General.ShowError("未能移除任何成员！");
                        return;
                    }
                    
                    InitGroupList();
                    gdvGroup.FocusedRowHandle = focused;
                }
            }
            dig.Close();
        }

        /// <summary>
        /// 新建/编辑当前选中用户
        /// </summary>
        /// <param name="isEdit"></param>
        private void UserEdit(bool isEdit)
        {
            var dig = new User
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectData = isEdit ? gdvUser.GetFocusedDataRow() : _Users.NewRow(),
                ObjectId = (Guid) gdvUser.GetFocusedDataRow()["ID"]
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                if (isEdit)
                {
                    gdvUser.GetFocusedDataRow().ItemArray = dig.ObjectData.ItemArray;
                    _Users.AcceptChanges();
                }
                else
                {
                    _Users.Rows.Add(dig.ObjectData);
                    gdvUser.FocusedRowHandle = gdvUser.GetRowHandle(_Users.Rows.Count - 1);
                }
                grdUser.Refresh();
            }
            dig.Close();
        }

        /// <summary>
        /// 删除当前选中用户
        /// </summary>
        private void UserDelete()
        {
            var row = gdvUser.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除用户【{row["登录名"]}】吗？\r\n用户删除后将无法恢复！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.DeleteUser(UserSession, (Guid) row["ID"]))
                {
                    General.ShowError($"对不起，用户【{row["登录名"]}】已经在系统中产生了相关业务记录，无法删除！\r\n如果您想禁止该用户登录系统，请使用封禁功能。");
                    return;
                }
                
                foreach (var memberRow in _Members.Rows.Cast<DataRow>().Where(memberRow => memberRow["UserId"].Equals(row["ID"])))
                {
                    memberRow.Delete();
                }
                _Members.AcceptChanges();
                InitMemberList();

                row.Delete();
                _Users.AcceptChanges();
                grdUser.Refresh();
            }
        }

        /// <summary>
        /// 封禁当前选中用户
        /// </summary>
        private void Banned()
        {
            var row = gdvUser.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要封禁用户【{row["登录名"]}】吗？\r\n用户被封禁后将无法登录系统！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.UpdateUserStatus(UserSession, (Guid) row["ID"], false)) return;

                row["状态"] = "封禁";
                _Users.AcceptChanges();
                grdUser.Refresh();
            }
        }

        /// <summary>
        /// 解封当前选中用户
        /// </summary>
        private void Release()
        {
            var row = gdvUser.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要对用户【{row["登录名"]}】解封吗？\r\n用户解封后即可正常登录系统！") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.UpdateUserStatus(UserSession, (Guid) row["ID"], true)) return;

                row["状态"] = "正常";
                _Users.AcceptChanges();
                grdUser.Refresh();
            }
        }

        /// <summary>
        /// 重置当前选中用户的密码
        /// </summary>
        private void Reset()
        {
            var row = gdvUser.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要重置用户【{row["登录名"]}】的密码为 123456 吗？") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (cli.ResetPassword(UserSession, (Guid)row["ID"]))
                {
                    General.ShowMessage($"用户【{row["登录名"]}】的密码已经重置。");
                }
                else
                {
                    General.ShowError($"对不起，用户【{row["登录名"]}】的密码重置失败。");
                }
            }
        }

        /// <summary>
        /// 在线用户管理
        /// </summary>
        private void Online()
        {
            var dig = new OnlineUser {Owner = this};
            dig.ShowDialog();
            dig.Close();
        }

        #endregion

    }
}
