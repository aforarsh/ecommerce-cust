using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class PaymentAdmin : System.Web.UI.Page
    {
        string str = "Data Source=DESKTOP-GNG1HEH\\SQLEXPRESS;Initial Catalog=ecommerce; Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["admin"] == null)
                //{
                //   Response.Redirect("Login.aspx");
                //}
                TextBox1.Visible = false;
                Calendar1.Visible = false;
                Button2.Visible = false;

                DataSet year = new DataSet();

                DataSet month = new DataSet();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script>alert('Please Select Data')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Payment_ID AS Payment_ID, Order_ID AS Order_ID, Total_Price AS Total_Price, receipt AS receipt, Tracking_No AS Tracking_No FROM tb_payment WHERE Payment_Date='" + TextBox1.Text + "' AND Order_Status='Pending'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tb_payment");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script>alert('No Record To Display')</script>");
                }
                else
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.Columns[0].Visible = true;
                    //GridView1.Columns[2].Visible = true;
                    Button2.Visible = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                string Payment_ID = row.Cells[1].Text;
                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton2") as RadioButton);

                string Order_Status;
                if (rb1.Checked)
                {
                    Order_Status = rb1.Text;
                }
                else
                {
                    Order_Status = rb2.Text;
                }

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tb_payment SET Order_Status=@a WHERE Payment_ID=@b", con);
                cmd.Parameters.AddWithValue("@a", Order_Status);
                cmd.Parameters.AddWithValue("@b", Payment_ID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Write("<script>alert('Status Updated Successfully.')</script>");
        }

        protected void AllPayment_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Payment_ID AS Payment_ID, Order_ID AS Order_ID, Total_Price AS Total_Price, receipt AS receipt, Payment_Date AS Payment_Date, Order_Status AS Order_Status, Tracking_No AS Tracking_No FROM tb_payment", con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tb_payment");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
            //GridView1.Columns[2].Visible = false;
            Button2.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                //TextBox1.Visible = false;
                Calendar1.Visible = false;
            }
            else
            {
                TextBox1.Visible = true;
                Calendar1.Visible = true;
            }
            Button2.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();

            Calendar1.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM tb_payment WHERE Payment_ID= '" + int.Parse(TextBox2.Text) + "'", con);
            SqlDataReader r = comm.ExecuteReader();
            while(r.Read())
            {
                TextBox2.Text = r.GetValue(0).ToString();
                TextBox3.Text = r.GetValue(4).ToString();
            }
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE tb_payment SET Tracking_No = '" + int.Parse(TextBox3.Text) + "' WHERE Payment_ID= '" + int.Parse(TextBox2.Text) + "'", con);
            comm.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Tracking No Added Successfully.')</script>");
        }
    }
}