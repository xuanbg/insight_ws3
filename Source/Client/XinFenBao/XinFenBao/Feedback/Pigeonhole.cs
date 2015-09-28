using System;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class Pigeonhole : DialogBase
    {

        #region 属性

        #endregion

        #region 变量声明

        private MDE_Member_Feedback _Feedback;

        #endregion

        #region 构造函数

        public Pigeonhole()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pigeonhole_Load(object sender, EventArgs e)
        {
            using (var cli = new ManagerClient(OpenForm.Binding, OpenForm.Address))
            {
                _Feedback = cli.GetFeedback(OpenForm.UserSession, ObjectId);
            }

            memMessage.EditValue = _Feedback.Complaint;
            memReturn.EditValue = _Feedback.Reply;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 点击确定保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (memDesc.EditValue == null)
            {
                General.ShowWarning("归档备注不能为空！请输入归档备注。");
                memDesc.Focus();
                return;
            }

            _Feedback.Description = memDesc.Text.Trim();
            using (var cli = new ManagerClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.Pigeonhole(OpenForm.UserSession, _Feedback))
                {
                    General.ShowWarning("对不起，归档失败！如多次保存失败，请联系管理员。");
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
