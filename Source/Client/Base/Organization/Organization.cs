using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using Insight.WS.Client.Common;
using Insight.WS.Client.Platform.Base.Service;

namespace Insight.WS.Client.Platform.Base
{
    public partial class Organization : MdiBase
    {

        #region 变量声明

        private DataTable _Orgs;
        private DataTable _Members;
        private List<Guid> _SubNodes;
        private List<Guid> _NodeList;
        private Guid _ObjectId;
        private int _NodeType;

        #endregion

        #region 构造函数

        public Organization()
        {
            InitializeComponent();
            treOrgList.SelectImageList = imgOrgTreeNode;
            treOrgList.FocusedNodeChanged += treOrgList_FocusedNodeChanged;
            treOrgList.CustomDrawNodeImages += Format.CustomDrawOrgTreeNodeImages;
        }


        #endregion

        #region 界面事件处理

        /// <summary>
        /// 1、空初始化成员列表
        /// 2、如组织机构树为空，将编辑等按钮设置为不可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Organization_Load(object sender, EventArgs e)
        {
            InitToolBar();
            InitOrgTree();
        }

        /// <summary>
        /// 1、选择节点后显示节点成员列表
        /// 2、设置编辑等按钮为可用
        /// 3、根据所选节点类型设置：添加成员、移除成员按钮是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treOrgList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;

            _ObjectId = (Guid)e.Node.GetValue("ID");
            var type = (int)e.Node.GetValue("NodeType");
            var canDel = e.Node.Nodes.Count == 0;
            var canAdd = type == 3;
            var canRemove = (type == 3 && _Members.Select(string.Format("TitleId = '{0}'", _ObjectId)).Length > 0);
            SwitchItemStatus(new Context("EditOrg", true), new Context("DeleteOrg", canDel), new Context("Merge", CanMerge(type)), new Context("Move", CanMove(type)), new Context("AddMember", canAdd), new Context("Remove", canRemove));
            InitMember();
        }

        /// <summary>
        /// 刷新树后根据节点数量切换工具栏图标可用状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treOrgList_NodesReloaded(object sender, EventArgs e)
        {
            if (_Orgs.Rows.Count == 0)
            {
                SwitchItemStatus(new Context("EditOrg", false), new Context("DeleteOrg", false), new Context("Move", false), new Context("Merge", false), new Context("AddMember", false), new Context("Remove", false));
                InitMember();
            }
            else if (treOrgList.FocusedNode != null)
            {
                _ObjectId = (Guid)treOrgList.FocusedNode.GetValue("ID");
                var type = (int)treOrgList.FocusedNode.GetValue("NodeType");
                var canDel = treOrgList.FocusedNode.Nodes.Count == 0;
                var canAdd = type == 3;
                var canRemove = (type == 3 && _Members.Select(string.Format("TitleId = '{0}'", _ObjectId)).Length > 0);
                SwitchItemStatus(new Context("EditOrg", true), new Context("DeleteOrg", canDel), new Context("Merge", CanMerge(type)), new Context("Move", CanMove(type)), new Context("AddMember", canAdd), new Context("Remove", canRemove));
            }
        }

