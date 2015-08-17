Namespace DAL.Orders

    Public Interface IOrderDAL 
        Function FindOrderWithOrderNumberAsync(ByVal orderNumber As String) As Task(Of DTO.Orders.SalesOrderHeader)
        Function FindOpenOrdersAsync() As Task(Of IEnumerable(Of DTO.Orders.SalesOrderHeader))
        Function FindAllSpecialOffersAsync() As Task(Of IEnumerable(Of DTO.Orders.SpecialOffer))
    End Interface
End Namespace