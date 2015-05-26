using System;
using System.IO;
using System.Windows.Forms;
using Insight.WS.Client.Business.Settlement.Service;
using Insight.WS.Client.Common;

namespace Insight.WS.Client.Business.Settlement
{
    public partial class Check : DialogBase
    {

        #region 属性

        /// <summary>
        /// 结账单模板ID
        /// </summary>
        public Guid TempletId { private get; set; }

        /// <summary>
        /// 结账单编码方案ID
        /// </summary>
        public Guid SchemeId { private get; set; }

        /// <summary>
        /// 结账流程ID
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Guid WorkflowId { get; set; }

        #endregion

        #region 构造方法

        public Check()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时初始化数据及界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReceipt_Load(object sender, EventArgs e)
        {
            pvcReport.Load(new MemoryStream(Commons.BuildImageData(Guid.Empty, TempletId).Image));
        }

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            using (var cli = new SettlementClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.AddCheck(OpenForm.UserSession, TempletId, SchemeId))
                {
                    General.ShowError("结账信息保存失败！如多次失败，请联系管理员。");
                    return;
                }
                
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
