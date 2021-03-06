
/*****初始化角色：所有用户*****/

DECLARE @RoleId UNIQUEIDENTIFIER
delete SYS_Role where Name = '所有用户'
insert SYS_Role (Name, Description, BuiltIn) 
select '所有用户', '内置角色，角色成员为全部用户成员', 1;
select @RoleId = ID from Sys_Role where SN = scope_identity()

-- 初始化角色成员
insert SYS_Role_UserGroup (RoleId, GroupId)
select @RoleId, ID from SYS_UserGroup where Name = 'AllUsers'

-- 设置功能权限
insert SYS_RolePerm_Action (RoleId, ActionId, Action)
select @RoleId, A.ID, 1
from SYS_ModuleAction A
where A.ModuleId in('CED5A90C-092E-4B38-B21D-433DFD96BFDB', '05C1B3B4-1536-4DE7-864A-B98C474F438B')
  and A.ID not in('C6D59DAF-18C8-4A05-AA22-BA27CBC4595B', '076890FA-483A-4EBC-9168-D94367741FE9', 'EDBC058A-BDC2-4108-B690-1C2E9E65AD97')

-- 设置数据权限
insert SYS_RolePerm_Data (RoleId, ModuleId, Mode, Permission)
select @RoleId, '5C801552-1905-452B-AE7F-E57227BE70B8', 1, 1 union all
select @RoleId, '5C801552-1905-452B-AE7F-E57227BE70B8', 0, 0
GO


/*****初始化角色：系统管理员*****/

DECLARE @RoleId UNIQUEIDENTIFIER
delete SYS_Role where Name = '系统管理员'
insert SYS_Role (Name, Description, BuiltIn) 
select '系统管理员', '内置角色，角色成员为系统管理员组成员', 1;
select @RoleId = ID from Sys_Role where SN = scope_identity()

-- 初始化角色成员
insert SYS_Role_UserGroup (RoleId, GroupId)
select @RoleId, ID from SYS_UserGroup where Name = 'Administers'

-- 设置功能权限
insert SYS_RolePerm_Action (RoleId, ActionId, Action)
select @RoleId, A.ID, 1
from SYS_ModuleAction A
join SYS_Module M on M.ID = A.ModuleId
  and (A.ID = 'EDBC058A-BDC2-4108-B690-1C2E9E65AD97'
    or M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
  
-- 设置数据权限
insert SYS_RolePerm_Data (RoleId, ModuleId, Mode, Permission)
select @RoleId, M.ID, 0, 1
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
union all
select @RoleId, M.ID, 1, 1
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
union all
select @RoleId, M.ID, 5, 1
from SYS_Module M
where M.Type = 1
and (M.ID in('5C801552-1905-452B-AE7F-E57227BE70B8', '6C0C486F-E039-4C53-9F36-9FE262FB0D3C')
    or M.ModuleGroupId = 'BDF57601-024F-41BC-9EF6-C5F2C334DF79')
GO