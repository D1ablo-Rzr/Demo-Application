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
    public partial class _Default : Page
    {
        DALLayer obj = new DALLayer();
        List<Customer> cust = new List<Customer>();
        List<OrderDetails> orders = new List<OrderDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HiddenField.Value = "-1";
            }

            cust = obj.get_customer();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(obj.AddCustomer(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Inserted !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(obj.EditCustomer(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
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
            if(obj.DeleteCust(TEXT_ID.Text))
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
            string CXID = TEXT_ID.Text.Trim();
            Response.Redirect("About.aspx?CX_ID="+CXID);
        }


        protected void showdata(int i)
        {
            TEXT_ID.Text = cust[i].get_ID();
            TEXT_NAME.Text = cust[i].get_CompName();
            TEXT_NAME_2.Text = cust[i].get_CustName();
            TEXT_TITLE.Text = cust[i].get_title();
            TEXT_ADDRESS.Text = cust[i].get_Address();
        }

        protected void showorders()
        {
            GridView1.DataSource = orders;
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            HiddenField.Value = "0";
            int i = Convert.ToInt32(HiddenField.Value);
            orders = obj.DisplayOrder(cust[i].get_ID());
            showdata(i);
            showorders();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            int i = cust.Count() - 1;
            HiddenField.Value = Convert.ToString(i);
            orders = obj.DisplayOrder(cust[i].get_ID());
            showdata(i);
            showorders();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(HiddenField.Value.TrimStart());
            i++;
            if (i < cust.Count)
            {
                orders = obj.DisplayOrder(cust[i].get_ID());
                showdata(i);
                showorders();
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
                i--;
            }
            HiddenField.Value = Convert.ToString(i);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(HiddenField.Value.TrimStart());
            i--;
            if (i > -1)
            {
                orders = obj.DisplayOrder(cust[i].get_ID());
                showdata(i);
                showorders();
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
                i++;
            }
            HiddenField.Value = Convert.ToString(i);
        }
    }
}