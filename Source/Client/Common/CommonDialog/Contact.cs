using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class Contact : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 父数据ID
        /// </summary>
        public Guid ParentId { private get; set; }

        #endregion

        #region 变量声明

        private MasterData _MasterData;
        private MDG_Contact _Contact;
        private DataTable _ContactInfo;
        private DataTable _ContactType;
        private List<object> _OldContacts = new List<object>();

        #endregion

        #region 构造方法

        public Contact()
        {
            InitializeComponent();
        }

        #endregion

        #region 界面事件

        private void Contact_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _Contact = IsEdit ? Commons.GetContact(ObjectId) : new MDG_Contact();
            _ContactInfo = Commons.GetContactInfo(ObjectId);
            _ContactType = Commons.Dictionary("Contact");

            Format.InitLookUpEdit(lokContact, _ContactType);
            InitBaseInfo();
            InitContactInfo();
        }

        /// <summary>
        /// 输入登录账号时根据输入内容启用登录用户复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoginName_EditValueChanged(object sender, EventArgs e)
        {
            chkIsLogin.Enabled = !string.IsNullOrEmpty(txtLoginName.Text.Trim());
        }

        /// <summary>
        /// 选中登录用户复选框时验证帐户名是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (_Contact.LoginUser || !chkIsLogin.Checked || !Commons.NameIsExist(txtLoginName.Text.Trim(), "LoginName", "SYS_User")) return;

            General.ShowError("您输入的登录账号已经存在！请更换登录账号…");
            txtLoginName.Focus();
            chkIsLogin.Checked = false;
        }

        /// <summary>
        /// 新增行后初始化行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "联系方式") return;

            if (gdvContact.GetRowCellValue(e.RowHandle, "ID") == DBNull.Value)
                gdvContact.SetRowCellValue(e.RowHandle, "ID", Guid.NewGuid());

            var alias = _ContactType.Rows.Find(e.Value)["Alias"];
            var isOnly = _ContactInfo.Select($"Alias = '{alias}'").Length == 0;
            gdvContact.SetRowCellValue(e.RowHandle, "Alias", alias);
            gdvContact.SetRowCellValue(e.RowHandle, "主要", isOnly);
        }

        /// <summary>
        /// 设定主要联系方式时保持选中行联系方式设定为主要的有且唯一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0 || e.Column.FieldName != "主要") return;

            var alias = gdvContact.GetDataRow(e.RowHandle)["Alias"];
            var isOnly = _ContactInfo.Select($"Alias = '{alias}'").Length == 0;
            if (!isOnly)
                _ContactInfo.Select($"Alias = '{gdvContact.GetDataRow(e.RowHandle)["Alias"]}'").ToList().ForEach(r => r["主要"] = 0);
            gdvContact.SetRowCellValue(e.RowHandle, "主要", true);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            gdvContact.DeleteSelectedRows();
            _ContactInfo.AcceptChanges();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化界面控件初始值
        /// </summary>
        private void InitBaseInfo()
        {
            Text = IsEdit ? "编辑联系人" : "新建联系人";
            txtLastName.EditValue = _Contact.LastName;
            txtFirstName.EditValue = _Contact.FirstName;
            txtMiddleName.EditValue = _Contact.MiddleName;
            cmbGender.SelectedIndex = _Contact.Gender ?? -1;
            datBirthday.EditValue = _Contact.Birthday;
            txtDepartment.EditValue = _Contact.Department;
            txtTitle.EditValue = _Contact.Title;
            txtLoginName.EditValue = _MasterData.Alias;
            chkIsLogin.Checked = _Contact.LoginUser;
            chkIsMaster.Checked = _Contact.IsMaster;
            txtOffice.EditValue = _Contact.OfficeAddress;
            txtHome.EditValue = _Contact.HomeAddress;
            memDescription.EditValue = _Contact.Description;
            txtLoginName.Enabled = !_Contact.LoginUser || txtLoginName.EditValue == null;
            chkIsLogin.Enabled = !_Contact.LoginUser && txtLoginName.EditValue != null;
            chkIsMaster.Enabled = !chkIsMaster.Checked;
        }

        /// <summary>
        /// 初始化联系方式列表
        /// </summary>
        private void InitContactInfo()
        {
            grdContact.DataSource = _ContactInfo;
            Format.GridFormat(gdvContact, 36, true);
            gdvContact.OptionsBehavior.EditorShowMode = EditorShowMode.MouseUp;
            gdvContact.Columns["联系方式"].ColumnEdit = lokContact;
            gdvContact.Columns["联系方式"].Width = 120;
            gdvContact.Columns["号码"].Width = 232;
            gdvContact.Columns["主要"].Width = 40;
            _ContactInfo.Select().ToList().ForEach(r => _OldContacts.Add(r["ID"]));
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                General.ShowWarning("请输入联系人姓名！");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                General.ShowWarning("请输入联系人姓名！");
                txtFirstName.Focus();
                return false;
            }

            foreach (DataRow row in _ContactInfo.Rows)
            {
                if (row["号码"] == DBNull.Value)
                {
                    General.ShowError($"没有输入{_ContactType.Rows.Find(row["联系方式"])["Name"]}号码！请输入正确的号码…");
                    return false;
                }
                if (!General.CheckInput(row["Alias"].ToString(), row["号码"].ToString()))
                {
                    General.ShowError($"{row["号码"]}不是合法的{_ContactType.Rows.Find(row["联系方式"])["Name"]}号码！请输入正确的号码…");
                    return false;
                }
                if (CheckMaster(row["Alias"]) > 1)
                {
                    General.ShowError($"有多个{_ContactType.Rows.Find(row["联系方式"])["Name"]}号码被设置为主要联系方式！请选择正确选择主要联系方式…");
                    return false;
                }
                if (CheckMaster(row["Alias"]) == 0)
                {
                    row["主要"] = true;
                }
            }
            return true;
        }

        /// <summary>
        /// 计算输入联系方式设置为主要的记录数量
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int CheckMaster(object obj)
        {
            return _ContactInfo.Select($"Alias = '{obj}'").Count(row => (bool) row["主要"]);
        }

        #endregion

        #region 按钮事件

        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.ParentId = ParentId;
            _MasterData.Name = txtLastName.Text.Trim() + txtFirstName.Text.Trim();
            _MasterData.Alias = txtLoginName.Text.Trim();

            _Contact.LastName = txtLastName.Text.Trim();
            _Contact.FirstName = txtFirstName.Text.Trim();
            _Contact.MiddleName = txtMiddleName.Text.Trim();
            _Contact.Gender = cmbGender.SelectedIndex;
            _Contact.Department = txtDepartment.Text.Trim();
            _Contact.Title = txtTitle.Text.Trim();
            _Contact.OfficeAddress = txtOffice.Text.Trim();
            _Contact.HomeAddress = txtHome.Text.Trim();
            _Contact.Birthday = (DateTime?)datBirthday.EditValue;
            _Contact.Description = memDescription.Text.Trim();
            _Contact.IsMaster = chkIsMaster.Checked;
            _Contact.LoginUser = chkIsLogin.Checked;

            foreach (var row in _ContactInfo.Rows.Cast<DataRow>().Where(row => row.RowState == DataRowState.Unchanged))
            {
                _OldContacts.Remove(row["ID"]);
                row.Delete();
            }
            _ContactInfo.AcceptChanges();

            if (IsEdit)
            {
                if (Commons.UpdateContact(_MasterData, _Contact, _OldContacts, _ContactInfo))
                    DialogResult = DialogResult.OK;
                else
                    General.ShowError("未能更新数据！");
            }
            else
            {
                if (Commons.AddContact(_MasterData, _Contact, _ContactInfo))
                    DialogResult = DialogResult.OK;
                else
                    General.ShowError("数据保存失败！");
            }
        }

        #endregion

    }
}
