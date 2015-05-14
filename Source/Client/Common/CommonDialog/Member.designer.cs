using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Common
{
    partial class Member
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Member));
            this.grdSelect = new DevExpress.XtraGrid.GridControl();
            this.gdvSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYSUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYSUserBindingSource)).BeginInit();
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
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(290, 424);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(200, 424);
            // 
            // panel
            // 
            this.panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel.Controls.Add(this.grdSelect);
            this.panel.Size = new System.Drawing.Size(370, 400);
            // 
            // grdSelect
            // 
            this.grdSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSelect.Location = new System.Drawing.Point(0, 0);
            this.grdSelect.MainView = this.gdvSelect;
            this.grdSelect.Name = "grdSelect";
            this.grdSelect.Size = new System.Drawing.Size(370, 400);
            this.grdSelect.TabIndex = 1;
            this.grdSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSelect});
            // 
            // gdvSelect
            // 
            this.gdvSelect.GridControl = this.grdSelect;
            this.gdvSelect.GroupRowHeight = 25;
            this.gdvSelect.Name = "gdvSelect";
            this.gdvSelect.OptionsFind.AlwaysVisible = true;
            this.gdvSelect.OptionsFind.FindDelay = 100;
            this.gdvSelect.OptionsFind.FindNullPrompt = "输入关键字进行查询...";
            this.gdvSelect.OptionsFind.HighlightFindResults = false;
            this.gdvSelect.OptionsSelection.MultiSelect = true;
            this.gdvSelect.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // dataTableBindingSource
            // 
            this.dataTableBindingSource.DataSource = typeof(System.Data.DataTable);
            // 
            // sYSUserBindingSource
            // 
            this.sYSUserBindingSource.DataSource = typeof(Insight.WS.Client.Common.Service.SYS_User);
            // 
            // Member
            // 
            this.ClientSize = new System.Drawing.Size(384, 462);
            this.Name = "Member";
            this.Text = "成员对话框";
            this.Load += new System.EventHandler(this.Member_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYSUserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdSelect;
        private GridView gdvSelect;
        private BindingSource dataTableBindingSource;
        private BindingSource sYSUserBindingSource;



    }
}