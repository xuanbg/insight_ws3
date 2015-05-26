using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class Group : DialogBase
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

        private SYS_UserGroup _Group;

        #endregion

        #region 构造方法

        public Group()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件处理

        /// <summary>
        /// 如果是编辑模式，加载该ID的用户组信息并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_Load(object sender, EventArgs e)
        {
            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                _Group = IsEdit ? cli.GetGroup(OpenForm.UserSession, ObjectId) : new SYS_UserGroup();
            }

            Text = IsEdit ? "编辑用户组" : "新建用户组";
            txtGroupName.Text = _Group.Name;
            memDescription.Text = _Group.Description;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 构造回传数据
        /// </summary>
        /// <param name="id"></param>
        private void SetObjectData(Guid id)
        {
            ObjectData["ID"] = id;
            ObjectData["组名称"] = _Group.Name;
            ObjectData["描述"] = _Group.Description;
            ObjectData["内置"] = false;
        }

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtGroupName.EditValue == null)
            {
                General.ShowWarning("必须输入用户组名称！");
                txtGroupName.Focus();
                return false;
            }
            if (_Group.Name != txtGroupName.Text.Trim() && Commons.NameIsExist(txtGroupName.Text.Trim(), "Name", "SYS_UserGroup"))
            {
                General.ShowWarning(string.Format("用户组【{0}】已经存在！", txtGroupName.Text.Trim()));
                txtGroupName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region 重写虚方法

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _Group.Name = txtGroupName.Text.Trim();
            _Group.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();

            using (var cli = new BaseClient(OpenForm.Binding, OpenForm.Address))
            {
                if (IsEdit)
                {
                    if (!cli.UpdateGroup(OpenForm.UserSession, _Group))
                    {
                        General.ShowError(string.Format("没有更新用户组【{0}】的任何信息！", _Group.Name));
                        return;
                    }
                    
                    SetObjectData(_Group.ID);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    var id = cli.AddGroup(OpenForm.UserSession, _Group);
                    if (id == null)
                    {
                        General.ShowError("新建用户组【" + _Group.Name + "】失败！");
                        return;
                    }
                    
                    SetObjectData((Guid) id);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        #endregion

    }
}
