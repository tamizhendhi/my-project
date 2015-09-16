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
           <center> <asp:Button ID="btnCancel" runat="server" Text="Cancel Booking" OnClick="btnCancel_Click" /></center>
       </div>
        
     <%--  <div>
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
                   <asp:Button ID="btnShow" runat="server" Text="Show" Width="100%" /></td> </tr>
            </table>

       </div>--%>
            <asp:GridView class="GridStyle" ID="GridView1" runat="server"></asp:GridView>

       
        <div>
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
                        <asp:DropDownList ID="DrpShifttime" runat="server"></asp:DropDownList>
                         </td>
                         </tr>
                <tr>
                    <td><asp:Label ID="lblCabname" runat="server" Text="Cab Name"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpCab" runat="server" OnSelectedIndexChanged="DrpCab_SelectedIndexChanged" ></asp:DropDownList></td>
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
                       <asp:TextBox ID="txtEnddate" runat="server" TextMode="Date"></asp:TextBox></td>
                     
                    
                </tr>
                
                  <tr>
                    <td><asp:Label ID="lbldays" runat="server" Text="No of Days"></asp:Label></td>
                    <td><asp:TextBox ID="txtdays" runat="server" Enabled="False"></asp:TextBox></td>
                 </tr>                    
            </table>
        <asp:Button ID="btnReq" runat="server" Text="Send Booking Request" OnClick="btnReq_Click"></asp:Button>
            <asp:Button ID="btnReset" runat="server" Text="Reset" />
        </div>



        <div>
            <center>
            <h2>Voucher Details</h2>
            </center>
            <table>
                <tr>
                    <td><asp:Label ID="lblVempid" runat="server" Text="EmployeeID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVempid" runat="server"></asp:TextBox>
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
                            <asp:ListItem>--select--</asp:ListItem>
                            <asp:ListItem>Thambaram</asp:ListItem>
                            <asp:ListItem>Medavakkam</asp:ListItem>
                            <asp:ListItem>Kelampakkam</asp:ListItem>
                            <asp:ListItem>Solinganallur</asp:ListItem>
                            <asp:ListItem>Perungudi</asp:ListItem>
                            <asp:ListItem>Trivanmiyur</asp:ListItem>
                            <asp:ListItem>Velacheri</asp:ListItem>
                            <asp:ListItem>Guindy</asp:ListItem>
                            <asp:ListItem>Arumpakkam</asp:ListItem>
                            <asp:ListItem>Ashokepillar</asp:ListItem>
                            <asp:ListItem>Coimbet</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   </tr>
                 <tr>
                    <td><asp:Label ID="lblVdestination" runat="server" Text="Destination"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DrpVdestination" runat="server">
                            <asp:ListItem>--select--</asp:ListItem>
                            <asp:ListItem>Thambaram</asp:ListItem>
                            <asp:ListItem>Medavakkam</asp:ListItem>
                            <asp:ListItem>Kelampakkam</asp:ListItem>
                            <asp:ListItem>Solinganallur</asp:ListItem>
                            <asp:ListItem>Perungudi</asp:ListItem>
                            <asp:ListItem>Trivanmiyur</asp:ListItem>
                            <asp:ListItem>Velacheri</asp:ListItem>
                            <asp:ListItem>Guindy</asp:ListItem>
                            <asp:ListItem>Arumpakkam</asp:ListItem>
                            <asp:ListItem>Ashokepillar</asp:ListItem>
                            <asp:ListItem>Coimbet</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                   </tr>
                 <tr>
                    <td><asp:Label ID="lblVbookdate" runat="server" Text="Booking Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVbookdate" runat="server" TextMode="Date"></asp:TextBox>
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
            <asp:Button ID="btnVReset" runat="server" Text="Reset" />
        </div>
       
        <div>

        </div>

    </div>
</asp:Content>

