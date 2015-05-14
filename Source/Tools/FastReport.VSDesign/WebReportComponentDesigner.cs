#if! WinForms
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.Design;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using FastReport.Design;
using FastReport.Forms;
using FastReport.Data;
using FastReport.Utils;
using FastReport.Design.StandardDesigner;
using FastReport.Web;
using FastReport.Web.Handlers;
using System.Web;
using System.Configuration;

namespace FastReport.VSDesign
{
  public class WebReportComponentDesigner : ControlDesigner
  {
    private DesignerActionListCollection _actionLists = null;

    public override DesignerActionListCollection ActionLists
    {
      get
      {
        if (_actionLists == null)
        {
          _actionLists = new DesignerActionListCollection();
          _actionLists.AddRange(base.ActionLists);

          // Add a custom DesignerActionList
          _actionLists.Add(new ActionList(this));
        }
        return _actionLists;
      }
    }

    private void SetupHandler()
    {
      IWebApplication webApp = (IWebApplication)GetService(typeof(IWebApplication));
      if (webApp != null)
      {
        Configuration config = webApp.OpenWebConfiguration(true);
        if (config != null)
          WebUtils.AddHandlers(config.FilePath);
      }
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      SetupHandler();
    }

    public class ActionList : DesignerActionList
    {
      private WebReportComponentDesigner _parent;
      private DesignerActionItemCollection _items;

      public ActionList(WebReportComponentDesigner parent)
        : base(parent.Component)
      {
        _parent = parent;
      }

      public override DesignerActionItemCollection GetSortedActionItems()
      {
        if (_items == null)
        {
          // to load the config
          using (Report report = new Report())
          {
          }

          _items = new DesignerActionItemCollection();
          _items.Add(new DesignerActionMethodItem(this, "DesignReport", Res.Get("ComponentMenu,Report,DesignReport"), true));
          _items.Add(new DesignerActionMethodItem(this, "SelectDataSource", Res.Get("ComponentMenu,Report,SelectDataSource"), true));
        }
        return _items;
      }

      /// <summary>
      /// The "Design Report" action.
      /// </summary>
      public void DesignReport()
      {
        // Get a reference to the parent designer's associated control               
        WebReport webreport = (WebReport)_parent.Component;
        Report report = new Report();

        bool fileBased = false;
        if (!String.IsNullOrEmpty(webreport.ReportFile))
        {
          string fileName = webreport.ReportFile;
          fileName = MapPath(webreport.Site, fileName);
          report.Load(fileName);
          fileBased = true;
        }
        else if (!String.IsNullOrEmpty(webreport.ReportResourceString))
          report.ReportResourceString = webreport.ReportResourceString;

        try
        {
          RegisterData(webreport, report, webreport.Site);
        }
        catch (Exception ex)
        {
          using (ExceptionForm form = new ExceptionForm(ex))
          {
            form.ShowDialog();
          }
          return;
        }
        using (DesignerForm designerForm = new DesignerForm())
        {
          designerForm.Designer.Report = report;
          designerForm.Designer.AskSave = fileBased;
          designerForm.ShowInTaskbar = true;
          designerForm.ShowDialog();
          if (designerForm.Designer.Modified && !fileBased)
          {
            string oldValue = webreport.ReportResourceString;
            webreport.ReportResourceString = report.SaveToStringBase64();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(webreport);
            PropertyDescriptor prop = props.Find("ReportResourceString", false);
            _parent.RaiseComponentChanged(prop, oldValue, webreport.ReportResourceString);
          }
        }
      }

      private Control FindControlRecursive(Control root, string id)
      {
        if (root.ID == id)
          return root;

        foreach (Control ctl in root.Controls)
        {
          Control foundCtl = FindControlRecursive(ctl, id);
          if (foundCtl != null)
            return foundCtl;
        }

        return null;
      }

      private string MapPath(IServiceProvider serviceProvider, string path)
      {
        if (path.Length != 0)
        {
          if (WebUtils.IsAbsolutePhysicalPath(path))
          {
            return path;
          }
          WebFormsRootDesigner designer = null;
          if (serviceProvider != null)
          {
            IDesignerHost service = (IDesignerHost)serviceProvider.GetService(typeof(IDesignerHost));
            if ((service != null) && (service.RootComponent != null))
            {
              designer = service.GetDesigner(service.RootComponent) as WebFormsRootDesigner;
              if (designer != null)
              {
                string appRelativeUrl = designer.ResolveUrl(path);
                IWebApplication application = (IWebApplication)serviceProvider.GetService(typeof(IWebApplication));
                if (application != null)
                {
                  IProjectItem projectItemFromUrl = application.GetProjectItemFromUrl(appRelativeUrl);
                  if (projectItemFromUrl != null)
                  {
                    return projectItemFromUrl.PhysicalPath;
                  }
                }
              }
            }
          }
        }
        return null;
      }

      private void RegisterData(WebReport webreport, Report report, IServiceProvider provider)
      {
        string[] dataSources = webreport.ReportDataSources.Split(new char[] { ';' });
        foreach (string dataSource in dataSources)
        {
          IDataSource ds = FindControlRecursive(webreport.Page, dataSource) as IDataSource;
          if (ds == null)
            continue;
          string dataName = (ds as Control).ID;

          // at design time, use design time data view
          if (provider != null)
          {
            if (ds is AccessDataSource)
            {
              // for MS Access data source, try to convert relative DataFile path.
              // This is needed to avoid the exception when access the database in the design time.
              AccessDataSource accessDs = ds as AccessDataSource;
              string saveDataFile = accessDs.DataFile;
              try
              {
                accessDs.DataFile = MapPath(provider, accessDs.DataFile);
                webreport.RegisterDataAsp(report, accessDs, dataName);
              }
              finally
              {
                accessDs.DataFile = saveDataFile;
              }
            }
            else
            {
              webreport.RegisterDataAsp(report, ds, dataName);
            }
          }
          else
          {
            webreport.RegisterDataAsp(report, ds, dataName);
          }
        }
      }

      /// <summary>
      /// The "Select Data Source" action.
      /// </summary>
      public void SelectDataSource()
      {
        using (AspSelectDataSourceForm form = new AspSelectDataSourceForm())
        {
          WebReport webreport = (WebReport)_parent.Component;
          string oldValue = webreport.ReportDataSources;
          IReferenceService service = GetService(typeof(IReferenceService)) as IReferenceService;
          form.Init(webreport, service);
          if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(webreport);
            PropertyDescriptor prop = props.Find("ReportDataSources", false);
            _parent.RaiseComponentChanged(prop, oldValue, webreport.ReportDataSources);
          }
        }
      }
    }
  }

  public class ReportFileEditor : UrlEditor
  {
    protected override string Caption
    {
      get
      {
        return Res.Get("ComponentMenu,WebReport,SelectReportFile");
      }
    }

    protected override string Filter
    {
      get
      {
        return Res.Get("FileFilters,Report");
      }
    }
  }

  public class LocalizationFileEditor : UrlEditor
  {
    protected override string Caption
    {
      get
      {
        return Res.Get("ComponentMenu,WebReport,SelectLocalizationFile");
      }
    }

    protected override string Filter
    {
      get
      {
        return Res.Get("FileFilters,Localization");
      }
    }
  }
}
#endif
