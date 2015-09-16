<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="CabSettings.aspx.cs" Inherits="adminaspx_CabSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="layout">
        <center>
            <h2> Service Settings </h2>
            
            <div>
                <ul>
                <li>Add Service &#9660;</li>
                <li><span>Remove Service &#9660;</span>
                    <ul>
                        <li>Remove Cab &#9660;</li>
                        <li>Remove Shift&#9660;</li>
                        <li>Remove Route&#9660;</li>
                   </ul>

                </li>
                    </ul>
            </div>
            
       <table>
           <tr>
                    <td><asp:Label ID="lblCabName" runat="server" Text="CabName"></asp:Label></td>
                    <td><asp:TextBox ID="txtCabName" runat="server"></asp:TextBox></td>
                  <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the Cabname" ControlToValidate="txtCabName"></asp:RequiredFieldValidator></td>
           </tr>
          
           <tr>
               <td><asp:Label ID="LblDriver" runat="server" Text="Driver Details"></asp:Label></td>
               <td><asp:TextBox ID="txtDriver" runat="server" ></asp:TextBox></td>
            
           </tr>
           <tr>
                    <td><asp:Label ID="lblShifttime"  runat="server" Text="Shift Time"></asp:Label></td>
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
             <asp:Button ID="btnRemove" runat="server" Text="Remove Service" OnClick="btnRemove_Click"/>
             <asp:Button ID="btnAdd" runat="server" Text="Add Service" OnClick="btnAdd_Click" />               
             <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"/>
            </center>
           
         
          </div>
</asp:Content>

