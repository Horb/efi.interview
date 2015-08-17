Namespace Customers

    Public Class CustomerDAL
        Implements ICustomerDAL

        Public Function Exists(customerId As Integer) As Task(Of Boolean) Implements ICustomerDAL.Exists
            Throw New NotImplementedException
        End Function

        Public Function SaveAsync(customer As DTO.Customers.Customer) As Task Implements ICustomerDAL.SaveAsync
            Throw New NotImplementedException
        End Function
    End Class

End Namespace