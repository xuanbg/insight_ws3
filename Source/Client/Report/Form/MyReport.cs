using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using FastReport;
using FastReport.Preview;
using FastReport.Utils;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Dialog;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report
{
    public partial class MyReport : MdiBase
    {

        #region 变量声明

        private DataTable _Reports;
        private DataTable _Instances;
        private SYS_Report_Instances _Instanc;
        private PreviewControl _Preview;

        #endregion

        #region 构造函数

        public MyReport()
        {
            InitializeComponent();

            treReports.CustomDrawNodeImages += Format.CustomDrawItemNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyReport_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitReport();
        }

        /// <summary>
        /// 所选报表变化后刷新报表实例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlReports_EditValueChanged(object sender, EventArgs e)
        {
            if (!(bool)treReports.FocusedNode.GetValue("IsData"))
            {
                trlReports.EditValue = null;
                datStart.Enabled = false;
                datEnd.Enabled = false;
                grlInstances.EditValue = null;
                grlInstances.Enabled = false;
                btnOpen.Enabled = false;
                SwitchItemStatus(new Context("Bulid", false));
            }

            if (trlReports.EditValue != null)
            {
                SwitchItemStatus(new Context("Bulid", true));
                InitInstance();
            }
        }

        /// <summary>
        /// 开始日期变化后刷新截止日期的最小值和实例列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDateChanged(object sender, EventArgs e)
        {
            if (datStart.EditValue != null)
            {
                datEnd.Properties.MinValue = datStart.DateTime;
            }

            if (_Instances != null)
            {
                RefreshList();
            }
        }

        /// <summary>
        /// 截止日期变化后刷新开始日期的最大值和实例列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndDateChanged(object sender, EventArgs e)
        {
            if (datEnd.EditValue != null)
            {
                datStart.Properties.MaxValue = datEnd.DateTime;
            }

            if (_Instances != null)
            {
                RefreshList();
            }
        }

        /// <summary>
        /// 报表预览窗口标签切换时根据内容切换保存和打印按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            tabControl.Enabled = tabControl.TabPages.Count > 0;
            SwitchItemStatus(new Context("Save", e.Page != null && (bool)e.Page.Tag), new Context("Print", tabControl.TabPages.Count > 0));
        }

        /// <summary>
        /// 关闭报表标签页时提示保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            var control = sender as XtraTabControl;
            var arg = e as ClosePageButtonEventArgs;
            var page = arg.Page as XtraTabPage;
            if ((bool)page.Tag)
            {
                var result = General.ShowQuestion(string.Format("{0} 尚未保存，是否需要保存？", page.Text));
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;

                    case DialogResult.Yes:
                        Save();
                        break;
                }
            }
            control.TabPages.Remove(page);
        }

        /// <summary>
        /// 获取所选报表实例并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var cli = new ReportClient(Binding, Address))
            {
                _Instanc = cli.GetReportInstance(UserSession, (Guid) grlInstances.EditValue);
            }

            ViewReport(false);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitReport()
        {
            using (var cli = new ReportClient(Binding, Address))
            {
                _Reports = cli.GetMyReports(UserSession);
                _Instances = cli.GetInstances(UserSession);
            }

            Format.InitTreeListLookUpEdit(trlReports, _Reports);

            // 初始化查询条件
            datStart.DateTime = DateTime.Now.AddDays(1).AddMonths(-1);
            datEnd.DateTime = DateTime.Now;

            panTop.Enabled = _Reports.Rows.Count > 0;
            var selected = trlReports.EditValue != null;
            SwitchItemStatus(new Context("Bulid", selected), new Context("Delete", false));
            InitInstance();
        }

        /// <summary>
        /// 初始化报表实例下拉列表
        /// </summary>
        private void InitInstance()
        {
            var dv = _Instances.Copy().DefaultView;
            var filter = string.Format("ReportId = '{0}'", trlReports.EditValue);
            dv.RowFilter = filter;

            var hasInstances = dv.Count > 0;
            var hasView = tabControl.TabPages.Count > 0;
            SwitchItemStatus(new Context("Save", hasView && (bool)tabControl.SelectedTabPage.Tag), new Context("Print", hasView));
            datStart.Enabled = hasInstances;
            datEnd.Enabled = hasInstances;

            RefreshList();
        }

        /// <summary>
        /// 刷新报表实例下拉列表
        /// </summary>
        private void RefreshList()
        {
            var dv = _Instances.Copy().DefaultView;
            var filter = string.Format("ReportId = '{0}' and CreateTime >= '{1}' and CreateTime < '{2}'", trlReports.EditValue, datStart.DateTime.Date, datEnd.DateTime.AddDays(1).Date);
            dv.RowFilter = filter;
            var hasInstance = dv.Count > 0;

            Format.InitGridLookUpEdit(grlInstances, dv);
            gdvInstances.Columns["Name"].Width = 400;
            gdvInstances.Columns["CreateTime"].Visible = false;
            grlInstances.Enabled = hasInstance;
            grlInstances.EditValue = hasInstance ? dv.ToTable().Rows[0]["ID"] : null;
            btnOpen.Enabled = hasInstance;
            SwitchItemStatus(new Context("Delete", hasInstance));
        }

        /// <summary>
        /// 在预览窗口显示报表
        /// </summary>
        private void ViewReport(bool isNew)
        {
            foreach (XtraTabPage page in tabControl.TabPages)
            {
                if (page.Name == _Instanc.ID.ToString())
                {
                    tabControl.SelectedTabPage = page;
                    return;
                }
            }

            _Preview = new PreviewControl
            {
                Name = _Instanc.ID.ToString(),
                Tag = _Instanc.ReportId,
                BackColor = SystemColors.AppWorkspace,
                Buttons = (barManager.Items["Export"].Enabled
                    ? PreviewButtons.Save
                    : PreviewButtons.None)
                          | PreviewButtons.Find
                          | PreviewButtons.Zoom
                          | PreviewButtons.Outline
                          | PreviewButtons.Navigator,
                Dock = DockStyle.Fill,
                Font = new Font("宋体", 9F),
                TabIndex = 1,
                UIStyle = UIStyle.Office2007Silver
            };

            var tabPage = new XtraTabPage
            {
                Name = _Instanc.ID.ToString(),
                Text = _Instanc.Name,
                Tag = isNew
            };
            tabPage.Controls.Add(_Preview);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTabPage = tabPage;

            _Preview.Load(new MemoryStream(_Instanc.Content));
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 重载菜单列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitReport();
                    break;

                case "Bulid":
                    Bulid();
                    break;

                case "Print":
                    Print();
                    break;

                case "Save":
                    Save();
                    break;

                case "Delete":
                    Delete();
                    break;
            }
        }

        /// <summary>
        /// 生成即时报表
        /// </summary>
        private void Bulid()
        {
            var dig = new InstantReport
            {
                Owner = this,
                ObjectId = (Guid) trlReports.EditValue
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                _Instanc = new SYS_Report_Instances
                {
                    ID = Guid.NewGuid(),
                    ReportId = dig.ObjectId,
                    Name = dig.ReportName,
                    Content = dig.Content
                };
                ViewReport(dig.CanSave);
            }
            dig.Close();
        }

        /// <summary>
        /// 保存即时报表
        /// </summary>
        private void Save()
        {
            var page = tabControl.SelectedTabPage;
            var ctl = page.Controls.Find(page.Name, false);
            var view = (PreviewControl)ctl[0];

            Stream stream = new MemoryStream();
            view.Save(stream);
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);

            _Instanc = new SYS_Report_Instances
            {
                ReportId = (Guid) view.Tag,
                Name = page.Text,
                Content = bytes
            };

            using (var cli = new ReportClient(Binding, Address))
            {
                var obj = cli.AddInstance(UserSession, _Instanc);
                if (obj == null)
                {
                    General.ShowError(string.Format("对不起， {0} 保存失败！\r\n如多次保存失败，请联系管理员。", _Instanc.Name));
                    return;
                }

                General.ShowMessage(string.Format("{0} 已保存！", _Instanc.Name));

                view.Name = obj.InstanceId.ToString();
                page.Name = obj.InstanceId.ToString();
                page.Tag = false;

                var row = _Instances.NewRow();
                row.ItemArray = new[] {obj.InstanceId, page.Text, view.Tag, DateTime.Now, obj.ID};
                _Instances.Rows.InsertAt(row, 0);
                InitInstance();
            }
        }

        /// <summary>
        /// 删除报表实例和用户关系
        /// </summary>
        private void Delete()
        {
            var str = string.Format("您是否要删除报表期次：\r\n    {0} ？\r\n报表删除后将无法继续查看。", grlInstances.Text);
            if (General.ShowConfirm(str) != DialogResult.OK) return;

            using (var cli = new ReportClient(Binding, Address))
            {
                var result = cli.DeleteReportIU(UserSession, (Guid) _Instances.Rows.Find(grlInstances.EditValue)["RID"]);
                if (!result)
                {
                    General.ShowError(string.Format("对不起，您所选的期次【{0}】删除失败！", grlInstances.Text));
                    return;
                }

                foreach (XtraTabPage page in tabControl.TabPages)
                {
                    if (page.Name == grlInstances.EditValue.ToString())
                    {
                        tabControl.TabPages.Remove(page);
                        break;
                    }
                }
                _Instances.Rows.Find(grlInstances.EditValue).Delete();
                _Instances.AcceptChanges();
                InitInstance();
            }
        }

        /// <summary>
        /// 打印当前激活TabPage的报表
        /// </summary>
        private void Print()
        {
            var page = tabControl.SelectedTabPage;
            var ctl = page.Controls.Find(page.Name, false);
            var view = (PreviewControl)ctl[0];
            view.Print();
        }

        #endregion

    }
}
