using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        private string _CxId, _CompanyName, _CustName, _CustTitle, _Address;

        public Customer()
        {
            this._CxId = "";
            this._CompanyName = "";
            this._CustName = "";
            this._CustTitle = "";
            this._Address = "";
        }

        public string GetId()
        {
            return _CxId;
        }
        public string GetCompName()
        {
            return _CompanyName;
        }
        public string GetCustName()
        {
            return _CustName;
        }
        public string GetTitle()
        {
            return _CustTitle;
        }
        public string GetAddress()
        {
            return _Address;
        }

        public void SetId(string ID)
        {
            this._CxId = ID;
        }

        public void SetCompName(string compName)
        {
            this._CompanyName = compName;
        }
        public void SetCustName(string custName)
        {
            this._CustName = custName;
        }
        public void SetTitle(string custTitle)
        {
            this._CustTitle = custTitle;
        }
        public void SetAddress(string address)
        {
            this._Address = address;
        }
        public bool IsEmpty()
        {
            if(this._CxId=="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
