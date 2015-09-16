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
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {    
        DateTime date = DateTime.Now;
        date = date.Subtract(TimeSpan.FromDays(7)); 
        if (Session["Manager"] != null)
        {
            txtmanager.Text = Session["Manager"].ToString();
            empid = Session["Empid"].ToString();
            name = Session["Name"].ToString();
        }
        con.Open();
        SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status from booking where empid='"+empid+"' and bookingdate >='"+date+"' ", con);
             
          SqlDataAdapter da = new SqlDataAdapter(com4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                con.Close();


        if (!Page.IsPostBack)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select distinct route  from settings ", con);
            SqlCommand com1 = new SqlCommand("select distinct route  from settings ", con);
            SqlCommand com2 = new SqlCommand("select distinct shift  from settings ", con);
            SqlCommand com3 = new SqlCommand("select distinct cabname  from settings ", con);
            DrpSource.DataSource = com.ExecuteReader();
            DrpDestination.DataSource = com1.ExecuteReader();
            DrpShifttime.DataSource = com2.ExecuteReader();
            DrpCab.DataSource = com3.ExecuteReader();

            DrpSource.DataTextField = "route";
            DrpSource.DataValueField = "route";
            DrpDestination.DataTextField = "route";
            DrpDestination.DataValueField = "route";
            DrpShifttime.DataTextField = "shift".ToString();
            DrpShifttime.DataValueField = "shift".ToString();
            DrpCab.DataTextField = "cabname";
            DrpCab.DataValueField = "cabname";

            DrpSource.DataBind();
            DrpDestination.DataBind();
            DrpShifttime.DataBind();
            DrpCab.DataBind();
            con.Close();
            DrpSource.Items.Insert(0, new ListItem("--select--", "0"));
            DrpDestination.Items.Insert(0, new ListItem("--select--", "0"));
            DrpShifttime.Items.Insert(0, new ListItem("--select--", "0"));
            DrpCab.Items.Insert(0, new ListItem("--select--", "0"));
           
        }
    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
    protected void DrpCab_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand com = new SqlCommand("select distinct driver  from settings where cabname=@cname;", con);
        com.Parameters.AddWithValue("@cname", DrpCab.SelectedValue);
        SqlDataReader sdr = com.ExecuteReader();
        if (sdr.Read())
        {
            txtDriver.Text = sdr[0].ToString();
        }

        con.Close();
    }
    protected void btnVoucher_Click(object sender, EventArgs e)
    {
        if(txtVempid.Text!="" && txtVcost.Text!="" && txtVcabname.Text!="" && txtVbookdate.Text!="" && FileVoucher.FileName!="" && DrpVsource.SelectedIndex!=0 && DrpVdestination.SelectedIndex!=0)
        {
        try
        {
              con.Open();
            try
            {  
                SqlCommand com = new SqlCommand("insert into voucher values(@id,@cname,@src,@des,@date,@cost,@file);", con);

                com.Parameters.AddWithValue("@id", "EMP-"+txtVempid.Text);
                com.Parameters.AddWithValue("@cname", txtVcabname.Text);

                com.Parameters.AddWithValue("@src", DrpVsource.SelectedValue);
                com.Parameters.AddWithValue("@des", DrpVdestination.SelectedValue);

                com.Parameters.AddWithValue("@date", txtVbookdate.Text);
                com.Parameters.AddWithValue("@cost", txtVcost.Text);

                com.Parameters.AddWithValue("@file", FileVoucher.FileName);



                com.ExecuteNonQuery();
                Messagebox("Voucher sent Successfully!!!");

            }
            catch(Exception ex)
            {
                Messagebox("Employee Id doesn't exist!");
            }
            con.Close();
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

        try
        {
             con.Open();
            try
            {
                SqlCommand com = new SqlCommand("insert into booking values(@id,@name,@src,@des,@shift,@cname,@st,@end,@days,@date,@status)", con);
                DateTime dt = DateTime.Parse(txtStartdate.Text);

                DateTime dt1 = DateTime.Parse(txtEnddate.Text);

                double d1 = (dt1 - dt).TotalDays;
                decimal total = (decimal)d1;
                com.Parameters.AddWithValue("@id", empid);

                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@src", DrpSource.SelectedValue.ToString());

                com.Parameters.AddWithValue("@des", DrpDestination.SelectedValue);
                com.Parameters.AddWithValue("@shift", DrpShifttime.SelectedValue);

                com.Parameters.AddWithValue("@cname", DrpCab.SelectedValue);
                com.Parameters.AddWithValue("@st", txtStartdate.Text);

                com.Parameters.AddWithValue("@end", txtEnddate.Text);

                com.Parameters.AddWithValue("@days", total);
                com.Parameters.AddWithValue("@date", day);
                com.Parameters.AddWithValue("@status", "Requested");
                com.ExecuteNonQuery();
                Messagebox("Request send Successfully!!!");
                Response.Redirect("CabUser.aspx");
            }
            catch (Exception ex)
            {
                Messagebox("Request discarded");
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Messagebox("Connection Failed");
        }
    
    
    }
  
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("UPDATE booking SET status='Canceled' WHERE empid='" + empid + "' and (status='Requested' or status='Confirmed');", con);

                com.ExecuteNonQuery();
                Messagebox("Booking Canceled Successfully!!!");
            }
            catch (Exception ex)
            {
                Messagebox("Request discarded");
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Messagebox("Connection Failed");
        }

    }
}