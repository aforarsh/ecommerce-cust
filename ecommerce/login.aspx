<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ecommerce.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ZHR COMPUTER & SERVICES</title>
    <style type="text/css">
        .auto-style1 {
            width: 650px;
            height: 283px;
            margin-bottom: 0px;
        }
        .auto-style2 {
            height: 44px;
        }
        .auto-style3 {
            width: 50%;
            height: 60px;
        }
        .auto-style4 {
            height: 60px;
        }
        .auto-style5 {
            width: 50%;
            height: 63px;
        }
        .auto-style6 {
            height: 63px;
        }
        .auto-style7 {
            height: 66px;
        }
    </style>
</head>
<body style="background-image: url('https://wallpaperaccess.com/full/2483946.jpg');">
    <form id="form1" runat="server">
        <br><br><br><br><br>
        <div>
            <table align="center" class="auto-style1" style="background-color: #CCCCCC">
                <tr>
                    <td colspan="2" align="center" class="auto-style2">
                        <h2>Login</h2>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style3"><b>Email :</b></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="269px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style5"><b>Password :</b></td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style7">
                        <asp:Button ID="Button1" runat="server" Height="50px" Text="Login" Width="128px" Font-Bold="True" Font-Size="Medium" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
