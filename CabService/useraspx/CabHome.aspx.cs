using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class useraspx_CabHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
       
    public string MarqueText { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        con.Open();
        SqlCommand command = new SqlCommand("select news from settings", con);

        SqlDataReader sdr = command.ExecuteReader();

       while (sdr.Read())
        {
            MarqueText = sdr[0].ToString();
        }

      

        command.Dispose();
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

    protected void btnlogin_Click(object sender, EventArgs e)
    {

         con.Open();
        SqlCommand command = new SqlCommand("select empid,name,position,accounttype,pmanager from cabprofile where username='"+txtUser.Text+"' AND password='"+txtPassword.Text+"'", con);

        SqlDataReader sdr = command.ExecuteReader();
        
        if (sdr.Read())
        {
            Session["Name"] = sdr[1].ToString();
            Session["Empid"] = sdr[0].ToString();
            Session["Position"] = sdr[2].ToString();
            Session["Manager"] = sdr[4].ToString();
            Session["Account"] = sdr[3].ToString();
            if (sdr[3].ToString() == "Admin")
            {
                Response.Redirect("/adminaspx/CabAdmin.aspx");                            
            }

            else if (sdr[3].ToString() == "PM/HR")
            {
                Response.Redirect("/adminaspx/CabAdmin.aspx");   
            }
            else if (sdr[3].ToString() == "User")
            {

                Response.Redirect("/useraspx/CabUser.aspx");
            }
        }

       else 
       {
          Messagebox("Invalid Username or Password");
       }

        
        command.Dispose();
        con.Close();
       
    }
}