using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class EditProductDetail : System.Web.UI.Page
    {
        string str = "Data Source=DESKTOP-GNG1HEH\\SQLEXPRESS;Initial Catalog=ecommerce; Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["admin"] == null)
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE tb_product SET Product_Name = '" + txtName.Text + "', Product_Desc = '" + txtDesc.Text + "', Product_Price = '" + int.Parse(txtPrice.Text) + "', Product_qty = '" + int.Parse(txtQuantity.Text) + "' WHERE Product_ID= '" + int.Parse(TextBox1.Text) + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Product Detail Updated Successfully.')</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM tb_product WHERE Product_ID= '" + int.Parse(TextBox1.Text) + "'", con);
            SqlDataReader r = comm.ExecuteReader();
            while (r.Read())
            {
                TextBox1.Text = r.GetValue(0).ToString();
                txtName.Text = r.GetValue(1).ToString();
                txtDesc.Text = r.GetValue(3).ToString();
                txtPrice.Text = r.GetValue(2).ToString();
                txtQuantity.Text = r.GetValue(5).ToString();
            }
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comm = new SqlCommand("DELETE tb_product WHERE Product_ID= '" + int.Parse(TextBox1.Text) + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Product Successfully Deleted.')</script>");
        }
    }
}