using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class MaterialData : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        #endregion

        #region 变量声明

        private MasterData _MasterData;
        private MDG_Material _Material;
        private DataTable _SizeType;
        private int _MaxValue;
        private int _Value;

        #endregion

        #region 构造方法

        public MaterialData()
        {
            InitializeComponent();

            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
            treSizeType.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
            treUnit.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
        }

        #endregion

        #region 界面事件

        private void MaterialData_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _SizeType = Commons.Dictionary("Unit", false);

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                _Material = IsEdit ? cli.GetMaterial(OpenForm.UserSession, ObjectId) : new MDG_Material();
            }

            if (!IsEdit)
            {
                _MasterData.CategoryId = ObjectId;
            }

            Text = IsEdit ? "编辑物资" : "新建物资";
            Format.InitTreeListLookUpEdit(trlCategory, Commons.Categorys(OpenForm.ModuleId));
            Format.InitTreeListLookUpEdit(trlSizeType, _SizeType);
            Format.InitTreeListLookUpEdit(trlUnit, _SizeType);
            Format.InitLookUpEdit(lokStoreType, Commons.Dictionary("Storage"));
            InitInfo();
        }

        /// <summary>
        /// 选择分类时置空选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlSizeType_EditValueChanged(object sender, EventArgs e)
        {
            if (trlSizeType.EditValue == null || (bool) _SizeType.Rows.Find(trlSizeType.EditValue)["IsData"]) return;

            trlSizeType.EditValue = null;
        }

        /// <summary>
        /// 选择分类时置空选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (trlUnit.EditValue == null || (bool)_SizeType.Rows.Find(trlUnit.EditValue)["IsData"]) return;

            trlUnit.EditValue = null;
        }

        /// <summary>
        /// 点击清除按钮置空选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lokStoreType_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() != "Clear") return;

            lokStoreType.EditValue = null;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化分类信息
        /// </summary>
        private void InitInfo()
        {
            trlCategory.EditValue = _MasterData.CategoryId;
            txtName.EditValue = _MasterData.Name;
            txtAlias.EditValue = _MasterData.Alias;
            txtCode.EditValue = _MasterData.Code;
            txtModel.EditValue = _Material.Model;
            txtBarCode.EditValue = _Material.BarCode;
            txtSize.EditValue = _Material.Size;
            trlSizeType.EditValue = _Material.SizeType;
            trlUnit.EditValue = _Material.Unit;
            lokStoreType.EditValue = _Material.StorageType;
            memDescription.EditValue = _Material.Description;
            SetIndexValue();
        }

        /// <summary>
        /// 设置Index值
        /// </summary>
        private void SetIndexValue()
        {
            _MaxValue = Commons.GetObjectCount(_MasterData.CategoryId) + (IsEdit ? 0 : 1);
            _Value = IsEdit ? _Material.Index : _MaxValue;

            spiIndex.Properties.MinValue = 1;
            spiIndex.Properties.MaxValue = _MaxValue;
            spiIndex.Value = _Value;
        }

        /// <summary>
        /// 验证输入:名称非空，编码、简称及同分类下名称是否已存在
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("物资名称不能为空！请输入名称。");
                txtName.Focus();
                return false;
            }
            if (txtName.Text.Trim() != _MasterData.Name && Commons.NameIsExist(_MasterData.CategoryId, txtName.Text.Trim(), "Name"))
            {
                General.ShowWarning(string.Format("该分类下已存在名称为【{0}】的物资！", txtName.Text.Trim()));
                txtName.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()) && txtCode.Text.Trim() != _MasterData.Code && Commons.NameIsExist(txtCode.Text.Trim(), "Code"))
            {
                General.ShowWarning(string.Format("已存在编码为【{0}】的物资！", txtCode.Text.Trim()));
                txtCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()) && txtAlias.Text.Trim() != _MasterData.Alias && Commons.NameIsExist(txtAlias.Text.Trim(), "Alias"))
            {
                General.ShowWarning(string.Format("已存在简称为【{0}】的物资！", txtAlias.Text.Trim()));
                txtAlias.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 保护方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.CategoryId = (Guid)trlCategory.EditValue;
            _MasterData.Name = txtName.Text.Trim();
            _MasterData.Alias = txtAlias.Text.Trim();
            _MasterData.Code = txtCode.Text.Trim();
            _Material.Index = (int)spiIndex.Value;
            _Material.BarCode = txtBarCode.Text.Trim();
            _Material.Model = txtModel.Text.Trim();
            _Material.Size = txtSize.Text.Trim();
            _Material.SizeType = (Guid?) trlSizeType.EditValue;
            _Material.Unit = (Guid?) trlUnit.EditValue;
            _Material.StorageType = (Guid?) lokStoreType.EditValue;
            _Material.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new MasterDatasClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateMaterial(OpenForm.UserSession, _MasterData, _Material, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("未能更新数据！");
                }
                else
                {
                    if (cli.AddMaterial(OpenForm.UserSession, _MasterData, _Material, _Value))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("数据保存失败！");
                }
            }
        }

        #endregion

    }
}
