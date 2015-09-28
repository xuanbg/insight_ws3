using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.XinFenBao.Service;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;

namespace Insight.WS.Client.XinFenBao
{
    public partial class MemberManage : MdiBase
    {

        private DataTable _TreeData;
        private DataTable _FilterFeed;
        private DataTable _SearcFeed;
        private DataView _CheckBacks;
        private DataView _CheckPendingList;
        private DataTable _CheckPendingFeed;
        private bool _HasFeed;
        

        public MemberManage()
        {
            InitializeComponent();
            treDate.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitDataTree();
            GetUnauditedGrig();
        }

        /// <summary>
        /// 根据关键字查询授信情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender,EventArgs e)
        {
            Search();
        }
        /// <summary>
        /// 搜索框按回车键进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        /// <summary>
        /// 日期树所选节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treDate_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e )
        {
            GetReceipts();
        }

        /// <summary>
        /// 清除关键字后按一起加载列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            _CheckBacks = _FilterFeed.DefaultView;
            InitGrid();
        }


        /// <summary>
        /// 初始化授信管理日期树
        /// </summary>
        private void InitDataTree()
        {
            using (var cli = new ManagerClient (Binding, Address))
            {
                _TreeData = cli.GetCheckListDate(UserSession);
            }
            treDate.DataSource = _TreeData;
            Format.TreeFormat(treDate);
        }

    


        /// <summary>
        /// 初始化授信管理授信列表
        /// </summary>
        private void InitGrid()
        {
            _HasFeed = _CheckBacks.Count > 0;
            //SwitchItemStatus(new Context("Reply", _HasFeed), new Context("Pigeonhole", _HasFeed));
            grdMember.DataSource = _CheckBacks;

            Format.GridFormat(gdvMember);
            gdvMember.Columns["客户类型"].Width = 62;
            gdvMember.Columns["手机号"].Width = 90;
            gdvMember.Columns["姓名"].Width = 60;
            gdvMember.Columns["身份证号"].Width = 195;
            gdvMember.Columns["工作单位/学校"].Width = 234;
            gdvMember.Columns["授信额度"].Width = 80;
            gdvMember.Columns["审核内容"].Width = 70;
            gdvMember.Columns["状态"].Width = 60;
        }

        /// <summary>
        /// 根据日期查询授信列表信息
        /// </summary>
        private void GetReceipts()
        {
            if ((int)treDate.FocusedNode.GetValue("Type") != 2) return;

            using (var cli = new ManagerClient(Binding, Address))
            {
                _FilterFeed = cli.GetCheckListForDate(UserSession, treDate.FocusedNode.GetValue("ID").ToString());
            }
            bteSearch.EditValue = null;
            _CheckBacks = _FilterFeed.DefaultView;
            InitGrid();
        }

        /// <summary>
        /// 根据手机号查询审核列表
        /// </summary>
        private void  Search()
        {
            using (var cli = new ManagerClient(Binding, Address))
            {
                _SearcFeed = cli.GetCheckListForName(UserSession, bteSearch.Text.Trim());
            }

            _CheckBacks = _SearcFeed.DefaultView;
            InitGrid();
        }

        /// <summary>
        /// 获取待审核列表
        /// </summary>
        private void GetUnauditedGrig()
        {
            
            using (var cli = new ManagerClient(Binding, Address))
            {
                _CheckPendingFeed = cli.GetAuditList(UserSession);
            }
            grdTask.DataSource = _CheckPendingFeed;

            Format.GridFormat(gdvTask);
            gdvTask.Columns["客户类型"].Width = 62;
            gdvTask.Columns["手机号"].Width = 90;
            gdvTask.Columns["姓名"].Width = 60;
            gdvTask.Columns["身份证号"].Width = 195;
            gdvTask.Columns["工作单位/学校"].Width = 234;
            gdvTask.Columns["授信额度"].Width = 80;
            gdvTask.Columns["审核内容"].Width = 70;
            gdvTask.Columns["状态"].Width = 60;
        }

        #region 按钮事件

        /// <summary>
        /// 工具栏按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name) 
            {
                case "Refresh":
                    InitDataTree();
                    break;

                case "Apply":
                    GetUnauditedGrig();
                    break;

                case "Subjoin":
                    GetUnauditedGrig();
                    break;

                case "SwitchView":
                    grdTask.Visible = grdTask.Visible == false;
                    break;
            }
        }

        #endregion

    }
}
