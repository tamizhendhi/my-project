<%@ Page Title="" Language="C#" MasterPageFile="~/master/CabAdminMaster.master" AutoEventWireup="true" CodeFile="CabAdmin.aspx.cs" Inherits="adminaspx_CabAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/CabReport.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="2"
        CellSpacing="2" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="white" Width="500px" OnRowCommand="GridView1_RowCommand" >
           <Columns>
       
               <asp:BoundField DataField="empid" HeaderText="empid"  />
                <asp:BoundField DataField="name" HeaderText="name"  />
                 <asp:BoundField DataField="source" HeaderText="source"  />
                <asp:BoundField DataField="destination" HeaderText="destination"  />
                <asp:BoundField DataField="shift" HeaderText="shift"  />
                <asp:BoundField DataField="cabname" HeaderText="cabname"  />
                 <asp:BoundField DataField="startdate" HeaderText="startdate"  />
                <asp:BoundField DataField="enddate" HeaderText="enddate"  />
                 <asp:BoundField DataField="days" HeaderText="days"  />
                <asp:BoundField DataField="bookingdate" HeaderText="bookingdate"  />
                  <asp:BoundField DataField="status" HeaderText="status"  />
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
    </div>
</asp:Content>

