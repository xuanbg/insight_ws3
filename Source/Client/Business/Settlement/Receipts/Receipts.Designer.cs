using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Business.Settlement
{
    partial class Receipts
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
            this.components = new Container();
            var resources = new ComponentResourceManager(typeof(Receipts));
            this.splMain = new SplitContainerControl();
            this.palTree = new PanelControl();
            this.treDate = new TreeList();
            this.imgDate = new ImageCollection(this.components);
            this.grdReceipts = new GridControl();
            this.gdvReceipts = new GridView();
            this.palSplit = new PanelControl();
            this.palFilter = new PanelControl();
            this.bteSearch = new ButtonEdit();
            this.btnQuery = new SimpleButton();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((ISupportInitialize)(this.palTree)).BeginInit();
            this.palTree.SuspendLayout();
            ((ISupportInitialize)(this.treDate)).BeginInit();
            ((ISupportInitialize)(this.imgDate)).BeginInit();
            ((ISupportInitialize)(this.grdReceipts)).BeginInit();
            ((ISupportInitialize)(this.gdvReceipts)).BeginInit();
            ((ISupportInitialize)(this.palSplit)).BeginInit();
            ((ISupportInitialize)(this.palFilter)).BeginInit();
            this.palFilter.SuspendLayout();
            ((ISupportInitialize)(this.bteSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.splMain.Location = new Point(5, 5);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Controls.Add(this.palTree);
            this.splMain.Panel1.MinSize = 120;
            this.splMain.Panel2.Controls.Add(this.grdReceipts);
            this.splMain.Panel2.Controls.Add(this.palSplit);
            this.splMain.Panel2.Controls.Add(this.palFilter);
            this.splMain.Panel2.MinSize = 800;
            this.splMain.Size = new Size(1070, 590);
            this.splMain.SplitterPosition = 160;
            this.splMain.TabIndex = 0;
            this.splMain.Text = "splitContainerControl1";
            // 
            // palTree
            // 
            this.palTree.Controls.Add(this.treDate);
            this.palTree.Dock = DockStyle.Fill;
            this.palTree.Location = new Point(0, 0);
            this.palTree.Name = "palTree";
            this.palTree.Size = new Size(160, 590);
            this.palTree.TabIndex = 0;
            // 
            // treDate
            // 
            this.treDate.BorderStyle = BorderStyles.NoBorder;
            this.treDate.Dock = DockStyle.Fill;
            this.treDate.Location = new Point(2, 2);
            this.treDate.Name = "treDate";
            this.treDate.SelectImageList = this.imgDate;
            this.treDate.Size = new Size(156, 586);
            this.treDate.TabIndex = 1;
            this.treDate.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treIndex_FocusedNodeChanged);
            // 
            // imgDate
            // 
            this.imgDate.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgDate.ImageStream")));
            this.imgDate.InsertGalleryImage("calendar_16x16.png", "images/scheduling/calendar_16x16.png", ImageResourceCache.Default.GetImage("images/scheduling/calendar_16x16.png"), 0);
            this.imgDate.Images.SetKeyName(0, "calendar_16x16.png");
            this.imgDate.InsertGalleryImage("calendar_16x16.png", "images/scheduling/calendar_16x16.png", ImageResourceCache.Default.GetImage("images/scheduling/calendar_16x16.png"), 1);
            this.imgDate.Images.SetKeyName(1, "calendar_16x16.png");
            this.imgDate.InsertGalleryImage("today_16x16.png", "images/scheduling/today_16x16.png", ImageResourceCache.Default.GetImage("images/scheduling/today_16x16.png"), 2);
            this.imgDate.Images.SetKeyName(2, "today_16x16.png");
            // 
            // grdReceipts
            // 
            this.grdReceipts.Dock = DockStyle.Fill;
            this.grdReceipts.Location = new Point(0, 45);
            this.grdReceipts.MainView = this.gdvReceipts;
            this.grdReceipts.Name = "grdReceipts";
            this.grdReceipts.Size = new Size(905, 545);
            this.grdReceipts.TabIndex = 2;
            this.grdReceipts.ViewCollection.AddRange(new BaseView[] {
            this.gdvReceipts});
            // 
            // gdvReceipts
            // 
            this.gdvReceipts.GridControl = this.grdReceipts;
            this.gdvReceipts.Name = "gdvReceipts";
            this.gdvReceipts.FocusedRowObjectChanged += new FocusedRowObjectChangedEventHandler(this.gdvReceipts_FocusedRowObjectChanged);
            this.gdvReceipts.DoubleClick += new EventHandler(this.gdvReceipts_DoubleClick);
            // 
            // palSplit
            // 
            this.palSplit.BorderStyle = BorderStyles.NoBorder;
            this.palSplit.Dock = DockStyle.Top;
            this.palSplit.Location = new Point(0, 40);
            this.palSplit.Name = "palSplit";
            this.palSplit.Size = new Size(905, 5);
            this.palSplit.TabIndex = 3;
            // 
            // palFilter
            // 
            this.palFilter.Controls.Add(this.bteSearch);
            this.palFilter.Controls.Add(this.btnQuery);
            this.palFilter.Dock = DockStyle.Top;
            this.palFilter.Location = new Point(0, 0);
            this.palFilter.Name = "palFilter";
            this.palFilter.Size = new Size(905, 40);
            this.palFilter.TabIndex = 0;
            // 
            // bteSearch
            // 
            this.bteSearch.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.bteSearch.Location = new Point(10, 10);
            this.bteSearch.Name = "bteSearch";
            this.bteSearch.Properties.AutoHeight = false;
            this.bteSearch.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Delete)});
            this.bteSearch.Properties.NullText = "在此输入结算单位名称进行查询…";
            this.bteSearch.Size = new Size(808, 21);
            this.bteSearch.TabIndex = 3;
            this.bteSearch.ButtonClick += new ButtonPressedEventHandler(this.bteSearch_ButtonClick);
            this.bteSearch.KeyDown += new KeyEventHandler(this.bteSearch_KeyDown);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnQuery.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new Point(826, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new Size(70, 22);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查  询";
            this.btnQuery.Click += new EventHandler(this.btnQuery_Click);
            // 
            // Receipts
            // 
            this.ClientSize = new Size(1080, 629);
            this.Name = "Receipts";
            this.Load += new EventHandler(this.Receipts_Load);
            this.Shown += new EventHandler(this.Receipts_Shown);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((ISupportInitialize)(this.palTree)).EndInit();
            this.palTree.ResumeLayout(false);
            ((ISupportInitialize)(this.treDate)).EndInit();
            ((ISupportInitialize)(this.imgDate)).EndInit();
            ((ISupportInitialize)(this.grdReceipts)).EndInit();
            ((ISupportInitialize)(this.gdvReceipts)).EndInit();
            ((ISupportInitialize)(this.palSplit)).EndInit();
            ((ISupportInitialize)(this.palFilter)).EndInit();
            this.palFilter.ResumeLayout(false);
            ((ISupportInitialize)(this.bteSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splMain;
        private PanelControl palTree;
        private TreeList treDate;
        private GridControl grdReceipts;
        private GridView gdvReceipts;
        private PanelControl palFilter;
        private ButtonEdit bteSearch;
        private SimpleButton btnQuery;
        private ImageCollection imgDate;
        private PanelControl palSplit;
    }
}
