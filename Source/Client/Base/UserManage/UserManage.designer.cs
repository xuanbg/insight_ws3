using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Platform.Base
{
    partial class UserManage
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManage));
            this.grdUser = new DevExpress.XtraGrid.GridControl();
            this.gdvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpUser = new DevExpress.XtraEditors.GroupControl();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.splGroup = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpUserGroup = new DevExpress.XtraEditors.GroupControl();
            this.grdGroup = new DevExpress.XtraGrid.GridControl();
            this.gdvGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpMember = new DevExpress.XtraEditors.GroupControl();
            this.grdMember = new DevExpress.XtraGrid.GridControl();
            this.gdvMember = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUser)).BeginInit();
            this.grpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splGroup)).BeginInit();
            this.splGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserGroup)).BeginInit();
            this.grpUserGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).BeginInit();
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
            // grdUser
            // 
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.Location = new System.Drawing.Point(2, 22);
            this.grdUser.MainView = this.gdvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new System.Drawing.Size(561, 566);
            this.grdUser.TabIndex = 3;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvUser});
            this.grdUser.Paint += new System.Windows.Forms.PaintEventHandler(this.grdUser_Paint);
            // 
            // gdvUser
            // 
            this.gdvUser.GridControl = this.grdUser;
            this.gdvUser.Name = "gdvUser";
            this.gdvUser.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvUser_FocusedRowObjectChanged);
            this.gdvUser.DoubleClick += new System.EventHandler(this.gdvUser_DoubleClick);
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.grdUser);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(565, 590);
            this.grpUser.TabIndex = 0;
            this.grpUser.Text = "用户";
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.splGroup);
            this.splMain.Panel1.MinSize = 400;
            this.splMain.Panel2.Controls.Add(this.grpUser);
            this.splMain.Panel2.MinSize = 400;
            this.splMain.Size = new System.Drawing.Size(1070, 590);
            this.splMain.SplitterPosition = 500;
            this.splMain.TabIndex = 0;
            // 
            // splGroup
            // 
            this.splGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splGroup.Horizontal = false;
            this.splGroup.Location = new System.Drawing.Point(0, 0);
            this.splGroup.Name = "splGroup";
            this.splGroup.Panel1.Controls.Add(this.grpUserGroup);
            this.splGroup.Panel1.MinSize = 200;
            this.splGroup.Panel1.Text = "Panel1";
            this.splGroup.Panel2.Controls.Add(this.grpMember);
            this.splGroup.Panel2.MinSize = 200;
            this.splGroup.Panel2.Text = "Panel2";
            this.splGroup.Size = new System.Drawing.Size(500, 590);
            this.splGroup.SplitterPosition = 300;
            this.splGroup.TabIndex = 0;
            // 
            // grpUserGroup
            // 
            this.grpUserGroup.Controls.Add(this.grdGroup);
            this.grpUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserGroup.Location = new System.Drawing.Point(0, 0);
            this.grpUserGroup.Name = "grpUserGroup";
            this.grpUserGroup.Size = new System.Drawing.Size(500, 300);
            this.grpUserGroup.TabIndex = 0;
            this.grpUserGroup.Text = "用户组";
            // 
            // grdGroup
            // 
            this.grdGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGroup.Location = new System.Drawing.Point(2, 22);
            this.grdGroup.MainView = this.gdvGroup;
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.Size = new System.Drawing.Size(496, 276);
            this.grdGroup.TabIndex = 1;
            this.grdGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvGroup});
            // 
            // gdvGroup
            // 
            this.gdvGroup.GridControl = this.grdGroup;
            this.gdvGroup.Name = "gdvGroup";
            this.gdvGroup.DoubleClick += new System.EventHandler(this.gdvGroup_DoubleClick);
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.grdMember);
            this.grpMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMember.Location = new System.Drawing.Point(0, 0);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(500, 285);
            this.grpMember.TabIndex = 0;
            this.grpMember.Text = "用户组成员";
            // 
            // grdMember
            // 
            this.grdMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMember.Location = new System.Drawing.Point(2, 22);
            this.grdMember.MainView = this.gdvMember;
            this.grdMember.Name = "grdMember";
            this.grdMember.Size = new System.Drawing.Size(496, 261);
            this.grdMember.TabIndex = 2;
            this.grdMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvMember});
            // 
            // gdvMember
            // 
            this.gdvMember.GridControl = this.grdMember;
            this.gdvMember.Name = "gdvMember";
            // 
            // UserManage
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "UserManage";
            this.Load += new System.EventHandler(this.UserManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUser)).EndInit();
            this.grpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splGroup)).EndInit();
            this.splGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpUserGroup)).EndInit();
            this.grpUserGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).EndInit();
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl grpUser;
        private GridControl grdUser;
        private GridView gdvUser;
        private SplitContainerControl splMain;
        private SplitContainerControl splGroup;
        private GroupControl grpUserGroup;
        private GridControl grdGroup;
        private GridView gdvGroup;
        private GroupControl grpMember;
        private GridControl grdMember;
        private GridView gdvMember;
    }
}