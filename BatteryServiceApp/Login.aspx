<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BatteryServiceApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Scripts/MUI/material.min.css" rel="stylesheet" />
    <script src="Scripts/MUI/material.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/Login.js"></script>
    
</head>
<body class="bodyNoPadding">
    <form id="form1" runat="server">
        <div class="divCenter" style="width:400px;height:500px;">
        
        <table>
            <tr>
                <td>
                    <table>
            <tr>
                <td align="center">
                    <asp:Image ImageUrl="~/Images/images.png" runat="server" ID="imgLogin" Width="80%" />
                </td>
            </tr>
        </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="mdl-typography--headline mdl-color-text--indigo-A700">
                        Welcome to Exide CRM App
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="mdl-typography--headline-color-contrast ">Please Login</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="align-items:center;margin-left:40px;">
                        <i class="material-icons md-48">person</i>
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="mdl-textfield__input" />
                        <label class="mdl-textfield__label" for="sample3">Username</label>
                        <span class="mdl-textfield__error" id="usernameError">Please Enter Username!</span>
                    </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="align-items:center;margin-left:40px;">
                    <i class="material-icons md-48">vpn_key</i>
                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="mdl-textfield__input" />
                        <label class="mdl-textfield__label" for="sample3">Password</label>
                        <span class="mdl-textfield__error" id="passwordError">Please Enter Password!</span>
                    </div></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInvalidLogin" Text="Invalid Username or Password" runat="server" Visible="false" ForeColor="Red" style="margin-left:100px;" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnReset" Text="Reset" runat="server" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--colored"/>
                    <asp:Button ID="btnLogin" Text="Login" runat="server" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" OnClientClick="validateLogin()" OnClick="btnLogin_Click"/>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
