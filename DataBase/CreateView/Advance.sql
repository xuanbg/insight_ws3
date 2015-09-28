IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'Advance') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW Advance
GO


/*****视图：查询可用预付款*****/

CREATE VIEW Advance
AS

with List as(
select d.ID, A.OwnerId, A.AccountNo, A.CardType, 
case when datediff(day, getdate(), isnull(D.ValidDate, '2999-12-31')) > 60 then 60 else datediff(day, getdate(), isnull(D.ValidDate, '2999-12-31')) end + case when D.ObjectId is null then 2 else 0 end + case D.Type when 1 then 1 else 0 end as Pri,
D.ObjectId, D.Type, D.ValidDate, D.Amount + isnull(R.Amount, 0) as Amount
from ABS_Advance A
join ABS_Advance_Detail D on D.AccountId = A.ID
left join (
  select DetailId, sum(Amount) as Amount from ABS_Advance_Record
  group by DetailId) R on r.DetailId = D.ID)

select top 1000 * from List order by Pri, ValidDate

GO