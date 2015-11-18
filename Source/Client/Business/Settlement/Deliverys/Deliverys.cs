using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Business.Settlement.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class Deliverys : MdiBase
    {

        #region 变量声明

        private ImageData _Image;
        private DataTable _Customers;
        private DataTable _Suppliers;
        private DataTable _Material;
        private DataTable _Units;
        private DataTable _DateTree;
        private DataTable _FilterDeliverys;
        private DataTable _SearchDeliverys;
        private DataView _Deliverys;
        private Guid? _SecrecyLevel;
        private Guid? _TempletId;
        private Guid? _TempleInId;
        private Guid? _TempleOutId;
        private Guid? _TempleBakId;
        private Guid? _SchemeId;
        private Guid? _SchemeInId;
        private Guid? _SchemeOutId;
        private Guid? _SchemeBakId;
        private Guid _DeliveryId;
        private bool _HasDelivery;
        private bool _CanEdit;
        private int _Status;
        private int _Type;

        #endregion

        #region 构造函数

        public Deliverys()
        {
            InitializeComponent();
            treDate.CustomDrawNodeImages += Format.CustomDrawNodeTypeImages;
        }

        #endregion

        #region 界面事件

        private void Storage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            LoadParameters();
            InitDateTree();

            var canIn = UserSession.DeptId.HasValue && _TempleInId.HasValue && _SchemeInId.HasValue;
            var canOut = UserSession.DeptId.HasValue && _TempleOutId.HasValue && _SchemeOutId.HasValue;
            var canBack = UserSession.DeptId.HasValue && _TempleBakId.HasValue && _SchemeBakId.HasValue;
            SwitchItemStatus(new Context("StoreIn", canIn), new Context("StoreOut", canOut), new Context("StoreBack", canBack));
        }

        private void Storage_Shown(object sender, EventArgs e)
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
            if ((int) e.Node.GetValue("Type") != 2) return;

            using (var cli = new SettlementClient(Binding, Address))
            {
                _FilterDeliverys = cli.GetDeliveryForDate(UserSession, ModuleId, e.Node.GetValue("ID").ToString());
            }

            _Deliverys = _FilterDeliverys.DefaultView;
            InitReceipts();
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
        private void bteSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            _Deliverys = _FilterDeliverys.DefaultView;
            InitReceipts();
        }

        /// <summary>
        /// 所选结算记录变化后切换工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReceipts_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            _Status = -1;
            if (_HasDelivery)
            {
                _CanEdit = (int)gdvReceipts.GetFocusedDataRow()["Permission"] > 0;

                var row = gdvReceipts.GetFocusedDataRow();
                if (_CanEdit && row["状态"].ToString() != "作废")
                {
                    _Status = row["单据号"] == DBNull.Value ? 1 : 2;
                }
                switch (row["类型"].ToString())
                {
                    case "入库":
                        _Type = 5;
                        _TempletId = _TempleInId;
                        _SchemeId = _SchemeInId;
                        break;

                    case "出库":
                        _Type = 6;
                        _TempletId = _TempleOutId;
                        _SchemeId = _SchemeOutId;
                        break;

                    case "退库":
                        _Type = 7;
                        _TempletId = _TempleBakId;
                        _SchemeId = _SchemeBakId;
                        break;
                }
                _DeliveryId = (Guid)gdvReceipts.GetFocusedDataRow()["ID"];
            }
            barManager.Items["Delete"].Caption =_Status == 2 ? "作废" : "删除";
            SwitchItemStatus(new Context("Delete", _Status > 0));
        }

        /// <summary>
        /// 双击结算记录列表查看记录详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvReceipts_DoubleClick(object sender, EventArgs e)
        {
            var edit = barManager.Items["ShowReceipt"];
            if (edit.Enabled) ShowReceipt();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载字典数据
        /// </summary>
        private void LoadDict()
        {
            _Customers = Commons.MasterDatas(8);
            _Suppliers = Commons.MasterDatas(4);
            _Material = Commons.Materials();
            _Units = Commons.Dictionary("Unit", false);
        }

        /// <summary>
        /// 初始化收款记录日期树
        /// </summary>
        private void InitDateTree()
        {
            using (var cli = new SettlementClient(Binding, Address))
            {
                _DateTree = cli.GetDeliveryDate(UserSession);
            }

            treDate.DataSource = _DateTree;
            Format.TreeFormat(treDate);
        }

        /// <summary>
        /// 初始化收款记录列表
        /// </summary>
        private void InitReceipts()
        {
            _HasDelivery = _Deliverys.Count > 0;
            SwitchItemStatus(new Context("Print", _HasDelivery), new Context("Preview", _HasDelivery), new Context("ShowReceipt", _HasDelivery), new Context("Attachment", _HasDelivery), new Context("Delete", _HasDelivery));

            grdReceipts.DataSource = _Deliverys;
            Format.GridFormat(gdvReceipts);
            gdvReceipts.Columns["类型"].Width = 40;
            gdvReceipts.Columns["单据号"].Width = 140;
            gdvReceipts.Columns["客户/供应商"].Width = 200;
            gdvReceipts.Columns["备注"].Width = 266;
            gdvReceipts.Columns["经办人"].Width = 60;
            gdvReceipts.Columns["经办人"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        /// <summary>
        /// 根据关键字查询收款记录
        /// </summary>
        private void Search()
        {
            using (var cli = new SettlementClient(Binding, Address))
            {
                _SearchDeliverys = cli.GetDeliveryForName(UserSession, ModuleId, bteSearch.Text.Trim());
            }

            _Deliverys = _SearchDeliverys.DefaultView;
            InitReceipts();
        }

        /// <summary>
        /// 载入选项参数
        /// </summary>
        private void LoadParameters()
        {
            ReadModuleParameter();

            // 入库单打印模板
            var pvs = GetParameter("16EBDC03-B0BB-481B-8EDC-0B9F29A97911");
            _TempleInId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 出库单打印模板
            pvs = GetParameter("8A5AF44F-B0CE-4D0A-B0CF-FFB8315613C8");
            _TempleOutId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 退库单打印模板
            pvs = GetParameter("42244164-E340-48C7-B153-920497B6F069");
            _TempleBakId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 入库单编码方案
            pvs = GetParameter("2F2ED486-2C52-4D83-AF61-85F6736C8337");
            _SchemeInId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 出库单编码方案
            pvs = GetParameter("A22F4C4D-6A43-4F02-BB22-429F6FB78580");
            _SchemeOutId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 退库单编码方案
            pvs = GetParameter("56C7ED33-4263-46D4-BA11-E99BC6BDBCBB");
            _SchemeBakId = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;

            // 涉密等级
            pvs = GetParameter("F52A5EB0-D491-49BE-9FCB-2031D8AABB3C");
            _SecrecyLevel = pvs.Count > 0 && pvs[0] != null ? (Guid?)Guid.Parse(pvs[0]) : null;
        }

        /// <summary>
        /// 打印单据
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="type"></param>
        /// <param name="isPrinted"></param>
        /// <returns></returns>
        private object DoPrint(object bid, int type, bool isPrinted = false)
        {
            if (!_SchemeId.HasValue)
            {
                General.ShowError("当前尚未设定编码方案！请使用设置功能设定编码方案。");
                return null;
            }

            var tid = isPrinted ? null : _TempletId;
            var printer = Config.Printer("BilPrint");
            if (!isPrinted)
            {
                using (var cli = new SettlementClient(Binding, Address))
                {
                    var code = cli.GetDeliveryCode(UserSession, (Guid)_SchemeId, (Guid)bid, ModuleId, null);
                    _Deliverys.Table.Rows.Find(bid)["单据号"] = code;
                    _Image = new ImageData
                    {
                        Code = code.ToString(),
                        ImageType = type,
                        SecrecyDegree = _SecrecyLevel,
                        CreatorDeptId = UserSession.DeptId,
                        CreatorUserId = UserSession.UserId
                    };
                }
            }
            return PrintImage((Guid)bid, tid, printer, _Image);
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

                case "StoreIn":
                    StoreIn();
                    break;

                case "StoreOut":
                    StoreOut();
                    break;

                case "StoreBack":
                    StoreBack();
                    break;

                case "Print":
                    Print();
                    break;

                case "Preview":
                    Preview();
                    break;

                case "ShowReceipt":
                    ShowReceipt();
                    break;

                case "Attachment":
                    AddAttachment();
                    break;

                case "Delete":
                    Delete();
                    break;

                case "Setting":
                    Setting();
                    break;
            }
        }

        /// <summary>
        /// 入库
        /// </summary>
        private void StoreIn()
        {
            var dig = new Entry
            {
                Owner = this,
                MasterDatas = _Suppliers,
                Material = _Material,
                Units = _Units
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitDateTree();
                if (dig.IsPrint) _Deliverys.Table.Rows.Find(dig.ReceiptId)["ImageId"] = DoPrint(dig.ReceiptId, 5);
            }
            dig.Close();
        }

        /// <summary>
        /// 出库
        /// </summary>
        private void StoreOut()
        {
            var dig = new Outbound
            {
                Owner = this,
                MasterDatas = _Customers,
                Material = _Material,
                Units = _Units
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitDateTree();
                if (dig.IsPrint) _Deliverys.Table.Rows.Find(dig.ReceiptId)["ImageId"] = DoPrint(dig.ReceiptId, 6);
            }
            dig.Close();
        }

        /// <summary>
        /// 退库
        /// </summary>
        private void StoreBack()
        {
            var dig = new BackStore
            {
                Owner = this,
                MasterDatas = _Customers,
                Material = _Material,
                Units = _Units
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitDateTree();
                if (dig.IsPrint) _Deliverys.Table.Rows.Find(dig.ReceiptId)["ImageId"] = DoPrint(dig.ReceiptId, 7);
            }
            dig.Close();
        }

        /// <summary>
        /// 打印单据
        /// </summary>
        private void Print()
        {
            var imageId = gdvReceipts.GetFocusedDataRow()["ImageId"];
            var isPrinted = imageId != DBNull.Value;
            var id = isPrinted ? imageId : gdvReceipts.GetFocusedDataRow()["ID"];
            imageId = DoPrint(id, _Type, isPrinted);
            if (!isPrinted)
            {
                _Deliverys.Table.Rows.Find(id)["ImageId"] = imageId;
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
        /// 查看明细
        /// </summary>
        private void ShowReceipt()
        {
            var sid = gdvReceipts.GetFocusedDataRow()["ImageId"];
            var dig = new ShowDelivery
            {
                Owner = this,
                CanEdit = _CanEdit,
                ObjectId = _DeliveryId,
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

            if (Commons.SaveImages(id, imgs, "ABS_Delivery_Attachs", "DeliveryId"))
                General.ShowMessage("附件上传成功！如需查看附件，请打开查看对话框并切换到附件清单页。");
            else
                General.ShowError("附件上传失败！如多次上次失败，请联系管理员。");
        }

        /// <summary>
        /// 删除/作废
        /// </summary>
        private void Delete()
        {
            var row = _Deliverys.Table.Rows.Find(_DeliveryId);
            if (General.ShowConfirm($"您确定要{barManager.Items["Delete"].Caption}收费记录吗？") != DialogResult.OK) return;

            using (var cli = new SettlementClient(Binding, Address))
            {
                if (!cli.DelDelivery(UserSession, _DeliveryId))
                {
                    General.ShowError($"{barManager.Items["Delete"].Caption}收款记录失败！如多次失败，请联系管理员。");
                    return;
                }
                
                if (_Status == 1)
                {
                    row.Delete();
                    return;
                }
                
                row["状态"] = "作废";
                SwitchItemStatus(new Context("Attachment", false), new Context("Delete", false));
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        private void Setting()
        {
            var dig = new DeliverysSet { Owner = this };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                WriteModuleParameter(dig.Parameters);
                LoadParameters();
            }
            dig.Close();
        }

        #endregion

    }
}
