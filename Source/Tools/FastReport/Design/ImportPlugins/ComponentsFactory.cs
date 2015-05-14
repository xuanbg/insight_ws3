using System;
using System.Collections.Generic;
using System.Text;
using FastReport.MSChart;
using FastReport.Table;
using FastReport.Matrix;

namespace FastReport.Design.ImportPlugins
{
    /// <summary>
    /// The components factory.
    /// </summary>
    public static class ComponentsFactory
    {
        #region Public Methods

        /// <summary>
        /// Creates a ReportPage instance in the specified Report.
        /// </summary>
        /// <param name="report">The Report instance.</param>
        /// <returns>The ReportPage instance.</returns>
        public static ReportPage CreateReportPage(Report report)
        {
            ReportPage page = new ReportPage();
            report.Pages.Add(page);
            page.CreateUniqueName();
            return page;
        }

        /// <summary>
        /// Creates a ReportTitleBand instance in the specified ReportPage.
        /// </summary>
        /// <param name="page">The ReportPage instance.</param>
        /// <returns>The ReportTitleBand instance.</returns>
        public static ReportTitleBand CreateReportTitleBand(ReportPage page)
        {
            ReportTitleBand reportTitle = new ReportTitleBand();
            page.ReportTitle = reportTitle;
            reportTitle.CreateUniqueName();
            return reportTitle;
        }

        /// <summary>
        /// Creates a ReportSummaryBand instance in the specified ReportPage.
        /// </summary>
        /// <param name="page">The ReportPage instance.</param>
        /// <returns>The ReportSummaryBand instance.</returns>
        public static ReportSummaryBand CreateReportSummaryBand(ReportPage page)
        {
            ReportSummaryBand reportSummary = new ReportSummaryBand();
            page.ReportSummary = reportSummary;
            reportSummary.CreateUniqueName();
            return reportSummary;
        }

        /// <summary>
        /// Creates a PageHeaderBand instance in the specified ReportPage.
        /// </summary>
        /// <param name="page">The ReportPage instance.</param>
        /// <returns>The PageHeaderBand instance.</returns>
        public static PageHeaderBand CreatePageHeaderBand(ReportPage page)
        {
            PageHeaderBand pageHeader = new PageHeaderBand();
            page.PageHeader = pageHeader;
            pageHeader.CreateUniqueName();
            return pageHeader;
        }

        /// <summary>
        /// Creates a PageFooterBand instance in the specified ReportPage.
        /// </summary>
        /// <param name="page">The ReportPage instance.</param>
        /// <returns>The PageFooterBand instance.</returns>
        public static PageFooterBand CreatePageFooterBand(ReportPage page)
        {
            PageFooterBand pageFooter = new PageFooterBand();
            page.PageFooter = pageFooter;
            pageFooter.CreateUniqueName();
            return pageFooter;
        }

        /// <summary>
        /// Creates a DataBand instance in the specified ReportPage.
        /// </summary>
        /// <param name="page">The ReportPage instance.</param>
        /// <returns>The DataBand instance.</returns>
        public static DataBand CreateDataBand(ReportPage page)
        {
            DataBand band = new DataBand();
            page.Bands.Add(band);
            band.CreateUniqueName();
            return band;
        }

        /// <summary>
        /// Creates a ChildBand instance in the specified BandBase.
        /// </summary>
        /// <param name="parent">The BandBase instance.</param>
        /// <returns>The ChildBand instance.</returns>
        public static ChildBand CreateChildBand(BandBase parent)
        {
            ChildBand child = new ChildBand();
            parent.AddChild(child);
            child.CreateUniqueName();
            return child;
        }

        /// <summary>
        /// Creates a LineObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the LineObject instance.</param>
        /// <param name="parent">The parent of the LineObject instance.</param>
        /// <returns>The LineObject instance.</returns>
        public static LineObject CreateLineObject(string name, Base parent)
        {
            LineObject line = new LineObject();
            line.Name = name;
            line.Parent = parent;
            return line;
        }

        /// <summary>
        /// Creates a ShapeObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the ShapeObject instance.</param>
        /// <param name="parent">The parent of the ShapeObject instance.</param>
        /// <returns>The ShapeObject instance.</returns>
        public static ShapeObject CreateShapeObject(string name, Base parent)
        {
            ShapeObject shape = new ShapeObject();
            shape.Name = name;
            shape.Parent = parent;
            return shape;
        }

        /// <summary>
        /// Creates a TextObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the TextObject instance.</param>
        /// <param name="parent">The parent of the TextObject instance.</param>
        /// <returns>The TextObject instance.</returns>
        public static TextObject CreateTextObject(string name, Base parent)
        {
            TextObject text = new TextObject();
            text.Name = name;
            text.Parent = parent;
            return text;
        }

        /// <summary>
        /// Creates a PictureObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the PictureObject instance.</param>
        /// <param name="parent">The parent of the PictureObject instance.</param>
        /// <returns>The PictureObject instance.</returns>
        public static PictureObject CreatePictureObject(string name, Base parent)
        {
            PictureObject picture = new PictureObject();
            picture.Name = name;
            picture.Parent = parent;
            return picture;
        }

        /// <summary>
        /// Creates a SubreportObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the SubreportObject instance.</param>
        /// <param name="parent">The parent of the SubreportObject instance.</param>
        /// <returns>The SubreportObject instance.</returns>
        public static SubreportObject CreateSubreportObject(string name, Base parent)
        {
            SubreportObject subreport = new SubreportObject();
            subreport.Name = name;
            subreport.Parent = parent;
            return subreport;
        }

#if!Basic
        /// <summary>
        /// Creates a MSChartObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the MSChartObject instance.</param>
        /// <param name="parent">The parent of the MSChartObject instance.</param>
        /// <returns>The MSChartObject instance.</returns>
        public static MSChartObject CreateMSChartObject(string name, Base parent)
        {
            MSChartObject chart = new MSChartObject();
            chart.Name = name;
            chart.Parent = parent;
            return chart;
        }

        /// <summary>
        /// Creates a TableObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the TableObject instance.</param>
        /// <param name="parent">The parent of the TableObject instance.</param>
        /// <returns>The TableObject instance.</returns>
        public static TableObject CreateTableObject(string name, Base parent)
        {
            TableObject table = new TableObject();
            table.Name = name;
            table.Parent = parent;
            return table;
        }

        /// <summary>
        /// Creates a MatrixObject instance with the specified name and parent.
        /// </summary>
        /// <param name="name">The name of the MatrixObject instance.</param>
        /// <param name="parent">The parent of the MatrixObject instance.</param>
        /// <returns>The MatrixObject instance.</returns>
        public static MatrixObject CreateMatrixObject(string name, Base parent)
        {
            MatrixObject matrix = new MatrixObject();
            matrix.Name = name;
            matrix.Parent = parent;
            return matrix;
        }
#endif
        #endregion // Public Methods
    }
}
