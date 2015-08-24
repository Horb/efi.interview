<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewOrder.aspx.vb" Inherits="EFI.Interview.ViewOrder" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Order
        <asp:Label ID="lblOrderNo" runat="server" Text="<%#Me.Order.SalesOrderNumber%>"></asp:Label></h1>
    <div class="row">
        <div class="col-md-9">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Order Summary</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="MainContent_txtPurchaseOrder" class="col-sm-2 control-label">PO #</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPurchaseOrder" CssClass="form-control" runat="server" Text="<%#Me.Order.PurchaseOrderNumber%>" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="MainContent_txtOrderId" class="col-sm-2 control-label">Order Id</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtOrderId" CssClass="form-control" runat="server" Text="<%#Me.Order.SalesOrderId%>" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="MainContent_txtOrderDateNew" class="col-sm-2 control-label">Order Date</label>
                                    <div class="col-sm-10">
                                        <input type="datetime" value='<%#Me.Order.OrderDate %>' id="txtOrderDateNew" class="form-control" runat="server" readonly />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="MainContent_txtRevisionNo" class="col-sm-2 control-label">Revision No</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtRevisionNo" ReadOnly="true" CssClass="form-control" runat="server" Text="<%#Me.Order.RevisionNumber %>"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="well" style="text-align: center;">
                <h4>Order Total</h4>
                <h1>
                    <asp:Label CssClass="label label-primary" ID="Label2" runat="server" Text='<%# Me.Order.TotalDue%>'></asp:Label></h1>
                <h4>Tax</h4>
                <h1>
                    <asp:Label CssClass="label label-success" ID="Label4" runat="server" Text='<%#Me.Order.TaxAmt%>'></asp:Label></h1>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <p class="lead">
                Status:
            <asp:Label ID="Label3" runat="server" Text=''></asp:Label>
            </p>

            <h4>Ordered By:
                <asp:Label ID="Label1" runat="server" Text="<%#Me.Order.Customer.FirstName%>"></asp:Label></h4>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Qty</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptItems" runat="server" DataSource="<%#Me.Order.LineItems %>" ItemType="EFI.DTO.Orders.SalesOrderLineItem">
                        <ItemTemplate>
                            <tr>
                                <td>All Items</td>
                                <td><%#Item.OrderQty%></td>
                                <td><%#Item.LineTotal%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
                <tfoot>
                    <tr>
                        <td></td>
                        <td>Total: <%#Me.Order.LineItems.Sum(Function(item) item.OrderQty)%></td>
                        <td>Total: <%#Me.Order.LineItems.Sum(Function(item) item.LineTotal)%></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>

</asp:Content>
