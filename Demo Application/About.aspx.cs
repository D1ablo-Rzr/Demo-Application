using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo_Application.DAL;

namespace Demo_Application
{
    public partial class About : Page
    {
        DALLayer obj = new DALLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["CX_ID"] != "")
                {
                    string cx_id = Request.QueryString["CX_ID"];
                    TextBox2.Text = cx_id;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProductName = Convert.ToString(DropDownList1.SelectedItem.Value);
            
            int Emp_ID = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Quantity = Convert.ToInt32(TextBox1.Text);
            string CX_ID = TextBox2.Text;
            if (obj.Place_order(CX_ID,Emp_ID,ProductName,Quantity))
            {
                Response.Write("<script>alert('Order Placed !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }
    }
}