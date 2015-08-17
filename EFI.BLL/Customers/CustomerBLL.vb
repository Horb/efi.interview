Imports EFI.DAL.Customers

Namespace Customers

    Public Class CustomerBLL
        Implements ICustomerBLL

        Private dal As ICustomerDAL

        Sub New(dal As ICustomerDAL)
            Me.dal = dal
        End Sub

        Public Async Function SaveAsync(customer As DTO.Customers.Customer) As Task Implements ICustomerBLL.SaveAsync
            Await Me.dal.SaveAsync(customer)
        End Function

        Public Async Function ValidateAsync(customer As DTO.Customers.Customer) As Task Implements ICustomerBLL.ValidateAsync
            If customer.Id.HasValue = False Then
                If String.IsNullOrEmpty(customer.Name) Then
                    Throw New ArgumentNullException("customer.Name", "The customer name attribute is a required field.")
                End If
            Else
                If Await Me.dal.Exists(customer.Id.Value) = False Then
                    Throw New InvalidOperationException("You have specified an id that does not exist. A customer Id is auto allocated and cannot be preset when saving")
                End If
            End If
        End Function
    End Class

End Namespace