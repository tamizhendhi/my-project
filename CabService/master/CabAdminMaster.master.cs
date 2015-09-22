using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CabAdminMaster : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
    string id;
    string atype;
    public string shift { get; set; }
    public string route { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        PMHome.Visible = false;
        AdminHome.Visible = false;
        HRHome.Visible = false;
        Voucherreport.Visible = false;
        Voucher.Visible = false;
        Cabreport.Visible = false;
        AddService.Visible = false;
        RemoveService.Visible = false;
        lblAddadmin.Visible = false;
       

        if (Session["Empid"] != null)
        {
            id = Session["Empid"].ToString();
            lblEmpid.Text = Session["Empid"].ToString();
            lblName.Text = Session["Name"].ToString();
            lblPosition.Text = Session["Position"].ToString();
            atype = Session["Account"].ToString();
        }
        if (atype == "Admin")
        {
            AdminHome.Visible = true;
            AddService.Visible = true;
            RemoveService.Visible = true;
            lblAddadmin.Visible = true;
        }
        else if (atype == "Project Manager")
        {
            PMHome.Visible = true;
            Voucher.Visible = true;
            Cabreport.Visible = true;
        }
        else if (atype == "Human Resource")
        {
            HRHome.Visible = true;
            Cabreport.Visible = true;
            Voucherreport.Visible = true;

        }
        con.Open();
        SqlCommand time = new SqlCommand("select distinct shift from settings", con);
        SqlCommand area = new SqlCommand("select distinct route from settings", con);
        SqlDataReader sdrtime = time.ExecuteReader();
       

        SqlDataReader sdrarea = area.ExecuteReader();
        while (sdrtime.Read())
        {
            if (sdrtime[0].ToString() != "12:30:00")
                shift += String.Format("{0:t tt}", sdrtime[0].ToString()) + "<br/>";


        }
        while (sdrarea.Read())
        {
            if (sdrarea[0].ToString() != "Removed")
                route += sdrarea[0].ToString() + "<br/>";

        }

        time.Dispose();
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
    public static string GetUniqueKey(int maxSize)
    {
        char[] chars = new char[62];
        chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW XYZ1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }

    protected void btnAddadmin_Click(object sender, EventArgs e)
    {
        if (txtAdminmail.Text != "Email-Id" && txtAdminmail.Text!="" && txtAdminid.Text!="")
        {
            try
            {
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand("insert into cabprofile values(@id,@name,@add,@pos,@tech,@pm,@user,@pswd,@actype,@ph)", con);

                    com.Parameters.AddWithValue("@id", "PM-" + txtAdminid.Text);

                    com.Parameters.AddWithValue("@name", "update");
                    com.Parameters.AddWithValue("@add", "update");

                    com.Parameters.AddWithValue("@pos", DrpActype.SelectedValue);
                    com.Parameters.AddWithValue("@tech", "update");

                    com.Parameters.AddWithValue("@pm", "update");
                    com.Parameters.AddWithValue("@user", txtAdminmail.Text);
                    string pswd = GetUniqueKey(5);
                    com.Parameters.AddWithValue("@pswd", pswd);

                    com.Parameters.AddWithValue("@actype",DrpActype.SelectedValue);
                    com.Parameters.AddWithValue("@ph", 9999999999);
                    com.ExecuteNonQuery();
                    Sendemail(pswd);
                    txtAdminid.Text = "EmpId";
                    txtAdminmail.Text ="Email-Id";
                    DrpActype.SelectedIndex = 0;
                    Messagebox(DrpActype.SelectedValue+"Added Successfully!!!");
                }
                catch
                {
                    Messagebox("EmployeeID already Exist");
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
            Messagebox("Please enter Email-Id or Emp-Id");
        }
   
    }
    public void Sendemail(string pswd)
    {
        string ActivationUrl;
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ananth.ameex@gmail.com", "ANANTH");
            message.To.Add(txtAdminmail.Text);
            message.Subject = "You are added into Ameex Cab Service";
            ActivationUrl = Server.HtmlEncode("http://localhost:51998/useraspx/CabHome.aspx");
            message.Body = "Your password:" + pswd + "<br/>" + "<a href='" + ActivationUrl + "'>Click Here to signin your account</a>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("ananth.ameex@gmail.com", "jeyalakshmi");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            Messagebox("Error in Communication!!!");
        }
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
            com4.Parameters.AddWithValue("@empid", id);
            com4.ExecuteNonQuery();
            con.Close();
            txtOldpassword.Text = "Old password";
            txtNewpassword.Text = "New password";
            txtConfirmpassword.Text = "Confirm password";
            Messagebox("Password changed successfully!!!");
        }
        else 
        {
            txtOldpassword.Text = "Old password";
            txtNewpassword.Text = "New password";
            txtConfirmpassword.Text = "Confirm password";
            Messagebox("Password Mismatch???");
        }
           
    
    }
}
