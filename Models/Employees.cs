using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }

        public Employees()
        {
            this.EmployeeID = 0;
            this.FirstName = "";
        }
        public int GetEmpID()
        {
            return this.EmployeeID;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public void SetEmpID(int ID)
        {
            this.EmployeeID = ID;
        }

        public void SetFirstName(string FirstName)
        {
            this.FirstName = FirstName;
        }
    }
}
