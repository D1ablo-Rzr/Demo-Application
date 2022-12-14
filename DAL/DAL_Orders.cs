using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class DAL_Orders
    {
        SqlConnection con = new SqlConnection(@"Data Source=SAL-BHATTI\SQLEXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=4Islamabad");
        public bool deleteOrder(string ID)
        {
            SqlCommand cmd1 = new SqlCommand("delete Orders where CustomerID=@id", con);
            cmd1.Parameters.AddWithValue("@id", ID);
            try
            {
                cmd1.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool deleteOrderDetails(string ID)
        {
            SqlCommand cmd = new SqlCommand("select OrderID from Orders where CustomerID=@id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            var Order_ID = cmd.ExecuteScalar();
            if (Order_ID == null)
            {
                return true;
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("delete [Order Details] where OrderID=@id", con);
                cmd1.Parameters.AddWithValue("@id", Order_ID);
                try
                {
                    cmd1.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<OrderDetails> DisplayOrder(string ID)
        {
            con.Open();
            var ls = new List<OrderDetails>();
            SqlCommand cmd = new SqlCommand("select OrderID, EmployeeID, OrderDate from Orders where CustomerID = @id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                int ordid = rd.GetOrdinal("OrderID");
                int empid = rd.GetOrdinal("EmployeeID");
                int orddate = rd.GetOrdinal("OrderDate");
                while (rd.Read())
                {
                    var order = new OrderDetails();
                    try
                    {
                        order.SetOrderId(rd.GetInt32(ordid));
                        order.SetEmpId(rd.GetInt32(empid));
                        order.SetDate(rd.GetDateTime(orddate));
                    }
                    catch
                    {
                        order.SetOrderId(rd.GetInt32(ordid));
                        order.SetEmpId(null);
                        order.SetDate(rd.GetDateTime(orddate));
                    }
                    ls.Add(order);
                }
                rd.Close();
            }
            con.Close();
            return ls;
        }

        public bool Order_details(int OrderID, int ProdID, decimal Unit_Price, int Quantity)
        {
            SqlCommand ord_det = new SqlCommand("insert into [Order Details](OrderID, ProductID, UnitPrice, Quantity) values(@orderid, @prod_id, @unitprice, @quantity)", con);
            ord_det.Parameters.AddWithValue("@orderid", OrderID);
            ord_det.Parameters.AddWithValue("@prod_id", ProdID);
            ord_det.Parameters.AddWithValue("@unitprice", Unit_Price);
            ord_det.Parameters.AddWithValue("@quantity", Quantity);

            try
            {
                ord_det.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Place_order(string Cx_ID, int EmpID, string Prod_Name, int Quantity)
        {
            con.Open();
            int Prod_ID = 0, Unit_Price = 0;


            SqlCommand cmd = new SqlCommand("SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC", con);
            int orderid = (int)cmd.ExecuteScalar();


            SqlCommand prodID = new SqlCommand("Select ProductID, UnitPrice from Products where ProductName=@prodname", con);
            prodID.Parameters.AddWithValue("prodname", Prod_Name);
            SqlDataReader r = prodID.ExecuteReader();

            while (r.Read())
            {
                Prod_ID = (int)r[0];
                Unit_Price = (int)r[1];
            }

            r.Close();
            Order_details(orderid, Prod_ID, Unit_Price, Quantity);


            SqlCommand ins = new SqlCommand("insert into Orders(CustomerID, EmployeeID, OrderDate) values( @cxid, @empid,@orderdate)", con);
            ins.Parameters.AddWithValue("cxid", Cx_ID);
            ins.Parameters.AddWithValue("@empid", EmpID);
            ins.Parameters.AddWithValue("@orderdate", DateTime.Now);
            try
            {
                ins.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
