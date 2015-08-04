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
    public partial class App_83_Add_SQL : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=.\SQLEXPRESS; DataBase=Lib_DB; Integrated Security =true");
        SqlCommand cmd;
        SqlDataReader sdr;
        public App_83_Add_SQL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPages.Clear();            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("insert into Books(ID,Title,Author,Pages_Number,Publish_Date) values('" + txtId.Text + "',N'" + txtTitle.Text + "',N'" + txtAuthor.Text + "'," + txtPages.Text + ",'" + dateP.Value + "')", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add Done", "Add SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Clear();
                txtTitle.Clear();
                txtAuthor.Clear();
                txtPages.Clear();            
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message,"Error",MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Error);   
            }
            finally
            {
                cn.Close();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("SELECT ID,Title,Author,Pages_Number,Publish_Date FROM Books WHERE ID='" + txtShow.Text + "'", cn);
                cn.Open();
                sdr = cmd.ExecuteReader();
                sdr.Read();
                txtId.Text = sdr["ID"].ToString();
                txtTitle.Text = sdr["Title"].ToString();
                txtAuthor.Text = sdr["Author"].ToString();
                txtPages.Text = sdr["Pages_Number"].ToString();
                dateP.Text = sdr["Publish_Date"].ToString();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);                   
            }
            finally
            {
                sdr.Close();
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE Books set Title=N'" + txtTitle.Text + "' ,Author=N'" + txtAuthor.Text + "' ,Pages_Number=" + txtPages.Text + ",Publish_Date='" + dateP.Value + "' WHERE ID='" + txtShow.Text + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Done", "Update SQL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {                
                cn.Close();
            }            
        }
    }
}
