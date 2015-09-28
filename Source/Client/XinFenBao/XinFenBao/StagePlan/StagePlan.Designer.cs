namespace Insight.WS.Client.XinFenBao
{
    partial class StagePlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StagePlan));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtStageNum = new DevExpress.XtraEditors.TextEdit();
            this.labStageNum = new DevExpress.XtraEditors.LabelControl();
            this.labRate = new DevExpress.XtraEditors.LabelControl();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.labP = new DevExpress.XtraEditors.LabelControl();
            this.labEffective = new DevExpress.XtraEditors.LabelControl();
            this.datEffective = new DevExpress.XtraEditors.DateEdit();
            this.labUserType = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labDescription = new DevExpress.XtraEditors.LabelControl();
            this.cbxUserType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEffective.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEffective.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxUserType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cbxUserType);
            this.panel.Controls.Add(this.txtRate);
            this.panel.Controls.Add(this.txtStageNum);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.datEffective);
            this.panel.Controls.Add(this.labP);
            this.panel.Controls.Add(this.labRate);
            this.panel.Controls.Add(this.labUserType);
            this.panel.Controls.Add(this.labEffective);
            this.panel.Controls.Add(this.labStageNum);
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
            // txtStageNum
            // 
            this.txtStageNum.EnterMoveNextControl = true;
            this.txtStageNum.Location = new System.Drawing.Point(260, 20);
            this.txtStageNum.Name = "txtStageNum";
            this.txtStageNum.Properties.Appearance.Options.UseTextOptions = true;
            this.txtStageNum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtStageNum.Properties.AutoHeight = false;
            this.txtStageNum.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtStageNum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtStageNum.Size = new System.Drawing.Size(100, 21);
            this.txtStageNum.TabIndex = 2;
            this.txtStageNum.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.txtStageNum_ParseEditValue);
            // 
            // labStageNum
            // 
            this.labStageNum.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labStageNum.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labStageNum.Location = new System.Drawing.Point(180, 20);
            this.labStageNum.Name = "labStageNum";
            this.labStageNum.Size = new System.Drawing.Size(80, 21);
            this.labStageNum.TabIndex = 0;
            this.labStageNum.Text = "分期数：";
            // 
            // labRate
            // 
            this.labRate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labRate.Location = new System.Drawing.Point(180, 50);
            this.labRate.Name = "labRate";
            this.labRate.Size = new System.Drawing.Size(80, 21);
            this.labRate.TabIndex = 0;
            this.labRate.Text = "费率：";
            // 
            // txtRate
            // 
            this.txtRate.EditValue = "1.8";
            this.txtRate.EnterMoveNextControl = true;
            this.txtRate.Location = new System.Drawing.Point(260, 50);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtRate.Properties.AutoHeight = false;
            this.txtRate.Properties.DisplayFormat.FormatString = "#,##0.####";
            this.txtRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRate.Size = new System.Drawing.Size(80, 21);
            this.txtRate.TabIndex = 4;
            // 
            // labP
            // 
            this.labP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labP.Location = new System.Drawing.Point(340, 50);
            this.labP.Name = "labP";
            this.labP.Size = new System.Drawing.Size(20, 21);
            this.labP.TabIndex = 0;
            this.labP.Text = "%";
            // 
            // labEffective
            // 
            this.labEffective.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labEffective.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labEffective.Location = new System.Drawing.Point(0, 50);
            this.labEffective.Name = "labEffective";
            this.labEffective.Size = new System.Drawing.Size(80, 21);
            this.labEffective.TabIndex = 0;
            this.labEffective.Text = "生效日期：";
            // 
            // datEffective
            // 
            this.datEffective.EditValue = null;
            this.datEffective.EnterMoveNextControl = true;
            this.datEffective.Location = new System.Drawing.Point(80, 50);
            this.datEffective.Name = "datEffective";
            this.datEffective.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.datEffective.Properties.AutoHeight = false;
            this.datEffective.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("datEffective.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datEffective.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datEffective.Size = new System.Drawing.Size(100, 21);
            this.datEffective.TabIndex = 3;
            // 
            // labUserType
            // 
            this.labUserType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUserType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUserType.Location = new System.Drawing.Point(0, 20);
            this.labUserType.Name = "labUserType";
            this.labUserType.Size = new System.Drawing.Size(80, 21);
            this.labUserType.TabIndex = 0;
            this.labUserType.Text = "用户类型：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 90);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(280, 50);
            this.memDescription.TabIndex = 5;
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDescription.Location = new System.Drawing.Point(0, 90);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(80, 21);
            this.labDescription.TabIndex = 0;
            this.labDescription.Text = "描述：";
            // 
            // cbxUserType
            // 
            this.cbxUserType.Location = new System.Drawing.Point(80, 20);
            this.cbxUserType.Name = "cbxUserType";
            this.cbxUserType.Properties.AutoHeight = false;
            this.cbxUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxUserType.Size = new System.Drawing.Size(100, 21);
            this.cbxUserType.TabIndex = 1;
            // 
            // StagePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "StagePlan";
            this.Text = "新建分期方案";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStageNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEffective.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEffective.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxUserType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.LabelControl labP;
        private DevExpress.XtraEditors.LabelControl labRate;
        private DevExpress.XtraEditors.TextEdit txtStageNum;
        private DevExpress.XtraEditors.LabelControl labEffective;
        private DevExpress.XtraEditors.LabelControl labStageNum;
        private DevExpress.XtraEditors.DateEdit datEffective;
        private DevExpress.XtraEditors.LabelControl labUserType;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private DevExpress.XtraEditors.LabelControl labDescription;
        private DevExpress.XtraEditors.ComboBoxEdit cbxUserType;
    }
}