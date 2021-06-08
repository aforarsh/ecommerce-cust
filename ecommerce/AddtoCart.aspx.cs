using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce
{
    public partial class AddtoCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["buyitems"] == null)
                {
                    Button1.Enabled = false;
                }
                else
                {
                    Button1.Enabled = true;
                }

                //Adding product to Gridview
                Session["addproduct"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pqty");
                dt.Columns.Add("ptprice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["Buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-20VP0PUP/SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");

                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_product WHERE Product_ID=" + Request.QueryString["id"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Product_Img"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Product_Price"].ToString();
                        dr["pqty"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int qty = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * qty;
                        dr["ptprice"] = TotalPrice;

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-20VP0PUP/SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");

                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_product WHERE Product_ID=" + Request.QueryString["id"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Product_Img"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Product_Price"].ToString();
                        dr["pqty"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int qty = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * qty;
                        dr["ptprice"] = TotalPrice;

                        dt.Rows.Add(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    }
                }
            }

            string OrderDate = DateTime.Now.ToShortDateString();
            Session["orderdate"] = OrderDate;
            orderid();
        }

        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["pprice"].ToString());
                i = i + 1;
            }

            return totalprice;
        }
    }
}