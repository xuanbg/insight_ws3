using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    partial class EditRule
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRule));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labStartAndEnd = new DevExpress.XtraEditors.LabelControl();
            this.labTime = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.cmbCycleType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            this.spiTimes = new DevExpress.XtraEditors.SpinEdit();
            this.datStart = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCycleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStart.Properties)).BeginInit();
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
            this.panel.Controls.Add(this.datStart);
            this.panel.Controls.Add(this.spiTimes);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.labStartAndEnd);
            this.panel.Controls.Add(this.labMemo);
            this.panel.Controls.Add(this.labTime);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.cmbCycleType);
            this.panel.Controls.Add(this.txtName);
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(65, 80);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入备注信息…";
            this.memDescription.Size = new System.Drawing.Size(285, 50);
            this.memDescription.TabIndex = 5;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // labStartAndEnd
            // 
            this.labStartAndEnd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labStartAndEnd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labStartAndEnd.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labStartAndEnd.Location = new System.Drawing.Point(170, 50);
            this.labStartAndEnd.Name = "labStartAndEnd";
            this.labStartAndEnd.Size = new System.Drawing.Size(80, 21);
            this.labStartAndEnd.TabIndex = 0;
            this.labStartAndEnd.Text = "起始于：";
            // 
            // labTime
            // 
            this.labTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTime.Location = new System.Drawing.Point(5, 50);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(60, 21);
            this.labTime.TabIndex = 0;
            this.labTime.Text = "周期：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(5, 20);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // cmbCycleType
            // 
            this.cmbCycleType.EditValue = "月";
            this.cmbCycleType.EnterMoveNextControl = true;
            this.cmbCycleType.Location = new System.Drawing.Point(130, 50);
            this.cmbCycleType.Name = "cmbCycleType";
            this.cmbCycleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCycleType.Properties.Items.AddRange(new object[] {
            "年",
            "月",
            "周",
            "日"});
            this.cmbCycleType.Size = new System.Drawing.Size(40, 20);
            this.cmbCycleType.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(65, 20);
            this.txtName.Name = "txtName";
            this.txtName.Properties.NullText = "请输入规则名称…";
            this.txtName.Size = new System.Drawing.Size(285, 20);
            this.txtName.TabIndex = 1;
            // 
            // labMemo
            // 
            this.labMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMemo.Location = new System.Drawing.Point(5, 80);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(60, 21);
            this.labMemo.TabIndex = 0;
            this.labMemo.Text = "备注：";
            // 
            // spiTimes
            // 
            this.spiTimes.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiTimes.EnterMoveNextControl = true;
            this.spiTimes.Location = new System.Drawing.Point(65, 50);
            this.spiTimes.Name = "spiTimes";
            this.spiTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiTimes.Properties.IsFloatValue = false;
            this.spiTimes.Properties.Mask.EditMask = "N00";
            this.spiTimes.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.spiTimes.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiTimes.Size = new System.Drawing.Size(60, 20);
            this.spiTimes.TabIndex = 1;
            // 
            // datStart
            // 
            this.datStart.EditValue = null;
            this.datStart.Location = new System.Drawing.Point(250, 50);
            this.datStart.Name = "datStart";
            this.datStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("datStart.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datStart.Size = new System.Drawing.Size(100, 22);
            this.datStart.TabIndex = 4;
            // 
            // EditRule
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "EditRule";
            this.Load += new System.EventHandler(this.EditRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCycleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl labStartAndEnd;
        private LabelControl labTime;
        private LabelControl labName;
        private ComboBoxEdit cmbCycleType;
        private TextEdit txtName;
        private MemoEdit memDescription;
        private LabelControl labMemo;
        private SpinEdit spiTimes;
        private DateEdit datStart;

    }
}