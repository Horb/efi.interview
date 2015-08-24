<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="EFI.Interview._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>EFI.Interview</h1>
        <p class="lead">Welcome to your EFI Technical Assessment. Click the button below to begin.</p>
        <p><a href="/Orders/ViewOrder.aspx?orderNumber=SO43665" class="btn btn-primary btn-lg">Get Started &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Overview</h2>
            <p>The Tasks will help you show a firm grounding in Visual Basic .Net, ASP.Net and SQL. You are free to use SQL Server Management Studio to browse the AdventureWorks database that powers this application.</p>
            <p>There are no trick questions and if you're stuck then please ask for a point in the right direction.</p>
            <p>Task 7 is open ended and you are not expected to complete it.</p>
        </div>
        <div class="col-md-8">
            <h2>Tasks</h2>
            <ol>
                <li>Run the project and navigate to the following url <code>/Orders/ViewOrder.aspx?orderNumber=SO43665</code> by clicking 'Get Started'.</li>
                <li>Why does the page load fail? Fix or otherwise handle the Exception that is causing the page load to fail.</li>
                <li>The Order Total and Tax prices are currently shown to 4 decimal places without thousand separators. Make alterations such that the prices appear to 2 decimal places and have commas as thousand separators.</li>
                <li>The Status currently displays an Integer value. Make alterations such that a description of the status appears instead of the Integer value.</li>
                <li><code>EFI.DAL.OrdersDAL.GetSalesOrderDetails</code> hasn't been implemented properly.
                    <ul>
                        <li>Implement <code>GetSalesOrderDetails</code> such that it returns the SalesOrderDetail records for a SalesOrderID.</li>
                        <li><code>ViewOrder.aspx</code> should output the SalesOrderDetail records for the Order in a table.</li>
                    </ul>
                <li>The Ordered By field currently only displays the First Name. Make alterations such that the Ordered By field displays the First and Last name of the Person.</li>
                <li><strong>Optional</strong>: Alter or suggest an approach to altering the application such that the SalesOrderDetail records can be changed and these changes be persisted to the database.</li>
            </ol>
        </div>
    </div>

</asp:Content>
