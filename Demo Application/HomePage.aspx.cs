using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Models;

namespace Demo_Application
{
    public partial class HomePage : Page
    {
        DAL_Customer Cust_Obj = new DAL_Customer();
        DAL_Orders Order_Obj = new DAL_Orders();
        List<Customer> cust = new List<Customer>();
        List<OrderDetails> orders = new List<OrderDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            cust = Cust_Obj.get_customer();
            if (!this.IsPostBack)
            {
                HiddenField.Value = "0";
                showdata(0);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TEXT_ID.Text = string.Empty;
            TEXT_ID.DataBind();
            TEXT_NAME.Text = string.Empty;
            TEXT_NAME.DataBind();
            TEXT_NAME_2.Text = string.Empty;
            TEXT_NAME_2.DataBind();
            TEXT_TITLE.Text = string.Empty;
            TEXT_TITLE.DataBind();
            TEXT_ADDRESS.Text = string.Empty;
            TEXT_ADDRESS.DataBind();
            Button10.Visible = true;
            GridView1.Visible=false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            if (Cust_Obj.EditCustomer(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Updated !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            if (Cust_Obj.DeleteCust(TEXT_ID.Text))
            {
                Response.Write("<script>alert('Data Deleted !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var CXID = TEXT_ID.Text.Trim();
            Response.Redirect("About.aspx?CX_ID="+CXID);
        }


        protected void showdata(int i)
        {
            TEXT_ID.Text = cust[i].GetId();
            TEXT_NAME.Text = cust[i].GetCompName();
            TEXT_NAME_2.Text = cust[i].GetCustName();
            TEXT_TITLE.Text = cust[i].GetTitle();
            TEXT_ADDRESS.Text = cust[i].GetAddress();

            orders = Order_Obj.DisplayOrder(cust[i].GetId());
            if (orders.Count != 0)
            {
                TextBox1.Text = "Displaying Orders";
                showorders();
            }
            else
            {
                GridView1.Visible = false;
                TextBox1.Text="No Orders Exist";
            }
        }

        protected void showorders()
        {
            GridView1.Visible = true;
            GridView1.DataSource = orders;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            HiddenField.Value = "0";
            int i = Convert.ToInt32(HiddenField.Value);
            showdata(i);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            int i = cust.Count() - 1;
            HiddenField.Value = Convert.ToString(i);
            showdata(i);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            int i = Convert.ToInt32(HiddenField.Value.TrimStart());
            i++;
            if (i < cust.Count)
            {
                showdata(i);
            }
            else
            {
                i = 0;
                showdata(i);
            }
            HiddenField.Value = Convert.ToString(i);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Button10.Visible = false;
            int i = Convert.ToInt32(HiddenField.Value.TrimStart());
            i--;
            if (i > -1)
            {
                showdata(i);
            }
            else
            {
                i=cust.Count-1;
                showdata(i);
            }
            HiddenField.Value = Convert.ToString(i);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (Cust_Obj.AddCustomer(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Inserted !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }
    }
}