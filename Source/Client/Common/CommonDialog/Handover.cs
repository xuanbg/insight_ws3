﻿using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class Handover : DialogBase
    {

        #region 属性

        /// <summary>
        /// 关系ID
        /// </summary>
        public Guid? MUId { private get; set; }

        /// <summary>
        /// 是否移交
        /// </summary>
        public bool IsTransfer { private get; set; }

        #endregion

        #region 变量声明
        
        private DataTable _Member;

        #endregion

        #region 构造方法

        public Handover()
        {
            InitializeComponent(); 
        }

        #endregion

        #region 界面事件

        private void Transfer_Load(object sender, EventArgs e)
        {
            _Member = Commons.GetAllEmployees();

            Text = IsTransfer ? "移交" : "共享";
            labTarget.Text = IsTransfer ? "移交给：" : "共享给：";
            labDate.Text = IsTransfer ? "移交日期：" : "共享始于：";

            sleTarget.Properties.DataSource = _Member;
            sleTarget.Properties.ValueMember = "ID";
            sleTarget.Properties.DisplayMember = "姓名";
            sleTarget.Properties.PopulateViewColumns();
            Format.GridFormat(gdvTarget);

            datDate.DateTime = DateTime.Now;
            btnConfirm.Enabled = false;
        }

        private void sleTarget_EditValueChanged(object sender, EventArgs e)
        {
            btnConfirm.Enabled = true;
        }

        #endregion
        
        #region 重写确定按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (General.ShowConfirm(string.Format("您确认要{0}给【{1}】吗？", Text, sleTarget.Text)) != DialogResult.OK)
            {
                return;
            }

            var owner = new MDR_MU
            {
                MasterDataId = ObjectId,
                UserId = (Guid) sleTarget.EditValue,
                IsMaster = IsTransfer,
                EffectiveDate = datDate.DateTime.Date
            };

            using (var cli = new CommonsClient(MainForm._Binding, MainForm._Address))
            {
                if (cli.Transfer(MainForm._Session, MUId, owner))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("数据保存失败！如多次保存失败，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
