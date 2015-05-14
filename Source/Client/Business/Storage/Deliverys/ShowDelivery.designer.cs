namespace Insight.WS.Client.Business.Storage
{
    partial class ShowDelivery
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDelivery));
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.tapDetail = new DevExpress.XtraTab.XtraTabPage();
            this.grdItem = new DevExpress.XtraGrid.GridControl();
            this.gdvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tapAttachs = new DevExpress.XtraTab.XtraTabPage();
            this.grpDesc = new DevExpress.XtraEditors.GroupControl();
            this.memDesc = new DevExpress.XtraEditors.MemoEdit();
            this.grdAttach = new DevExpress.XtraGrid.GridControl();
            this.gdvAttach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tapSnapshot = new DevExpress.XtraTab.XtraTabPage();
            this.pvcSnapshot = new FastReport.Preview.PreviewControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.tapDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItem)).BeginInit();
            this.tapAttachs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDesc)).BeginInit();
            this.grpDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttach)).BeginInit();
            this.tapSnapshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(760, 454);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(670, 454);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtName);
            this.panel.Size = new System.Drawing.Size(840, 49);
            // 
            // tabInfo
            // 
            this.tabInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInfo.Location = new System.Drawing.Point(7, 62);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedTabPage = this.tapDetail;
            this.tabInfo.Size = new System.Drawing.Size(844, 427);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tapDetail,
            this.tapAttachs,
            this.tapSnapshot});
            this.tabInfo.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabInfo_SelectedPageChanged);
            // 
            // tapDetail
            // 
            this.tapDetail.Controls.Add(this.grdItem);
            this.tapDetail.Name = "tapDetail";
            this.tapDetail.Size = new System.Drawing.Size(838, 398);
            this.tapDetail.Text = "物资明细";
            // 
            // grdItem
            // 
            this.grdItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdItem.Location = new System.Drawing.Point(2, 2);
            this.grdItem.MainView = this.gdvItem;
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(834, 394);
            this.grdItem.TabIndex = 0;
            this.grdItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.tapAttachs.Size = new System.Drawing.Size(838, 398);
            this.tapAttachs.Text = "附件清单";
            // 
            // grpDesc
            // 
            this.grpDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDesc.Controls.Add(this.memDesc);
            this.grpDesc.Location = new System.Drawing.Point(2, 238);
            this.grpDesc.Name = "grpDesc";
            this.grpDesc.Size = new System.Drawing.Size(834, 158);
            this.grpDesc.TabIndex = 2;
            this.grpDesc.Text = "备注";
            // 
            // memDesc
            // 
            this.memDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memDesc.Location = new System.Drawing.Point(2, 22);
            this.memDesc.Name = "memDesc";
            this.memDesc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memDesc.Size = new System.Drawing.Size(830, 134);
            this.memDesc.TabIndex = 1;
            this.memDesc.UseOptimizedRendering = true;
            // 
            // grdAttach
            // 
            this.grdAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAttach.Location = new System.Drawing.Point(2, 2);
            this.grdAttach.MainView = this.gdvAttach;
            this.grdAttach.Name = "grdAttach";
            this.grdAttach.Size = new System.Drawing.Size(834, 234);
            this.grdAttach.TabIndex = 0;
            this.grdAttach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvAttach});
            // 
            // gdvAttach
            // 
            this.gdvAttach.GridControl = this.grdAttach;
            this.gdvAttach.Name = "gdvAttach";
            this.gdvAttach.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvAttach_FocusedRowObjectChanged);
            this.gdvAttach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvAttach_KeyDown);
            this.gdvAttach.DoubleClick += new System.EventHandler(this.gdvAttach_DoubleClick);
            // 
            // tapSnapshot
            // 
            this.tapSnapshot.Controls.Add(this.pvcSnapshot);
            this.tapSnapshot.Name = "tapSnapshot";
            this.tapSnapshot.Size = new System.Drawing.Size(838, 398);
            this.tapSnapshot.Text = "单据快照";
            // 
            // pvcSnapshot
            // 
            this.pvcSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvcSnapshot.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pvcSnapshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pvcSnapshot.FastScrolling = true;
            this.pvcSnapshot.Font = new System.Drawing.Font("宋体", 9F);
            this.pvcSnapshot.Location = new System.Drawing.Point(2, 2);
            this.pvcSnapshot.Name = "pvcSnapshot";
            this.pvcSnapshot.PageOffset = new System.Drawing.Point(9, 9);
            this.pvcSnapshot.Size = new System.Drawing.Size(834, 394);
            this.pvcSnapshot.StatusbarVisible = false;
            this.pvcSnapshot.TabIndex = 0;
            this.pvcSnapshot.ToolbarVisible = false;
            this.pvcSnapshot.UIStyle = FastReport.Utils.UIStyle.Office2007Silver;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "交付单位：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 15);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(745, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(742, 61);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 20);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "查 看";
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(797, 61);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 20);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删 除";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ShowDelivery
            // 
            this.ClientSize = new System.Drawing.Size(854, 492);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tabInfo);
            this.Name = "ShowDelivery";
            this.Text = "查看";
            this.Load += new System.EventHandler(this.ShowReceipt_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.tabInfo, 0);
            this.Controls.SetChildIndex(this.btnOpen, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.tapDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItem)).EndInit();
            this.tapAttachs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDesc)).EndInit();
            this.grpDesc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttach)).EndInit();
            this.tapSnapshot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage tapDetail;
        private DevExpress.XtraTab.XtraTabPage tapAttachs;
        private DevExpress.XtraGrid.GridControl grdItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvItem;
        private DevExpress.XtraTab.XtraTabPage tapSnapshot;
        private DevExpress.XtraGrid.GridControl grdAttach;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvAttach;
        private FastReport.Preview.PreviewControl pvcSnapshot;
        private DevExpress.XtraEditors.LabelControl labName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.GroupControl grpDesc;
        private DevExpress.XtraEditors.MemoEdit memDesc;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
