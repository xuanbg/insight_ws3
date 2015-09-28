IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'OrderStatus') AND OBJECTPROPERTY(id, N'ISVIEW') = 1)
DROP VIEW OrderStatus
GO


/***** ”Õº£∫≤È—Ø∂©µ•◊¥Ã¨*****/

CREATE VIEW OrderStatus
AS

select BO.OID, BO.YunOrderId, BO.XfbOrderId, YO.Orders_DeliveryStatus as DeliveryStatus, YO.Orders_PaymentStatus as PaymentStatus, YO.Orders_Status as OrdersStatus, YO.Orders_RefundStatus
from BIZ_Order BO
join Orders YO on YO.Orders_ID = BO.YunOrderId
where YO.Orders_DeliveryStatus != BO.DeliveryStatus 
  or YO.Orders_PaymentStatus != BO.PaymentStatus
  or YO.Orders_Status != BO.OrdersStatus
  or YO.Orders_RefundStatus != BO.RefundStatus

GO