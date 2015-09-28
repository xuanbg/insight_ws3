using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class FeedbackManage : MdiBase
    {

        #region 变量声明

        private DataTable _TreeData;
        private DataTable _FilterFeed;
        private DataTable _SearchFeed;
        private DataView _FeedBacks;
        private bool _HasFeed;

        #endregion

        #region 构造函数

        public FeedbackManage()
        {
            InitializeComponent();
            treDate.CustomDrawNodeImages += Format.CustomDrawNodeTypeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeedbackManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitDateTree();
        }

        /// <summary>
        /// 日期树所选节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treDate_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            GetReceipts();
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
        /// 清除关键字后按日期加载列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bteSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bteSearch.EditValue = null;
            _FeedBacks = _FilterFeed.DefaultView;
            InitGrid();
        }

        /// <summary>
        /// 根据关键字查询意见反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 所选行变化刷新工具栏状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvFeedback_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (!_HasFeed) return;

            var row = gdvFeedback.GetFocusedDataRow();
            var canReply = _HasFeed && row["状态"].ToString() != "已归档";
            var canPige = row["状态"].ToString() == "已解决";
            SwitchItemStatus(new Context("Reply", canReply), new Context("Pigeonhole", canPige));
        }

        /// <summary>
        /// 双击回复意见
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvFeedback_DoubleClick(object sender, EventArgs e)
        {
            if (_HasFeed) Reply();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化意见反馈日期树
        /// </summary>
        private void InitDateTree()
        {
            using (var cli = new ManagerClient(Binding, Address))
            {
                _TreeData = cli.GetFeedbackDate(UserSession);
            }

            treDate.DataSource = _TreeData;
            Format.TreeFormat(treDate);
        }

        /// <summary>
        /// 初始化意见反馈列表
        /// </summary>
        private void InitGrid()
        {
            _HasFeed = _FeedBacks.Count > 0;
            SwitchItemStatus(new Context("Reply", _HasFeed), new Context("Pigeonhole", _HasFeed));

            grdFeedback.DataSource = _FeedBacks;
            Format.GridFormat(gdvFeedback);
            gdvFeedback.Columns["客户姓名"].Width = 100;
            gdvFeedback.Columns["手机号"].Width = 100;
            gdvFeedback.Columns["意见"].Width = 590;
            gdvFeedback.Columns["状态"].Width = 60;
        }

        /// <summary>
        /// 根据日期查询意见反馈
        /// </summary>
        private void GetReceipts()
        {
            if ((int)treDate.FocusedNode.GetValue("Type") != 2) return;

            using (var cli = new ManagerClient(Binding, Address))
            {
                _FilterFeed = cli.GetFeedBacksForDate(UserSession, treDate.FocusedNode.GetValue("ID").ToString());
            }

            bteSearch.EditValue = null;
            _FeedBacks = _FilterFeed.DefaultView;
            InitGrid();
        }

        /// <summary>
        /// 根据关键字查询意见反馈
        /// </summary>
        private void Search()
        {
            using (var cli = new ManagerClient(Binding, Address))
            {
                _SearchFeed = cli.GetFeedBacksForName(UserSession, bteSearch.Text.Trim());
            }

            _FeedBacks = _SearchFeed.DefaultView;
            InitGrid();
        }

        #endregion

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
                    InitDateTree();
                    break;

                case "Reply":
                    Reply();
                    break;

                case "Pigeonhole":
                    Pigeonhole(); 
                    break;
            }
        }

        /// <summary>
        /// 回复意见
        /// </summary>
        private void Reply()
        {
            var dig = new Reply() 
            {
                Owner = this,
                ObjectId = (Guid) gdvFeedback.GetFocusedDataRow()["ID"]
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitGrid();
            }
            dig.Close();
        }

        /// <summary>
        /// 意见归档
        /// </summary>
        private void Pigeonhole()
        {
            var dig = new Pigeonhole()
            {
                Owner = this,
                ObjectId = (Guid)gdvFeedback.GetFocusedDataRow()["ID"]
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitGrid();
            }
            dig.Close();
        }

        #endregion

    }
}
