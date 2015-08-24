Imports EFI.DAL.Customers
Imports EFI.BLL.Customers
Imports EFI.BLL.Orders
Imports EFI.DAL.Orders

Public Class DependencyConfig


    Public Shared Sub ConfigureDependencies()

        DependencyContainer.Default.Bind(Of ICustomerDAL, CustomerDAL)(Function() New CustomerDAL())

        DependencyContainer.Default.Bind(Of IOrderDAL, OrderDAL)(Function() New OrderDAL())
        DependencyContainer.Default.Bind(Of IOrderBLL, OrderBLL)(Function() New OrderBLL(DependencyContainer.Default.Get(Of IOrderDAL),
                                                                                         DependencyContainer.Default.Get(Of ICustomerDAL)))

    End Sub

End Class
