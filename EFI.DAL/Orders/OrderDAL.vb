Imports System.Data.SqlClient
Imports System.Text
Imports EFI.DTO.Orders
Imports System.Threading

Namespace Orders

    Public Class OrderDAL
        Implements IOrderDAL


        Public Function FindOpenOrdersAsync() As Task(Of IEnumerable(Of DTO.Orders.SalesOrderHeader)) Implements IOrderDAL.FindOpenOrdersAsync
            Throw New NotImplementedException
        End Function

        Public Async Function FindOrderWithOrderNumberAsync(orderNumber As String) As Task(Of DTO.Orders.SalesOrderHeader) Implements IOrderDAL.FindOrderWithOrderNumberAsync
            Dim sql As StringBuilder
            Dim result As SalesOrderHeader


            sql = New StringBuilder("SELECT soh.SalesOrderID, soh.RevisionNumber, soh.OrderDate, soh.DueDate, soh.ShipDate, soh.Status, soh.OnlineOrderFlag, soh.SalesOrderNumber, soh.PurchaseOrderNumber, soh.TotalDue, soh.Freight, ")

            sql.
                AppendLine(" soh.TaxAmt, soh.SubTotal, p.PersonType, p.NameStyle, p.Title, p.FirstName, p.MiddleName, p.Suffix, p.LastName, p.BusinessEntityID ").
                AppendLine("FROM Sales.SalesOrderHeader AS soh INNER JOIN ").
                AppendLine(" Sales.Customer AS c ON c.CustomerID = soh.CustomerID INNER JOIN ").
                AppendLine(" Person.Person AS p ON p.BusinessEntityID = c.PersonID ").
                AppendLine("WHERE        (soh.SalesOrderNumber = @orderno) ")
             
            Using cn = New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("AdventureWorks").ConnectionString)
                
                Await cn.OpenAsync()

                Using sqc = New SqlCommand(sql.ToString(), cn)
                    sqc.Parameters.AddWithValue("@orderNo", orderNumber)

                    Using reader = Await sqc.ExecuteReaderAsync

                        If Await reader.ReadAsync() Then
                            result = New SalesOrderHeader()

                            With result
                                .Customer = New DTO.Customers.Customer() With {.Id = reader("BusinessEntityID"), .Name = reader("FirstName")} 'TODO: Add Fully formatted name to the customer

                                .OrderNumber = orderNumber
                                .DueDate = reader("DueDate")
                                .Online = reader("OnlineOrderFlag")
                                .OrderDate = reader("OrderDate")
                                .OrderId = reader("SalesOrderID")
                                .Revision = reader("RevisionNumber")
                                .ShipDate = reader("ShipDate")
                                .Status = reader("Status")
                                .SubTotal = reader("SubTotal")
                                .Tax = reader("TaxAmt")
                                .TotalDue = reader("TotalDue")

                            End With

                        End If


                    End Using
                End Using
            End Using

            Return result

        End Function

        Public Async Function FindAllSpecialOffersAsync() As Task(Of IEnumerable(Of DTO.Orders.SpecialOffer)) Implements IOrderDAL.FindAllSpecialOffersAsync
            Dim items As IList(Of DTO.Orders.SpecialOffer) = Nothing

            Using cn = New SqlConnection()
                Await cn.OpenAsync()

                Using sqc = New SqlCommand(My.Settings.SQL_SpecialOffers, cn)
                    Using reader = Await sqc.ExecuteReaderAsync
                        items = New List(Of DTO.Orders.SpecialOffer)
                        While Await reader.ReadAsync()
                            Dim item = New DTO.Orders.SpecialOffer


                            item.Category = reader("Category")
                            item.Description = reader("Description")
                            item.Discount = reader("DiscountPct") * 100
                            item.End = reader("EndDate")
                            item.Id = reader("SpecialOfferID")
                            item.MaxQty = reader("MaxQty") 'TODO: Fix nullable types
                            item.MinQty = reader("MinQty")
                            item.Start = reader("Start")
                            item.Type = reader("Type")

                            items.Add(item)
                        End While
                    End Using
                End Using
            End Using

            Return items
        End Function
    End Class

End Namespace