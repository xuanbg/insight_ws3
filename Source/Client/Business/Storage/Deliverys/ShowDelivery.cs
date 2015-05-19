using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using Insight.WS.Client.Business.Storage.Service;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Business.Storage
{
    public partial class ShowDelivery : DialogBase
    {

        #region 属性

        public bool CanEdit { private get; set; }

        /// <summary>
        /// 打印快照ID
        /// </summary>
        public Guid? SnapshotId { private get; set; }

        #endregion

        #region 变量声明

        private ABS_Delivery _Delivery;
        private ImageData _Snapshot;
        private DataTable _Items;
        private DataTable _Attachs;
        private Guid _AttachId;
        private bool _HasAttach;
        private bool _CanDel;

        #endregion

        #region 构造方法

        public ShowDelivery()
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
        private void ShowReceipt_Load(object sender, EventArgs e)
        {
            _Snapshot = SnapshotId.HasValue ? Commons.ImageData((Guid)SnapshotId) : null;

            using (var cli = new StorageClient(OpenForm.Binding, OpenForm.Address))
            {
                _Delivery = cli.GetDelivery(OpenForm.UserSession, ObjectId);
                _Items = cli.GetDeliveryItem(OpenForm.UserSession, ObjectId);
                _Attachs = cli.GetDeliveryAttach(OpenForm.UserSession, ObjectId);
            }

            _HasAttach = _Attachs.Rows.Count > 0;
            tapSnapshot.PageEnabled = SnapshotId.HasValue;

            InitBaseInfo();
            InitItemList();
            InitAttachList();
            InitSnapshot();
        }

        /// <summary>
        /// 切换到附件页时显示查看附件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabInfo_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            btnOpen.Visible = e.Page.Name == "tapAttachs";
            btnOpen.Enabled = _HasAttach;
            btnDelete.Visible = e.Page.Name == "tapAttachs";
            btnDelete.Enabled = CanEdit && _CanDel && _HasAttach;
        }

        private void gdvAttach_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _AttachId = (Guid)gdvAttach.GetFocusedDataRow()["ID"];
            _CanDel = gdvAttach.GetFocusedDataRow()["扩展名"].ToString() != "fpx";
            btnOpen.Enabled = _HasAttach;
            btnDelete.Enabled = CanEdit && _CanDel && _HasAttach;
        }

        /// <summary>
        /// 双击附件列表查看附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAttach_DoubleClick(object sender, EventArgs e)
        {
            ViewAttach();
        }

        /// <summary>
        /// 点击查看按钮查看选中行附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ViewAttach();
        }

        /// <summary>
        /// 按下Del键删除选中行附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAttach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && CanEdit && _CanDel) Delete();
        }

        /// <summary>
        /// 点击删除按钮删除选中行附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CanEdit) Delete();
        }

        /// <summary>
        /// 重写窗体关闭事件，去除关闭确认功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void DialogClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化基础信息
        /// </summary>
        private void InitBaseInfo()
        {
            txtName.EditValue = _Delivery.ObjectName;
            memDesc.EditValue = _Delivery.Description;

            if (_Delivery.Direction == 0)
            {
                foreach (DataRow row in _Items.Rows)
                {
                    row["数量"] = -(decimal)row["数量"];
                    row["金额"] = -(decimal)row["金额"];
                }
            }
        }

        /// <summary>
        /// 初始化收费项目列表
        /// </summary>
        private void InitItemList()
        {
            grdItem.DataSource = _Items;
            Format.GridFormat(gdvItem);
            gdvItem.Columns["摘要"].Width = 260;
            gdvItem.Columns["项目"].Width = 160;
        }

        /// <summary>
        /// 初始化附件列表
        /// </summary>
        private void InitAttachList()
        {
            grdAttach.DataSource = _Attachs;
            Format.GridFormat(gdvAttach);
            gdvAttach.Columns["类型"].Width = 100;
            gdvAttach.Columns["编码"].Width = 140;
            gdvAttach.Columns["名称"].Width = 280;
            gdvAttach.Columns["扩展名"].Width = 60;
            gdvAttach.Columns["扩展名"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvAttach.Columns["密级"].Width = 60;
            gdvAttach.Columns["密级"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvAttach.Columns["页数"].Width = 60;
            gdvAttach.Columns["页数"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvAttach.Columns["字节数"].Width = 80;
        }

        /// <summary>
        /// 初始化收据快照
        /// </summary>
        private void InitSnapshot()
        {
            if (_Snapshot == null) return;

            pvcSnapshot.Load(new MemoryStream(_Snapshot.Image));
            pvcSnapshot.ZoomWholePage();
            if (!_Delivery.Validity) General.AddWatermark(pvcSnapshot.Report, "作 废");
            pvcSnapshot.Refresh();
        }

        /// <summary>
        /// 打开附件
        /// </summary>
        private void ViewAttach()
        {
            if (!_CanDel)
            {
                tabInfo.SelectedTabPageIndex = 2;
                return;
            }

            General.OpenAttach(_AttachId);
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        private void Delete()
        {
            var name = gdvAttach.GetFocusedDataRow()["名称"];
            if (General.ShowConfirm(string.Format("您确定要删除附件【{0}】吗？", name)) != DialogResult.OK) return;

            if (Commons.DelImageData(_AttachId))
            {
                _Attachs.Rows.Find(_AttachId).Delete();
                _Attachs.AcceptChanges();
                _HasAttach = _Attachs.Rows.Count > 0;
            }
            else
            {
                General.ShowError("删除附件失败！该附件可能被别的业务引用。");
            }
        }

        #endregion

        #region 按钮事件
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
