namespace Insight.WS.Client.Common.Dialog
{
    partial class PrintSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSet));
            this.cbxTagPrint = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxBilPrint = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxDocPrint = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labDocPrint = new DevExpress.XtraEditors.LabelControl();
            this.labelTagPrint = new DevExpress.XtraEditors.LabelControl();
            this.labBillPrint = new DevExpress.XtraEditors.LabelControl();
            this.chkMergerPrint = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTagPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxBilPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDocPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMergerPrint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.chkMergerPrint);
            this.panel.Controls.Add(this.cbxTagPrint);
            this.panel.Controls.Add(this.cbxBilPrint);
            this.panel.Controls.Add(this.cbxDocPrint);
            this.panel.Controls.Add(this.labDocPrint);
            this.panel.Controls.Add(this.labelTagPrint);
            this.panel.Controls.Add(this.labBillPrint);
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
            // cbxTagPrint
            // 
            this.cbxTagPrint.Location = new System.Drawing.Point(105, 55);
            this.cbxTagPrint.Name = "cbxTagPrint";
            this.cbxTagPrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxTagPrint.Properties.NullText = "请选择默认标签打印机";
            this.cbxTagPrint.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxTagPrint.Size = new System.Drawing.Size(240, 20);
            this.cbxTagPrint.TabIndex = 2;
            this.cbxTagPrint.Tag = "";
            // 
            // cbxBilPrint
            // 
            this.cbxBilPrint.Location = new System.Drawing.Point(105, 90);
            this.cbxBilPrint.Name = "cbxBilPrint";
            this.cbxBilPrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxBilPrint.Properties.NullText = "请选择默认票据打印机";
            this.cbxBilPrint.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxBilPrint.Size = new System.Drawing.Size(240, 20);
            this.cbxBilPrint.TabIndex = 3;
            this.cbxBilPrint.Tag = "";
            // 
            // cbxDocPrint
            // 
            this.cbxDocPrint.Location = new System.Drawing.Point(105, 20);
            this.cbxDocPrint.Name = "cbxDocPrint";
            this.cbxDocPrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxDocPrint.Properties.NullText = "请选择默认文档打印机";
            this.cbxDocPrint.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxDocPrint.Size = new System.Drawing.Size(240, 20);
            this.cbxDocPrint.TabIndex = 1;
            this.cbxDocPrint.Tag = "";
            // 
            // labDocPrint
            // 
            this.labDocPrint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDocPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDocPrint.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDocPrint.Location = new System.Drawing.Point(25, 20);
            this.labDocPrint.Name = "labDocPrint";
            this.labDocPrint.Size = new System.Drawing.Size(80, 21);
            this.labDocPrint.TabIndex = 5;
            this.labDocPrint.Text = "文档打印机：";
            // 
            // labelTagPrint
            // 
            this.labelTagPrint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelTagPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelTagPrint.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelTagPrint.Location = new System.Drawing.Point(25, 55);
            this.labelTagPrint.Name = "labelTagPrint";
            this.labelTagPrint.Size = new System.Drawing.Size(80, 21);
            this.labelTagPrint.TabIndex = 0;
            this.labelTagPrint.Text = "标签打印机：";
            // 
            // labBillPrint
            // 
            this.labBillPrint.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labBillPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labBillPrint.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labBillPrint.Location = new System.Drawing.Point(25, 90);
            this.labBillPrint.Name = "labBillPrint";
            this.labBillPrint.Size = new System.Drawing.Size(80, 21);
            this.labBillPrint.TabIndex = 0;
            this.labBillPrint.Text = "票据打印机：";
            // 
            // chkMergerPrint
            // 
            this.chkMergerPrint.Location = new System.Drawing.Point(105, 115);
            this.chkMergerPrint.Name = "chkMergerPrint";
            this.chkMergerPrint.Properties.AutoHeight = false;
            this.chkMergerPrint.Properties.Caption = "合并打印三联票据";
            this.chkMergerPrint.Size = new System.Drawing.Size(240, 20);
            this.chkMergerPrint.TabIndex = 4;
            // 
            // PrintSet
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "PrintSet";
            this.Text = "打印机设置";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxTagPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxBilPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDocPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMergerPrint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbxTagPrint;
        private DevExpress.XtraEditors.ComboBoxEdit cbxBilPrint;
        private DevExpress.XtraEditors.ComboBoxEdit cbxDocPrint;
        private DevExpress.XtraEditors.LabelControl labDocPrint;
        private DevExpress.XtraEditors.LabelControl labelTagPrint;
        private DevExpress.XtraEditors.LabelControl labBillPrint;
        private DevExpress.XtraEditors.CheckEdit chkMergerPrint;

    }
}