using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;
using FastReport.Design;
using FastReport.Forms;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using FastReport.Data;
using System.Data;
using FastReport.Utils;
using FastReport.Design.StandardDesigner;

namespace FastReport.VSDesign
{
  public class ReportComponentDesigner : ComponentDesigner
  {
    private Report FReport;
    private static bool FFirstTimeRun = true;

    
    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      FReport = component as Report;
    }

    public override void DoDefaultAction()
    {
      DesignVerb(this, EventArgs.Empty);
    }

    public override DesignerVerbCollection Verbs
    {
      get
      {
        return new DesignerVerbCollection(new DesignerVerb[] { 
          new DesignerVerb(Res.Get("ComponentMenu,Report,DesignReport"), new EventHandler(DesignVerb)),
          new DesignerVerb(Res.Get("ComponentMenu,Report,SelectDataSource"), new EventHandler(SelectDataSourceVerb)) });
      }
    }
    
    private void RaiseReportChanged()
    {
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(FReport);
      PropertyDescriptor prop = props.Find("ReportResourceString", false);
      RaiseComponentChanged(prop, "", FReport.ReportResourceString);
    }

    private void DesignVerb(object sender, EventArgs e)
    {
      if (FReport.Dictionary.DataSources.Count == 0 && FReport.Dictionary.Connections.Count == 0 && FFirstTimeRun)
        SelectDataSourceVerb(sender, e);
      else
        FReport.Dictionary.ReRegisterData();

      FFirstTimeRun = false;

      try
      {
        using (DesignerForm designerForm = new DesignerForm())
        {
          designerForm.Designer.Report = FReport;
          designerForm.Designer.AskSave = !FReport.StoreInResources;
          designerForm.ShowInTaskbar = true;
          designerForm.ShowDialog();
          if (designerForm.Designer.Modified && FReport.StoreInResources)
            RaiseReportChanged();
        }
      }
      catch (Exception ex)
      {
        using (ExceptionForm form = new ExceptionForm(ex))
        {
          form.ShowDialog();
        }
      }  

      DesignerActionUIService designerActionUISvc = 
        GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
      if (designerActionUISvc != null)
        designerActionUISvc.HideUI(FReport);
    }

    private void SelectDataSourceVerb(object sender, EventArgs e)
    {
      using (SelectDataSourceForm form = new SelectDataSourceForm())
      {
        IReferenceService service = GetService(typeof(IReferenceService)) as IReferenceService;
        form.Init(FReport, service);
        if (form.ShowDialog() == DialogResult.OK)
          RaiseReportChanged();
      }
    }
  }
  
}
