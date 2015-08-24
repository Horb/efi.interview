Imports EFI.DAL.Orders
Imports EFI.DTO.Orders
Imports EFI.DAL.Customers

Namespace Orders

    Public Class OrderBLL
        Implements IOrderBLL

        Protected OrderDAL As IOrderDAL
        Protected CustomerDAL As ICustomerDAL

        Public Sub New(OrderDAL As IOrderDAL, CustomerDAL As ICustomerDAL)
            Me.OrderDAL = OrderDAL
            Me.CustomerDAL = CustomerDAL
        End Sub

        Public Function GetOrder(SalesOrderNumber As String) As SalesOrderHeader Implements IOrderBLL.GetSalesOrder
            Dim so As SalesOrderHeader
            so = OrderDAL.GetSalesOrder(SalesOrderNumber)
            so.LineItems = OrderDAL.GetSalesOrderItems(so.SalesOrderId)
            so.Customer = CustomerDAL.GetCustomer(so.CustomerID)
            Return so
        End Function

    End Class
End Namespace