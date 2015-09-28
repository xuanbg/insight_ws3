using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;
using ComboBoxItem = Insight.WS.Client.Common.ComboBoxItem;

namespace Insight.WS.Client.Platform.Base
{
    public partial class OrgNode : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public int NodeType { get; set; }

        #endregion

        #region 变量声明

        private SYS_Organization _Org;
        private DataTable _Position;
        private Guid? _ParentId;
        private int _MaxValue;
        private int _Value;

        #endregion

        #region 构造方法

        public OrgNode()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件处理

        /// <summary>
        /// 如果是编辑模式，加载该ID的机构信息并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgNode_Load(object sender, EventArgs e)
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Org = (ObjectId != Guid.Empty) ? cli.GetOrg(OpenForm.UserSession, ObjectId) : new SYS_Organization();
            }

            _Position = Commons.Dictionary("Position");
            Format.InitLookUpEdit(lokPosition, _Position);

            if (IsEdit)
                EditOrgNode();
            else
                NewOrgNode();

            txtCode.Text = _Org.Code;
            txtName.Text = _Org.Name;
            txtFullName.Text = _Org.FullName;
            txtAlias.Text = _Org.Alias;
        }

        /// <summary>
        /// 根据节点类型设置复选框和岗位下拉框是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNodeType_SelectedValueChanged(object sender, EventArgs e)
        {
            chkRoot.Enabled = (cmbNodeType.SelectedItem.GetHashCode() == 1 && !IsEdit);
            lokPosition.Enabled = (cmbNodeType.SelectedItem.GetHashCode() == 3);
        }

        private void lokPosition_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() != "Clear") return;

            lokPosition.EditValue = null;
        }

        private void chkRoot_CheckedChanged(object sender, EventArgs e)
        {
            _ParentId = chkRoot.Checked ? null : (Guid?)ObjectId;
            cmbNodeType.Enabled = !chkRoot.Checked;
            SetIndexValue();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 新建模式
        /// </summary>
        private void NewOrgNode()
        {
            Text = "新建";
            switch (_Org.NodeType)
            {
                case 1:
                    cmbNodeType.Properties.Items.Clear();
                    cmbNodeType.Properties.Items.Add(new ComboBoxItem(1, "机构"));
                    cmbNodeType.Properties.Items.Add(new ComboBoxItem(2, "部门"));
                    cmbNodeType.SelectedIndex = (NodeType >= 1 && NodeType < 3) ? NodeType - 1 : 1;
                    chkRoot.Checked = false;
                    break;

                case 2:
                    cmbNodeType.Properties.Items.Clear();
                    cmbNodeType.Properties.Items.Add(new ComboBoxItem(2, "部门"));
                    cmbNodeType.Properties.Items.Add(new ComboBoxItem(3, "职位"));
                    cmbNodeType.SelectedIndex = (NodeType > 1 && NodeType <= 3) ? NodeType - 2 : 1;
                    chkRoot.Checked = false;
                    break;

                default:
                    cmbNodeType.Properties.Items.Clear();
                    cmbNodeType.Properties.Items.Add(new ComboBoxItem(1, "机构"));
                    cmbNodeType.SelectedIndex = 0;
                    chkRoot.Checked = true;
                    break;
            }

            _ParentId = chkRoot.Checked ? null : (Guid?)ObjectId;
            SetIndexValue();

            cmbNodeType.Enabled = !chkRoot.Checked;
            chkRoot.Enabled = (cmbNodeType.SelectedItem.GetHashCode() == 1 && _Org.NodeType != 3 && _Org.NodeType != 0);
            lokPosition.Enabled = (cmbNodeType.SelectedItem.GetHashCode() == 3);

            _Org = new SYS_Organization();
        }

        /// <summary>
        /// 编辑模式
        /// </summary>
        private void EditOrgNode()
        {
            Text = "编辑";
            _ParentId = _Org.ParentId;
            SetIndexValue();

            cmbNodeType.Properties.Items.Clear();
            cmbNodeType.Properties.Items.Add(new ComboBoxItem(1, "机构"));
            cmbNodeType.Properties.Items.Add(new ComboBoxItem(2, "部门"));
            cmbNodeType.Properties.Items.Add(new ComboBoxItem(3, "职位"));
            cmbNodeType.SelectedIndex = _Org.NodeType - 1;
            cmbNodeType.Enabled = false;
            chkRoot.Checked = _ParentId == null;
            chkRoot.Enabled = false;
            lokPosition.EditValue = _Org.PositionId;
        }

        /// <summary>
        /// 设置Index值
        /// </summary>
        private void SetIndexValue()
        {
            _MaxValue = Commons.GetObjectCount(_ParentId, "ParentId", "SYS_Organization") + (IsEdit ? 0 : 1);
            _Value = IsEdit ? _Org.Index : _MaxValue;

            spiIndex.Properties.MinValue = 1;
            spiIndex.Properties.MaxValue = _MaxValue;
            spiIndex.Value = _Value;
        }

        /// <summary>
        /// 输入合法性验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            var name = txtName.Text.Trim();
            var fullName = txtFullName.Text.Trim();
            var alias = txtAlias.Text.Trim();
            var code = txtCode.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                General.ShowWarning("名称不能为空！请输入正确的名称。");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                General.ShowWarning("全称不能为空！全称用于输出，请输入正确的全称。");
                txtFullName.Focus();
                return false;
            }

            if (_Org.Name != name && Commons.NameIsExist(_ParentId, name, "Name", "SYS_Organization", true))
            {
                General.ShowWarning("同一父节点下已经存在名称为【" + name + "】的节点！请不要重复输入。");
                txtName.Focus();
                return false;
            }

            if (cmbNodeType.EditValue.GetHashCode() != 3 && _Org.FullName != fullName && Commons.NameIsExist(fullName, "FullName", "SYS_Organization"))
            {
                General.ShowWarning("已经存在全称为【" + fullName + "】的节点！请不要重复输入。");
                txtFullName.Focus();
                return false;
            }

            if (txtAlias.Text.Trim() != "" && _Org.Alias != alias && Commons.NameIsExist(alias, "Alias", "SYS_Organization"))
            {
                General.ShowWarning("已经存在简称为【" + alias + "】的节点！请不要重复输入。");
                txtAlias.Focus();
                return false;
            }

            if (txtCode.Text.Trim() != "" && _Org.Code != code && Commons.NameIsExist(code, "Code", "SYS_Organization"))
            {
                General.ShowWarning("已经存在编码为【" + code + "】的节点！请不要重复输入。");
                txtCode.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 重写虚方法实现

        /// <summary>
        /// 点击确定按钮
        /// 1、进行输入合法性检查
        /// 2、将用户输入值赋于对象_Org
        /// 3、将_Org的值插入或更新到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _Org.Index = (int)spiIndex.Value;
            _Org.Name = (string)txtName.EditValue;
            _Org.FullName = (string)txtFullName.EditValue;
            _Org.Alias = (string)txtAlias.EditValue;
            _Org.Code = (string)txtCode.EditValue;
            _Org.PositionId = (Guid?)lokPosition.EditValue;

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateOrg(OpenForm.UserSession, _Org, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError($"没有更新{cmbNodeType.Text}【{_Org.FullName}】的任何信息！");
                }
                else
                {
                    _Org.NodeType = cmbNodeType.EditValue.GetHashCode();
                    _Org.ParentId = _ParentId;
                    if (!cli.AddOrg(OpenForm.UserSession, _Org, _Value))
                    {
                        General.ShowError($"对不起，因为未知的原因，新建{cmbNodeType.Text}【{_Org.FullName}】失败！\r\n如出现重复失败的情况，请联系管理员。");
                        return;
                    }
                    
                    NodeType = _Org.NodeType;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        #endregion

    }
}
