using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

namespace FastReport.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebUtils
    {
        /// <summary>
        /// Contain the filename of httphandler
        /// </summary>
        public const string HandlerFileName = "FastReport.Export.aspx";
        internal const string PicsPrefix = "frximg";
        internal const string PrintPrefix = "frxprint";
        internal const string ReportPrefix = "frxreport";
        internal const string StartupScriptName = "FrxStartup";
        internal const string ConstID = "ID";
        internal const string DefaultCreator = "FastReport";
        internal const string DefaultProducer = "FastReport .NET";
        internal const string HTMLEXPORT = "frh";
        internal const string REPORT = "frr";
        internal const string PROPERTIES = "frx";
        internal const string EXPORT = "fre";
        internal const string HiddenIDSuffix = "FRID";

        /// <summary>
        /// Determines whether the path is an absolute physical path.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns><b>true</b> if the path is absolute physical path.</returns>
        public static bool IsAbsolutePhysicalPath(string path)
        {
            if ((path == null) || (path.Length < 3))
            {
                return false;
            }
            return (path.StartsWith(@"\\", StringComparison.Ordinal) || ((char.IsLetter(path[0]) && (path[1] == ':')) && (path[2] == '\\')));
        }

        private static bool CheckNewHandler(XmlElement element)
        {
            bool found = false;
            XmlNode node = element.SelectSingleNode("system.webServer");
            if (node != null)
            {
                XmlNode node2 = node.SelectSingleNode("handlers");
                if (node2 != null)
                {
                    XmlNode node3 = node2.SelectSingleNode(String.Format("add[@path=\"{0}\"]", HandlerFileName));
                    found = (node3 != null);
                }
            }
            return found;
        }

        private static bool CheckOldHandler(XmlElement element)
        {
            bool found = false;
            XmlNode node = element.SelectSingleNode("system.web");
            if (node != null)
            {
                XmlNode node2 = node.SelectSingleNode("httpHandlers");
                if (node2 != null)
                {
                    XmlNode node3 = node2.SelectSingleNode(String.Format("add[@path=\"{0}\"]", HandlerFileName));
                    found = (node3 != null);
                }
            }
            return found;
        }

        /// <summary>
        /// Check http handlers in web.config
        /// </summary>
        /// <returns></returns>
        public static bool CheckHandlers()
        {
            string webConfigFile = HttpContext.Current.Server.MapPath("~/web.config");
            bool found1 = false;
            bool found2 = false;
            if (File.Exists(webConfigFile))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(webConfigFile);
                XmlElement element = xml.DocumentElement;
                found1 = CheckOldHandler(element);
                found2 = CheckNewHandler(element);
            }
            return found1 || found2;
        }

        /// <summary>
        /// Add http handlers in web.config
        /// </summary>
        public static void AddHandlers(string webConfigFile)
        {            
            if (File.Exists(webConfigFile))
            {
                bool modified = false;
                XmlDocument xml = new XmlDocument();
                xml.Load(webConfigFile);
                XmlElement element = xml.DocumentElement;

                // integrated style
                string s = "system.webServer";
                XmlNode node = element.SelectSingleNode(s);
                if (node == null)
                {
                    node = xml.CreateElement(s);
                    element.AppendChild(node);
                }

                XmlNode node2 = node.SelectSingleNode("validation[@validateIntegratedModeConfiguration=\"false\"]");
                if (node2 == null)
                {
                    node2 = xml.CreateElement("validation");
                    XmlAttribute a = xml.CreateAttribute("validateIntegratedModeConfiguration");
                    a.Value = "false";
                    node2.Attributes.Append(a);
                    node.AppendChild(node2);
                    modified = true;
                }

                s = "handlers";
                node2 = node.SelectSingleNode(s);
                if (node2 == null)
                {
                    node2 = xml.CreateElement(s);
                    node.AppendChild(node2);
                }
                XmlNode node3 = node2.SelectSingleNode(String.Format("add[@path=\"{0}\"]", HandlerFileName));
                if (node3 == null)
                {
                    node3 = xml.CreateElement("add");
                    XmlAttribute a = xml.CreateAttribute("name");
                    a.Value = "FastReportHandler";
                    node3.Attributes.Append(a);
                    a = xml.CreateAttribute("path");
                    a.Value = HandlerFileName;
                    node3.Attributes.Append(a);
                    a = xml.CreateAttribute("verb");
                    a.Value = "*";
                    node3.Attributes.Append(a);
                    a = xml.CreateAttribute("type");
                    a.Value = "FastReport.Web.Handlers.WebExport";
                    node3.Attributes.Append(a);
                    node2.AppendChild(node3);
                    modified = true;
                }

                // standard style
                s = "system.web";
                node = element.SelectSingleNode(s);
                if (node == null)
                {
                    node = xml.CreateElement(s);
                    element.AppendChild(node);
                }
                s = "httpHandlers";
                node2 = node.SelectSingleNode(s);
                if (node2 == null)
                {
                    node2 = xml.CreateElement(s);
                    node.AppendChild(node2);
                }
                node3 = node2.SelectSingleNode(String.Format("add[@path=\"{0}\"]", HandlerFileName));
                if (node3 == null)
                {
                    node3 = xml.CreateElement("add");
                    XmlAttribute a = xml.CreateAttribute("path");
                    a.Value = HandlerFileName;
                    node3.Attributes.Append(a);
                    a = xml.CreateAttribute("verb");
                    a.Value = "*";
                    node3.Attributes.Append(a);
                    a = xml.CreateAttribute("type");
                    a.Value = "FastReport.Web.Handlers.WebExport";
                    node3.Attributes.Append(a);
                    node2.AppendChild(node3);
                    modified = true;
                } 
                // save config
                if (modified)
                  xml.Save(webConfigFile);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CheckHandlersRuntime()
        {
            if (!CheckHandlers())
            {
                StringBuilder e = new StringBuilder();
                e.AppendLine("FastReport handler not found. Please modify your web.config:");
                e.AppendLine("IIS6");
                e.AppendLine("<system.web>");
                e.AppendLine("...");
                e.AppendLine("  <httpHandlers>");
                e.Append("    <add path=\"").Append(HandlerFileName).AppendLine("\" verb=\"*\" type=\"FastReport.Web.Handlers.WebExport\"/>");
                e.AppendLine("      ....");
                e.AppendLine("  </httpHandlers>");
                e.AppendLine("</system.web>");
                e.AppendLine("IIS7");
                e.AppendLine("<configuration>");
                e.AppendLine("...");
                e.AppendLine("  <system.webServer>");
                e.AppendLine("    <validation validateIntegratedModeConfiguration=\"false\"/>");
                e.AppendLine("...");
                e.AppendLine("    <handlers>");
                e.AppendLine("    ...");
                e.AppendLine("      <remove name=\"FastReportHandler\"/>");
                e.Append("      <add name=\"FastReportHandler\" path=\"").Append(HandlerFileName).AppendLine("\" verb=\"*\" type=\"FastReport.Web.Handlers.WebExport\" />");
                e.AppendLine("    </handlers>");
                e.AppendLine("  </system.webServer>");
                e.AppendLine("</configuration>");
                throw new Exception(e.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReverseString(string str)
        {
            StringBuilder result = new StringBuilder(str.Length);
            int i, j;
            if (!String.IsNullOrEmpty(str))
                for (j = 0, i = str.Length - 1; i >= 0; i--, j++)
                    result.Append(str[i]);
            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetGUID(HttpContext context, string id)
        {
            string result = String.Empty;
            if (HttpContext.Current != null)
                result = context.Request[String.Concat(id, "$", WebUtils.HiddenIDSuffix)];

            if (String.IsNullOrEmpty(result))
                result = Guid.NewGuid().ToString().Replace("-", "");
            else
                result = WebUtils.ReverseString(result);

            return result;
        }

        internal static void ResponseChunked(HttpResponse httpResponse, byte[] p)
        {
            int chunkSize = 8192;
            int position = 0;
            while (position < p.Length && httpResponse.IsClientConnected)
            {
                if (chunkSize > p.Length - position)
                    chunkSize = p.Length - position;
                httpResponse.OutputStream.Write(p, position, chunkSize);
                position += chunkSize;
                httpResponse.Flush();
            }
        }
    }
}
