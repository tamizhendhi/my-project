using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminaspx_Removesetting : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
   
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
    protected void btnRshift_Click(object sender, EventArgs e)
    {
        if (txtCabNamershift.Text != "" && txtShifttime.Text != "" && txtNewsrshift.Text != "")
        {
            try
            {
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand("delete from settings where (cabname='" + txtCabNamershift.Text + "' and shift='" + txtShifttime.Text + "')", con);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    SqlCommand com1 = new SqlCommand("insert into settings values(@cname,@driver,@shift,@route,@news,@capacity);", con);

                    com1.Parameters.AddWithValue("@cname", "Removed");

                    com1.Parameters.AddWithValue("@driver", "Removed");
                    com1.Parameters.AddWithValue("@shift", "12:30");

                    com1.Parameters.AddWithValue("@route", "Removed");
                    com1.Parameters.AddWithValue("@news", txtNewsrshift.Text);

                    com1.Parameters.AddWithValue("@capacity", 0);
                    com1.ExecuteNonQuery();
                    reset();
                    Messagebox("Shift removed successfully!!!");

                }
                catch (Exception ex)
                {
                    Messagebox("Shift can't be removed!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Messagebox("Connection Failed");
            }


        }
        else
        {
            Messagebox("Please enter values???");
        }
    }
    protected void btnRcab_Click(object sender, EventArgs e)
    {
        if (txtCabName.Text != "" && txtNews.Text != "")
        {
            try
            {
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand("delete from settings where cabname='" + txtCabName.Text + "'", con);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    SqlCommand com1 = new SqlCommand("insert into settings values(@cname,@driver,@shift,@route,@news,@capacity);", con);

                    com1.Parameters.AddWithValue("@cname", "Removed");

                    com1.Parameters.AddWithValue("@driver", "Removed");
                    com1.Parameters.AddWithValue("@shift", "12:30");

                    com1.Parameters.AddWithValue("@route", "Removed");
                    com1.Parameters.AddWithValue("@news", txtNews.Text);

                    com1.Parameters.AddWithValue("@capacity", 0);

                    com1.ExecuteNonQuery();
                    reset();
                    Messagebox("Cab removed successfully!!!");


                }
                catch (Exception ex)
                {
                    Messagebox("Cab can't be removed!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Messagebox("Connection Failed");
            }
        }
        else
        {
            Messagebox("Please enter values???");
        }

    }
    protected void btnRroute_Click(object sender, EventArgs e)
    {
        if (txtCabNamerroute.Text != "" && txtRoute.Text != "" && txtNewsrroute.Text != "")
        {
            try
            {
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand("delete from settings where (cabname='" + txtCabNamerroute.Text + "' and route='" + txtRoute.Text + "')", con);
                    com.ExecuteNonQuery();
                    com.Dispose();
                    SqlCommand com1 = new SqlCommand("insert into settings values(@cname,@driver,@shift,@route,@news,@capacity);", con);

                    com1.Parameters.AddWithValue("@cname", "Removed");

                    com1.Parameters.AddWithValue("@driver", "Removed");
                    com1.Parameters.AddWithValue("@shift", "12:30");

                    com1.Parameters.AddWithValue("@route", "Removed");
                    com1.Parameters.AddWithValue("@news", txtNewsrroute.Text);
                    com1.Parameters.AddWithValue("@capacity", 0);
                    com1.ExecuteNonQuery();
                    reset();
                    Messagebox("Route removed successfully!!!");


                }
                catch (Exception ex)
                {
                    Messagebox("Route can't be removed!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Messagebox("Connection Failed");
            }
        }
        else
        {
            Messagebox("Please enter values???");
        }
    }
    public void reset()
    {
        txtCabName.Text = string.Empty;
        txtCabNamerroute.Text = string.Empty;
        txtCabNamershift.Text = string.Empty;
        txtNews.Text = string.Empty;
        txtNewsrroute.Text = string.Empty;
        txtNewsrshift.Text = string.Empty;
        txtRoute.Text = string.Empty;
        txtShifttime.Text = string.Empty;
    }
    protected void btnResetrcab_Click(object sender, EventArgs e)
    {
        reset();
    }
}