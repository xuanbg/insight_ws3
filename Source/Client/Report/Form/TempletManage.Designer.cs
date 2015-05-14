using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using FastReport;

namespace Insight.WS.Client.Platform.Report
{
    partial class TemplateManage
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateManage));
            var designerSettings1 = new FastReport.Design.DesignerSettings();
            var designerRestrictions1 = new FastReport.Design.DesignerRestrictions();
            var emailSettings1 = new FastReport.Export.Email.EmailSettings();
            var previewSettings1 = new FastReport.PreviewSettings();
            var reportSettings1 = new FastReport.ReportSettings();
            this.treCategory = new DevExpress.XtraTreeList.TreeList();
            this.grpMould = new DevExpress.XtraEditors.GroupControl();
            this.grdTemplet = new DevExpress.XtraGrid.GridControl();
            this.gdvTemplet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpTree = new DevExpress.XtraEditors.GroupControl();
            this.frSettings = new FastReport.EnvironmentSettings();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMould)).BeginInit();
            this.grpMould.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemplet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTemplet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).BeginInit();
            this.grpTree.SuspendLayout();
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
            // treCategory
            // 
            this.treCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treCategory.Location = new System.Drawing.Point(2, 22);
            this.treCategory.Name = "treCategory";
            this.treCategory.OptionsView.ShowColumns = false;
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new System.Drawing.Size(196, 566);
            this.treCategory.TabIndex = 1;
            // 
            // grpMould
            // 
            this.grpMould.Controls.Add(this.grdTemplet);
            this.grpMould.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMould.Location = new System.Drawing.Point(0, 0);
            this.grpMould.Name = "grpMould";
            this.grpMould.Size = new System.Drawing.Size(865, 590);
            this.grpMould.TabIndex = 0;
            this.grpMould.Text = "模板列表";
            // 
            // grdTemplet
            // 
            this.grdTemplet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTemplet.Location = new System.Drawing.Point(2, 22);
            this.grdTemplet.MainView = this.gdvTemplet;
            this.grdTemplet.Name = "grdTemplet";
            this.grdTemplet.Size = new System.Drawing.Size(861, 566);
            this.grdTemplet.TabIndex = 2;
            this.grdTemplet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvTemplet});
            // 
            // gdvTemplet
            // 
            this.gdvTemplet.GridControl = this.grdTemplet;
            this.gdvTemplet.Name = "gdvTemplet";
            this.gdvTemplet.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvTemplet_FocusedRowObjectChanged);
            this.gdvTemplet.DoubleClick += new System.EventHandler(this.gdvTemplet_DoubleClick);
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
            this.splMain.Panel2.Controls.Add(this.grpMould);
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
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new System.Drawing.Size(200, 590);
            this.grpTree.TabIndex = 0;
            this.grpTree.Text = "模板分类";
            // 
            // frSettings
            // 
            designerSettings1.ApplicationConnection = null;
            designerSettings1.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("designerSettings1.Icon")));
            designerSettings1.Restrictions = designerRestrictions1;
            designerSettings1.Text = "";
            this.frSettings.DesignerSettings = designerSettings1;
            emailSettings1.Address = "";
            emailSettings1.Host = "";
            emailSettings1.MessageTemplate = "";
            emailSettings1.Name = "";
            emailSettings1.Password = "";
            emailSettings1.UserName = "";
            this.frSettings.EmailSettings = emailSettings1;
            previewSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings1.Icon")));
            previewSettings1.Text = "";
            this.frSettings.PreviewSettings = previewSettings1;
            this.frSettings.ReportSettings = reportSettings1;
            this.frSettings.UIStyle = FastReport.Utils.UIStyle.Office2007Silver;
            this.frSettings.CustomSaveReport += new FastReport.Design.OpenSaveReportEventHandler(this.CustomSaveReport);
            // 
            // TemplateManage
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "TemplateManage";
            this.Text = "模板管理";
            this.Load += new System.EventHandler(this.TemplateManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMould)).EndInit();
            this.grpMould.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTemplet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTemplet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTree)).EndInit();
            this.grpTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdTemplet;
        private GridView gdvTemplet;
        private TreeList treCategory;
        private GroupControl grpMould;
        private SplitContainerControl splMain;
        private GroupControl grpTree;
        private EnvironmentSettings frSettings;

    }
}