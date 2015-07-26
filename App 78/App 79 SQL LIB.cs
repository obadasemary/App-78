using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace App_78
{
    public partial class App_79_SQL_LIB : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\OBADA; DataBase=Lib_DB; Integrated Security =true");
        SqlCommand cmd;
        SqlDataReader sdr;
        public App_79_SQL_LIB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT ID,Title,Author FROM Books",cn);            
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                listBox1.Items.Add("ID : "+sdr["ID"].ToString()+"\tTitle : "+sdr["Title"].ToString()+"\tAuthor : "+sdr["Author"].ToString());
            }
            sdr.Close();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            App_83_Add_SQL app = new App_83_Add_SQL();
            app.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM Books WHERE ID='" + textBox1.Text + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Remove Done", "Remove SQL", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox1.Clear();
                listBox1.Items.Clear();
            }
            catch (Exception exs)
            {
                MessageBox.Show(exs.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            App_87_Data app = new App_87_Data();
            app.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            App_88_Data_Views app = new App_88_Data_Views();
            app.Show();
        }
    }
}
