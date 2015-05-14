using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.MasterDatas
{
    partial class Material
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
            var resources = new ComponentResourceManager(typeof(Material));
            this.splMain = new SplitContainerControl();
            this.grpTree = new GroupControl();
            this.treCategory = new TreeList();
            this.grdMaterial = new GridControl();
            this.gdvMaterial = new GridView();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.grpTree)).BeginInit();
            this.grpTree.SuspendLayout();
            ((ISupportInitialize)(this.treCategory)).BeginInit();
            ((ISupportInitialize)(this.grdMaterial)).BeginInit();
            ((ISupportInitialize)(this.gdvMaterial)).BeginInit();
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
            this.splMain.Panel1.Controls.Add(this.grpTree);
            this.splMain.Panel1.MinSize = 160;
            this.splMain.Panel2.Controls.Add(this.grdMaterial);
            this.splMain.Panel2.MinSize = 600;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 200;
            this.splMain.TabIndex = 0;
            // 
            // grpTree
            // 
            this.grpTree.Controls.Add(this.treCategory);
            this.grpTree.Dock = DockStyle.Fill;
            this.grpTree.Location = new Point(0, 0);
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new Size(200, 590);
            this.grpTree.TabIndex = 0;
            this.grpTree.Text = "物资分类";
            // 
            // treCategory
            // 
            this.treCategory.Dock = DockStyle.Fill;
            this.treCategory.Location = new Point(2, 22);
            this.treCategory.Name = "treCategory";
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new Size(196, 566);
            this.treCategory.TabIndex = 0;
            this.treCategory.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treCategory_FocusedNodeChanged);
            this.treCategory.DoubleClick += new EventHandler(this.treCategory_DoubleClick);
            // 
            // grdMaterial
            // 
            this.grdMaterial.Dock = DockStyle.Fill;
            this.grdMaterial.Location = new Point(0, 0);
            this.grdMaterial.MainView = this.gdvMaterial;
            this.grdMaterial.Name = "grdMaterial";
            this.grdMaterial.Size = new Size(865, 590);
            this.grdMaterial.TabIndex = 0;
            this.grdMaterial.ViewCollection.AddRange(new BaseView[] {
            this.gdvMaterial});
            // 
            // gdvMaterial
            // 
            this.gdvMaterial.GridControl = this.grdMaterial;
            this.gdvMaterial.Name = "gdvMaterial";
            this.gdvMaterial.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvMaterial_FocusedRowObjectChanged);
            this.gdvMaterial.DoubleClick += new EventHandler(this.gdvMaterial_DoubleClick);
            // 
            // Material
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new Size(1080, 629);
            this.Name = "Material";
            this.Load += new EventHandler(this.Material_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.grpTree)).EndInit();
            this.grpTree.ResumeLayout(false);
            ((ISupportInitialize)(this.treCategory)).EndInit();
            ((ISupportInitialize)(this.grdMaterial)).EndInit();
            ((ISupportInitialize)(this.gdvMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private TreeList treCategory;
        private GridControl grdMaterial;
        private GridView gdvMaterial;
        private GroupControl grpTree;
    }
}
