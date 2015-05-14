using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Report.Service;

namespace Insight.WS.Client.Platform.Report.Dialog
{
    public partial class CopyTemplet : DialogBase
    {

        #region 属性

        /// <summary>
        /// 返回数据集
        /// </summary>
        public DataRow ObjectData { private get; set; }

        #endregion

        #region 变量声明

        private ReportClient _Client;
        private SYS_Report_Templates _Templet;

        #endregion

        #region 构造函数

        public CopyTemplet()
        {
            InitializeComponent();
            treCategory.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        private void CopyTemplet_Load(object sender, EventArgs e)
        {
            var mid = Guid.Parse("DD46BA9F-A345-4CEC-AE00-26561460E470");
            Format.InitTreeListLookUpEdit(trlCategory, Commons.Categorys(mid, true));
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
            if (string.IsNullOrEmpty(trlCategory.Text.Trim()))
            {
                General.ShowWarning("请选择模板分类！");
                trlCategory.Focus();
                return false;
            }
            if (Commons.NameIsExist((Guid)trlCategory.EditValue, txtName.Text.Trim(), "Name", "SYS_Report_Templates"))
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

            _Templet = new SYS_Report_Templates
            {
                Name = txtName.Text.Trim(),
                CategoryId = (Guid) trlCategory.EditValue,
                Description = memDescription.EditValue == null ? null : memDescription.Text.Trim(),
                CreatorUserId = OpenForm.UserSession.UserId,
                CreatorDeptId = OpenForm.UserSession.DeptId
            };

            _Client = new ReportClient(OpenForm.Binding, OpenForm.Address);
            var id = _Client.CopyTemplet(OpenForm.UserSession, ObjectId, _Templet);
            _Client.Close();

            if (id != null)
            {
                ObjectData["ID"] = (Guid)id;
                ObjectData["CategoryId"] = _Templet.CategoryId;
                ObjectData["名称"] = _Templet.Name;
                ObjectData["描述"] = _Templet.Description;
                ObjectData["创建人"] = OpenForm.UserSession.UserName;
                ObjectData["创建日期"] = DateTime.Now;

                DialogResult = DialogResult.OK;
            }
            else
            {
                General.ShowError("对不起，模板复制失败！如果连续失败，请联系管理员。");
            }
        }

        #endregion

    }
}
