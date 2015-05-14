using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Platform.Base
{
    partial class OrgNode
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgNode));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.cmbNodeType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labSimpName = new DevExpress.XtraEditors.LabelControl();
            this.labFullName = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.labCode = new DevExpress.XtraEditors.LabelControl();
            this.labNum = new DevExpress.XtraEditors.LabelControl();
            this.labPosition = new DevExpress.XtraEditors.LabelControl();
            this.labType = new DevExpress.XtraEditors.LabelControl();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.spiIndex = new DevExpress.XtraEditors.SpinEdit();
            this.chkRoot = new DevExpress.XtraEditors.CheckEdit();
            this.lokPosition = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNodeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPosition.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.panel.Controls.Add(this.spiIndex);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.txtFullName);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.lokPosition);
            this.panel.Controls.Add(this.chkRoot);
            this.panel.Controls.Add(this.cmbNodeType);
            this.panel.Controls.Add(this.labNum);
            this.panel.Controls.Add(this.labCode);
            this.panel.Controls.Add(this.labSimpName);
            this.panel.Controls.Add(this.labFullName);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.labPosition);
            this.panel.Controls.Add(this.labType);
            // 
            // cmbNodeType
            // 
            this.cmbNodeType.EnterMoveNextControl = true;
            this.cmbNodeType.Location = new System.Drawing.Point(55, 20);
            this.cmbNodeType.Name = "cmbNodeType";
            this.cmbNodeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNodeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNodeType.ShowToolTips = false;
            this.cmbNodeType.Size = new System.Drawing.Size(70, 20);
            this.cmbNodeType.TabIndex = 1;
            this.cmbNodeType.SelectedValueChanged += new System.EventHandler(this.cmbNodeType_SelectedValueChanged);
            // 
            // labSimpName
            // 
            this.labSimpName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labSimpName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labSimpName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labSimpName.Location = new System.Drawing.Point(5, 110);
            this.labSimpName.Name = "labSimpName";
            this.labSimpName.Size = new System.Drawing.Size(50, 21);
            this.labSimpName.TabIndex = 0;
            this.labSimpName.Text = "简称：";
            // 
            // labFullName
            // 
            this.labFullName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labFullName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labFullName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labFullName.Location = new System.Drawing.Point(5, 80);
            this.labFullName.Name = "labFullName";
            this.labFullName.Size = new System.Drawing.Size(50, 21);
            this.labFullName.TabIndex = 0;
            this.labFullName.Text = "全称：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(5, 50);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(50, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // labCode
            // 
            this.labCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCode.Location = new System.Drawing.Point(125, 110);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(50, 21);
            this.labCode.TabIndex = 0;
            this.labCode.Text = "编码：";
            // 
            // labNum
            // 
            this.labNum.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labNum.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labNum.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labNum.Location = new System.Drawing.Point(255, 110);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(50, 21);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "序号：";
            // 
            // labPosition
            // 
            this.labPosition.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPosition.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPosition.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPosition.Location = new System.Drawing.Point(170, 20);
            this.labPosition.Name = "labPosition";
            this.labPosition.Size = new System.Drawing.Size(50, 21);
            this.labPosition.TabIndex = 0;
            this.labPosition.Text = "岗位：";
            // 
            // labType
            // 
            this.labType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labType.Location = new System.Drawing.Point(5, 20);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(50, 21);
            this.labType.TabIndex = 0;
            this.labType.Text = "类型：";
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new System.Drawing.Point(55, 110);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(70, 20);
            this.txtAlias.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.EnterMoveNextControl = true;
            this.txtFullName.Location = new System.Drawing.Point(55, 80);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 20);
            this.txtFullName.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(55, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(175, 110);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(80, 20);
            this.txtCode.TabIndex = 7;
            // 
            // spiIndex
            // 
            this.spiIndex.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiIndex.EnterMoveNextControl = true;
            this.spiIndex.Location = new System.Drawing.Point(305, 110);
            this.spiIndex.Name = "spiIndex";
            this.spiIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiIndex.Properties.IsFloatValue = false;
            this.spiIndex.Properties.Mask.EditMask = "N00";
            this.spiIndex.Size = new System.Drawing.Size(50, 20);
            this.spiIndex.TabIndex = 8;
            // 
            // chkRoot
            // 
            this.chkRoot.EnterMoveNextControl = true;
            this.chkRoot.Location = new System.Drawing.Point(130, 22);
            this.chkRoot.Name = "chkRoot";
            this.chkRoot.Properties.Caption = "根";
            this.chkRoot.Size = new System.Drawing.Size(30, 15);
            this.chkRoot.TabIndex = 2;
            this.chkRoot.CheckedChanged += new System.EventHandler(this.chkRoot_CheckedChanged);
            // 
            // lokPosition
            // 
            this.lokPosition.EnterMoveNextControl = true;
            this.lokPosition.Location = new System.Drawing.Point(220, 20);
            this.lokPosition.Name = "lokPosition";
            this.lokPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "清除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lokPosition.Properties.NullText = "请选择";
            this.lokPosition.Properties.ShowHeader = false;
            this.lokPosition.Size = new System.Drawing.Size(135, 20);
            this.lokPosition.TabIndex = 3;
            this.lokPosition.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lokPosition_ButtonClick);
            // 
            // OrgNode
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "OrgNode";
            this.Load += new System.EventHandler(this.OrgNode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbNodeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPosition.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxEdit cmbNodeType;
        private LabelControl labSimpName;
        private LabelControl labFullName;
        private LabelControl labName;
        private LabelControl labCode;
        private LabelControl labNum;
        private LabelControl labPosition;
        private LabelControl labType;
        private TextEdit txtAlias;
        private TextEdit txtFullName;
        private TextEdit txtName;
        private TextEdit txtCode;
        private SpinEdit spiIndex;
        private CheckEdit chkRoot;
        private LookUpEdit lokPosition;
    }
}