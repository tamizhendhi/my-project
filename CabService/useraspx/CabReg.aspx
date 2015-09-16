<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabMaster.master" AutoEventWireup="true" CodeFile="CabReg.aspx.cs" Inherits="useraspx_CabReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReg.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="layout">
         
             
         
        <center>
            <h2> User Registration</h2>
            
       <table>
           <tr>
                    <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the value" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator></td>
           </tr>
           <tr>
                    <td><asp:Label ID="lblEmpid"  runat="server" Text="Employee ID"></asp:Label></td>
                    <td><asp:TextBox ID="txtEmpid" runat="server"></asp:TextBox></td>
              <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter the ID" ControlToValidate="txtEmpid"></asp:RequiredFieldValidator></td>
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
               <td><asp:Label ID="LblTec" runat="server" Text="Technology"></asp:Label></td>
               <td><asp:DropDownList ID="DrpTec" runat="server">
                        <asp:ListItem>--select--</asp:ListItem>
                   <asp:ListItem>Mobile Technology</asp:ListItem>
                        <asp:ListItem>Dot Net</asp:ListItem>
                        <asp:ListItem>EpiServer</asp:ListItem>
                        <asp:ListItem>Ectran</asp:ListItem>
                        <asp:ListItem>Drupal</asp:ListItem>
                        <asp:ListItem>Joomla</asp:ListItem>                        
                        <asp:ListItem>Mejanto</asp:ListItem>
                   </asp:DropDownList></td>

           </tr>
           <tr>
               <td><asp:Label ID="lblPM" runat="server" Text="PM Name"></asp:Label></td>
               <td><asp:DropDownList ID="DrpPM" runat="server">
                                               
                   </asp:DropDownList></td>

           </tr>
           
           <tr>
                    <td><asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label></td>
                    <td><asp:TextBox ID="txtPhone" runat="server" ControlToValidate="txtPhone"></asp:TextBox></td>
               <td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Correct Mobile no" EnableViewState="True" ControlToValidate="txtPhone" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator></td>
           </tr>
           <tr>
                    <td><asp:Label ID="lblUser" runat="server" Text="User Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtUser" runat="server" Text="Enter email"></asp:TextBox></td>
                    <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email" ControlToValidate="txtUser" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="string"></asp:RegularExpressionValidator></td>
           </tr>
            
           
            <tr>
                    <td><asp:Label ID="lblPswd" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="txtPswd" runat="server" TextMode="Password" ControlToValidate="txtPswd"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter password" ControlToValidate="txtPswd"></asp:RequiredFieldValidator></td>
           </tr>
           <tr>
                    <td><asp:Label ID="lblCpswd" runat="server" Text="Confirm Password"></asp:Label></td>
                    <td><asp:TextBox ID="txtCpswd" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch!!!" ControlToCompare="txtPswd" ControlToValidate="txtCpswd"></asp:CompareValidator></td>
           </tr>
          
       </table>
             <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"  />
             
            </center>
           
         
          </div>
    
    
   </asp:Content>

