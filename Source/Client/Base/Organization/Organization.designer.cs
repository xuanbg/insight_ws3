using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Base
{
    partial class Organization
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Organization));
            this.grpOrg = new DevExpress.XtraEditors.GroupControl();
            this.treOrgList = new DevExpress.XtraTreeList.TreeList();
            this.grpMember = new DevExpress.XtraEditors.GroupControl();
            this.grdMember = new DevExpress.XtraGrid.GridControl();
            this.gdvMember = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOrg)).BeginInit();
            this.grpOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
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
            // grpOrg
            // 
            this.grpOrg.Controls.Add(this.treOrgList);
            this.grpOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrg.Location = new System.Drawing.Point(0, 0);
            this.grpOrg.Name = "grpOrg";
            this.grpOrg.Size = new System.Drawing.Size(730, 590);
            this.grpOrg.TabIndex = 9;
            this.grpOrg.Text = "组织机构";
            // 
            // treOrgList
            // 
            this.treOrgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treOrgList.Location = new System.Drawing.Point(2, 22);
            this.treOrgList.Name = "treOrgList";
            this.treOrgList.Size = new System.Drawing.Size(726, 566);
            this.treOrgList.TabIndex = 0;
            this.treOrgList.NodesReloaded += new System.EventHandler(this.treOrgList_NodesReloaded);
            this.treOrgList.DoubleClick += new System.EventHandler(this.treOrgList_DoubleClick);
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.grdMember);
            this.grpMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMember.Location = new System.Drawing.Point(0, 0);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(335, 590);
            this.grpMember.TabIndex = 8;
            this.grpMember.Text = "职位用户";
            // 
            // grdMember
            // 
            this.grdMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMember.Location = new System.Drawing.Point(2, 22);
            this.grdMember.MainView = this.gdvMember;
            this.grdMember.Name = "grdMember";
            this.grdMember.Size = new System.Drawing.Size(331, 566);
            this.grdMember.TabIndex = 9;
            this.grdMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvMember});
            // 
            // gdvMember
            // 
            this.gdvMember.GridControl = this.grdMember;
            this.gdvMember.Name = "gdvMember";
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpOrg);
            this.splMain.Panel1.MinSize = 500;
            this.splMain.Panel2.Controls.Add(this.grpMember);
            this.splMain.Panel2.MinSize = 300;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 730;
            this.splMain.TabIndex = 0;
            // 
            // Organization
            // 
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "Organization";
            this.Load += new System.EventHandler(this.Organization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpOrg)).EndInit();
            this.grpOrg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treOrgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).EndInit();
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl grpOrg;
        private GroupControl grpMember;
        private GridControl grdMember;
        private GridView gdvMember;
        private GridView gridView2;
        private TreeList treOrgList;
        private SplitContainerControl splMain;
    }
}