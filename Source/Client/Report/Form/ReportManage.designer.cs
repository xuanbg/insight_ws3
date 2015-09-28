using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Report
{
    partial class ReportManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportManage));
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpTree = new DevExpress.XtraEditors.GroupControl();
            this.treCategory = new DevExpress.XtraTreeList.TreeList();
            this.splReport = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpReport = new DevExpress.XtraEditors.GroupControl();
            this.grdReport = new DevExpress.XtraGrid.GridControl();
            this.gdvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splDetailed = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpInstalments = new DevExpress.XtraEditors.GroupControl();
            this.grdRules = new DevExpress.XtraGrid.GridControl();
            this.gdvRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splEntity = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpEntity = new DevExpress.XtraEditors.GroupControl();
            this.grdEntitys = new DevExpress.XtraGrid.GridControl();
            this.gdvEntitys = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpSubmit = new DevExpress.XtraEditors.GroupControl();
            this.grdMembers = new DevExpress.XtraGrid.GridControl();
            this.gdvMembers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).BeginInit();
            this.grpTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splReport)).BeginInit();
            this.splReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpReport)).BeginInit();
            this.grpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splDetailed)).BeginInit();
            this.splDetailed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpInstalments)).BeginInit();
            this.grpInstalments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splEntity)).BeginInit();
            this.splEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEntity)).BeginInit();
            this.grpEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntitys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEntitys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSubmit)).BeginInit();
            this.grpSubmit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpTree);
            this.splMain.Panel1.MinSize = 160;
            this.splMain.Panel2.Controls.Add(this.splReport);
            this.splMain.Panel2.MinSize = 600;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 200;
            this.splMain.TabIndex = 0;
            // 
            // grpTree
            // 
            this.grpTree.Controls.Add(this.treCategory);
            this.grpTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTree.Location = new System.Drawing.Point(0, 0);
            this.grpTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new System.Drawing.Size(200, 590);
            this.grpTree.TabIndex = 0;
            this.grpTree.Text = "报表分类";
            // 
            // treCategory
            // 
            this.treCategory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treCategory.Location = new System.Drawing.Point(2, 21);
            this.treCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treCategory.Name = "treCategory";
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new System.Drawing.Size(196, 567);
            this.treCategory.TabIndex = 1;
            this.treCategory.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treCategory.DoubleClick += new System.EventHandler(this.treCategory_DoubleClick);
            // 
            // splReport
            // 
            this.splReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splReport.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splReport.Horizontal = false;
            this.splReport.Location = new System.Drawing.Point(0, 0);
            this.splReport.Name = "splReport";
            this.splReport.Panel1.Controls.Add(this.grpReport);
            this.splReport.Panel1.MinSize = 200;
            this.splReport.Panel2.Controls.Add(this.splDetailed);
            this.splReport.Panel2.MinSize = 200;
            this.splReport.Size = new System.Drawing.Size(865, 590);
            this.splReport.SplitterPosition = 360;
            this.splReport.TabIndex = 0;
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.grdReport);
            this.grpReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReport.Location = new System.Drawing.Point(0, 0);
            this.grpReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(865, 360);
            this.grpReport.TabIndex = 0;
            this.grpReport.Text = "报表定义";
            // 
            // grdReport
            // 
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReport.Location = new System.Drawing.Point(2, 21);
            this.grdReport.MainView = this.gdvReport;
            this.grdReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReport.Name = "grdReport";
            this.grdReport.Size = new System.Drawing.Size(861, 337);
            this.grdReport.TabIndex = 2;
            this.grdReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvReport,
            this.gridView7});
            // 
            // gdvReport
            // 
            this.gdvReport.GridControl = this.grdReport;
            this.gdvReport.Name = "gdvReport";
            this.gdvReport.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvReport_FocusedRowObjectChanged);
            this.gdvReport.DoubleClick += new System.EventHandler(this.gdvReport_DoubleClick);
            // 
            // gridView7
            // 
            this.gridView7.GridControl = this.grdReport;
            this.gridView7.Name = "gridView7";
            // 
            // splDetailed
            // 
            this.splDetailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splDetailed.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splDetailed.Location = new System.Drawing.Point(0, 0);
            this.splDetailed.Name = "splDetailed";
            this.splDetailed.Panel1.Controls.Add(this.grpInstalments);
            this.splDetailed.Panel1.MinSize = 200;
            this.splDetailed.Panel1.Text = "Panel1";
            this.splDetailed.Panel2.Controls.Add(this.splEntity);
            this.splDetailed.Panel2.MinSize = 400;
            this.splDetailed.Panel2.Text = "Panel2";
            this.splDetailed.Size = new System.Drawing.Size(865, 225);
            this.splDetailed.SplitterPosition = 285;
            this.splDetailed.TabIndex = 0;
            this.splDetailed.Text = "splitContainerControl2";
            // 
            // grpInstalments
            // 
            this.grpInstalments.Controls.Add(this.grdRules);
            this.grpInstalments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInstalments.Location = new System.Drawing.Point(0, 0);
            this.grpInstalments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpInstalments.Name = "grpInstalments";
            this.grpInstalments.Size = new System.Drawing.Size(285, 225);
            this.grpInstalments.TabIndex = 0;
            this.grpInstalments.Text = "分期";
            // 
            // grdRules
            // 
            this.grdRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRules.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRules.Location = new System.Drawing.Point(2, 21);
            this.grdRules.MainView = this.gdvRules;
            this.grdRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRules.Name = "grdRules";
            this.grdRules.Size = new System.Drawing.Size(281, 202);
            this.grdRules.TabIndex = 3;
            this.grdRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvRules,
            this.gridView3});
            // 
            // gdvRules
            // 
            this.gdvRules.GridControl = this.grdRules;
            this.gdvRules.Name = "gdvRules";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdRules;
            this.gridView3.Name = "gridView3";
            // 
            // splEntity
            // 
            this.splEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splEntity.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splEntity.Location = new System.Drawing.Point(0, 0);
            this.splEntity.Name = "splEntity";
            this.splEntity.Panel1.Controls.Add(this.grpEntity);
            this.splEntity.Panel1.MinSize = 200;
            this.splEntity.Panel2.Controls.Add(this.grpSubmit);
            this.splEntity.Panel2.MinSize = 200;
            this.splEntity.Size = new System.Drawing.Size(575, 225);
            this.splEntity.SplitterPosition = 285;
            this.splEntity.TabIndex = 0;
            // 
            // grpEntity
            // 
            this.grpEntity.Controls.Add(this.grdEntitys);
            this.grpEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEntity.Location = new System.Drawing.Point(0, 0);
            this.grpEntity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpEntity.Name = "grpEntity";
            this.grpEntity.Size = new System.Drawing.Size(285, 225);
            this.grpEntity.TabIndex = 0;
            this.grpEntity.Text = "主体";
            // 
            // grdEntitys
            // 
            this.grdEntitys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEntitys.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEntitys.Location = new System.Drawing.Point(2, 21);
            this.grdEntitys.MainView = this.gdvEntitys;
            this.grdEntitys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdEntitys.Name = "grdEntitys";
            this.grdEntitys.Size = new System.Drawing.Size(281, 202);
            this.grdEntitys.TabIndex = 4;
            this.grdEntitys.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvEntitys,
            this.gridView2});
            // 
            // gdvEntitys
            // 
            this.gdvEntitys.GridControl = this.grdEntitys;
            this.gdvEntitys.Name = "gdvEntitys";
            this.gdvEntitys.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvEntity_FocusedRowObjectChanged);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdEntitys;
            this.gridView2.Name = "gridView2";
            // 
            // grpSubmit
            // 
            this.grpSubmit.Controls.Add(this.grdMembers);
            this.grpSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubmit.Location = new System.Drawing.Point(0, 0);
            this.grpSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSubmit.Name = "grpSubmit";
            this.grpSubmit.Size = new System.Drawing.Size(285, 225);
            this.grpSubmit.TabIndex = 0;
            this.grpSubmit.Text = "报送";
            // 
            // grdMembers
            // 
            this.grdMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMembers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMembers.Location = new System.Drawing.Point(2, 21);
            this.grdMembers.MainView = this.gdvMembers;
            this.grdMembers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMembers.Name = "grdMembers";
            this.grdMembers.Size = new System.Drawing.Size(281, 202);
            this.grdMembers.TabIndex = 5;
            this.grdMembers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvMembers,
            this.gridView5});
            // 
            // gdvMembers
            // 
            this.gdvMembers.GridControl = this.grdMembers;
            this.gdvMembers.Name = "gdvMembers";
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.grdMembers;
            this.gridView5.Name = "gridView5";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // ReportManage
            // 
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "ReportManage";
            this.Load += new System.EventHandler(this.ReportManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).EndInit();
            this.grpTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splReport)).EndInit();
            this.splReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpReport)).EndInit();
            this.grpReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splDetailed)).EndInit();
            this.splDetailed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpInstalments)).EndInit();
            this.grpInstalments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splEntity)).EndInit();
            this.splEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpEntity)).EndInit();
            this.grpEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntitys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEntitys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSubmit)).EndInit();
            this.grpSubmit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private GroupControl grpTree;
        private TreeList treCategory;
        private SplitContainerControl splReport;
        private GroupControl grpReport;
        private GridControl grdReport;
        private GridView gdvReport;
        private GridView gridView7;
        private GroupControl grpSubmit;
        private GridControl grdMembers;
        private GridView gdvMembers;
        private GridView gridView5;
        private SplitContainerControl splDetailed;
        private GroupControl grpInstalments;
        private GridControl grdRules;
        private GridView gdvRules;
        private GridView gridView3;
        private GroupControl grpEntity;
        private GridControl grdEntitys;
        private GridView gdvEntitys;
        private GridView gridView2;
        private GridView gridView1;
        private SplitContainerControl splEntity;


    }
}