using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ProductDal
    {
        SqlConnection con = new SqlConnection(@"Data Source=SAL-BHATTI\SQLEXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=4Islamabad");

        public List<Products> AddProducts()
        {
            List<Products> ProductList = new List<Products>();
            con.Open();
            var cmd = new SqlCommand("select ProductID,ProductName from Products", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                Products Temp = new Products();
                Temp.SetID(rd.GetInt32(rd.GetOrdinal("ProductID")));
                Temp.SetProdName(rd.GetString(rd.GetOrdinal("ProductName")));
                ProductList.Add(Temp);
            }
            return ProductList;
        }

        public List<Employees> AddEmployees()
        {
            con.Open();
            List<Employees> EmployeeList = new List<Employees>();
            var cmd1 = new SqlCommand("select EmployeeId from Employees", con);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while(rd1.Read())
            {
                Employees Temp = new Employees();
                Temp.SetEmpID(rd1.GetInt32(rd1.GetOrdinal("EmployeeId")));
                EmployeeList.Add(Temp);
            }
            return EmployeeList;
        }
    }
}
