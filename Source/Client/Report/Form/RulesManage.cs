using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Report.Dialog;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report
{
    public partial class RulesManage : MdiBase
    {

        #region 变量声明

        private ReportClient _Client ;
        private DataTable _Rules;
        private bool _CanEdit;

        #endregion

        #region 构造方法

        public RulesManage()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        private void RulesManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitData();
        }

        private void gdvRule_DoubleClick(object sender, EventArgs e)
        {
            if (!_CanEdit) return;

            EditRule(true);
        }

        private void gdvRule_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _CanEdit = (int)gdvRule.GetFocusedDataRow()["Permission"] == 1 && !(bool)gdvRule.GetFocusedDataRow()["预置"];
            SwitchItemStatus(new Context("EditRule", _CanEdit), new Context("DeleteRule", _CanEdit));
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载所有分期规则
        /// </summary>
        private void InitData()
        {
            _Client = new ReportClient(Binding, Address);
            _Rules = _Client.GetRules(UserSession);
            _Client.Close();

            grdRule.DataSource = _Rules;
            Format.GridFormat(gdvRule);
            gdvRule.Columns[2].Width = 240;
            gdvRule.Columns[3].Width = 80;
            gdvRule.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvRule.Columns[4].Width = 80;
            gdvRule.Columns[5].Width = 482;
        }

        #endregion

        #region 按钮事件

        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitData();
                    break;

                case "NewRule":
                    EditRule(false);
                    break;

                case "EditRule":
                    EditRule(true);
                    break;

                case "DeleteRule":
                    DeleteRule();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑分期规则
        /// </summary>
        private void EditRule(bool isEdit)
        {
            var fr = gdvRule.FocusedRowHandle;
            var dig = new EditRule
            {
                Owner = this,
                ObjectId = (Guid) gdvRule.GetFocusedDataRow()["ID"],
                IsEdit = isEdit
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitData();
                gdvRule.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除分期规则
        /// </summary>
        private void DeleteRule()
        {
            var row = gdvRule.GetDataRow(gdvRule.FocusedRowHandle);
            if (General.ShowConfirm(string.Format("您确定要删除分期规则【{0}】吗?", row["名称"])) != DialogResult.OK) return;

            _Client = new ReportClient(Binding, Address);
            if (_Client.DelRule(UserSession, (Guid)row["ID"]))
            {
                gdvRule.DeleteRow(gdvRule.FocusedRowHandle);
            }
            else
            {
                General.ShowError(string.Format("对不起，分期规则【{0}】已经被使用，无法删除该规则！", row["名称"]));
            }
            _Client.Close();
        }

        #endregion

    }
}
