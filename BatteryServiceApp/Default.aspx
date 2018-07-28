<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BatteryServiceApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Generate Quote</h1>
        <p class="lead">Generare Quote for new customers here</p>
        <p><a href="Pages/Quote.aspx" 6class="btn btn-primary btn-lg">New Quote &raquo;</a></p>
    </div>

    <div class="jumbotron">
        <h1>Invoice</h1>
        <p class="lead">Check Invoice Details</p>
        <p><a href="Pages/ServiceHome.aspx" 6class="btn btn-primary btn-lg">Invoice Section &raquo;</a></p>
    </div>

</asp:Content>
