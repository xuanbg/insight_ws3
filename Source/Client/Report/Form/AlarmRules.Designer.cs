using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Report
{
    partial class AlarmRules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmRules));
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpWarning = new DevExpress.XtraEditors.GroupControl();
            this.gcWaining = new DevExpress.XtraGrid.GridControl();
            this.gvWarining = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpTree = new DevExpress.XtraEditors.GroupControl();
            this.splRules = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpRules = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpWarning)).BeginInit();
            this.grpWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).BeginInit();
            this.grpTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splRules)).BeginInit();
            this.splRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRules)).BeginInit();
            this.grpRules.SuspendLayout();
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
            // treeList
            // 
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(2, 22);
            this.treeList.Name = "treeList";
            this.treeList.Size = new System.Drawing.Size(246, 566);
            this.treeList.TabIndex = 1;
            // 
            // gcMain
            // 
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(2, 22);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(811, 176);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // grpWarning
            // 
            this.grpWarning.Controls.Add(this.gcWaining);
            this.grpWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWarning.Location = new System.Drawing.Point(0, 0);
            this.grpWarning.Name = "grpWarning";
            this.grpWarning.Size = new System.Drawing.Size(815, 385);
            this.grpWarning.TabIndex = 0;
            this.grpWarning.Text = "预警消息：";
            // 
            // gcWaining
            // 
            this.gcWaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWaining.Location = new System.Drawing.Point(2, 22);
            this.gcWaining.MainView = this.gvWarining;
            this.gcWaining.Name = "gcWaining";
            this.gcWaining.Size = new System.Drawing.Size(811, 361);
            this.gcWaining.TabIndex = 2;
            this.gcWaining.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWarining});
            // 
            // gvWarining
            // 
            this.gvWarining.GridControl = this.gcWaining;
            this.gvWarining.Name = "gvWarining";
            this.gvWarining.OptionsView.ShowGroupPanel = false;
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpTree);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.splRules);
            this.splMain.Panel2.MinSize = 600;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 250;
            this.splMain.TabIndex = 0;
            // 
            // grpTree
            // 
            this.grpTree.Controls.Add(this.treeList);
            this.grpTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTree.Location = new System.Drawing.Point(0, 0);
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new System.Drawing.Size(250, 590);
            this.grpTree.TabIndex = 13;
            this.grpTree.Text = "规则分类";
            // 
            // splRules
            // 
            this.splRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splRules.Horizontal = false;
            this.splRules.Location = new System.Drawing.Point(0, 0);
            this.splRules.Name = "splRules";
            this.splRules.Panel1.Controls.Add(this.grpRules);
            this.splRules.Panel1.MinSize = 160;
            this.splRules.Panel2.Controls.Add(this.grpWarning);
            this.splRules.Panel2.MinSize = 200;
            this.splRules.Size = new System.Drawing.Size(815, 590);
            this.splRules.SplitterPosition = 200;
            this.splRules.TabIndex = 0;
            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.gcMain);
            this.grpRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRules.Location = new System.Drawing.Point(0, 0);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(815, 200);
            this.grpRules.TabIndex = 0;
            this.grpRules.Text = "预警规则";
            // 
            // AlarmRules
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "AlarmRules";
            this.Load += new System.EventHandler(this.AlarmRules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpWarning)).EndInit();
            this.grpWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).EndInit();
            this.grpTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splRules)).EndInit();
            this.splRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpRules)).EndInit();
            this.grpRules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeList treeList;
        private GridControl gcMain;
        private GridView gvMain;
        private GroupControl grpWarning;
        private GridControl gcWaining;
        private GridView gvWarining;
        private SplitContainerControl splMain;
        private SplitContainerControl splRules;
        private GroupControl grpTree;
        private GroupControl grpRules;


    }
}