using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Insight.WS.Client.Common;
using Insight.WS.Client.Common.Service;
using Insight.WS.Client.MasterDatas.Service;

namespace Insight.WS.Client.MasterDatas
{
    public partial class EmployeeData : DialogBase
    {

        #region 属性

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { get; set; }

        #endregion

        #region 变量声明

        private MasterDatasClient _Client;
        private MasterData _MasterData;
        private MDG_Employee _Employee;
        private MDR_ET _Title;
        private DataTable _ContactInfo;
        private DataTable _OrgList;
        private DataTable _ContactType;
        private List<object> _OldContacts = new List<object>();

        #endregion

        #region 构造方法

        public EmployeeData()
        {
            InitializeComponent();
            treTitle.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 窗体加载时加载数据并初始化界面控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeData_Load(object sender, EventArgs e)
        {
            _MasterData = IsEdit ? Commons.GetMasterData(ObjectId) : new MasterData();
            _ContactType = Commons.Dictionary("Contact");
            _ContactInfo = Commons.GetContactInfo(ObjectId);
            _OrgList = Commons.OrgTree();

            _Client = new MasterDatasClient(OpenForm.Binding, OpenForm.Address);
            _Employee = IsEdit ? _Client.GetEmployee(OpenForm.UserSession, ObjectId) : new MDG_Employee();
            _Title = IsEdit ? _Client.GetEmployeeTitle(OpenForm.UserSession, ObjectId) : new MDR_ET();
            _Client.Close();

            var dv = _OrgList.Copy().DefaultView;
            dv.RowFilter = string.Format("ParentId = '{0}'", ObjectId);
            Format.InitTreeListLookUpEdit(trlTitle, IsEdit ? _OrgList.DefaultView : dv);
            Format.InitSearchLookUpEdit(sleLeader, Commons.GetAllEmployees(), "姓名");
            Format.InitGridLookUpEdit(grlWorkType, Commons.Dictionary("WorkType"));
            Format.InitLookUpEdit(lokContact, _ContactType);
            InitBaseInfo();
            InitContactInfo();
        }

        /// <summary>
        /// 职位选择不正确时清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlTitle_EditValueChanged(object sender, EventArgs e)
        {
            if (trlTitle.EditValue == null) return;

            if ((int)_OrgList.Rows.Find(trlTitle.EditValue)["NodeType"] < 3)
            {
                trlTitle.EditValue = null;
            }
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
            if (!_Employee.LoginUser && chkIsLogin.Checked)
            {
                if (Commons.NameIsExist(txtLoginName.Text.Trim(), "LoginName", "SYS_User"))
                {
                    General.ShowError("您输入的登录账号已经存在！请更换登录账号…");
                    txtLoginName.Focus();
                    chkIsLogin.Checked = false;
                }
            }
        }

        /// <summary>
        /// 新增行后初始化行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (gdvContact.GetRowCellValue(e.RowHandle, "ID") == DBNull.Value)
            {
                gdvContact.SetRowCellValue(e.RowHandle, "ID", Guid.NewGuid());
            }
            if (e.Column.FieldName == "联系方式")
            {
                var alias = _ContactType.Rows.Find(e.Value)["Alias"];
                var isOnly = _ContactInfo.Select(string.Format("Alias = '{0}'", alias)).Length == 0;
                gdvContact.SetRowCellValue(e.RowHandle, "Alias", alias);
                gdvContact.SetRowCellValue(e.RowHandle, "主要", isOnly);
            }
        }

        /// <summary>
        /// 设定主要联系方式时保持选中行联系方式设定为主要的有且唯一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "主要")
            {
                var alias = gdvContact.GetDataRow(e.RowHandle)["Alias"];
                var isOnly = _ContactInfo.Select(string.Format("Alias = '{0}'", alias)).Length == 0;
                if (!isOnly)
                {
                    _ContactInfo.Select(string.Format("Alias = '{0}'", gdvContact.GetDataRow(e.RowHandle)["Alias"])).ToList().ForEach(r => r["主要"] = 0);
                }
                gdvContact.SetRowCellValue(e.RowHandle, "主要", true);
            }
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gdvContact.DeleteSelectedRows();
                _ContactInfo.AcceptChanges();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化界面控件初始值
        /// </summary>
        private void InitBaseInfo()
        {
            Text = IsEdit ? "编辑员工" : "新建员工";
            picPhoto.EditValue = _Employee.Photo;
            txtName.EditValue = _MasterData.Name;
            cmbGender.SelectedIndex = _Employee.Gender ?? -1;
            trlTitle.EditValue = IsEdit ? (Guid?)_Title.TitleId : null;
            sleLeader.EditValue = _Employee.DirectLeader;
            txtCode.EditValue = _MasterData.Code;
            grlWorkType.EditValue = _Employee.WorkType;
            datEntry.EditValue = IsEdit ? _Employee.EntryDate : DateTime.Now;
            txtLoginName.EditValue = _MasterData.Alias;
            txtIDCardNo.EditValue = _Employee.IdCardNo;
            chkIsLogin.Checked = _Employee.LoginUser;
            txtOffice.EditValue = _Employee.OfficeAddress;
            txtHome.EditValue = _Employee.HomeAddress;
            memDescription.EditValue = _Employee.Description;
            txtLoginName.Enabled = !_Employee.LoginUser || txtLoginName.EditValue == null;
            chkIsLogin.Enabled = !_Employee.LoginUser && txtLoginName.EditValue != null;
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

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            var pmf = Owner as Employee;
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowWarning("员工姓名不能为空！请输入员工姓名…");
                txtName.Focus();
                return false;
            }
            if (cmbGender.SelectedIndex == -1)
            {
                General.ShowWarning("请为该员工设置性别…");
                cmbGender.Focus();
                return false;
            }
            if (trlTitle.EditValue == null)
            {
                General.ShowWarning("员工职位不能为空！请选择该员工的职位…");
                trlTitle.Focus();
                return false;
            }
            if (pmf._NeedLeader && sleLeader.EditValue == null)
            {
                General.ShowWarning("直属领导不能为空！请选择该员工的直属领导…");
                sleLeader.Focus();
                return false;
            }
            if (pmf._NeedCoed && string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                General.ShowWarning("员工工号不能为空！请输入员工工号…");
                txtCode.Focus();
                return false;
            }
            if (pmf._NeedCoed && txtCode.Text.Trim() != _MasterData.Code && Commons.NameIsExist(txtCode.Text.Trim(), "Code"))
            {
                General.ShowWarning("您输入的工号已经存在！请输入该员工的正确工号…");
                txtCode.Focus();
                return false;
            }
            if (pmf._NeedType && grlWorkType.EditValue == null)
            {
                General.ShowWarning("尚未选择该员工的工种！请选择该员工的工种…");
                grlWorkType.Focus();
                return false;
            }
            if (datEntry.EditValue == null)
            {
                General.ShowWarning("入职日期不能为空！请输入该员工的正确入职日期…");
                datEntry.Focus();
                return false;
            }
            if (pmf._NeedId && string.IsNullOrEmpty(txtIDCardNo.Text))
            {
                General.ShowWarning("身份证号不能为空！请输入该员工的正确二代身份证号码…");
                txtIDCardNo.Focus();
                return false;
            }
            if (pmf._NeedId && (txtIDCardNo.Text.Trim().Length < 18 || !General.CheckIdCard18(txtIDCardNo.Text.Trim())))
            {
                General.ShowWarning("您输入的身份证号不正确！请输入该员工的正确二代身份证号码…");
                txtIDCardNo.Focus();
                return false;
            }

