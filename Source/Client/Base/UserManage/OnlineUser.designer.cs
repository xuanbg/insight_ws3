using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Insight.WS.Client.Platform.Base
{
    partial class OnlineUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineUser));
            this.grdOnline = new DevExpress.XtraGrid.GridControl();
            this.gdvOnline = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastConnect = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOnline)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.grdOnline);
            this.panel.Size = new System.Drawing.Size(770, 428);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(690, 404);
            this.btnConfirm.Text = "关  闭";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(600, 404);
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
            // grdOnline
            // 
            this.grdOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOnline.Location = new System.Drawing.Point(2, 2);
            this.grdOnline.MainView = this.gdvOnline;
            this.grdOnline.Name = "grdOnline";
            this.grdOnline.Size = new System.Drawing.Size(766, 424);
            this.grdOnline.TabIndex = 0;
            this.grdOnline.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvOnline});
            // 
            // gdvOnline
            // 
            this.gdvOnline.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gdvOnline.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colLoginName,
            this.colDeptName,
            this.colMachineId,
            this.colLastConnect});
            this.gdvOnline.GridControl = this.grdOnline;
            this.gdvOnline.Name = "gdvOnline";
            this.gdvOnline.OptionsFind.AlwaysVisible = true;
            this.gdvOnline.OptionsFind.FindNullPrompt = "输入关键字进行查询…";
            this.gdvOnline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdvOnline_KeyDown);
            // 
            // colUserName
            // 
            this.colUserName.Caption = "用户名";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colLoginName
            // 
            this.colLoginName.Caption = "登录账号";
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 1;
            // 
            // colDeptName
            // 
            this.colDeptName.Caption = "登录部门";
            this.colDeptName.FieldName = "DeptName";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.Visible = true;
            this.colDeptName.VisibleIndex = 2;
            // 
            // colMachineId
            // 
            this.colMachineId.AppearanceCell.Options.UseTextOptions = true;
            this.colMachineId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMachineId.Caption = "用户设备码";
            this.colMachineId.FieldName = "MachineId";
            this.colMachineId.Name = "colMachineId";
            this.colMachineId.Visible = true;
            this.colMachineId.VisibleIndex = 3;
            // 
            // colLastConnect
            // 
            this.colLastConnect.AppearanceCell.Options.UseTextOptions = true;
            this.colLastConnect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastConnect.Caption = "最后在线时间";
            this.colLastConnect.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.colLastConnect.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastConnect.FieldName = "LastConnect";
            this.colLastConnect.Name = "colLastConnect";
            this.colLastConnect.Visible = true;
            this.colLastConnect.VisibleIndex = 4;
            // 
            // OnlineUser
            // 
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Name = "OnlineUser";
            this.Text = "在线用户";
            this.Load += new System.EventHandler(this.OnlineUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOnline)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl grdOnline;
        private GridView gdvOnline;
        private GridColumn colUserName;
        private GridColumn colLoginName;
        private GridColumn colDeptName;
        private GridColumn colLastConnect;
        private GridColumn colMachineId;
    }
}
