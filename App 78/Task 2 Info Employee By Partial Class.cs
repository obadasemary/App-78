using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_78
{
    public partial class Task_2_Info_Employee_By_Partial_Class : Form
    {
        public Task_2_Info_Employee_By_Partial_Class()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.fName = txtFN.Text;
            emp.lName = txtLN.Text;
            emp.empName = emp.fName + "  " + emp.lName;
            emp.DeptName = txtDept.Text;
            emp.Email = txtEmail.Text;

            //StringBuilder sb = new StringBuilder();
            //sb.Append("Name : " + emp.empName);
            //sb.Append("\r\nDepartment : " + emp.DeptName);
            //sb.Append("<\r\nEmail : " + emp.Email);
            txtInfo.Text = emp.Display;
        }
    }
}
