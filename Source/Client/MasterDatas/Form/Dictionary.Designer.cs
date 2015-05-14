using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.MasterDatas
{
    partial class Dictionary
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
            var resources = new ComponentResourceManager(typeof(Dictionary));
            this.splMain = new SplitContainerControl();
            this.grpCategory = new GroupControl();
            this.treCategory = new TreeList();
            this.grdData = new GridControl();
            this.gdvData = new GridView();
            this.barButtonItem1 = new BarButtonItem();
            this.barButtonItem2 = new BarButtonItem();
            this.barButtonItem3 = new BarButtonItem();
            this.barButtonItem4 = new BarButtonItem();
            this.btnAdd = new BarButtonItem();
            this.Edit = new BarButtonItem();
            this.Del = new BarButtonItem();
            this.Rev = new BarButtonItem();
            this.barButtonItem5 = new BarButtonItem();
            this.barButtonItem6 = new BarButtonItem();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grpCategory)).BeginInit();
            this.grpCategory.SuspendLayout();
            ((ISupportInitialize)(this.treCategory)).BeginInit();
            ((ISupportInitialize)(this.grdData)).BeginInit();
            ((ISupportInitialize)(this.gdvData)).BeginInit();
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
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.splMain);
            // 
            // splMain
            // 
            this.splMain.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.splMain.FixedPanel = SplitFixedPanel.None;
            this.splMain.Location = new Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.grpCategory);
            this.splMain.Panel1.MinSize = 160;
            this.splMain.Panel2.Controls.Add(this.grdData);
            this.splMain.Panel2.MinSize = 600;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 200;
            this.splMain.TabIndex = 0;
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.treCategory);
            this.grpCategory.Dock = DockStyle.Fill;
            this.grpCategory.Location = new Point(0, 0);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new Size(200, 590);
            this.grpCategory.TabIndex = 1;
            this.grpCategory.Text = "字典分类";
            // 
            // treCategory
            // 
            this.treCategory.Dock = DockStyle.Fill;
            this.treCategory.Location = new Point(2, 22);
            this.treCategory.Name = "treCategory";
            this.treCategory.OptionsView.ShowColumns = false;
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new Size(196, 566);
            this.treCategory.TabIndex = 0;
            this.treCategory.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treCategory.DoubleClick += new EventHandler(this.treCategory_DoubleClick);
            // 
            // grdData
            // 
            this.grdData.Dock = DockStyle.Fill;
            this.grdData.Location = new Point(0, 0);
            this.grdData.MainView = this.gdvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new Size(865, 590);
            this.grdData.TabIndex = 0;
            this.grdData.ViewCollection.AddRange(new BaseView[] {
            this.gdvData});
            // 
            // gdvData
            // 
            this.gdvData.GridControl = this.grdData;
            this.gdvData.Name = "gdvData";
            this.gdvData.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gvData_FocusedRowObjectChanged);
            this.gdvData.DoubleClick += new EventHandler(this.gdvData_DoubleClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = -1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = -1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = -1;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Id = -1;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btnAdd
            // 
            this.btnAdd.Id = -1;
            this.btnAdd.Name = "btnAdd";
            // 
            // Edit
            // 
            this.Edit.Id = -1;
            this.Edit.Name = "Edit";
            // 
            // Del
            // 
            this.Del.Id = -1;
            this.Del.Name = "Del";
            // 
            // Rev
            // 
            this.Rev.Id = -1;
            this.Rev.Name = "Rev";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Id = -1;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Id = -1;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // Dictionary
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new Size(1080, 629);
            this.Name = "Dictionary";
            this.Load += new EventHandler(this.Dictionary_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grpCategory)).EndInit();
            this.grpCategory.ResumeLayout(false);
            ((ISupportInitialize)(this.treCategory)).EndInit();
            ((ISupportInitialize)(this.grdData)).EndInit();
            ((ISupportInitialize)(this.gdvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private TreeList treCategory;
        private GridControl grdData;
        private GridView gdvData;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarButtonItem btnAdd;
        private BarButtonItem Edit;
        private BarButtonItem Del;
        private BarButtonItem Rev;
        private BarButtonItem barButtonItem5;
        private BarButtonItem barButtonItem6;
        private GroupControl grpCategory;
    }
}
