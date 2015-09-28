namespace Insight.WS.Client.XinFenBao
{
    partial class Reply
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reply));
            this.memMessage = new DevExpress.XtraEditors.MemoEdit();
            this.labMessage = new DevExpress.XtraEditors.LabelControl();
            this.labReturn = new DevExpress.XtraEditors.LabelControl();
            this.memReturn = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memReturn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.memReturn);
            this.panel.Controls.Add(this.labReturn);
            this.panel.Controls.Add(this.memMessage);
            this.panel.Controls.Add(this.labMessage);
            this.panel.Size = new System.Drawing.Size(370, 250);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(290, 274);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(200, 274);
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
            // memMessage
            // 
            this.memMessage.Enabled = false;
            this.memMessage.Location = new System.Drawing.Point(60, 20);
            this.memMessage.Name = "memMessage";
            this.memMessage.Size = new System.Drawing.Size(290, 100);
            this.memMessage.TabIndex = 1;
            // 
            // labMessage
            // 
            this.labMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labMessage.Location = new System.Drawing.Point(0, 20);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(60, 21);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "意见：";
            // 
            // labReturn
            // 
            this.labReturn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labReturn.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labReturn.Location = new System.Drawing.Point(0, 130);
            this.labReturn.Name = "labReturn";
            this.labReturn.Size = new System.Drawing.Size(60, 21);
            this.labReturn.TabIndex = 0;
            this.labReturn.Text = "回复：";
            // 
            // memReturn
            // 
            this.memReturn.Location = new System.Drawing.Point(60, 130);
            this.memReturn.Name = "memReturn";
            this.memReturn.Size = new System.Drawing.Size(290, 100);
            this.memReturn.TabIndex = 2;
            // 
            // Reply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Name = "Reply";
            this.Text = "回复";
            this.Load += new System.EventHandler(this.Reply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memReturn.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memMessage;
        private DevExpress.XtraEditors.LabelControl labMessage;
        private DevExpress.XtraEditors.MemoEdit memReturn;
        private DevExpress.XtraEditors.LabelControl labReturn;
    }
}