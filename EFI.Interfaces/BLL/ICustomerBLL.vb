Namespace BLL.Customers

    Public Interface ICustomerBLL
        Function GetCustomer(CustomerID As Integer) As DTO.Customers.Customer
    End Interface

End Namespace