Namespace BLL.Orders

    Public Interface IOrderBLL
        Function GetSalesOrder(SalesOrderNumber As String) As DTO.Orders.SalesOrderHeader
    End Interface

End Namespace