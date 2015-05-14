using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Insight.WS.Client.Platform.Base
{
    partial class User
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            this.labUserName = new DevExpress.XtraEditors.LabelControl();
            this.labLoginName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLoginName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.memDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labMemo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
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
            this.panel.Controls.Add(this.labMemo);
            this.panel.Controls.Add(this.txtUserName);
            this.panel.Controls.Add(this.labelControl1);
            this.panel.Controls.Add(this.txtLoginName);
            this.panel.Controls.Add(this.labelControl2);
            // 
            // labUserName
            // 
            this.labUserName.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUserName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labUserName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labUserName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labUserName.Location = new System.Drawing.Point(10, 50);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(80, 21);
            this.labUserName.TabIndex = 1;
            this.labUserName.Text = "用户名：";
            // 
            // labLoginName
            // 
            this.labLoginName.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLoginName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labLoginName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labLoginName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labLoginName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labLoginName.Location = new System.Drawing.Point(10, 90);
            this.labLoginName.Name = "labLoginName";
            this.labLoginName.Size = new System.Drawing.Size(80, 21);
            this.labLoginName.TabIndex = 1;
            this.labLoginName.Text = "登录名：";
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "用户姓名（中文）";
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.Location = new System.Drawing.Point(80, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.NullText = "推荐使用用户姓名（中文）作为用户名";
            this.txtUserName.Size = new System.Drawing.Size(260, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(0, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // txtLoginName
            // 
            this.txtLoginName.EditValue = "大小写英文字母";
            this.txtLoginName.Location = new System.Drawing.Point(80, 50);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Properties.NullText = "请输入用户登录名，由大小写英文字母组成";
            this.txtLoginName.Size = new System.Drawing.Size(260, 20);
            this.txtLoginName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(0, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 21);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "登录名：";
            // 
            // memDescription
            // 
            this.memDescription.Location = new System.Drawing.Point(80, 80);
            this.memDescription.Name = "memDescription";
            this.memDescription.Properties.NullText = "请输入用户描述…";
            this.memDescription.Size = new System.Drawing.Size(260, 50);
            this.memDescription.TabIndex = 3;
            this.memDescription.UseOptimizedRendering = true;
            // 
            // labMemo
            // 
            this.labMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMemo.Location = new System.Drawing.Point(0, 80);
            this.labMemo.Name = "labMemo";
            this.labMemo.Size = new System.Drawing.Size(80, 21);
            this.labMemo.TabIndex = 0;
            this.labMemo.Text = "描述：";
            // 
            // User
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Name = "User";
            this.Load += new System.EventHandler(this.User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelControl labUserName;
        private LabelControl labLoginName;
        private TextEdit txtUserName;
        private LabelControl labelControl1;
        private TextEdit txtLoginName;
        private LabelControl labelControl2;
        private MemoEdit memDescription;
        private LabelControl labMemo;
    }
}