<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewInvoice.aspx.cs" Inherits="BatteryServiceApp.Pages.NewInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Invoice Here
    </h2>
    <table width="90%">
        <tr>
            <td align="right">
                <asp:Label ID="lblMobileNumber" Text="Mobile Number : " runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="Number" CssClass="form-control" Width="50%"></asp:TextBox>
                <div class="invalid-feedback">
                    Please enter mobile number!.
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="margin-top: 20px; width: 100%">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblName" Text="Name : " runat="server" CssClass="form-control-Label" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblAddress" Text="Address : " runat="server" CssClass="form-control-Label" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblPinCode" Text="Pin Code : " runat="server" CssClass="form-control-Label" />
                        </td>
                        <td width="10%">
                            <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" TextMode="Number" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblState" Text="State : " runat="server" CssClass="form-control-Label" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server" DataTextField="Value" DataValueField="Text" CssClass="form-control">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnAddInvoice" Text="Add Invoice" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnAddInvoice_Click" />
</asp:Content>
