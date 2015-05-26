using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    public partial class InstantReport : DialogBase
    {

        #region 属性

        /// <summary>
        /// 即时报表是否能被保存
        /// </summary>
        public bool CanSave { get; set; }

        /// <summary>
        /// 报表名称
        /// </summary>
        public string ReportName { get; set; }

        /// <summary>
        /// 报表内容
        /// </summary>
        public byte[] Content { get; set; }

        #endregion

        #region 变量声明

        private SYS_Report_Definition _Definition;
        private DataTable _ReportEntitys;

        #endregion

        #region 构造函数

        public InstantReport()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 根据报表类型、当前用户初始化窗体控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDig_Load(object sender, EventArgs e)
        {
            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                _ReportEntitys = cli.GetMyReportEntitys(OpenForm.UserSession, ObjectId);
                _Definition = cli.GetDefinition(OpenForm.UserSession, ObjectId);
            }

            txtReport.Text = _Definition.Name;
            lokEntitys.Properties.ValueMember = "ID";
            lokEntitys.Properties.DisplayMember = "FullName";
            lokEntitys.Properties.DataSource = _ReportEntitys;
            lokEntitys.Properties.PopulateColumns();
            lokEntitys.Properties.Columns[0].Visible = false;
            lokEntitys.ItemIndex = 0;

            datBegin.Enabled = (_Definition.Mode == 1 ||(_Definition.Mode == 2 && _Definition.Delay < 0));
            datEnd.Enabled = (_Definition.Mode == 1 ||(_Definition.Mode == 2 && _Definition.Delay >= 0));
            if (datBegin.Enabled) datBegin.DateTime = _Definition.Delay < 0 ? DateTime.Today.AddDays(1) : DateTime.Today.AddDays(1).AddMonths(-1);
            if (datEnd.Enabled) datEnd.DateTime = _Definition.Delay < 0 ? DateTime.Today.AddMonths(1) : DateTime.Today;
        }

        private void datBegin_EditValueChanged(object sender, EventArgs e)
        {
            if (datBegin.EditValue == null) return;

            datEnd.Properties.MinValue = datBegin.DateTime;
        }

        private void datEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (datEnd.EditValue == null) return;

            datBegin.Properties.MaxValue = datEnd.DateTime;
        }

        #endregion

        #region 重写虚方法

        /// <summary>
        /// 点击确定后通过窗体属性返回生成报表要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            var sd = datBegin.Enabled ? (DateTime?)datBegin.DateTime.Date : null;
            var ed = datEnd.Enabled ? (DateTime?)datEnd.DateTime.Date : null;
            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                try
                {
                    var instance = cli.BulidReport(OpenForm.UserSession, ObjectId, sd, ed, lokEntitys.Text, (Guid) lokEntitys.EditValue);
                    CanSave = true;
                    ReportName = instance.Name;
                    Content = instance.Content;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch
                {
                    General.ShowError("对不起，生成报表失败！如多次生成失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
