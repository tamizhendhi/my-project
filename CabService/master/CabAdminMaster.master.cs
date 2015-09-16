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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Empid"] != null)
        {
            lblEmpid.Text = Session["Empid"].ToString();
            lblName.Text = Session["Name"].ToString();
            lblPosition.Text = Session["Position"].ToString();
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
        if (txtAdminmail.Text != "Email-Id")
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
                con.Open();
                try
                {
                    SqlCommand com = new SqlCommand("insert into cabprofile values(@id,@name,@add,@pos,@tech,@pm,@user,@pswd,@actype)", con);

                    com.Parameters.AddWithValue("@id", "PM-" + txtAdminid.Text);

                    com.Parameters.AddWithValue("@name", "update");
                    com.Parameters.AddWithValue("@add", "update");

                    com.Parameters.AddWithValue("@pos", "Project Manager");
                    com.Parameters.AddWithValue("@tech", "update");

                    com.Parameters.AddWithValue("@pm", "update");
                    com.Parameters.AddWithValue("@user", txtAdminmail.Text);
                    string pswd = GetUniqueKey(5);
                    com.Parameters.AddWithValue("@pswd", pswd);

                    com.Parameters.AddWithValue("@actype", "PM/HR");
                    com.ExecuteNonQuery();
                    Sendemail(pswd);
                    Messagebox("Admin added Successfully!!!");
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
            Messagebox("Please enter Email-Id");
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
            message.Subject = "Remember Email";
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
        //Session.Remove("Empid");
        //Session.Remove("Name");
        //Session.Remove("Position");

        //Session.RemoveAll();
        Session.Abandon();
        Session.Contents.RemoveAll();
        FormsAuthentication.SignOut();
        Response.Redirect("../useraspx/CabHome.aspx");
    }
}
