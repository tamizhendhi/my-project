<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabMaster.master" AutoEventWireup="true" CodeFile="CabUser.aspx.cs" Inherits="useraspx_CabBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabUser.css" rel="stylesheet" />
    <script src="../js/CabUser.js"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
        <div>
            <h3>Cab Profile</h3>
            <span><a href="CabProfileUpdate.aspx">Update Profile</a></span>
             <span>Booking Request<em>&#9660;</em></span>
            <span>Voucher Details<em>&#9660;</em></span>
            <asp:TextBox ID="txtcanceldate" runat="server"  TextMode="Date"></asp:TextBox>
           <center>
          <asp:Button ID="BtnCdate" runat="server" Text="Cancel Specific Date" OnClick="BtnCdate_Click" OnClientClick="confirmDelete()" ToolTip="Select date wants to cancel" />
          <asp:Button ID="btnCancel" runat="server" Text="Cancel Booking" OnClick="btnCancel_Click" OnClientClick="confirmDelete()" ToolTip="Choose start date to cancel booking" /></center>
       </div>
        <h3>Booking status:</h3>
         <asp:GridView class="GridStyle" ID="GridUser" runat="server"></asp:GridView>
        
       
        <div class="booking">
           
            <center>
            <h2>Wait for a Cab???</h2>
            </center>
            <table>
                <tr>
                    <td><asp:Label ID="lblSource" runat="server" Text="Source"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpSource" runat="server">
                                </asp:DropDownList>
                    </td>
                   </tr>
                 <tr>
                    <td><asp:Label ID="lblDestination" runat="server" Text="Destination"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpDestination" runat="server">
                               </asp:DropDownList>
                     </td>
                   </tr>
                 <tr>
                    <td><asp:Label ID="lblShifttime" runat="server" Text="Shift time"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpShifttime" runat="server" OnSelectedIndexChanged="DrpShifttime_SelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList>
                         </td>
                         </tr>
                <tr>
                    <td><asp:Label ID="lblCabname" runat="server" Text="Cab Name"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpCab" runat="server" OnSelectedIndexChanged="DrpCab_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                          </tr>
                
                  <tr>
                    <td><asp:Label ID="lblDriver" runat="server" Text="Cab Driver"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDriver" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                     </tr>
               
                 <tr>
                    <td><asp:Label ID="lblmanager" runat="server" Text="Project Manager"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtmanager" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                       </tr>
                <tr>
                    <td><asp:Label ID="lblStartdate" runat="server" Text="Startdate"></asp:Label></td>
                   <td>
                       <asp:TextBox ID="txtStartdate" runat="server" TextMode="Date"></asp:TextBox></td>
                     </tr>
                 <tr>
                    <td><asp:Label ID="lblEnddate" runat="server" Text="Enddate"></asp:Label></td>
                   <td>
                       <asp:TextBox ID="txtEnddate" runat="server" TextMode="Date" OnTextChanged="txtEnddate_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                     
                    
                </tr>
                
                  <tr>
                    <td><asp:Label ID="lbldays" runat="server" Text="No of Days"></asp:Label></td>
                    <td><asp:TextBox ID="txtdays" runat="server" Enabled="False"></asp:TextBox></td>
                 </tr>                    
            </table>
        <asp:Button ID="btnReq" runat="server" Text="Send Booking Request" OnClick="btnReq_Click"></asp:Button>
            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                 
        </div>

        <h3>Voucher Status:</h3>

        <div>
            <center>
            <h2>Voucher Details</h2>
            </center>
            <table>
                <tr>
                    <td><asp:Label ID="lblVempid" runat="server" Text="EmployeeID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVempid" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                       </tr>
                <tr>
                    <td><asp:Label ID="lblVcabname" runat="server" Text="Cab Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVcabname" runat="server"></asp:TextBox>
                    </td>
                   </tr>
                <tr>
                    <td><asp:Label ID="lblVsource" runat="server" Text="Source"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpVsource" runat="server">
                                </asp:DropDownList>
                    </td>
                   </tr>
                 <tr>
                    <td><asp:Label ID="lblVdestination" runat="server" Text="Destination"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpVdestination" runat="server">
                             </asp:DropDownList>
                     </td>
                   </tr>
                
                 <tr>
                    <td><asp:Label ID="lblVcost" runat="server" Text="Cost"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVcost" runat="server"></asp:TextBox>
                    </td>
                      </tr>
              
                
                  <tr>
                    <td><asp:Label ID="lblVfile" runat="server" Text="Voucher Bill"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="FileVoucher" runat="server" />
                    </td>
                         </tr>
               
                
               
               
            </table>
             <asp:Button ID="btnVoucher" runat="server" Text="Send Voucher" OnClick="btnVoucher_Click"></asp:Button>
            <asp:Button ID="btnVReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        </div>
       
        <asp:GridView ID="GridVoucher" class="GridStyle" runat="server"></asp:GridView>
        
             <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3888.096566218665!2d80.2466485!3d12.9656723!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3a525d6b55e76671%3A0x8d24eb61f1dca3b2!2sAmeex+Technologies!5e0!3m2!1sen!2sin!4v1442471297286" ></iframe>
   
    </div>
</asp:Content>

