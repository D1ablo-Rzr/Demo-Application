using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }

        public OrderDetails()
        {
            this.OrderID = 0;
            this.EmployeeID = null;
            this.OrderDate = null;
        }

        public int GetOrderId()
        {
            return this.OrderID;
        }

        public int? GetEmpID()
        {
            return this.EmployeeID;
        }

        public DateTime? GetDate()
        {
            return this.OrderDate;
        }

        public void SetOrderId(int orderId)
        {
            this.OrderID = orderId;
        }
        public void SetEmpId(int? employId)
        {
            this.EmployeeID = employId;
        }
        public void SetDate(DateTime? orderDate)
        {
            this.OrderDate = orderDate;
        }
    }
}
