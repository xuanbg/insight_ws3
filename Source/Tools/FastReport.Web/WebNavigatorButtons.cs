using System.IO;
using System;
using FastReport.Utils;
using System.Web.UI;

namespace FastReport.Web
{
    public
    partial class WebReport
    {
        private void SetEnableButtons()
        {
            if (ShowToolbar)
            {
                btnNext.Enabled = CurrentPage < (TotalPages - 1);
                btnFirst.Enabled = CurrentPage > 0;
                btnPrev.Enabled = CurrentPage > 0;
                btnLast.Enabled = CurrentPage < (TotalPages - 1);
                btnFirst.ImageUrl = GetButtonImageURL("First", btnFirst.Enabled);
                btnPrev.ImageUrl = GetButtonImageURL("Prev", btnPrev.Enabled);
                btnNext.ImageUrl = GetButtonImageURL("Next", btnNext.Enabled);
                btnLast.ImageUrl = GetButtonImageURL("Last", btnLast.Enabled);
            }
        }

        private string GetResourceImageUrl(string resName)
        {
            ClientScriptManager cs = Page.ClientScript;
            Type rsType = this.GetType();
            return cs.GetWebResourceUrl(rsType, string.Format("FastReport.Web.Resources.Buttons.{0}", resName));
        }

        private string GetButtonDesignPath(string Name)
        {
            string resName = Name + ".gif";
            if (string.IsNullOrEmpty(ButtonsPath))
                return GetResourceImageUrl(resName);
            
            string custPath = ButtonsPath + "/" + resName;
            return ResolveClientUrl(custPath);
        }

        private string GetButtonImageURL(string Name, bool Enabled)
        {
            string resName = Name + (Enabled ? "" : "_disabled") + ".gif";
            if (string.IsNullOrEmpty(ButtonsPath))
                return GetResourceImageUrl(resName);
            return ResolveUrl(string.Format("{0}/{1}", ButtonsPath, resName));
        }
      }
}