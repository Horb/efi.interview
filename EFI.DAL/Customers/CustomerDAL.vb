Imports System.Data.SqlClient
Imports System.Text

Namespace Customers

    Public Class CustomerDAL
        Implements ICustomerDAL

        Protected Function GetCustomerSQL() As Object
            Dim sb As New StringBuilder
            sb.AppendLine("SELECT c.[CustomerID], p.[FirstName] ")
            sb.AppendLine("FROM [Sales].[Customer] c ")
            sb.AppendLine("INNER JOIN [Person].[Person] p")
            sb.AppendLine("    ON c.PersonID = p.BusinessEntityID")
            sb.AppendLine("WHERE c.[CustomerID] = @CustomerID")
            Return sb.ToString
        End Function

        Public Function GetCustomer(CustomerID As Integer) As DTO.Customers.Customer Implements ICustomerDAL.GetCustomer
            Using cn As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("AdventureWorks").ConnectionString)
                cn.Open()
                Using cmd As New SqlCommand(GetCustomerSQL, cn)
                    cmd.Parameters.Add(New SqlParameter("@CustomerID", CustomerID))
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New DTO.Customers.Customer With {
                                .Id = reader("CustomerID"),
                                .FirstName = reader("FirstName")
                            }
                        Else
                            Throw New Exception(String.Format("Customer not found for CustomerID={0}", CustomerID))
                        End If
                    End Using
                End Using
            End Using
        End Function

    End Class

End Namespace