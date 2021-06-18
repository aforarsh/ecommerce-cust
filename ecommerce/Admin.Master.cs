using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load2(object sender, EventArgs e)
        {

        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProduct.aspx");
        }

        protected void OrderStatus_Click(object sender, EventArgs e)
        {

            Response.Redirect("OrderStatus.aspx");
        }
    }
}