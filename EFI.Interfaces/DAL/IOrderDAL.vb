Namespace DAL.Orders

    Public Interface IOrderDAL 
        Function GetSalesOrder(SalesOrderNumber As String) As DTO.Orders.SalesOrderHeader
        Function GetSalesOrderDetails(SalesOrderID As String) As IEnumerable(Of DTO.Orders.SalesOrderDetail)
    End Interface
End Namespace