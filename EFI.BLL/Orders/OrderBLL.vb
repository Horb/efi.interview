Namespace Orders

    Public Class OrderBLL
        Implements IOrderBLL

        Public Sub ApproveOrder(order As DTO.Orders.SalesOrderHeader) Implements IOrderBLL.ApproveOrder
            order.Status = 2
        End Sub

    End Class
End Namespace