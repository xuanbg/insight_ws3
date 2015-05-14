using System;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.Platform.Base
{
    public partial class MyDesktop : MdiBase
    {

        #region 构造函数

        public MyDesktop()
        {
            InitializeComponent();

            // 初始化查询条件
            datStart.DateTime = DateTime.Now.AddMonths(-1).AddDays(1);
            datEnd.DateTime = DateTime.Now;
        }

        #endregion

        #region 私有方法

        #endregion

        #region 界面事件

        private void MyDesktop_Load(object sender, EventArgs e)
        {
            InitToolBar();
        }

        private void StartDateChanged(object sender, EventArgs e)
        {
            if (datStart.EditValue != null)
            {
                datEnd.Properties.MinValue = datStart.DateTime;
            }
        }

        private void EndDateChanged(object sender, EventArgs e)
        {
            if (datEnd.EditValue != null)
            {
                datStart.Properties.MaxValue = datEnd.DateTime;
            }
        }

        private void cmbType_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_EditValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region 按钮事件

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
