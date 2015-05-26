using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class RoleWizard : WizardBase
    {

        #region 变量声明

        private SYS_Role _Role;
        private DataTable _Actions;
        private DataTable _RelData;
        private List<object> _OldActions = new List<object>();
        private List<object> _OldRelData = new List<object>();

        #endregion

        #region 构造方法

        public RoleWizard()
        {
            InitializeComponent();

            treModule.CustomDrawNodeImages += DrawNodeImages;
            treAction.CustomDrawNodeImages += DrawNodeImages;
            treDataModule.CustomDrawNodeImages += DrawNodeImages;
            treDataPerm.CustomDrawNodeImages += DrawNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 加载向导界面时调用初始化界面方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleWizard_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "编辑角色" : "新建角色";
            wizPage1.AllowNext = false;
            InitWizard();
            InitModule();
            InitDataModule();
        }

        /// <summary>
        /// 根据输入切换下一步按钮可用状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.EditValue = null;
            }
            wizPage1.AllowNext = txtName.EditValue != null;
        }

        /// <summary>
        /// 焦点离开名称输入框时切换下一步按钮是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_Leave(object sender, EventArgs e)
        {
            CheckName();
        }

        /// <summary>
        /// 改变业务模块选中状态后刷新功能操作树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treModule_AfterCheckNode(object sender, NodeEventArgs e)
        {
            InitAction();
        }

        /// <summary>
        /// 选择节点后更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treAction_AfterCheckNode(object sender, NodeEventArgs e)
        {
            treAction.FocusedNode = e.Node;
            NodesForEach(e.Node, 1);
        }

        /// <summary>
        /// 改变业务模块选中状态后刷新数据权限树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treDataModule_AfterCheckNode(object sender, NodeEventArgs e)
        {
            InitDataMode();
        }

        /// <summary>
        /// 选择节点后更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treDataPerm_AfterCheckNode(object sender, NodeEventArgs e)
        {
            treDataPerm.FocusedNode = e.Node;
            NodesForEach(e.Node, 2);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化向导界面
        /// </summary>
        private void InitWizard()
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Role = IsEdit ? cli.GetRole(OpenForm.UserSession, ObjectId) : new SYS_Role();
                _Actions = cli.GetRoleActions(OpenForm.UserSession, ObjectId);
                _RelData = cli.GetRoleRelData(OpenForm.UserSession, ObjectId);
            }

            _Actions.Select("Action = 2 and CheckState is not null").ToList().ForEach(r => _OldActions.Add(r["ID"]));
            _RelData.Select("Action > 3 and CheckState is not null").ToList().ForEach(r => _OldRelData.Add(r["ID"]));

            txtName.EditValue = _Role.Name;
            memDescription.EditValue = _Role.Description;
        }

        /// <summary>
        /// 初始化模块树
        /// </summary>
        private void InitModule()
        {
            var dv = _Actions.Copy().DefaultView;
            dv.RowFilter = "Action < 2";
            treModule.DataSource = dv;
            Format.TreeFormat(treModule);
            treModule.Columns["Info"].Visible = false;
            treModule.Columns["Original"].Visible = false;
            treModule.CollapseAll();
            treModule.ExpandToLevel(0);

            _Actions.Select("Action < 2 and CheckState = 'Checked'").ToList().ForEach(r =>
            {
                treModule.SetNodeCheckState(treModule.FindNodeByKeyID(r["ID"]), CheckState.Checked, true);
                r["CheckState"] = null;
            });

            InitAction();
        }

        /// <summary>
        /// 初始化功能树
        /// </summary>
        private void InitAction()
        {
            var dv = _Actions.Copy().DefaultView;
            treAction.DataSource = dv;
            Format.TreeFormat(treAction);
            treAction.Columns["Name"].Width = 210;
            treAction.Columns["Info"].Width = 80;
            treAction.Columns["Info"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            treAction.Columns["Original"].Visible = false;
            treAction.CollapseAll();
            treAction.ExpandToLevel(0);
            treAction.FocusedNode = treAction.FindNode(n => n.Level == 0);

            // 初始化Action树节点CheckState
            _Actions.Select("CheckState is not null").ToList().ForEach(r => treAction.SetNodeCheckState(treAction.FindNodeByKeyID(r["ID"]), (CheckState)Enum.Parse(typeof(CheckState), r["CheckState"].ToString()), true));

            // 裁剪Action树，去掉Module树上未选中节点
            var ids = new List<object>();
            treModule.GetNodeList().ForEach(n => ids.Add(n.GetValue("ID")));
            treModule.GetAllCheckedNodes().ForEach(n => ids.Remove(n.GetValue("ID")));
            treModule.GetAllCheckedNodes().ForEach(n => { if (n.ParentNode != null)ids.Remove(n.ParentNode.GetValue("ID")); });
            ids.ForEach(id => treAction.DeleteNode(treAction.FindNodeByFieldValue("ID", id)));
        }

        /// <summary>
        /// 初始化数据模块树
        /// </summary>
        private void InitDataModule()
        {
            var dv = _RelData.Copy().DefaultView;
            dv.RowFilter = "Action < 4";
            treDataModule.DataSource = dv;
            Format.TreeFormat(treDataModule);
            treDataModule.Columns["Info"].Visible = false;
            treDataModule.Columns["Original"].Visible = false;
            treDataModule.CollapseAll();
            treDataModule.ExpandToLevel(0);

            _RelData.Select("Action < 4 and CheckState = 'Checked'").ToList().ForEach(r =>
            {
                treDataModule.SetNodeCheckState(treDataModule.FindNodeByKeyID(r["ID"]), CheckState.Checked, true);
                r["CheckState"] = null;
            });

            InitDataMode();
        }

        /// <summary>
        /// 初始化数据授权模式列表
        /// </summary>
        private void InitDataMode()
        {
            var dv = _RelData.Copy().DefaultView;
            treDataPerm.DataSource = dv;
            Format.TreeFormat(treDataPerm);
            treDataPerm.Columns["Name"].Width = 210;
            treDataPerm.Columns["Info"].Width = 80;
            treDataPerm.Columns["Info"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            treDataPerm.Columns["Original"].Visible = false;
            treDataPerm.ExpandAll();

            // 初始化DataPermit树节点CheckState
            _RelData.Select("CheckState is not null").ToList().ForEach(r => treDataPerm.SetNodeCheckState(treDataPerm.FindNodeByKeyID(r["ID"]), (CheckState)Enum.Parse(typeof(CheckState), r["CheckState"].ToString()), true));

            // 裁剪DataPermit树，去掉Module树上未选中节点
            var ids = new List<object>();
            treDataModule.GetNodeList().ForEach(n => ids.Add(n.GetValue("ID")));
            treDataModule.GetAllCheckedNodes().ForEach(n => ids.Remove(n.GetValue("ID")));
            treDataModule.GetAllCheckedNodes().ForEach(n => { if (n.ParentNode != null)ids.Remove(n.ParentNode.GetValue("ID")); });
            ids.ForEach(id => treDataPerm.DeleteNode(treDataPerm.FindNodeByFieldValue("ID", id)));
        }

        /// <summary>
        /// 遍历选择节点及子节点，修改节点Info列内容及DataTable对应记录
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type"></param>
        private void NodesForEach(TreeListNode node, int type)
        {
            if (node.HasChildren)
            {
                node.Nodes.ToList().ForEach(n => NodesForEach(n, type));
                return;
            }

            var pstr = "";
            switch (type)
            {
                case 1:
                    pstr = node.CheckState == CheckState.Checked ? "允许" : (node.CheckState == CheckState.Indeterminate ? "拒绝" : null);
                    _Actions.Rows.Find(node.GetValue("ID"))["CheckState"] = node.CheckState.ToString();
                    _Actions.Rows.Find(node.GetValue("ID"))["Info"] = pstr;
                    break;

                case 2:
                    pstr = node.CheckState == CheckState.Checked ? "读写" : (node.CheckState == CheckState.Indeterminate ? "只读" : null);
                    _RelData.Rows.Find(node.GetValue("ID"))["CheckState"] = node.CheckState.ToString();
                    _RelData.Rows.Find(node.GetValue("ID"))["Info"] = pstr;
                    break;
            }
            node.SetValue("Info", pstr);
        }

        /// <summary>
        /// 验证名称是否可用
        /// </summary>
        private void CheckName()
        {
            var name = txtName.Text.Trim();
            if (name == _Role.Name || !Commons.NameIsExist(name, "Name", "SYS_Role")) return;

            General.ShowError(string.Format("系统中已经存在名称为【{0}】的角色！请重新命名。", name));
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

        #endregion

        #region 确定按钮方法

        /// <summary>
        /// 点击完成将数据存入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wizRole_FinishClick(object sender, CancelEventArgs e)
        {
            _Role.Name = txtName.Text.Trim();
            _Role.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            var ids = new List<object>();
            treModule.GetAllCheckedNodes().ForEach(n => ids.Add(n.GetValue("ID")));
            foreach (DataRow row in _Actions.Rows)
            {
                if (string.IsNullOrEmpty(row["Info"].ToString()) || !ids.Exists(id => id.Equals(row["ParentId"])))
                    row.Delete();
                else if (treAction.FindNodeByKeyID(row["ID"]).CheckState.ToString() == row["Original"].ToString() && _OldActions.Remove(row["ID"]))
                    row.Delete();
            }
            _Actions.AcceptChanges();

            ids.Clear();
            treDataModule.GetAllCheckedNodes().ForEach(n => ids.Add(n.GetValue("ID")));
            foreach (DataRow row in _RelData.Rows)
            {
                if (string.IsNullOrEmpty(row["Info"].ToString()) || !ids.Exists(id => id.Equals(row["ParentId"])))
                    row.Delete();
                else if (treDataPerm.FindNodeByKeyID(row["ID"]).CheckState.ToString() == row["Original"].ToString() && _OldRelData.Remove(row["ID"]))
                    row.Delete();
            }
            _RelData.AcceptChanges();

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.EditRole(OpenForm.UserSession, _Role, _OldActions, _OldRelData, null, _Actions, _RelData, null))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("角色权限更新失败！如多次失败，请联系管理员。");
                }
                else
                {
                    if (cli.AddRole(OpenForm.UserSession, _Role, _Actions, _RelData, null))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("角色权限保存失败！如多次失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
