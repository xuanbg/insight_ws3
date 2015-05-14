using System;
using System.Web;
using FastReport.Web;
using System.IO;

namespace FastReport.Web.Handlers
{
    /// <summary>
    /// Web handler class
    /// </summary>
    public class WebExport: IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        private bool WebFarmMode = false;
        private string FileStoragePath;

        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Process Request
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            FileStoragePath = WebReportCache.GetStoragePath(context);
            WebFarmMode = !String.IsNullOrEmpty(FileStoragePath);

            if (context.Request.Params[WebUtils.PicsPrefix] != null)
            {
                string imageKeyName = Convert.ToString(context.Request.Params[WebUtils.PicsPrefix]);
                context.Response.ContentType = "image/png";
                context.Response.Flush();
                byte[] image;
                if (WebFarmMode)
                {
                    image = WebReportCache.GetFileStorage(String.Empty, imageKeyName, FileStoragePath) as byte[];
                }
                else
                {
                    image = HttpRuntime.Cache[imageKeyName] as byte[];
                }
                if (image != null)
                    WebUtils.ResponseChunked(context.Response, image);                
                context.Response.End();
            }
            else if (context.Request.QueryString[WebUtils.ConstID] != null)
            {
                string cacheKeyName = String.Concat(WebUtils.EXPORT, context.Request.QueryString[WebUtils.ConstID]);
                WebExportItem exportItem;
                if (WebFarmMode)
                {
                    exportItem = WebReportCache.GetFileStorage(String.Empty, cacheKeyName, FileStoragePath) as WebExportItem;
                }
                else
                {
                    exportItem = HttpRuntime.Cache[cacheKeyName] as WebExportItem;
                }
                if (exportItem != null)
                {
                    if (!WebFarmMode)
                        HttpRuntime.Cache.Remove(cacheKeyName);
                    context.Response.ClearContent();
                    context.Response.ClearHeaders();
                    if (string.IsNullOrEmpty(exportItem.ContentType))
                        context.Response.ContentType = "application/unknown";
                    else
                        context.Response.ContentType = exportItem.ContentType;
                    context.Response.AddHeader("Content-Type", context.Response.ContentType);

                    string disposition = "attachment";
                    if (context.Request.QueryString["displayinline"].Equals("True", StringComparison.OrdinalIgnoreCase))
                        disposition = "inline";

                    context.Response.AddHeader("Content-Disposition", string.Format("{0}; filename={1}", disposition, HttpUtility.UrlEncode(exportItem.FileName)));
                    context.Response.Flush();

                    WebUtils.ResponseChunked(context.Response, exportItem.File);

                    context.Response.End();
                }
            }
            else if (context.Request.Params[WebUtils.PrintPrefix] != null && context.Request.Params[WebUtils.ReportPrefix] != null)
            {                
                WebReport webReport = new WebReport();
                webReport.ReportGuid = context.Request.Params[WebUtils.ReportPrefix];
                webReport.ReportDone = true;
                webReport.WebFarm = WebFarmMode;
                webReport.StoragePath = FileStoragePath;

                if (WebFarmMode)
                {
                    webReport.Report = WebReportCache.GetFileStorage(WebUtils.REPORT, webReport.ReportGuid, FileStoragePath) as Report;
                    webReport.Properties = WebReportCache.GetFileStorage(WebUtils.PROPERTIES, webReport.ReportGuid, FileStoragePath) as WebReportProperties;
                }
                else
                {
                    webReport.Report = WebReportCache.CacheGet(String.Concat(WebUtils.REPORT, webReport.ReportGuid)) as Report;
                    webReport.Properties = WebReportCache.CacheGet(String.Concat(WebUtils.PROPERTIES, webReport.ReportGuid)) as WebReportProperties;
                }                

                if (context.Request.Params[WebUtils.PrintPrefix] == "pdf")
                    webReport.PrintPdf();
                else
                    webReport.PrintHtml();

                context.Response.End();
            }
            else
            {
                int count = 0;
                if (WebFarmMode)
                    count = WebReportCache.CleanStorage(FileStoragePath, WebReportCache.GetStorageTimeout(), WebReportCache.GetStorageCleanup());
                context.Response.ContentType = "text/html";
                context.Response.Write(String.Concat("FastReport.Web.WebExport handler: ", 
                    " FastReport.NET <b>v", FastReport.Utils.Config.Version, "</b><br/>",
                    "Current server time: <b>", DateTime.Now.ToString(), "</b><br/>",
                    "Cluster mode: <b>", (WebFarmMode ? "ON" : "OFF"), "</b><br/>",
                    "Files in storage: <b>", count.ToString(), "</b>"));
                context.Response.End();
            }
        }

        #endregion
    }
}
