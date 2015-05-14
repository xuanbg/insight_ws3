using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Business.SCM.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.SCM
{
    public partial class Supplier : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 行政区划数据
        /// </summary>
        public DataTable RegionData { private get; set; }

        #endregion

        #region 变量声明

        private SCMClient _Client;
        private MasterData _MasterData;
        private MDG_Supplier _Supplier;
        private DataTable _Enterprise;
        private DataTable _Industry;
        private DataView _Province;
        private DataView _City;
        private DataView _District;
        
        #endregion

        #region 构造方法

        public Supplier()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时初始化数据及界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supplier_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _Industry = Commons.Dictionary("Industry");
            _Enterprise = Commons.Dictionary("Enterprise");

            _Client = new SCMClient(OpenForm.Binding, OpenForm.Address);
            _Supplier = IsEdit ? _Client.GetSupplier(OpenForm.UserSession, ObjectId) : new MDG_Supplier();
            _Client.Close();

            _Province = RegionData.Copy().DefaultView;
            _City = RegionData.Copy().DefaultView;
            _District = RegionData.Copy().DefaultView;
            _Province.RowFilter = "IsData = 0 and Code like '%0000'";

            lokCity.Enabled = _Supplier.Province != null;
            lokDistrict.Enabled = _Supplier.City != null;

            Format.InitLookUpEdit(lokProvince, _Province);
            Format.InitLookUpEdit(lokCity, _City);
            Format.InitLookUpEdit(lokDistrict, _District);
            Format.InitLookUpEdit(lokIndustry, _Industry.DefaultView);
            Format.InitLookUpEdit(lokEnterprise, _Enterprise.DefaultView);

            InitBaseInfo();
        }

        /// <summary>
        /// 根据所选省/直辖市切换市县数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Province_EditValueChanged(object sender, EventArgs e)
        {
            lokCity.Enabled = lokProvince.EditValue != null;
            lokCity.EditValue = null;
            lokDistrict.EditValue = null;
            _City.RowFilter = "ParentId = '" + lokProvince.EditValue + "'";
            lokCity.Properties.DataSource = _City;
        }

        /// <summary>
        /// 根据所选市切换县数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void City_EditValueChanged(object sender, EventArgs e)
        {
            if (lokCity.EditValue == null) return;
            lokDistrict.Enabled = lokCity.EditValue != null;
            lokDistrict.EditValue = null;
            _District.RowFilter = "ParentId = '" + lokCity.EditValue + "'";
            lokDistrict.Properties.DataSource = _District;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化客户信息
        /// </summary>
        private void InitBaseInfo()
        {
            Text = IsEdit ? "编辑供应商" : "新增供应商";
            txtName.EditValue = _MasterData.Name;
            txtAlias.EditValue = _MasterData.Alias;

            txtPhone.EditValue = _Supplier.Phone;
            txtWebsite.EditValue = _Supplier.Website;
            txtZipCode.EditValue = _Supplier.ZipCode;
            lokProvince.EditValue = _Supplier.Province;
            lokCity.EditValue = _Supplier.City;
            lokDistrict.EditValue = _Supplier.District;
            txtAddress.EditValue = _Supplier.Address;

            lokIndustry.EditValue = _Supplier.IndustryType;
            lokEnterprise.EditValue = _Supplier.EnterpriseType;
            txtBusiness.EditValue = _Supplier.BusinessScope;
            txtCorporation.EditValue = _Supplier.Corporation;
            txtScale.EditValue = _Supplier.Scale;
            speStaffs.EditValue = _Supplier.Staffs;
            txtRegister.EditValue = _Supplier.RegisterNumber;
            txtTax.EditValue = _Supplier.TaxNumber;
            datRegisterDate.EditValue = _Supplier.RegisterDate;
            memDescription.EditValue = _Supplier.Description;
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("供应商名称不能为空！请输入正确的供应商名称。");
                txtName.Focus();
                return false;
            }

            _Client = new SCMClient(OpenForm.Binding, OpenForm.Address);
            if (txtName.Text.Trim() != _MasterData.Name && Commons.NameIsExist(txtName.Text.Trim(), "Name"))
            {
                _Client.Close();
                General.ShowError(string.Format("已存在名称为【{0}】的数据！", txtName.Text.Trim()));
                txtName.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()) && txtAlias.Text.Trim() != _MasterData.Alias && Commons.NameIsExist(txtAlias.Text.Trim(), "Alias"))
            {
                _Client.Close();
                General.ShowError(string.Format("已存在简称为【{0}】的数据！", txtAlias.Text.Trim()));
                txtAlias.Focus();
                return false;
            }
            _Client.Close();

            if (lokProvince.EditValue == null)
            {
                General.ShowError("地址填写不完整！请选择供应商所在的省或直辖市。");
                lokProvince.Focus();
                return false;
            }
            if (lokCity.EditValue == null)
            {
                General.ShowError("地址填写不完整！请选择供应商所在的市或地区。");
                lokCity.Focus();
                return false;
            }
            if (lokDistrict.EditValue == null)
            {
                General.ShowError("地址填写不完整！请选择供应商所在的区县");
                lokDistrict.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                General.ShowError("地址填写不完整！请输入供应商所在街道和门牌号码等具体地址信息。");
                txtAddress.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 按钮事件
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.Name = txtName.Text.Trim();
            _MasterData.Alias = txtAlias.Text.Trim();
            _Supplier.EnterpriseType = (Guid?)lokEnterprise.EditValue;
            _Supplier.IndustryType = (Guid?)lokIndustry.EditValue;
            _Supplier.RegisterNumber = txtRegister.Text.Trim();
            _Supplier.TaxNumber = txtTax.Text.Trim();
            _Supplier.Corporation = txtCorporation.Text.Trim();
            _Supplier.RegisterDate = (DateTime?)datRegisterDate.EditValue;
            _Supplier.BusinessScope = txtBusiness.Text.Trim();
            _Supplier.Scale = txtScale.Text.Trim();
            _Supplier.Staffs = speStaffs.Value == 0 ? null : (int?)speStaffs.Value;
            _Supplier.Province = (Guid)lokProvince.EditValue;
            _Supplier.City = (Guid)lokCity.EditValue;
            _Supplier.District = (Guid)lokDistrict.EditValue;
            _Supplier.Address = txtAddress.Text.Trim();
            _Supplier.Phone = txtPhone.Text.Trim();
            _Supplier.ZipCode = txtZipCode.Text.Trim();
            _Supplier.Website = txtWebsite.Text.Trim();
            _Supplier.Description = memDescription.Text.Trim();

            _Client = new SCMClient(OpenForm.Binding, OpenForm.Address);
            if (IsEdit)
            {
                if (_Client.UpdateMasterData(OpenForm.UserSession, _MasterData, _Supplier))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("未能更新数据！");
                }
            }
            else
            {
                _Supplier.CreatorDeptId = OpenForm.UserSession.DeptId;
                _Supplier.CreatorUserId = OpenForm.UserSession.UserId;
                if (_Client.AddMasterData(OpenForm.UserSession, _MasterData, _Supplier))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("数据保存失败！");
                }
            }
            _Client.Close();
        }

        #endregion

    }
}
