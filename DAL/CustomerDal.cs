using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Models;

namespace DAL
{
    public class CustomerDal
    {
        OrderDal Orders = new OrderDal();
        SqlConnection con = new SqlConnection(@"Data Source=SAL-BHATTI\SQLEXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=4Islamabad");
        public bool AddCustomer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address) values (@ID, @CompName, @CustName, @CustTitle, @Address)", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("compname", CompName);
            cmd.Parameters.AddWithValue("CustName", CustName);
            cmd.Parameters.AddWithValue("@CustTitle", CustTitle);
            cmd.Parameters.AddWithValue("@Address", Address);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool EditCustomer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Customers set CompanyName=@compname, ContactName=@CustName, ContactTitle=@CustTitle, Address=@Address where CustomerID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("compname", CompName);
            cmd.Parameters.AddWithValue("CustName", CustName);
            cmd.Parameters.AddWithValue("@CustTitle", CustTitle);
            cmd.Parameters.AddWithValue("@Address", Address);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }



        public bool DeleteCust(string ID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Customers where CustomerID=@id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            try
            {
                Orders.DeleteOrderDetails(ID);
                Orders.DeleteOrder(ID);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Customer NextCustomer(string ID)
        {
            con.Open();
            var Customer_next = new Customer();
            SqlCommand cmd = new SqlCommand("select CustomerID, CompanyName, ContactName, ContactTitle, Address from Customers where CustomerID>@ID ORDER BY LIMIT 1", con);
            cmd.Parameters.AddWithValue("id", ID);
            SqlDataReader rd = cmd.ExecuteReader();
            Customer_next.SetId(rd.GetString(rd.GetOrdinal("CustomerID")));
            Customer_next.SetCompName(rd.GetString(rd.GetOrdinal("CompanyName")));
            Customer_next.SetCustName(rd.GetString(rd.GetOrdinal("ContactName")));
            Customer_next.SetTitle(rd.GetString(rd.GetOrdinal("ContactTitle")));
            Customer_next.SetAddress(rd.GetString(rd.GetOrdinal("Address")));

            return Customer_next;
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> List_customer = new List<Customer>();

            con.Open();
            SqlCommand cmd = new SqlCommand("select CustomerID, CompanyName, ContactName, ContactTitle, Address from Customers", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Customer Temp = new Customer();
                Temp.SetId(rd.GetString(rd.GetOrdinal("CustomerID")));
                Temp.SetCompName(rd.GetString(rd.GetOrdinal("CompanyName")));
                Temp.SetCustName(rd.GetString(rd.GetOrdinal("ContactName")));
                Temp.SetTitle(rd.GetString(rd.GetOrdinal("ContactTitle")));
                Temp.SetAddress(rd.GetString(rd.GetOrdinal("Address")));
                List_customer.Add(Temp);
            }
            con.Close();
            rd.Close();
            return List_customer;
        }

        
    }
}