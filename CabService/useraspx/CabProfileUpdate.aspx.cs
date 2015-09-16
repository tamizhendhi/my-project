using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class useraspx_CabProfileUpdate : System.Web.UI.Page
{
    string empid,actype;
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["Empid"] != null)
        {
            empid = Session["Empid"].ToString();
            actype = Session["Account"].ToString();
        }
        if (actype != "User")
        {
            this.MasterPageFile = "../master/CabAdminMaster.master";
        }
    }
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
        try
        {
            SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("UPDATE cabprofile SET name=@name,address=@add,position=@pos,technology=@tech,pmanager=@pm,phone=@ph WHERE empid=@eid;", con);



                com.Parameters.AddWithValue("@name", txtName.Text);
                com.Parameters.AddWithValue("@add", txtAdd.Text);

                com.Parameters.AddWithValue("@pos", DrpPos.SelectedValue);
                com.Parameters.AddWithValue("@tech", DrpTec.SelectedValue);

                com.Parameters.AddWithValue("@pm", DrpPM.SelectedValue);
                com.Parameters.AddWithValue("@ph", txtPhone.Text);
                com.Parameters.AddWithValue("@eid", empid);

               
                com.ExecuteNonQuery();
                
                Messagebox("Updation Successfull!!!");
                Response.Redirect("CabUser.aspx");
            }
            catch
            {
                Messagebox("Updation failed!!!");
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
        txtName.Text = String.Empty;       
        txtAdd.Text = String.Empty;
        txtPhone.Text = String.Empty;       
        DrpPM.SelectedIndex = 0;
        DrpPos.SelectedIndex = 0;
        DrpTec.SelectedIndex = 0;
    }  
}