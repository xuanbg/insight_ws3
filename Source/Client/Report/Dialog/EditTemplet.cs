using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    public partial class EditTemplet : DialogBase
    {

        #region 属性

        /// <summary>
        /// 返回数据集
        /// </summary>
        public DataRow ObjectData { get; set; }

        #endregion

        #region 变量声明

        private SYS_Report_Templates _Templet;

        #endregion

        #region 构造函数

        public EditTemplet()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件处理

        private void EditTemplet_Load(object sender, EventArgs e)
        {
            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                _Templet = cli.GetTemplate(OpenForm.UserSession, ObjectId);
            }

            var mid = Guid.Parse("DD46BA9F-A345-4CEC-AE00-26561460E470");
            Format.InitTreeListLookUpEdit(trlCategory, Commons.Categorys(mid, true));

            trlCategory.EditValue = _Templet.CategoryId;
            txtName.Text = _Templet.Name;
            memDescription.Text = _Templet.Description;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("请输入模板名称！");
                txtName.Focus();
                return false;
            }

            if (_Templet.Name != txtName.Text.Trim() && Commons.NameIsExist((Guid)trlCategory.EditValue, txtName.Text.Trim(), "Name", "SYS_Report_Templates"))
            {
                General.ShowWarning("对不起，同一分类下模板名称不能相同！");
                txtName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 重写确定按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _Templet.CategoryId = (Guid)trlCategory.EditValue;
            _Templet.Name = txtName.Text.Trim();
            _Templet.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new ReportClient(OpenForm.Binding, OpenForm.Address))
            {
                if (!cli.EditTemplets(OpenForm.UserSession, _Templet))
                {
                    General.ShowError("对不起，修改后的内容没有保存成功！请再试一次。");
                    return;
                }
                
                ObjectData["CategoryId"] = _Templet.CategoryId;
                ObjectData["名称"] = _Templet.Name;
                ObjectData["描述"] = _Templet.Description;
                DialogResult = DialogResult.OK;
            }
        }

        #endregion

    }
}