            var hasPhone = false;
            var hanMail = false;
            foreach (DataRow row in _ContactInfo.Rows)
            {
                if (row["号码"] == DBNull.Value)
                {
                    General.ShowWarning(string.Format("没有输入{0}号码！请输入正确的号码…", _ContactType.Rows.Find(row["联系方式"])["Name"]));
                    return false;
                }
                if (!General.CheckInput(row["Alias"].ToString(), row["号码"].ToString()))
                {
                    General.ShowWarning(string.Format("{0}不是合法的{1}号码！请输入正确的号码…", row["号码"], _ContactType.Rows.Find(row["联系方式"])["Name"]));
                    return false;
                }
                if (CheckMaster(row["Alias"]) > 1)
                {
                    General.ShowWarning(string.Format("有多个{0}号码被设置为主要联系方式！请选择正确选择主要联系方式…", _ContactType.Rows.Find(row["联系方式"])["Name"]));
                    return false;
                }
                if (CheckMaster(row["Alias"]) == 0)
                {
                    row["主要"] = true;
                }

                if (row["Alias"].ToString() == "Mobile") hasPhone = true;
                if (row["Alias"].ToString() == "Email") hanMail = true;
            }
            if (pmf._NeedPhone && !hasPhone)
            {
                General.ShowWarning("移动电话不能为空！请输入该员工的移动电话号码…");
                return false;
            }
            if (pmf._NeedMail && !hanMail)
            {
                General.ShowWarning("电子邮件不能为空！请输入该员工的电子邮件地址…");
                return false;
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
            return _ContactInfo.Select(string.Format("Alias = '{0}'", obj)).Count(row => (bool) row["主要"]);
        }

        #endregion

        #region 保存数据

        /// <summary>
        /// 保存修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            _MasterData.Name = txtName.Text.Trim();
            _MasterData.Alias = txtLoginName.Text.Trim();
            _MasterData.Code = txtCode.Text.Trim();

            _Employee.Gender = cmbGender.SelectedIndex;
            _Employee.WorkType = (Guid?) grlWorkType.EditValue;
            _Employee.IdCardNo = txtIDCardNo.Text.Trim();
            _Employee.DirectLeader = (Guid?) sleLeader.EditValue;
            _Employee.OfficeAddress = txtOffice.Text.Trim();
            _Employee.HomeAddress = txtHome.Text.Trim();
            _Employee.Photo = General.ImageToByteArray(picPhoto.Image);
            _Employee.Thumbnail = General.ImageToByteArray(General.GetThumbnail(picPhoto.Image));
            _Employee.EntryDate = datEntry.DateTime;
            _Employee.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();
            _Employee.LoginUser = chkIsLogin.Checked;

            _Title.TitleId = (Guid)trlTitle.EditValue;

            foreach (var row in _ContactInfo.Rows.Cast<DataRow>().Where(row => row.RowState == DataRowState.Unchanged))
            {
                _OldContacts.Remove(row["ID"]);
                row.Delete();
            }
            _ContactInfo.AcceptChanges();

            _Client = new MasterDatasClient(OpenForm.Binding, OpenForm.Address);
            if (IsEdit)
            {
                if (_Client.UpdateEmployee(OpenForm.UserSession, _MasterData, _Employee, _Title, _OldContacts, _ContactInfo))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("未能更新数据！");
                }
            }
            else
            {
                _Employee.Status = 1;
                _Employee.CreatorDeptId = OpenForm.UserSession.DeptId;
                _Employee.CreatorUserId = OpenForm.UserSession.UserId;
                if (_Client.AddEmployee(OpenForm.UserSession, _MasterData, _Employee, _Title, _ContactInfo))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    General.ShowError("数据保存失败！");
                }
            }
            _Client.Close();
        }

        #endregion

    }
}
