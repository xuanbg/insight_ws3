using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Base
{
    partial class AddMember
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
            var resources = new ComponentResourceManager(typeof(AddMember));
            this.tabMember = new XtraTabControl();
            this.pagTitle = new XtraTabPage();
            this.palTitle = new PanelControl();
            this.treOrg = new TreeList();
            this.pagGroup = new XtraTabPage();
            this.grdGroup = new GridControl();
            this.gdvGroup = new GridView();
            this.pagUser = new XtraTabPage();
            this.grdUser = new GridControl();
            this.gdvUser = new GridView();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            ((ISupportInitialize)(this.tabMember)).BeginInit();
            this.tabMember.SuspendLayout();
            this.pagTitle.SuspendLayout();
            ((ISupportInitialize)(this.palTitle)).BeginInit();
            this.palTitle.SuspendLayout();
            ((ISupportInitialize)(this.treOrg)).BeginInit();
            this.pagGroup.SuspendLayout();
            ((ISupportInitialize)(this.grdGroup)).BeginInit();
            ((ISupportInitialize)(this.gdvGroup)).BeginInit();
            this.pagUser.SuspendLayout();
            ((ISupportInitialize)(this.grdUser)).BeginInit();
            ((ISupportInitialize)(this.gdvUser)).BeginInit();
            this.SuspendLayout();
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
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(290, 424);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(200, 424);
            // 
            // panel
            // 
            this.panel.Size = new Size(370, 400);
            this.panel.Visible = false;
            // 
            // tabMember
            // 
            this.tabMember.Location = new Point(7, 7);
            this.tabMember.Name = "tabMember";
            this.tabMember.SelectedTabPage = this.pagTitle;
            this.tabMember.Size = new Size(374, 404);
            this.tabMember.TabIndex = 100;
            this.tabMember.TabPages.AddRange(new XtraTabPage[] {
            this.pagTitle,
            this.pagGroup,
            this.pagUser});
            // 
            // pagTitle
            // 
            this.pagTitle.Controls.Add(this.palTitle);
            this.pagTitle.Name = "pagTitle";
            this.pagTitle.Size = new Size(368, 375);
            this.pagTitle.Text = "添加职位成员";
            // 
            // palTitle
            // 
            this.palTitle.Controls.Add(this.treOrg);
            this.palTitle.Location = new Point(3, 3);
            this.palTitle.Name = "palTitle";
            this.palTitle.Size = new Size(362, 369);
            this.palTitle.TabIndex = 0;
            // 
            // treOrg
            // 
            this.treOrg.Dock = DockStyle.Fill;
            this.treOrg.Location = new Point(2, 2);
            this.treOrg.Name = "treOrg";
            this.treOrg.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treOrg.OptionsSelection.MultiSelect = true;
            this.treOrg.OptionsView.ShowCheckBoxes = true;
            this.treOrg.SelectImageList = this.imgOrgTreeNode;
            this.treOrg.Size = new Size(358, 365);
            this.treOrg.TabIndex = 0;
            // 
            // pagGroup
            // 
            this.pagGroup.Controls.Add(this.grdGroup);
            this.pagGroup.Name = "pagGroup";
            this.pagGroup.Size = new Size(368, 375);
            this.pagGroup.Text = "添加用户组成员";
            // 
            // grdGroup
            // 
            this.grdGroup.Location = new Point(3, 3);
            this.grdGroup.MainView = this.gdvGroup;
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.Size = new Size(362, 369);
            this.grdGroup.TabIndex = 0;
            this.grdGroup.ViewCollection.AddRange(new BaseView[] {
            this.gdvGroup});
            // 
            // gdvGroup
            // 
            this.gdvGroup.GridControl = this.grdGroup;
            this.gdvGroup.Name = "gdvGroup";
            this.gdvGroup.OptionsSelection.MultiSelect = true;
            this.gdvGroup.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // pagUser
            // 
            this.pagUser.Controls.Add(this.grdUser);
            this.pagUser.Name = "pagUser";
            this.pagUser.Size = new Size(368, 375);
            this.pagUser.Text = "添加用户成员";
            // 
            // grdUser
            // 
            this.grdUser.Location = new Point(3, 3);
            this.grdUser.MainView = this.gdvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new Size(362, 369);
            this.grdUser.TabIndex = 1;
            this.grdUser.ViewCollection.AddRange(new BaseView[] {
            this.gdvUser});
            // 
            // gdvUser
            // 
            this.gdvUser.GridControl = this.grdUser;
            this.gdvUser.Name = "gdvUser";
            this.gdvUser.OptionsFind.AlwaysVisible = true;
            this.gdvUser.OptionsFind.FindDelay = 100;
            this.gdvUser.OptionsFind.FindNullPrompt = "输入关键字进行查询…";
            this.gdvUser.OptionsFind.HighlightFindResults = false;
            this.gdvUser.OptionsSelection.MultiSelect = true;
            this.gdvUser.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // AddMember
            // 
            this.ClientSize = new Size(384, 462);
            this.Controls.Add(this.tabMember);
            this.Name = "AddMember";
            this.Text = "添加角色成员";
            this.Load += new EventHandler(this.AddMember_Load);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.tabMember, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            ((ISupportInitialize)(this.tabMember)).EndInit();
            this.tabMember.ResumeLayout(false);
            this.pagTitle.ResumeLayout(false);
            ((ISupportInitialize)(this.palTitle)).EndInit();
            this.palTitle.ResumeLayout(false);
            ((ISupportInitialize)(this.treOrg)).EndInit();
            this.pagGroup.ResumeLayout(false);
            ((ISupportInitialize)(this.grdGroup)).EndInit();
            ((ISupportInitialize)(this.gdvGroup)).EndInit();
            this.pagUser.ResumeLayout(false);
            ((ISupportInitialize)(this.grdUser)).EndInit();
            ((ISupportInitialize)(this.gdvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraTabControl tabMember;
        private XtraTabPage pagTitle;
        private XtraTabPage pagGroup;
        private XtraTabPage pagUser;
        private PanelControl palTitle;
        private TreeList treOrg;
        private GridControl grdGroup;
        private GridView gdvGroup;
        private GridControl grdUser;
        private GridView gdvUser;

    }
}
