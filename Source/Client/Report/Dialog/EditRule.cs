using System;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    public partial class EditRule : DialogBase
    {

        #region 属性

        public bool IsEdit { get; set; }

        #endregion

        #region 变量声明

        private SYS_Report_Rules _Rule;

        #endregion

        #region 构造方法

        public EditRule()
        {
            InitializeComponent();
        }
        
        #endregion
       
        #region 界面事件

        /// <summary>
        /// 编辑分期时，为控件赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditRule_Load(object sender, EventArgs e)
        {
            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                _Rule = IsEdit ? cli.GetRule(OpenForm.UserSession, ObjectId) : new SYS_Report_Rules();
            }

            Text = IsEdit ? "编辑分期" : "新建分期";
            txtName.Text = _Rule.Name;
            if (IsEdit)
            {
                if (_Rule.Cycle != null) spiTimes.Value = (decimal)_Rule.Cycle;
                if (_Rule.CycleType != null) cmbCycleType.SelectedIndex = (int)_Rule.CycleType - 1;
            }
            if (_Rule.StartTime != null) datStart.DateTime = IsEdit ? (DateTime)_Rule.StartTime : DateTime.Today;
            memDescription.Text = _Rule.Description;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("分期规则名称不能为空！请输入规则名称。");
                txtName.Focus();
                return false;
            }

            if (_Rule.Name != txtName.Text.Trim() && Commons.NameIsExist(txtName.Text.Trim(), "Name", "SYS_Report_Rules"))
            {
                General.ShowWarning("已存在名称为【" + txtName.Text.Trim() + "】的分期规则！请修改规则名称。");
                txtName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 保护方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _Rule.Name = txtName.Text.Trim();
            _Rule.Cycle = (int)spiTimes.Value;
            _Rule.CycleType = cmbCycleType.SelectedIndex + 1;
            _Rule.StartTime = (DateTime)datStart.EditValue;
            _Rule.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.EditRule(OpenForm.UserSession, _Rule))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("对不起，分期规则保存失败！如连续保存失败，请联系管理员。");
                }
                else
                {
                    if (cli.AddRule(OpenForm.UserSession, _Rule) != null)
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("对不起，分期规则更新失败！如连续更新失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
