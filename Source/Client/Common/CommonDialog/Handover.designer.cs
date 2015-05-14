using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Common
{
    partial class Handover
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Handover));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labTarget = new DevExpress.XtraEditors.LabelControl();
            this.sleTarget = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gdvTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datDate = new DevExpress.XtraEditors.DateEdit();
            this.labDate = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.datDate);
            this.panel.Controls.Add(this.sleTarget);
            this.panel.Controls.Add(this.labDate);
            this.panel.Controls.Add(this.labTarget);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.TabIndex = 3;
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
            // labTarget
            // 
            this.labTarget.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTarget.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTarget.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTarget.Location = new System.Drawing.Point(0, 45);
            this.labTarget.Name = "labTarget";
            this.labTarget.Size = new System.Drawing.Size(80, 21);
            this.labTarget.TabIndex = 0;
            this.labTarget.Text = "移交给：";
            // 
            // sleTarget
            // 
            this.sleTarget.Location = new System.Drawing.Point(80, 45);
            this.sleTarget.Name = "sleTarget";
            this.sleTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sleTarget.Properties.NullText = "请选择目标人员…";
            this.sleTarget.Properties.PopupFormSize = new System.Drawing.Size(280, 200);
            this.sleTarget.Properties.ShowClearButton = false;
            this.sleTarget.Properties.ShowFooter = false;
            this.sleTarget.Properties.View = this.gdvTarget;
            this.sleTarget.Size = new System.Drawing.Size(270, 20);
            this.sleTarget.TabIndex = 1;
            this.sleTarget.EditValueChanged += new System.EventHandler(this.sleTarget_EditValueChanged);
            // 
            // gdvTarget
            // 
            this.gdvTarget.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvTarget.Name = "gdvTarget";
            this.gdvTarget.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvTarget.OptionsView.ShowGroupPanel = false;
            // 
            // datDate
            // 
            this.datDate.EditValue = null;
            this.datDate.Location = new System.Drawing.Point(80, 80);
            this.datDate.Name = "datDate";
            this.datDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.datDate.Properties.AutoHeight = false;
            this.datDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("datDate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.datDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDate.Size = new System.Drawing.Size(100, 21);
            this.datDate.TabIndex = 2;
            // 
            // labDate
            // 
            this.labDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDate.Location = new System.Drawing.Point(0, 80);
            this.labDate.Name = "labDate";
            this.labDate.Size = new System.Drawing.Size(80, 21);
            this.labDate.TabIndex = 0;
            this.labDate.Text = "移交日期：";
            // 
            // Handover
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "Handover";
            this.Load += new System.EventHandler(this.Transfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl labTarget;
        private SearchLookUpEdit sleTarget;
        private GridView gdvTarget;
        private DateEdit datDate;
        private LabelControl labDate;

    }
}