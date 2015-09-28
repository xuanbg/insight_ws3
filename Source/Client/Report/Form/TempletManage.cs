using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using FastReport.Design;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Dialog;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report
{
    public partial class TemplateManage : MdiBase
    {

        #region 变量声明

        private SYS_Report_Templates _Template;
        private DataTable _Category;
        private DataTable _Templates;
        private string _FilterStr;
        private FastReport.Report _Report;
        private bool _CanEdit;

        #endregion

        #region 构造函数

        public TemplateManage()
        {
            InitializeComponent();

            // 注册界面操作事件
            treCategory.FocusedNodeChanged += treeList_FocusedNodeChanged;
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时初始化分类并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateManage_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitCategory();

            if (_Templates.Rows.Count == 0)
            {
                SwitchItemStatus(new Context("CopyTemplet", false), new Context("EditTemplet", false), new Context("DeleteTemplet", false), new Context("Design", false), new Context("Export", false));
            }
        }

        /// <summary>
        /// 选择分类后在模板列表显示选中分类下的所有模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            _FilterStr = $"CategoryId = '{e.Node.GetValue("ID")}'";
            InitTemplets();
        }

        /// <summary>
        /// 根据所选内容刷新工具栏按钮可用状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvTemplet_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            _CanEdit = (int)gdvTemplet.GetFocusedDataRow()["Permission"] == 1;
            SwitchItemStatus(new Context("EditTemplet", _CanEdit), new Context("DeleteTemplet", _CanEdit), new Context("Design", _CanEdit));
        }

        /// <summary>
        /// 双击模板列表打开设计器修改鼠标所选模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvTemplet_DoubleClick(object sender, EventArgs e)
        {
            if (gdvTemplet.GetFocusedRow() == null || !_CanEdit) return;

            Design();
        }

        /// <summary>
        /// 自定义保存报表模板事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomSaveReport(object sender, OpenSaveReportEventArgs e)
        {
            using (var cli = new ReportClient(Binding, Address))
            {
                if (!cli.UpdateContent(UserSession, _Report.ReportResourceString.Substring(1), Guid.Parse(_Report.BaseName)))
                    General.ShowError("模板保存失败！请再次保存所做的修改。");
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化模板分类
        /// </summary>
        private void InitCategory()
        {
            var mid = Guid.Parse("DD46BA9F-A345-4CEC-AE00-26561460E470");
            _Category = Commons.Categorys(mid, true);

            using (var cli = new ReportClient(Binding, Address))
            {
                _Templates = cli.GetTemplates(UserSession);
            }

            var ids = new List<object>();
            treCategory.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => { ids.Add(n.GetValue("ID")); });
            var fid = treCategory.FocusedNode?.GetValue("ID");

            treCategory.DataSource = _Category;
            Format.TreeFormat(treCategory);
            treCategory.ExpandAll();

            ids.ForEach(id => { treCategory.FindNodeByKeyID(id).Expanded = true; });
            treCategory.FocusedNode = treCategory.FindNodeByKeyID(fid);
        }

        /// <summary>
        /// 根据分类显示模板列表
        /// </summary>
        private void InitTemplets()
        {
            var dv = _Templates.Copy().DefaultView;
            dv.RowFilter = _FilterStr;

            grdTemplet.DataSource = dv;
            Format.GridFormat(gdvTemplet);
            gdvTemplet.Columns["名称"].Width = 240;
            gdvTemplet.Columns["描述"].Width = 415;

            var hasTemp = dv.Count > 0;
            SwitchItemStatus(new Context("CopyTemplet", hasTemp), new Context("EditTemplet", hasTemp), new Context("DeleteTemplet", hasTemp), new Context("Design", hasTemp), new Context("Export", hasTemp));
        }

        #endregion

        #region 为按钮注册事件

        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "Refresh":
                    InitCategory();
                    break;

                case "CopyTemplet":
                    Copy();
                    break;

                case "EditTemplet":
                    Edit();
                    break;

                case "DeleteTemplet":
                    Delete();
                    break;

                case "Design":
                    Design();
                    break;

                case "Import":
                    Import();
                    break;

                case "Export":
                    Export();
                    break;
            }
        }

        /// <summary>
        /// 复制模板
        /// </summary>
        private void Copy()
        {
            var dig = new CopyTemplet
            {
                Owner = this,
                ObjectId = (Guid) gdvTemplet.GetFocusedDataRow()["ID"],
                ObjectData = _Templates.NewRow()
            };

            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitCategory();
            }
            dig.Close();
        }

        /// <summary>
        /// 编辑模板
        /// </summary>
        private void Edit()
        {
            var id = (Guid)gdvTemplet.GetFocusedDataRow()["ID"];
            var fr = gdvTemplet.FocusedRowHandle;
            var dig = new EditTemplet
            {
                Owner = this,
                ObjectId = id,
                ObjectData = _Templates.Rows.Find(id)
            };

            if (dig.ShowDialog() == DialogResult.OK)
            {
                _Templates.Rows.Find(id).ItemArray = dig.ObjectData.ItemArray;
                InitTemplets();
                gdvTemplet.FocusedRowHandle = fr;
            }
            dig.Close();
        }

        /// <summary>
        /// 删除当前选中模板
        /// </summary>
        private void Delete()
        {
            var row = gdvTemplet.GetFocusedDataRow();
            if (General.ShowConfirm($"您确定要删除模板【{row["名称"]}】吗？\r\n模板删除后将无法恢复！") != DialogResult.OK) return;

            using (var cli = new ReportClient(Binding, Address))
            {
                if (!cli.DelTemplets(UserSession, (Guid) gdvTemplet.GetFocusedDataRow()["ID"]))
                {
                    General.ShowError("对不起，该模板已经被使用，无法删除！");
                    return;
                }
                
                _Templates.Rows.Find(row["ID"]).Delete();
                _Templates.AcceptChanges();
                InitTemplets();
            }
        }

        /// <summary>
        /// 修改模板设计
        /// </summary>
        private void Design()
        {
            using (var cli = new ReportClient(Binding, Address))
            {
                _Template = cli.GetTemplate(UserSession, (Guid)gdvTemplet.GetFocusedDataRow()["ID"]);
            }

            Form form = null;
            foreach (var childForm in ParentForm.MdiChildren.Where(childForm => childForm.Text.Contains("FastReport - ")))
            {
                if (_Report.BaseName == _Template.ID.ToString())
                {
                    childForm.Activate();
                }
                else
                {
                    childForm.Close();
                    form = childForm;
                }
            }

            if (form == null || form.Text == "")
            {
                try
                {
                    _Report = new FastReport.Report();
                    _Report.LoadFromString(_Template.Content);
                    _Report.FileName = _Template.Name;
                    _Report.BaseName = _Template.ID.ToString();
                    _Report.Design(ParentForm);
                }
                catch
                {
                    General.ShowError("打开模板失败，您当前选中的模板无法识别！");
                }
            }
        }

        /// <summary>
        /// 导入模板
        /// </summary>
        private void Import()
        {
            _Template = new SYS_Report_Templates();

            var open = new OpenFileDialog {Filter = "报表文件(*.frx)|*.FRX"};
            if (open.ShowDialog() != DialogResult.OK) return;

            var fullName = open.SafeFileName;
            _Template.Name = fullName.Substring(0, fullName.IndexOf("."));
            _Template.CategoryId = (Guid)treCategory.FocusedNode.GetValue("ID");

            if (Commons.NameIsExist((Guid)_Template.CategoryId, _Template.Name, "Name", "SYS_Report_Templates"))
            {
                General.ShowError("对不起，在当前所选分类下该模板已存在！");
                return;
            }

            var path = open.FileName;
            var reader = new StreamReader(path);
            _Template.Content = reader.ReadToEnd();
            reader.Close();

            _Template.CreatorUserId = UserSession.UserId;
            _Template.CreatorDeptId = UserSession.DeptId;

            using (var cli = new ReportClient(Binding, Address))
            {
                var obj = cli.AddTemplet(UserSession, _Template);
                if (obj == null)
                {
                    General.ShowError("对不起，导入模板失败！请确认您要导入的文件是否存在。");
                    return;
                }
                    
                InitCategory();
            }
        }

        /// <summary>
        /// 导出模板
        /// </summary>
        private void Export()
        {
            using (var cli = new ReportClient(Binding, Address))
            {
                _Template = cli.GetTemplate(UserSession, (Guid)gdvTemplet.GetFocusedDataRow()["ID"]);
            }

            var save = new SaveFileDialog
            {
                Filter = "报表模板文件(*.frx)|*.frx",
                RestoreDirectory = true,
                AddExtension = true,
                DefaultExt = "frx",
                FileName = _Template.Name
            };
            if (save.ShowDialog() != DialogResult.OK) return;

            using (var sw = new StreamWriter(save.FileName))
            {
                try
                {
                    sw.Write(_Template.Content);
                }
                catch
                {
                    General.ShowError("对不起，模板导出失败！请确认是否具有足够的系统权限。");
                }
            }
        }

        #endregion

    }
}
