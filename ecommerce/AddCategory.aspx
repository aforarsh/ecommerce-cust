<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ecommerce.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <center>
    <div class="navbar" style="border-width: 3px; border-color: #333333">
        <table align="center" style="width: 386px; height: 410px">
        <tr>
            <td colspan="2" align="center">
                <h2>Add Category</h2><br />
            </td>
        </tr>
        <tr>
            <td>
                <b style="font-size: 21px; font-weight: bold">Category: &nbsp;&nbsp;&nbsp;</b>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="44px" Width="230px" CausesValidation="True" placeholder="Category Name" BorderColor="#333333" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Enter Category Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="Add" Height="44px" Width="80px" Font-Bold="True" Font-Size="Medium" BackColor="Aqua" BorderColor="#333333" BorderWidth="2px" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><br /></td>
        </tr>
        <tr emptydatatext="No Data">
            <td colspan="2" align="center">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#333333" BorderStyle="None" BorderWidth="2px" CssClass="button" DataKeyNames="Category_ID" SortedDescendingHeaderStyle-Wrap="True" EmptyDataText="No Record To Display" Font-Bold="True" PageSize="4" Width="257px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Category">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Text='<%# Eval("Category_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField CausesValidation="False" HeaderText="Operation" ShowDeleteButton="True" ShowEditButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataRowStyle Font-Bold="False" />
                    <HeaderStyle BorderColor="#333333" BorderWidth="3px" Font-Size="Large" />

<SortedDescendingHeaderStyle Wrap="True"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </td>
        </tr>
        </table>
    </div>
    </center>
    <div>

</asp:Content>
