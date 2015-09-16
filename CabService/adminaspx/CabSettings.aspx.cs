using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminaspx_CabSettings : System.Web.UI.Page
{
     SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
           
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
         try
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("insert into settings values(@cname,@driver,@shift,@route,@news)", con);

                  com.Parameters.AddWithValue("@cname", txtCabName.Text);
                com.Parameters.AddWithValue("@driver", txtDriver.Text);

                com.Parameters.AddWithValue("@shift", txtShifttime.Text);
                com.Parameters.AddWithValue("@route",txtRoute.Text);

                com.Parameters.AddWithValue("@news",txtNews.Text);
                com.ExecuteNonQuery();
                    
                
                Messagebox("Settings Added Successfully!!!");
                Response.Redirect("CabAdmin.aspx");
            }
            catch (Exception ex)
            { 
                 Messagebox("Settings can't be added!!!"); 
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Messagebox("Connection Failed"); 
        }
   
    }

    
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("delete from settings where cabname=@cname AND shift=@shift", con);

                com.Parameters.AddWithValue("@cname", txtCabName.Text);
                com.Parameters.AddWithValue("@driver", txtDriver.Text);

                com.Parameters.AddWithValue("@shift", txtShifttime.Text);
                com.Parameters.AddWithValue("@route", txtRoute.Text);

                com.Parameters.AddWithValue("@news", txtNews.Text);
                com.ExecuteNonQuery();


                Messagebox("Settings Removed Successfully!!!");
                Response.Redirect("CabAdmin.aspx");
            }
            catch(Exception ex)
            {
                Messagebox("Settings can't be removeddded!!!");
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Messagebox("Connection Failed");
        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCabName.Text =string.Empty;
        txtDriver.Text = string.Empty;
        txtNews.Text = string.Empty;
        txtRoute.Text = string.Empty;
        txtShifttime.Text = string.Empty;
    }
}