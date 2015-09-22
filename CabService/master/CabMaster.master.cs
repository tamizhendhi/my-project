using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CabMaster : System.Web.UI.MasterPage
{
    string empid,atype;
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
    public string shift { get; set; }
    public string route { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        userhome.Visible = false; 
        update.Visible = false;
            if (Session["Empid"] != null && Session["Account"]!=null)
            {
                empid = Session["Empid"].ToString();
                lblEmpid.Text = Session["Empid"].ToString();
                lblName.Text = Session["Name"].ToString();
                lblPosition.Text = Session["Position"].ToString();
                atype = Session["Account"].ToString();
            }

            if (atype == "User")
            {
                home.Visible = false;
                signup.Visible = false;
                userhome.Visible = true;
                update.Visible = true;
            }
            con.Open();
            SqlCommand command = new SqlCommand("select distinct shift from settings", con);
            SqlCommand command1 = new SqlCommand("select distinct route from settings", con);
            SqlDataReader sdrshift = command.ExecuteReader();
            SqlDataReader sdrroute = command1.ExecuteReader();
            while (sdrshift.Read())
            {   
                if(sdrshift[0].ToString()!="12:30:00")
                shift += String.Format("{0:t tt}", sdrshift[0].ToString())+ "<br/>";
               
              
            }
            while (sdrroute.Read())
            {
                if (sdrroute[0].ToString() != "Removed")
                route += sdrroute[0].ToString()+"<br/>";

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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Empid");
        Session.Remove("Name");
        Session.Remove("Position");
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore(); 
        Response.Redirect("../useraspx/CabHome.aspx");
        
    }





    protected void btnChangepassword_Click(object sender, EventArgs e)
    {
        if (txtConfirmpassword.Text == txtNewpassword.Text)
        {
            con.Open();
            SqlCommand com4 = new SqlCommand("UPDATE cabprofile SET password='" + txtNewpassword.Text + "' WHERE (password='" + txtOldpassword.Text + "' and empid =@empid)", con);
            com4.Parameters.AddWithValue("@empid", empid);
            com4.ExecuteNonQuery();
            con.Close();
            Messagebox("Password changed successfully!!!");
        }
        else 
        {
            Messagebox("Password Mismatch???");
        }
           
    }
}
