namespace Insight.WS.Client.XinFenBao
{
    partial class AdvEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvEdit));
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labIndex = new DevExpress.XtraEditors.LabelControl();
            this.labCode = new DevExpress.XtraEditors.LabelControl();
            this.labImage = new DevExpress.XtraEditors.LabelControl();
            this.spiIndex = new DevExpress.XtraEditors.SpinEdit();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtImage = new DevExpress.XtraEditors.TextEdit();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.labTarget = new DevExpress.XtraEditors.LabelControl();
            this.txtTarget = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarget.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnUpload);
            this.panel.Controls.Add(this.spiIndex);
            this.panel.Controls.Add(this.txtImage);
            this.panel.Controls.Add(this.txtTarget);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.labTarget);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.labImage);
            this.panel.Controls.Add(this.labCode);
            this.panel.Controls.Add(this.labIndex);
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
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(220, 114);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.AutoHeight = false;
            this.txtCode.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtCode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCode.Size = new System.Drawing.Size(140, 22);
            this.txtCode.TabIndex = 5;
            this.txtCode.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtCode_ParseEditValue);
            // 
            // labIndex
            // 
            this.labIndex.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labIndex.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labIndex.Location = new System.Drawing.Point(0, 115);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(80, 21);
            this.labIndex.TabIndex = 0;
            this.labIndex.Text = "播放次序：";
            // 
            // labCode
            // 
            this.labCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCode.Location = new System.Drawing.Point(140, 115);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(80, 21);
            this.labCode.TabIndex = 0;
            this.labCode.Text = "商品编号：";
            // 
            // labImage
            // 
            this.labImage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labImage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labImage.Location = new System.Drawing.Point(0, 80);
            this.labImage.Name = "labImage";
            this.labImage.Size = new System.Drawing.Size(80, 21);
            this.labImage.TabIndex = 0;
            this.labImage.Text = "图片：";
            // 
            // spiIndex
            // 
            this.spiIndex.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spiIndex.Location = new System.Drawing.Point(80, 115);
            this.spiIndex.Name = "spiIndex";
            this.spiIndex.Properties.Appearance.Options.UseTextOptions = true;
            this.spiIndex.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spiIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiIndex.Properties.IsFloatValue = false;
            this.spiIndex.Properties.Mask.EditMask = "N00";
            this.spiIndex.Size = new System.Drawing.Size(60, 20);
            this.spiIndex.TabIndex = 4;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 15);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(80, 15);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtName.Size = new System.Drawing.Size(280, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtImage
            // 
            this.txtImage.Enabled = false;
            this.txtImage.EnterMoveNextControl = true;
            this.txtImage.Location = new System.Drawing.Point(80, 80);
            this.txtImage.Name = "txtImage";
            this.txtImage.Properties.AutoHeight = false;
            this.txtImage.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtImage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImage.Size = new System.Drawing.Size(215, 22);
            this.txtImage.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(300, 80);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(60, 22);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "选择";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // labTarget
            // 
            this.labTarget.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTarget.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTarget.Location = new System.Drawing.Point(0, 45);
            this.labTarget.Name = "labTarget";
            this.labTarget.Size = new System.Drawing.Size(80, 21);
            this.labTarget.TabIndex = 0;
            this.labTarget.Text = "跳转地址：";
            // 
            // txtTarget
            // 
            this.txtTarget.EnterMoveNextControl = true;
            this.txtTarget.Location = new System.Drawing.Point(80, 45);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Properties.AutoHeight = false;
            this.txtTarget.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtTarget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTarget.Size = new System.Drawing.Size(280, 22);
            this.txtTarget.TabIndex = 2;
            this.txtTarget.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtTarget_ParseEditValue);
            // 
            // AdvEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "AdvEdit";
            this.Text = "轮播";
            this.Load += new System.EventHandler(this.AdvEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarget.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labCode;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labIndex;
        private DevExpress.XtraEditors.LabelControl labImage;
        private DevExpress.XtraEditors.SpinEdit spiIndex;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labName;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.TextEdit txtImage;
        private DevExpress.XtraEditors.TextEdit txtTarget;
        private DevExpress.XtraEditors.LabelControl labTarget;
    }
}