<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewOrder.aspx.vb" Inherits="EFI.Interview.ViewOrder" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Order
        <asp:Label ID="lblOrderNo" runat="server" Text="<%#Me.Order.OrderNumber%>"></asp:Label></h1>

    <div class="jumbotron">
        <h1>
            <asp:Label ID="Label2" runat="server" Text='<%#String.Format("{0:C}", Me.Order.TotalDue)%>'></asp:Label></h1>

    </div>

    <h2>Order Summary</h2>

    <div class="row">

        <div class="col-md-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="MainContent_txtPurchaseOrder" class="col-sm-2 control-label">PO #</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPurchaseOrder" CssClass="form-control" runat="server" Text="<%#Me.Order.PurchaseOrder%>" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="MainContent_txtOrderId" class="col-sm-2 control-label">Order Id</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtOrderId" CssClass="form-control" runat="server" Text="<%#Me.Order.OrderId%>" ReadOnly="true"></asp:TextBox>
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
                        <asp:TextBox ID="txtRevisionNo" ReadOnly="true" CssClass="form-control" runat="server" Text="<%#Me.Order.Revision%>"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12">
            <p class="lead">
                Status:
            <asp:Label ID="Label3" runat="server" Text='<%# Me.Order.Status%>'></asp:Label>
            </p>

            <h4>Ordered By:
        <asp:Label ID="Label1" runat="server" Text="<%#Me.Order.Customer.Name%>"></asp:Label>
            </h4>

            <p>
                <a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
