using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class Advertiser : MdiBase
    {

        #region 变量声明

        private List<BIZ_Advertiser> _Advertisers;

        #endregion

        #region 构造函数

        public Advertiser()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Advertiser_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitGrid();

            var canEdit = _Advertisers.Count > 0;
            SwitchItemStatus(new Context("EditAdvertisere", canEdit), new Context("DeleteAdvertiser", canEdit));
        }

        /// <summary>
        /// 所选行改变后刷新工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAdvertiser_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            SwitchItemStatus(new Context("EditAdvertisere", true), new Context("DeleteAdvertiser", true));
        }

        /// <summary>
        /// 双击编辑所选行轮播广告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAdvertiser_DoubleClick(object sender, EventArgs e)
        {
            if (gdvAdvertiser.FocusedRowHandle < 0) return;

            EditAdvertisere(true);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 
        /// </summary>
        private void InitGrid()
        {
            using (var cli = new ManagerClient(Binding, Address))
            {
                _Advertisers = cli.GetAdvertisers(UserSession);
            }

            grdAdvertiser.DataSource = _Advertisers;
            Format.GridFormat(gdvAdvertiser);
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

                case "NewAdvertiser":
                    EditAdvertisere(false);
                    break;

                case "EditAdvertisere":
                    EditAdvertisere(true);
                    break;

                case "DeleteAdvertiser":
                    DeleteAdvertiser();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑轮播广告
        /// </summary>
        /// <param name="isEdit"></param>
        private void EditAdvertisere(bool isEdit)
        {
            var obj = isEdit ? _Advertisers[gdvAdvertiser.FocusedRowHandle] : new BIZ_Advertiser();
            var dig = new AdvEdit
            {
                Owner = this,
                IsEdit = isEdit,
                Advertiser = obj
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitGrid();
            }
            dig.Close();
        }

        /// <summary>
        /// 删除轮播广告
        /// </summary>
        private void DeleteAdvertiser()
        {
            var obj = _Advertisers[gdvAdvertiser.FocusedRowHandle];
            if (General.ShowConfirm("您确定要删除所选的轮播图吗？数据删除后无法恢复。") != DialogResult.OK) return;

            using (var cli = new ManagerClient(Binding, Address))
            {
                if (!cli.DelAdvertiser(UserSession, obj.ID))
                {
                    General.ShowError("对不起，未能删除所选轮播图！如多次删除失败，请联系管理员。");
                    return;
                }
            }

            _Advertisers.Remove(obj);
            gdvAdvertiser.RefreshData();
        }

        #endregion

    }
}
