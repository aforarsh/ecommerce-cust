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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LTLQC7F\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tb_registration"+ "(First_Name,Last_Name,Email_ID,Gender,Address,Phone_No,Password) VALUES (@First_Name,@Last_Name,@Email_ID,@Gender,@Address,@Phone_No,@Password)",con);
            cmd.Parameters.AddWithValue("@First_Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Last_Name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Email_ID", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Address", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Phone_No", TextBox6.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Registered Successfully";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}