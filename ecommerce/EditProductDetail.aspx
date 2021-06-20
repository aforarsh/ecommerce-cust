<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditProductDetail.aspx.cs" Inherits="ecommerce.EditProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar" style="border-width: 3px; border-color: #333333; height:auto">
        <br />
        <table style="width: 700px; height:390px; background-color: #5f98f3;" align="center">
            <tr>
                <td align="center" width="50%" colspan="2" class="auto-style1">
                    <h1>Edit Product Detail</h1><hr />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <h3>Product ID:</h3>
                </td>
                <td width="50%">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#FF66FF" BorderColor="#FF66FF" Font-Bold="True" Font-Size="Medium" OnClick="Button3_Click" Text="GET" />
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <h3>Product Name:</h3>
                </td>
                <td width="50%">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <h3>Product Description:</h3>
                </td>
                <td width="50%">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <h3>Product Price(RM):</h3>
                </td>
                <td width="50%">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Price is Invalid" ForeColor="Red" ValidationExpression="[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" width="50%">
                    <h3>Product Quantity:</h3>
                </td>
                <td width="50%">
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Quantity is Invalid" ForeColor="Red" ValidationExpression="[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" width="50%" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Update" Font-Bold="True" ForeColor="Black" Height="36px" Width="88px" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit0" runat="server" Text="Delete" Font-Bold="True" ForeColor="Black" Height="36px" Width="88px" OnClick="btnDelete_Click" />
                </td>
            </tr>
        </table><br />
    </div>
</asp:Content>
