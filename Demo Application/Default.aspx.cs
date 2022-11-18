using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Demo_Application.DAL;
using Demo_Application.Models;

namespace Demo_Application
{
    public partial class _Default : Page
    {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
        DALLayer obj = new DALLayer();
        List<Customer> cust = new List<Customer>();
        List<OrderDetails> orders = new List<OrderDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                HiddenField.Value = "-1";
=======
        
        List<ServiceReference1.Customer> CustomerList = new List<ServiceReference1.Customer>();
        ServiceReference1.Customer[] CustomerArray;
        List<ServiceReference1.OrderDetails> OrderList = new List<ServiceReference1.OrderDetails>();
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerArray = client.CustomerData();
            CustomerList = CustomerArray.ToList();
            if (!this.IsPostBack)
            {
                HiddenField.Value = "0";
                _ShowData(0);
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
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
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            if(obj.EditCustomer(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
=======
            Button10.Visible = false;
            if (client.Edit(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
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
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            if(obj.DeleteCust(TEXT_ID.Text))
=======
            Button10.Visible = false;
            if (client.Delete(TEXT_ID.Text))
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
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
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            string CXID = TEXT_ID.Text.Trim();
            Response.Redirect("About.aspx?CX_ID="+CXID);
=======
            var CX_ID = TEXT_ID.Text.Trim();
            Response.Redirect("OrderPlacement.aspx?CX_ID="+CX_ID);
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
        }


        protected void _ShowData(int iterator)
        {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            TEXT_ID.Text = cust[i].get_ID();
            TEXT_NAME.Text = cust[i].get_CompName();
            TEXT_NAME_2.Text = cust[i].get_CustName();
            TEXT_TITLE.Text = cust[i].get_title();
            TEXT_ADDRESS.Text = cust[i].get_Address();
=======
            TEXT_ID.Text = CustomerList[iterator].CustomerId;
            TEXT_NAME.Text = CustomerList[iterator].CompanyName;
            TEXT_NAME_2.Text = CustomerList[iterator].CustomerName;
            TEXT_TITLE.Text = CustomerList[iterator].CustomerTitle;
            TEXT_ADDRESS.Text = CustomerList[iterator].Address;

            //OrderList = client.OrdersData(CustomerList,iterator);
            /*if (OrderList.Count != 0)
            {
                TextBox1.Text = "Displaying Orders";
                _ShowOrders();
            }
            else
            {
                GridView1.Visible = false;
                TextBox1.Text="No Orders Exist";
            }*/
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
        }

        protected void _ShowOrders()
        {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            GridView1.DataSource = orders;
=======
            GridView1.Visible = true;
            GridView1.DataSource = OrderList;
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            HiddenField.Value = "0";
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            int i = Convert.ToInt32(HiddenField.Value);
            orders = obj.DisplayOrder(cust[i].get_ID());
            showdata(i);
            showorders();
=======
            int iterator = Convert.ToInt32(HiddenField.Value);
            _ShowData(iterator);
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            int i = cust.Count() - 1;
            HiddenField.Value = Convert.ToString(i);
            orders = obj.DisplayOrder(cust[i].get_ID());
            showdata(i);
            showorders();
=======
            Button10.Visible = false;
            int iterator = CustomerList.Count() - 1;
            HiddenField.Value = Convert.ToString(iterator);
            _ShowData(iterator);
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
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
=======
            Button10.Visible = false;
            int Iterator = Convert.ToInt32(HiddenField.Value.TrimStart());
            Iterator++;
            if (Iterator < CustomerList.Count)
            {
                _ShowData(Iterator);
            }
            else
            {
                Iterator = 0;
                _ShowData(Iterator);
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
            }
            HiddenField.Value = Convert.ToString(Iterator);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream:Demo Application/Default.aspx.cs
            int i = Convert.ToInt32(HiddenField.Value.TrimStart());
            i--;
            if (i > -1)
            {
                orders = obj.DisplayOrder(cust[i].get_ID());
                showdata(i);
                showorders();
=======
            Button10.Visible = false;
            int iterator = Convert.ToInt32(HiddenField.Value.TrimStart());
            iterator--;
            if (iterator > -1)
            {
                _ShowData(iterator);
            }
            else
            {
                iterator=CustomerList.Count-1;
                _ShowData(iterator);
            }
            HiddenField.Value = Convert.ToString(iterator);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {  
            if (client.Add(TEXT_ID.Text, TEXT_NAME.Text, TEXT_NAME_2.Text, TEXT_TITLE.Text, TEXT_ADDRESS.Text))
            {
                Response.Write("<script>alert('Data Inserted !!')</script>");
>>>>>>> Stashed changes:Demo Application/HomePage.aspx.cs
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