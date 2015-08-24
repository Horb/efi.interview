Namespace DAL.Orders

    Public Interface IOrderDAL 
        Function GetSalesOrder(SalesOrderNumber As String) As DTO.Orders.SalesOrderHeader
        Function GetSalesOrderItems(SalesOrderID As String) As IEnumerable(Of DTO.Orders.SalesOrderLineItem)
    End Interface
End Namespace