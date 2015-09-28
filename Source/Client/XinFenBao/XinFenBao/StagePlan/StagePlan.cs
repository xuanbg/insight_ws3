using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.XinFenBao.Service;

namespace Insight.WS.Client.XinFenBao
{
    public partial class StagePlan : DialogBase
    {

        #region 属性

        /// <summary>
        /// 分期方案列表
        /// </summary>
        public List<BIZ_StagePlan> StagePlans { get; set; }

        #endregion

        #region 变量声明

        private BIZ_StagePlan _StagePlan;

        #endregion

        #region 构造函数

        public StagePlan()
        {
            InitializeComponent();

            cbxUserType.Properties.Items.Add("行业版用户");
            cbxUserType.Properties.Items.Add("市场版用户");
            cbxUserType.Properties.Items.Add("信分宝用户");
            cbxUserType.SelectedIndex = 0;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 输入分期数后检查是否存在同期数未生效分期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStageNum_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Value.ToString())) return;

            if (StagePlans.Exists(p => p.StageNum == Convert.ToInt32(e.Value) && p.EffectiveDate > DateTime.Now))
            {
                General.ShowWarning("已经存在相同分期数的未生效分期方案！请等该分期方案生效后再进行操作。");
            }

            var type = cbxUserType.SelectedIndex == 0 ? -9 : (cbxUserType.SelectedIndex == 1 ? -1 : -5);
            datEffective.Properties.MinValue = StagePlans.Exists(p => p.StageNum == Convert.ToInt32(e.Value) && p.UserType == type) ? DateTime.Now : DateTime.MinValue;
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
            if (string.IsNullOrEmpty(txtStageNum.Text.Trim()))
            {
                General.ShowWarning("分期数不能为空！请输入分期数。");
                txtStageNum.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtRate.Text.Trim()))
            {
                General.ShowWarning("费率不能为空！请输入费率。");
                txtRate.Focus();
                return;
            }

            if (datEffective.EditValue == null)
            {
                General.ShowWarning("生效日期不能为空！请选择生效日期。");
                datEffective.Focus();
                return;
            }

            _StagePlan = new BIZ_StagePlan
            {
                StageNum = Convert.ToInt32(txtStageNum.EditValue),
                Rate = Convert.ToDecimal(txtRate.EditValue) / 100,
                EffectiveDate = datEffective.DateTime.Date,
                Description = memDescription.Text.Trim()
            };
            switch (cbxUserType.SelectedIndex)
            {
                case 1:
                    _StagePlan.UserType = -1;
                    break;
                case 2:
                    _StagePlan.UserType = -5;
                    break;
                default:
                    _StagePlan.UserType = -9;
                    break;
            }
            using (var cli = new ManagerClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.AddStagePlan(OpenForm.UserSession, _StagePlan))
                {
                    General.ShowWarning("对不起，分期方案保存失败！如多次保存失败，请联系管理员。");
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
