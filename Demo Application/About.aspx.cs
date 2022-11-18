using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< Updated upstream:Demo Application/About.aspx.cs
using Demo_Application.DAL;
=======
using Models;
using DAL;
using System.Data.SqlClient;
>>>>>>> Stashed changes:Demo Application/OrderPlacement.aspx.cs

namespace Demo_Application
{
    public partial class About : Page
    {
<<<<<<< Updated upstream:Demo Application/About.aspx.cs
        DALLayer obj = new DALLayer();
=======
        List<ServiceReference1.Employees> EmployeeLs = new List<ServiceReference1.Employees>();
        ServiceReference1.Employees[] Arr;
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
>>>>>>> Stashed changes:Demo Application/OrderPlacement.aspx.cs
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["CX_ID"] != "")
                {
                    string cx_id = Request.QueryString["CX_ID"];
                    TextBox2.Text = cx_id;
                    ProductList();
                    EmployeeList();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProductName = Convert.ToString(DropDownList1.SelectedItem.Text);
            int EmployeeID = Convert.ToInt32(DropDownList2.SelectedItem.Text);
            int Quantity = Convert.ToInt32(TextBox1.Text);
            string CustomerID = TextBox2.Text;
            if (client.PlaceOrder(CustomerID,EmployeeID,ProductName,Quantity))
            {
                Response.Write("<script>alert('Order Placed !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error Occured !!')</script>");
            }
        }

        protected void ProductList()
        {
           /*List<ServiceReference1.Products> ProductList = new List<ServiceReference1.Products>();
            ProductList = client.AddProducts();
            DropDownList1.DataSource = ProductList;
            DropDownList1.DataTextField = "ProductName";
            DropDownList1.DataValueField = "ProductID";
            DropDownList1.DataBind();*/
        }

        protected void EmployeeList()
        {
            
            Arr = client.AddEmployees();
            EmployeeLs = Arr.ToList();
            DropDownList2.DataSource = EmployeeLs;
            DropDownList2.DataTextField = "EmployeeID";
            DropDownList2.DataValueField = "EmployeeID";
            DropDownList2.DataBind();

        }
    }
}