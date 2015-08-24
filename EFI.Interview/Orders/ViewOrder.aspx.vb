Imports EFI.BLL.Orders
Imports System.Threading.Tasks

Public Class ViewOrder
    Inherits System.Web.UI.Page

    Dim bll As IOrderBLL

    Protected Sub New()
        Me.bll = DependencyContainer.Default.Get(Of IOrderBLL)()
    End Sub

    Public Property Order As DTO.Orders.SalesOrderHeader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            LoadOrder()

        End If
    End Sub

    Private Sub LoadOrder()
        Dim orderNumber As String

        orderNumber = Request("orderNumber")

        If String.IsNullOrEmpty(orderNumber) Then
            Throw New ArgumentNullException("orderNumber")
        End If

        Me.Order = bll.GetSalesOrder(orderNumber)

        If Not Order Is Nothing Then
            Me.DataBind()
        Else
            Response.StatusCode = Net.HttpStatusCode.NotFound
        End If

    End Sub

End Class