using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Business.CRM.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.CRM
{
    public partial class Customer : DialogBase
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

        /// <summary>
        /// 客户类型数据
        /// </summary>
        public DataTable ClassData { private get; set; }

        /// <summary>
        /// 客户状态数据
        /// </summary>
        public DataTable StatuData { private get; set; }

        #endregion

        #region 变量声明

        private CRMClient _Client;
        private MasterData _MasterData;
        private MDG_Customer _Customer;
        private DataTable _Enterprise;
        private DataTable _Industry;
        private DataView _Province;
        private DataView _City;
        private DataView _District;
        
        #endregion

        #region 构造方法

        public Customer()
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
        private void Customer_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _Industry = Commons.Dictionary("Industry");
            _Enterprise = Commons.Dictionary("Enterprise");

            _Client = new CRMClient(OpenForm.Binding, OpenForm.Address);
            _Customer = IsEdit ? _Client.GetCustomer(OpenForm.UserSession, ObjectId) : new MDG_Customer();
            _Client.Close();

            _Province = RegionData.Copy().DefaultView;
            _City = RegionData.Copy().DefaultView;
            _District = RegionData.Copy().DefaultView;
            _Province.RowFilter = "IsData = 0 and Code like '%0000'";

            lokCity.Enabled = _Customer.Province != null;
            lokDistrict.Enabled = _Customer.City != null;

            Format.InitLookUpEdit(lokProvince, _Province);
            Format.InitLookUpEdit(lokCity, _City);
            Format.InitLookUpEdit(lokDistrict, _District);
            Format.InitLookUpEdit(lokIndustry, _Industry.DefaultView);
            Format.InitLookUpEdit(lokEnterprise, _Enterprise.DefaultView);
            Format.InitLookUpEdit(lokStatu, StatuData.DefaultView);
            Format.InitLookUpEdit(lokClass, ClassData.DefaultView);

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
            Text = IsEdit ? "编辑客户" : "新增客户";
            txtName.EditValue = _MasterData.Name;
            txtAlias.EditValue = _MasterData.Alias;

            txtPhone.EditValue = _Customer.Phone;
            txtWebsite.EditValue = _Customer.Website;
            txtZipCode.EditValue = _Customer.ZipCode;
            lokProvince.EditValue = _Customer.Province;
            lokCity.EditValue = _Customer.City;
            lokDistrict.EditValue = _Customer.District;
            txtAddress.EditValue = _Customer.Address;
            lokStatu.EditValue = _Customer.Statu;
            lokClass.EditValue = _Customer.Class;
            if (lokStatu.EditValue == null) lokStatu.ItemIndex = 0;
            if (lokClass.EditValue == null) lokClass.ItemIndex = 0;

            lokIndustry.EditValue = _Customer.IndustryType;
            lokEnterprise.EditValue = _Customer.EnterpriseType;
            txtBusiness.EditValue = _Customer.BusinessScope;
            txtCorporation.EditValue = _Customer.Corporation;
            txtScale.EditValue = _Customer.Scale;
            speStaffs.EditValue = _Customer.Staffs;
            txtRegister.EditValue = _Customer.RegisterNumber;
            txtTax.EditValue = _Customer.TaxNumber;
            datRegisterDate.EditValue = _Customer.RegisterDate;
            memDescription.EditValue = _Customer.Description;
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("客户名称不能为空！请输入正确的客户名称。");
                txtName.Focus();
                return false;
            }

            _Client = new CRMClient(OpenForm.Binding, OpenForm.Address);
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
                General.ShowError("地址填写不完整！请选择客户所在的省或直辖市。");
                lokProvince.Focus();
                return false;
            }
            if (lokCity.EditValue == null)
            {
                General.ShowError("地址填写不完整！请选择客户所在的市或地区。");
                lokCity.Focus();
                return false;
            }
            if (lokDistrict.EditValue == null)
            {
                General.ShowError("地址填写不完整！请选择客户所在的区县");
                lokDistrict.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                General.ShowError("地址填写不完整！请输入客户所在街道和门牌号码等具体地址信息。");
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
            _Customer.EnterpriseType = (Guid?)lokEnterprise.EditValue;
            _Customer.IndustryType = (Guid?)lokIndustry.EditValue;
            _Customer.RegisterNumber = txtRegister.Text.Trim();
            _Customer.TaxNumber = txtTax.Text.Trim();
            _Customer.Corporation = txtCorporation.Text.Trim();
            _Customer.RegisterDate = (DateTime?)datRegisterDate.EditValue;
            _Customer.BusinessScope = txtBusiness.Text.Trim();
            _Customer.Scale = txtScale.Text.Trim();
            _Customer.Staffs = speStaffs.Value == 0 ? null : (int?)speStaffs.Value;
            _Customer.Province = (Guid)lokProvince.EditValue;
            _Customer.City = (Guid)lokCity.EditValue;
            _Customer.District = (Guid)lokDistrict.EditValue;
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.ZipCode = txtZipCode.Text.Trim();
            _Customer.Website = txtWebsite.Text.Trim();
            _Customer.Class = (Guid)lokClass.EditValue;
            _Customer.Statu = (Guid)lokStatu.EditValue;
            _Customer.Description = memDescription.Text.Trim();

            _Client = new CRMClient(OpenForm.Binding, OpenForm.Address);
            if (IsEdit)
            {
                if (_Client.UpdateCustomer(OpenForm.UserSession, _MasterData, _Customer))
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
                if (_Client.AddCustomer(OpenForm.UserSession, _MasterData, _Customer))
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
