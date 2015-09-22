using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminaspx_CabVoucher : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubjectData();

        }

    }
    protected void BindSubjectData()
    {
        GridView1.Visible = true;
        btnAcceptall.Visible = true;
        btnRejectall.Visible = true;
        string pm = "";
        if (Session["Name"] != null)
        {
            pm = Session["Name"].ToString();
        }


        DateTime date = DateTime.Now;
        date = date.Subtract(TimeSpan.FromDays(3));


        con.Open();
        SqlCommand com4 = new SqlCommand("select * from voucher where (status='Requested' and pmanager='" + pm + "')and  bookingdate >='" + date + "'", con);

        SqlDataAdapter da = new SqlDataAdapter(com4);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            btnAcceptall.Visible = false;
            btnRejectall.Visible = false;
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You have processed all your requests...')</script>");

        }
        con.Close();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[index];


        if (e.CommandName == "Accept")
        {
            con.Open();
            string id = (GridView1.Rows[index].Cells[0].Text);
            SqlCommand com4 = new SqlCommand("UPDATE voucher SET status='Verified' WHERE empid=@empid and status='Requested'", con);
            com4.Parameters.AddWithValue("@empid", id);
            com4.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            BindSubjectData();
        }
        else if (e.CommandName == "Reject")
        {

            con.Open();
            string id = (GridView1.Rows[index].Cells[0].Text);
            SqlCommand com4 = new SqlCommand("UPDATE voucher SET status='Rejected' WHERE empid=@empid and status='Requested'", con);
            com4.Parameters.AddWithValue("@empid", id);
            com4.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            BindSubjectData();


        }
    }
    protected void btnAcceptall_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("UPDATE voucher SET status='Verified' WHERE status='Requested'", con);
        com4.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        BindSubjectData();
        con.Close();
        GridView1.Visible = false;
        btnAcceptall.Visible = false;
        btnRejectall.Visible = false;


    }
    protected void btnRejectall_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("UPDATE voucher SET status='Rejected' WHERE status='Requested'", con);
        com4.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        BindSubjectData();
        con.Close();
        GridView1.Visible = false;
        btnAcceptall.Visible = false;
        btnRejectall.Visible = false;

    }
}