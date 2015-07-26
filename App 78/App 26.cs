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
    public partial class App_26 : Form
    {
        public App_26()
        {
            InitializeComponent();

            //Create 3 Groups

            listView1.Groups.Add("", "Social Media");
            listView1.Groups.Add("", "DeskTop");
            listView1.Groups.Add("", "Programs");

            //Add Items to the group 1

            listView1.Items.Add("Facebook", 0);
            listView1.Items.Add("Twitter", 1);
            listView1.Items.Add("Instegram", 2);

            listView1.Items[0].Group = listView1.Groups[0];
            listView1.Items[1].Group = listView1.Groups[0];
            listView1.Items[2].Group = listView1.Groups[0];

            //Add Items to the group 2

            listView1.Items.Add("Mac", 3);
            listView1.Items.Add("Ubuntu", 4);

            listView1.Items[3].Group = listView1.Groups[1];
            listView1.Items[4].Group = listView1.Groups[1];

            //Add Items to the group 3

            listView1.Items.Add("Visual Studio", 5);

            listView1.Items[5].Group = listView1.Groups[2];

        }
    }
}
