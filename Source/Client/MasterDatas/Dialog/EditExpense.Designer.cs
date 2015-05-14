using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.MasterDatas
{
    partial class EditExpense
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(EditExpense));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.spiIndex = new DevExpress.XtraEditors.SpinEdit();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.trlCategory = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treCategory = new DevExpress.XtraTreeList.TreeList();
            this.labIndex = new DevExpress.XtraEditors.LabelControl();
            this.labPrice = new DevExpress.XtraEditors.LabelControl();
            this.labAlias = new DevExpress.XtraEditors.LabelControl();
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.labCategory = new DevExpress.XtraEditors.LabelControl();
            this.labCode = new DevExpress.XtraEditors.LabelControl();
            this.labUnit = new DevExpress.XtraEditors.LabelControl();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.trlUnit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treUnit = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUnit)).BeginInit();
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
            this.panel.AccessibleDescription = "1223";
            this.panel.Controls.Add(this.trlUnit);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.labIndex);
            this.panel.Controls.Add(this.labUnit);
            this.panel.Controls.Add(this.labMemo);
            this.panel.Controls.Add(this.labPrice);
            this.panel.Controls.Add(this.labAlias);
            this.panel.Controls.Add(this.labCategory);
            this.panel.Controls.Add(this.labCode);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.trlCategory);
            this.panel.Controls.Add(this.spiIndex);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.txtPrice);
            this.panel.Size = new System.Drawing.Size(370, 200);
            this.panel.Tag = "";
            // 
            // txtPrice
            // 
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPrice.Location = new System.Drawing.Point(240, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "n4";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(110, 20);
            this.txtPrice.TabIndex = 5;
            // 
            // spiIndex
            // 
            this.spiIndex.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiIndex.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.spiIndex.Location = new System.Drawing.Point(300, 50);
            this.spiIndex.Name = "spiIndex";
            this.spiIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spiIndex.Properties.IsFloatValue = false;
            this.spiIndex.Properties.Mask.EditMask = "N00";
            this.spiIndex.Size = new System.Drawing.Size(50, 20);
            this.spiIndex.TabIndex = 7;
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new System.Drawing.Point(60, 80);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(120, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCode.Location = new System.Drawing.Point(240, 80);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(110, 20);
            this.txtCode.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new System.Drawing.Point(60, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 1;
            // 
            // trlCategory
            // 
            this.trlCategory.Location = new System.Drawing.Point(60, 15);
            this.trlCategory.Name = "trlCategory";
            this.trlCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("trlCategory.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlCategory.Properties.NullText = "请选择分类…";
            this.trlCategory.Properties.PopupFormSize = new System.Drawing.Size(290, 200);
            this.trlCategory.Properties.TreeList = this.treCategory;
            this.trlCategory.Size = new System.Drawing.Size(290, 22);
            this.trlCategory.TabIndex = 8;
            // 
            // treCategory
            // 
            this.treCategory.Location = new System.Drawing.Point(0, 0);
            this.treCategory.Name = "treCategory";
            this.treCategory.OptionsBehavior.EnableFiltering = true;
            this.treCategory.OptionsView.ShowIndentAsRowStyle = true;
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new System.Drawing.Size(400, 200);
            this.treCategory.TabIndex = 0;
            // 
            // labIndex
            // 
            this.labIndex.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labIndex.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labIndex.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labIndex.Location = new System.Drawing.Point(240, 50);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(60, 21);
            this.labIndex.TabIndex = 0;
            this.labIndex.Text = "索引：";
            // 
            // labPrice
            // 
            this.labPrice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labPrice.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labPrice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labPrice.Location = new System.Drawing.Point(180, 110);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(60, 21);
            this.labPrice.TabIndex = 0;
            this.labPrice.Text = "单价：";
            // 
            // labAlias
            // 
            this.labAlias.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labAlias.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labAlias.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labAlias.Location = new System.Drawing.Point(0, 80);
            this.labAlias.Name = "labAlias";
            this.labAlias.Size = new System.Drawing.Size(60, 21);
            this.labAlias.TabIndex = 0;
            this.labAlias.Text = "简称：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labName.Location = new System.Drawing.Point(0, 50);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // labCategory
            // 
            this.labCategory.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCategory.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCategory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCategory.Location = new System.Drawing.Point(0, 15);
            this.labCategory.Name = "labCategory";
            this.labCategory.Size = new System.Drawing.Size(60, 21);
            this.labCategory.TabIndex = 0;
            this.labCategory.Text = "分类：";
            // 
            // labCode
            // 
            this.labCode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCode.Location = new System.Drawing.Point(180, 80);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(60, 21);
            this.labCode.TabIndex = 0;
            this.labCode.Text = "编码：";
            // 
            // labUnit
            // 
            this.labUnit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUnit.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labUnit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUnit.Location = new System.Drawing.Point(0, 110);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(60, 21);
            this.labUnit.TabIndex = 0;
            this.labUnit.Text = "单位：";
            // 
            // labMemo
            // 
            this.labMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMemo.Location = new System.Drawing.Point(0, 145);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(60, 21);
            this.labMemo.TabIndex = 0;
            this.labMemo.Text = "描述：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(60, 145);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new System.Drawing.Size(290, 40);
            this.memDescription.TabIndex = 6;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // trlUnit
            // 
            this.trlUnit.EnterMoveNextControl = true;
            this.trlUnit.Location = new System.Drawing.Point(60, 110);
            this.trlUnit.Name = "trlUnit";
            this.trlUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.trlUnit.Properties.NullText = "请选择…";
            this.trlUnit.Properties.PopupFormMinSize = new System.Drawing.Size(120, 200);
            this.trlUnit.Properties.PopupFormSize = new System.Drawing.Size(120, 200);
            this.trlUnit.Properties.TreeList = this.treUnit;
            this.trlUnit.Size = new System.Drawing.Size(120, 20);
            this.trlUnit.TabIndex = 4;
            this.trlUnit.EditValueChanged += new System.EventHandler(this.trlUnit_EditValueChanged);
            // 
            // treUnit
            // 
            this.treUnit.Location = new System.Drawing.Point(4, 0);
            this.treUnit.Name = "treUnit";
            this.treUnit.OptionsBehavior.EnableFiltering = true;
            this.treUnit.OptionsView.ShowIndentAsRowStyle = true;
            this.treUnit.SelectImageList = this.imgCategoryNode;
            this.treUnit.Size = new System.Drawing.Size(330, 200);
            this.treUnit.TabIndex = 0;
            // 
            // EditExpense
            // 
            this.AccessibleDescription = "";
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Name = "EditExpense";
            this.Text = "新增项目";
            this.Load += new System.EventHandler(this.Expenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeListLookUpEdit trlCategory;
        private TreeList treCategory;
        private SpinEdit spiIndex;
        private TextEdit txtAlias;
        private TextEdit txtCode;
        private TextEdit txtName;
        private TextEdit txtPrice;
        private LabelControl labIndex;
        private LabelControl labPrice;
        private LabelControl labAlias;
        private LabelControl labCategory;
        private LabelControl labName;
        private LabelControl labCode;
        private LabelControl labUnit;
        private LabelControl labMemo;
        private MemoEdit memDescription;
        private TreeListLookUpEdit trlUnit;
        private TreeList treUnit;

    }
}