<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="CabReport.aspx.cs" Inherits="adminaspx_CabReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReport.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
          
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblDetailstdate" runat="server" Text="Start Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDetailstdate" runat="server" TextMode="Date"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="lblDetailenddate" runat="server" Text="End Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDetailenddate" runat="server" TextMode="Date"></asp:TextBox></td>
               <td>
                   <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td> </tr>
            </table>
        <asp:GridView class="GridStyle" ID="GridView1" runat="server"></asp:GridView>

        <center><asp:Button ID="btnExcel" runat="server" Text="Excel Report" OnClick="btnExcel_Click"></asp:Button></center>
    
    </div>
</asp:Content>

