using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Base
{
    partial class RoleManage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleManage));
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpRole = new DevExpress.XtraEditors.GroupControl();
            this.grdRole = new DevExpress.XtraGrid.GridControl();
            this.gdvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splMember = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpMember = new DevExpress.XtraEditors.GroupControl();
            this.treMember = new DevExpress.XtraTreeList.TreeList();
            this.grpUser = new DevExpress.XtraEditors.GroupControl();
            this.grdUser = new DevExpress.XtraGrid.GridControl();
            this.gdvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPermission = new DevExpress.XtraTab.XtraTabControl();
            this.pagModule = new DevExpress.XtraTab.XtraTabPage();
            this.panModule = new DevExpress.XtraEditors.PanelControl();
            this.treModule = new DevExpress.XtraTreeList.TreeList();
            this.pagAction = new DevExpress.XtraTab.XtraTabPage();
            this.panAction = new DevExpress.XtraEditors.PanelControl();
            this.treAction = new DevExpress.XtraTreeList.TreeList();
            this.pagData = new DevExpress.XtraTab.XtraTabPage();
            this.panData = new DevExpress.XtraEditors.PanelControl();
            this.treData = new DevExpress.XtraTreeList.TreeList();
            this.imgPermission = new DevExpress.Utils.ImageCollection(this.components);
            this.imgMember = new DevExpress.Utils.ImageCollection(this.components);
            this.imgData = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRole)).BeginInit();
            this.grpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMember)).BeginInit();
            this.splMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUser)).BeginInit();
            this.grpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPermission)).BeginInit();
            this.tabPermission.SuspendLayout();
            this.pagModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panModule)).BeginInit();
            this.panModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treModule)).BeginInit();
            this.pagAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panAction)).BeginInit();
            this.panAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treAction)).BeginInit();
            this.pagData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panData)).BeginInit();
            this.panData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgData)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.xtraScrollable.Controls.Add(this.tabPermission);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 0);
            this.barDockControlBottom.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Location = new System.Drawing.Point(0, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMain.Horizontal = false;
            this.splMain.Location = new System.Drawing.Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpRole);
            this.splMain.Panel1.MinSize = 200;
            this.splMain.Panel2.Controls.Add(this.splMember);
            this.splMain.Panel2.MinSize = 200;
            this.splMain.ScrollBarSmallChange = 1;
            this.splMain.Size = new System.Drawing.Size(750, 590);
            this.splMain.SplitterPosition = 295;
            this.splMain.TabIndex = 0;
            // 
            // grpRole
            // 
            this.grpRole.Controls.Add(this.grdRole);
            this.grpRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRole.Location = new System.Drawing.Point(0, 0);
            this.grpRole.Name = "grpRole";
            this.grpRole.Size = new System.Drawing.Size(750, 295);
            this.grpRole.TabIndex = 0;
            this.grpRole.Text = "角色";
            // 
            // grdRole
            // 
            this.grdRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRole.Location = new System.Drawing.Point(2, 21);
            this.grdRole.MainView = this.gdvRole;
            this.grdRole.Name = "grdRole";
            this.grdRole.Size = new System.Drawing.Size(746, 272);
            this.grdRole.TabIndex = 1;
            this.grdRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvRole});
            // 
            // gdvRole
            // 
            this.gdvRole.GridControl = this.grdRole;
            this.gdvRole.Name = "gdvRole";
            this.gdvRole.DoubleClick += new System.EventHandler(this.gdvRole_DoubleClick);
            // 
            // splMember
            // 
            this.splMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMember.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splMember.Location = new System.Drawing.Point(0, 0);
            this.splMember.Name = "splMember";
            this.splMember.Panel1.Controls.Add(this.grpMember);
            this.splMember.Panel1.MinSize = 160;
            this.splMember.Panel2.Controls.Add(this.grpUser);
            this.splMember.Panel2.MinSize = 300;
            this.splMember.Size = new System.Drawing.Size(750, 290);
            this.splMember.SplitterPosition = 220;
            this.splMember.TabIndex = 0;
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.treMember);
            this.grpMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMember.Location = new System.Drawing.Point(0, 0);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(220, 290);
            this.grpMember.TabIndex = 0;
            this.grpMember.Text = "角色成员";
            // 
            // treMember
            // 
            this.treMember.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treMember.Location = new System.Drawing.Point(2, 21);
            this.treMember.Name = "treMember";
            this.treMember.OptionsView.ShowColumns = false;
            this.treMember.Size = new System.Drawing.Size(216, 267);
            this.treMember.TabIndex = 0;
            this.treMember.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treMember_FocusedNodeChanged);
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.grdUser);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(525, 290);
            this.grpUser.TabIndex = 0;
            this.grpUser.Text = "成员用户";
            // 
            // grdUser
            // 
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.Location = new System.Drawing.Point(2, 21);
            this.grdUser.MainView = this.gdvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new System.Drawing.Size(521, 267);
            this.grdUser.TabIndex = 0;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvUser});
            // 
            // gdvUser
            // 
            this.gdvUser.GridControl = this.grdUser;
            this.gdvUser.Name = "gdvUser";
            // 
            // tabPermission
            // 
            this.tabPermission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPermission.Location = new System.Drawing.Point(760, 5);
            this.tabPermission.Name = "tabPermission";
            this.tabPermission.SelectedTabPage = this.pagModule;
            this.tabPermission.Size = new System.Drawing.Size(319, 594);
            this.tabPermission.TabIndex = 0;
            this.tabPermission.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pagModule,
            this.pagAction,
            this.pagData});
            this.tabPermission.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabPermission_SelectedPageChanged);
            // 
            // pagModule
            // 
            this.pagModule.Controls.Add(this.panModule);
            this.pagModule.Name = "pagModule";
            this.pagModule.Size = new System.Drawing.Size(313, 565);
            this.pagModule.Text = "模块权限";
            // 
            // panModule
            // 
            this.panModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panModule.Controls.Add(this.treModule);
            this.panModule.Location = new System.Drawing.Point(2, 2);
            this.panModule.Name = "panModule";
            this.panModule.Size = new System.Drawing.Size(309, 561);
            this.panModule.TabIndex = 0;
            // 
            // treModule
            // 
            this.treModule.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treModule.Location = new System.Drawing.Point(2, 2);
            this.treModule.Name = "treModule";
            this.treModule.Size = new System.Drawing.Size(305, 557);
            this.treModule.TabIndex = 2;
            // 
            // pagAction
            // 
            this.pagAction.Controls.Add(this.panAction);
            this.pagAction.Name = "pagAction";
            this.pagAction.Size = new System.Drawing.Size(313, 565);
            this.pagAction.Text = "功能权限";
            // 
            // panAction
            // 
            this.panAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAction.Controls.Add(this.treAction);
            this.panAction.Location = new System.Drawing.Point(2, 2);
            this.panAction.Name = "panAction";
            this.panAction.Size = new System.Drawing.Size(309, 561);
            this.panAction.TabIndex = 0;
            // 
            // treAction
            // 
            this.treAction.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treAction.Location = new System.Drawing.Point(2, 2);
            this.treAction.Name = "treAction";
            this.treAction.OptionsView.ShowHorzLines = false;
            this.treAction.OptionsView.ShowIndicator = false;
            this.treAction.OptionsView.ShowVertLines = false;
            this.treAction.Size = new System.Drawing.Size(305, 557);
            this.treAction.TabIndex = 3;
            // 
            // pagData
            // 
            this.pagData.Controls.Add(this.panData);
            this.pagData.Name = "pagData";
            this.pagData.Size = new System.Drawing.Size(313, 565);
            this.pagData.Text = "数据权限";
            // 
            // panData
            // 
            this.panData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panData.Controls.Add(this.treData);
            this.panData.Location = new System.Drawing.Point(2, 2);
            this.panData.Name = "panData";
            this.panData.Size = new System.Drawing.Size(309, 561);
            this.panData.TabIndex = 0;
            // 
            // treData
            // 
            this.treData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treData.Location = new System.Drawing.Point(2, 2);
            this.treData.Name = "treData";
            this.treData.OptionsView.ShowHorzLines = false;
            this.treData.OptionsView.ShowIndicator = false;
            this.treData.OptionsView.ShowVertLines = false;
            this.treData.Size = new System.Drawing.Size(305, 557);
            this.treData.TabIndex = 4;
            // 
            // imgPermission
            // 
            this.imgPermission.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgPermission.ImageStream")));
            this.imgPermission.Images.SetKeyName(0, "Navigation.png");
            this.imgPermission.Images.SetKeyName(1, "Module.png");
            this.imgPermission.Images.SetKeyName(2, "Action.png");
            this.imgPermission.InsertGalleryImage("close_16x16.png", "images/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png"), 3);
            this.imgPermission.Images.SetKeyName(3, "close_16x16.png");
            this.imgPermission.InsertGalleryImage("checkbox_16x16.png", "images/content/checkbox_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/checkbox_16x16.png"), 4);
            this.imgPermission.Images.SetKeyName(4, "checkbox_16x16.png");
            // 
            // imgMember
            // 
            this.imgMember.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMember.ImageStream")));
            this.imgMember.Images.SetKeyName(0, "Suggestion.png");
            this.imgMember.Images.SetKeyName(1, "User.png");
            this.imgMember.Images.SetKeyName(2, "Group.png");
            this.imgMember.Images.SetKeyName(3, "NodePost.png");
            // 
            // imgData
            // 
            this.imgData.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgData.ImageStream")));
            this.imgData.Images.SetKeyName(0, "Navigation.png");
            this.imgData.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 1);
            this.imgData.Images.SetKeyName(1, "database_16x16.png");
            this.imgData.InsertGalleryImage("new_16x16.png", "images/actions/new_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/new_16x16.png"), 2);
            this.imgData.Images.SetKeyName(2, "new_16x16.png");
            this.imgData.InsertGalleryImage("customer_16x16.png", "images/people/customer_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/customer_16x16.png"), 3);
            this.imgData.Images.SetKeyName(3, "customer_16x16.png");
            this.imgData.Images.SetKeyName(4, "NodeDept.png");
            this.imgData.InsertGalleryImage("home_16x16.png", "images/navigation/home_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 5);
            this.imgData.Images.SetKeyName(5, "home_16x16.png");
            this.imgData.Images.SetKeyName(6, "NodeOrg.png");
            this.imgData.InsertGalleryImage("documentmap_16x16.png", "images/navigation/documentmap_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/documentmap_16x16.png"), 7);
            this.imgData.Images.SetKeyName(7, "documentmap_16x16.png");
            // 
            // RoleManage
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "RoleManage";
            this.Load += new System.EventHandler(this.RoleManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpRole)).EndInit();
            this.grpRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMember)).EndInit();
            this.splMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMember)).EndInit();
            this.grpMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUser)).EndInit();
            this.grpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPermission)).EndInit();
            this.tabPermission.ResumeLayout(false);
            this.pagModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panModule)).EndInit();
            this.panModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treModule)).EndInit();
            this.pagAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panAction)).EndInit();
            this.panAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treAction)).EndInit();
            this.pagData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panData)).EndInit();
            this.panData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private GroupControl grpMember;
        private GroupControl grpRole;
        private GroupControl grpUser;
        private PanelControl panModule;
        private PanelControl panAction;
        private SplitContainerControl splMain;
        private SplitContainerControl splMember;
        private GridControl grdRole;
        private GridView gdvRole;
        private GridControl grdUser;
        private GridView gdvUser;
        private XtraTabControl tabPermission;
        private XtraTabPage pagModule;
        private XtraTabPage pagAction;
        private XtraTabPage pagData;
        private TreeList treAction;
        private TreeList treModule;
        private TreeList treMember;
        private ImageCollection imgMember;
        private ImageCollection imgPermission;
        private PanelControl panData;
        private TreeList treData;
        private ImageCollection imgData;

    }
}