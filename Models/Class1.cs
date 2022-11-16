using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public string CxId, CompanyName, CustName, CustTitle, Address;

        public Customer()
        {
            CxId = "";
            CompanyName = "";
            CustName = "";
            CustTitle = "";
            Address = "";
        }

        public string get_ID()
        {
            return CxId;
        }
        public string get_CompName()
        {
            return CompanyName;
        }
        public string get_CustName()
        {
            return CustName;
        }
        public string get_title()
        {
            return CustTitle;
        }
        public string get_Address()
        {
            return Address;
        }

        public void set_ID(string ID)
        {
            this.CxId = ID;
        }

        public void set_CompName(string CompName)
        {
            this.CompanyName = CompName;
        }
        public void set_CustName(string Custname)
        {
            this.CustName = Custname;
        }
        public void set_Title(string Custtitle)
        {
            this.CustTitle = Custtitle;
        }
        public void set_Address(string address)
        {
            this.Address = address;
        }
    }

    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }

        public OrderDetails()
        {
            OrderID = 0;
            EmployeeID = null;
        }

        public int get_orderid()
        {
            return OrderID;
        }

        public int? get_empID()
        {
            return EmployeeID;
        }

        public DateTime? get_date()
        {
            return OrderDate;
        }

        public void set_orderid(int id)
        {
            this.OrderID = id;
        }
        public void set_empid(int? id)
        {
            this.EmployeeID = id;
        }
        public void set_date(DateTime? date)
        {
            this.OrderDate = date;
        }
    }
}
