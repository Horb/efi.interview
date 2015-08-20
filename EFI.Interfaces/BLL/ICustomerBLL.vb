Namespace BLL.Customers

    Public Interface ICustomerBLL

        Function ValidateAsync(customer As DTO.Customers.Customer) As Task

    End Interface

End Namespace