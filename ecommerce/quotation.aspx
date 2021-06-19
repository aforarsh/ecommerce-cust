<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeFile="quotation.aspx.cs" Inherits="ecommerce.quotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
    <div style="font-family: Arial; align-items:center;" dir="ltr" draggable="auto">
    <fieldset style="width: 300px">
        <legend title="Contact us" ForeColor="Red" style="color: #000000; font-style: normal; background-color: #FFFFFF; text-transform: none;">Contact us</legend>
        <table>
            <tr>
                <td style="background-color: #CC9900">
                    <b>Name:</b>
                </td>
                <td>
                    <asp:TextBox 
                        ID="txtName" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator1" 
                        runat="server"
                        ControlToValidate="txtName" 
                        ErrorMessage="Name is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #CC9900">
                    <b>Email:</b>
                </td>
                <td>
                    <asp:TextBox 
                        ID="txtEmail" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator 
                        Display="Dynamic" 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator2"
                        runat="server" 
                        ControlToValidate="txtEmail" 
                        ErrorMessage="Email is required"
                        Text="*">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                        Display="Dynamic" 
                        ForeColor="Red" 
                        ID="RegularExpressionValidator1"
                        runat="server" 
                        ErrorMessage="Invalid Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail"
                        Text="*">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #CC9900">
                    <b style="color: #000000; background-color: #CC9900;">Subject:</b>
                </td>
                <td>
                    <asp:TextBox 
                        ID="txtSubject" 
                        Width="200px" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator3" 
                        runat="server"
                        ControlToValidate="txtSubject" 
                        ErrorMessage="Subject is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; background-color: #CC9900;">
                    <b>Propose Quotation:</b>
                </td>
                <td style="vertical-align: top">
                    <asp:TextBox 
                        ID="txtComments" 
                        Width="200px" 
                        TextMode="MultiLine" 
                        Rows="5" 
                        runat="server">
                    </asp:TextBox>
                </td>
                <td style="vertical-align: top">
                    <asp:RequiredFieldValidator 
                        ForeColor="Red" 
                        ID="RequiredFieldValidator4" 
                        runat="server"
                        ControlToValidate="txtComments" 
                        ErrorMessage="Comments is required" 
                        Text="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary 
                        HeaderText="Please fix the following errors" 
                        ForeColor="Red"
                        ID="ValidationSummary1" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label 
                        ID="lblMessage" 
                        runat="server" 
                        Font-Bold="true">
                    </asp:Label>

                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button 
                        ID="Button1" 
                        runat="server" 
                        Text="Submit" 
                        OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</div>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    
        
</asp:Content>
