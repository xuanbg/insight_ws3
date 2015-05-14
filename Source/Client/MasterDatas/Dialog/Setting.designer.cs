using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.MasterDatas
{
    partial class Setting
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
            var resources = new ComponentResourceManager(typeof(Setting));
            this.grpNeed = new GroupControl();
            this.chkNeedLeader = new CheckEdit();
            this.chkNeedPhone = new CheckEdit();
            this.chkNeedMail = new CheckEdit();
            this.chkNeedType = new CheckEdit();
            this.chkNeedId = new CheckEdit();
            this.chkNeedCode = new CheckEdit();
            this.labTemplate = new LabelControl();
            this.grlTemplate = new GridLookUpEdit();
            this.gdvTemplate = new GridView();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.grpNeed)).BeginInit();
            this.grpNeed.SuspendLayout();
            ((ISupportInitialize)(this.chkNeedLeader.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkNeedPhone.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkNeedMail.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkNeedType.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkNeedId.Properties)).BeginInit();
            ((ISupportInitialize)(this.chkNeedCode.Properties)).BeginInit();
            ((ISupportInitialize)(this.grlTemplate.Properties)).BeginInit();
            ((ISupportInitialize)(this.gdvTemplate)).BeginInit();
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
            this.panel.Controls.Add(this.labTemplate);
            this.panel.Controls.Add(this.grlTemplate);
            this.panel.Size = new Size(370, 50);
            // 
            // grpNeed
            // 
            this.grpNeed.Controls.Add(this.chkNeedLeader);
            this.grpNeed.Controls.Add(this.chkNeedPhone);
            this.grpNeed.Controls.Add(this.chkNeedMail);
            this.grpNeed.Controls.Add(this.chkNeedType);
            this.grpNeed.Controls.Add(this.chkNeedId);
            this.grpNeed.Controls.Add(this.chkNeedCode);
            this.grpNeed.Location = new Point(7, 64);
            this.grpNeed.Name = "grpNeed";
            this.grpNeed.Size = new Size(370, 93);
            this.grpNeed.TabIndex = 0;
            this.grpNeed.Text = "必填项目";
            // 
            // chkNeedLeader
            // 
            this.chkNeedLeader.Location = new Point(120, 35);
            this.chkNeedLeader.Name = "chkNeedLeader";
            this.chkNeedLeader.Properties.Caption = "直属领导";
            this.chkNeedLeader.Size = new Size(75, 15);
            this.chkNeedLeader.TabIndex = 4;
            // 
            // chkNeedPhone
            // 
            this.chkNeedPhone.Location = new Point(250, 35);
            this.chkNeedPhone.Name = "chkNeedPhone";
            this.chkNeedPhone.Properties.Caption = "移动电话";
            this.chkNeedPhone.Size = new Size(75, 15);
            this.chkNeedPhone.TabIndex = 6;
            // 
            // chkNeedMail
            // 
            this.chkNeedMail.Location = new Point(250, 65);
            this.chkNeedMail.Name = "chkNeedMail";
            this.chkNeedMail.Properties.Caption = "电子邮件";
            this.chkNeedMail.Size = new Size(75, 15);
            this.chkNeedMail.TabIndex = 7;
            // 
            // chkNeedType
            // 
            this.chkNeedType.Location = new Point(20, 65);
            this.chkNeedType.Name = "chkNeedType";
            this.chkNeedType.Properties.Caption = "工种";
            this.chkNeedType.Size = new Size(75, 15);
            this.chkNeedType.TabIndex = 3;
            // 
            // chkNeedId
            // 
            this.chkNeedId.Location = new Point(120, 65);
            this.chkNeedId.Name = "chkNeedId";
            this.chkNeedId.Properties.Caption = "身份证号";
            this.chkNeedId.Size = new Size(75, 15);
            this.chkNeedId.TabIndex = 5;
            // 
            // chkNeedCode
            // 
            this.chkNeedCode.Location = new Point(20, 35);
            this.chkNeedCode.Name = "chkNeedCode";
            this.chkNeedCode.Properties.Caption = "工号";
            this.chkNeedCode.Size = new Size(75, 15);
            this.chkNeedCode.TabIndex = 2;
            // 
            // labTemplate
            // 
            this.labTemplate.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.labTemplate.AutoSizeMode = LabelAutoSizeMode.None;
            this.labTemplate.Location = new Point(0, 15);
            this.labTemplate.Name = "labTemplate";
            this.labTemplate.Size = new Size(80, 21);
            this.labTemplate.TabIndex = 0;
            this.labTemplate.Text = "打印模板：";
            // 
            // grlTemplate
            // 
            this.grlTemplate.Location = new Point(80, 15);
            this.grlTemplate.Name = "grlTemplate";
            this.grlTemplate.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.grlTemplate.Properties.NullText = "请选择模板…";
            this.grlTemplate.Properties.PopupFormSize = new Size(270, 120);
            this.grlTemplate.Properties.View = this.gdvTemplate;
            this.grlTemplate.Size = new Size(270, 20);
            this.grlTemplate.TabIndex = 1;
            // 
            // gdvTemplate
            // 
            this.gdvTemplate.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gdvTemplate.Name = "gdvTemplate";
            this.gdvTemplate.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvTemplate.OptionsView.ShowColumnHeaders = false;
            this.gdvTemplate.OptionsView.ShowGroupPanel = false;
            // 
            // Setting
            // 
            this.ClientSize = new Size(384, 212);
            this.Controls.Add(this.grpNeed);
            this.Name = "Setting";
            this.Text = "设置";
            this.Load += new EventHandler(this.Setting_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grpNeed, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.grpNeed)).EndInit();
            this.grpNeed.ResumeLayout(false);
            ((ISupportInitialize)(this.chkNeedLeader.Properties)).EndInit();
            ((ISupportInitialize)(this.chkNeedPhone.Properties)).EndInit();
            ((ISupportInitialize)(this.chkNeedMail.Properties)).EndInit();
            ((ISupportInitialize)(this.chkNeedType.Properties)).EndInit();
            ((ISupportInitialize)(this.chkNeedId.Properties)).EndInit();
            ((ISupportInitialize)(this.chkNeedCode.Properties)).EndInit();
            ((ISupportInitialize)(this.grlTemplate.Properties)).EndInit();
            ((ISupportInitialize)(this.gdvTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl grpNeed;
        private LabelControl labTemplate;
        private CheckEdit chkNeedPhone;
        private CheckEdit chkNeedType;
        private CheckEdit chkNeedId;
        private CheckEdit chkNeedCode;
        private CheckEdit chkNeedLeader;
        private CheckEdit chkNeedMail;
        private GridLookUpEdit grlTemplate;
        private GridView gdvTemplate;
    }
}
