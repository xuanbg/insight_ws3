using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Platform.Base
{
    partial class Group
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Group));
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labGroupName = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
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
            this.panel.Controls.Add(this.memDescription);
            this.panel.Controls.Add(this.labGroupName);
            this.panel.Controls.Add(this.txtGroupName);
            this.panel.Controls.Add(this.labMemo);
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(75, 60);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入用户组描述…";
            this.memDescription.Size = new System.Drawing.Size(280, 60);
            this.memDescription.TabIndex = 2;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // labGroupName
            // 
            this.labGroupName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labGroupName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labGroupName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labGroupName.Location = new System.Drawing.Point(15, 30);
            this.labGroupName.Name = "labGroupName";
            this.labGroupName.Size = new System.Drawing.Size(60, 21);
            this.labGroupName.TabIndex = 0;
            this.labGroupName.Text = "名称：";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(75, 30);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Properties.NullText = "推荐使用中文名称";
            this.txtGroupName.Size = new System.Drawing.Size(280, 20);
            this.txtGroupName.TabIndex = 1;
            // 
            // labMemo
            // 
            this.labMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMemo.Location = new System.Drawing.Point(15, 60);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(60, 21);
            this.labMemo.TabIndex = 0;
            this.labMemo.Text = "描述：";
            // 
            // Group
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "Group";
            this.Load += new System.EventHandler(this.Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MemoEdit memDescription;
        private LabelControl labGroupName;
        private TextEdit txtGroupName;
        private LabelControl labMemo;

    }
}