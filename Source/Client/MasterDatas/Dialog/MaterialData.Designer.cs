using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.MasterDatas
{
    partial class MaterialData
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager(typeof(MaterialData));
            var serializableAppearanceObject2 = new SerializableAppearanceObject();
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            this.trlSizeType = new TreeListLookUpEdit();
            this.treSizeType = new TreeList();
            this.txtSize = new TextEdit();
            this.memDescription = new MemoEdit();
            this.lokStoreType = new LookUpEdit();
            this.txtBarCode = new TextEdit();
            this.txtModel = new TextEdit();
            this.trlCategory = new TreeListLookUpEdit();
            this.treCategory = new TreeList();
            this.spiIndex = new SpinEdit();
            this.labIndex = new LabelControl();
            this.txtAlias = new TextEdit();
            this.txtCode = new TextEdit();
            this.labStartAndEnd = new LabelControl();
            this.labCategory = new LabelControl();
            this.labTime = new LabelControl();
            this.labName = new LabelControl();
            this.txtName = new TextEdit();
            this.labModel = new LabelControl();
            this.labSize = new LabelControl();
            this.labBarCode = new LabelControl();
            this.labStoreType = new LabelControl();
            this.labDescription = new LabelControl();
            this.labUnit = new LabelControl();
            this.trlUnit = new TreeListLookUpEdit();
            this.treUnit = new TreeList();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.trlSizeType.Properties)).BeginInit();
            ((ISupportInitialize)(this.treSizeType)).BeginInit();
            ((ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokStoreType.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtBarCode.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((ISupportInitialize)(this.trlCategory.Properties)).BeginInit();
            ((ISupportInitialize)(this.treCategory)).BeginInit();
            ((ISupportInitialize)(this.spiIndex.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((ISupportInitialize)(this.trlUnit.Properties)).BeginInit();
            ((ISupportInitialize)(this.treUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Folder.png");
            this.imgFolderNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Folder.png");
            this.imgCategoryNode.Images.SetKeyName(2, "FolderOpen.png");
            // 
            // imgOrgTreeNode
            // 
            this.imgOrgTreeNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgOrgTreeNode.ImageStream")));
            this.imgOrgTreeNode.Images.SetKeyName(0, "NodeOrg.png");
            this.imgOrgTreeNode.Images.SetKeyName(1, "NodeDept.png");
            this.imgOrgTreeNode.Images.SetKeyName(2, "NodePost.png");
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(390, 224);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(300, 224);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.trlUnit);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.trlSizeType);
            this.panel.Controls.Add(this.spiIndex);
            this.panel.Controls.Add(this.txtBarCode);
            this.panel.Controls.Add(this.labIndex);
            this.panel.Controls.Add(this.trlCategory);
            this.panel.Controls.Add(this.labBarCode);
            this.panel.Controls.Add(this.txtSize);
            this.panel.Controls.Add(this.labCategory);
            this.panel.Controls.Add(this.lokStoreType);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.labSize);
            this.panel.Controls.Add(this.labStoreType);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.labUnit);
            this.panel.Controls.Add(this.labModel);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtCode);
            this.panel.Controls.Add(this.txtModel);
            this.panel.Controls.Add(this.labTime);
            this.panel.Controls.Add(this.labStartAndEnd);
            this.panel.Size = new Size(470, 200);
            // 
            // trlSizeType
            // 
            this.trlSizeType.EnterMoveNextControl = true;
            this.trlSizeType.Location = new Point(305, 80);
            this.trlSizeType.Name = "trlSizeType";
            this.trlSizeType.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.trlSizeType.Properties.NullText = "请选择…";
            this.trlSizeType.Properties.PopupFormMinSize = new Size(120, 200);
            this.trlSizeType.Properties.PopupFormSize = new Size(145, 200);
            this.trlSizeType.Properties.TreeList = this.treSizeType;
            this.trlSizeType.Size = new Size(145, 20);
            this.trlSizeType.TabIndex = 7;
            this.trlSizeType.EditValueChanged += new EventHandler(this.trlSizeType_EditValueChanged);
            // 
            // treSizeType
            // 
            this.treSizeType.Location = new Point(0, 0);
            this.treSizeType.Name = "treSizeType";
            this.treSizeType.OptionsBehavior.EnableFiltering = true;
            this.treSizeType.OptionsView.ShowIndentAsRowStyle = true;
            this.treSizeType.SelectImageList = this.imgCategoryNode;
            this.treSizeType.Size = new Size(400, 200);
            this.treSizeType.TabIndex = 0;
            // 
            // txtSize
            // 
            this.txtSize.EnterMoveNextControl = true;
            this.txtSize.Location = new Point(220, 80);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new Size(80, 20);
            this.txtSize.TabIndex = 6;
            // 
            // memDescription
            // 
            this.memDescription.Location = new Point(60, 145);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入描述信息……";
            this.memDescription.Size = new Size(390, 40);
            this.memDescription.TabIndex = 12;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // lokStoreType
            // 
            this.lokStoreType.Location = new Point(240, 110);
            this.lokStoreType.Name = "lokStoreType";
            this.lokStoreType.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo),
            new EditorButton(ButtonPredefines.Clear, "清除", -1, true, true, false, ImageLocation.MiddleCenter, null, new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.lokStoreType.Properties.NullText = "请选择…";
            this.lokStoreType.Properties.PopupFormMinSize = new Size(80, 200);
            this.lokStoreType.Properties.PopupWidth = 80;
            this.lokStoreType.Properties.ShowHeader = false;
            this.lokStoreType.Size = new Size(100, 20);
            this.lokStoreType.TabIndex = 9;
            this.lokStoreType.ButtonClick += new ButtonPressedEventHandler(this.lokStoreType_ButtonClick);
            // 
            // txtBarCode
            // 
            this.txtBarCode.EnterMoveNextControl = true;
            this.txtBarCode.Location = new Point(360, 50);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new Size(90, 20);
            this.txtBarCode.TabIndex = 4;
            // 
            // txtModel
            // 
            this.txtModel.EnterMoveNextControl = true;
            this.txtModel.Location = new Point(60, 80);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new Size(100, 20);
            this.txtModel.TabIndex = 5;
            // 
            // trlCategory
            // 
            this.trlCategory.Location = new Point(60, 15);
            this.trlCategory.Name = "trlCategory";
            this.trlCategory.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("trlCategory.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlCategory.Properties.NullText = "请选择分类…";
            this.trlCategory.Properties.PopupFormMinSize = new Size(180, 200);
            this.trlCategory.Properties.PopupFormSize = new Size(180, 200);
            this.trlCategory.Properties.TreeList = this.treCategory;
            this.trlCategory.Size = new Size(180, 22);
            this.trlCategory.TabIndex = 10;
            // 
            // treCategory
            // 
            this.treCategory.Location = new Point(75, 9);
            this.treCategory.Name = "treCategory";
            this.treCategory.OptionsBehavior.EnableFiltering = true;
            this.treCategory.OptionsView.ShowIndentAsRowStyle = true;
            this.treCategory.SelectImageList = this.imgFolderNode;
            this.treCategory.Size = new Size(400, 200);
            this.treCategory.TabIndex = 0;
            // 
            // spiIndex
            // 
            this.spiIndex.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spiIndex.Location = new Point(400, 110);
            this.spiIndex.Name = "spiIndex";
            this.spiIndex.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.spiIndex.Properties.IsFloatValue = false;
            this.spiIndex.Properties.Mask.EditMask = "N00";
            this.spiIndex.Size = new Size(50, 20);
            this.spiIndex.TabIndex = 11;
            // 
            // labIndex
            // 
            this.labIndex.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labIndex.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labIndex.AutoSizeMode = LabelAutoSizeMode.None;
            this.labIndex.Location = new Point(340, 110);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new Size(60, 21);
            this.labIndex.TabIndex = 0;
            this.labIndex.Text = "序号：";
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new Point(60, 50);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new Size(100, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new Point(220, 50);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new Size(80, 20);
            this.txtCode.TabIndex = 3;
            // 
            // labStartAndEnd
            // 
            this.labStartAndEnd.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labStartAndEnd.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labStartAndEnd.AutoSizeMode = LabelAutoSizeMode.None;
            this.labStartAndEnd.Location = new Point(0, 50);
            this.labStartAndEnd.Name = "labStartAndEnd";
            this.labStartAndEnd.Size = new Size(60, 21);
            this.labStartAndEnd.TabIndex = 0;
            this.labStartAndEnd.Text = "简称：";
            // 
            // labCategory
            // 
            this.labCategory.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCategory.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labCategory.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCategory.Location = new Point(0, 15);
            this.labCategory.Name = "labCategory";
            this.labCategory.Size = new Size(60, 21);
            this.labCategory.TabIndex = 0;
            this.labCategory.Text = "分类：";
            // 
            // labTime
            // 
            this.labTime.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labTime.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labTime.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTime.Location = new Point(160, 50);
            this.labTime.Name = "labTime";
            this.labTime.Size = new Size(60, 21);
            this.labTime.TabIndex = 0;
            this.labTime.Text = "编码：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(240, 15);
            this.labName.Name = "labName";
            this.labName.Size = new Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new Point(300, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(150, 20);
            this.txtName.TabIndex = 1;
            // 
            // labModel
            // 
            this.labModel.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labModel.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labModel.AutoSizeMode = LabelAutoSizeMode.None;
            this.labModel.Location = new Point(0, 80);
            this.labModel.Name = "labModel";
            this.labModel.Size = new Size(60, 21);
            this.labModel.TabIndex = 0;
            this.labModel.Text = "型号：";
            // 
            // labSize
            // 
            this.labSize.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labSize.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labSize.AutoSizeMode = LabelAutoSizeMode.None;
            this.labSize.Location = new Point(160, 80);
            this.labSize.Name = "labSize";
            this.labSize.Size = new Size(60, 21);
            this.labSize.TabIndex = 0;
            this.labSize.Text = "规格：";
            // 
            // labBarCode
            // 
            this.labBarCode.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labBarCode.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labBarCode.AutoSizeMode = LabelAutoSizeMode.None;
            this.labBarCode.Location = new Point(300, 50);
            this.labBarCode.Name = "labBarCode";
            this.labBarCode.Size = new Size(60, 21);
            this.labBarCode.TabIndex = 0;
            this.labBarCode.Text = "条码：";
            // 
            // labStoreType
            // 
            this.labStoreType.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labStoreType.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labStoreType.AutoSizeMode = LabelAutoSizeMode.None;
            this.labStoreType.Location = new Point(160, 110);
            this.labStoreType.Name = "labStoreType";
            this.labStoreType.Size = new Size(80, 21);
            this.labStoreType.TabIndex = 0;
            this.labStoreType.Text = "存储方式：";
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labDescription.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.labDescription.Location = new Point(0, 145);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new Size(60, 21);
            this.labDescription.TabIndex = 0;
            this.labDescription.Text = "描述：";
            // 
            // labUnit
            // 
            this.labUnit.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labUnit.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labUnit.AutoSizeMode = LabelAutoSizeMode.None;
            this.labUnit.Location = new Point(0, 110);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new Size(60, 21);
            this.labUnit.TabIndex = 0;
            this.labUnit.Text = "单位：";
            // 
            // trlUnit
            // 
            this.trlUnit.EnterMoveNextControl = true;
            this.trlUnit.Location = new Point(60, 110);
            this.trlUnit.Name = "trlUnit";
            this.trlUnit.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.trlUnit.Properties.NullText = "请选择…";
            this.trlUnit.Properties.PopupFormMinSize = new Size(120, 200);
            this.trlUnit.Properties.PopupFormSize = new Size(140, 200);
            this.trlUnit.Properties.TreeList = this.treUnit;
            this.trlUnit.Size = new Size(98, 20);
            this.trlUnit.TabIndex = 8;
            this.trlUnit.EditValueChanged += new EventHandler(this.trlUnit_EditValueChanged);
            // 
            // treUnit
            // 
            this.treUnit.Location = new Point(10, 0);
            this.treUnit.Name = "treUnit";
            this.treUnit.OptionsBehavior.EnableFiltering = true;
            this.treUnit.OptionsView.ShowIndentAsRowStyle = true;
            this.treUnit.SelectImageList = this.imgCategoryNode;
            this.treUnit.Size = new Size(363, 200);
            this.treUnit.TabIndex = 0;
            // 
            // MaterialData
            // 
            this.ClientSize = new Size(484, 262);
            this.Name = "MaterialData";
            this.Load += new EventHandler(this.MaterialData_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.trlSizeType.Properties)).EndInit();
            ((ISupportInitialize)(this.treSizeType)).EndInit();
            ((ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((ISupportInitialize)(this.lokStoreType.Properties)).EndInit();
            ((ISupportInitialize)(this.txtBarCode.Properties)).EndInit();
            ((ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((ISupportInitialize)(this.trlCategory.Properties)).EndInit();
            ((ISupportInitialize)(this.treCategory)).EndInit();
            ((ISupportInitialize)(this.spiIndex.Properties)).EndInit();
            ((ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((ISupportInitialize)(this.trlUnit.Properties)).EndInit();
            ((ISupportInitialize)(this.treUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MemoEdit memDescription;
        private LookUpEdit lokStoreType;
        private TextEdit txtBarCode;
        private TextEdit txtModel;
        private TextEdit txtSize;
        private TreeListLookUpEdit trlSizeType;
        private TreeList treSizeType;
        private TreeListLookUpEdit trlCategory;
        private TreeList treCategory;
        private LabelControl labCategory;
        private LabelControl labIndex;
        private TextEdit txtName;
        private TextEdit txtAlias;
        private LabelControl labSize;
        private LabelControl labStoreType;
        private LabelControl labDescription;
        private LabelControl labBarCode;
        private LabelControl labModel;
        private LabelControl labName;
        private TextEdit txtCode;
        private LabelControl labTime;
        private LabelControl labStartAndEnd;
        private SpinEdit spiIndex;
        private TreeListLookUpEdit trlUnit;
        private TreeList treUnit;
        private LabelControl labUnit;
    }
}
