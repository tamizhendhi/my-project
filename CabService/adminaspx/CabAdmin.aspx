<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="CabAdmin.aspx.cs" Inherits="adminaspx_CabAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReport.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
        <h2>Booking Request:</h2>
        <asp:GridView ID="GridView1" class="GridStyle" runat="server" AutoGenerateColumns="False"
      OnRowCommand="GridView1_RowCommand" >
           <Columns>
       
               <asp:BoundField DataField="empid" HeaderText="EmpID"  />
                <asp:BoundField DataField="name" HeaderText="Name"  />
                 <asp:BoundField DataField="source" HeaderText="Source"  />
                <asp:BoundField DataField="destination" HeaderText="Destination"  />
                <asp:BoundField DataField="shift" HeaderText="Shift"  />
                <asp:BoundField DataField="cabname" HeaderText="Cabname"  />
                 <asp:BoundField DataField="startdate" HeaderText="Startdate"  />
                <asp:BoundField DataField="enddate" HeaderText="Enddate"  />
                 <asp:BoundField DataField="days" HeaderText="Days"  />
                <asp:BoundField DataField="bookingdate" HeaderText="Bookingdate"  />
                  <asp:BoundField DataField="status" HeaderText="Status"  />
               <asp:BoundField DataField="canceleddate" HeaderText="Canceleddate"  />
             

                 <asp:TemplateField>
                <ItemTemplate>
<asp:Button ID="btnAccept"  runat="server" CommandName="Accept" Text="Accept" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
       />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
<asp:Button ID="btnReject" CommandName="Reject" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
      Text="Reject" />
                </ItemTemplate>
            </asp:TemplateField>
    </Columns>     
                
      </asp:GridView>
        <asp:Button ID="btnAcceptall" runat="server" Text="Accept All" OnClick="btnAcceptall_Click"  />
        <asp:Button ID="btnRejectall" runat="server" Text="Reject All" OnClick="btnRejectall_Click" />
    </div>





</asp:Content>

