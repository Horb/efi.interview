Namespace Orders

    Public Class SalesOrderHeader
        Property SalesOrderId As Integer
        Property RevisionNumber As Integer
        Property OrderDate As Date
        Property SalesOrderNumber As String
        Property PurchaseOrderNumber As String
        Property TotalDue As Decimal
        Property TaxAmt As Decimal
        Property SubTotal As Decimal
        Property CurrencyRateID As Integer

        ''' <summary>
        ''' Order current status. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled</remarks>
        Property Status As Integer

        Property CustomerID As Integer
        Property Customer As DTO.Customers.Customer
        Property LineItems As IEnumerable(Of SalesOrderDetail)

        Sub New()
            Me.LineItems = New List(Of SalesOrderDetail)
        End Sub

    End Class

End Namespace