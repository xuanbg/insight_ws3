using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    partial class InstantReport
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
            var resources = new ComponentResourceManager(typeof(InstantReport));
            var serializableAppearanceObject2 = new SerializableAppearanceObject();
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            this.datBegin = new DateEdit();
            this.datEnd = new DateEdit();
            this.lokEntitys = new LookUpEdit();
            this.labOrg = new LabelControl();
            this.labStartDate = new LabelControl();
            this.labEndDate = new LabelControl();
            this.labName = new LabelControl();
            this.txtReport = new TextEdit();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.datBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datBegin.Properties)).BeginInit();
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((ISupportInitialize)(this.datEnd.Properties)).BeginInit();
            ((ISupportInitialize)(this.lokEntitys.Properties)).BeginInit();
            ((ISupportInitialize)(this.txtReport.Properties)).BeginInit();
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
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtReport);
            this.panel.Controls.Add(this.labEndDate);
            this.panel.Controls.Add(this.labStartDate);
            this.panel.Controls.Add(this.labName);
            this.panel.Controls.Add(this.labOrg);
            this.panel.Controls.Add(this.lokEntitys);
            this.panel.Controls.Add(this.datEnd);
            this.panel.Controls.Add(this.datBegin);
            // 
            // datBegin
            // 
            this.datBegin.EditValue = null;
            this.datBegin.EnterMoveNextControl = true;
            this.datBegin.Location = new Point(80, 100);
            this.datBegin.Name = "datBegin";
            this.datBegin.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datBegin.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.datBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datBegin.Size = new Size(95, 22);
            this.datBegin.TabIndex = 2;
            this.datBegin.EditValueChanged += new EventHandler(this.datBegin_EditValueChanged);
            // 
            // datEnd
            // 
            this.datEnd.EditValue = null;
            this.datEnd.EnterMoveNextControl = true;
            this.datEnd.Location = new Point(255, 100);
            this.datEnd.Name = "datEnd";
            this.datEnd.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, ((Image)(resources.GetObject("datEnd.Properties.Buttons"))), new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.datEnd.Size = new Size(95, 22);
            this.datEnd.TabIndex = 3;
            this.datEnd.EditValueChanged += new EventHandler(this.datEnd_EditValueChanged);
            // 
            // lokEntitys
            // 
            this.lokEntitys.EnterMoveNextControl = true;
            this.lokEntitys.Location = new Point(80, 65);
            this.lokEntitys.Name = "lokEntitys";
            this.lokEntitys.Properties.AutoHeight = false;
            this.lokEntitys.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.lokEntitys.Properties.NullText = "请选择…";
            this.lokEntitys.Properties.ShowHeader = false;
            this.lokEntitys.Size = new Size(270, 21);
            this.lokEntitys.TabIndex = 1;
            // 
            // labOrg
            // 
            this.labOrg.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labOrg.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labOrg.AutoSizeMode = LabelAutoSizeMode.None;
            this.labOrg.Location = new Point(0, 65);
            this.labOrg.Name = "labOrg";
            this.labOrg.Size = new Size(80, 21);
            this.labOrg.TabIndex = 0;
            this.labOrg.Text = "机构/部门：";
            // 
            // labStartDate
            // 
            this.labStartDate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labStartDate.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labStartDate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labStartDate.Location = new Point(0, 100);
            this.labStartDate.Name = "labStartDate";
            this.labStartDate.Size = new Size(80, 21);
            this.labStartDate.TabIndex = 0;
            this.labStartDate.Text = "开始日期：";
            // 
            // labEndDate
            // 
            this.labEndDate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labEndDate.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labEndDate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labEndDate.Location = new Point(175, 100);
            this.labEndDate.Name = "labEndDate";
            this.labEndDate.Size = new Size(80, 21);
            this.labEndDate.TabIndex = 0;
            this.labEndDate.Text = "截止日期：";
            // 
            // labName
            // 
            this.labName.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labName.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labName.AutoSizeMode = LabelAutoSizeMode.None;
            this.labName.Location = new Point(0, 30);
            this.labName.Name = "labName";
            this.labName.Size = new Size(80, 21);
            this.labName.TabIndex = 0;
            this.labName.Text = "生成报表：";
            // 
            // txtReport
            // 
            this.txtReport.EnterMoveNextControl = true;
            this.txtReport.Location = new Point(80, 30);
            this.txtReport.Name = "txtReport";
            this.txtReport.Properties.ReadOnly = true;
            this.txtReport.Size = new Size(270, 20);
            this.txtReport.TabIndex = 100;
            // 
            // InstantReport
            // 
            this.ClientSize = new Size(384, 212);
            this.Name = "InstantReport";
            this.Text = "即时报表";
            this.Load += new EventHandler(this.OpenDig_Load);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.datBegin.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datBegin.Properties)).EndInit();
            ((ISupportInitialize)(this.datEnd.Properties.CalendarTimeProperties)).EndInit();
            ((ISupportInitialize)(this.datEnd.Properties)).EndInit();
            ((ISupportInitialize)(this.lokEntitys.Properties)).EndInit();
            ((ISupportInitialize)(this.txtReport.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateEdit datBegin;
        private LookUpEdit lokEntitys;
        private DateEdit datEnd;
        private LabelControl labOrg;
        private LabelControl labEndDate;
        private LabelControl labStartDate;
        private LabelControl labName;
        private TextEdit txtReport;
    }
}
