using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerTitle { get; set; } 
        public string Address { get; set; }

        public Customer()
        {
            this.CustomerId = "";
            this.CompanyName = "";
            this.CustomerName = "";
            this.CustomerTitle = "";
            this.Address = "";
        }

        public string GetId()
        {
            return CustomerId;
        }
        public string GetCompName()
        {
            return CompanyName;
        }
        public string GetCustName()
        {
            return CustomerName;
        }
        public string GetTitle()
        {
            return CustomerTitle;
        }
        public string GetAddress()
        {
            return Address;
        }

        public void SetId(string ID)
        {
            this.CustomerId = ID;
        }

        public void SetCompName(string compName)
        {
            this.CompanyName = compName;
        }
        public void SetCustName(string custName)
        {
            this.CustomerName = custName;
        }
        public void SetTitle(string custTitle)
        {
            this.CustomerTitle = custTitle;
        }
        public void SetAddress(string address)
        {
            this.Address = address;
        }
    }
}
