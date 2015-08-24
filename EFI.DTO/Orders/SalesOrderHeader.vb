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

        Property CustomerID As Integer
        Property Customer As DTO.Customers.Customer
        Property LineItems As IEnumerable(Of SalesOrderLineItem)

        Sub New()
            Me.LineItems = New List(Of SalesOrderLineItem)
        End Sub

    End Class

End Namespace