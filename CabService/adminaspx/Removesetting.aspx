<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="Removesetting.aspx.cs" Inherits="adminaspx_Removesetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/Removesetting.css" rel="stylesheet" />
    <script src="../js/Removesetting.js"></script>
    <script src="../js/jquery-1.11.0.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
        <center>
            <h2> Service Settings </h2>
            <h3>Remove Services</h3>
            
                <ul  class="bdiv">
                        <li>Remove Cab &#9660;</li>
                        <li>Remove Shift&#9660;</li>
                        <li>Remove Route&#9660;</li>
                </ul>
            
            <div class="rcab">
                <table>
                <tr>
                    <td><asp:Label ID="lblCabName" runat="server" Text="CabName"></asp:Label></td>
                    <td><asp:TextBox ID="txtCabName" runat="server"></asp:TextBox></td>
                    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the Cabname" ControlToValidate="txtCabName"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                   <td><asp:Label ID="lblNews" runat="server" Text="Service News"></asp:Label></td>
                   <td> <asp:TextBox ID="txtNews" runat="server"></asp:TextBox>   </td>
                </tr>
                </table>
                <asp:Button ID="btnRcab" runat="server" Text="Remove Cab" />
             <asp:Button ID="btnResetrcab" runat="server" Text="Reset"  /> 
            </div>
            <div class="rshift">
                <table>
                <tr>
                    <td><asp:Label ID="lblCabNamershift" runat="server" Text="CabName"></asp:Label></td>
                    <td><asp:TextBox ID="txtCabNamershift" runat="server"></asp:TextBox></td>
                  <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter the Cabname" ControlToValidate="txtCabName"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblShifttime"  runat="server" Text="Shift Time"></asp:Label></td>
                    <td> <asp:TextBox ID="txtShifttime" runat="server" TextMode="Time"></asp:TextBox> </td>  
                </tr>
                <tr>
                   <td><asp:Label ID="lblNewsrshift" runat="server" Text="Service News"></asp:Label></td>
                   <td> <asp:TextBox ID="txtNewsrshift" runat="server"></asp:TextBox>   </td>
                </tr>
                    </table>
                <asp:Button ID="btnRshift" runat="server" Text="Remove Shift" />
             <asp:Button ID="btnResetRshift" runat="server" Text="Reset"  /> 
            </div>
            <div class="rroute">
                <table>
                <tr>
                    <td><asp:Label ID="lblCabNamerroute" runat="server" Text="CabName"></asp:Label></td>
                    <td><asp:TextBox ID="txtCabNamerroute" runat="server"></asp:TextBox></td>
                  <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter the Cabname" ControlToValidate="txtCabName"></asp:RequiredFieldValidator></td>
                </tr>
                 <tr>
               <td><asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label></td>
              <td>  <asp:TextBox ID="txtRoute" runat="server"></asp:TextBox>  </td>
           </tr>
               
                <tr>
                   <td><asp:Label ID="lblNewsrroute" runat="server" Text="Service News"></asp:Label></td>
                   <td> <asp:TextBox ID="txtNewsrroute" runat="server"></asp:TextBox>   </td>
                </tr>
                    </table>
                <asp:Button ID="btnRroute" runat="server" Text="Remove Route" />
             <asp:Button ID="btnResetrroute" runat="server" Text="Reset"  /> 
            </div>
        </center>
    </div>

</asp:Content>

