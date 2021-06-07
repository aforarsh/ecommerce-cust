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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tb_registration WHERE CONVERT(VARCHAR,Email_ID)='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Label1.Text = "Login Successful";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "Incorrect email id or password.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}