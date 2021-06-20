<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ecommerce.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ZHR COMPUTER & SERVICES</title>
</head>
<body  style="background-image: url('https://wallpaperaccess.com/full/2483946.jpg');>
    <form id="form1" runat="server">
        <div style="height:510px">
            <table style="width:700px; height:390px; background-color:#0094ff;" align="center">
                <tr>
                    <td colspan="2" width="50%" align="center">
                        <h1>Payment</h1>
                    </td>
                </tr>
                <tr>
                    <td width="50%" align="center">
                        <h3>Receipt</h3>
                    </td>
                    <td width="50%" align="center">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="50%" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" Font-Size="Medium" Height="36px" OnClick="Button1_Click" Width="88px" UseSubmitBehaviour="false" data-dismiss="modal"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="50%" align="center">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
