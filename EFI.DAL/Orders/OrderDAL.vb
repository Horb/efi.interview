Imports System.Data.SqlClient
Imports System.Text
Imports EFI.DTO.Orders
Imports System.Threading

Namespace Orders

    Public Class OrderDAL

        Implements IOrderDAL

        Public Function GetSalesOrderSQL() As String
            Dim sb As New StringBuilder
            sb.AppendLine("SELECT [SalesOrderID]")
            sb.AppendLine("      ,[RevisionNumber]")
            sb.AppendLine("      ,[OrderDate]")
            sb.AppendLine("      ,[DueDate]")
            sb.AppendLine("      ,[ShipDate]")
            sb.AppendLine("      ,[Status]")
            sb.AppendLine("      ,[OnlineOrderFlag]")
            sb.AppendLine("      ,[SalesOrderNumber]")
            sb.AppendLine("      ,[PurchaseOrderNumber]")
            sb.AppendLine("      ,[AccountNumber]")
            sb.AppendLine("      ,[CustomerID]")
            sb.AppendLine("      ,[SalesPersonID]")
            sb.AppendLine("      ,[TerritoryID]")
            sb.AppendLine("      ,[BillToAddressID]")
            sb.AppendLine("      ,[ShipToAddressID]")
            sb.AppendLine("      ,[ShipMethodID]")
            sb.AppendLine("      ,[CreditCardID]")
            sb.AppendLine("      ,[CreditCardApprovalCode]")
            sb.AppendLine("      ,[CurrencyRateID]")
            sb.AppendLine("      ,[SubTotal]")
            sb.AppendLine("      ,[TaxAmt]")
            sb.AppendLine("      ,[Freight]")
            sb.AppendLine("      ,[TotalDue]")
            sb.AppendLine("      ,[Comment]")
            sb.AppendLine("      ,[rowguid]")
            sb.AppendLine("      ,[ModifiedDate]")
            sb.AppendLine("FROM [Sales].[SalesOrderHeader]")
            sb.AppendLine("WHERE [SalesOrderNumber] = @SalesOrderNumber")
            Return sb.ToString
        End Function

        Public Function GetSalesOrder(SalesOrderNumber As String) As SalesOrderHeader Implements IOrderDAL.GetSalesOrder
            Using cn As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("AdventureWorks").ConnectionString)
                cn.Open()
                Using cmd As New SqlCommand(GetSalesOrderSQL, cn)
                    cmd.Parameters.Add(New SqlParameter("@SalesOrderNumber", SalesOrderNumber))
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim so As New SalesOrderHeader
                            With so
                                .SalesOrderId = reader("SalesOrderID")
                                .RevisionNumber = reader("RevisionNumber")
                                .SalesOrderNumber = reader("SalesOrderNumber")
                                .PurchaseOrderNumber = reader("PurchaseOrderNumber")
                                .OrderDate = reader("OrderDate")
                                .SubTotal = reader("SubTotal")
                                .TaxAmt = reader("TaxAmt")
                                .TotalDue = reader("TotalDue")
                                .CustomerID = reader("CustomerID")
                                .CurrencyRateID = reader("CurrencyRateID")
                            End With
                            Return so
                        Else
                            Throw New Exception(String.Format("SalesOrderHeader not found for SalesOrderNumber={0}", SalesOrderNumber))
                        End If
                    End Using
                End Using
            End Using
        End Function

        Public Function GetSalesOrderDetails(SalesOrderID As String) As IEnumerable(Of SalesOrderDetail) Implements IOrderDAL.GetSalesOrderDetails
            ' TODO: Return a list of SalesOrderDetail records for the given SalesOrderID
            Return New List(Of SalesOrderDetail)
        End Function

    End Class

End Namespace