Namespace DAL.Customers


    Public Interface ICustomerDAL

        Function SaveAsync(customer As DTO.Customers.Customer) As Task
        Function Exists(customerId As Integer) As Task(Of Boolean)

    End Interface

End Namespace