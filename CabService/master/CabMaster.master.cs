using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CabMaster : System.Web.UI.MasterPage
{
    Label [] lb=new Label[20];
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
   

    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["Empid"] != null)
            {
                lblEmpid.Text = Session["Empid"].ToString();
                lblName.Text = Session["Name"].ToString();
                lblPosition.Text = Session["Position"].ToString();
            }

            //con.Open();
            //SqlCommand command = new SqlCommand("select route from settings", con);

            //SqlDataReader sdr = command.ExecuteReader();

            //while (sdr.Read())
            //{

            //    for (int l=0;l<sdr.ToString().Length;l++) 
            //    {
            //        lb[l].Text =sdr[0].ToString() ;
            //    }
                
            //}
            //Response.Write(lb);


            //command.Dispose();
            //con.Close();

       
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("Empid");
        Session.Remove("Name");
        Session.Remove("Position");

        Session.RemoveAll();
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore(); 
        Response.Redirect("../useraspx/CabHome.aspx");
        
    }

}
