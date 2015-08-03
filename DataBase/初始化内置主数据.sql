DECLARE @MID UNIQUEIDENTIFIER


/*****初始化主数据（收支项目：内置收支项目）*****/
insert MasterData (CategoryId, Name, Alias)
select ID, '抹零', 'CML' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 1 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '预付款', 'YFK' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '折扣', 'Off' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '分期还款', 'Loans' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '分期服务费', 'Service' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'