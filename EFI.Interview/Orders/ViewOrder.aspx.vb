Imports EFI.DAL.Orders
Imports System.Threading.Tasks

Public Class ViewOrder
    Inherits System.Web.UI.Page

    Private ReadOnly dal As IOrderDAL

    Protected Sub New()
        Me.dal = DependencyContainer.Default.Get(Of IOrderDAL)()
    End Sub

    Public Property Order As DTO.Orders.SalesOrderHeader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            RegisterAsyncTask(New PageAsyncTask(AddressOf LoadOrder))

        End If
    End Sub

    Private Async Function LoadOrder() As Task
        Dim orderNumber As String


        orderNumber = Request("orderNumber")

        If String.IsNullOrEmpty(orderNumber) Then
            Throw New ArgumentNullException("orderNumber")
        End If

        Me.Order = Await dal.FindOrderWithOrderNumberAsync(orderNumber)

        If Not Order Is Nothing Then

            Me.DataBind()
        Else
            Response.StatusCode = Net.HttpStatusCode.NotFound
        End If

    End Function

End Class