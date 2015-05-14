using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;

namespace Insight.WS.Client.Business.SCM
{
    partial class Supplier
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
            var resources = new ComponentResourceManager(typeof(Supplier));
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            this.txtAlias = new TextEdit();
            this.datRegisterDate = new DateEdit();
            this.txtName = new TextEdit();
            this.lokDistrict = new LookUpEdit();
            this.lokProvince = new LookUpEdit();
            this.lokCity = new LookUpEdit();
            this.txtAddress = new TextEdit();
            this.memDescription = new MemoEdit();
            this.txtBusiness = new TextEdit();
            this.txtWebsite = new TextEdit();
            this.txtZipCode = new TextEdit();
            this.lokIndustry = new LookUpEdit();
            this.lokEnterprise = new LookUpEdit();
            this.labName = new LabelControl();
            this.labAlias = new LabelControl();
            this.labAddress = new LabelControl();
            this.txtTax = new TextEdit();
            this.txtRegister = new TextEdit();
            this.labZipCode = new LabelControl();
            this.labWebsite = new LabelControl();
            this.labDescription = new LabelControl();
            this.labCorporation = new LabelControl();
            this.txtCorporation = new TextEdit();
            this.labPhone = new LabelControl();
            this.txtPhone = new TextEdit();
            this.labIndustry = new LabelControl();
            this.labEnterprise = new LabelControl();
            this.labBusiness = new LabelControl();
            this.labRegister = new LabelControl();
            this.labTax = new LabelControl();
            this.labRegisterDate = new LabelControl();
            this.labScale = new LabelControl();
            this.labStaffs = new LabelControl();
            this.labelControl6 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.speStaffs = new SpinEdit();
            this.txtScale = new TextEdit();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((ISupportInitialize)(this.datRegisterDate.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datRegisterDate.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokDistrict.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokProvince.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokCity.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtBusiness.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtWebsite.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtZipCode.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokIndustry.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokEnterprise.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtTax.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtRegister.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtCorporation.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((ISupportInitialize)(this.speStaffs.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtScale.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFolderNode
            // 
            this.imgFolderNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgFolderNode.ImageStream")));
            this.imgFolderNode.Images.SetKeyName(0, "Item.png");
            this.imgFolderNode.Images.SetKeyName(1, "Close.png");
            this.imgFolderNode.Images.SetKeyName(2, "Open.png");
            // 
            // imgCategoryNode
            // 
            this.imgCategoryNode.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imgCategoryNode.ImageStream")));
            this.imgCategoryNode.Images.SetKeyName(0, "Doc.png");
            this.imgCategoryNode.Images.SetKeyName(1, "Close.png");
            this.imgCategoryNode.Images.SetKeyName(2, "Open.png");
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
            this.btnConfirm.Location = new Point(490, 285);
            this.btnConfirm.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(400, 285);
            this.btnCancel.TabIndex = 23;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.labStaffs);
            this.panel.Controls.Add(this.labScale);
            this.panel.Controls.Add(this.labRegisterDate);
            this.panel.Controls.Add(this.txtPhone);
            this.panel.Controls.Add(this.labTax);
            this.panel.Controls.Add(this.labPhone);
            this.panel.Controls.Add(this.txtZipCode);
            this.panel.Controls.Add(this.labBusiness);
            this.panel.Controls.Add(this.labZipCode);
            this.panel.Controls.Add(this.datRegisterDate);
            this.panel.Controls.Add(this.labRegister);
            this.panel.Controls.Add(this.labEnterprise);
            this.panel.Controls.Add(this.labIndustry);
            this.panel.Controls.Add(this.labelControl7);
            this.panel.Controls.Add(this.labelControl6);
            this.panel.Controls.Add(this.labCorporation);
            this.panel.Controls.Add(this.txtCorporation);
            this.panel.Controls.Add(this.labDescription);
            this.panel.Controls.Add(this.labWebsite);
            this.panel.Controls.Add(this.txtTax);
            this.panel.Controls.Add(this.txtRegister);
            this.panel.Controls.Add(this.labAddress);
            this.panel.Controls.Add(this.labAlias);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.txtAddress);
            this.panel.Controls.Add(this.lokDistrict);
            this.panel.Controls.Add(this.lokProvince);
            this.panel.Controls.Add(this.lokCity);
            this.panel.Controls.Add(this.lokEnterprise);
            this.panel.Controls.Add(this.txtBusiness);
            this.panel.Controls.Add(this.txtWebsite);
            this.panel.Controls.Add(this.lokIndustry);
            this.panel.Controls.Add(this.txtAlias);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.speStaffs);
            this.panel.Controls.Add(this.txtScale);
            this.panel.Size = new Size(570, 261);
            // 
            // txtAlias
            // 
            this.txtAlias.EnterMoveNextControl = true;
            this.txtAlias.Location = new Point(315, 15);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new Size(60, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // datRegisterDate
            // 
            this.datRegisterDate.EditValue = null;
            this.datRegisterDate.Location = new Point(435, 170);
            this.datRegisterDate.Name = "datRegisterDate";
            this.datRegisterDate.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datRegisterDate.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datRegisterDate.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datRegisterDate.Properties.NullDate = "";
            this.datRegisterDate.Size = new Size(120, 22);
            this.datRegisterDate.TabIndex = 20;
            // 
            // txtName
            // 
            this.txtName.EnterMoveNextControl = true;
            this.txtName.Location = new Point(60, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(200, 20);
            this.txtName.TabIndex = 1;
            // 
            // lokDistrict
            // 
            this.lokDistrict.EnterMoveNextControl = true;
            this.lokDistrict.Location = new Point(265, 45);
            this.lokDistrict.Name = "lokDistrict";
            this.lokDistrict.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokDistrict.Properties.NullText = "请选择…";
            this.lokDistrict.Properties.PopupFormMinSize = new Size(80, 160);
            this.lokDistrict.Properties.PopupWidth = 100;
            this.lokDistrict.Size = new Size(110, 20);
            this.lokDistrict.TabIndex = 6;
            // 
            // lokProvince
            // 
            this.lokProvince.EnterMoveNextControl = true;
            this.lokProvince.Location = new Point(60, 45);
            this.lokProvince.Name = "lokProvince";
            this.lokProvince.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokProvince.Properties.NullText = "请选择…";
            this.lokProvince.Properties.PopupFormMinSize = new Size(80, 160);
            this.lokProvince.Properties.PopupWidth = 100;
            this.lokProvince.Size = new Size(100, 20);
            this.lokProvince.TabIndex = 4;
            this.lokProvince.EditValueChanged += new EventHandler(this.Province_EditValueChanged);
            // 
            // lokCity
            // 
            this.lokCity.EnterMoveNextControl = true;
            this.lokCity.Location = new Point(165, 45);
            this.lokCity.Name = "lokCity";
            this.lokCity.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokCity.Properties.NullText = "请选择…";
            this.lokCity.Properties.PopupFormMinSize = new Size(80, 160);
            this.lokCity.Properties.PopupWidth = 100;
            this.lokCity.Size = new Size(95, 20);
            this.lokCity.TabIndex = 5;
            this.lokCity.EditValueChanged += new EventHandler(this.City_EditValueChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.EnterMoveNextControl = true;
            this.txtAddress.Location = new Point(381, 45);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new Size(174, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // memDescription
            // 
            this.memDescription.Location = new Point(80, 205);
            this.memDescription.Name = "memDescription";
            this.memDescription.Size = new Size(475, 40);
            this.memDescription.TabIndex = 21;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // txtBusiness
            // 
            this.txtBusiness.Location = new Point(80, 170);
            this.txtBusiness.Name = "txtBusiness";
            this.txtBusiness.Size = new Size(135, 20);
            this.txtBusiness.TabIndex = 14;
            // 
            // txtWebsite
            // 
            this.txtWebsite.EnterMoveNextControl = true;
            this.txtWebsite.Location = new Point(60, 75);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new Size(200, 20);
            this.txtWebsite.TabIndex = 9;
            // 
            // txtZipCode
            // 
            this.txtZipCode.EnterMoveNextControl = true;
            this.txtZipCode.Location = new Point(315, 75);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Properties.Mask.EditMask = "d6";
            this.txtZipCode.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtZipCode.Size = new Size(60, 20);
            this.txtZipCode.TabIndex = 8;
            // 
            // lokIndustry
            // 
            this.lokIndustry.Location = new Point(80, 110);
            this.lokIndustry.Name = "lokIndustry";
            this.lokIndustry.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokIndustry.Properties.NullText = "请选择…";
            this.lokIndustry.Properties.PopupFormMinSize = new Size(80, 160);
            this.lokIndustry.Properties.PopupWidth = 135;
            this.lokIndustry.Size = new Size(135, 20);
            this.lokIndustry.TabIndex = 12;
            // 
            // lokEnterprise
            // 
            this.lokEnterprise.Location = new Point(80, 140);
            this.lokEnterprise.Name = "lokEnterprise";
            this.lokEnterprise.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokEnterprise.Properties.NullText = "请选择…";
            this.lokEnterprise.Properties.PopupFormMinSize = new Size(80, 160);
            this.lokEnterprise.Properties.PopupWidth = 135;
            this.lokEnterprise.Size = new Size(135, 20);
            this.lokEnterprise.TabIndex = 13;
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(0, 15);
            this.labName.Name = "labName";
            this.labName.Size = new Size(60, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称：";
            // 
            // labAlias
            // 
            this.labAlias.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labAlias.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labAlias.AutoSizeMode = LabelAutoSizeMode.None;
            this.labAlias.Location = new Point(260, 15);
            this.labAlias.Name = "labAlias";
            this.labAlias.Size = new Size(55, 21);
            this.labAlias.TabIndex = 0;
            this.labAlias.Text = "简称：";
            // 
            // labAddress
            // 
            this.labAddress.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labAddress.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labAddress.AutoSizeMode = LabelAutoSizeMode.None;
            this.labAddress.Location = new Point(0, 45);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new Size(60, 21);
            this.labAddress.TabIndex = 0;
            this.labAddress.Text = "地址：";
            // 
            // txtTax
            // 
            this.txtTax.Location = new Point(435, 140);
            this.txtTax.Name = "txtTax";
            this.txtTax.Properties.MaxLength = 15;
            this.txtTax.Size = new Size(120, 20);
            this.txtTax.TabIndex = 19;
            // 
            // txtRegister
            // 
            this.txtRegister.Location = new Point(435, 110);
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Properties.MaxLength = 15;
            this.txtRegister.Size = new Size(120, 20);
            this.txtRegister.TabIndex = 18;
            // 
            // labZipCode
            // 
            this.labZipCode.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labZipCode.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labZipCode.AutoSizeMode = LabelAutoSizeMode.None;
            this.labZipCode.Location = new Point(260, 75);
            this.labZipCode.Name = "labZipCode";
            this.labZipCode.Size = new Size(55, 21);
            this.labZipCode.TabIndex = 0;
            this.labZipCode.Text = "邮编：";
            // 
            // labWebsite
            // 
            this.labWebsite.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labWebsite.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labWebsite.AutoSizeMode = LabelAutoSizeMode.None;
            this.labWebsite.Location = new Point(0, 75);
            this.labWebsite.Name = "labWebsite";
            this.labWebsite.Size = new Size(60, 21);
            this.labWebsite.TabIndex = 0;
            this.labWebsite.Text = "网站：";
            // 
            // labDescription
            // 
            this.labDescription.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labDescription.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.labDescription.Location = new Point(0, 205);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new Size(80, 21);
            this.labDescription.TabIndex = 0;
            this.labDescription.Text = "备注：";
            // 
            // labCorporation
            // 
            this.labCorporation.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labCorporation.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labCorporation.AutoSizeMode = LabelAutoSizeMode.None;
            this.labCorporation.Location = new Point(215, 110);
            this.labCorporation.Name = "labCorporation";
            this.labCorporation.Size = new Size(60, 21);
            this.labCorporation.TabIndex = 0;
            this.labCorporation.Text = "法人：";
            // 
            // txtCorporation
            // 
            this.txtCorporation.Location = new Point(275, 110);
            this.txtCorporation.Name = "txtCorporation";
            this.txtCorporation.Size = new Size(60, 20);
            this.txtCorporation.TabIndex = 15;
            // 
            // labPhone
            // 
            this.labPhone.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labPhone.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labPhone.AutoSizeMode = LabelAutoSizeMode.None;
            this.labPhone.Location = new Point(375, 15);
            this.labPhone.Name = "labPhone";
            this.labPhone.Size = new Size(60, 21);
            this.labPhone.TabIndex = 0;
            this.labPhone.Text = "电话：";
            // 
            // txtPhone
            // 
            this.txtPhone.EnterMoveNextControl = true;
            this.txtPhone.Location = new Point(435, 15);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Mask.EditMask = "\\d{3,4}?-?\\d{3,5}-?\\d{3,4}?";
            this.txtPhone.Properties.Mask.MaskType = MaskType.RegEx;
            this.txtPhone.Size = new Size(120, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // labIndustry
            // 
            this.labIndustry.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labIndustry.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labIndustry.AutoSizeMode = LabelAutoSizeMode.None;
            this.labIndustry.Location = new Point(0, 110);
            this.labIndustry.Name = "labIndustry";
            this.labIndustry.Size = new Size(80, 21);
            this.labIndustry.TabIndex = 0;
            this.labIndustry.Text = "行业类型：";
            // 
            // labEnterprise
            // 
            this.labEnterprise.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labEnterprise.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labEnterprise.AutoSizeMode = LabelAutoSizeMode.None;
            this.labEnterprise.Location = new Point(0, 140);
            this.labEnterprise.Name = "labEnterprise";
            this.labEnterprise.Size = new Size(80, 21);
            this.labEnterprise.TabIndex = 0;
            this.labEnterprise.Text = "企业类型：";
            // 
            // labBusiness
            // 
            this.labBusiness.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labBusiness.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labBusiness.AutoSizeMode = LabelAutoSizeMode.None;
            this.labBusiness.Location = new Point(0, 170);
            this.labBusiness.Name = "labBusiness";
            this.labBusiness.Size = new Size(80, 21);
            this.labBusiness.TabIndex = 0;
            this.labBusiness.Text = "经营范围：";
            // 
            // labRegister
            // 
            this.labRegister.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labRegister.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labRegister.AutoSizeMode = LabelAutoSizeMode.None;
            this.labRegister.Location = new Point(355, 110);
            this.labRegister.Name = "labRegister";
            this.labRegister.Size = new Size(80, 21);
            this.labRegister.TabIndex = 0;
            this.labRegister.Text = "注册号：";
            // 
            // labTax
            // 
            this.labTax.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labTax.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labTax.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTax.Location = new Point(355, 140);
            this.labTax.Name = "labTax";
            this.labTax.Size = new Size(80, 21);
            this.labTax.TabIndex = 0;
            this.labTax.Text = "税号：";
            // 
            // labRegisterDate
            // 
            this.labRegisterDate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labRegisterDate.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labRegisterDate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labRegisterDate.Location = new Point(355, 170);
            this.labRegisterDate.Name = "labRegisterDate";
            this.labRegisterDate.Size = new Size(80, 21);
            this.labRegisterDate.TabIndex = 0;
            this.labRegisterDate.Text = "开业日期：";
            // 
            // labScale
            // 
            this.labScale.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labScale.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labScale.AutoSizeMode = LabelAutoSizeMode.None;
            this.labScale.Location = new Point(215, 140);
            this.labScale.Name = "labScale";
            this.labScale.Size = new Size(60, 21);
            this.labScale.TabIndex = 0;
            this.labScale.Text = "资产：";
            // 
            // labStaffs
            // 
            this.labStaffs.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labStaffs.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labStaffs.AutoSizeMode = LabelAutoSizeMode.None;
            this.labStaffs.Location = new Point(215, 170);
            this.labStaffs.Name = "labStaffs";
            this.labStaffs.Size = new Size(60, 21);
            this.labStaffs.TabIndex = 0;
            this.labStaffs.Text = "员工：";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labelControl6.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labelControl6.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl6.Location = new Point(335, 140);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(20, 21);
            this.labelControl6.TabIndex = 165;
            this.labelControl6.Text = "万";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labelControl7.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labelControl7.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl7.Location = new Point(335, 170);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(20, 21);
            this.labelControl7.TabIndex = 165;
            this.labelControl7.Text = "人";
            // 
            // speStaffs
            // 
            this.speStaffs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speStaffs.Location = new Point(275, 170);
            this.speStaffs.Name = "speStaffs";
            this.speStaffs.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.speStaffs.Properties.EditValueChangedFiringMode = EditValueChangedFiringMode.Default;
            this.speStaffs.Properties.Mask.EditMask = "d";
            this.speStaffs.Size = new Size(60, 20);
            this.speStaffs.TabIndex = 17;
            // 
            // txtScale
            // 
            this.txtScale.Location = new Point(275, 140);
            this.txtScale.Name = "txtScale";
            this.txtScale.Properties.Mask.EditMask = "d";
            this.txtScale.Properties.Mask.MaskType = MaskType.Numeric;
            this.txtScale.Size = new Size(60, 20);
            this.txtScale.TabIndex = 16;
            // 
            // Supplier
            // 
            this.ClientSize = new Size(584, 322);
            this.Name = "Supplier";
            this.Load += new EventHandler(this.Supplier_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((ISupportInitialize)(this.datRegisterDate.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datRegisterDate.Properties)).EndInit();
            ((ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((ISupportInitialize)(this.lokDistrict.Properties)).EndInit();
            ((ISupportInitialize)(this.lokProvince.Properties)).EndInit();
            ((ISupportInitialize)(this.lokCity.Properties)).EndInit();
            ((ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((ISupportInitialize)(this.txtBusiness.Properties)).EndInit();
            ((ISupportInitialize)(this.txtWebsite.Properties)).EndInit();
            ((ISupportInitialize)(this.txtZipCode.Properties)).EndInit();
            ((ISupportInitialize)(this.lokIndustry.Properties)).EndInit();
            ((ISupportInitialize)(this.lokEnterprise.Properties)).EndInit();
            ((ISupportInitialize)(this.txtTax.Properties)).EndInit();
            ((ISupportInitialize)(this.txtRegister.Properties)).EndInit();
            ((ISupportInitialize)(this.txtCorporation.Properties)).EndInit();
            ((ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((ISupportInitialize)(this.speStaffs.Properties)).EndInit();
            ((ISupportInitialize)(this.txtScale.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextEdit txtAlias;
        private DateEdit datRegisterDate;
        private TextEdit txtName;
        private LookUpEdit lokDistrict;
        private LookUpEdit lokProvince;
        private LookUpEdit lokCity;
        private TextEdit txtAddress;
        private TextEdit txtZipCode;
        private LookUpEdit lokEnterprise;
        private TextEdit txtBusiness;
        private TextEdit txtWebsite;
        private LookUpEdit lokIndustry;
        private MemoEdit memDescription;
        private TextEdit txtTax;
        private TextEdit txtRegister;
        private LabelControl labAddress;
        private LabelControl labAlias;
        private LabelControl labName;
        private LabelControl labDescription;
        private LabelControl labWebsite;
        private LabelControl labZipCode;
        private LabelControl labCorporation;
        private TextEdit txtCorporation;
        private LabelControl labPhone;
        private TextEdit txtPhone;
        private LabelControl labStaffs;
        private LabelControl labScale;
        private LabelControl labRegisterDate;
        private LabelControl labTax;
        private LabelControl labBusiness;
        private LabelControl labRegister;
        private LabelControl labEnterprise;
        private LabelControl labIndustry;
        private LabelControl labelControl7;
        private LabelControl labelControl6;
        private SpinEdit speStaffs;
        private TextEdit txtScale;

    }
}
