using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Application.Models
{
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