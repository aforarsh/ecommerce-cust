<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="ecommerce.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('https://wallpaperaccess.com/full/2483946.jpg');>
    <form id="form1" runat="server">
        <br><br><br><br><br>
        <div style="height:510px">
            <table style="width:700px; height:390px; background-color:#0094ff;" align="center">
                <tr>
                    <td colspan="2" width="50%" align="center">
                        <h1>Payment</h1><hr/>
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%">
                        <h3>Upload Receipt</h3>
                    </td>
                    <td align="center" width="50%">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" Font-Size="Medium" Height="36px" OnClick="Button1_Click" Width="88px" />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%" colspan="2">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
