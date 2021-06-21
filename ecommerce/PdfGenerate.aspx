<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfGenerate.aspx.cs" Inherits="ecommerce.PdfGenerate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 503px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Download Invoice" BackColor="Silver" Font-Bold="True" Font-Size="X-Large" Height="49px" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#CC9900" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" NavigateUrl="~/Default.aspx">Homepage</asp:HyperLink>
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            <table border="1">
                <tr>
                    <td style="text-align: center">
                        <h2 style="text-align: center">Retail Invoice</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        Order No:
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        Order Date:
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="auto-style1">
                                    Buyer Address: <br />
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                   
                                </td>
                                <td>
                                    Seller Address: <br />
                                    ZHR COMPUTER & NETWORK
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1000px">
                            <Columns>
                                <asp:BoundField DataField="paymentid" HeaderText="Payment ID">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <!--asp:BoundField DataField="Product_ID" HeaderText="Product ID">
                                <ItemStyle HorizontalAlign="Center" />
                                </!--asp:BoundField>
                                <asp:BoundField DataField="Product_Name" HeaderText="Product Name">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Product_Qty" HeaderText="Quantity">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="price" HeaderText="Price">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField-->
                                <asp:BoundField DataField="trackingno" HeaderText="Tracking No" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        Grand Total:
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">This is a computer generated invoice.</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
