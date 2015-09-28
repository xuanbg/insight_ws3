using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class PlanManage : MdiBase
    {

        #region 变量声明

        private List<BIZ_StagePlan> _StagePlans;

        #endregion

        #region 构造函数

        public PlanManage()
        {
            InitializeComponent();

            var userType = new DataTable("Table");
            userType.Columns.AddRange(new[]{
                new DataColumn("ID", typeof(int)),
                new DataColumn("Name", typeof(string)) });
            userType.Rows.Add(-1, "市场版用户");
            userType.Rows.Add(-5, "信分宝用户");
            userType.Rows.Add(-9, "行业版用户");

            Format.InitLookUpEdit(rleUserType, userType);
            rleUserType.Columns["Name"].Alignment = HorzAlignment.Center;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体启动时初始化用户界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitGrid();
        }

        /// <summary>
        /// 所选行改变后同步工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvPlan_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            var obj = _StagePlans[e.FocusedRowHandle];
            SwitchItemStatus(new Context("DeletePlan", true), new Context("SetDefault", obj.Validity || obj.InvalidDate == null));
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化分期方案列表
        /// </summary>
        private void InitGrid()
        {
            using (var cli = new ManagerClient(Binding, Address))
            {
                _StagePlans = cli.GetStagePlans(UserSession);
            }

            _StagePlans.ForEach(p => p.Validity = p.EffectiveDate < DateTime.Now && (p.InvalidDate == null || p.InvalidDate > DateTime.Now));
            grdPlan.DataSource = _StagePlans;
            Format.GridFormat(gdvPlan);
            gdvPlan.Columns["UserType"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            var candel = _StagePlans.Count > 0;
            SwitchItemStatus(new Context("DeletePlan", candel), new Context("SetDefault", candel));
            if (!candel) return;

            var obj = _StagePlans[gdvPlan.FocusedRowHandle];
            SwitchItemStatus(new Context("SetDefault", obj.Validity || obj.InvalidDate == null));
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
                    InitGrid();
                    break;

                case "NewPlan":
                    NewPlan();
                    break;

                case "DeletePlan":
                    DeletePlan();
                    break;

                case "SetDefault":
                    SetDefault();
                    break;
            }
        }

        /// <summary>
        /// 新建分期方案
        /// </summary>
        private void NewPlan()
        {
            var dig = new StagePlan
            {
                Owner = this,
                StagePlans = _StagePlans
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitGrid();
            }
            dig.Close();
        }

        /// <summary>
        /// 删除分期方案
        /// </summary>
        private void DeletePlan()
        {
            var obj = _StagePlans[gdvPlan.FocusedRowHandle];
            if (General.ShowConfirm("您确定要删除所选的分期方案吗？数据删除后无法恢复。") != DialogResult.OK) return;

            using (var cli = new ManagerClient(Binding, Address))
            {
                if (!cli.DeletePlan(UserSession, obj.ID))
                {
                    General.ShowError("对不起，未能删除所选分期方案！如多次删除失败，请联系管理员。");
                    return;
                }

                InitGrid();
            }
        }

        /// <summary>
        /// 设置选中方案为默认方案
        /// </summary>
        private void SetDefault()
        {
            var obj = _StagePlans[gdvPlan.FocusedRowHandle];
            if (General.ShowConfirm("您确定要所选的分期方案设置为默认分期方案吗？") != DialogResult.OK) return;

            using (var cli = new ManagerClient(Binding, Address))
            {
                if (!cli.SetDefault(UserSession, obj.ID))
                {
                    General.ShowError("对不起，未能设置所选分期方案为默认方案！如多次删除失败，请联系管理员。");
                    return;
                }

                InitGrid();
            }
        }

        #endregion

    }
}