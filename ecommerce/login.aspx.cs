using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ecommerce
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tb_registration WHERE CONVERT(VARCHAR,Email_ID)='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con);
            
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (TextBox1.Text == "Admin" & TextBox2.Text == "Admin")
            {
                Label1.Text = "Welcome back Admin";
                Label1.ForeColor = System.Drawing.Color.DarkGreen;
                LinkButton1.Visible = false;
                HyperLink1.Visible = true;
            }
            else if (dt.Rows.Count == 1)
            {
                Session["username"] = TextBox1.Text;
                Session["buyitems"] = null;
                fillSavedCart();
                Response.Redirect("Default.aspx");
                LinkButton1.Visible = true;
                HyperLink1.Visible = false;
                /*                Label1.Text = "Login Successful";
                                Label1.ForeColor = System.Drawing.Color.Green;*/
            }
            else
            {
                Label1.Text = "Incorrect email id or password.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void fillSavedCart()
        {
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

            String mycon = @"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True";
            SqlConnection scon = new SqlConnection(mycon);

            String myquery = "Select * FROM tb_cart WHERE CONVERT(VARCHAR,Email_ID)='" + Session["username"].ToString() + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                int counter = ds.Tables[0].Rows.Count;
                while (i < counter)
                {
                    dr = dt.NewRow();
                    dr["sno"] = i + 1;
                    dr["pid"] = ds.Tables[0].Rows[i]["Product_ID"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[i]["Product_Name"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[i]["Product_Img"];
                    dr["pdesc"] = ds.Tables[0].Rows[i]["Product_Desc"];
                    dr["pqty"] = ds.Tables[0].Rows[i]["Product_qty"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[i]["Product_Price"].ToString();
                    int price = Convert.ToInt32(ds.Tables[0].Rows[i]["Product_Price"].ToString());
                    int qty = Convert.ToInt16(ds.Tables[0].Rows[i]["Product_Qty"].ToString());
                    int total = price * qty;
                    dr["ptprice"] = total;
                    dt.Rows.Add(dr);
                    i = i + 1;
                }

            }
            else
            {
                Session["buyitems"] = null;
            }

           Session["buyitems"] = dt;
        }
    }

    internal class HyperLink1
    {
        public static bool Visible { get; internal set; }
    }

    internal class LinkButton1
    {
        public static bool Visible { get; internal set; }
    }
}