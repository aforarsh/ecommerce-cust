﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-20VP0PUP\SQLEXPRESS;Initial Catalog=ecommerce;Integrated Security=True;");
                if (FileUpload1.HasFile)
                {
                    string filename = FileUpload1.PostedFile.FileName;
                    string filepath = "receipts/" + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/receipts/") + filename);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tb_Order SET Payment_Prove=@file WHERE Order_ID=" + Request.QueryString["oid"], con);
                    cmd.Parameters.AddWithValue("@file", filepath);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}