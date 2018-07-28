<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quote.aspx.cs" Inherits="BatteryServiceApp.Pages.Quote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <br />
    <br />
    <table>
        <tr>
            <td width="150px">
                <asp:Label ID="lblQuoteId" Text="Quotation Number : " runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtQuoteNumber" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblQuoteAddress" Text="Quote To :" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtQuoteAddress" runat="server" TextMode="MultiLine" Width="400px" Height="75px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="udpQuoteLayout" runat="server">
        <ContentTemplate>   
            <asp:Panel id="pnlQuotePanel" runat="server"></asp:Panel>
            <asp:Button id="BtnAddItem" Text="Add Item" runat="server" OnClick="BtnAddItem_Click" class="btn btn-default" BackColor="#ff9933" />
            <br />
            <asp:CheckBox id="chkScrap" Text="Scrap Buy Back" runat="server" OnCheckedChanged="chkScrap_CheckedChanged" AutoPostBack="true" EnableViewState="true" />
            <asp:Panel ID="pnlScrapPanel" runat="server"></asp:Panel>
            <asp:Button id="BtnAddScrap" Text="Add Scrap" runat="server" OnClick="BtnAddScrap_Click" class="btn btn-default" BackColor="#ff9933" />
            <table width="40%">
                <tr>
                    <td width="20%">
                        <asp:Label ID="lblDelivery" Text="Delivery : " runat="server" /></td>
                    <td width="30%">
                        <asp:DropDownList ID="ddlDelivery" runat="server">
                            <asp:ListItem Text="Immediate" Value="Immediate" />
                            <asp:ListItem Text="1-15 Days" Value="1-15 Days" />
                            <asp:ListItem Text="15-30 Days" Value="15-30 Days"/>
                            <asp:ListItem Text="30-45 Days" Value="30-45 Days"/>
                        </asp:DropDownList>
                    </td>
                    <td width="20%" align="Center">
                        <asp:Label ID="lblValidity" Text="Vaidity : " runat="server" />
                    </td>
                    <td width="30%">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Text="January" Value="January" />
                            <asp:ListItem Text="February" Value="February" />
                            <asp:ListItem Text="March" Value="March" />
                            <asp:ListItem Text="April" Value="April" />
                            <asp:ListItem Text="May" Value="May" />
                            <asp:ListItem Text="June" Value="June" />
                            <asp:ListItem Text="July" Value="July" />
                            <asp:ListItem Text="August" Value="August" />
                            <asp:ListItem Text="September" Value="September" />
                            <asp:ListItem Text="October" Value="October" />
                            <asp:ListItem Text="November" Value="November" />
                            <asp:ListItem Text="December" Value="December" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="right">
                        <asp:Button id="BtnGenerate" Text="Preview" runat="server" class="btn btn-default" BackColor="#2087ee" OnClick="Unnamed_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
</asp:Content>
