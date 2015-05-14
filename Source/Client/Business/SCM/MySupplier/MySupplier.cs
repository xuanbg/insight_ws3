using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Business.SCM.Service;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.Business.SCM
{
    public partial class MySupplier : MdiBase
    {

        #region 变量声明

        private SCMClient _Client;
        private DataTable _Suppliers;
        private DataTable _SupplierInfo;
        private DataTable _Contacts;
        private DataTable _ContactInfo;
        private DataTable _Region;
        private Guid _SupplierId;
        private Guid _ContactId;
        private bool _HasSupplier;
        private bool _IsMySupplier;
        private bool _CanEdit;
        private bool _HasContact;
        private string _TypeFilter;
        private string _Filter;

        #endregion

        #region 构造函数

        public MySupplier()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 加载窗体时初始化查询/筛选条件和供应商列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySupplier_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitData();
        }

        /// <summary>
        /// 第一次加载时获取行政区划数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySupplier_Shown(object sender, EventArgs e)
        {
            var ts = new ThreadStart(GetRegion);
            var td = new Thread(ts);
            td.Start();
        }

        /// <summary>
        /// 选择/取消选择筛选条件后刷新供应商列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            _TypeFilter = "-1" + (chkMy.Checked ? " ,0" : "") + (chkSub.Checked ? " ,1" : "") + (chkUnion.Checked ? " ,2" : "");
            _Filter = string.Format("Type in ({0})", _TypeFilter);
            InitSupplier();
        }

        /// <summary>
        /// 改变所选供应商后刷新工具栏按钮状态、详细信息和联系人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvSupplier_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _SupplierId = _HasSupplier ? (Guid)gdvSupplier.GetFocusedDataRow()["SupplierId"] : Guid.Empty;
            _IsMySupplier = _HasSupplier && (int)gdvSupplier.GetFocusedDataRow()["Type"] == 0;
            _CanEdit = _HasSupplier && (int)gdvSupplier.GetFocusedDataRow()["Type"] % 2 == 0;
            var enable = gdvSupplier.GetFocusedDataRow()["状态"].ToString() == "正常";
            SwitchItemStatus(new Context("EditSupplier", _CanEdit), new Context("DelSupplier", _IsMySupplier && enable),
                             new Context("Sharing", _IsMySupplier), new Context("Transfer", _IsMySupplier), new Context("Enable", _IsMySupplier && !enable));
            grdOther.Visible = false;
            InitSupplierInfo();
            InitContact();
        }

        /// <summary>
        /// 双击供应商列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (_IsMySupplier) Supplier(true);
        }

        private void glvContact_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _ContactId = _HasContact ? (Guid)glvContact.GetFocusedDataRow()["ID"] : Guid.Empty;
            grdOther.Visible = false;
        }

        /// <summary>
        /// 双击联系人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glvContact_DoubleClick(object sender, EventArgs e)
        {
            if (_IsMySupplier) Contact(true);
        }

        /// <summary>
        /// 输入回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 清空查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            Filter_CheckedChanged(null, null);
        }

        /// <summary>
        /// 点击查看其它联系方式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbeView_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            grdOther.Visible = grdOther.Visible == false;
            if (grdOther.Visible) InitContactInfo();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            _Contacts = Commons.GetContacts();
            _ContactInfo = Commons.GetContactInfos();

            _Client = new SCMClient(Binding, Address);
            _Suppliers = _Client.GetSuppliers(UserSession);
            _SupplierInfo = _Client.GetSupplierInfo(UserSession);
            _Client.Close();

            Filter_CheckedChanged(null, null);
        }

        /// <summary>
        /// 初始化供应商列表
        /// </summary>
        private void InitSupplier()
        {
            var dv = _Suppliers.Copy().DefaultView;
            dv.RowFilter = _Filter;
            var dt = dv.ToTable();
            dt.PrimaryKey = new[] { dt.Columns["ID"] };
            var dl = (from DataRow row in dt.Rows let str = string.Format("SupplierId = '{0}'", row["SupplierId"]) where (int) row["Type"] == 2 && dt.Select(str).Length > 1 select row["ID"]).ToList();
            dl.ForEach(id => dt.Rows.Find(id).Delete());
            dt.AcceptChanges();
            _HasSupplier = dt.Rows.Count > 0;

            grdSupplier.DataSource = dt;
            Format.GridFormat(gdvSupplier);
            gdvSupplier.Columns["状态"].Width = 40;
            gdvSupplier.Columns["状态"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvSupplier.Columns["采购经理"].Width = 60;
            gdvSupplier.Columns["采购经理"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvSupplier.Columns["名称"].Width = 200;
            gdvSupplier.Columns["简称"].Width = 80;
            gdvSupplier.Columns["经营范围"].Width = 120;
            gdvSupplier.Columns["资产规模"].Width = 60;
            gdvSupplier.Columns["资产规模"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvSupplier.Columns["员工人数"].Width = 60;
            gdvSupplier.Columns["员工人数"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvSupplier.Columns["地址"].Width = 335;
            gdvSupplier.Columns["邮编"].Width = 60;
            gdvSupplier.Columns["邮编"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            if (!_HasSupplier)
            {
                SwitchItemStatus(new Context("EditSupplier", false), new Context("DelSupplier", false),
                                 new Context("Enable", false), new Context("Transfer", false), new Context("Sharing", false),
                                 new Context("NewContact", false), new Context("EditContact", false), new Context("DelContact", false));
                _SupplierId = Guid.Empty;
                InitSupplierInfo();
                InitContact();
            }
        }

        /// <summary>
        /// 初始化供应商详细信息列表
        /// </summary>
        private void InitSupplierInfo()
        {
            var dv = _SupplierInfo.DefaultView;
            dv.RowFilter = string.Format("SupplierId = '{0}'", _SupplierId);

            vrdInfo.RowHeaderWidth = 80;
            vrdInfo.RecordWidth = 240;
            vrdInfo.DataSource = dv;
            vrdInfo.Rows[0].Visible = false;
            vrdInfo.Rows[11].Height = 46;
        }

        /// <summary>
        /// 初始化联系人列表
        /// </summary>
        private void InitContact()
        {
            var dv = _Contacts.DefaultView;
            dv.RowFilter = string.Format("ParentId = '{0}'", _SupplierId);
            _HasContact = dv.Count > 0;

            grdContact.DataSource = dv;
            SwitchItemStatus(new Context("NewContact", _CanEdit), new Context("EditContact", _IsMySupplier && _HasContact), new Context("DelContact", _IsMySupplier && _HasContact));
        }

        /// <summary>
        /// 初始化联系方式列表
        /// </summary>
        private void InitContactInfo()
        {
            var dv = _ContactInfo.Copy().DefaultView;
            dv.RowFilter = string.Format("MasterDataId = '{0}'", glvContact.GetFocusedDataRow()["ID"]);

            grdOther.DataSource = dv;
            Format.GridFormat(gdvOther);
            gdvOther.Columns["联系方式"].Width = 80;
            gdvOther.Columns["号码"].Width = 140;
            gdvOther.Columns["主要"].Width = 40;
        }

        /// <summary>
        /// 根据输入条件查询数据
        /// </summary>
        private void Search()
        {
            _Filter = string.Format("Type in ({0}) and 名称 like '%{1}%'", _TypeFilter, bteSearch.Text.Trim());
            InitSupplier();
        }

        /// <summary>
        /// 获取行政区划数据
        /// </summary>
        private void GetRegion()
        {
            _Region = Commons.Dictionary("Region", false);
        }

        #endregion

        #region 按钮事件

        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitData();
                    break;
                case "NewSupplier":
                    Supplier(false);
                    break;
                case "EditSupplier":
                    Supplier(true);
                    break;
                case "DelSupplier":
                    DelSupplier();
                    break;
                case "Sharing":
                    Transfer(false);
                    break;
                case "Transfer":
                    Transfer(true);
                    break;
                case "Enable":
                    Enable();
                    break;
                case "NewContact":
                    Contact(false);
                    break;
                case "EditContact":
                    Contact(true);
                    break;
                case "DelContact":
                    DelContact();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑供应商
        /// </summary>
        /// <param name="isEdit"></param>
        private void Supplier(bool isEdit)
        {
            var rowHandle = gdvSupplier.FocusedRowHandle;
            var dig = new Supplier
            {
                Owner = this,
                ObjectId = _SupplierId,
                IsEdit = isEdit,
                RegionData = _Region
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitData();
                gdvSupplier.FocusedRowHandle = rowHandle;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除供应商，如不能删除则设置状态为停用
        /// </summary>
        private void DelSupplier()
        {
            var row = gdvSupplier.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要删除供应商【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            var n = Commons.DelMasterData(_SupplierId);
            switch (n)
            {
                case 1:
                    _Suppliers.Rows.Find(row["ID"]).Delete();
                    _Suppliers.AcceptChanges();
                    InitSupplier();
                    break;

                case 2:
                    General.ShowWarning("该供应商已被使用，无法删除，已停用！");
                    _Suppliers.Rows.Find(row["ID"])["状态"] = "停用";
                    InitSupplier();
                    break;

                default:
                    General.ShowError("对不起，该供应商已经被使用，且无法停用！");
                    break;
            }
        }

        /// <summary>
        /// 将停用的选定数据重新启用
        /// </summary>
        private void Enable()
        {
            var row = gdvSupplier.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要启用【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            if (Commons.EnableMasterData(_SupplierId, "MDG_Supplier"))
            {
                _Suppliers.Rows.Find(row["ID"])["状态"] = "正常";
                InitSupplier();
            }
            else
            {
                General.ShowError(string.Format("对不起，供应商【{0}】启用失败！", row["名称"]));
            }
        }

        /// <summary>
        /// 共享/移交供应商
        /// </summary>
        private void Transfer(bool isTransfer)
        {
            var dig = new Handover
            {
                Owner = this,
                IsTransfer = isTransfer,
                ObjectId = _SupplierId,
                MUId = isTransfer ? (Guid?) gdvSupplier.GetFocusedDataRow()["ID"] : null
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitData();
            }
            dig.Close();
        }

        /// <summary>
        /// 新建/编辑联系人
        /// </summary>
        /// <param name="isEdit"></param>
        private void Contact(bool isEdit)
        {
            var fcr = glvContact.FocusedRowHandle;
            var dig = new Contact
            {
                Owner = this,
                ObjectId = isEdit ? _ContactId : Guid.Empty,
                ParentId = _SupplierId,
                IsEdit = isEdit
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                _Contacts = Commons.GetContacts();
                _ContactInfo = Commons.GetContactInfos();
                InitContact();
                glvContact.FocusedRowHandle = fcr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        private void DelContact()
        {
            var row = glvContact.GetFocusedDataRow();
            if (General.ShowConfirm(string.Format("您确定要删除【{0}】吗?", row["姓名"])) != DialogResult.OK) return;

            if (Commons.DelMasterData( _ContactId) > 0)
            {
                if (row["主要联系人"].ToString() == "是")
                {
                    General.ShowWarning("您删除了一个主要联系人，请为该供应商设定一个新的主要联系人！");
                }
                _Contacts.Rows.Find(row["ID"]).Delete();
                _Contacts.AcceptChanges();
                InitContact();
            }
            else
            {
                General.ShowError(string.Format("对不起！删除联系人【{0}】失败。", row["名称"]));
            }
        }

        #endregion

    }
}
