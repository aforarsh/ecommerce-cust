@@ -5,31 +5,45 @@
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ZHR COMPUTER & NETWORK</title>
    <style type="text/css">
        .auto-style1 {
            width: 538px;
            height: 208px;
        }
        .auto-style2 {
            height: 242px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br><br><br><br><br><br><br>
<body style="background-image: url('https://wallpaperaccess.com/full/2483946.jpg');">
    <form id="form2" runat="server" class="auto-style2">
        <div>
            <table>
        </div>
            <table align="center" class="auto-style1" style="background-color: #C0C0C0">
                <tr>
                    <td colspan="2" align="center">
                        <h2>Login</h2>
                    </td>
                </tr>
                <tr>
                    <td><b>Email ID: </b></td>
                    <td align="center" width="50%">
                        <b>Email ID: </b>

                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="302px"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" runat="server" Height="24px" Width="372px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Password: </b></td>
                    <td align="center" width="50%"><b>Password: </b></td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Height="24px" Width="302px"></asp:TextBox>
                        <asp:TextBox ID="TextBox4" runat="server" Height="24px" Width="174px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                        <asp:Button ID="Button2" runat="server" Text="Login" BackColor="Silver" Font-Bold="True" Font-Size="Medium" Width="88px" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
@ -38,7 +52,6 @@
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>