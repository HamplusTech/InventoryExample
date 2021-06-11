using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ProductCode", typeof(int)), new DataColumn("NameDescription", typeof(string)), new DataColumn("UnitPrice", typeof(double)), new DataColumn("Quantity", typeof(int)), new DataColumn("Price", typeof(double)), new DataColumn("Discount", typeof(double)), new DataColumn("Total", typeof(double)) });
            ViewState["SO"] = dt;
            this.BindGrid();
        }
    }
    protected void BindGrid()
    {
        xSale.DataSource = (DataTable)ViewState["SO"];
        xSale.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["SO"];
        dt.Rows.Add(txtCode.Text.Trim(), txtpname.Text.Trim(), txtunitprice.Text.Trim(), txtqty.Text.Trim(), txtprice.Text.Trim(), txtdiscount.Text.Trim(), txttotal.Text.Trim());
        ViewState["SO"] = dt;
        this.BindGrid();

        
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ProductCode", typeof(int)), new DataColumn("NameDescription", typeof(string)), new DataColumn("UnitPrice", typeof(double)), new DataColumn("Quantity", typeof(int)), new DataColumn("Price", typeof(double)), new DataColumn("Discount", typeof(double)), new DataColumn("Total", typeof(double)) });
        foreach (GridViewRow row in xSale.Rows)
        {
            int sValue1 = int.Parse(xSale.SelectedRow.Cells[1].Text);
            string sValue2 = xSale.SelectedRow.Cells[2].Text;
            double sValue3 = double.Parse(xSale.SelectedRow.Cells[3].Text);
            int sValue4 = int.Parse(xSale.SelectedRow.Cells[4].Text);
            double sValue5 = int.Parse(xSale.SelectedRow.Cells[5].Text);
            double sValue6 = int.Parse(xSale.SelectedRow.Cells[6].Text);
            double sValue7 = int.Parse(xSale.SelectedRow.Cells[7].Text);
        }

        if (dt.Rows.Count > 0)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Alhamd;Integrated Security=True"))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.SaleOrder";

                    //[OPTIONAL]: Map the DataTable columns with that of the database table
                    sqlBulkCopy.ColumnMappings.Add("sValue1", "ProductCode");
                    sqlBulkCopy.ColumnMappings.Add("sValue2", "NameDescription");
                    sqlBulkCopy.ColumnMappings.Add("sValue3", "UnitPrice");
                    sqlBulkCopy.ColumnMappings.Add("sValue4", "Quantity");
                    sqlBulkCopy.ColumnMappings.Add("sValue5", "Price");
                    sqlBulkCopy.ColumnMappings.Add("sValue6", "Discount");
                    sqlBulkCopy.ColumnMappings.Add("sValue7", "Total");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
        }
    }
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Alhamd;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        string sql_query;

        try
        {

            sql_query = "select ProductID, ProductName, UnitPrice from Products where ProductID='" + txtCode.Text.Trim() + "'";
            da = new SqlDataAdapter(sql_query, con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCode.Text = ds.Tables[0].Rows[0]["ProductID"].ToString();
                txtpname.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                txtunitprice.Text = ds.Tables[0].Rows[0]["UnitPrice"].ToString();


            }
        }
        catch
        {
            con.Close();
        }
    }
}
