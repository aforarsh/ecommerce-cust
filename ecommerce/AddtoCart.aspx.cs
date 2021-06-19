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
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("login.aspx");
                }

                //Adding product to Gridview
                Session["addproduct"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pdesc");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pqty");
                dt.Columns.Add("ptprice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        

                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_product WHERE Product_ID=" + Request.QueryString["id"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Product_Img"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Product_Desc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Product_Price"].ToString();
                        dr["pqty"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Product_Price"].ToString());
                        int qty = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * qty;
                        dr["ptprice"] = TotalPrice;

                        dt.Rows.Add(dr);

                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tb_cart (sno, Product_ID, Product_Name, Product_img, Product_Desc, Product_Price, Product_Qty, Email_ID)  VALUES('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pimage"] + "','" + dr["pdesc"] + "','" + dr["pprice"] + "','" + dr["pqty"] + "','"
                            + Session["username"].ToString() + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");

                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tb_product WHERE Product_ID=" + Request.QueryString["id"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["Product_ID"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Product_Img"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Product_Desc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Product_Price"].ToString();
                        dr["pqty"] = Request.QueryString["quantity"];

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Product_Price"].ToString());
                        int qty = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * qty;
                        dr["ptprice"] = TotalPrice;

                        dt.Rows.Add(dr);

                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tb_cart (sno, Product_ID, Product_Name, Product_img, Product_Desc, Product_Price, Product_Qty, Email_ID) VALUES('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pimage"] + "','"+ dr["pdesc"] + "','" + dr["pprice"] + "','" + dr["pqty"] + "','" 
                            + Session["username"].ToString() + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["Buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
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
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                    }
                }
            }

            if (GridView1.Rows.Count.ToString() == "0")
            {
                LinkButton1.Enabled = false;
                LinkButton1.ForeColor = System.Drawing.Color.White;
                Button1.Enabled = false;
                Button1.Text = "Oops";
            }
            else
            {
                LinkButton1.Enabled = true;
                Button1.Enabled = true;
            }
            String OrderDate = DateTime.Now.ToShortDateString();
            Session["Orderdate"] = OrderDate;
            orderid();
        }

        public void orderid()
        {
            String alpha = "abCdefghIjklmNopqrStuvwXyz1234567890";
            Random r = new Random();
            char[] myArray = new char[5];
            for (int i = 0; i < 5; i++)
            {
                myArray[i] = alpha[(int)(35 * r.NextDouble())];
            }
            String orderid;
            orderid = "Order_ID: " + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + new string(myArray) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            Session["Orderid"] = orderid;
        }

        //Final total price
        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice = 0;
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["ptprice"].ToString());
                i = i + 1;
            }

            return totalprice;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);
                TableCell prID = GridView1.Rows[e.RowIndex].Cells[1];

                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE top (1) FROM tb_cart WHERE Product_ID = '" + prID.Text + "' AND CONVERT(VARCHAR,Email_ID)='" + Session["username"] + "' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    // Item is deleted from shopping cart
                    break;
                }
            }

            //Setting no after deleting a row
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();
            }

            Session["buyitems"] = dt;
            Response.Redirect("AddtoCart.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                SqlConnection scon = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
                scon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tb_Order(Order_ID,sno,Product_ID,Product_Name,Product_Price,Product_Qty,Order_Date) VALUES('" + Session["Orderid"] + "','"
                    + dt.Rows[i]["sno"] + "','" + dt.Rows[i]["pid"] + "','" + dt.Rows[i]["pname"] + "','" + dt.Rows[i]["pprice"] + "','" + dt.Rows[i]["pqty"] + "','" + Session["Orderdate"] + "')", scon);

                cmd.ExecuteNonQuery();
                scon.Close();
            }

            //if session is null
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (GridView1.Rows.Count.ToString() == "0")
                {
                    Response.Write("<script>alert('Your cart is empty');</script>");
                }
                else
                {
                    Response.Redirect("PlaceOrder.aspx?id" + Session["Orderid"]);
                }
            }

        }

        public void clearCart()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tb_cart WHERE CONVERT(VARCHAR,Email_ID)='" + Session["username"] + "' ", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("AddtoCart.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["buyitems"] = null;
            clearCart();
        }
    }
}