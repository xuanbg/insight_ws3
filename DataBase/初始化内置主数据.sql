DECLARE @MID UNIQUEIDENTIFIER


/*****��ʼ�������ݣ���֧��Ŀ��������֧��Ŀ��*****/
insert MasterData (CategoryId, Name, Alias)
select ID, 'Ĩ��', 'CML' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 1 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, 'Ԥ����', 'YFK' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '�ۿ�', 'Off' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '���ڻ���', 'Loans' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'

insert MasterData (CategoryId, Name, Alias)
select ID, '���ڷ����', 'Service' from BASE_Category where Alias = 'BuiltIn'
select @MID = ID from MasterData where SN = scope_identity()
insert MDG_Expense (MID, Unit, BuiltIn)
select @MID, ID, 0 from MasterData where Alias = 'RMBY'