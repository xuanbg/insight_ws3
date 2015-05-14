using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    partial class EditTemplet
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTemplet));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labCategory = new DevExpress.XtraEditors.LabelControl();
            this.trlCategory = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treCategory = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.trlCategory);
            this.panel.Controls.Add(this.labCategory);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.labRemark);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.txtName);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
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
            // labRemark
            // 
            this.labRemark.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labRemark.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labRemark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labRemark.Location = new System.Drawing.Point(5, 80);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(60, 21);
            this.labRemark.TabIndex = 63;
            this.labRemark.Text = "备注：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(5, 50);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(65, 80);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入备注信息…";
            this.memDescription.Size = new System.Drawing.Size(285, 50);
            this.memDescription.TabIndex = 3;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(65, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(285, 20);
            this.txtName.TabIndex = 2;
            // 
            // labCategory
            // 
            this.labCategory.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCategory.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCategory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCategory.Location = new System.Drawing.Point(5, 20);
            this.labCategory.Name = "labCategory";
            this.labCategory.Size = new System.Drawing.Size(60, 21);
            this.labCategory.TabIndex = 0;
            this.labCategory.Text = "分类：";
            // 
            // trlCategory
            // 
            this.trlCategory.EnterMoveNextControl = true;
            this.trlCategory.Location = new System.Drawing.Point(65, 20);
            this.trlCategory.Name = "trlCategory";
            this.trlCategory.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.trlCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("trlCategory.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlCategory.Properties.NullText = "请选择报表分类…";
            this.trlCategory.Properties.PopupFormSize = new System.Drawing.Size(285, 200);
            this.trlCategory.Properties.TreeList = this.treCategory;
            this.trlCategory.Size = new System.Drawing.Size(285, 22);
            this.trlCategory.TabIndex = 1;
            // 
            // treCategory
            // 
            this.treCategory.Location = new System.Drawing.Point(56, 21);
            this.treCategory.Name = "treCategory";
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new System.Drawing.Size(280, 200);
            this.treCategory.TabIndex = 0;
            // 
            // EditTemplet
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "EditTemplet";
            this.Text = "编辑模板";
            this.Load += new System.EventHandler(this.EditTemplet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl labName;
        private LabelControl labRemark;
        private MemoEdit memDescription;
        private TextEdit txtName;
        private LabelControl labCategory;
        private TreeListLookUpEdit trlCategory;
        private TreeList treCategory;

    }
}