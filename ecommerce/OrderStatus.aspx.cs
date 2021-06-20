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
    public partial class OrderStatus : System.Web.UI.Page
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
                //Label1.Visible = false;
                //Label2.Visible = false;
                //DropDownList1.Visible = false;
                //DropDownList2.Visible = false;
                Calendar1.Visible = false;
                Button2.Visible = false;

                DataSet year = new DataSet();
                year.ReadXml(Server.MapPath("~/Year.xml"));
                //DropDownList1.DataTextField = "Number";
                //DropDownList1.DataValueField = "Number";
                //DropDownList1.DataSource = year;
                //DropDownList1.DataBind();

                DataSet month = new DataSet();
                year.ReadXml(Server.MapPath("~/Month.xml"));
                //DropDownList2.DataTextField = "Number";
                //DropDownList2.DataValueField = "Number";
                //DropDownList2.DataSource = year;
                //DropDownList2.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                //TextBox1.Visible = false;
                //Label1.Visible = false;
                //Label2.Visible = false;
                //DropDownList1.Visible = false;
                //DropDownList2.Visible = false;
                Calendar1.Visible = false;
            }
            else
            {
                TextBox1.Visible = true;
                //Label1.Visible = true;
                //Label2.Visible = true;
                //DropDownList1.Visible = true;
                //DropDownList2.Visible = true;
                Calendar1.Visible = true;
            }
            Button2.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();

            //Label1.Visible = false;
            //Label2.Visible = false;
            //DropDownList1.Visible = false;
            //DropDownList2.Visible = false;
            Calendar1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script>alert('Please Select Date')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Order_ID AS Order_ID, Product_Name AS Product_Name, Product_Price AS Product_Price, Product_Qty AS Product_Qty, Order_Date AS Order_Date FROM tb_Order WHERE Order_Date='" +TextBox1.Text + "' AND Order_Status!='Completed'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "tb_Order");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script>alert('No Record To Display')</script>");
                }
                else
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.Columns[0].Visible = true;
                    Button2.Visible = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                string Order_ID = row.Cells[1].Text;
                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb3 = (row.Cells[0].FindControl("RadioButton3") as RadioButton);
                RadioButton rb4 = (row.Cells[0].FindControl("RadioButton4") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton2") as RadioButton);

                string Order_Status;
                if (rb1.Checked)
                {
                    Order_Status = rb1.Text;
                }
                else if (rb3.Checked)
                {
                    Order_Status = rb3.Text;
                }
                else if (rb4.Checked)
                {
                    Order_Status = rb4.Text;
                }
                else
                {
                    Order_Status = rb2.Text;
                }

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tb_Order SET Order_Status=@a WHERE Order_ID=@b", con);
                cmd.Parameters.AddWithValue("@a", Order_Status);
                cmd.Parameters.AddWithValue("@b", Order_ID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Write("<script>alert('Status Updated Successfully.')</script>");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void AllOrder_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Order_ID AS Order_ID, Product_Name AS Product_Name, Product_Price AS Product_Price, Product_Qty AS Product_Qty, Order_Date AS Order_Date, Order_Status AS Status FROM tb_Order", con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tb_Order");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
            Button2.Visible = false;
        }
    }
}