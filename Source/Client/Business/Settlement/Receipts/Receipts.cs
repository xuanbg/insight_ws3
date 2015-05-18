using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using FastReport;
using Insight.WS.Client.Business.Settlement.Receipt;
using Insight.WS.Client.Business.Settlement.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class Receipts : MdiBase
    {

        #region 变量声明

        private SettlementClient _Client;
        private ImageData _Image;
        private DataTable _Cashiers;
        private DataTable _Payments;
        private DataTable _Expense;
        private DataTable _Pays;
        private DataTable _Units;
        private DataTable _DateTree;
        private DataTable _FilterReceipts;
        private DataTable _SearchReceipts;
        private DataView _Receipts;
        private Guid? _SecrecyLevel;
        private Guid? _DefaultPay;
        private Guid? _CheckWId;
        private Guid? _ReceiptTId;
        private Guid? _PaymentTId;
        private Guid? _CheckTId;
        private Guid? _TempletId;
        private Guid? _ReceiptSId;
        private Guid? _PaymentSId;
        private Guid? _CheckSId;
        private Guid? _SchemeId;
        private Guid _ReceiptId;
        private bool _HasReceipt;
        private bool _CanEdit;
        private int _Status;
        private int _WipeType;
        private int _WipeLevel;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造方法
        /// </summary>
        public Receipts()
        {
            InitializeComponent();

            treDate.CustomDrawNodeImages += Format.CustomDrawNodeTypeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 载入
        /// </summary>
        private void Receipts_Load(object sender, EventArgs e)
        {
            InitToolBar();
            LoadParameters();
            InitDateTree();
        }

        private void Receipts_Shown(object sender, EventArgs e)
        {
            var ts = new ThreadStart(LoadDict);
            var td = new Thread(ts);
            td.Start();
        }

        /// <summary>
        /// 日历树焦点变更刷新收款记录列表
        /// </summary>
        private void treIndex_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            GetReceipts();
        }

        /// <summary>
        /// 搜索框输入回车根据输入关键字刷新收款记录列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        /// <summary>
        /// 点击查询按钮根据输入关键字刷新收款记录列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 点击清除按钮清空输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            _Receipts = _FilterReceipts.DefaultView;
            InitReceipts();
        }

        /// <summary>
        /// 所选结算记录变化后切换工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReceipts_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _Status = -1;
            if (_HasReceipt)
            {
                _CanEdit = (int)gdvReceipts.GetFocusedDataRow()["Permission"] > 0;

                var row = gdvReceipts.GetFocusedDataRow();
                if (_CanEdit && row["状态"].ToString() != "作废")
                {
                    _Status = row["结账"] == DBNull.Value ? (row["单据号"] == DBNull.Value ? 1 : 2) : ((bool)row["结账"] ? 3 : 0);
                }
                _ReceiptId = (Guid)gdvReceipts.GetFocusedDataRow()["ID"];
                _TempletId = row["类型"].ToString() == "收款" ? _ReceiptTId : _PaymentTId;
                _SchemeId = row["类型"].ToString() == "收款" ? _ReceiptSId : _PaymentSId;
            }
            barManager.Items["Delete"].Caption = _Status == 1 ? "删除" : "作废";
            SwitchItemStatus(new Context("Attachment", _Status >= 0), new Context("Delete", _Status > 0 && _Status < 3), new Context("Deduction", _Status == 3));
        }

        /// <summary>
        /// 双击结算记录列表查看记录详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReceipts_DoubleClick(object sender, EventArgs e)
        {
            if (_HasReceipt) ShowReceipt();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载字典数据
        /// </summary>
        private void LoadDict()
        {
            _Cashiers = Commons.MasterDatas(12);
            _Payments = Commons.MasterDatas(14);
            _Expense = Commons.Expenses();
            _Pays = Commons.Dictionary("Settlement");
            _Units = Commons.Dictionary("Unit", false);
        }

        /// <summary>
        /// 初始化收款记录日期树
        /// </summary>
        private void InitDateTree()
        {
            _Client = new SettlementClient(Binding, Address);
            _DateTree = _Client.GetClearingDate(UserSession);
            _Client.Close();

            treDate.DataSource = _DateTree;
            Format.TreeFormat(treDate);
        }

        /// <summary>
        /// 初始化收款记录列表
        /// </summary>
        private void InitReceipts()
        {
            _HasReceipt = _Receipts.Count > 0;
            SwitchItemStatus(new Context("Print", _HasReceipt), new Context("Preview", _HasReceipt), new Context("Show", _HasReceipt), new Context("Attachment", _HasReceipt), new Context("Delete", _HasReceipt), new Context("Deduction", _HasReceipt));

            grdReceipts.DataSource = _Receipts;
            Format.GridFormat(gdvReceipts);
            gdvReceipts.Columns["单据号"].Width = 140;
            gdvReceipts.Columns["结算单位"].Width = 200;
            gdvReceipts.Columns["备注"].Width = 226;
            gdvReceipts.Columns["经办人"].Width = 60;
            gdvReceipts.Columns["经办人"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvReceipts.Columns["结账"].Width = 40;
        }

        /// <summary>
        /// 根据日期查询收款记录
        /// </summary>
        private void GetReceipts()
        {
            if ((int) treDate.FocusedNode.GetValue("Type") != 2) return;

            _Client = new SettlementClient(Binding, Address);
            _FilterReceipts = _Client.GetReceiptsForDate(UserSession, ModuleId, treDate.FocusedNode.GetValue("ID").ToString());
            _Client.Close();

            bteSearch.EditValue = null;
            _Receipts = _FilterReceipts.DefaultView;
            InitReceipts();
        }

        /// <summary>
        /// 根据关键字查询收款记录
        /// </summary>
        private void Search()
        {
            _Client = new SettlementClient(Binding, Address);
            _SearchReceipts = _Client.GetReceiptsForName(UserSession, ModuleId, bteSearch.Text.Trim());
            _Client.Close();

            _Receipts = _SearchReceipts.DefaultView;
            InitReceipts();
        }

        /// <summary>
        /// 载入选项参数
        /// </summary>
        private void LoadParameters()
        {
            ReadModuleParameter();

            // 抹零方式
            var pvs = GetParameter("2BFABFD1-4B70-4DFC-9DC0-8CBAE8422545");
            _WipeType = pvs.Count > 0 && pvs[0] != null ? Convert.ToInt32(pvs[0]) : 1;

            // 抹零级别
            pvs = GetParameter("EEE681A7-BCCF-4AFF-909A-161CFFC184D4");
            _WipeLevel = pvs.Count > 0 && pvs[0] != null ? Convert.ToInt32(pvs[0]) : 0;

            // 涉密等级
            pvs = GetParameter("3773961E-30A3-400C-9497-C616E0AD38E3");
            _SecrecyLevel = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 默认结算方式
            pvs = GetParameter("212864FE-71CF-4838-AE55-1991D117B061");
            _DefaultPay = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 结账流程
            pvs = GetParameter("247F6E2B-8AD3-43C3-AA32-7748507102E0");
            _CheckWId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 收据打印模板
            pvs = GetParameter("8BC6C0B7-EEE5-4AD2-B1D7-086CFA92C54F");
            _ReceiptTId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 付款单打印模板
            pvs = GetParameter("29A890C9-0E08-4471-99CF-358011B9A94C");
            _PaymentTId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 结账单打印模板
            pvs = GetParameter("4D897D4C-8982-429D-8810-0EFD396A4A02");
            _CheckTId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 收据编码方案
            pvs = GetParameter("DD68AA9B-9893-4774-93A3-06082A436E55");
            _ReceiptSId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 付款单编码方案
            pvs = GetParameter("1B03C4EA-61CA-4910-AC7F-5443FB43D816");
            _PaymentSId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 结账单编码方案
            pvs = GetParameter("C8C8AA66-41A6-4D25-AF9D-787AAF60DA0F");
            _CheckSId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;
        }

        /// <summary>
        /// 打印收据
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="isPrinted"></param>
        /// <returns></returns>
        private object DoPrint(object bid, bool isPrinted = false)
        {
            var tid = isPrinted ? null : _TempletId;
            var printer = Config.Printer("BilPrint");
            if (!isPrinted)
            {
                _Client = new SettlementClient(Binding, Address);
                if (_SchemeId != null)
                {
                    var code = _Client.GetReceiptCode(UserSession, (Guid)_SchemeId, (Guid)bid, ModuleId);
                    _Client.Close();

                    _Receipts.Table.Rows.Find(bid)["单据号"] = code;
                    _Image = new ImageData {Code = code.ToString()};
                }
                _Image.ImageType = 1;
                _Image.SecrecyDegree = _SecrecyLevel;
                _Image.CreatorDeptId = UserSession.DeptId;
                _Image.CreatorUserId = UserSession.UserId;
            }

            var onSheet = Config.IsMergerPrint() ? PagesOnSheet.Three : PagesOnSheet.One;
            return PrintImage((Guid)bid, tid, printer, _Image, onSheet);
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 点击工具条中的按钮
        /// </summary>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitDateTree();
                    break;
                case "Cashier":
                    Cashier();
                    break;
                case "Payment":
                    Payment();
                    break;
                case "Check":
                    Check();
                    break;
                case "Print":
                    Print();
                    break;
                case "Preview":
                    Preview();
                    break;
                case "Show":
                    ShowReceipt();
                    break;
                case "Attachment":
                    AddAttachment();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "Deduction":
                    Deduction();
                    break;
                case "Setting":
                    Setting();
                    break;
            }
        }

        /// <summary>
        /// 收款
        /// </summary>
        private void Cashier()
        {
            if (!UserSession.DeptId.HasValue)
            {
                General.ShowError("当前用户未登录到业务部门，无法进行收款业务！");
                return;
            }

            if (!_DefaultPay.HasValue || !_ReceiptTId.HasValue || !_ReceiptSId.HasValue)
            {
                General.ShowWarning("当前未设置必要参数！请设置默认结算方式、收据打印模板和收据编码方案。");
                return;
            }

            var dig = new Cashier
            {
                Owner = this,
                MasterDatas = _Cashiers,
                Expense = _Expense,
                PayTypes = _Pays,
                Units = _Units,
                WipeMode = _WipeLevel,
                WipeType = _WipeType,
                DefaultPay = (Guid) _DefaultPay
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                GetReceipts();
                if (dig.IsPrint)
                {
                    var id = DoPrint(dig.ReceiptId);
                    var row = _Receipts.Table.Rows.Find(dig.ReceiptId);
                    if (row != null)
                    {
                        row["ImageId"] = id;
                        barManager.Items["Delete"].Caption = "作废";
                    }
                }
            }
            dig.Close();
        }

        /// <summary>
        /// 付款
        /// </summary>
        private void Payment()
        {
            if (!UserSession.DeptId.HasValue)
            {
                General.ShowError("当前用户未登录到业务部门，无法进行付款业务！");
                return;
            }

            if (!_DefaultPay.HasValue || !_PaymentTId.HasValue || !_PaymentSId.HasValue)
            {
                General.ShowWarning("当前未设置必要参数！请设置默认结算方式、付款单打印模板和付款单编码方案。");
                return;
            }

            var dig = new Payment
            {
                Owner = this,
                MasterDatas = _Payments,
                Expense = _Expense,
                PayTypes = _Pays,
                Units = _Units,
                DefaultPay = (Guid) _DefaultPay
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                GetReceipts();
                if (dig.IsPrint)
                {
                    var id = DoPrint(dig.ReceiptId);
                    var row = _Receipts.Table.Rows.Find(dig.ReceiptId);
                    if (row != null)
                    {
                        row["ImageId"] = id;
                        barManager.Items["Delete"].Caption = "作废";
                    }
                }
            }
            dig.Close();
        }

        /// <summary>
        /// 结账
        /// </summary>
        private void Check()
        {
            if (!_CheckTId.HasValue || !_CheckSId.HasValue || !_CheckWId.HasValue)
            {
                General.ShowWarning("当前未设置必要参数！请设置结账单模板、结账单编码方案和结账流程。");
                return;
            }

            var dig = new Check
            {
                Owner = this,
                TempletId = (Guid) _CheckTId,
                SchemeId = (Guid) _CheckSId,
                WorkflowId = (Guid)_CheckWId
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                if (bteSearch.EditValue == null)
                    GetReceipts();
                else
                    Search();
            }
            dig.Close();
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            var imageId = gdvReceipts.GetFocusedDataRow()["ImageId"];
            var isPrinted = imageId != DBNull.Value;
            var id = isPrinted ? imageId : gdvReceipts.GetFocusedDataRow()["ID"];
            imageId = DoPrint(id, isPrinted);
            if (!isPrinted)
            {
                _Receipts.Table.Rows.Find(id)["ImageId"] = imageId;
                barManager.Items["Delete"].Caption = "作废";
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        private void Preview()
        {
            var imageId = gdvReceipts.GetFocusedDataRow()["ImageId"];
            var isPrinted = imageId != DBNull.Value;
            var id = isPrinted ? imageId : gdvReceipts.GetFocusedDataRow()["ID"];
            var templat = isPrinted ? null : _TempletId;
            PreviewImage((Guid)id, templat);
        }

        /// <summary>
        /// 查看单据
        /// </summary>
        private void ShowReceipt()
        {
            var sid = gdvReceipts.GetFocusedDataRow()["ImageId"];
            var dig = new ShowReceipt
            {
                Owner = this,
                CanEdit = _CanEdit,
                ObjectId = _ReceiptId,
                SnapshotId = sid == DBNull.Value ? null : (Guid?) sid
            };
            dig.ShowDialog();
            dig.Close();
        }

        /// <summary>
        /// 添加附件
        /// </summary>
        private void AddAttachment()
        {
            var id = (Guid)gdvReceipts.GetFocusedDataRow()["ID"];
            var imgs = General.AddFiles(_SecrecyLevel);
            if (imgs == null) return;

            if (Commons.SaveImages(id, imgs, "ABS_Clearing_Attachs", "ClearingId"))
            {
                General.ShowMessage("附件上传成功！如需查看附件，请打开查看对话框并切换到附件清单页。");
            }
            else
            {
                General.ShowError("附件上传失败！如多次上次失败，请联系管理员。");
            }
        }

        /// <summary>
        /// 作废/删除
        /// </summary>
        private void Delete()
        {
            var row = _Receipts.Table.Rows.Find(_ReceiptId);
            if (General.ShowConfirm(string.Format("您确定要{0}结算记录吗？", barManager.Items["Delete"].Caption)) != DialogResult.OK) return;

            _Client = new SettlementClient(Binding, Address);
            var result = _Client.DelReceipt(UserSession, _ReceiptId, _Status);
            _Client.Close();

            if (result)
            {
                if (_Status == 1)
                {
                    row.Delete();
                }
                else
                {
                    row["状态"] = "作废";
                    SwitchItemStatus(new Context("Attachment", false), new Context("Delete", false));
                }
            }
            else
            {
                General.ShowError(string.Format("{0}结算记录失败！如多次失败，请联系管理员。", barManager.Items["Delete"].Caption));
            }
        }

        /// <summary>
        /// 冲销
        /// </summary>
        private void Deduction()
        {
            InitDateTree();
        }

        /// <summary>
        /// 设置
        /// </summary>
        private void Setting()
        {
            var dig = new Setting {Owner = this};
            if (dig.ShowDialog() == DialogResult.OK)
            {
                WriteModuleParameter(dig.Parameters);
                LoadParameters();

                var row = gdvReceipts.GetFocusedDataRow();
                if (row != null)
                {
                    var type = row["类型"].ToString();
                    _TempletId = type == "收款" ? _ReceiptTId : _PaymentTId;
                    _SchemeId = type == "收款" ? _ReceiptSId : _PaymentSId;
                }
            }
            dig.Close();
        }

        #endregion

    }
}
