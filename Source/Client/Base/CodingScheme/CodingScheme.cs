using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class CodingScheme : MdiBase
    {

        #region 变量声明

        private DataTable _Schemes;
        private DataTable _Record;
        private DataTable _Allot;
        private Guid _ObjectId = Guid.Empty;
        private bool _HasScheme;
        private bool _HasRecord;
        private bool _HasAllot;
        private bool _CanEdit;
        private bool _IsEnable;

        #endregion

        #region 构造方法

        public CodingScheme()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时初始化工具条及界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodingScheme_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitScheme();
            if (!_HasScheme)
            {
                SwitchItemStatus(new Context("EditScheme", false), new Context("DeleteScheme", false), new Context("Enable", false), new Context("Allot", false), new Context("Cancel", false), new Context("Clear", false));
            }
        }

        /// <summary>
        /// 编码方案列表所选行改变后刷新工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvScheme_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _ObjectId = _HasScheme ? (Guid)gdvScheme.GetFocusedDataRow()["ID"] : Guid.Empty;
            _CanEdit = _HasScheme && (int)gdvScheme.GetFocusedDataRow()["Permission"] == 1;
            _IsEnable = _HasScheme && gdvScheme.GetFocusedDataRow()["状态"].ToString() == "正常";
            SwitchItemStatus(new Context("EditScheme", _CanEdit), new Context("DeleteScheme", _CanEdit&& _IsEnable), new Context("Enable", _CanEdit && !_IsEnable), new Context("Allot", _CanEdit), new Context("Cancel", false), new Context("Clear", false));
            InitRecord();
            InitAllot();
        }

        /// <summary>
        /// 双击编码方案列表编辑所选方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvScheme_DoubleClick(object sender, EventArgs e)
        {
            var enable = barManager.Items["Enable"];
            var edit = barManager.Items["EditScheme"];
            if (enable.Enabled)
            {
                Enable();
            }
            else if (edit.Enabled)
            {
                EditScheme(true);
            }
        }

        /// <summary>
        /// 编码分组列表所选行改变后刷新工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvCode_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var canClear = _HasRecord && (int)gdvCode.GetFocusedDataRow()["记录数"] > 10000;
            SwitchItemStatus(new Context("Clear", canClear));
        }

        /// <summary>
        /// 分配号段列表所选行改变后刷新工具栏按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvAllot_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            var canCancel = _HasAllot && gdvAllot.GetFocusedDataRow()["状态"].ToString() == "未用";
            SwitchItemStatus(new Context("Cancel", canCancel));
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化编码方案列表
        /// </summary>
        private void InitScheme()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Schemes = cli.GetSchemes(UserSession);
                _Record = cli.GetSerialRecord(UserSession);
                _Allot = cli.GetAllotRecord(UserSession);
                _HasScheme = _Schemes.Rows.Count > 0;
            }

            grdScheme.DataSource = _Schemes;
            Format.GridFormat(gdvScheme);
            gdvScheme.Columns["名称"].Width = 200;
            gdvScheme.Columns["编码格式"].Width = 160;
            gdvScheme.Columns["分组规则"].Width = 80;
            gdvScheme.Columns["描述"].Width = 456;

            if (!_HasScheme)
            {
                InitRecord();
                InitAllot();
            }
        }

        /// <summary>
        /// 初始化流水码使用记录列表
        /// </summary>
        private void InitRecord()
        {
            var dv = _Record.Copy().DefaultView;
            dv.RowFilter = $"SchemeId = '{_ObjectId}'";
            _HasRecord = dv.Count > 0;

            grdCode.DataSource = dv;
            Format.GridFormat(gdvCode);
            gdvCode.Columns["分组标识"].Width = 200;
            gdvCode.Columns["当前流水"].Width = 80;
            gdvCode.Columns["当前流水"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gdvCode.Columns["记录数"].Width = 80;
            gdvCode.Columns["记录数"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        /// <summary>
        /// 初始化编码分配记录
        /// </summary>
        private void InitAllot()
        {
            var dv = _Allot.Copy().DefaultView;
            dv.RowFilter = $"SchemeId = '{_ObjectId}'";
            _HasAllot = dv.Count > 0;

            grdAllot.DataSource = dv;
            Format.GridFormat(gdvAllot);
            gdvAllot.Columns["制单人员"].Width = 80;
            gdvAllot.Columns["单据类型"].Width = 160;
            gdvAllot.Columns["编码区段"].Width = 126;
            gdvAllot.Columns["编码区段"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
        }

        #endregion

        #region 工具栏方法

        /// <summary>
        /// 工具栏按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitScheme();
                    break;

                case "NewScheme":
                    EditScheme(false);
                    break;

                case "EditScheme":
                    EditScheme(true);
                    break;

                case "DeleteScheme":
                    DelScheme();
                    break;

                case "Enable":
                    Enable();
                    break;

                case "Allot":
                    AllotSerial();
                    break;

                case "Cancel":
                    CancelAllot();
                    break;

                case "Clear":
                    ClearRecord();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑编码方案
        /// </summary>
        /// <param name="isEdit"></param>
        private void EditScheme(bool isEdit)
        {
            var focused = gdvScheme.GetFocusedDataSourceRowIndex();
            var dig = new CodeScheme
            {
                Owner = this,
                IsEdit = isEdit,
                ObjectId = _ObjectId
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitScheme();
                gdvScheme.FocusedRowHandle = focused;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除编码方案，如不能删除，则停用
        /// </summary>
        private void DelScheme()
        {
            var row = gdvScheme.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除编码方案【{row["名称"]}】吗？") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                switch (cli.DeleteScheme(UserSession, (Guid) row["ID"]))
                {
                    case 0:
                        General.ShowError("对不起，数据操作失败！如多次操作失败，请联系管理员。");
                        break;

                    case 1:
                        General.ShowMessage($"编码方案【{row["名称"]}】删除成功！");
                        gdvScheme.DeleteRow(gdvScheme.FocusedRowHandle);
                        break;

                    case 2:
                        General.ShowMessage($"对不起，编码方案【{row["名称"]}】已被使用，该编码方案已被设置为停用状态！");
                        gdvScheme.SetFocusedRowCellValue("状态", "停用");
                        SwitchItemStatus(new Context("DeleteScheme", false), new Context("Enable", true));
                        break;
                }
            }
        }

        /// <summary>
        /// 启用已停用编码方案
        /// </summary>
        private void Enable()
        {
            var row = gdvScheme.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要启用编码方案【{row["名称"]}】吗？") != DialogResult.OK) return;

            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.EnableScheme(UserSession, (Guid) row["ID"]))
                {
                    General.ShowError($"编码方案【{row["名称"]}】启用失败！如多次操作失败，请联系管理员。");
                    return;
                }
                
                General.ShowMessage($"编码方案【{row["名称"]}】启用成功！");
                gdvScheme.SetFocusedRowCellValue("状态", "正常");
                SwitchItemStatus(new Context("DeleteScheme", true), new Context("Enable", false));
            }
        }

        /// <summary>
        /// 分配流水号段
        /// </summary>
        private void AllotSerial()
        {

        }

        /// <summary>
        /// 取消已分配流水号段
        /// </summary>
        private void CancelAllot()
        {

        }

        /// <summary>
        /// 清理过期流水记录
        /// </summary>
        private void ClearRecord()
        {

        }

        #endregion

    }
}
