using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Platform.Base
{
    partial class CodeScheme
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeScheme));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.labFormat = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labMark = new DevExpress.XtraEditors.LabelControl();
            this.txtMark = new DevExpress.XtraEditors.TextEdit();
            this.txtFormat = new DevExpress.XtraEditors.TextEdit();
            this.labPreview = new DevExpress.XtraEditors.LabelControl();
            this.labmemo = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.bntPreview = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntPreview.Properties)).BeginInit();
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
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.txtFormat);
            this.panel.Controls.Add(this.txtMark);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.labMark);
            this.panel.Controls.Add(this.labmemo);
            this.panel.Controls.Add(this.labPreview);
            this.panel.Controls.Add(this.labFormat);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.bntPreview);
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 10);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "方案名称：";
            // 
            // labFormat
            // 
            this.labFormat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labFormat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labFormat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labFormat.Location = new System.Drawing.Point(0, 40);
            this.labFormat.Name = "labFormat";
            this.labFormat.Size = new System.Drawing.Size(80, 21);
            this.labFormat.TabIndex = 0;
            this.labFormat.Text = "编码格式：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 20);
            this.txtName.TabIndex = 1;
            // 
            // labMark
            // 
            this.labMark.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMark.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMark.Location = new System.Drawing.Point(200, 40);
            this.labMark.Name = "labMark";
            this.labMark.Size = new System.Drawing.Size(80, 21);
            this.labMark.TabIndex = 0;
            this.labMark.Text = "分组规则：";
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(280, 40);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(70, 20);
            this.txtMark.TabIndex = 3;
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(80, 40);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(120, 20);
            this.txtFormat.TabIndex = 2;
            // 
            // labPreview
            // 
            this.labPreview.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPreview.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPreview.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPreview.Location = new System.Drawing.Point(0, 70);
            this.labPreview.Name = "labPreview";
            this.labPreview.Size = new System.Drawing.Size(80, 21);
            this.labPreview.TabIndex = 0;
            this.labPreview.Text = "预览：";
            // 
            // labmemo
            // 
            this.labmemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labmemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labmemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labmemo.Location = new System.Drawing.Point(0, 100);
            this.labmemo.Name = "labmemo";
            this.labmemo.Size = new System.Drawing.Size(80, 21);
            this.labmemo.TabIndex = 0;
            this.labmemo.Text = "描述：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 100);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(270, 40);
            this.memDescription.TabIndex = 5;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // bntPreview
            // 
            this.bntPreview.Location = new System.Drawing.Point(80, 70);
            this.bntPreview.Name = "bntPreview";
            this.bntPreview.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtPreview.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.bntPreview.Properties.NullText = "请点击预览按钮…";
            this.bntPreview.Properties.ReadOnly = true;
            this.bntPreview.Size = new System.Drawing.Size(270, 22);
            this.bntPreview.TabIndex = 4;
            this.bntPreview.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bntPreview_ButtonClick);
            // 
            // CodeScheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "CodeScheme";
            this.Text = "CodeScheme";
            this.Load += new System.EventHandler(this.CodeScheme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntPreview.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl labFormat;
        private LabelControl labName;
        private TextEdit txtMark;
        private TextEdit txtName;
        private LabelControl labMark;
        private MemoEdit memDescription;
        private TextEdit txtFormat;
        private LabelControl labmemo;
        private LabelControl labPreview;
        private ButtonEdit bntPreview;
    }
}