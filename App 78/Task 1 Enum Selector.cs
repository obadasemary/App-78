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
    public partial class Task_1_Enum_Selector : Form
    {
        enum Department
        {
            Human_Resources = 1,
            Finance = 2,
            Development = 3,
            IT = 4
        }
        public Task_1_Enum_Selector()
        {
            InitializeComponent();
        }

        private void Task_1_Enum_Selector_Load(object sender, EventArgs e)
        {

            //comboBox1.DataSource = Enum.GetNames(typeof(Department));
            //comboBox1.DataSource = Enum.GetValues(typeof(Department));
            //comboBox1.DisplayMember = "Text";


            //Array itemValues = Enum.GetValues(typeof(Department));
            //Array itemNames = Enum.GetNames(typeof(Department));

            //for (int i = 0; i < itemNames.Length - 1; i++)
            //{
            //    List item = itemNames[i],ite
            //}



            //foreach (var dep in Enum.GetNames(typeof(Department)))
            //{
            //    comboBox1.Items.Add(dep);
            //}

            comboBox1.DataSource = Enum.GetNames(typeof(Department));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department x = (Department)Enum.Parse(typeof(Department),comboBox1.Text);
            int y = (int)x;
            textBox1.Text = y.ToString();
            textBox2.Text = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox3.Text);
            string ena = Enum.GetName(typeof(Department), num);
            comboBox1.Text = ena;
            textBox3.Clear();
            //Department x = (Department)Enum.Parse(typeof(Department), textBox3.Text);
            //int y = (int)x;
            //textBox1.Text = textBox3.Text;
        }
    }
}
