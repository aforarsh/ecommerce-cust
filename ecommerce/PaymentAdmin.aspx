<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PaymentAdmin.aspx.cs" Inherits="ecommerce.PaymentAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 183px;
        }
        .auto-style3 {
            width: 276px;
        }
        .auto-style4 {
            width: 183px;
            height: 23px;
        }
        .auto-style5 {
            width: 276px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style9 {
            margin-left: 0px;
        }
        .auto-style10 {
            width: 204px;
        }
        .auto-style11 {
            width: 204px;
            height: 23px;
        }
        .auto-style12 {
            width: 183px;
            height: 26px;
        }
        .auto-style13 {
            width: 276px;
            height: 26px;
        }
        .auto-style14 {
            width: 204px;
            height: 26px;
        }
        .auto-style15 {
            height: 26px;
        }
        .auto-style16 {
            width: 145px;
        }
        .auto-style17 {
            width: 145px;
            height: 23px;
        }
        .auto-style18 {
            width: 145px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="navbar" style="height: auto">
        <div align="right">
            <asp:LinkButton ID="AllOrder" runat="server" OnClick="AllPayment_Click"> Show All Payment List</asp:LinkButton>
            &nbsp;
        </div>
        <b>Select Date:</b>
        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Width="122px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/calendar-icon.png" OnClick="ImageButton1_Click" />
        <br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Click" CssClass="button" Font-Bold="True" Height="39px" Width="72px" OnClick="Button1_Click" />
        <br />
        <br />
        
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style15">Add Tracking No</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">Order ID:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style9" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style17">&nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#FF66FF" BorderColor="#FF66FF" Font-Bold="True" Font-Size="Medium" OnClick="Button3_Click" Text="GET" />
&nbsp;
                    <asp:Button ID="Button4" runat="server" BackColor="#FF66FF" BorderColor="#FF66FF" Font-Bold="True" Font-Size="Medium" OnClick="Button4_Click" Text="ADD" />
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13">Tracking No:</td>
                <td class="auto-style14">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style9" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style18"></td>
                <td class="auto-style15">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5"></td>
                <td class="auto-style11"></td>
                <td class="auto-style17"></td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:TemplateField HeaderText="Order Status">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="Ostatus" Text="Pending" /><br />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Ostatus" Text="Processing" />
                        &nbsp;
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />  
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Update Status" CssClass="button" Font-Bold="True" Height="37px" Width="136px" OnClick="Button2_Click" />
        <br /><br />
    </div>
</asp:Content>
