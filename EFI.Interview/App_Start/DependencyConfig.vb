Imports EFI.DAL.Customers
Imports EFI.BLL.Customers
Imports EFI.BLL.Orders
Imports EFI.DAL.Orders

Public Class DependencyConfig


    Public Shared Sub ConfigureDependencies()
        'Binds components to interfaces...

        DependencyContainer.Default.Bind(Of ICustomerDAL, CustomerDAL)(Function() New CustomerDAL())
        DependencyContainer.Default.Bind(Of ICustomerBLL, CustomerBLL)(Function() New CustomerBLL(DependencyContainer.Default.Get(Of ICustomerDAL)))
        DependencyContainer.Default.Bind(Of IOrderBLL, OrderBLL)(Function() New OrderBLL())
        DependencyContainer.Default.Bind(Of IOrderDAL, OrderDAL)(Function() New OrderDAL())

    End Sub

End Class
