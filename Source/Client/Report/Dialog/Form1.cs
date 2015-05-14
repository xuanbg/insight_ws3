using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SERP.Client.Platform.Report.Dialog
{
    public partial class Form1 : Form
    {
        private DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();

        private DataTable data = new DataTable();
        private DataTable dtData4 = new DataTable();
        public Form1()
        {
            InitializeComponent();

            dtData4.Columns.Add("ID");
            dtData4.Columns.Add("Name");
            dtData4.Columns.Add("Sex");
            DataRow drData;
            drData = dtData4.NewRow();
            drData[0] = 2;
            drData[1] = "李四";
            drData[2] = "女";
            dtData4.Rows.Add(drData);
            drData = dtData4.NewRow();
            drData[0] = 4;
            drData[1] = "小芳";
            drData[2] = "女";
            dtData4.Rows.Add(drData);
        }
       
    }
}
