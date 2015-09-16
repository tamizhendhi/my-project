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


    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime date = DateTime.Now;
        date = date.Subtract(TimeSpan.FromDays(7));
        con.Open();
        SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status from booking where bookingdate >='" + date + "' ", con);

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
        con.Open();
        SqlCommand com4 = new SqlCommand("select empid,source,destination,shift,cabname,startdate,enddate,bookingdate,status from booking where  bookingdate >='" + txtDetailstdate.Text + "' and bookingdate <='" + txtDetailenddate.Text + "' ", con);

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



    protected void btnExcel_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("select * from booking where  bookingdate >='" + txtDetailstdate.Text + "' and bookingdate <='" + txtDetailenddate.Text + "' ", con);

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
    
}