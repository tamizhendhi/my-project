using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminaspx_CabReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMX-505-PC;Initial Catalog=CabService;MultipleActiveResultSets=true;Integrated Security=True");
    string atype = ""; string pm = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        btnExcel.Visible = true;
        
        if (Session["Account"] != null)
        {
            atype = Session["Account"].ToString();
            pm=Session["Name"].ToString();
        }
        DateTime date = DateTime.Now;
        date = date.Subtract(TimeSpan.FromDays(7));
        con.Open();
        SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status,canceleddate from booking where('" + atype + "'='Admin' or pmanager='" + pm + "' or '" + atype + "'='Human Resource')and bookingdate >='" + date + "' ", con);

        SqlDataAdapter da = new SqlDataAdapter(com4);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        con.Close();



    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        int row=0;
        if (txtDetailstdate.Text != "" && txtDetailenddate.Text != "")
        {
            con.Open();
            SqlCommand com = new SqlCommand("select count(*) from booking where('" + atype + "'='Admin' or pmanager='" + pm + "' or '" + atype + "'='Human Resource') and  startdate >='" + txtDetailstdate.Text + "' and enddate <='" + txtDetailenddate.Text + "' ", con);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                row = Int32.Parse(rd[0].ToString());
            }
            if (row != 0)
            {

                SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status from booking where('" + atype + "'='Admin' or pmanager='" + pm + "' or '" + atype + "'='Human Resource') and  startdate >='" + txtDetailstdate.Text + "' and enddate <='" + txtDetailenddate.Text + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter(com4);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                con.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('No records are found under this duration???')</script>");
                GridView1.Visible = false;
                btnExcel.Visible = false;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please select start and end date!!!')</script>");
           
        }
    }



    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (txtDetailstdate.Text != "" && txtDetailenddate.Text != "")
        {

            con.Open();
            SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status from booking where('" + atype + "'='Admin' or pmanager='" + pm + "' or '" + atype + "'='Human Resource') and  startdate >='" + txtDetailstdate.Text + "' and enddate <='" + txtDetailenddate.Text + "' ", con);

            SqlDataAdapter da = new SqlDataAdapter(com4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();




            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CabServiceReport.xls"));
            Response.ContentType = "application/ms-excel";

            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please select start and end date???')</script>");

        }
    }
}