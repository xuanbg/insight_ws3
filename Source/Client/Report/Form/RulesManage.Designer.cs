using System.ComponentModel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Platform.Report
{
    partial class RulesManage
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesManage));
            this.grdRule = new DevExpress.XtraGrid.GridControl();
            this.gdvRule = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            this.xtraScrollable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRule)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollable
            // 
            this.xtraScrollable.Controls.Add(this.grdRule);
            // 
            // grdRule
            // 
            this.grdRule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRule.Location = new System.Drawing.Point(5, 5);
            this.grdRule.MainView = this.gdvRule;
            this.grdRule.Name = "grdRule";
            this.grdRule.Size = new System.Drawing.Size(1070, 590);
            this.grdRule.TabIndex = 0;
            this.grdRule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvRule});
            // 
            // gdvRule
            // 
            this.gdvRule.GridControl = this.grdRule;
            this.gdvRule.Name = "gdvRule";
            this.gdvRule.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gdvRule_FocusedRowObjectChanged);
            this.gdvRule.DoubleClick += new System.EventHandler(this.gdvRule_DoubleClick);
            // 
            // RulesManage
            // 
            this.ClientSize = new System.Drawing.Size(1080, 629);
            this.Name = "RulesManage";
            this.Load += new System.EventHandler(this.RulesManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            this.xtraScrollable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvRule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdRule;
        private GridView gdvRule;
    }
}