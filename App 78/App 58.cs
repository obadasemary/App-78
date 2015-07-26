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
    public partial class App_58 : Form
    {
        public App_58()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Today is : " + DateTime.Now + "        ||       Computer Name is : " + Environment.MachineName;
        }
    }
}
