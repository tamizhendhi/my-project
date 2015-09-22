using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class useraspx_CabBooking : System.Web.UI.Page
{
    string empid, name;
    decimal total;
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
    DateTime date = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {    
        
        date = date.Subtract(TimeSpan.FromDays(15)); 
        if (Session["Manager"] != null)
        {
            txtmanager.Text = Session["Manager"].ToString();
            empid = Session["Empid"].ToString();
            name = Session["Name"].ToString();
            txtVempid.Text = empid;
        }

        gridrefresh();
        gridVoucher();
        
        if (!Page.IsPostBack)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select distinct route  from settings where route <> 'Removed' ", con);
            SqlCommand com1 = new SqlCommand("select distinct route  from settings where route <> 'Removed' ", con);
            SqlCommand com2 = new SqlCommand("select distinct shift  from settings where shift <> '12:30'", con);
            SqlCommand com3 = new SqlCommand("select distinct route  from settings where route <> 'Removed' ", con);
            SqlCommand com4 = new SqlCommand("select distinct route  from settings where route <> 'Removed' ", con);
           
            DrpSource.DataSource = com.ExecuteReader();
            DrpDestination.DataSource = com1.ExecuteReader();
            DrpShifttime.DataSource = com2.ExecuteReader();
            DrpVdestination.DataSource = com3.ExecuteReader();
            DrpVsource.DataSource = com4.ExecuteReader();
          
            
            DrpSource.DataTextField = "route";
            DrpSource.DataValueField = "route";
            DrpDestination.DataTextField = "route";
            DrpDestination.DataValueField = "route";
            DrpShifttime.DataTextField = "shift".ToString();
            DrpShifttime.DataValueField = "shift".ToString();
            DrpVsource.DataTextField = "route";
            DrpVsource.DataValueField = "route";
            DrpVdestination.DataTextField = "route";
            DrpVdestination.DataValueField = "route";

            
            DrpSource.DataBind();
            DrpDestination.DataBind();
            DrpShifttime.DataBind();
            DrpVsource.DataBind();
            DrpVdestination.DataBind();
            con.Close();
            DrpSource.Items.Insert(0, new ListItem("--Ameex Technologies--", "Ameex Technologies"));
            DrpDestination.Items.Insert(0, new ListItem("--select--", "0"));
            DrpShifttime.Items.Insert(0, new ListItem("--select--", "0"));
            DrpCab.Items.Insert(0, new ListItem("--select--", "0"));
            DrpVsource.Items.Insert(0, new ListItem("--Ameex Technologies--", "Ameex Technologies"));
            DrpVdestination.Items.Insert(0, new ListItem("--select--", "0"));
         
        }
    }
    public void gridrefresh()
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status,canceleddate from booking where empid='" + empid + "' and bookingdate >='" + date + "' ", con);

        SqlDataAdapter da = new SqlDataAdapter(com4);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridUser.DataSource = dt;
            GridUser.DataBind();
        }
        con.Close();
 
    }
    public void gridVoucher()
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("select * from voucher where empid='" + empid + "'and (status='Requested' or status='Verified' or status='Confirmed') and bookingdate >='" + date + "' ", con);

        SqlDataAdapter da = new SqlDataAdapter(com4);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridVoucher.DataSource = dt;
            GridVoucher.DataBind();
        }
        con.Close();

    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
  
  

    protected void btnVoucher_Click(object sender, EventArgs e)
    {
        string pm="";
        if (Session["Manager"] != null)
        {
            pm = Session["Manager"].ToString();
        }

        if(txtVempid.Text!="" && txtVcost.Text!="" && txtVcabname.Text!=""  && FileVoucher.FileName!="" && DrpVdestination.SelectedIndex!=0)
        {
        try
        {
              con.Open();
            try
            {  
                SqlCommand com = new SqlCommand("insert into voucher values(@id,@cname,@src,@des,@date,@cost,@file,@status,@pmanager);", con);

                com.Parameters.AddWithValue("@id",empid);
                com.Parameters.AddWithValue("@cname", txtVcabname.Text);

                com.Parameters.AddWithValue("@src", DrpVsource.SelectedValue);
                com.Parameters.AddWithValue("@des", DrpVdestination.SelectedValue);

                com.Parameters.AddWithValue("@date", DateTime.Now);
                com.Parameters.AddWithValue("@cost", txtVcost.Text);

                com.Parameters.AddWithValue("@file", FileVoucher.FileName);
                com.Parameters.AddWithValue("@status", "Requested");
                com.Parameters.AddWithValue("@pmanager", pm);
                com.ExecuteNonQuery();
                con.Close();
                Messagebox("Voucher sent Successfully!!!");
               
                gridVoucher();
               

            }
            catch(Exception ex)
            {
                Messagebox("Employee Id doesn't exist!");
            }
           
        }
        catch (Exception ex)
        {
            Messagebox("Connection Failed");
        }
    }
    else{
        Messagebox("Please enter all the values");
        }

    }



    protected void btnReq_Click(object sender, EventArgs e)
    {
      
        DateTime day=DateTime.Now;
        int seat=0,capacity=0;
        if (DrpCab.SelectedIndex != 0 && DrpShifttime.SelectedIndex != 0)
        {

            try
            {
                con.Open();

                try
                {
                    SqlCommand com1 = new SqlCommand("select count(* )from booking where shift='" + DrpShifttime.SelectedValue + "' and cabname='" + DrpCab.SelectedValue + "' and startdate<='" + txtStartdate.Text + "' and enddate>='" + txtEnddate.Text + "' and  status<>'Canceled'", con);
                    SqlDataReader rd = com1.ExecuteReader();
                    SqlCommand cap = new SqlCommand("select capacity from settings where cabname='" + DrpCab.SelectedValue + "'", con);
                    SqlDataReader srd = cap.ExecuteReader();

                    while (srd.Read())
                    {
                        capacity = Int32.Parse(srd[0].ToString());
                    }
                    while (rd.Read())
                    {
                        seat = Int32.Parse(rd[0].ToString());
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + seat + "')</script>");
                    }
                    if (seat < capacity)
                    {
                        SqlCommand com = new SqlCommand("insert into booking values(@id,@name,@src,@des,@shift,@cname,@st,@end,@days,@date,@status,@canceleddate,@pm)", con);
                        DateTime dt = DateTime.Parse(txtStartdate.Text);

                        DateTime dt1 = DateTime.Parse(txtEnddate.Text);

                        double d1 = (dt1 - dt).TotalDays;
                        total = (decimal)d1 + 1;
                        com.Parameters.AddWithValue("@id", empid);

                        com.Parameters.AddWithValue("@name", name);
                        com.Parameters.AddWithValue("@src", DrpSource.SelectedValue);

                        com.Parameters.AddWithValue("@des", DrpDestination.SelectedValue);
                        com.Parameters.AddWithValue("@shift", DrpShifttime.SelectedValue);

                        com.Parameters.AddWithValue("@cname", DrpCab.SelectedValue);
                        com.Parameters.AddWithValue("@st", txtStartdate.Text);

                        com.Parameters.AddWithValue("@end", txtEnddate.Text);

                        com.Parameters.AddWithValue("@days", total);
                        com.Parameters.AddWithValue("@date", day);
                        com.Parameters.AddWithValue("@status", "Requested");
                        com.Parameters.AddWithValue("@canceleddate", "");
                        com.Parameters.AddWithValue("@pm", txtmanager.Text);

                        com.ExecuteNonQuery();
                        con.Close();
                        gridrefresh();
                        reset();

                        Messagebox("Booking Request send Successfully!!!");
                    }
                    else
                    {
                        Messagebox("Seat not available in this cab for your shifttime!!!");
                    }
                }
                catch (Exception ex)
                {
                    Messagebox("Request discarded");
                }
            }
            catch (Exception ex)
            {
                Messagebox("Connection Failed!!!");
            }
        }
        else
        {
            Messagebox("Please select shift or cab name!!!");
        }
    }
  
    protected void btnCancel_Click(object sender, EventArgs e)
{
      string confirmationValue = Request.Form["confirmValue"];

      if (confirmationValue == "Yes" && txtcanceldate.Text != "")
      {
          ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + txtcanceldate.Text + "')</script>");
              
          try
          {
              con.Open();
              try
              {
                  SqlCommand com = new SqlCommand("UPDATE booking SET status='Canceled' WHERE empid='" + empid + "' and (status='Requested' or status='Confirmed') and (startdate ='" + txtcanceldate.Text + "');", con);

                  com.ExecuteNonQuery();

                  Messagebox("Booking Canceled Successfully!!!");
              }
              catch (Exception ex)
              {
                  Messagebox("Request discarded");
              }
              con.Close();
              gridrefresh();
          }
          catch (Exception ex)
          {
              Messagebox("Connection Failed");
          }
      }
      else
      {
          Messagebox("Please enter values!!!");
      }

    }
    
    protected void DrpShifttime_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        DrpCab.Items.Clear();
        DrpCab.Items.Insert(0, new ListItem("--select--", "0"));
          
        SqlCommand com = new SqlCommand("select distinct cabname  from settings where shift=@shift;", con);
        com.Parameters.AddWithValue("@shift", DrpShifttime.SelectedValue);
        SqlDataReader r = com.ExecuteReader();
        while (r.Read())
        {
            string ss = r[0].ToString();
            DrpCab.Items.Add(ss);
        }
        r.Close();

        con.Close();
    }
    protected void DrpCab_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
       
        SqlCommand com = new SqlCommand("select distinct driver  from settings where cabname=@cname;", con);
        com.Parameters.AddWithValue("@cname", DrpCab.SelectedValue);
        SqlDataReader r = com.ExecuteReader();
        while (r.Read())
        {
            txtDriver.Text = r[0].ToString();
        }
        r.Close();

        con.Close();
    }
    protected void txtEnddate_TextChanged(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Parse(txtStartdate.Text);

        DateTime dt1 = DateTime.Parse(txtEnddate.Text);

        double d1 = (dt1 - dt).TotalDays;
        total = (decimal)d1 + 1;
               
        txtdays.Text = total.ToString();
    }

    protected void BtnCdate_Click(object sender, EventArgs e)
    {
       
            string confirmationValue = Request.Form["confirmValue"];

            if (confirmationValue == "Yes" && txtcanceldate.Text != "")
            {

                try
                {
                    con.Open();
                    try
                    {

                        SqlCommand com = new SqlCommand("UPDATE booking SET canceleddate='" + txtcanceldate.Text + "',days=(days-1) WHERE empid='" + empid + "' and (startdate <='" + txtcanceldate.Text + "' and enddate >='" + txtcanceldate.Text + "')", con);

                        com.ExecuteNonQuery();

                        Messagebox("Booking Canceled Successfully!!!");
                    }
                    catch (Exception ex)
                    {
                        Messagebox("Request discarded");
                    }
                    con.Close();
                    gridrefresh();
                }
                catch (Exception ex)
                {
                    Messagebox("Connection Failed");
                }
            }
            else
            {
                Messagebox("Please enter values!!!");
            }

    }
    public void reset(){
        DrpSource.SelectedIndex = 0;
        DrpDestination.SelectedIndex = 0;
        DrpShifttime.SelectedIndex = 0;
        DrpCab.SelectedIndex = 0;
        DrpVsource.SelectedIndex = 0;
        DrpVdestination.SelectedIndex = 0;
        txtcanceldate.Text = string.Empty;
        txtdays.Text = string.Empty;
        txtDriver.Text = string.Empty;
        txtEnddate.Text = string.Empty;
        txtStartdate.Text = string.Empty;
        txtVcabname.Text = string.Empty;
        txtVcost.Text = string.Empty;
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
}