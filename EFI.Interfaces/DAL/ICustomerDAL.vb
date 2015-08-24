Namespace DAL.Customers


    Public Interface ICustomerDAL
        Function GetCustomer(CustomerID As Integer) As DTO.Customers.Customer
    End Interface

End Namespace