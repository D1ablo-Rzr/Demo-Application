using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using DAL;
using System.Data.SqlClient;

namespace WebServiceApplication
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        CustomerDal Cust_Obj = new CustomerDal();
        OrderDal Order_Obj = new OrderDal();
        ProductDal Product_Obj = new ProductDal();

        [WebMethod]
        public bool Add(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Cust_Obj.AddCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool Edit(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Cust_Obj.EditCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool Delete(string ID)
        {
            if (Cust_Obj.DeleteCust(ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public void CustomerData(List<Customer> cust)
        {
            cust = Cust_Obj.GetCustomer();
        }
        [WebMethod]
        public List<OrderDetails> OrdersData(List<Customer> Customer1, int i)
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders = Order_Obj.DisplayOrder(Customer1[i].GetId());
            return orders;
        }

        [WebMethod]

        public bool PlaceOrder(string CustomerID, int EmployeeID, string ProductName, int Quantity)
        {
            if (Order_Obj.PlaceOrder(CustomerID, EmployeeID, ProductName, Quantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public SqlDataReader AddProducts()
        {
            SqlDataReader reader = Product_Obj.AddProducts();
            return reader;
        }

        [WebMethod]
        public SqlDataReader AddEmployees()
        {
            SqlDataReader reader = Product_Obj.AddEmployees();
            return reader;
        }
    }
}
