using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class EditData : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// 返回结果集
        /// </summary>
        public DataRow ObjectData { get; set; }

        #endregion

        #region 变量声明

        private MasterData _MasterData;
        private MDG_Dictionary _Dictionary;
        private int _MaxValue;
        private int _Value;

        #endregion

        #region 构造方法

        public EditData()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        private void MasterData_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                _Dictionary = IsEdit ? cli.GetDictionary(OpenForm.UserSession, ObjectId) : new MDG_Dictionary();
            }

            if (!IsEdit)
            {
                _MasterData.CategoryId = ObjectId;
                _Dictionary.CreatorDeptId = OpenForm.UserSession.DeptId;
                _Dictionary.CreatorUserId = OpenForm.UserSession.UserId;
            }

            Text = IsEdit ? "编辑数据" : "新建数据";
            txtName.EditValue = _MasterData.Name;
            txtAlias.EditValue = _MasterData.Alias;
            txtCode.EditValue = _MasterData.Code;
            memDescription.EditValue = _Dictionary.Description;

            SetIndexValue();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置Index值
        /// </summary>
        private void SetIndexValue()
        {
            _MaxValue = Commons.GetObjectCount(_MasterData.CategoryId) + (IsEdit ? 0 : 1);
            _Value = IsEdit ? _Dictionary.Index : _MaxValue;

            spiIndex.Properties.MinValue = 1;
            spiIndex.Properties.MaxValue = _MaxValue;
            spiIndex.Value = _Value;
        }

        /// <summary>
        /// 验证输入:名称非空，名称、编码、简称同分类下是否已存在
        /// </summary>
        /// <returns></returns>
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
                General.ShowWarning(string.Format("该分类下已存在名称为【{0}】的数据！", txtName.Text.Trim()));
                txtName.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()) && txtCode.Text.Trim() != _MasterData.Code && Commons.NameIsExist(txtCode.Text.Trim(), "Code"))
            {
                General.ShowWarning(string.Format("已存在编码为【{0}】的数据！", txtCode.Text.Trim()));
                txtCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()) && txtAlias.Text.Trim() != _MasterData.Alias && Commons.NameIsExist(txtAlias.Text.Trim(), "Alias"))
            {
                General.ShowWarning(string.Format("已存在简称为【{0}】的数据！", txtAlias.Text.Trim()));
                txtAlias.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 确认按钮方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.Name = txtName.Text.Trim();
            _MasterData.Alias = txtAlias.Text.Trim();
            _MasterData.Code = txtCode.Text.Trim();
            _Dictionary.Index = (int)spiIndex.Value;
            _Dictionary.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateDictionary(OpenForm.UserSession, _MasterData, _Dictionary, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("未能更新数据！");
                }
                else
                {
                    if (cli.AddDictionary(OpenForm.UserSession, _MasterData, _Dictionary, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("数据保存失败！");
                }
            }
        }

        #endregion

    }
}
