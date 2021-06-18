using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        string str = "Data Source=DESKTOP-GNG1HEH\\SQLEXPRESS;Initial Catalog=ecommerce; Integrated Security=True;";
        //int ProductId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["admin"] == null)
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}
            ShowProduct();
        }

        public void ShowProduct()
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tb_product1", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowProduct();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowProduct();
            //int index = e.NewEditIndex;
            //GridViewRow row = (GridViewRow)GridView1.Rows[index];
            //Label Product_ID = (Label)row.FindControl("Label1");
            //ProductId = int.Parse(Product_ID.Text.ToString());
            //SqlConnection con = new SqlConnection(str);
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tb_product1 WHERE Product_ID='" + Product_ID.Text + "' ", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
 

            //    Label Product_ID = (Label)row.FindControl("Label1");
            //    TextBox Product_Name = (TextBox)row.FindControl("TextBox1");
            //    TextBox Product_Desc = (TextBox)row.FindControl("TextBox2");
            //    TextBox Product_Price = (TextBox)row.FindControl("TextBox3");
            //    TextBox Product_Qty = (TextBox)row.FindControl("TextBox4");
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            
                int Product_ID = GridView1.EditIndex;
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tb_product1 SET Product_Name=@1, Product_Desc=@2, Product_Price=@3, Product_Qty=@4 WHERE Product_ID=@5 ", con);
                cmd.Parameters.AddWithValue("@1", (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@2", (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@3", (GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@4", (GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@5", Product_ID);
                //cmd.Parameters.AddWithValue("@5", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                ShowProduct();
                Response.Write("<script>alert('Product Updated Successful');</script>");
                //DropDownList1.SelectedValue = "Select Category";  
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Category_Name = DropDownList1.SelectedValue.ToString();
            if (Category_Name == "SELECT tb_category")
            {
                ShowProduct();
            }
            else
            {
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tb_product1 WHERE Product_Category='" + Category_Name + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int Product_ID = GridView1.EditIndex;
            int Product_ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("DELETE FROM tb_product1 WHERE Product_ID=@1", con1);
            cmd1.Parameters.AddWithValue("@1", Product_ID);
            cmd1.ExecuteNonQuery();
            con1.Close();
            Response.Write("<script>alert('Product Deleted Successful');</script>");
            ShowProduct();
        }
    }
}