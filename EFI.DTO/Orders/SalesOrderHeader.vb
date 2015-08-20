Namespace Orders

    Public Class SalesOrderHeader
        ''' <summary>
        ''' The order Id
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property OrderId As Integer

        Property Revision As Integer
        Property OrderDate As Date
        Property DueDate As Date
        Property ShipDate As Date

        ''' <summary>
        ''' The status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled</remarks>
        Property Status As Integer
        Property Online As Boolean
        Property OrderNumber As String
        Property PurchaseOrder As String
        Property Customer As DTO.Customers.Customer
        Property TotalDue As Decimal
        Property Tax As Decimal
        Property SubTotal As Decimal

        Property CurrencyCode As String

        Property LineItems As IEnumerable(Of SalesOrderLineItem)

        Sub New()
            Me.LineItems = New List(Of SalesOrderLineItem)
        End Sub
    End Class

End Namespace