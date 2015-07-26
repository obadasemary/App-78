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
    public partial class App_13 : Form
    {
        int size = 12;
        public App_13()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.label1.Text = toolStripTextBox1.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.label1.Font = new Font("", size);
            size += 4;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (size == 0)
            {
                size = 12;
            }
            this.label1.Font = new Font("", size);
            size -= 4;
        }
    }
}
