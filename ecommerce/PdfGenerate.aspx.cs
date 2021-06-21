using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



namespace ecommerce
{
    public partial class PdfGenerate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Orderid = Session["Orderid"].ToString();
            Label1.Text = Orderid;
            findorderdate(Label2.Text);
            string Address = Session["address"].ToString();
            Label3.Text = Address;
            showgrid(Label1.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exportpdf();
        }

        private void exportpdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename-OrderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        private void findorderdate(String Orderid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LTLQC7F\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from tb_order where orderid= '" + Label1.Text + "'");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds.Tables[0].Rows[0]["Order_Date"].ToString();
            }
            con.Close();

        }


        private void showgrid(String orderid)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("Product_ID");
            dt.Columns.Add("Product_Name");
            dt.Columns.Add("Product_Qty");
            dt.Columns.Add("Product_Price");
            dt.Columns.Add("totalprice");
            dt.Columns.Add("trackingno");
            SqlConnection scon = new SqlConnection(@"Data Source=DESKTOP-LTLQC7F\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from tb_order where orderid= '" + Label1.Text + "'");
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;
            while (i < totalrows)
            {
                dr = dt.NewRow();
                dr["sno"] = ds.Tables[0].Rows[i]["sno"].ToString();
                dr["Product_ID"] = ds.Tables[0].Rows[i]["Product_ID"].ToString();
                dr["Product_Name"] = ds.Tables[0].Rows[i]["Product_Name"].ToString();
                dr["Product_Qty"] = ds.Tables[0].Rows[i]["Product_Qty"].ToString();
                dr["Product_Price"] = ds.Tables[0].Rows[i]["Product_Price"].ToString();
                int price = Convert.ToInt32(ds.Tables[0].Rows[i]["Product_Price"].ToString());
                int quantity = Convert.ToInt16(ds.Tables[0].Rows[i]["Product_Qty"].ToString());
                int totalprice = price * quantity;
                dr["totalprice"] = totalprice;
                grandtotal = grandtotal + totalprice;
                dr["trackingno"] = ds.Tables[0].Rows[i]["trackingno"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label4.Text = grandtotal.ToString();
        }
    }
}