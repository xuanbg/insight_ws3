using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport.Utils;
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace FastReport.Forms
{
  internal partial class SelectLanguageForm : BaseDialogForm
  {
    private void Init()
    {
      tbFolder.Text = Res.LocaleFolder;
      PopulateLocalizations(tbFolder.Text);
    }

    private void Done()
    {
      // convert selected locale name from Native name to English name
      string localeName = lbxLanguages.SelectedIndex <= 0 ? "" : (string)lbxLanguages.SelectedItem;
      if (localeName != "")
      {
        CultureInfo[] infos = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (CultureInfo info in infos)
        {
          if (String.Compare(info.DisplayName, localeName, true) == 0)
          {
            localeName = info.EnglishName;
            break;
          }
        }
      }

      Res.DefaultLocaleName = localeName;
      Res.LocaleFolder = tbFolder.Text;
      Res.LoadDefaultLocale();
    }

    private void PopulateLocalizations(string folder)
    {
      lbxLanguages.Items.Clear();
      lbxLanguages.Items.Add(Res.Get("Forms,SelectLanguage,Auto"));
      lbxLanguages.SelectedIndex = 0;
      
      List<string> files = new List<string>();
      if (Directory.Exists(folder))
      {
        foreach (string file in Directory.GetFiles(folder, "*.frl"))
        {
          files.Add(Path.GetFileNameWithoutExtension(file));
        }
      }
      files.Add("English");
      files.Sort();

      // convert English locale name to DisplayName
      CultureInfo[] infos = CultureInfo.GetCultures(CultureTypes.AllCultures);
      List<string> names = new List<string>();
      string defaultName = "";
      foreach (string file in files)
      {
        string name = file;
        foreach (CultureInfo info in infos)
        {
          if (String.Compare(info.EnglishName, file, true) == 0)
          {
            name = info.DisplayName;
            break;
          }
        }
        names.Add(name);
        if (String.Compare(file, Res.DefaultLocaleName, true) == 0)
          defaultName = name;
      }
      names.Sort();

      foreach (string name in names)
      {
        lbxLanguages.Items.Add(name);
      }
      if (defaultName != "")
        lbxLanguages.SelectedItem = defaultName;
    }

    private void tbFolder_ButtonClick(object sender, EventArgs e)
    {
      using (FolderBrowserDialog dialog = new FolderBrowserDialog())
      {
        dialog.SelectedPath = tbFolder.Text;
        dialog.ShowNewFolderButton = false;
        dialog.Description = Res.Get("Forms,SelectLanguage,SelectFolder");
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          tbFolder.Text = dialog.SelectedPath;
          PopulateLocalizations(tbFolder.Text);
        }
      }
    }

    private void lbxLanguages_DoubleClick(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void SelectLanguageForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (DialogResult == DialogResult.OK)
        Done();
    }

    public override void Localize()
    {
      base.Localize();

      MyRes res = new MyRes("Forms,SelectLanguage");
      Text = res.Get("");
      lblSelect.Text = res.Get("SelectLanguage");
      lblFolder.Text = res.Get("Folder");
      tbFolder.Image = Res.GetImage(1);
    }

    public SelectLanguageForm()
    {
      InitializeComponent();
      Localize();
      Init();
    }

    private void SelectLanguageForm_Shown(object sender, EventArgs e)
    {
      lbxLanguages.Height = lblFolder.Top - lbxLanguages.Top - 12;
    }
  }
}

