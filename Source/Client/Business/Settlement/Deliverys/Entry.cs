using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Business.Settlement.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class Entry : DialogBase
    {

        #region 属性

        /// <summary>
        /// 供应商数据
        /// </summary>
        public DataTable MasterDatas { private get; set; }

        /// <summary>
        /// 物资数据
        /// </summary>
        public DataTable Material { private get; set; }

        /// <summary>
        /// 单位数据
        /// </summary>
        public DataTable Units { private get; set; }

        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrint { get; private set; }

        /// <summary>
        /// 单据ID
        /// </summary>
        public object ReceiptId { get; private set; }

        #endregion

        #region 变量声明

        private ABS_Delivery _Delivery;
        private DataTable _ItemList;
        private Guid? _CustomerId;
        private bool _HasCustomer;
        private bool _IsEdit;
        private bool _IsPlan;

        #endregion

        #region 构造方法

        public Entry()
        {
            InitializeComponent();

            treUnit.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_Load(object sender, EventArgs e)
        {
            InitCustomers();
            InitMaterial();
            InitUnit();

            InitItemList(null);
            btnConfirm.Enabled = false;
        }

        /// <summary>
        /// 选择供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sleCustomer_EditValueChanged(object sender, EventArgs e)
        {
            _HasCustomer = true;
            _CustomerId = (Guid?)sleCustomer.EditValue;
            txtName.EditValue = null;
            btnAdd.Enabled = true;
        }

        /// <summary>
        /// 手动输入供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            _HasCustomer = !string.IsNullOrEmpty(txtName.Text.Trim()) || sleCustomer.EditValue != null;
            btnAdd.Enabled = _HasCustomer;
        }

        /// <summary>
        /// 输入申请单号后更新供应商信息和入库物资列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtApplyCode_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null) return;

            InitItemList(e.Value);
        }

        /// <summary>
        /// 选择入库项目刷新编辑按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            btnEdit.Enabled = e.RowHandle >= 0;
        }

        /// <summary>
        /// 双击入库项目列表编辑选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Enabled) EditItem(true);
        }

        /// <summary>
        /// 增加入库项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditItem(false);
        }

        /// <summary>
        /// 编辑入库项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditItem(true);
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnConfirm.Enabled = _HasCustomer && gdvItem.SelectedRowsCount > 0;
        }

        #endregion

        #region 项目界面事件

        /// <summary>
        /// 输入条码后按条码查询物资并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodeBar_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null) return;

            var rows = Material.Select(string.Format("BarCode = '{0}'", e.Value));
            if (rows.Length > 0) sleMaterial.EditValue = rows[0]["ID"];
            else General.ShowError(string.Format("系统中不存在条码为【{0}】的物资数据，请输入正确的条码。", e.Value));
        }

        /// <summary>
        /// 选择入库物资
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sleMaterial_EditValueChanged(object sender, EventArgs e)
        {
            trlUnit.Enabled = sleMaterial.EditValue != null;
            txtPrice.Enabled = sleMaterial.EditValue != null;
            txtCount.Enabled = sleMaterial.EditValue != null;
            calAmount.Enabled = sleMaterial.EditValue != null;
            memSummary.Enabled = sleMaterial.EditValue != null;
            if (sleMaterial.EditValue == null) return;

            var unit = Material.Rows.Find(sleMaterial.EditValue)["Unit"];
            trlUnit.EditValue = unit == DBNull.Value ? null : unit;
            trlUnit.Enabled = trlUnit.EditValue == null;
        }

        /// <summary>
        /// 选择计价单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (trlUnit.EditValue == null || (bool)Units.Rows.Find(trlUnit.EditValue)["IsData"]) return;

            trlUnit.EditValue = null;
        }

        /// <summary>
        /// 根据单价和数量计算金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPrice.EditValue == null) return;

            if (txtPrice.Text.Trim() == "0.")
            {
                txtPrice.EditValue = null;
                txtCount.EditValue = null;
            }

            if (txtPrice.EditValue != null && txtCount.EditValue != null)
            {
                calAmount.Value = Math.Round(Convert.ToDecimal(txtPrice.EditValue) * Convert.ToDecimal(txtCount.EditValue), 2);
            }
        }

        /// <summary>
        /// 根据单价和数量计算金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCount_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCount.EditValue == null) return;

            if (txtCount.Text.Trim() == "0.") txtCount.EditValue = null;

            var maxCount = _IsEdit ? (decimal)gdvItem.GetFocusedDataRow()["MaxCount"] : 0;
            if (_IsPlan && Math.Abs(Convert.ToDecimal(txtCount.EditValue)) > Math.Abs(maxCount)) txtCount.EditValue = maxCount;

            if (txtPrice.EditValue != null && txtCount.EditValue != null)
            {
                calAmount.Value = Math.Round(Convert.ToDecimal(txtPrice.EditValue) * Convert.ToDecimal(txtCount.EditValue), 2);
            }
            btnItemAdd.Enabled = txtCount.EditValue != null;
        }

        /// <summary>
        /// 输入金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calAmount_EditValueChanged(object sender, EventArgs e)
        {
            var maxAmount = (decimal)0;
            if (_IsEdit) maxAmount = (decimal)gdvItem.GetFocusedDataRow()["MaxAmount"];
            if (_IsPlan && Math.Abs(calAmount.Value) > Math.Abs(maxAmount)) calAmount.Value = maxAmount;
        }

        /// <summary>
        /// 增加/编辑入库项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            var mid = sleMaterial.EditValue;
            var smy = memSummary.EditValue;
            var name = sleMaterial.Text;
            var unit = trlUnit.Text;
            var price = txtPrice.EditValue ?? DBNull.Value;
            var count = txtCount.EditValue ?? DBNull.Value;
            var amount = Math.Round(calAmount.Value, 2);

            if (_IsEdit)
            {
                var row = _ItemList.Rows[gdvItem.FocusedRowHandle];
                row.ItemArray = new[] { row["ID"], row["ObjectId"], _IsPlan, 1, _IsPlan ? row["ProductId"] : mid, smy, _IsPlan ? row["项目"] : name, unit, price, count, row["MaxCount"], amount, row["MaxAmount"] };
                gdvItem.SelectRow(gdvItem.FocusedRowHandle);
            }
            else
            {
                _ItemList.Rows.Add(Guid.NewGuid(), _CustomerId, 0, 1, mid, smy, name, unit, price, count, 0, amount, 0);
                gdvItem.SelectRow(_ItemList.Rows.Count - 1);
            }

            ResetItemInfo(!_IsEdit && sleMaterial.Enabled);
        }

        /// <summary>
        /// 关闭弹出对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            palItem.Visible = false;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化供应商下拉列表
        /// </summary>
        private void InitCustomers()
        {
            sleCustomer.Properties.DataSource = MasterDatas;
            sleCustomer.Properties.ValueMember = "ID";
            sleCustomer.Properties.DisplayMember = "Name";
            sleCustomer.Properties.PopulateViewColumns();
            Format.GridFormat(gdvCustomer);
        }

        /// <summary>
        /// 初始化物资下拉列表
        /// </summary>
        private void InitMaterial()
        {
            sleMaterial.Properties.DataSource = Material;
            sleMaterial.Properties.DisplayMember = "Name";
            sleMaterial.Properties.ValueMember = "ID";
            sleMaterial.Properties.PopulateViewColumns();
            Format.GridFormat(gdvMaterial);
        }

        /// <summary>
        /// 初始化项目单位下拉列表
        /// </summary>
        private void InitUnit()
        {
            trlUnit.Properties.DataSource = Units;
            trlUnit.Properties.DisplayMember = "Name";
            trlUnit.Properties.ValueMember = "ID";
            Format.TreeFormat(treUnit);
        }

        /// <summary>
        /// 初始化入库项目列表
        /// </summary>
        /// <param name="code"></param>
        private void InitItemList(object code)
        {
            using (var cli = new SettlementClient(OpenForm.Binding, OpenForm.Address))
            {
                _ItemList = cli.Get_GoodsPlan(OpenForm.UserSession, code);
            }

            if (code != null && _ItemList.Rows.Count == 0)
            {
                General.ShowError(string.Format("单号为【{0}】的入库申请未审批通过或不存在。\r\n请输入正确的申请单号。", code));
                return;
            }

            btnEdit.Enabled = _ItemList.Rows.Count > 0;
            grdItem.DataSource = _ItemList;
            Format.GridFormat(gdvItem, 0, false, false);
            gdvItem.Columns["IsPlan"].Visible = false;
            gdvItem.Columns["摘要"].Width = 240;
            gdvItem.Columns["项目"].Width = 120;
            gdvItem.Columns["MaxCount"].Visible = false;
            gdvItem.Columns["MaxAmount"].Visible = false;

            if (_ItemList.Rows.Count > 0) sleCustomer.EditValue = _ItemList.Rows[0]["ObjectId"];

            for (var i = 0; i < gdvItem.RowCount; i++)
            {
                if ((bool)gdvItem.GetDataRow(i)["Selected"]) gdvItem.SelectRow(i);
            }
        }

        /// <summary>
        /// 新增/编辑入库项目
        /// </summary>
        /// <param name="isEdit"></param>
        private void EditItem(bool isEdit)
        {
            _IsEdit = isEdit;
            _IsPlan = isEdit;
            ResetItemInfo(true);

            if (isEdit)
            {
                var row = gdvItem.GetFocusedDataRow();
                _IsPlan = (bool)row["IsPlan"];
                txtCodeBar.EditValue = Material.Select(string.Format("ID = '{0}'", row["ProductId"]))[0]["BarCode"];
                sleMaterial.EditValue = row["ProductId"];
                trlUnit.EditValue = Units.Select(string.Format("Name = '{0}'", row["单位"]))[0]["ID"];
                txtPrice.EditValue = row["单价"] == DBNull.Value ? null : row["单价"];
                txtCount.EditValue = row["数量"] == DBNull.Value ? null : row["数量"];
                calAmount.EditValue = row["金额"];
                memSummary.EditValue = row["摘要"];
            }

            txtCodeBar.Enabled = !_IsPlan;
            sleMaterial.Enabled = !_IsPlan;
            trlUnit.Enabled = !_IsPlan && sleMaterial.EditValue != null;
            txtPrice.Enabled = !_IsPlan && sleMaterial.EditValue != null;
            txtCount.Enabled = _IsEdit;
            calAmount.Enabled = _IsEdit;
            memSummary.Enabled = _IsEdit;
            btnItemAdd.Text = _IsEdit ? "编 辑" : "添 加";
        }

        /// <summary>
        /// 重置弹出对话框
        /// </summary>
        private void ResetItemInfo(bool open)
        {
            txtCodeBar.Enabled = true;
            txtCodeBar.EditValue = null;
            sleMaterial.Enabled = true;
            sleMaterial.EditValue = null;
            trlUnit.EditValue = null;
            txtPrice.EditValue = null;
            txtCount.EditValue = null;
            calAmount.EditValue = null;
            memSummary.EditValue = null;

            palItem.Visible = open;
            txtCodeBar.Focus();
        }

        #endregion

        #region 按钮事件


        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!OpenForm.UserSession.DeptId.HasValue) return;

            _Delivery = new ABS_Delivery
            {
                Direction = 1,
                ObjectId = _CustomerId,
                ObjectName = txtName.EditValue == null ? sleCustomer.Text : txtName.Text.Trim(),
                Description = memDesc.Text.Trim(),
                CreatorDeptId = (Guid) OpenForm.UserSession.DeptId,
                CreatorUserId = OpenForm.UserSession.UserId
            };

            _ItemList.AcceptChanges();
            var dv = _ItemList.Copy().DefaultView;
            dv.RowFilter = "Selected = 1";

            using (var cli = new SettlementClient(OpenForm.Binding, OpenForm.Address))
            {
                ReceiptId = cli.AddDelivery(OpenForm.UserSession, _Delivery, dv.ToTable());
            }

            if (ReceiptId == null)
            {
                General.ShowError("入库数据保存失败！如多次保存失败，请联系管理员。");
                return;
            }
            
            if (General.ShowConfirm("您需要现在就打印入库单吗？如现在不打印，可在出入库管理界面进行打印。") == DialogResult.OK)
            {
                IsPrint = true;
            }
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