        /// <summary>
        /// 双击编辑当前选中节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treOrgList_DoubleClick(object sender, EventArgs e)
        {
            if (treOrgList.FocusedNode != null)
            {
                NodeEdit(true);
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化组织机构树
        /// </summary>
        private void InitOrgTree()
        {
            using (var cli = new BaseClient(Binding, Address))
            {
                _Orgs = cli.GetOrgs(UserSession);
                _Members = cli.GetOrgMembers(UserSession);
            }

            var ids = new List<object>();
            treOrgList.GetNodeList().FindAll(n => n.HasChildren && n.Expanded).ForEach(n => { ids.Add(n.GetValue("ID")); });
            var fid = treOrgList.FocusedNode == null ? null : treOrgList.FocusedNode.GetValue("ID");

            treOrgList.DataSource = _Orgs;
            Format.TreeFormat(treOrgList);
            treOrgList.OptionsView.ShowColumns = true;
            treOrgList.Columns["名称"].Width = 355;
            treOrgList.Columns["全称"].Width = 160;
            treOrgList.Columns["简称"].Width = 100;
            treOrgList.Columns["编码"].Width = 100;
            treOrgList.CollapseAll();
            treOrgList.ExpandToLevel(0);

            ids.ForEach(id => { treOrgList.FindNodeByKeyID(id).Expanded = true; });
            treOrgList.FocusedNode = treOrgList.FindNodeByKeyID(fid);
        }

        /// <summary>
        /// 初始化职位人员列表
        /// </summary>
        private void InitMember()
        {
            var filter = string.Format("TitleId = '{0}'", treOrgList.FocusedNode == null ? "" : treOrgList.FocusedNode.GetValue("ID"));
            var dv = _Members.Copy().DefaultView;
            dv.RowFilter = filter;
            grdMember.DataSource = dv;

            Format.GridFormat(gdvMember);
            gdvMember.Columns["用户名"].Width = 120;
            gdvMember.Columns["登录名"].Width = 100;
        }

        /// <summary>
        /// 根据所选节点的ID、ParentId、NodeType计算可移动的目标节点数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool CanMove(int type)
        {
            _NodeList = new List<Guid>();
            _SubNodes = new List<Guid>();
            SubNodes(_ObjectId);

            var parentId = treOrgList.FocusedNode.GetValue("ParentId");
            var filter = string.Format("NodeType <= {0}", (type == 3 ? 2 : type));
            foreach (var row in _Orgs.Select(filter).Where(row => (type != 3 || (int)row["NodeType"] != 1) && !row["ID"].Equals(parentId)))
            {
                _NodeList.Add((Guid)row["ID"]);
            }

            foreach (var i in _SubNodes)
            {
                _NodeList.Remove(i);
            }
            return _NodeList.Count > 1;
        }

        /// <summary>
        /// 根据所选节点的ID、NodeType计算可合并的目标节点数量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool CanMerge(int type)
        {
            _NodeList = new List<Guid>();
            _SubNodes = new List<Guid>();
            SubNodes(_ObjectId);

            foreach (var row in _Orgs.Select(string.Format("NodeType = {0}", type)))
            {
                _NodeList.Add((Guid)row["ID"]);
            }

            foreach (var i in _SubNodes)
            {
                _NodeList.Remove(i);
            }
            return _NodeList.Count > 1;
        }

        /// <summary>
        /// 获取树中所选节点的子节点
        /// </summary>
        /// <param name="id"></param>
        private void SubNodes(Guid id)
        {
            foreach (var nodeId in _Orgs.Select(string.Format("ParentId = '{0}'", id)).Select(row => (Guid)row["ID"]))
            {
                _SubNodes.Add(nodeId);
                SubNodes(nodeId);
            }
        }

        #endregion

        #region 按钮事件处理

        /// <summary>
        /// 重写工具栏按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Caption)
            {
                case "刷新":
                    InitOrgTree();
                    break;

                case "新建":
                    NodeEdit(false);
                    break;

                case "编辑":
                    NodeEdit(true);
                    break;

                case "删除":
                    NodeRemove();
                    break;

                case "移动":
                    NodeMove();
                    break;

                case "合并":
                    NodeMeger();
                    break;

                case "添加成员":
                    AddMember();
                    break;

                case "移除成员":
                    RemoveMember();
                    break;
            }
        }

        /// <summary>
        /// 新建/编辑组织机构节点
        /// </summary>
        /// <param name="isEdit"></param>
        private void NodeEdit(bool isEdit)
        {
            var dig = new OrgNode
            {
                Owner = this,
                NodeType = _NodeType,
                IsEdit = isEdit,
                ObjectId = _ObjectId
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                _NodeType = dig.NodeType;
                InitOrgTree();
            }
            dig.Close();
        }

        /// <summary>
        /// 删除组织机构节点
        /// </summary>
        private void NodeRemove()
        {
            var fn = treOrgList.FocusedNode.GetValue("名称");
            if (General.ShowConfirm(string.Format("您确定要删除节点【{0}】吗？\r\n节点删除后将无法恢复！", fn)) != DialogResult.OK) return;

            var pn = treOrgList.FocusedNode.ParentNode;
            using (var cli = new BaseClient(Binding, Address))
            {
                if (!cli.DeleteOrg(UserSession, _ObjectId))
                {
                    General.ShowError(string.Format("对不起，【{0}】已经被使用，无法删除！", fn));
                    return;
                }
                
                InitOrgTree();
                treOrgList.FocusedNode = pn == null ? treOrgList.Nodes.FirstNode : (pn.Nodes.Count == 1 ? pn : pn.Nodes[pn.Nodes.Count - 2]);
            }
        }

        /// <summary>
        /// 移动节点
        /// </summary>
        private void NodeMove()
        {
            var dig = new NodeMove
            {
                Owner = this,
                ObjectId = _ObjectId,
                ObjectData = _Orgs.Rows.Find(_ObjectId)
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                _Orgs.Rows.Find(_ObjectId).ItemArray = dig.ObjectData.ItemArray;
                _Orgs.AcceptChanges();
            }
            dig.Close();
        }

        /// <summary>
        /// 合并节点
        /// </summary>
        private void NodeMeger()
        {
            var dig = new NodeMerge
            {
                Owner = this,
                ObjectId = _ObjectId
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                InitOrgTree();
            }
            dig.Close();
        }

        /// <summary>
        /// 添加职位成员
        /// </summary>
        private void AddMember()
        {
            DataTable list;
            using (var cli = new BaseClient(Binding, Address))
            {
                list = cli.GetOrgMemberBeSides(UserSession, _ObjectId);
            }

            var dig = new Member
            {
                IsAdd = true,
                List = list
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                using (var cli = new BaseClient(Binding, Address))
                {
                    if (!cli.AddOrgMember(UserSession, _ObjectId, dig.IdList))
                    {
                        General.ShowError("未能增加任何成员！");
                        return;
                    }
                    
                    InitOrgTree();
                }
            }
            dig.Close();
        }

        /// <summary>
        /// 移除职位成员
        /// </summary>
        private void RemoveMember()
        {
            var dig = new Member
            {
                IsAdd = false,
                List = _Members.Select(string.Format("TitleId = '{0}'", _ObjectId)).CopyToDataTable()
            };
            if (dig.ShowDialog() == DialogResult.OK)
            {
                using (var cli = new BaseClient(Binding, Address))
                {
                    if (!cli.DeleteOrgMember(UserSession, dig.IdList))
                    {
                        General.ShowError("未能移除任何成员！");
                        return;
                    }
                    
                    foreach (var rid in dig.IdList)
                    {
                        _Members.Rows.Find(rid).Delete();
                    }
                    _Members.AcceptChanges();
                    InitMember();
                    treOrgList_NodesReloaded(null, null);
                }
            }
            dig.Close();
        }

        #endregion

    }
}
