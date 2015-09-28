using System;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class Reply : DialogBase
    {

        #region 属性

        #endregion

        #region 变量声明

        private MDE_Member_Feedback _Feedback;

        #endregion

        #region 构造函数

        public Reply()
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
        private void Reply_Load(object sender, EventArgs e)
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
            if (memReturn.EditValue == null)
            {
                General.ShowWarning("回复内容不能为空！请输入回复内容。");
                memReturn.Focus();
                return;
            }

            _Feedback.Reply = memReturn.Text.Trim();
            using (var cli = new ManagerClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.SaveReply(OpenForm.UserSession, _Feedback))
                {
                    General.ShowWarning("对不起，回复内容保存失败！如多次保存失败，请联系管理员。");
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
