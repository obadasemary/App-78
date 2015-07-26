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
    public partial class App_78 : Form
    {
        public App_78()
        {
            InitializeComponent();
            listView1.Columns.Add("Folders");
            listView1.Columns.Add("Descriptions");
            listView1.Items.Add("Folder 1", 0);
            listView1.Items.Add("Folder 2", 0);
            listView1.Items.Add("Folder 3", 0);
            listView1.Items.Add("Folder 4", 0);
            listView1.Items.Add("Folder 5", 0);
            listView1.Items.Add("Folder 6", 0);
            listView1.Items.Add("Folder 7", 0);
            listView1.Items.Add("Folder 8", 0);
        }

        private void App_78_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "LargeIcon")
            {
                listView1.View = View.LargeIcon;
            }
            else if (comboBox1.Text == "Details")
            {
                listView1.View = View.Details;
            }
            else if (comboBox1.Text == "List")
            {
                listView1.View = View.List;
            }
            else if (comboBox1.Text == "SmallIcon")
            {
                listView1.View = View.SmallIcon;
            }
            else if (comboBox1.Text == "Tile")
            {
                listView1.View = View.Tile;
            }          
        }
    }
}
