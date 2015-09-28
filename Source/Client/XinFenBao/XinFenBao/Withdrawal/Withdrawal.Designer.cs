namespace Insight.WS.Client.XinFenBao
{
    partial class Withdrawal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Withdrawal));
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.palTree = new DevExpress.XtraEditors.PanelControl();
            this.treDate = new DevExpress.XtraTreeList.TreeList();
            this.grdReceipts = new DevExpress.XtraGrid.GridControl();
            this.gdvReceipts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.palSplit = new DevExpress.XtraEditors.PanelControl();
            this.palFilter = new DevExpress.XtraEditors.PanelControl();
            this.bteSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palTree)).BeginInit();
            this.palTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceipts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvReceipts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palFilter)).BeginInit();
            this.palFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
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
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.palTree);
            this.splMain.Panel1.MinSize = 120;
            this.splMain.Panel2.Controls.Add(this.grdReceipts);
            this.splMain.Panel2.Controls.Add(this.palSplit);
            this.splMain.Panel2.Controls.Add(this.palFilter);
            this.splMain.Panel2.MinSize = 800;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 160;
            this.splMain.TabIndex = 1;
            this.splMain.Text = "splitContainerControl1";
            // 
            // palTree
            // 
            this.palTree.Controls.Add(this.treDate);
            this.palTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palTree.Location = new System.Drawing.Point(0, 0);
            this.palTree.Name = "palTree";
            this.palTree.Size = new System.Drawing.Size(160, 590);
            this.palTree.TabIndex = 0;
            // 
            // treDate
            // 
            this.treDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treDate.Location = new System.Drawing.Point(2, 2);
            this.treDate.Name = "treDate";
            this.treDate.Size = new System.Drawing.Size(156, 586);
            this.treDate.TabIndex = 1;
            // 
            // grdReceipts
            // 
            this.grdReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReceipts.Location = new System.Drawing.Point(0, 45);
            this.grdReceipts.MainView = this.gdvReceipts;
            this.grdReceipts.Name = "grdReceipts";
            this.grdReceipts.Size = new System.Drawing.Size(905, 545);
            this.grdReceipts.TabIndex = 2;
            this.grdReceipts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvReceipts});
            // 
            // gdvReceipts
            // 
            this.gdvReceipts.GridControl = this.grdReceipts;
            this.gdvReceipts.Name = "gdvReceipts";
            // 
            // palSplit
            // 
            this.palSplit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.palSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.palSplit.Location = new System.Drawing.Point(0, 40);
            this.palSplit.Name = "palSplit";
            this.palSplit.Size = new System.Drawing.Size(905, 5);
            this.palSplit.TabIndex = 3;
            // 
            // palFilter
            // 
            this.palFilter.Controls.Add(this.bteSearch);
            this.palFilter.Controls.Add(this.btnQuery);
            this.palFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.palFilter.Location = new System.Drawing.Point(0, 0);
            this.palFilter.Name = "palFilter";
            this.palFilter.Size = new System.Drawing.Size(905, 40);
            this.palFilter.TabIndex = 0;
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bteSearch.EditValue = "在此输入客户手机号进行查询…";
            this.bteSearch.Location = new System.Drawing.Point(10, 10);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入结算单位名称进行查询…";
            this.bteSearch.Size = new System.Drawing.Size(808, 21);
            this.bteSearch.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(826, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(70, 22);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查  询";
            // 
            // Withdrawal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "Withdrawal";
            this.Text = "Withdrawal";
            this.Load += new System.EventHandler(this.Withdrawal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.palTree)).EndInit();
            this.palTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReceipts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvReceipts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palFilter)).EndInit();
            this.palFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splMain;
        private DevExpress.XtraEditors.PanelControl palTree;
        private DevExpress.XtraTreeList.TreeList treDate;
        private DevExpress.XtraGrid.GridControl grdReceipts;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvReceipts;
        private DevExpress.XtraEditors.PanelControl palSplit;
        private DevExpress.XtraEditors.PanelControl palFilter;
        private DevExpress.XtraEditors.ButtonEdit bteSearch;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
    }
}