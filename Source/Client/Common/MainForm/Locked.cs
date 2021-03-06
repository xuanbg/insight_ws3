﻿using System;
using System.Windows.Forms;

namespace Insight.WS.Client.Common
{
    public partial class Unlock : DialogBase
    {

        #region 构造函数

        public Unlock()
        {
            InitializeComponent();
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 确认按钮事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (General.GetHash(txtUnlockPw.Text.Trim()) != MainForm.Session.Signature)
            {
                General.ShowError("请输入正确的密码，否则无法为您解除锁定！");
                txtUnlockPw.Text = string.Empty;
                txtUnlockPw.Focus();
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 拦截Alt-F4
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | 0x200;
                return cp;
            }
        }

        #endregion

    }
}
