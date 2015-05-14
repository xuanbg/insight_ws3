using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Insight.WS.Client.Common.Dialog
{
    public partial class PrintSet : DialogBase
    {

        #region 变量声明

        string _DocPrint;
        string _BilPrint;
        string _TagPrint;

        #endregion

        #region 构造方法

        public PrintSet()
        {
            InitializeComponent();

            _DocPrint = Config.Printer("DocPrint");
            _TagPrint = Config.Printer("TagPrint");
            _BilPrint = Config.Printer("BilPrint");
            var merger = Config.IsMergerPrint();

            // 在列表框中列出所有的打印机
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cbxDocPrint.Properties.Items.Add(printer);
                cbxTagPrint.Properties.Items.Add(printer);
                cbxBilPrint.Properties.Items.Add(printer);
            }

            // 在列表框中插入例外项
            cbxDocPrint.Properties.Items.Insert(0, "不设置默认打印机");
            cbxTagPrint.Properties.Items.Insert(0, "不设置默认打印机");
            cbxBilPrint.Properties.Items.Insert(0, "不设置默认打印机");

            cbxDocPrint.EditValue = (_DocPrint == "") ? null : _DocPrint;
            cbxTagPrint.EditValue = (_TagPrint == "") ? null : _TagPrint;
            cbxBilPrint.EditValue = (_BilPrint == "") ? null : _BilPrint;
            chkMergerPrint.Checked = merger;
        }

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            _DocPrint = cbxDocPrint.SelectedIndex < 1 ? "" : cbxDocPrint.Text;
            _BilPrint = cbxBilPrint.SelectedIndex < 1 ? "" : cbxBilPrint.Text;
            _TagPrint = cbxTagPrint.SelectedIndex < 1 ? "" : cbxTagPrint.Text;

            Config.SavePrinter("docPrint", _DocPrint);
            Config.SavePrinter("bilPrint", _BilPrint);
            Config.SavePrinter("tagPrint", _TagPrint);
            Config.SaveIsMergerPrint(chkMergerPrint.Checked);

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
