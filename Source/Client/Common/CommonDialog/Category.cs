using System;
using System.Data;
using System.Windows.Forms;
using Insight.WS.Client.Common.Service;

namespace Insight.WS.Client.Common
{
    public partial class Category : DialogBase
    {

        #region 属性

        /// <summary>
        /// 模块Id
        /// </summary>
        public Guid ModuleId { private get; set; }

        /// <summary>
        /// 是否编辑对象
        /// </summary>
        public bool IsEdit { private get; set; }

        /// <summary>
        /// 是否可编辑根分类
        /// </summary>
        public bool AllowEditRoot { private get; set; }

        #endregion

        #region 变量声明

        private BASE_Category _Category;
        private DataTable _Categorys;
        private Guid? _ParentId;
        private int _IndexValue;
        private int _Index;

        #endregion

        #region 构造方法

        public Category()
        {
            InitializeComponent();
            treParent.CustomDrawNodeImages += Format.CustomDrawFolderNodeImages;
        }

        #endregion

        #region 界面事件

        private void Category_Load(object sender, EventArgs e)
        {
            _Categorys = Commons.Categorys(ModuleId);

            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                _Category = IsEdit ? cli.GetCategory(MainForm.Session, ObjectId) : new BASE_Category();
            }
            _ParentId = IsEdit ? _Category.ParentId : (ObjectId == Guid.Empty) ? null : (Guid?)ObjectId;
            InitInfo();
        }
        
        /// <summary>
        /// EditValue发生变化后：
        /// 1、改变索引值
        /// 2、如新的父分类下存在重名，提示用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tleParent_EditValueChanged(object sender, EventArgs e)
        {
            var id = (Guid?)trlParent.EditValue;
            SetIndexValue(id);

            var dv = _Categorys.Copy().DefaultView;
            dv.RowFilter = (id == null) ? string.Format("ParentId is null and Name = '{0}'", txtName.Text) : string.Format("ParentId = '{0}' and Name = '{1}'", id, txtName.Text);
            if (dv.Count > 0)
            {
                General.ShowMessage("您所选择的父分类下已经存在同名分类！请修改分类名称或重新选择父分类。");
            }
        }

        /// <summary>
        /// 父节点为根被选中/取消选中时切换父节点EditValue和控件可用状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRoot.Checked)
            {
                trlParent.EditValue = null;
                trlParent.Enabled = false;
            }
            else
            {
                trlParent.EditValue = _ParentId;
                trlParent.Enabled = true;
            }
        }

        #endregion

        #region 私有方法

        private void InitInfo()
        {
            _ParentId = IsEdit ? _Category.ParentId : (ObjectId == Guid.Empty) ? null : (Guid?)ObjectId;
            Text = IsEdit ? "编辑分类" : "新建分类";
       
            if (_Categorys.Rows.Count == 0)
            {
                chkRoot.Enabled = false;
                _IndexValue = 1;
            }
            else if (IsEdit)
            {
                RemoveNode(_Category.ID);
                _IndexValue = _Category.Index;
                SetIndexValue(_Category.ParentId);
            }

            Format.InitTreeListLookUpEdit(trlParent, _Categorys);

            trlParent.EditValue = _ParentId;
            chkRoot.Checked = trlParent.EditValue == null;
            chkRoot.Enabled = AllowEditRoot;
            txtName.EditValue = _Category.Name;
            txtAlias.EditValue = _Category.Alias;
            txtCode.EditValue = _Category.Code;
            memDescription.EditValue = _Category.Description;
        }

        /// <summary>
        /// 移除无关节点（自身及子节点）
        /// </summary>
        private void RemoveNode(Guid? id)
        {
            SubNodes(id);
            _Categorys.Rows.Find(id).Delete();
            _Categorys.AcceptChanges();
        }

        /// <summary>
        /// 递归删除子节点
        /// </summary>
        /// <param name="id"></param>
        private void SubNodes(Guid? id)
        {
            foreach (var row in _Categorys.Select(string.Format("ParentId = '{0}'", id)))
            {
                SubNodes((Guid)row["ID"]);
                row.Delete();
            }
        }

        /// <summary>
        /// 设置Index值
        /// </summary>
        /// <param name="id"></param>
        private void SetIndexValue(Guid? id)
        {
            var dv = _Categorys.Copy().DefaultView;
            dv.RowFilter = (id == null) ? "ParentId is null" : string.Format("ParentId = '{0}'", id);
            var maxValue = dv.Count + 1;
            _IndexValue = IsEdit ? _IndexValue : maxValue;
            _Index = id == _ParentId ? _IndexValue : maxValue;
            spiIndex.Properties.MinValue = 1;
            spiIndex.Properties.MaxValue = maxValue;
            spiIndex.Value = _Index;
        }

        /// <summary>
        /// 数据合法性校验
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                General.ShowError("分类名称不能为空！请输入正确的名称。");
                txtName.Focus();
                return false;
            }

            if (_Category.Name != txtName.Text.Trim() && Commons.NameIsExist(ModuleId, (Guid?)trlParent.EditValue, "Name", txtName.Text.Trim()))
            {
                General.ShowError(string.Format("对不起，在父分类【{0}】中已存在名称为【{1}】的分类！\n\r请修改分类名称后再点击确定按钮保存数据。", trlParent.Text, txtName.Text));
                txtName.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtAlias.Text.Trim()) && _Category.Alias != txtAlias.Text.Trim() && Commons.NameIsExist(ModuleId, "Alias", txtAlias.Text.Trim()))
            {
                General.ShowError( string.Format("对不起，已经存在名为【{0}】的简称！分类简称可以为空，但不能重复。", txtAlias.Text));
                txtAlias.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtCode.Text.Trim()) && _Category.Code != txtCode.Text.Trim() && Commons.NameIsExist(ModuleId, "Code", txtCode.Text.Trim()))
            {
                General.ShowError(string.Format("对不起，已经存在名为【{0}】的编码！分类编码可以为空，但不能重复。", txtCode.Text));
                txtCode.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新对象实体属性值
        /// </summary>
        private void ObjectAssign()
        {
            _Category.ParentId = (Guid?)trlParent.EditValue;
            _Category.Index = (int)spiIndex.Value;
            _Category.Name = txtName.Text.Trim();
            _Category.Alias = txtAlias.Text.Trim();
            _Category.Code = txtCode.Text.Trim();
            _Category.Description = memDescription.EditValue == null ? null : memDescription.Text.Trim();
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 点击确定后提交更新或插入新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Confirm_Click(object sender, EventArgs e)
        {
            if (!IsValid()) return;

            ObjectAssign();

            using (var cli = new CommonsClient(MainForm.Binding, MainForm.Address))
            {
                if (IsEdit)
                {
                    if (cli.UpdateCategory(MainForm.Session, _Category, _Index, _ParentId, _IndexValue))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("对不起，因为未知的原因，更新" + _Category.Name + "】失败！\r\n如出现重复失败的情况，请联系管理员。");
                }
                else
                {
                    _Category.ModuleId = ModuleId;
                    _Category.CreatorDeptId = OpenForm.UserSession.DeptId;
                    _Category.CreatorUserId = OpenForm.UserSession.UserId;

                    if (cli.AddCategory(MainForm.Session, _Category, _IndexValue))
                        DialogResult = DialogResult.OK;
                    else
                        General.ShowError("对不起，因为未知的原因，新建" + _Category.Name + "】失败！\r\n如出现重复失败的情况，请联系管理员。");
                }
            }
        }

        #endregion

    }
}
