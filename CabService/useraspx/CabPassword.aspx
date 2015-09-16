<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabMaster.master" AutoEventWireup="true" CodeFile="CabPassword.aspx.cs" Inherits="useraspx_CabPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="frame">
    <asp:TextBox ID="txtRemember" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtRemember" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="string"></asp:RegularExpressionValidator>
    <asp:Button ID="btnRemember" runat="server" Text="Send Email" OnClick="btnRemember_Click" />
        </div>
</asp:Content>

