using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using FastReport.Preview;
using FastReport.Utils;

namespace Insight.WS.Client.Business.Settlement
{
    partial class ShowReceipt
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(ShowReceipt));
            this.tabInfo = new XtraTabControl();
            this.tapDetail = new XtraTabPage();
            this.grdPay = new GridControl();
            this.gdvPay = new GridView();
            this.grdItem = new GridControl();
            this.gdvItem = new GridView();
            this.tapAttachs = new XtraTabPage();
            this.grpDesc = new GroupControl();
            this.memDesc = new MemoEdit();
            this.grdAttach = new GridControl();
            this.gdvAttach = new GridView();
            this.tapSnapshot = new XtraTabPage();
            this.pvcSnapshot = new PreviewControl();
            this.labName = new LabelControl();
            this.txtName = new TextEdit();
            this.labAmount = new LabelControl();
            this.txtAmount = new TextEdit();
            this.btnOpen = new SimpleButton();
            this.btnDelete = new SimpleButton();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.tapDetail.SuspendLayout();
            ((ISupportInitialize)(this.grdPay)).BeginInit();
            ((ISupportInitialize)(this.gdvPay)).BeginInit();
            ((ISupportInitialize)(this.grdItem)).BeginInit();
            ((ISupportInitialize)(this.gdvItem)).BeginInit();
            this.tapAttachs.SuspendLayout();
            ((ISupportInitialize)(this.grpDesc)).BeginInit();
            this.grpDesc.SuspendLayout();
            ((ISupportInitialize)(this.memDesc.Properties)).BeginInit();
            ((ISupportInitialize)(this.grdAttach)).BeginInit();
            ((ISupportInitialize)(this.gdvAttach)).BeginInit();
            this.tapSnapshot.SuspendLayout();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.labAmount);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtAmount);
            this.panel.Controls.Add(this.txtName);
            this.panel.Size = new Size(840, 49);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(760, 454);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(670, 454);
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // tabInfo
            // 
            this.tabInfo.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.tabInfo.Location = new Point(7, 62);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedTabPage = this.tapDetail;
            this.tabInfo.Size = new Size(844, 427);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new XtraTabPage[] {
            this.tapDetail,
            this.tapAttachs,
            this.tapSnapshot});
            this.tabInfo.SelectedPageChanged += new TabPageChangedEventHandler(this.tabInfo_SelectedPageChanged);
            // 
            // tapDetail
            // 
            this.tapDetail.Controls.Add(this.grdPay);
            this.tapDetail.Controls.Add(this.grdItem);
            this.tapDetail.Name = "tapDetail";
            this.tapDetail.Size = new Size(838, 398);
            this.tapDetail.Text = "款项明细";
            // 
            // grdPay
            // 
            this.grdPay.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.grdPay.Location = new Point(2, 238);
            this.grdPay.MainView = this.gdvPay;
            this.grdPay.Name = "grdPay";
            this.grdPay.Size = new Size(834, 158);
            this.grdPay.TabIndex = 1;
            this.grdPay.ViewCollection.AddRange(new BaseView[] {
            this.gdvPay});
            // 
            // gdvPay
            // 
            this.gdvPay.GridControl = this.grdPay;
            this.gdvPay.Name = "gdvPay";
            // 
            // grdItem
            // 
            this.grdItem.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.grdItem.Location = new Point(2, 2);
            this.grdItem.MainView = this.gdvItem;
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new Size(834, 234);
            this.grdItem.TabIndex = 0;
            this.grdItem.ViewCollection.AddRange(new BaseView[] {
            this.gdvItem});
            // 
            // gdvItem
            // 
            this.gdvItem.GridControl = this.grdItem;
            this.gdvItem.Name = "gdvItem";
            // 
            // tapAttachs
            // 
            this.tapAttachs.Controls.Add(this.grpDesc);
            this.tapAttachs.Controls.Add(this.grdAttach);
            this.tapAttachs.Name = "tapAttachs";
            this.tapAttachs.Size = new Size(838, 398);
            this.tapAttachs.Text = "附件清单";
            // 
            // grpDesc
            // 
            this.grpDesc.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.grpDesc.Controls.Add(this.memDesc);
            this.grpDesc.Location = new Point(2, 238);
            this.grpDesc.Name = "grpDesc";
            this.grpDesc.Size = new Size(834, 158);
            this.grpDesc.TabIndex = 2;
            this.grpDesc.Text = "备注";
            // 
            // memDesc
            // 
            this.memDesc.Dock = DockStyle.Fill;
            this.memDesc.Location = new Point(2, 22);
            this.memDesc.Name = "memDesc";
            this.memDesc.Properties.BorderStyle = BorderStyles.NoBorder;
            this.memDesc.Size = new Size(830, 134);
            this.memDesc.TabIndex = 1;
            this.memDesc.UseOptimizedRendering = true;
            // 
            // grdAttach
            // 
            this.grdAttach.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.grdAttach.Location = new Point(2, 2);
            this.grdAttach.MainView = this.gdvAttach;
            this.grdAttach.Name = "grdAttach";
            this.grdAttach.Size = new Size(834, 234);
            this.grdAttach.TabIndex = 0;
            this.grdAttach.ViewCollection.AddRange(new BaseView[] {
            this.gdvAttach});
            // 
            // gdvAttach
            // 
            this.gdvAttach.GridControl = this.grdAttach;
            this.gdvAttach.Name = "gdvAttach";
            this.gdvAttach.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvAttach_FocusedRowObjectChanged);
            this.gdvAttach.KeyDown += new KeyEventHandler(this.gdvAttach_KeyDown);
            this.gdvAttach.DoubleClick += new EventHandler(this.gdvAttach_DoubleClick);
            // 
            // tapSnapshot
            // 
            this.tapSnapshot.Controls.Add(this.pvcSnapshot);
            this.tapSnapshot.Name = "tapSnapshot";
            this.tapSnapshot.Size = new Size(838, 398);
            this.tapSnapshot.Text = "单据快照";
            // 
            // pvcSnapshot
            // 
            this.pvcSnapshot.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.pvcSnapshot.BackColor = SystemColors.AppWorkspace;
            this.pvcSnapshot.BorderStyle = BorderStyle.FixedSingle;
            this.pvcSnapshot.FastScrolling = true;
            this.pvcSnapshot.Font = new Font("宋体", 9F);
            this.pvcSnapshot.Location = new Point(2, 2);
            this.pvcSnapshot.Name = "pvcSnapshot";
            this.pvcSnapshot.PageOffset = new Point(9, 9);
            this.pvcSnapshot.Size = new Size(834, 394);
            this.pvcSnapshot.StatusbarVisible = false;
            this.pvcSnapshot.TabIndex = 0;
            this.pvcSnapshot.ToolbarVisible = false;
            this.pvcSnapshot.UIStyle = UIStyle.Office2007Silver;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(0, 15);
            this.labName.Name = "labName";
            this.labName.Size = new Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "结算单位：";
            // 
            // txtName
            // 
            this.txtName.Location = new Point(80, 15);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new Size(460, 20);
            this.txtName.TabIndex = 1;
            // 
            // labAmount
            // 
            this.labAmount.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labAmount.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labAmount.AutoSizeMode = LabelAutoSizeMode.None;
            this.labAmount.Location = new Point(540, 15);
            this.labAmount.Name = "labAmount";
            this.labAmount.Size = new Size(80, 21);
            this.labAmount.TabIndex = 0;
            this.labAmount.Text = "总金额：";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new Point(620, 15);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.DisplayFormat.FormatString = "c";
            this.txtAmount.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.txtAmount.Properties.ReadOnly = true;
            this.txtAmount.Size = new Size(185, 20);
            this.txtAmount.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = ((Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new Point(793, 61);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new Size(24, 20);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new Point(823, 61);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(24, 20);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // ShowReceipt
            // 
            this.ClientSize = new Size(854, 492);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tabInfo);
            this.Name = "ShowReceipt";
            this.Text = "查看";
            this.Load += new EventHandler(this.ShowReceipt_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.tabInfo, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnOpen, 0);
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.tapDetail.ResumeLayout(false);
            ((ISupportInitialize)(this.grdPay)).EndInit();
            ((ISupportInitialize)(this.gdvPay)).EndInit();
            ((ISupportInitialize)(this.grdItem)).EndInit();
            ((ISupportInitialize)(this.gdvItem)).EndInit();
            this.tapAttachs.ResumeLayout(false);
            ((ISupportInitialize)(this.grpDesc)).EndInit();
            this.grpDesc.ResumeLayout(false);
            ((ISupportInitialize)(this.memDesc.Properties)).EndInit();
            ((ISupportInitialize)(this.grdAttach)).EndInit();
            ((ISupportInitialize)(this.gdvAttach)).EndInit();
            this.tapSnapshot.ResumeLayout(false);
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraTabControl tabInfo;
        private XtraTabPage tapDetail;
        private XtraTabPage tapAttachs;
        private GridControl grdItem;
        private GridView gdvItem;
        private XtraTabPage tapSnapshot;
        private GridControl grdAttach;
        private GridView gdvAttach;
        private PreviewControl pvcSnapshot;
        private LabelControl labAmount;
        private LabelControl labName;
        private TextEdit txtAmount;
        private TextEdit txtName;
        private GridControl grdPay;
        private GridView gdvPay;
        private SimpleButton btnOpen;
        private SimpleButton btnDelete;
        private GroupControl grpDesc;
        private MemoEdit memDesc;
    }
}
