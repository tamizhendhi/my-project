<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="CabSettings.aspx.cs" Inherits="adminaspx_CabSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="layout">
        <center>
            <h2> Service Settings </h2>
            
            
       <table>
           <tr>
                    <td><asp:Label ID="lblCabName" runat="server" Text="CabName"></asp:Label></td>
                    <td><asp:TextBox ID="txtCabName" runat="server"></asp:TextBox></td>
                  <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the Cabname" ControlToValidate="txtCabName"></asp:RequiredFieldValidator></td>
           </tr>
            <tr>
               <td><asp:Label ID="lblSeat" runat="server" Text="Total Seats"></asp:Label></td>
               <td><asp:TextBox ID="txtSeat" runat="server" TextMode="Number"></asp:TextBox></td>
            
           </tr>
          
           <tr>
               <td><asp:Label ID="LblDriver" runat="server" Text="Driver Details"></asp:Label></td>
               <td><asp:TextBox ID="txtDriver" runat="server" ></asp:TextBox></td>
            
           </tr>
           <tr>
                    <td><asp:Label ID="lblShifttime"  runat="server" Text="Shift Time" ></asp:Label></td>
                <td> <asp:TextBox ID="txtShifttime" runat="server" TextMode="Time"></asp:TextBox> </td>  
           </tr>
            <tr>
               <td><asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label></td>
              <td>  <asp:TextBox ID="txtRoute" runat="server"></asp:TextBox>  </td>
           </tr>
           <tr>
               <td><asp:Label ID="lblNews" runat="server" Text="Service News"></asp:Label></td>
               <td> <asp:TextBox ID="txtNews" runat="server"></asp:TextBox>   </td>

           </tr>
       </table>
             <asp:Button ID="btnAdd" runat="server" Text="Add Service" OnClick="btnAdd_Click" />               
             <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"/>
            </center>
           
         
          </div>
</asp:Content>

