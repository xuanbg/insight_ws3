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
            var resources = new ComponentResourceManager(typeof(OnlineUser));
            this.grdOnline = new GridControl();
            this.gdvOnline = new GridView();
            this.colUserName = new GridColumn();
            this.colLoginName = new GridColumn();
            this.colDeptName = new GridColumn();
            this.colMachineId = new GridColumn();
            this.colLastConnect = new GridColumn();
            ((ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((ISupportInitialize)(this.imgFolderNode)).BeginInit();
            ((ISupportInitialize)(this.imgCategoryNode)).BeginInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).BeginInit();
            ((ISupportInitialize)(this.grdOnline)).BeginInit();
            ((ISupportInitialize)(this.gdvOnline)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.grdOnline);
            this.panel.Size = new Size(770, 428);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new Point(690, 404);
            this.btnConfirm.Text = "关  闭";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new Point(600, 404);
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
            // grdOnline
            // 
            this.grdOnline.Dock = DockStyle.Fill;
            this.grdOnline.Location = new Point(2, 2);
            this.grdOnline.MainView = this.gdvOnline;
            this.grdOnline.Name = "grdOnline";
            this.grdOnline.Size = new Size(766, 424);
            this.grdOnline.TabIndex = 0;
            this.grdOnline.ViewCollection.AddRange(new BaseView[] {
            this.gdvOnline});
            // 
            // gdvOnline
            // 
            this.gdvOnline.BorderStyle = BorderStyles.NoBorder;
            this.gdvOnline.Columns.AddRange(new GridColumn[] {
            this.colUserName,
            this.colLoginName,
            this.colDeptName,
            this.colMachineId,
            this.colLastConnect});
            this.gdvOnline.GridControl = this.grdOnline;
            this.gdvOnline.Name = "gdvOnline";
            this.gdvOnline.OptionsFind.AlwaysVisible = true;
            this.gdvOnline.OptionsFind.FindNullPrompt = "输入关键字进行查询…";
            this.gdvOnline.KeyDown += new KeyEventHandler(this.gdvOnline_KeyDown);
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
            this.colMachineId.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.colMachineId.Caption = "用户设备码";
            this.colMachineId.FieldName = "MachineId";
            this.colMachineId.Name = "colMachineId";
            this.colMachineId.Visible = true;
            this.colMachineId.VisibleIndex = 3;
            // 
            // colLastConnect
            // 
            this.colLastConnect.AppearanceCell.Options.UseTextOptions = true;
            this.colLastConnect.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            this.colLastConnect.Caption = "最后在线时间";
            this.colLastConnect.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colLastConnect.DisplayFormat.FormatType = FormatType.DateTime;
            this.colLastConnect.FieldName = "LastConnect";
            this.colLastConnect.Name = "colLastConnect";
            this.colLastConnect.Visible = true;
            this.colLastConnect.VisibleIndex = 4;
            // 
            // OnlineUser
            // 
            this.ClientSize = new Size(784, 442);
            this.Name = "OnlineUser";
            this.Text = "在线用户";
            this.Load += new EventHandler(this.OnlineUser_Load);
            ((ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((ISupportInitialize)(this.imgFolderNode)).EndInit();
            ((ISupportInitialize)(this.imgCategoryNode)).EndInit();
            ((ISupportInitialize)(this.imgOrgTreeNode)).EndInit();
            ((ISupportInitialize)(this.grdOnline)).EndInit();
            ((ISupportInitialize)(this.gdvOnline)).EndInit();
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
