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
            LinkButton1.Visible = true;
            HyperLink1.Visible = false;

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