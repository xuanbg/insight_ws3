using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class EditExpense : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        #endregion

        #region 变量声明

        private MasterData _MasterData;
        private MDG_Expense _Expense;
        private DataTable _Units;
        private int _MaxValue;
        private int _Value;

        #endregion

        #region 构造方法

        public EditExpense()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
            treUnit.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 页面载入
        /// </summary>
        /// <param name="sender">引入</param>
        /// <param name="e">页面载入事件</param>
        private void Expenses_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _Units = Commons.Dictionary("Unit", false);
            Format.InitTreeListLookUpEdit(trlCategory, Commons.Categorys(OpenForm.ModuleId));
            Format.InitTreeListLookUpEdit(trlUnit, _Units);

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                _Expense = IsEdit ? cli.GetExpense(OpenForm.UserSession, ObjectId) : new MDG_Expense();
            }

            if (!IsEdit)
            {
                _MasterData.CategoryId = ObjectId;
            }

            Text = IsEdit ? "编辑项目" : "新建项目";
            InitInfo();
        }

        /// <summary>
        /// 选择分类时置空选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (trlUnit.EditValue == null || (bool) _Units.Rows.Find(trlUnit.EditValue)["IsData"]) return;

            trlUnit.EditValue = null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化基本信息
        /// </summary>
        private void InitInfo()
        {
            trlCategory.EditValue = _MasterData.CategoryId;
            txtName.EditValue = _MasterData.Name;
            txtAlias.EditValue = _MasterData.Alias;
            txtCode.EditValue = _MasterData.Code;
            trlUnit.EditValue = _Expense.Unit;
            txtPrice.EditValue = _Expense.Price;
            memDescription.EditValue = _Expense.Description;
            SetIndexValue();
        }

        /// <summary>
        /// 设置Index值
        /// </summary>
        private void SetIndexValue()
        {
            _MaxValue = Commons.GetObjectCount(_MasterData.CategoryId) + (IsEdit ? 0 : 1);
            _Value = IsEdit ? _Expense.Index : _MaxValue;

            spiIndex.Properties.MinValue = 1;
            spiIndex.Properties.MaxValue = _MaxValue;
            spiIndex.Value = _Value;
        }

        /// <summary>
        /// 检查输入
        /// </summary>
        /// <returns>输入合格与否</returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("字典数据名称不能为空！请输入名称。");
                txtName.Focus();
                return false;
            }
            if (txtName.Text.Trim() != _MasterData.Name && Commons.NameIsExist(_MasterData.CategoryId, txtName.Text.Trim(), "Name"))
            {
                General.ShowWarning($"该分类下已存在名称为【{txtName.Text.Trim()}】的数据！");
                txtName.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()) && txtCode.Text.Trim() != _MasterData.Code && Commons.NameIsExist(txtCode.Text.Trim(), "Code"))
            {
                General.ShowWarning($"已存在编码为【{txtCode.Text.Trim()}】的数据！");
                txtCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()) && txtAlias.Text.Trim() != _MasterData.Alias && Commons.NameIsExist(txtAlias.Text.Trim(), "Alias"))
            {
                General.ShowWarning($"已存在简称为【{txtAlias.Text.Trim()}】的数据！");
                txtAlias.Focus();
                return false;
            }
            return true;
        } 

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.CategoryId = (Guid)trlCategory.EditValue;
            _MasterData.Name = txtName.Text.Trim();
            _MasterData.Alias = txtAlias.Text.Trim();
            _MasterData.Code = txtCode.Text.Trim();
            _Expense.Index = (int)spiIndex.Value;
            _Expense.Unit = (Guid?) trlUnit.EditValue;
            _Expense.Price = (txtPrice.EditValue == null || (decimal)txtPrice.EditValue == 0) ? null : (decimal?)txtPrice.EditValue;
            _Expense.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateExpense(OpenForm.UserSession, _MasterData, _Expense, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("未能更新数据！");
                }
                else
                {
                    if (cli.AddExpense(OpenForm.UserSession, _MasterData, _Expense, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("数据保存失败！");
                }
            }
        }

        #endregion

    }
}
