using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class CodeScheme : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        #endregion

        #region 变量声明

        private SYS_Code_Scheme _Scheme;

        #endregion

        #region 构造方法

        public CodeScheme()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 打开对话框时初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeScheme_Load(object sender, EventArgs e)
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Scheme = IsEdit ? cli.GetScheme(OpenForm.UserSession, ObjectId) : new SYS_Code_Scheme();
            }

            Text = IsEdit ? "编辑编码方案" : "新建编码方案";
            txtName.EditValue = _Scheme.Name;
            txtFormat.EditValue = _Scheme.CodeFormat;
            txtMark.EditValue = _Scheme.SerialFormat;
            memDescription.EditValue = _Scheme.Description;
        }

        /// <summary>
        /// 点击预览按钮预览编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntPreview_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var format = txtFormat.Text.Trim();
            if (string.IsNullOrEmpty(format))
            {
                General.ShowError("请先设定编码格式！");
                txtFormat.Focus();
                return;
            }
            
            var id = IsEdit ? ObjectId : Guid.Empty;
            var mark = txtMark.Text.Trim();
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                bntPreview.Text = cli.GetCodePreview(OpenForm.UserSession, id, format, mark);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtName.EditValue == null)
            {
                General.ShowWarning("必须输入名称！且名称必须唯一。");
                txtName.Focus();
                return false;
            }
            if (txtFormat.EditValue == null)
            {
                General.ShowWarning("必须输入编码规则！");
                txtFormat.Focus();
                return false;
            }
            if (_Scheme.Name != txtName.Text.Trim() && Commons.NameIsExist(txtName.Text.Trim(), "Name", "SYS_Code_Scheme"))
            {
                General.ShowWarning($"编码方案【{txtName.Text.Trim()}】已经存在！");
                txtName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 完成方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _Scheme.Name = txtName.Text.Trim();
            _Scheme.CodeFormat = txtFormat.Text.Trim();
            _Scheme.SerialFormat = txtMark.Text.Trim();
            _Scheme.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateScheme(OpenForm.UserSession, _Scheme))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError($"更新编码方案【{_Scheme.Name}】失败！如多次失败，请联系管理员。");
                }
                else
                {
                    if (cli.AddScheme(OpenForm.UserSession, _Scheme))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("新建编码方案【" + _Scheme.Name + "】失败！如多次失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
