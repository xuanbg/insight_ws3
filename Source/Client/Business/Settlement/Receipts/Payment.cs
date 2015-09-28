using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Business.Settlement.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class Payment : DialogBase
    {

        #region 属性

        /// <summary>
        /// 收款人数据
        /// </summary>
        public DataTable MasterDatas { private get; set; }

        /// <summary>
        /// 款项数据
        /// </summary>
        public DataTable Expense { private get; set; }

        /// <summary>
        /// 支付方式数据
        /// </summary>
        public DataTable PayTypes { private get; set; }

        /// <summary>
        /// 单位数据
        /// </summary>
        public DataTable Units { private get; set; }

        /// <summary>
        /// 默认结算方式
        /// </summary>
        public Guid DefaultPay { private get; set; }

        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrint { get; private set; }

        /// <summary>
        /// 付款单ID
        /// </summary>
        public object ReceiptId { get; private set; }

        #endregion

        #region 变量声明

        private ABS_Clearing _Receipt;
        private DataTable _PayList;
        private DataTable _ItemList;
        private GridColumnSummaryItem _Amount;
        private decimal _Total;
        private Guid? _CustomerId;
        private bool _HasCustomer;
        private bool _IsEdit;
        private bool _IsPlan;

        #endregion

        #region 构造方法

        public Payment()
        {
            InitializeComponent();

            treExpense.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
            treUnit.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;

            _Amount = new GridColumnSummaryItem(SummaryItemType.Sum) {DisplayFormat = _Total.ToString("n")};
            _PayList = new DataTable("Table");
            _PayList.Columns.AddRange(new[]
            {
                new DataColumn("ID", typeof (Guid)),
                new DataColumn("票号", typeof (string)),
                new DataColumn("结算方式", typeof (Guid)),
                new DataColumn("金额", typeof (decimal))
            });
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
            var dv = Expense.DefaultView;
            dv.RowFilter = "BuiltIn <> 1";
            Format.InitTreeListLookUpEdit(trlExpense, dv);
            Format.InitSearchLookUpEdit(sleCustomer, MasterDatas);
            Format.InitLookUpEdit(lokPay, PayTypes);
            Format.InitTreeListLookUpEdit(trlUnit, Units);
            InitPayList();

            InitItemList(Guid.Empty);
        }

        /// <summary>
        /// 选择付款人后按付款人ID加载收款项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sleCustomer_EditValueChanged(object sender, EventArgs e)
        {
            _HasCustomer = true;
            _CustomerId = (Guid)sleCustomer.EditValue;
            txtName.EditValue = null;
            btnAdd.Enabled = true;

            InitItemList((Guid)_CustomerId);
            if (_ItemList.Rows.Count > 0)
            {
                for (var i = 0; i < gdvItem.RowCount; i++)
                {
                    if ((bool)gdvItem.GetDataRow(i)["Selected"]) gdvItem.SelectRow(i);
                }
            }
            else
            {
                EditItem(false);
            }
        }

        /// <summary>
        /// 手动输入付款人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            _HasCustomer = !string.IsNullOrEmpty(txtName.Text.Trim()) || sleCustomer.EditValue != null;
            btnAdd.Enabled = _HasCustomer;
            gdvPay_RowCountChanged(null, null);
        }

        /// <summary>
        /// 选择收款项目刷新编辑按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            btnEdit.Enabled = e.RowHandle >= 0;
        }

        /// <summary>
        /// 双击收款项目列表编辑选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Enabled) EditItem(true);
        }

        /// <summary>
        /// 选择/取消选择付款项目后重新计算总金额和初始化结算方式列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow < 0)
            {
                for (var i = 0; i < gdvItem.RowCount; i++) gdvItem.GetDataRow(i)["Selected"] = gdvItem.IsRowSelected(i);
            }
            else
            {
                gdvItem.GetDataRow(e.ControllerRow)["Selected"] = gdvItem.IsRowSelected(e.ControllerRow);
            }
            ResetPayList();
        }

        /// <summary>
        /// 增加收款项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditItem(false);
        }

        /// <summary>
        /// 编辑收款项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditItem(true);
        }

        /// <summary>
        /// 结算金额变化后验证合法性以及自动补充一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvPay_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "金额") return;

            var maxVal = _Total;
            var count = gdvPay.RowCount;
            for (var i = 0; i < count; i++)
            {
                if (i > e.RowHandle) _PayList.Rows.RemoveAt(e.RowHandle + 1);
                if (i < e.RowHandle) maxVal -= (decimal)_PayList.Rows[i]["金额"];
            }

            if ((decimal)e.Value > maxVal) _PayList.Rows[e.RowHandle]["金额"] = maxVal;

            var amount = _Total - _PayList.Select().ToList().Sum(r => (decimal)r["金额"]);
            if (amount != 0) _PayList.Rows.Add(Guid.NewGuid(), null, DefaultPay, amount);
        }

        /// <summary>
        /// 支付方式变化后验证合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvPay_RowCountChanged(object sender, EventArgs e)
        {
            btnConfirm.Enabled = _HasCustomer && gdvItem.SelectedRowsCount > 0;
        }

        #endregion

        #region 弹出事件

        /// <summary>
        /// 选择收费项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlExpense_EditValueChanged(object sender, EventArgs e)
        {
            trlUnit.Enabled = trlExpense.EditValue != null;
            txtPrice.Enabled = trlExpense.EditValue != null;
            calAmount.Enabled = trlExpense.EditValue != null;
            memSummary.Enabled = trlExpense.EditValue != null;
            if (trlExpense.EditValue == null) return;

            if (!(bool)Expense.Rows.Find(trlExpense.EditValue)["IsData"])
            {
                trlExpense.EditValue = null;
                btnItem.Enabled = false;
            }
            else
            {
                var unit = Expense.Rows.Find(trlExpense.EditValue)["Unit"];
                var price = Expense.Rows.Find(trlExpense.EditValue)["Price"];
                trlUnit.EditValue = unit == DBNull.Value ? null : unit;
                trlUnit.Enabled = trlUnit.EditValue == null;
                txtPrice.EditValue = price == DBNull.Value ? null : price;
                txtPrice.Enabled = txtPrice.EditValue == null;
                txtCount.EditValue = txtPrice.EditValue != null ? "1" : null;
                calAmount_EditValueChanged(null, null);
            }
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
            txtCount.Enabled = txtPrice.EditValue != null;
            if (txtPrice.EditValue == null) return;

            if (txtPrice.Text.Trim() == "0.")
            {
                txtPrice.EditValue = null;
                txtCount.EditValue = null;
            }
            SetAmount();
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

            var maxCount = _IsEdit ? (decimal)gdvItem.GetFocusedDataRow()["Counts"] : 0;
            if (_IsPlan && Math.Abs(Convert.ToDecimal(txtCount.EditValue)) > Math.Abs(maxCount)) txtCount.EditValue = maxCount;
            SetAmount();
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
            btnItem.Enabled = trlExpense.EditValue != null && calAmount.Value != 0;
        }

        /// <summary>
        /// 增加/编辑收费项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItem_Click(object sender, EventArgs e)
        {
            var eid = trlExpense.EditValue;
            var smy = memSummary.EditValue;
            var name = trlExpense.Text;
            var unit = trlUnit.Text;
            var price = txtPrice.EditValue ?? DBNull.Value;
            var count = txtCount.EditValue ?? DBNull.Value;
            var amount = calAmount.Value;

            if (_IsEdit)
            {
                var row = _ItemList.Rows[gdvItem.FocusedRowHandle];
                row.ItemArray = new[] { row["ID"], row["ObjectId"], 1, 1, _IsPlan ? row["ProductId"] : eid, smy, _IsPlan ? row["项目"] : name, unit, price, row["Counts"], count, row["MaxAmount"], amount };
                gdvItem.SelectRow(gdvItem.FocusedRowHandle);
            }
            else
            {
                _ItemList.Rows.Add(Guid.NewGuid(), _CustomerId, 0, 1, eid, smy, name, unit, price, 0, count, 0, amount);
                gdvItem.SelectRow(_ItemList.Rows.Count - 1);
            }

            ResetItemInfo(!_IsEdit && trlExpense.Enabled);
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
        /// 根据收款人ID初始化付款项目列表
        /// </summary>
        /// <param name="id"></param>
        private void InitItemList(Guid id)
        {
            using (var cli = new SettlementClient(OpenForm.Binding, OpenForm.Address))
            {
                _ItemList = cli.GetFundPlans(OpenForm.UserSession, id, -1);
            }

            btnEdit.Enabled = _ItemList.Rows.Count > 0;
            grdItem.DataSource = _ItemList;
            Format.GridFormat(gdvItem, 0, false, false);
            gdvItem.Columns["IsPlan"].Visible = false;
            gdvItem.Columns["摘要"].Width = 240;
            gdvItem.Columns["项目"].Width = 120;
            gdvItem.Columns["Counts"].Visible = false;
            gdvItem.Columns["金额"].Summary.Clear();
            gdvItem.Columns["金额"].Summary.Add(_Amount);
            gdvItem.Columns["MaxAmount"].Visible = false;
        }

        /// <summary>
        /// 初始化结算方式列表
        /// </summary>
        private void InitPayList()
        {
            grdPay.DataSource = _PayList;
            Format.GridFormat(gdvPay, 32, true);
            gdvPay.Columns["票号"].Width = 200;
            gdvPay.Columns["结算方式"].ColumnEdit = lokPay;
            gdvPay.Columns["结算方式"].Width = 120;
            gdvPay.Columns["金额"].ColumnEdit = calPayAmount;
        }

        /// <summary>
        /// 重新计算总金额和初始化支付方式列表
        /// </summary>
        private void ResetPayList()
        {
            _Total = Math.Round(_ItemList.Select("Selected = 1").ToList().Sum(r => (decimal)r["金额"]), 2);
            _Amount.DisplayFormat = _Total.ToString("n");

            _PayList.Clear();
            if (_Total != 0) _PayList.Rows.Add(Guid.NewGuid(), null, DefaultPay, _Total);
        }

        /// <summary>
        /// 新增/编辑收费项目
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
                _IsPlan = row["PlanId"] != DBNull.Value;

                if (_IsPlan) txtExpense.EditValue = row["项目"];
                else trlExpense.EditValue = row["ProductId"];

                trlUnit.EditValue = Units.Select($"Name = '{row["单位"]}'")[0]["ID"];
                txtPrice.EditValue = row["单价"] == DBNull.Value ? null : row["单价"];
                txtCount.EditValue = row["数量"] == DBNull.Value ? null : row["数量"];
                calAmount.EditValue = row["金额"];
                memSummary.EditValue = row["摘要"];
                calAmount.Focus();
            }

            txtExpense.Visible = _IsPlan;
            trlExpense.Visible = !_IsPlan;
            trlUnit.Enabled = !_IsPlan && trlExpense.EditValue != null;
            txtPrice.Enabled = !_IsPlan && trlExpense.EditValue != null;
            calAmount.Enabled = _IsEdit;
            memSummary.Enabled = _IsEdit;
            btnItem.Text = isEdit ? "更 改" : "添 加";
        }

        /// <summary>
        /// 根据单价和数量计算金额
        /// </summary>
        private void SetAmount()
        {
            if (txtPrice.EditValue == null || txtCount.EditValue == null) return;

            calAmount.Value = Math.Round(Convert.ToDecimal(txtPrice.EditValue) * Convert.ToDecimal(txtCount.EditValue), 2);
        }

        /// <summary>
        /// 重置弹出对话框
        /// </summary>
        private void ResetItemInfo(bool open)
        {
            trlExpense.Enabled = true;
            trlExpense.EditValue = null;
            trlUnit.EditValue = null;
            txtPrice.EditValue = null;
            txtCount.EditValue = null;
            calAmount.EditValue = null;
            memSummary.EditValue = null;

            palItem.Visible = open;
            trlExpense.Focus();
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 点击收款按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!OpenForm.UserSession.DeptId.HasValue) return;

            _Receipt = new ABS_Clearing
            {
                Direction = -1,
                ObjectId = _CustomerId,
                ObjectName = txtName.EditValue == null ? sleCustomer.Text : txtName.Text.Trim(),
                Description = memDesc.Text.Trim(),
                CreatorDeptId = (Guid) OpenForm.UserSession.DeptId,
                CreatorUserId = OpenForm.UserSession.UserId
            };

            _ItemList.AcceptChanges();
            _PayList.AcceptChanges();
            var dv = _ItemList.Copy().DefaultView;
            dv.RowFilter = "Selected = 1";

            using (var cli = new SettlementClient(OpenForm.Binding, OpenForm.Address))
            {
                ReceiptId = cli.AddClearing(OpenForm.UserSession, _Receipt, dv.ToTable(), _PayList);
            }

            if (ReceiptId == null)
            {
                General.ShowError("付款数据保存失败！如多次保存失败，请联系管理员。");
                return;
            }
            
            if (General.ShowConfirm("您需要现在打印单据吗？如不打印，可在结算管理界面进行打印。") == DialogResult.OK)
            {
                IsPrint = true;
            }
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
