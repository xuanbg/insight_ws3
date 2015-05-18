using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using FastReport;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class MdiBase : XtraForm
    {

        #region 属性

        /// <summary>
        /// 模块Id
        /// </summary>
        public Guid ModuleId { get; set; }

        /// <summary>
        /// 用户会话对象
        /// </summary>
        public Session UserSession { get; set; }

        /// <summary>
        /// WCF服务绑定
        /// </summary>
        public CustomBinding Binding { get; set; }

        /// <summary>
        /// WCF服务器地址：端口号
        /// </summary>
        public EndpointAddress Address { get; set; }

        /// <summary>
        /// 业务模块选项参数
        /// </summary>
        private List<SYS_ModuleParam> ModuleParams { get; set; }

        #endregion

        #region 字段声明

        private DataTable _Actions;

        #endregion

        #region 构造方法

        protected MdiBase()
        {
            InitializeComponent();
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 初始化模块工具栏
        /// </summary>
        protected void InitToolBar()
        {
            using (var cli = new CommonsClient(MainForm._Binding, MainForm._Address))
            {
                _Actions = cli.GetAction(UserSession, ModuleId);
            }

            barMainToolBar.BarName = ModuleId.ToString();
            foreach (DataRow row in _Actions.Rows)
            {
                var item = new BarButtonItem(barManager, row["Alias"].ToString())
                {
                    CategoryGuid = (Guid) row["ModuleId"],
                    Tag = row["Enable"],
                    Name = row["Name"].ToString(),
                    Glyph = Image.FromStream(new MemoryStream((byte[]) row["Icon"])),
                    PaintStyle = (bool) row["ShowText"] ? BarItemPaintStyle.CaptionGlyph : BarItemPaintStyle.Standard,
                    Enabled = (bool) row["Enable"],
                    Visibility = (bool) row["Validity"] ? BarItemVisibility.Always : BarItemVisibility.Never
                };
                item.ItemClick += item_ItemClick;

                barManager.Items.Add(item);
                barManager.Bars[ModuleId.ToString()].ItemLinks.Add(item, (bool)row["BeginGroup"]);
            }
        }

        /// <summary>
        /// 根据输入的选项ID获取选项值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected List<string> GetParameter(string id)
        {
            var pid = Guid.Parse(id);
            var pvl = new List<string>();
            if (ModuleParams.Exists(obj => obj.ParamId == pid))
            {
                pvl.AddRange(ModuleParams.FindAll(p => p.ParamId == pid).Select(p => p.Value));
            }
            return pvl;
        }

        /// <summary>
        /// 读取模块选项参数
        /// </summary>
        protected void ReadModuleParameter()
        {
            ModuleParams = Commons.ModuleParam(ModuleId);
        }

        /// <summary>
        /// 保存模块选项参数
        /// </summary>
        protected void WriteModuleParameter(IEnumerable<SYS_ModuleParam> pams)
        {
            var apl = new List<SYS_ModuleParam>();
            var upl = new List<SYS_ModuleParam>();
            foreach (var pam in pams)
            {
                if (!ModuleParams.Exists(p => p.ID == pam.ID)) apl.Add(pam);
                if (ModuleParams.Exists(p => p.ID == pam.ID && p.Value != pam.Value)) upl.Add(pam);
            }

            var result = Commons.SaveModuleParam(apl, upl);
            if (!result)
            {
                General.ShowError("保存选项失败！如多次保存失败，请联系管理员。");
            }
        }

        /// <summary>
        /// 新建/编辑分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isEdit"></param>
        /// <param name="allowEditRoot"></param>
        /// <returns></returns>
        protected bool EditCatalog(Guid id, bool isEdit, bool allowEditRoot = false)
        {
            var dig = new Category
            {
                Owner = this,
                ObjectId = id,
                ModuleId = ModuleId,
                AllowEditRoot = allowEditRoot,
                IsEdit = isEdit
            };
            var result = dig.ShowDialog() == DialogResult.OK;
            dig.Close();
            return result;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        protected void DeleteCatalog(TreeList tree)
        {
            var fn = tree.FocusedNode;
            if (General.ShowConfirm(string.Format("您确定要删除分类【{0}】吗?", fn.GetValue("Name"))) != DialogResult.OK)
                return;

            using (var cli = new CommonsClient(MainForm._Binding, MainForm._Address))
            {
                if (cli.DelCategory(MainForm._Session, (Guid)fn.GetValue("ID")))
                    tree.DeleteNode(tree.FocusedNode);
                else
                    General.ShowError("对不起，该分类已经被使用，无法删除！");
            }
        }

        /// <summary>
        /// 使用指定的模板打印数据
        /// </summary>
        /// <param name="oid">数据对象ID</param>
        /// <param name="tid">模板ID</param>
        /// <param name="printer">打印机名称</param>
        /// <param name="obj">ImageData对象实体</param>
        /// <param name="onSheet">合并打印模式</param>
        protected string PrintImage(Guid oid, Guid? tid, string printer = null, ImageData obj = null, PagesOnSheet onSheet = PagesOnSheet.One)
        {
            var print = BuildReport(oid, tid, obj);
            if (print == null) return null;

            if (onSheet != PagesOnSheet.One)
            {
                print.PrintSettings.PrintMode = PrintMode.Scale;
                print.PrintSettings.PagesOnSheet = onSheet;
            }

            if (!string.IsNullOrEmpty(printer))
            {
                print.PrintSettings.ShowDialog = false;
                print.PrintSettings.Printer = printer;
            }
            print.PrintPrepared();
            return print.FileName;
        }

        /// <summary>
        /// 使用指定的模板预览数据
        /// </summary>
        /// <param name="oid">数据对象ID</param>
        /// <param name="tid">模板ID</param>
        protected void PreviewImage(Guid oid, Guid? tid)
        {
            var print = BuildReport(oid, tid);
            if (print == null) return;

            print.ShowPrepared(true);
        }

        /// <summary>
        /// 切换工具栏按钮状态
        /// </summary>
        /// <param name="context"></param>
        protected void SwitchItemStatus(params Context[] context)
        {
            foreach (var obj in context)
            {
                var item = barManager.Items[obj.Name];
                item.Enabled = obj.Status && (bool)item.Tag;
            }
        }

        /// <summary>
        /// 工具条按钮点击事件的虚方法实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            General.ShowError("对不起，该功能尚未实现！");
        }

        #endregion

        #region 私有方法

        private Report BuildReport(Guid oid, Guid? tid, ImageData obj = null)
        {
            var isCopy = false;
            ImageData img;
            if (tid == null || tid == Guid.Empty)
            {
                isCopy = true;
                img = Commons.ImageData(oid);
                if (img == null)
                {
                    General.ShowError("尚未设置打印模板！请先在设置对话框中设置正确的模板。");
                    return null;
                }
            }
            else
            {
                img = Commons.BuildImageData(oid, (Guid)tid, obj);
            }

            var print = new Report {FileName = img.ID.ToString()};
            print.LoadPrepared(new MemoryStream(img.Image));

            if (isCopy) General.AddWatermark(print, "副 本");
            return print;
        }

        #endregion

    }
}
