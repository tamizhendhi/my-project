<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabMaster.master" AutoEventWireup="true" CodeFile="CabHome.aspx.cs" Inherits="useraspx_CabHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabHome.css" rel="stylesheet" />
    <script src="../js/CabHome.js"></script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
         <div> 
              <p>Flash News &#10095;</p><marquee scrolldelay="150"  ><%= MarqueText %></marquee>
         </div>
       <div id="slider">
            <figure>
            <img src="../images/cab2.jpg" alt="cab">
            <img src="../images/cab3.jpg" alt="cab">
            <img src="../images/cab.jpg" alt="cab">
            <img src="../images/cab1.jpg" alt="cab">        
            <img src="../images/cab4.jpg" alt="cab">
            </figure>
       </div>
       <div>
           <center>
        <img src="../images/userlogo.jpg" alt="admin" />
        <asp:TextBox ID="txtUser" runat="server"  Text="Email"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" Text="password" TextMode="Password" ></asp:TextBox>
        <asp:Button ID="btnlogin" runat="server" Text="Login"  OnClick="btnlogin_Click"></asp:Button>
        <a href="CabPassword.aspx">Remember password?</a>              
        </center> 
          <center> <a href="CabReg.aspx"><span>If you are new user please register!</span></a>  </center>
    </div>

        
        
    </div>
</asp:Content>

