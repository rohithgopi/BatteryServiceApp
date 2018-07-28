<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceHome.aspx.cs" Inherits="BatteryServiceApp.Pages.ServiceHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-5">
            <h1>New Invoice</h1>
            <p class="lead">Generate Invoice for existing and new customer.</p>
            <p><a href="NewInvoice.aspx" class="btn btn-primary btn-lg">New invoice &raquo;</a></p>
        </div>

        <div class="col-lg-5">
            <h1>Products</h1>
            <p class="lead">Add new batteries, solar cells & inverters.</p>
            <p>
                <a href="Product.aspx" class="btn btn-primary btn-lg">New Products &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
