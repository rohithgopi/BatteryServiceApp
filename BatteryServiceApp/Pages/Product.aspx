<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="BatteryServiceApp.Pages.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Scripts/MUI/material.css" rel="stylesheet" />
    <div class="jumbotron">
        <h2>New Product</h2>
        <p class="lead">Add New Products Here</p>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblProductName" Text="Product Name" runat="server" /></td>
                <td><asp:TextBox ID="txtProducts" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblProductType" Text="Product Type" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlProductType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnAddProduct" Text="Add Product" runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--colored" OnClick="BtnAddProduct_Click"  />
                </td>
            </tr>
        </table>
        

    </div>
</asp:Content>
