using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_78
{
    public partial class Employee
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string Display
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(empName);
                sb.Append("\r\n" + this.DeptName);
                sb.Append("\r\n" + Email);
                return sb.ToString();
            }
            //set { display = value; }
        }
    }
}
