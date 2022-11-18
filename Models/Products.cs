using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }


        public Products()
        {
            this.ProductID = 0;
            this.ProductName = "";
            this.UnitPrice = 0;
        }

        public int GetProdID()
        {
            return this.ProductID;
        }

        public string GetProdName()
        {
            return this.ProductName;
        }

        public decimal GetUnitPrice()
        {
            return this.UnitPrice;
        }

        public void SetID(int ID)
        {
            this.ProductID = ID;
        }

        public void SetProdName(string ProductName)
        {
            this.ProductName = ProductName;
        }

        public void SetUnitPrice(decimal UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }
    }
}
