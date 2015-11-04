using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraWizard;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    public partial class ReportWizard : WizardBase
    {

        #region 变量声明

        private SYS_Report_Definition _Definition;
        private DataTable _Templets;
        private DataTable _Rules;
        private DataTable _Entitys;
        private DataTable _Members;
        private readonly List<object> _OldRules = new List<object>();
        private readonly List<object> _OldEntitys = new List<object>();
        private readonly List<object> _OldMembers = new List<object>();
        private Guid _DefinitionId;
        private bool _HasName;
        private bool _HasTemp;
        private bool _HasRule;
        private bool _HasEntity;
        private bool _HasMember;
        private List<string> _DataSource; 

        #endregion

        #region 构造方法

        public ReportWizard()
        {
            InitializeComponent();

            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
            treTemplet.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
            treEntity.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 加载向导界面时初始化控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "编辑报表" : "新建报表";
            _DefinitionId = IsEdit ? ObjectId : Guid.Empty;
            spiTimes.Properties.MinValue = 1;
            spiTimes.Properties.MaxValue = 5;
            wizPage1.AllowNext = false;
            wizPage2.AllowFinish = false;
            InitWizard();
        }

        /// <summary>
        /// 根据报表名称、模板和分期规则内容切换下一步按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.EditValue = null;
            }
            _HasName = txtName.EditValue != null;
            wizPage1.AllowNext = _HasName && _HasTemp && _HasRule;
        }

        /// <summary>
        /// 焦点离开名称输入框时验证是否重名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_Leave(object sender, EventArgs e)
        {
            CheckName();
        }

        /// <summary>
        /// 1、模板下拉列表所选内容改变时，如所选为分类，则清空所选
        /// 2、根据报表名称、模板和分期规则内容切换下一步按钮状态
        /// 3、如报表名称为空，设置报表名称为模板名称并验证重名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlTemplet_EditValueChanged(object sender, EventArgs e)
        {
            _HasTemp = trlTemplet.EditValue != null;
            wizPage1.AllowNext = _HasName && _HasTemp && _HasRule;
            if (trlTemplet.EditValue == null) return;

            if (!(bool)_Templets.Rows.Find(trlTemplet.EditValue)["IsData"])
            {
                trlTemplet.EditValue = null;
            }
            else if (txtName.EditValue == null)
            {
                txtName.Text = trlTemplet.Text;
                CheckName();
            }
        }

        /// <summary>
        /// 根据所选统计模式切换分期规则选择模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMode_EditValueChanged(object sender, EventArgs e)
        {
            cmbDelay.Enabled = cmbMode.SelectedIndex < 2;
            spiTimes.Enabled = cmbMode.SelectedIndex < 2;
            grdRules.Enabled = cmbMode.SelectedIndex < 2;
            cmbDelay.SelectedIndex = cmbDelay.Enabled ? (_Definition.Delay < 0 ? 1 : 0) : -1;
            spiTimes.EditValue = spiTimes.Enabled ? (_Definition.Delay == 0 ? 2 : Math.Abs(_Definition.Delay)) : 0;

            if (cmbMode.SelectedIndex > 0)
            {
                gdvRules.ClearSelection();
                gdvRules.SelectRow(0);
                gdvRules.FocusedRowHandle = 0;
            }
        }

        /// <summary>
        /// 根据报表名称、模板和分期规则内容切换下一步按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvRules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow < 0)
            {
                foreach (DataRow row in _Rules.Rows)
                {
                    row["Selected"] = e.Action == CollectionChangeAction.Add;
                }
            }
            else
            {
                _Rules.Rows[e.ControllerRow]["Selected"] = e.Action == CollectionChangeAction.Add;
                _HasRule = gdvRules.SelectedRowsCount > 0;
                wizPage1.AllowNext = _HasName && _HasTemp && _HasRule;
            }
        }

        /// <summary>
        /// 如统计模式为时点，清除选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvRules_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (cmbMode.SelectedIndex != 1) return;

            gdvRules.UnselectRow(e.PrevFocusedRowHandle);
        }

        /// <summary>
        /// 点击下一步时根据选择状态和报送对象选择状态切换完成按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wizard_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            _HasEntity = HasCheckedNode();
            _HasMember = HasMember();
            wizPage2.AllowFinish = _HasEntity && _HasMember;
        }

        /// <summary>
        /// 组织机构树所选节点变化后保存报送对象列表状态并刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treEntity_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            InitMemberList();
        }

        /// <summary>
        /// 选择组织机构树节点后根据选择状态和报送对象选择状态切换完成按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treEntity_AfterCheckNode(object sender, NodeEventArgs e)
        {
            _Entitys.Rows[e.Node.Id]["Selected"] = e.Node.Checked;
            treEntity.SetFocusedNode(e.Node);
            _HasEntity = HasCheckedNode();
            _HasMember = HasMember();
            wizPage2.AllowFinish = _HasEntity && _HasMember;
        }

        /// <summary>
        /// 根据组织机构树节点选择状态和报送对象选择状态切换完成按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _Members.Rows.Find(gdvMember.GetFocusedDataRow()["ID"])["Selected"] = gdvMember.IsRowSelected(gdvMember.FocusedRowHandle);
            _HasEntity = HasCheckedNode();
            _HasMember = HasMember();
            wizPage2.AllowFinish = _HasEntity && _HasMember;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化向导界面控件
        /// </summary>
        private void InitWizard()
        {
            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                _Definition = IsEdit
                    ? cli.GetDefinition(OpenForm.UserSession, _DefinitionId)
                    : new SYS_Report_Definition();
                _DataSource = cli.GetDataSource(OpenForm.UserSession);
                _Rules = cli.GetReportRule(OpenForm.UserSession, _DefinitionId);
                _Entitys = cli.GetReportEntity(OpenForm.UserSession, _DefinitionId);
                _Members = cli.GetReportMember(OpenForm.UserSession, _DefinitionId);
                _HasMember = _Members.Select("Selected = 1").Length > 0;
            }

            _Members.Select("Selected = 1").ToList().ForEach(r => _OldMembers.Add(r["RoleId"]));
            if (!IsEdit)
            {
                _Definition.CategoryId = ObjectId;
                _Definition.Mode = 1;
                _Definition.Delay = 2;
                _Definition.Type = 1;
            }

            _Templets = Commons.Templets("Report", false);
            Format.InitTreeListLookUpEdit(trlCategory, Commons.Categorys(OpenForm.ModuleId));
            Format.InitTreeListLookUpEdit(trlTemplet, _Templets);
            cmbDataSource.Properties.Items.AddRange(_DataSource);
            InitRuleList();
            InitEntityTree();
            InitMemberList();
            InitBaseInfo();
        }

        /// <summary>
        /// 初始化基本信息
        /// </summary>
        private void InitBaseInfo()
        {
            txtName.EditValue = _Definition.Name;
            trlCategory.EditValue = _Definition.CategoryId;
            trlTemplet.EditValue = IsEdit ? (Guid?)_Definition.TemplateId : null;
            cmbMode.SelectedIndex = _Definition.Mode - 1;
            cmbDelay.SelectedIndex = _Definition.Delay > 0 ? 0 : 1;
            cmbDataSource.Text = _Definition.DataSource;
            cmbType.SelectedIndex = _Definition.Type - 1;
            memDescription.EditValue = _Definition.Description;
        }

        /// <summary>
        /// 初始化分期规则列表
        /// </summary>
        private void InitRuleList()
        {
            var dv = _Rules.Copy().DefaultView;
            grdRules.DataSource = dv;
            Format.GridFormat(gdvRules, 0);
            gdvRules.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            gdvRules.Columns["名称"].Width = 160;
            gdvRules.Columns["周期"].Width = 60;
            gdvRules.Columns["周期"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            for (var i = 0; i < gdvRules.RowCount; i++)
            {
                if (!(bool) gdvRules.GetDataRow(i)["Selected"]) continue;

                _OldRules.Add(gdvRules.GetDataRow(i)["ID"]);
                gdvRules.SelectRow(i);
                if (cmbMode.SelectedIndex == 1)
                {
                    gdvRules.FocusedRowHandle = i;
                }
            }
        }

        /// <summary>
        /// 初始化统计主体列表
        /// </summary>
        private void InitEntityTree()
        {
            var dv = _Entitys.Copy().DefaultView;
            treEntity.DataSource = dv;
            Format.TreeFormat(treEntity);
            treEntity.SelectImageList = imgOrgTreeNode;
            treEntity.ExpandToLevel(0);

            foreach (var n in treEntity.GetNodeList().Where(n => (bool)n.GetValue("Selected")))
            {
                _OldEntitys.Add(n.GetValue("ID"));
                n.Checked = true;
            }
        }

        /// <summary>
        /// 初始化报送对象列表
        /// </summary>
        private void InitMemberList()
        {
            var dv = _Members.Copy().DefaultView;
            dv.RowFilter = $"OrgId = '{treEntity.FocusedNode.GetValue("OrgId")}'";
            grdMember.DataSource = dv;
            Format.GridFormat(gdvMember, 0);
            gdvMember.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            gdvMember.Columns["名称"].Width = 100;
            gdvMember.Columns["描述"].Width = 124;

            for (var i = 0; i < gdvMember.RowCount; i++)
            {
                if (!(bool) gdvMember.GetDataRow(i)["Selected"]) continue;

                gdvMember.SelectRow(i);
            }
        }

        /// <summary>
        /// 判断是否有选中节点
        /// </summary>
        /// <returns></returns>
        private bool HasCheckedNode()
        {
            return treEntity.GetNodeList().Aggregate(false, (current, node) => node.Checked || current);
        }

        /// <summary>
        /// 判断是否选有有效报送对象
        /// </summary>
        /// <returns></returns>
        private bool HasMember()
        {
            return treEntity.GetNodeList().Aggregate(false, (current, node) => (node.Checked && _Members.Select($"OrgId = '{node.GetValue("OrgId")}' and Selected = 1").Length > 0) || current);
        }

        /// <summary>
        /// 检查名称在所选分类下是否重复，如重复，提示用户名称重复
        /// </summary>
        private void CheckName()
        {
            var name = txtName.Text.Trim();
            if (name != _Definition.Name && Commons.NameIsExist(_Definition.CategoryId, name, "Name", "SYS_Report_Definition"))
            {
                General.ShowError($"此分类下已经存在名称为【{name}】的报表！请重新命名。");
            }
        }

        /// <summary>
        /// 删除未选择记录
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        /// <param name="col"></param>
        private void RemoveUnusedData(DataTable table, ICollection<object> list, string col = "ID")
        {
            foreach (DataRow row in table.Rows)
            {
                if (!(bool)row["Selected"])
                {
                    row.Delete();
                }
                else if (list.Remove(row[col]))
                {
                    row.Delete();
                }
                else if (row.RowState == DataRowState.Unchanged)
                {
                    row["Selected"] = false;
                }
            }
            table.AcceptChanges();
        }

        #endregion

        #region 完成方法

        /// <summary>
        /// 点击完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wzdReport_FinishClick(object sender, CancelEventArgs e)
        {
            _Definition.CategoryId = (Guid)trlCategory.EditValue;
            _Definition.Name = txtName.Text.Trim();
            _Definition.TemplateId = (Guid)trlTemplet.EditValue;
            _Definition.Mode = cmbMode.SelectedIndex + 1;
            _Definition.Delay = (int)spiTimes.Value * (cmbDelay.SelectedIndex > 0 ? -1 : 1);
            _Definition.Type = cmbType.SelectedIndex + 1;
            _Definition.DataSource = cmbDataSource.Text;
            _Definition.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            foreach (var node in treEntity.GetNodeList())
            {
                var hasMember = _Members.Select($"OrgId = '{node.GetValue("OrgId")}' and Selected = 1").Length > 0;
                if (hasMember)
                    _OldEntitys.Remove(node.GetValue("ID"));
                else
                    _Entitys.Rows.Find(node.GetValue("ID"))["Selected"] = 0;
            }

            RemoveUnusedData(_Rules, _OldRules);
            RemoveUnusedData(_Entitys, _OldEntitys);
            RemoveUnusedData(_Members, _OldMembers, "RoleId");

            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.EditDefinition(OpenForm.UserSession, _Definition, _OldRules, _OldEntitys, _OldMembers, _Rules, _Entitys, _Members))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("报表定义更新失败！如多次失败，请联系管理员。");
                }
                else
                {
                    if (cli.AddDefinition(OpenForm.UserSession, _Definition, _Rules, _Entitys, _Members))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("报表定义保存失败！如多次失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
