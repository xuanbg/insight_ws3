using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport.Export;
using FastReport.Export.OoXML;
using FastReport.Utils;


namespace FastReport.Forms
{
    internal partial class Excel2007ExportForm : BaseExportForm
    {
        public override void Init(ExportBase export)
        {
            base.Init(export);
            MyRes res = new MyRes("Export,Xlsx");
            Text = res.Get("");
            Excel2007Export ooxmlExport = Export as Excel2007Export;
            cbWysiwyg.Checked = ooxmlExport.Wysiwyg;
            cbPageBreaks.Checked = ooxmlExport.PageBreaks;
            cbDataOnly.Checked = ooxmlExport.DataOnly;
        }
        
        protected override void Done()
        {
            base.Done();
            Excel2007Export ooxmlExport = Export as Excel2007Export;
            ooxmlExport.Wysiwyg = cbWysiwyg.Checked;
            ooxmlExport.PageBreaks = cbPageBreaks.Checked;
            ooxmlExport.DataOnly = cbDataOnly.Checked;
        }
        
        public override void Localize()
        {
            base.Localize();
            MyRes res = new MyRes("Export,Misc");
            gbOptions.Text = res.Get("Options");
            cbWysiwyg.Text = res.Get("Wysiwyg");
            cbPageBreaks.Text = res.Get("PageBreaks");
            cbDataOnly.Text = Res.Get("Export,Csv,DataOnly");
        }        
        
        public Excel2007ExportForm()
        {
            InitializeComponent();
        }
    }
}

