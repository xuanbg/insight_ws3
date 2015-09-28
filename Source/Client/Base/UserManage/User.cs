using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class User : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 返回结果集
        /// </summary>
        public DataRow ObjectData { get; set; }

        #endregion

        #region 变量声明

        private SYS_User _User;

        #endregion

        #region 构造方法

        public User()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件处理

        /// <summary>
        /// 如果是编辑模式，加载该ID的用户信息并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_Load(object sender, EventArgs e)
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _User = IsEdit ? cli.GetUser(OpenForm.UserSession, ObjectId) : new SYS_User();
            }

            Text = IsEdit ? "编辑用户" : "新建用户";
            txtUserName.EditValue = _User.Name;
            txtLoginName.EditValue = _User.LoginName;
            memDescription.EditValue = _User.Description;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 检查是否存在重名，如重名则自动加一位随机数字直至不重名
        /// </summary>
        private bool CheckName()
        {
            if (_User.LoginName == txtLoginName.Text.Trim() || !Commons.NameIsExist(txtLoginName.Text.Trim(), "LoginName", "SYS_User")) return true;

            var i = new Random();
            var loginName = txtLoginName.Text + i.Next(1, 9);
            if (General.ShowConfirm($"用户【{txtLoginName.Text}】已经存在！\n\r是否修改为{loginName}？") == DialogResult.OK)
            {
                txtLoginName.Text = loginName;
                CheckName();
                return true;
            }

            txtLoginName.Focus();
            return false;
        }

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtUserName.EditValue == null)
            {
                General.ShowWarning("必须输入用户名！用户名一般是用户的姓名。");
                txtUserName.Focus();
                return false;
            }

            if (txtLoginName.EditValue == null)
            {
                General.ShowWarning("必须输入登录名！登录名只能是英文字母组成。");
                txtLoginName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 构造回传数据
        /// </summary>
        /// <param name="id"></param>
        private void SetObjectData(Guid id)
        {
            ObjectData["ID"] = id;
            ObjectData["名称"] = _User.Name;
            ObjectData["登录名"] = _User.LoginName;
            ObjectData["描述"] = _User.Description;
            ObjectData["内置"] = false;
            ObjectData["状态"] = "正常";
        }

        #endregion

        #region 重写虚方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            if (!CheckName()) return;

            _User.Name = txtUserName.Text.Trim();
            _User.LoginName = txtLoginName.Text.Trim();
            _User.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (!cli.UpdateUser(OpenForm.UserSession, _User))
                    {
                        General.ShowError($"没有更新用户【{_User.LoginName}】的任何信息！");
                        return;
                    }
                    
                    DialogResult = DialogResult.OK;
                    SetObjectData(_User.ID);
                }
                else
                {
                    _User.ID = Guid.NewGuid();
                    if (!cli.AddUser(OpenForm.UserSession, _User))
                    {
                        General.ShowError($"新建用户【{_User.LoginName}】失败！");
                        return;
                    }
                    
                    DialogResult = DialogResult.OK;
                    SetObjectData(_User.ID);
                }
            }
        }

        #endregion

    }
}
