using System.ComponentModel;

namespace Insight.WS.Client.Common
{
    partial class Category
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Category));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labParent = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            this.trlParent = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treParent = new DevExpress.XtraTreeList.TreeList();
            this.labIndex = new DevExpress.XtraEditors.LabelControl();
            this.spiIndex = new DevExpress.XtraEditors.SpinEdit();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labAlias = new DevExpress.XtraEditors.LabelControl();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.labCode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.chkRoot = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoot.Properties)).BeginInit();
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
            this.btnConfirm.Location = new System.Drawing.Point(290, 224);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(200, 224);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.chkRoot);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.spiIndex);
            this.panel.Controls.Add(this.trlParent);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.labCode);
            this.panel.Controls.Add(this.labIndex);
            this.panel.Controls.Add(this.labAlias);
            this.panel.Controls.Add(this.labMemo);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.labParent);
            this.panel.Size = new System.Drawing.Size(370, 200);
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(80, 55);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 20);
            this.txtName.TabIndex = 1;
            // 
            // labParent
            // 
            this.labParent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labParent.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labParent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labParent.Location = new System.Drawing.Point(0, 20);
            this.labParent.Name = "labParent";
            this.labParent.Size = new System.Drawing.Size(80, 21);
            this.labParent.TabIndex = 0;
            this.labParent.Text = "父分类：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 55);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "分类名称：";
            // 
            // labMemo
            // 
            this.labMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMemo.Location = new System.Drawing.Point(0, 120);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(80, 21);
            this.labMemo.TabIndex = 0;
            this.labMemo.Text = "备注：";
            // 
            // tleParent
            // 
            this.trlParent.Location = new System.Drawing.Point(80, 20);
            this.trlParent.Name = "tleParent";
            this.trlParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("tleParent.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlParent.Properties.NullText = "";
            this.trlParent.Properties.PopupFormSize = new System.Drawing.Size(230, 200);
            this.trlParent.Properties.TreeList = this.treParent;
            this.trlParent.Size = new System.Drawing.Size(230, 22);
            this.trlParent.TabIndex = 4;
            this.trlParent.EditValueChanged += new System.EventHandler(this.tleParent_EditValueChanged);
            // 
            // treParent
            // 
            this.treParent.Location = new System.Drawing.Point(0, 0);
            this.treParent.Name = "treParent";
            this.treParent.OptionsBehavior.EnableFiltering = true;
            this.treParent.OptionsView.ShowIndentAsRowStyle = true;
            this.treParent.SelectImageList = this.imgFolderNode;
            this.treParent.Size = new System.Drawing.Size(400, 200);
            this.treParent.TabIndex = 0;
            // 
            // labIndex
            // 
            this.labIndex.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labIndex.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labIndex.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labIndex.Location = new System.Drawing.Point(220, 55);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(60, 21);
            this.labIndex.TabIndex = 0;
            this.labIndex.Text = "序号：";
            // 
            // spiIndex
            // 
            this.spiIndex.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiIndex.Location = new System.Drawing.Point(280, 55);
            this.spiIndex.Name = "spiIndex";
            this.spiIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiIndex.Properties.IsFloatValue = false;
            this.spiIndex.Properties.Mask.EditMask = "N00";
            this.spiIndex.Size = new System.Drawing.Size(70, 20);
            this.spiIndex.TabIndex = 6;
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 120);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入备注信息…";
            this.memDescription.Size = new System.Drawing.Size(270, 60);
            this.memDescription.TabIndex = 7;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // labAlias
            // 
            this.labAlias.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAlias.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labAlias.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAlias.Location = new System.Drawing.Point(0, 85);
            this.labAlias.Name = "labAlias";
            this.labAlias.Size = new System.Drawing.Size(80, 21);
            this.labAlias.TabIndex = 0;
            this.labAlias.Text = "简称：";
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new System.Drawing.Point(80, 85);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(140, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // labCode
            // 
            this.labCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCode.Location = new System.Drawing.Point(220, 85);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(60, 21);
            this.labCode.TabIndex = 0;
            this.labCode.Text = "编码：";
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(280, 85);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(70, 20);
            this.txtCode.TabIndex = 3;
            // 
            // chkRoot
            // 
            this.chkRoot.Location = new System.Drawing.Point(320, 24);
            this.chkRoot.Name = "chkRoot";
            this.chkRoot.Properties.Caption = "根";
            this.chkRoot.Size = new System.Drawing.Size(30, 15);
            this.chkRoot.TabIndex = 5;
            this.chkRoot.CheckedChanged += new System.EventHandler(this.chkRoot_CheckedChanged);
            // 
            // Category
            // 
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Name = "Category";
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoot.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.TreeListLookUpEdit trlParent;
        private DevExpress.XtraEditors.CheckEdit chkRoot;
        private DevExpress.XtraTreeList.TreeList treParent;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SpinEdit spiIndex;
        private DevExpress.XtraEditors.TextEdit txtAlias;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.MemoEdit memDescription;
        private DevExpress.XtraEditors.LabelControl labParent;
        private DevExpress.XtraEditors.LabelControl labName;
        private DevExpress.XtraEditors.LabelControl labIndex;
        private DevExpress.XtraEditors.LabelControl labAlias;
        private DevExpress.XtraEditors.LabelControl labCode;
        private DevExpress.XtraEditors.LabelControl labMemo;

        #endregion

    }
}