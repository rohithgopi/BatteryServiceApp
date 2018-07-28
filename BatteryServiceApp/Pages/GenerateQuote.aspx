<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateQuote.aspx.cs" Inherits="BatteryServiceApp.Pages.GenerateQuote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="90%" style="margin-left:auto;margin-right:auto;">
                <tr>
                    <td>
                        <table width="100%" align="center">
                            <tr>
                                <td>
                                    <asp:Image ID="imgExide" ImageUrl="~/Images/Exide.jpg" runat="server" Width="195px" Height="195px" />
                                </td>
                                <td align="Center">
                                    <asp:Label ID="lblCompName" Text="XL BATTERY SERVICE" runat="server" ForeColor="#0033cc" Font-Names="Algerian" Font-Size="25pt" />
                                    <br />
                                    <asp:Label ID="lblAddress" Text="No.405, Dr.Nanjappa Road, Coimbatore – 641 018" runat="server" Font-Bold="true" Font-Size="15pt" />
                                    <br />
                                    <asp:Label ID="lblAddress2" Text="Landline : 0422-2230161, Cell : 94431 64481" runat="server" Font-Bold="true" Font-Size="15pt" />
                                    <br />
                                    <asp:Label ID="lblEmail" Text="E-mail: " runat="server" Font-Bold="true" Font-Size="15pt" />
                                    <asp:HyperLink NavigateUrl="xlbatteryservice@gmail.com" runat="server" Text="xlbatteryservice@gmail.com" Font-Bold="true" Font-Size="15pt" />
                                    <br />
                                    <asp:Label ID="lblGst" Text="GST Number: " runat="server" Font-Bold="true" Font-Size="15pt" /><asp:Label ID="lblGstNo" Text="33ABYPV0558M2ZQ" runat="server" Font-Bold="true" Font-Size="15pt" Font-Underline="true" ForeColor="Blue" />
                                </td>
                                <td align="center">
                                    <asp:Image ID="imgMicro" ImageUrl="~/Images/Microtek.png" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td align="Center">
                                    <asp:Label ID="lblQuotation" Text="" runat="server" Font-Bold="true" Font-Size="25pt" />
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:Label ID="lblDate" Text="Date : " runat="server" Font-Bold="true" Font-Size="12pt" />
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblTo" Text="To :" runat="server" Font-Bold="true" Font-Size="12pt" />
                        </div>
                        <div style="margin-left:30px;">
                            <asp:Label ID="lblToAddress" Text="" runat="server" Font-Bold="true" Font-Size="12pt" />
                            <br />
                            <div>
                                <asp:Label ID="lblThank" Text="Thank you for your inquiry" runat="server" Font-Size="15pt" Font-Italic="true" />
                                <br />
                                <asp:Label ID="lblQuotes" Text="We are pleased to quote you the following:" runat="server" Font-Size="15pt" />
                            </div>
                        </div>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="GrvItem" runat="server" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="No" HeaderText="S.No" ItemStyle-Width="4%"/>
                                <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Width="5%"/>
                                <asp:BoundField DataField="HsnCode" HeaderText="HSN Code"/>
                                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="40%"/>
                                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price"/>
                                <asp:BoundField DataField="Gst" HeaderText="Gst %"/>
                                <asp:BoundField DataField="GstRate" HeaderText="Gst Rate"/>
                                <asp:BoundField DataField="NetPrice" HeaderText="Net Price"/>
                                <asp:BoundField DataField="Warranty" HeaderText="Warranty"/>
                                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price"/>
                            </Columns>
                            <HeaderStyle BackColor="#3399ff" />

                        </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblItemTotal" Text="" runat="server" Font-Bold="true" Font-Size="15pt"/>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlScrapDetails" runat="server">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Label Text="Scrap Buyback Details" runat="server" Font-Size="15pt" Font-Underline="true" />
                                    </td>
                                </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GrvScrap" runat="server" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="No" HeaderText="S.No" ItemStyle-Width="4%"/>
                                <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Width="5%"/>
                                <asp:BoundField DataField="HsnCode" HeaderText="HSN Code"/>
                                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="40%"/>
                                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price"/>
                                <asp:BoundField DataField="Gst" HeaderText="Gst %"/>
                                <asp:BoundField DataField="GstRate" HeaderText="Gst Rate"/>
                                <asp:BoundField DataField="NetPrice" HeaderText="Net Price"/>
                                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price"/>
                            </Columns>
                            <HeaderStyle BackColor="#3399ff" />

                        </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblScrapTotal" Text="" runat="server" Font-Bold="true" Font-Size="15pt" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>

                        <asp:Label ID="lblNetPayable" Text="" runat="server" Font-Bold="true" Font-Size="12pt" />
                        <asp:Label ID="lblNetPayableWords" Text="" runat="server" Font-Size="12pt" />
                        <br />
                        <br />
                        <asp:Label ID="lblConcern" Text="We will be happy to answer all your questions and provide you with any additional information." runat="server" Font-Size="15pt" Font-Bold="true" />
                        <br />
                        <br />
                        <table width="35%" style="font-weight:bold;">
                            <tr>
                                <td>1.</td>
                                <td>GST</td>
                                <td>:</td>
                                <td>As shown above</td>
                            </tr>
                            <tr>
                                <td>2.</td>
                                <td>Delivery</td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblDelivery" Text="" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>3.</td>
                                <td>Validity</td>
                                <td>:</td>
                                <td><asp:Label ID="lblValidity" Text="" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>4.</td>
                                <td>Payment</td>
                                <td>:</td>
                                <td>100% against Delivery</td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label Text="Thanking You" runat="server" Font-Size="13pt"/> 
                        <br />
                        <asp:Label ID="Label1" Text="For XL BATTERY SERVICE" runat="server" ForeColor="#0033cc" Font-Names="Algerian" Font-Size="15pt" />
                        <br />
                        <asp:Button ID="btnPDF" Text="Download PDF" runat="server" OnClick="btnPDF_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
