using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class useraspx_CabPassword : System.Web.UI.Page
{
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
    protected void btnRemember_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;Integrated Security=True");
        con.Open();
        SqlCommand command = new SqlCommand("select password from cabprofile where username='" +txtRemember.Text + "'", con);

        SqlDataReader sdr = command.ExecuteReader();
        if (sdr.Read())
        {
            string pswd = sdr[0].ToString();
            Sendemail(pswd);
        }
        else
        {
            Messagebox("Invalid Username!!!");
        }

    }
    public void Sendemail( string pswd)
    {
        string ActivationUrl;
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ananth.ameex@gmail.com", "ANANTH");
            message.To.Add(txtRemember.Text);
            message.Subject = "Remember Password Email";
            ActivationUrl = Server.HtmlEncode("http://localhost:51998/useraspx/CabHome.aspx");
            message.Body = "Your password:"+ pswd+"<br/>" +"<a href='" + ActivationUrl + "'>Click Here to signin your account</a>";
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
}