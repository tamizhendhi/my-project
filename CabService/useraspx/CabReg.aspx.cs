using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class useraspx_CabReg : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
         
    protected void Page_Load(object sender, EventArgs e)
    {
        DrpPM.Items.Insert(0, new ListItem("--select--", "0"));


    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
              con.Open();
            try
            {
                SqlCommand com = new SqlCommand("insert into cabprofile values(@id,@name,@add,@pos,@tech,@pm,@user,@pswd,@actype,@phone)", con);

                com.Parameters.AddWithValue("@id", "EMP-" + txtEmpid.Text);

                com.Parameters.AddWithValue("@name", txtName.Text);
                com.Parameters.AddWithValue("@add", txtAdd.Text);

                com.Parameters.AddWithValue("@pos", DrpPos.SelectedValue);
                com.Parameters.AddWithValue("@tech", DrpTec.SelectedValue);

                com.Parameters.AddWithValue("@pm", DrpPM.SelectedValue);
                com.Parameters.AddWithValue("@user", txtUser.Text);

                com.Parameters.AddWithValue("@pswd", txtPswd.Text);

                com.Parameters.AddWithValue("@actype", "User");
                com.Parameters.AddWithValue("@phone", txtPhone.Text);
                com.ExecuteNonQuery();
                Session["Empid"] = "EMP-" + txtEmpid.Text;
                Session["Name"] = txtName.Text;
                
                Session["Position"] = DrpPos.SelectedValue;
                Messagebox("Registration Successfull!!!");
                Response.Redirect("CabHome.aspx");
            }
            catch (Exception ex)
            { 
                 Messagebox("Username/EmployeeID already Exist"); 
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
        txtEmpid.Text = String.Empty;
        txtAdd.Text = String.Empty;
        txtPhone.Text = String.Empty;
        txtUser.Text = String.Empty;
        txtPswd.Text = String.Empty;
        txtCpswd.Text = String.Empty;
        DrpPM.SelectedIndex = 0;
        DrpPos.SelectedIndex = 0;
        DrpTec.SelectedIndex = 0;
    }
    protected void DrpTec_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        DrpPM.Items.Clear();
        DrpPM.Items.Insert(0, new ListItem("--select--", "0"));

        SqlCommand com = new SqlCommand("select distinct empid,name from cabprofile where technology='"+DrpTec.SelectedValue+"' and accounttype='Project Manager'", con);
   
        SqlDataReader r = com.ExecuteReader();
        while (r.Read())
        {
            string ss = r[1].ToString();
            DrpPM.Items.Add(ss);
        }
        r.Close();

        con.Close();
    }
}