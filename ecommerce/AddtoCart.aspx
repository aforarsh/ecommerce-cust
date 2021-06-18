<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddtoCart.aspx.cs" Inherits="ecommerce.AddtoCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ZHR COMPUTER & SERVICES</title>
    <style type="text/css">
        .auto-style1 {
            height: 1784px;
        }
    </style>
</head>
<body style="background-image: url('https://wallpaperaccess.com/full/2483946.jpg')";>
    <form id="form1" runat="server">
        <div align="center" style="margin:0 auto" class="auto-style1">
            <h2 style="text-decoration: underline overline blink; color: #5f98f3">You have the following products in your cart</h2>
            <br/><br/>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Colonna MT" Font-Size="Large" NavigateUrl="Default.aspx">Continue Shopping</asp:HyperLink><br/>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Clear Cart</asp:LinkButton>
            <br/><br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#333333" BorderWidth="5px" EmptyDataText="No products available" Font-Bold="True" Height="257px" ShowFooter="True" Width="1100px" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="Sr No">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pid" HeaderText="Product ID">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="pimage" HeaderText="Product Image">
                        <ItemStyle Height="300px" HorizontalAlign="Center" Width="340px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="pname" HeaderText="Product Name">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pdesc" HeaderText="Product Description">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pqty" HeaderText="Qty">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pprice" HeaderText="Price">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ptprice" HeaderText="Total Price">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="True"  />
                </Columns>
                <FooterStyle BackColor="#6666FF" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="DarkOrchid" ForeColor="White" />
            </asp:GridView>

            <br/>

            <asp:Button ID="Button1" runat="server" Text="Checkout" BackColor="Blue" BorderColor="#066666" BorderStyle="Ridge" Font-Bold="True" Font-Size="Large" Height="46px" Width="135px" OnClick="Button1_Click"/>

        </div>
    </form>
</body>
</html>
