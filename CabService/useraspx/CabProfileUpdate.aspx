<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabMaster.master" AutoEventWireup="true" CodeFile="CabProfileUpdate.aspx.cs" Inherits="useraspx_CabProfileUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Cab Profilation</title>
    <link href="../css/CabReg.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="layout">
         
             
         
        <center>
            <h2> User Profilation</h2>
            
       <table>
           <tr>
                    <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the value" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator></td>
           </tr>
          
           <tr>
               <td><asp:Label ID="LblAdd" runat="server" Text="Address"></asp:Label></td>
               <td><asp:TextBox ID="txtAdd" runat="server" TextMode="MultiLine" ControlToValidate="txtAdd"></asp:TextBox></td>
              <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter address" ControlToValidate="txtAdd"></asp:RequiredFieldValidator></td>
           </tr>
           <tr>
                    <td><asp:Label ID="lblPos"  runat="server" Text="Position"></asp:Label></td>
                    <td><asp:DropDownList  ID="DrpPos" runat="server">
                        <asp:ListItem>select</asp:ListItem>
                        <asp:ListItem>Technical</asp:ListItem>
                        <asp:ListItem>Project Manager</asp:ListItem>
                        <asp:ListItem>Human Resource</asp:ListItem>                        
                        </asp:DropDownList></td>
           </tr>
            <tr>
               <td><asp:Label ID="lblTec" runat="server" Text="Technology"></asp:Label></td>
               <td><asp:DropDownList ID="DrpTec" runat="server">
                        <asp:ListItem>select</asp:ListItem>
                        <asp:ListItem>Dot Net</asp:ListItem>
                        <asp:ListItem>EpiServer</asp:ListItem>
                        <asp:ListItem>Ectran</asp:ListItem>
                   </asp:DropDownList></td>

           </tr>
           <tr>
               <td><asp:Label ID="lblPM" runat="server" Text="PM Name"></asp:Label></td>
               <td><asp:DropDownList ID="DrpPM" runat="server">
                        <asp:ListItem>select</asp:ListItem>
                        <asp:ListItem>Bazharam Arivu</asp:ListItem>
                        <asp:ListItem>Fakkir Mohamed</asp:ListItem>
                        <asp:ListItem>Rajkumar</asp:ListItem>
                        
                   </asp:DropDownList></td>

           </tr>
           
           <tr>
                    <td><asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label></td>
                    <td><asp:TextBox ID="txtPhone" runat="server" ControlToValidate="txtPhone"></asp:TextBox></td>
               <td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Correct Mobile no" EnableViewState="True" ControlToValidate="txtPhone" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator></td>
           </tr>
          
            
           
           
          
       </table>
             <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"  />
             
            </center>
           
         
          </div>
    
    
</asp:Content>

