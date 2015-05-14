using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace Insight.WS.Client.Platform.Base
{
    partial class NodeMerge
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeMerge));
            var serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.trlOrgList = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treOrg = new DevExpress.XtraTreeList.TreeList();
            this.labTargetNode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlOrgList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrg)).BeginInit();
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
            this.panel.Controls.Add(this.trlOrgList);
            this.panel.Controls.Add(this.labTargetNode);
            // 
            // tllOrgList
            // 
            this.trlOrgList.Location = new System.Drawing.Point(80, 60);
            this.trlOrgList.Name = "tllOrgList";
            this.trlOrgList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("tllOrgList.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.trlOrgList.Properties.NullText = "请选择目标节点…";
            this.trlOrgList.Properties.PopupFormSize = new System.Drawing.Size(270, 150);
            this.trlOrgList.Properties.TreeList = this.treOrg;
            this.trlOrgList.Size = new System.Drawing.Size(270, 22);
            this.trlOrgList.TabIndex = 1;
            this.trlOrgList.EditValueChanged += new System.EventHandler(this.tlOrgList_EditValueChanged);
            // 
            // treOrg
            // 
            this.treOrg.Location = new System.Drawing.Point(-19, -25);
            this.treOrg.Name = "treOrg";
            this.treOrg.OptionsBehavior.EnableFiltering = true;
            this.treOrg.OptionsView.ShowColumns = false;
            this.treOrg.Size = new System.Drawing.Size(485, 200);
            this.treOrg.TabIndex = 0;
            // 
            // labTargetNode
            // 
            this.labTargetNode.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTargetNode.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labTargetNode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labTargetNode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTargetNode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTargetNode.Location = new System.Drawing.Point(0, 60);
            this.labTargetNode.Name = "labTargetNode";
            this.labTargetNode.Size = new System.Drawing.Size(80, 21);
            this.labTargetNode.TabIndex = 0;
            this.labTargetNode.Text = "目标节点：";
            // 
            // NodeMerge
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.ControlBox = false;
            this.Name = "NodeMerge";
            this.Text = "合并";
            this.Load += new System.EventHandler(this.Merge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlOrgList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeListLookUpEdit trlOrgList;
        private TreeList treOrg;
        private LabelControl labTargetNode;
    }
}